using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.MMO;
using GameServer.MMO.Concepts;
using Photon.SocketServer;
using System;
using System.Collections.Generic;

namespace GameServer.Server
{
    public class GameController
    {
        #region Singleton
        private static readonly GameController _instance = new GameController();
        public static GameController Instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion

        public ObjectCache<GamePlayer> userOnline;

        private static readonly object syncRoot = new object();
        public event Action<MMOPeer, EventData, SendParameters, Dictionary<byte, object>> BroadcastMessage;

        public ListCache<ChatData> chatData;

        public GameController()
        {
            userOnline = new ObjectCache<GamePlayer>();
            chatData = new ListCache<ChatData>();
        }

        public void Subscription(Action<MMOPeer, EventData, SendParameters, Dictionary<byte, object>> BroadcastMessageDelegate)
        {
            lock (syncRoot)
            {
                BroadcastMessage += BroadcastMessageDelegate;
            }
        }

        public void UnSubscription(Action<MMOPeer, EventData, SendParameters, Dictionary<byte, object>> BroadcastMessageDelegate)
        {
            lock (syncRoot)
            {
                BroadcastMessage -= BroadcastMessageDelegate;
            }
        }

        public void FireEvent(MMOPeer peer, SendParameters sendParameters, byte eventCode,
            Dictionary<byte, object> evParams, Dictionary<byte, object> subParams)
        {
            EventData @event = new EventData(eventCode)
            {
                Parameters = evParams
            };

            lock (syncRoot)
            {
                BroadcastMessage(peer, @event, sendParameters, subParams);
            }
        }

        public bool AddChat(PlayerCacheData cacheData, string message)
        {
            try
            {
                if (chatData.Count() >= Settings.Instance.maxLengthCacheChat - 1)
                {
                    CommonLog.Instance.PrintLog("count here: " + chatData.Count());
                    chatData.RemoveItem(0);
                }
            }
            catch (Exception ex)
            {
                CommonLog.Instance.PrintLog(ex.ToString());
            }


            ChatData cData = new ChatData()
            {
                avatar = cacheData.info.avatar,
                message = message,
                nickname = cacheData.info.nickname,
                username = cacheData.info.username,
                vip = cacheData.info.vip,
            };
            return chatData.AddItem(cData);
        }

        #region Users Online Manager
        public bool AddUserOnline(string username, GamePlayer player)
        {
            return userOnline.AddItem(username, player);
        }

        public bool IsUserOnline(string userId)
        {
            if (String.IsNullOrEmpty(userId.ToString()))
            {
                return false;
            }
            else
            {
                GamePlayer tmp;
                return userOnline.TryGetItem(userId.ToString(), out tmp);
            }
        }

        public bool RemoveUserOnline(string userId)
        {
            if (userOnline.items.ContainsKey(userId.ToString()))
            {
                return userOnline.RemoveItem(userId.ToString());
            }
            return false;
        }

        public GamePlayer GetUserOnline(string userId)
        {
            GamePlayer tmp;
            if (userOnline.TryGetItem(userId.ToString(), out tmp))
            {
                return tmp;
            }
            return null;
        }
        #endregion
    }
}
