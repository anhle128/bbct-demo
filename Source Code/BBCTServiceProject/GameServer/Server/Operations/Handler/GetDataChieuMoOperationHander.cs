using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataChieuMoOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {
            MUserInfo userInfo = MongoController.UserDb.Info.GetData(player.cacheData.id);

            if (userInfo == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DBError);

            ChieuMo chieuMoResult = new ChieuMo();

            MChieuMoConfig chieuMoConfig = MongoController.ConfigDb.ChieuMo.GetData();
            //.GetSingleData(a => a.server_id == Settings.Instance.server_id);
            if (chieuMoConfig == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DBError);
            chieuMoResult.quay_tuong_normal = SetChieuMoData
            (
                chieuMoConfig.quay_tuong.normal_config,
                userInfo.last_time_free_quay_tuong_normal
            );
            chieuMoResult.quay_tuong_special = SetChieuMoData
            (
                chieuMoConfig.quay_tuong.special_config,
                userInfo.last_time_free_quay_tuong_special
            );
            chieuMoResult.quay_vat_pham = SetChieuMoData
            (
                chieuMoConfig.quay_vat_pham.normal_config,
                userInfo.last_time_free_quay_vat_pham
            );
            chieuMoResult.count_time_free_quay_tuong_normal = userInfo.count_times_free_quay_tuong_normal;
            chieuMoResult.max_free_quay_tuong_normal_in_day = chieuMoConfig.quay_tuong.normal_config.max_free_in_day;

            DataChieuMoResponseData responseData = new DataChieuMoResponseData()
            {
                data = chieuMoResult
            };

            // responseData
            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetDataChieuMoOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }

        private ChieuMoPrice SetChieuMoData(MQuayTuongPrice chieuMoPrice, DateTime lastTimeFree)
        {
            ChieuMoPrice resultData = new ChieuMoPrice();
            resultData.price = chieuMoPrice.price;
            resultData.x10_price = chieuMoPrice.x10_price;
            resultData.rest_free_time = CommonFunc.GetRestTimeSecond(lastTimeFree, chieuMoPrice.wait_time_free * 60);
            return resultData;
        }

        private ChieuMoPrice SetChieuMoData(MQuayVatPhamPrice chieuMoPrice, DateTime lastTimeFree)
        {
            ChieuMoPrice resultData = new ChieuMoPrice();
            resultData.price = chieuMoPrice.price;
            resultData.x10_price = chieuMoPrice.x10_price;
            //resultData.rest_free_time = CommonFunc.CalculateSecondTimeSpand(chieuMoPrice.wait_time_free, lastTimeFree);
            resultData.rest_free_time = CommonFunc.GetRestTimeSecond(lastTimeFree, chieuMoPrice.wait_time_free * 60);
            return resultData;
        }


    }
}
