using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataVanTieuOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            if (player.cacheData.info.level < StaticDatabase.entities.configs.vanTieuConfig.levelRequire)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);

            int countVanTieuDone =
                MongoController.UserDb.VanTieu.CountStartVanTieu(player.cacheData.info._id);
            // vận tiêu còn của ngày hôm trước
            MUserVanTieu currentUserVanTieu =
                MongoController.UserDb.VanTieu.GetPrevData(player.cacheData.info._id);
            // nêu o còn thì lấy vận tiêu mới ngày hôm nay
            if (currentUserVanTieu == null)
                currentUserVanTieu = MongoController.UserDb.VanTieu.GetDataByUserId(player.cacheData.info._id);

            VanTieuResponseData responseData = null;
            if (currentUserVanTieu == null)
            {
                currentUserVanTieu = new MUserVanTieu()
                {
                    user_id = player.cacheData.info._id,
                    hash_code_time = CommonFunc.GetHashCodeTime(),
                    level = player.cacheData.info.level,
                    nickname = player.cacheData.info.nickname,
                    vip = player.cacheData.info.vip,
                    end = false,
                    start = false
                };
                MongoController.UserDb.VanTieu.Create(currentUserVanTieu);

                responseData = new VanTieuResponseData()
                {
                    times = countVanTieuDone,
                    current_vehicle = null
                };
            }
            else
            {
                responseData = new VanTieuResponseData();
                responseData.times = countVanTieuDone;
                if (currentUserVanTieu.current_vehicle != null)
                {
                    responseData.current_vehicle = new CurVehicle();
                    responseData.current_vehicle.going_on = currentUserVanTieu.current_vehicle.going_on;
                    responseData.current_vehicle.type = currentUserVanTieu.current_vehicle.type;
                    if (currentUserVanTieu.users_cuop_tieu != null)
                    {
                        responseData.current_vehicle.countTimesBiCuop = currentUserVanTieu.users_cuop_tieu.Count;
                    }
                    if (currentUserVanTieu.current_vehicle.going_on)
                    {
                        responseData.current_vehicle.time = CommonFunc.GetRestTimeSecond(currentUserVanTieu.current_vehicle.start,
                                StaticDatabase.entities.configs.vanTieuConfig.GetSecondDurationTime());
                    }

                    int silverReward = StaticDatabase.entities.configs.GetSilverVanTieuReward
                    (
                    currentUserVanTieu.users_cuop_tieu != null ? currentUserVanTieu.users_cuop_tieu.Count : 0,
                        currentUserVanTieu.current_vehicle.type
                    );
                    if (currentUserVanTieu.rewards == null)
                        currentUserVanTieu.rewards = new List<SubRewardItem>();

                    currentUserVanTieu.rewards.Add(new SubRewardItem()
                    {
                        quantity = silverReward,
                        static_id = 0,
                        type_reward = (int)TypeReward.Silver
                    });
                    responseData.current_vehicle.rewards = currentUserVanTieu.rewards;

                    if (currentUserVanTieu.users_cuop_tieu != null && currentUserVanTieu.users_cuop_tieu.Count > 0)
                    {

                        List<MUserInfo> listUseInfoCuopTieu = new List<MUserInfo>();

                        foreach (var username in currentUserVanTieu.users_cuop_tieu)
                        {
                            MUserInfo userCuopTieu = MongoController.UserDb.Info.GetData(username);
                            if (userCuopTieu != null)
                                listUseInfoCuopTieu.Add(userCuopTieu);
                        }

                        List<Player> listCuopTieuPlayers = listUseInfoCuopTieu.Select(info => new Player()
                        {
                            nickname = info.nickname,
                            userid = info._id.ToString(),
                            vip = info.vip,
                            level = info.level,
                            avatar = info.avatar,
                        }).ToList();
                        responseData.cuop_tieu_players = listCuopTieuPlayers;
                    }
                }
            }
            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetDataVanTieuOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}
