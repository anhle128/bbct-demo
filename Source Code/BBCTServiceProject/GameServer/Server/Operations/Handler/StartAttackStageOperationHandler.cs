using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using StaticDB.Models;

namespace GameServer.Server.Operations.Handler
{
    public class StartAttackStageOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {
            ActionStageRequestData requestData = new ActionStageRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            PlayerCacheData userInfo = player.cacheData;

            // kiểm tra thể lực
            Map mapData = StaticDatabase.entities.maps[requestData.stage_info.map_index];
            Stage stage = mapData.stages[requestData.stage_info.stage_index];
            if (userInfo.stamina < stage.stamina)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DoesNotEnoughStamina);

            //Get UserState
            MUserStage userStage = MongoController.UserDb.Stage.GetData(player.cacheData.id,
                requestData.stage_info);

            bool isNull = false;
            if (userStage == null)
            {
                isNull = true;
                userStage = new MUserStage()
                {
                    user_id = player.cacheData.id,
                    stage_info = new UserStage()
                    {
                        stage = new StageMode()
                        {
                            stage_index = requestData.stage_info.stage_index,
                            map_index = requestData.stage_info.map_index,
                            level = requestData.stage_info.level,
                        },
                        attack_times = 0,
                        star = 0
                    }
                };
            }

            if (!CheckValidStage(userStage, userInfo))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidStage);

            if (userStage.stage_info.attack_times >= stage.maxAttack)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxAttackTimes);


            CommonFunc.CheckStaminaAndCooldownTime(player);

            //neu la map level 1 thi save lan cuoi danh vao cache
            if (userStage.stage_info.stage.level == 1)
                userInfo.lastest_stage_attacked = userStage.stage_info.stage;

            //Progress Data
            userInfo.stamina -= stage.stamina;
            userStage.stage_info.attack_times += 1;

            if (isNull)
                MongoController.UserDb.Stage.Create(userStage);
            else
                MongoController.UserDb.Stage.Update(userStage);

            MongoController.UserDb.Info.Update_Stamina_StageAttacked(userInfo);
            MongoController.LogSubDB.NhiemVuHangNgay.SaveLogNhiemVu(player.cacheData.id, TypeNhiemVuHangNgay.AttackStage);

            userInfo.stageAttacked = userStage;

            //response
            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }


        private bool CheckValidStage(MUserStage uStage, PlayerCacheData userInfo)
        {
            if (uStage.stage_info.stage.map_index == 0 &&
                uStage.stage_info.stage.stage_index == 0)
                return true;

            StageMode prevStage = GetPrevStage(uStage.stage_info.stage);
            MUserStage userStage = MongoController.UserDb.Stage.GetData(userInfo.id, prevStage);


            if (userStage == null)
                return false;

            return userStage.stage_info.star > 0;
        }

        private StageMode GetPrevStage(StageMode stageMode)
        {
            int prevIndexMap = stageMode.map_index;
            int prevIndexStage = stageMode.stage_index;

            // danh stage dau tien cua map
            if (prevIndexStage == 0)
            {
                if (prevIndexMap != 0)
                {
                    prevIndexMap = stageMode.map_index - 1;
                    prevIndexStage = StaticDatabase.entities.maps[prevIndexMap].stages.Length - 1;
                }

            }
            else
            {
                prevIndexStage = stageMode.stage_index - 1;
            }

            StageMode stageModeResult = new StageMode()
            {
                stage_index = prevIndexStage,
                level = stageMode.level,
                map_index = prevIndexMap
            };

            return stageModeResult;
        }

    }
}
