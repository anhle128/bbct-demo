using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.NotifyMessage;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.SubDatataseCollection
{
    public class BattleBangChienCollection : AbsCollectionController<MBattleBangChien>
    {
        public BattleBangChienCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {

        }

        public void UpdateDamage(MBattleBangChien bangChien, int lane, string team, double plusDmg)
        {
            string col = "";
            double dmg = plusDmg;
            if (lane == 1)
            {
                col = "dmg_top_" + team;
                if (team.Equals("a"))
                {
                    dmg += bangChien.dmg_top_a;
                }
                else
                {
                    dmg += bangChien.dmg_top_b;
                }
            }
            else if (lane == 2)
            {
                col = "dmg_mid_" + team;
                if (team.Equals("a"))
                {
                    dmg += bangChien.dmg_mid_a;
                }
                else
                {
                    dmg += bangChien.dmg_mid_b;
                }
            }
            else
            {
                col = "dmg_bot_" + team;
                if (team.Equals("a"))
                {
                    dmg += bangChien.dmg_bot_a;
                }
                else
                {
                    dmg += bangChien.dmg_bot_b;
                }
            }
            Dictionary<string, object> dictData = new Dictionary<string, object>(1)
            {
                {col, dmg}
            };
            UpdateFields(bangChien._id, dictData);
        }

        public void ProcessStartBangChien(int time)
        {
            if (time == 1)
            {
                #region Khởi tạo hoạt động bang chiến

                var guilds = MongoController.GuildDb.Guild.GetDatas().ToList();

                List<MGuild> filterGuild = new List<MGuild>();

                foreach (var g in guilds)
                {
                    int countMember = MongoController.GuildDb.GuildMember.CountMemberInGuild(g._id);
                    if (countMember >= StaticDatabase.entities.configs.guildConfig.bangChienMinMember)
                    {
                        filterGuild.Add(g);
                    }
                }

                if (filterGuild.Count >= 8)
                {
                    var orderGuilds = filterGuild.OrderByDescending(x => x.tmp_contribution).ThenByDescending(x => x.level).ToList();

                    List<MGuild> lstGuild = new List<MGuild>();
                    string[] objIdGuilds = new string[8];
                    for (int i = 0; i < 8; i++)
                    {
                        lstGuild.Add(orderGuilds[i]);
                        objIdGuilds[i] = orderGuilds[i]._id;
                    }

                    MBangChien bangChien = new MBangChien()
                    {
                        server_id = Settings.Instance.server_id,
                        state = BangChien.State.DangDienRa,
                        start_time = DateTime.Now,
                        guilds = objIdGuilds,
                    };

                    MongoController.GuildDb.BangChien.Create(bangChien);

                    Shuffle<MGuild>(lstGuild);

                    List<MBattleBangChien> lstBattleBangChien = new List<MBattleBangChien>();

                    for (int i = 0; i < 4; i++)
                    {
                        MBattleBangChien battleBangChien = new MBattleBangChien()
                        {
                            guild_a = lstGuild[i]._id,
                            guild_b = lstGuild[i + 4]._id,
                            id_bangchien = bangChien._id,
                            result = (int)BattleBangChien.Result.DangDienRa,
                            round = 1,
                            dmg_bot_a = 0,
                            dmg_bot_b = 0,
                            dmg_mid_a = 0,
                            dmg_mid_b = 0,
                            dmg_top_a = 0,
                            dmg_top_b = 0,
                        };
                        lstBattleBangChien.Add(battleBangChien);

                    }

                    MongoController.GuildDb.BattleBangChien.CreateAll(lstBattleBangChien);
                }

                MongoController.GuildDb.Guild.ResetAllTmpContribution();

                #endregion
            }
            else
            {
                var bangChien = MongoController.GuildDb.BangChien.GetData(BangChien.State.DangDienRa);

                if (bangChien != null)
                {
                    var battles = MongoController.GuildDb.BattleBangChien.GetListData(x => x.id_bangchien.Equals(bangChien._id) &&
                    x.result == (int)BattleBangChien.Result.ChuaDienRa &&
                    x.round == time);

                    foreach (var battle in battles)
                    {
                        StartBattle(battle._id);
                    }
                }

            }
        }

        public void ProcessEndBangChien(int time)
        {
            //CommonLog.Instance.PrintLog("ProcessEndBangChien time: " + time);
            List<string> winGuilds = new List<string>();

            var bangChien = MongoController.GuildDb.BangChien.GetData(BangChien.State.DangDienRa);
            if (bangChien != null)
            {
                #region Tính kết quả cho các trận đấu đang diễn ra trong round hiện tại

                var battles = MongoController.GuildDb.BattleBangChien.GetListData(x => x.id_bangchien.Equals(bangChien._id) &&
                    x.result == (int)BattleBangChien.Result.DangDienRa &&
                    x.round == time);

                foreach (var battle in battles)
                {
                    int pointA = 0;
                    int pointB = 0;

                    if (battle.dmg_bot_a > battle.dmg_bot_b)
                    {
                        pointA++;
                    }
                    else if (battle.dmg_bot_a < battle.dmg_bot_b)
                    {
                        pointB++;
                    }

                    if (battle.dmg_mid_a > battle.dmg_mid_b)
                    {
                        pointA++;
                    }
                    else if (battle.dmg_mid_a < battle.dmg_mid_b)
                    {
                        pointB++;
                    }

                    if (battle.dmg_top_a > battle.dmg_top_b)
                    {
                        pointA++;
                    }
                    else if (battle.dmg_top_a < battle.dmg_top_b)
                    {
                        pointB++;
                    }

                    if (pointA > pointB)
                    {
                        Dictionary<string, object> dictData = new Dictionary<string, object>(1)
                        {
                            {"result", (int)BattleBangChien.Result.BenAThang},
                        };
                        UpdateFields(battle._id, dictData);
                        winGuilds.Add(battle.guild_a);
                    }
                    else
                    {
                        Dictionary<string, object> dictData = new Dictionary<string, object>(1)
                        {
                            {"result", (int)BattleBangChien.Result.BenBThang},
                        };
                        UpdateFields(battle._id, dictData);
                        winGuilds.Add(battle.guild_b);
                    }
                }

                #endregion

                #region Tạo các trận đấu cho vòng (round) tiếp theo

                if (time == 1)
                {
                    List<MBattleBangChien> lstBattleBangChien = new List<MBattleBangChien>();

                    for (int i = 0; i < 4; i += 2)
                    {
                        MBattleBangChien battleBangChien = new MBattleBangChien()
                        {
                            guild_a = winGuilds[i],
                            guild_b = winGuilds[i + 1],
                            id_bangchien = bangChien._id,
                            result = (int)BattleBangChien.Result.ChuaDienRa,
                            round = 2,
                            dmg_bot_a = 0,
                            dmg_bot_b = 0,
                            dmg_mid_a = 0,
                            dmg_mid_b = 0,
                            dmg_top_a = 0,
                            dmg_top_b = 0,
                        };
                        lstBattleBangChien.Add(battleBangChien);
                    }

                    MongoController.GuildDb.BattleBangChien.CreateAll(lstBattleBangChien);
                }
                else if (time == 2)
                {
                    MBattleBangChien battleBangChien = new MBattleBangChien()
                    {
                        guild_a = winGuilds[0],
                        guild_b = winGuilds[1],
                        id_bangchien = bangChien._id,
                        result = (int)BattleBangChien.Result.ChuaDienRa,
                        round = 3,
                        dmg_bot_a = 0,
                        dmg_bot_b = 0,
                        dmg_mid_a = 0,
                        dmg_mid_b = 0,
                        dmg_top_a = 0,
                        dmg_top_b = 0,
                    };
                    MongoController.GuildDb.BattleBangChien.Create(battleBangChien);
                }

                #endregion

                #region Kết thúc hoạt động và trao thưởng

                if (time == 3)
                {
                    CommonLog.Instance.PrintLog("End bang chien, chao truong thoi ae");
                    var members = MongoController.GuildDb.GuildMember.GetDatas(winGuilds[0]);
                    List<SubRewardItem> rewards =
                        CommonFunc.ConvertToSubReward(StaticDatabase.entities.configs.guildConfig.rewardBangChien);
                    MongoController.UserDb.Mail.SendGiftBangChien(members, rewards);
                    bangChien.state = BangChien.State.DaKetThuc;
                    MongoController.GuildDb.BangChien.Update(bangChien);

                    MGuild guild = MongoController.GuildDb.Guild.GetDataByUserId(winGuilds[0]);

                    CommonLog.Instance.PrintLog("Bang chien thang: " + guild.name);
                    NotifyMessageController.Instance.SendTop1WarGild(guild.name);
                }

                #endregion
            }
        }

        public void Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            Random rnd = new Random();
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public void StartBattle(string id)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>(1)
            {
                {"result", (int)BattleBangChien.Result.DangDienRa}
            };
            UpdateFields(id, dictData);
        }

        public List<MBattleBangChien> GetDatas(string id)
        {
            return GetListData(a => a.id_bangchien.Equals(id));
        }

        public MBattleBangChien GetData(string id)
        {
            return GetSingleData(x => x._id.Equals((id)));
        }
    }
}
