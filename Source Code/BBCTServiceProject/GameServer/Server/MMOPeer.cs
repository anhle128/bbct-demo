using GameServer.Common.Enum;
using GameServer.Common.SerializeData.EventData;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;
using PhotonHostRuntimeInterfaces;
using System;
using System.Collections.Generic;

namespace GameServer.Server
{
    /// <summary>
    /// Đóng vai trò xử lý cho 1 client kết nối đến server_id lúc đầu , khi client đó chưa enter vào world nào
    /// </summary>
    public class MMOPeer : Peer, IOperationHandler
    {
        #region Properties
        public GamePlayer Player;
        private readonly object _objectLock = new object();

        /// <summary>
        ///   Gets or sets the counter subscription.
        ///   Counters are subscribed with operation <see cref = "SubscribeCounter" /> and unsubscribed with <see cref = "OperationCode.UnsubscribeCounter" />.
        /// </summary>
        //public IDisposable CounterSubscription { get; set; }

        /// <summary>
        ///   Gets or sets the MMO radar subscription.
        ///   The radar is subscribed with operation <see cref = "RadarSubscribe" />.
        /// </summary>
        //public IDisposable MmoRadarSubscription { get; set; }
        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Initializes a new instance of the <see cref = "MmoPeer" /> class.
        /// </summary>
        /// <param name = "rpcProtocol">
        ///   The rpc protocol.
        /// </param>
        /// <param name = "nativePeer">
        ///   The native peer.
        /// </param>
        [CLSCompliant(false)]
        public MMOPeer(IRpcProtocol rpcProtocol, IPhotonPeer nativePeer)
            : base(rpcProtocol, nativePeer)
        {
            Player = new GamePlayer(this);
            this.SetCurrentOperationHandler(this);
        }

        #endregion

        #region Implement
        /// <summary>
        ///   <see cref = "IOperationHandler" /> implementation.
        ///   Stops any further operation handling and disposes the peer's resources.
        /// </summary>
        /// <param name = "peer">
        ///   The client peer.
        /// </param>
        public void OnDisconnect(PeerBase peer)
        {
            //CommonLog.Instance.PrintLog("MMOPeer - OnDisconnect");
            Player.SignOut();
            this.SetCurrentOperationHandler(null);
            this.Dispose();
            peer.Dispose();
        }

        /// <summary>
        ///   <see cref = "IOperationHandler" /> implementation.
        ///   Disconnects the peer.
        /// </summary>
        /// <param name = "peer">
        ///   The client peer.
        /// </param>
        public void OnDisconnectByOtherPeer(PeerBase peer)
        {
            // Disconnect after any queued events are sent
            peer.RequestFiber.Enqueue(() => peer.RequestFiber.Enqueue(peer.Disconnect));
        }

        /// <summary>
        /// <see cref = "IOperationHandler" /> implementation.
        /// Mỗi khi có operation từ client request lên sẽ đưa vào xử lý trong hàm này
        /// </summary>
        /// <param name="peer"></param>
        /// <param name="operationRequest"></param>
        /// <param name="sendParameters"></param>
        /// <returns></returns>
        public OperationResponse OnOperationRequest(PeerBase peer, OperationRequest operationRequest, SendParameters sendParameters)
        {
            //// Cho Operation Handler xử lý request từ client
            //lock (_objectLock)
            //{

            //}
            return Player.operationController.HandleOperation(operationRequest, sendParameters);
        }

        public void SendEvent(byte code, Dictionary<byte, object> param)
        {
            var eventData = new EventData(code, param);
            this.SendEvent(eventData, new SendParameters());
        }

        #endregion

        public void BroadcastMessage(MMOPeer peer, EventData evData, SendParameters sendParameters, Dictionary<byte, object> param)
        {
            if (peer != this)
            {
                if (evData.Code == (byte)EventCode.ChatServer)
                {
                    ChatServerEventData data = new ChatServerEventData()
                    {
                        username = peer.Player.cacheData.username,
                        nickname = peer.Player.cacheData.nickname,
                        avatar = peer.Player.cacheData.avatar,
                        message = param[1].ToString(),
                        vip = peer.Player.cacheData.vip
                    };
                    SendEvent((byte)EventCode.ChatServer, data.Serialize());
                }
                else if (evData.Code == (byte)EventCode.NotifyMessage)
                {
                    NotifyMessageEventData data = new NotifyMessageEventData()
                    {
                        message = param[1].ToString()
                    };
                    SendEvent((byte)EventCode.NotifyMessage, data.Serialize());
                }
                else if (evData.Code == (byte)EventCode.ChatGuild)
                {
                    if (peer.Player.cacheData.guildId.Equals(this.Player.cacheData.guildId))
                    {
                        ChatServerEventData data = new ChatServerEventData()
                        {
                            username = peer.Player.cacheData.username,
                            nickname = peer.Player.cacheData.nickname,
                            avatar = peer.Player.cacheData.avatar,
                            message = param[1].ToString(),
                            vip = peer.Player.cacheData.vip
                        };
                        SendEvent((byte)EventCode.ChatGuild, data.Serialize());
                    }

                }
            }

            if (evData.Code == (byte)EventCode.BossDeath)
            {
                NotifyMessageEventData data = new NotifyMessageEventData()
                {
                    message = param[1].ToString()
                };
                SendEvent((byte)EventCode.BossDeath, data.Serialize());
            }
        }
    }
}
