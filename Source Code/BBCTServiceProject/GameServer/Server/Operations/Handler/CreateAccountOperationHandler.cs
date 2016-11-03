using DynamicDBModel;
using DynamicDBModel.Models;
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
using StaticDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class CreateAccountOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {
            if (GameController.Instance.userOnline.Count() >= Settings.Instance.maxConnection)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxConnection);

            CreateAccountRequestData requestData = new CreateAccountRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            bool existAccount = MongoController.UserDb.Info.CheckExistAccount(requestData.nickname,
                player.cacheData.info.username);

            if (existAccount)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AccountExist);

            if (StaticDatabase.entities.configs.characterConfig.defaultCharSelections.All(
                    a => a.id != requestData.char_id))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            // process
            // create character
            MUserCharacter userCharacter = new MUserCharacter()
            {
                static_id = requestData.char_id
            };
            MongoController.UserDb.Char.Create(userCharacter);

            // create user
            MUserInfo newUser = new MUserInfo()
            {
                username = player.cacheData.info.username,
                nickname = requestData.nickname,
                hash_code_login_time = CommonFunc.GetHashCodeTime()

            };

            newUser.avatar = requestData.char_id;

            FormationConfig formationConfig = StaticDatabase.entities.configs.formationConfig;

            newUser.formations = new DataFormation[formationConfig.maxNumberCharInFormation];

            for (int i = 0; i < newUser.formations.Length; i++)
            {
                newUser.formations[i] = new DataFormation()
                {
                    sub = new List<string>() { "-1", "-1", "-1", "-1", "-1", },
                    main = new StringArray[3]
                };

                DataFormation dataFormation = newUser.formations[i];

                for (int j = 0; j < dataFormation.main.Length; j++)
                {
                    dataFormation.main[j] = new StringArray();
                    dataFormation.main[j].columns = new string[3];
                    for (int k = 0; k < dataFormation.main[k].columns.Length; j++)
                    {
                        dataFormation.main[i].columns[j] = "-1";
                    }
                }
            }

            newUser.last_formation_used = 0;
            newUser.formations[0].main[1].columns[1] = userCharacter._id.ToString();

            MongoController.UserDb.Info.Create(newUser);
            userCharacter.user_id = newUser._id;
            MongoController.UserDb.Char.Update(userCharacter);

            player.SignIn(newUser);
            player.cacheData.info.avatar_star = userCharacter.star_level;

            if (StaticDatabase.entities.configs.playerDefaultConfig.rewards != null)
            {
                MongoController.UserDb.UpdateReward
                (
                    player.cacheData,
                    CommonFunc.ConvertToSubReward(StaticDatabase.entities.configs.playerDefaultConfig.rewards),
                    ReasonActionGold.RewardCreateAccount
                );
            }

            // response
            Entity entities = MongoController.GetEntity(player.cacheData, newUser);

            SignInResponseData responseData = new SignInResponseData()
            {
                entities = entities,
            };

            CommonLog.Instance.PrintLog("create account done!");

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}
