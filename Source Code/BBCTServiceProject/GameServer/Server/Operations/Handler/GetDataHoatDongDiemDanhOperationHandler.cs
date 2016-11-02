using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataHoatDongDiemDanhOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            MonthReward monthReward =
                StaticDatabase.entities.configs.hoatDongDiemDanhConfig.monthRewards.FirstOrDefault(a => a.month == DateTime.Today.Month);
            if (monthReward == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

            double currentIndex = StaticDatabase.entities.configs.hoatDongDiemDanhConfig.GetCurrentIndex();

            MUserDienDanhThang userDiemDanh =
                MongoController.UserDb.DiemDanhThang.GetData(player.cacheData.info._id, monthReward.month);
            if (userDiemDanh == null)
            {
                userDiemDanh = new MUserDienDanhThang()
                {
                    user_id = player.cacheData.info._id,
                    month = monthReward.month,
                    year = DateTime.Now.Year
                };
                MongoController.UserDb.DiemDanhThang.Create(userDiemDanh);

                HoatDongDiemDanhThangResponseData responsedata = new HoatDongDiemDanhThangResponseData()
                {
                    currentIndex = (int)currentIndex,
                    month = monthReward.month,
                    indexDayRewards = new List<int>()
                };

                return new OperationResponse()
                {
                    OperationCode = operationRequest.OperationCode,
                    DebugMessage = "GetDataHoatDongDiemDanhOperationHandler done!",
                    Parameters = responsedata.Serialize(),
                    ReturnCode = (short)ReturnCode.OK
                };
            }
            else
            {
                HoatDongDiemDanhThangResponseData responsedata = new HoatDongDiemDanhThangResponseData()
                {
                    currentIndex = (int)currentIndex,
                    month = monthReward.month,
                    indexDayRewards = userDiemDanh.index_day_rewards
                };

                return new OperationResponse()
                {
                    OperationCode = operationRequest.OperationCode,
                    DebugMessage = "GetDataHoatDongDiemDanhOperationHandler done!",
                    Parameters = responsedata.Serialize(),
                    ReturnCode = (short)ReturnCode.OK
                };
            }



        }
    }
}
