using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Database.Controller;
using MongoDBModel.MainDatabaseModels;
using Photon.SocketServer;
using System;

namespace GameServer.Server.Operations.Core
{
    public class OperationController
    {
        private readonly PeerBase _peer;
        private readonly GamePlayer _player;

        private HandlerFactory _handlerFactory;

        public OperationController(PeerBase peer, GamePlayer gamePlayer)
        {
            this._peer = peer;
            this._player = gamePlayer;
            this._handlerFactory = new HandlerFactory();

        }

        public OperationResponse HandleOperation(OperationRequest operationRequest, SendParameters sendParameters)
        {
            try
            {
                if (!MMOApplication.IsDoneLoadData)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.ServerNotReady);
                if (!_handlerFactory.Handlers.ContainsKey(operationRequest.OperationCode))
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OperationCodeError);
                //if (_player.cacheData != null)
                //{
                //    CommonLog.Instance.PrintLog(string.Format("nickname: {0} - {1}", _player.cacheData.nickname, (OperationCode)operationRequest.OperationCode));
                //}
                return _handlerFactory.Handlers[operationRequest.OperationCode].
                    Handler(_player, operationRequest, sendParameters, this);
            }
            catch (Exception ex)
            {
                CommonLog.Instance.PrintLog(ex.ToString());
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.ExceptionError);
            }

        }

        public void SendResponse(OperationResponse response, SendParameters sendParameters)
        {
            _peer.SendOperationResponse(response, sendParameters);
        }
    }
}
