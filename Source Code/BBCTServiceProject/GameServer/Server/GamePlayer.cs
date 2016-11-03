using GameServer.Database.Controller;
using GameServer.MMO.Concepts;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;

namespace GameServer.Server
{
    public class GamePlayer
    {
        public enum State
        {
            Lobby,
            SignIn,
            InWorld,
            Diconnect
        }
        public State state;

        public PlayerCacheData cacheData;

        public DateTime timeChat = new DateTime();

        public OperationController operationController;

        public MMOPeer peer;
        public Item item;

        public GamePlayer(MMOPeer peer)
        {
            state = State.Lobby;
            this.peer = peer;
            operationController = new OperationController(peer, this);
        }

        public void FirstSignIn(string username)
        {
            cacheData = new PlayerCacheData()
            {
                info = new MUserInfo()
                {
                    username = username
                }
            };
        }

        public void SignIn(MUserInfo userInfo)
        {
            state = State.SignIn;

            cacheData = new PlayerCacheData();
            cacheData.info = userInfo;

            GameController.Instance.AddUserOnline(userInfo.username, this);
            cacheData.loginId = MongoController.LogDb.LoginLog.Login(cacheData.info._id);
            var guildMem = MongoController.GuildDb.GuildMember.GetData(cacheData.info._id);
            string guildName = null;
            string guildId = null;
            if (guildMem != null)
            {
                var guild = MongoController.GuildDb.Guild.GetDataByUserId(guildMem.guild_id);
                if (guild != null)
                {
                    guildName = guild.name;
                    guildId = guild._id.ToString();
                }

            }
            cacheData.guildName = guildName;
            cacheData.guildId = guildId;
            cacheData.listUserChar = new List<MUserCharacter>();
            cacheData.listUserEquip = new List<MUserEquip>();
            cacheData.listUserItem = new List<MUserItem>();

            GameController.Instance.Subscription(peer.BroadcastMessage);
        }

        public void SignInTest(MUserInfo userInfo)
        {
            state = State.SignIn;

            cacheData = new PlayerCacheData();
            cacheData.info = userInfo;
        }



        public void SignOut()
        {
            if (state != State.Diconnect)
            {
                if (MongoController.LogDb != null && MongoController.LogDb.LoginLog != null && cacheData != null)
                {
                    MongoController.LogDb.LoginLog.Logout(cacheData.loginId);
                }
                MongoController.UserDb.Info.UpdatePosition(cacheData);
                ExitWorld();
                GameController.Instance.UnSubscription(peer.BroadcastMessage);
                if (cacheData != null)
                {
                    if (GameController.Instance.IsUserOnline(cacheData.info._id))
                    {
                        GameController.Instance.RemoveUserOnline(cacheData.info._id);
                        cacheData = null;
                    }
                }
            }
        }

        public void EnterWorld(Item item)
        {
            state = State.InWorld;
            this.item = item;

        }

        public void ExitWorld()
        {
            if (state == State.InWorld)
            {
                //MongoController.UserDb.Info.UpdatePosition((cacheData.id), cacheData.x, cacheData.y);
                item.ExitWorld();
                item = null;
                state = State.SignIn;
            }
        }
    }
}
