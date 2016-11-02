using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Server.Operations.Core;
using GameServer.Database;
using GameServer.Database.Controller;
using Photon.SocketServer;
using System;

namespace GameServer.Server.Operations.Handler
{
    public class GetPointSkillOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            double time = 0;

            if (player.cacheData.point_skill >= StaticDatabase.entities.configs.maxPointSkill)
            {
                time = -1;
            }
            else
            {
                int maxPointSkillReceive = StaticDatabase.entities.configs.maxPointSkill - player.cacheData.point_skill;

                TimeSpan timeSpan = DateTime.Now - player.cacheData.last_time_update_point_skill;
                //CommonLog.Instance.PrintLog("Player.cacheData.last_time_update_point_skill: " + Player.cacheData.last_time_update_point_skill);
                double coolDownTime = StaticDatabase.entities.configs.GetSecondCoolDownPlusPointSkill();
                double totalSecond = timeSpan.TotalSeconds;
                if (timeSpan.TotalSeconds > coolDownTime)
                {
                    double pointSkillReceive = totalSecond / coolDownTime;

                    if (pointSkillReceive > maxPointSkillReceive)
                        pointSkillReceive = maxPointSkillReceive;

                    player.cacheData.point_skill += (int)pointSkillReceive;

                    MongoController.UserDb.Info.UpdatePlusPointSkill(player.cacheData);

                    if (player.cacheData.point_skill == StaticDatabase.entities.configs.maxPointSkill)
                    {
                        time = -1;
                    }
                    else
                    {
                        DateTime nextTimePlus =
                            player.cacheData.list_time_update_point_skill.AddMinutes(
                                StaticDatabase.entities.configs.timeCooldownPlusPointSkill);
                        time = (nextTimePlus - DateTime.Now).TotalSeconds;
                    }
                }
                else
                {
                    time = coolDownTime - timeSpan.TotalSeconds;
                }
            }

            GetCooldownPointResponseData responseData = new GetCooldownPointResponseData()
            {
                point = player.cacheData.point_skill,
                cooldown_time = time
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetPointSkillOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}
