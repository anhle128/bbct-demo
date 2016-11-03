using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class PowerupCharOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            PowerupCharRequestData request = new PowerupCharRequestData();
            request.Deserialize(operationRequest.Parameters);


            if (request.char_stocks.Any(a => a.Equals(request.char_powerup)))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            MUserCharacter userChar =
                player.cacheData.listUserChar.FirstOrDefault(a => a._id.Equals(request.char_powerup));
            if (userChar == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidChar);

            if (userChar.powerup_level >= StaticDatabase.entities.configs.characterConfig.maxPowerup)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxPowerupLevel);

            List<MUserCharacter> listUserCharStock = new List<MUserCharacter>();

            int totalExp = 0;
            int totalSilver = 0;
            foreach (var charStock in request.char_stocks)
            {
                MUserCharacter userCharStock = player.cacheData.listUserChar.FirstOrDefault(a => a._id.Equals(charStock));

                if (userCharStock == null)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidChar);

                listUserCharStock.Add(userCharStock);
                totalExp += StaticDatabase.entities.configs.characterConfig.GetExpReceiveToPowerup
                (
                    userChar.star_level,
                    userCharStock.star_level
                );

                totalSilver +=
                    StaticDatabase.entities.configs.characterConfig.GetSilverNeedToPowerup(userCharStock.star_level);
            }

            if (totalSilver > player.cacheData.info.silver)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughSliver);

            player.cacheData.info.silver -= totalSilver;
            userChar.exp += totalExp;

            if (userChar.exp > 100)
            {
                userChar.exp = 0;
                userChar.powerup_level++;
            }

            player.cacheData.DeleteAllUserChar(listUserCharStock);
            MongoController.UserDb.Char.Update_PowerupLevel(userChar);
            MongoController.UserDb.Info.UpdateSilver(player.cacheData, TypeUseSilver.PowerupChar, totalSilver);

            RewardResponseData response = new RewardResponseData()
            {
                user_silver = player.cacheData.info.silver
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "",
                Parameters = response.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}
