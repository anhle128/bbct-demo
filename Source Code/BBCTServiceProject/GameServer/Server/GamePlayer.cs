using DynamicDBModel.Models;
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
                username = username,
            };
        }

        public void SignIn(MUserInfo userInfo)
        {
            state = State.SignIn;

            cacheData = new PlayerCacheData();
            cacheData.id = userInfo._id;
            cacheData.username = userInfo.username;
            cacheData.nickname = userInfo.nickname;
            cacheData.avatar = userInfo.avatar;
            cacheData.level = userInfo.level;
            cacheData.exp = userInfo.exp;
            cacheData.vip = userInfo.vip;
            cacheData.x = (float)userInfo.posX;
            cacheData.y = (float)userInfo.posY;
            cacheData.silver = userInfo.silver;
            cacheData.gold = userInfo.gold;
            cacheData.ruby = userInfo.ruby;
            cacheData.lastest_stage_attacked = userInfo.lastest_stage_attacked;
            cacheData.highest_stages_attacked = userInfo.highest_stages_attacked;
            cacheData.stamina = userInfo.stamina;
            cacheData.point_skill = userInfo.point_skill;
            cacheData.formation = userInfo.formation;
            cacheData.last_time_update_stamina = userInfo.last_time_update_stamina;
            cacheData.list_time_update_point_skill = userInfo.last_time_update_point_skill;
            cacheData.pointLuanKiem = userInfo.point_luan_kiem;
            cacheData.rankLuanKiem = userInfo.rank_luan_kiem;
            cacheData.lastTimeAttackLuanKiem = userInfo.last_time_attack_luan_kiem;
            cacheData.allBonusThanThapAttributes = userInfo.all_bonus_than_thap_attributes;
            cacheData.total_ruby_trans = userInfo.total_ruby_trans;
            cacheData.create_at = userInfo.created_at;
            cacheData.last_time_update_point_skill = userInfo.last_time_update_point_skill;
            cacheData.doi_hinh_du_bi = userInfo.doi_hinh_du_bi;

            GameController.Instance.AddUserOnline(userInfo.username, this);
            cacheData.loginId = MongoController.LogDb.LoginLog.Login(cacheData.id);
            var guildMem = MongoController.GuildDb.GuildMember.GetData(userInfo._id);
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
            cacheData.avatar_star = userInfo.avatar_star;

            if (cacheData.highest_stages_attacked == null)
            {
                userInfo.highest_stages_attacked = new StageMode()
                {
                    map_index = 0,
                    stage_index = 0,
                    level = 1,
                };
            }

            cacheData.listUserChar = new List<MUserCharacter>();
            cacheData.listUserEquip = new List<MUserEquip>();
            cacheData.listUserItem = new List<MUserItem>();

            GameController.Instance.Subscription(peer.BroadcastMessage);
        }

        public void SignInTest(MUserInfo userInfo)
        {
            state = State.SignIn;

            cacheData = new PlayerCacheData();
            cacheData.id = userInfo._id;
            cacheData.username = userInfo.username;
            cacheData.nickname = userInfo.nickname;
            cacheData.avatar = userInfo.avatar;
            cacheData.level = userInfo.level;
            cacheData.exp = userInfo.exp;
            cacheData.vip = userInfo.vip;
            cacheData.x = (float)userInfo.posX;
            cacheData.y = (float)userInfo.posY;
            cacheData.silver = userInfo.silver;
            cacheData.gold = userInfo.gold;
            cacheData.ruby = userInfo.ruby;
            cacheData.lastest_stage_attacked = userInfo.lastest_stage_attacked;
            cacheData.highest_stages_attacked = userInfo.highest_stages_attacked;
            cacheData.stamina = userInfo.stamina;
            cacheData.point_skill = userInfo.point_skill;
            cacheData.formation = userInfo.formation;
            cacheData.last_time_update_stamina = userInfo.last_time_update_stamina;
            cacheData.list_time_update_point_skill = userInfo.last_time_update_point_skill;
            cacheData.pointLuanKiem = userInfo.point_luan_kiem;
            cacheData.rankLuanKiem = userInfo.rank_luan_kiem;
            cacheData.lastTimeAttackLuanKiem = userInfo.last_time_attack_luan_kiem;
            cacheData.allBonusThanThapAttributes = userInfo.all_bonus_than_thap_attributes;
            cacheData.total_ruby_trans = userInfo.total_ruby_trans;
            cacheData.create_at = userInfo.created_at;
            cacheData.last_time_update_point_skill = userInfo.last_time_update_point_skill;
            cacheData.doi_hinh_du_bi = userInfo.doi_hinh_du_bi;
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
                    if (GameController.Instance.IsUserOnline(cacheData.id))
                    {
                        GameController.Instance.RemoveUserOnline(cacheData.id);
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
