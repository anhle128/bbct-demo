
using DynamicDBModel.Enum;
using KDQHGameServer.Common;
using KDQHGameServer.Common.Enum;
using KDQHGameServer.Common.SerializeData.RequestData;
using KDQHGameServer.Server.Operations.Core;
using KHQHGameServer.Database;
using KHQHGameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using StaticDB.Models;
using System.Linq;

namespace KDQHGameServer.Server.Operations.Handler
{
    public class ChangeSkillCharOperationHandler : IOperationHandler
    {
        public Photon.SocketServer.OperationResponse Handler(GamePlayer player, Photon.SocketServer.OperationRequest operationRequest, Photon.SocketServer.SendParameters sendParameters, OperationController controller)
        {
            UpSkillRequestData requestData = new UpSkillRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MUserCharacter userChar =
                player.cacheData.listUserChar.FirstOrDefault(a => a._id.ToString() == requestData.char_id);

            // kiểm tra user character
            if (userChar == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            Character character = StaticDatabase.entities.characters.Single(a => a.id == userChar.static_id);

            // kiểm tra character được thay skill
            if (character.isMain == false)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            // kiểm tra skill passive
            if (requestData.type_skill == TypeSkill.Ultimate && (requestData.index_skill > 0 && userChar.level < StaticDatabase.entities.configs.characterConfig.levelUnlockMainSkills[requestData.index_skill-1]))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            else if (requestData.type_skill == TypeSkill.Passive && userChar.powerup_level < StaticDatabase.entities.configs.characterConfig.powerUpLevelUnlockPassiveSkill)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            else if (requestData.type_skill == TypeSkill.Passive2 && userChar.level < StaticDatabase.entities.configs.characterConfig.levelUnlockPassiveSkill2)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            userChar.index_used_skills[(int)requestData.type_skill] = requestData.index_skill;

            // update
            MongoController.UserDb.Char.UpdateUsedSkill(userChar);

            // Response
            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}
