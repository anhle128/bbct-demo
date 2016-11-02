using DynamicDBModel.Models;
using ExitGames.Client.Photon;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database;
using Player = GameConsoleClient.Components.Player;

namespace GameConsoleClient.Action
{
    public class ActionAttackMap : AbsAction
    {
        int currentMap = 0;
        int currentStage = 0;

        public ActionAttackMap(Player player)
            : base(player)
        {

        }

        public override void Prepare()
        {
            //MongoController.UserDb.Stage.DeleteAll(a => a.username == Player.GetUsername());
        }

        public override void DoAction()
        {
            currentMap = 0;
            currentStage = 0;

            base.DoAction();
            StartAttackMap();
        }

        public override void OnResponse(OperationResponse operationResponse)
        {
            base.OnResponse(operationResponse);
            //Common.PrintLog(operationResponse.OperationCode, operationResponse.ReturnCode);
            if (operationResponse.ReturnCode == (short)ReturnCode.OK)
            {
                OperationCode code = (OperationCode)operationResponse.OperationCode;
                switch (code)
                {
                    case OperationCode.StartAttackStage:
                        EndAttackMap();
                        break;
                    case OperationCode.EndAttackStage:
                        StartAttackMap();
                        break;
                }
            }
            else if (operationResponse.ReturnCode == (short)ReturnCode.MaxAttackTimes)
            {
                StartAttackMap();
            }
            else
            {
                player.StartNewAction();
            }
        }

        public void CheckAttackMap()
        {
            try
            {
                if (StaticDatabase.entities.maps.Length == currentMap)
                {
                    player.StartNewAction();
                    return;
                }

                if (StaticDatabase.entities.maps[currentMap].stages.Length == currentStage)
                {
                    currentStage = 0;
                    currentMap++;
                    //CheckAttackMap();
                }
            }
            catch (System.Exception ex)
            {
                player.StartNewAction();
            }

        }


        private void StartAttackMap()
        {
            //CheckAttackMap();
            ActionStageRequestData requestData = new ActionStageRequestData()
            {
                stage_info = new StageMode()
                {
                    level = 1,
                    map_index = 0,
                    stage_index = 0
                }

            };
            //Console.WriteLine(string.Format("stage: {0} - map: {1}", currentStage, currentMap));
            player.DoOperationRequest(OperationCode.StartAttackStage, requestData.Serialize());
            currentStage++;
        }

        private void EndAttackMap()
        {
            EndAttackStageRequestData requestData = new EndAttackStageRequestData()
            {
                star = 1
            };

            player.DoOperationRequest(OperationCode.EndAttackStage, requestData.Serialize());
        }
    }
}
