using DynamicDBModel;
using DynamicDBModel.Enum;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.GlobalInfo;
using GameServer.NapThe;
using GameServer.Server.Operations.Core;
using MongoDBModel.MainDatabaseModels;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class SignInOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {
            if (GameController.Instance.userOnline.Count() >= Settings.Instance.maxConnection)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxConnection);

            SignInRequestData requestData = new SignInRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            string data = EncryptLiblary.CryptLib.Instance.AesDecrypt(requestData.token);
            string[] split = data.Split('-');

            string username = split[0];

            return ProcessSignin(player, operationRequest, username);
        }

        private static OperationResponse ProcessSignin(GamePlayer player, OperationRequest operationRequest, string username)
        {
            MUserInfo userInfo = MongoController.UserDb.Info.GetDataByUsername(username);

            if (userInfo == null)
            {
                player.FirstSignIn(username);

                return new OperationResponse()
                {
                    OperationCode = operationRequest.OperationCode,
                    DebugMessage = "",
                    Parameters = new Dictionary<byte, object>(),
                    ReturnCode = (short)ReturnCode.FirstSignin
                };
            }
            else
            {
                // kiểm tra tài khoản có bị khóa hay không
                if (userInfo.isLocked)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AccountLocked);

                // kiểm tra user có đang đăng nhập hay không
                if (GameController.Instance.userOnline.items.ContainsKey(username))
                {
                    GamePlayer currentPlayer = GameController.Instance.userOnline.items[username];

                    currentPlayer.peer.SendEvent((byte)EventCode.ForceDisconnected, new Dictionary<byte, object>());

                    currentPlayer.SignOut();
                }

                player.SignIn(userInfo);

                // kiểm tra reset lượt đánh hàng ngày
                if (userInfo.hash_code_login_time != CommonFunc.GetHashCodeTime())
                {
                    userInfo.hash_code_login_time = CommonFunc.GetHashCodeTime();
                    MongoController.UserDb.Info.ClearInfo(userInfo);
                    MongoController.UserDb.Stage.ClearAllAttackTimes(userInfo);
                }
                // reset chúc phúc
                if (userInfo.hash_code_time_chuc_phuc != CommonFunc.GetHashCodeTime())
                {
                    if (userInfo.count_chuc_phuc == StaticDatabase.entities.configs.chucPhucConfig.maxChucPhuc)
                    {
                        userInfo.count_chuc_phuc = 0;
                        MongoController.UserDb.Info.UpdateChucPhuc(userInfo);
                    }
                }

                // check payment
                List<MTransaction> listNewTrans = MongoController.LogDb.Trans.GetCheckTrans(player.cacheData.info._id);
                MSKx2NapConfig x2Config = MongoController.ConfigDb.Skx2Nap.GetData();
                if (x2Config == null)
                    SuKienInfo.SetDeactiveSuKien(TypeSuKien.x2Nap);
                if (listNewTrans.Count > 0)
                {
                    NapTheHandler.CheckTrans(player, operationRequest, listNewTrans, x2Config);

                    userInfo.vip = player.cacheData.info.vip;
                    userInfo.total_ruby_trans = player.cacheData.info.total_ruby_trans;
                    userInfo.ruby = player.cacheData.info.ruby;
                }

                Entity entities = MongoController.GetEntity(player.cacheData, userInfo);

                SignInResponseData responseData = new SignInResponseData()
                {
                    entities = entities
                };

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
}
