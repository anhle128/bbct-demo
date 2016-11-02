using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.MainDatabaseModels;
using MongoDBModel.SubDatabaseModels;
using StaticDB.Enum;
using StaticDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.SubDatataseCollection
{
    public class UserMailCollection : AbsCollectionController<MUserMail>
    {
        public UserMailCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }



        public List<MUserMail> GetDatas(string userid)
        {
            return GetListData
            (
                filter: a =>
                    a.user_id == userid &&
                    a.created_at >= DateTime.Now.AddDays(-3)
            ).OrderByDescending(a => a.created_at).ToList();
        }

        protected override void SetDefaultValue(MUserMail data)
        {
            data.readed = false;
            data.server_id = Settings.Instance.server_id;
        }

        public void UpdateReaded(MUserMail data)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>(1)
            {
                {"readed",true}
            };
            UpdateFields(data._id, dictData);
        }

        public void SendGiftThanThap(List<TopUserThanThap> listTopThanThap, List<TopReward> listTopReward)
        {
            List<MUserMail> listMails = new List<MUserMail>();
            for (int i = 0; i < listTopReward.Count; i++)
            {
                if (i > listTopThanThap.Count - 1)
                    break;

                List<SubRewardItem> listReward = listTopReward.Single(a => a.index == i).rewards;

                MUserMail userMail = new MUserMail()
                {
                    user_id = (listTopThanThap[i].userid),
                    title = "Phần thưởng top quỷ cốc tử",
                    content = "Chúc mừng bạn đã dành được hạng" + (i + 1),
                    rewards = listReward,
                    type = UserMailType.Normal
                };
                listMails.Add(userMail);
            }
            // create mails
            CreateAll(listMails);
        }

        public void SendGiftTopVongQuayMayMan(List<TopUserVongQuayMayMan> topUsers, List<TopReward> rewards)
        {
            List<MUserMail> listMailCreat = new List<MUserMail>();

            for (int i = 0; i < rewards.Count; i++)
            {
                if (i > topUsers.Count - 1)
                    break;

                TopUserVongQuayMayMan topUser = topUsers[i];
                TopReward reward = rewards[i];

                MUserMail mail = new MUserMail()
                {
                    user_id = (topUser.userid),
                    title = "Phần thưởng top sự kiện vòng quay may mắn",
                    content = string.Format("Chúc mừng bạn đã đạt hạng {0} trong sự kiện vòng quay may mắn", (i + 1)),
                    rewards = reward.rewards,
                    type = UserMailType.Normal,
                    readed = false
                };

                listMailCreat.Add(mail);
            }

            CreateAll(listMailCreat);
        }

        public void SendGiftTopLevelDuaTopServer(List<TopUser> topPlayers, List<TopReward> rewards)
        {
            List<MUserMail> listMailCreate = new List<MUserMail>();

            int countPlayer = topPlayers.Count;
            for (int i = 0; i < rewards.Count; i++)
            {
                if (i >= countPlayer)
                    break;

                TopUser topUser = topPlayers[i];
                TopReward reward = rewards[i];

                MUserMail mail = new MUserMail()
                {
                    user_id = (topUser.userid),
                    title = "Phần thưởng ''Sự Kiện Đua Top Cấp Độ''",
                    content = string.Format("Chúc mừng bạn đã đạt hạng {0} trong sự kiện đua top cấp độ", (i + 1)),
                    rewards = reward.rewards,
                    type = UserMailType.Normal,
                    readed = false
                };

                listMailCreate.Add(mail);
            }

            CreateAll(listMailCreate);
        }

        public void SendGiftTopPowerDuaTopServer(List<TopUser> topPlayers, List<TopReward> rewards)
        {
            List<MUserMail> listMailCreate = new List<MUserMail>();

            int countPlayer = topPlayers.Count;
            for (int i = 0; i < rewards.Count; i++)
            {
                if (i >= countPlayer)
                    break;

                TopUser topUser = topPlayers[i];
                TopReward reward = rewards[i];

                MUserMail mail = new MUserMail()
                {
                    user_id = (topUser.userid),
                    title = "Phần thưởng ''Sự Kiện Đua Top Lực Chiến''",
                    content = string.Format("Chúc mừng bạn đã đạt hạng {0} trong sự kiện đua top lực chiến", (i + 1)),
                    rewards = reward.rewards,
                    type = UserMailType.Normal,
                    readed = false
                };

                listMailCreate.Add(mail);
            }

            CreateAll(listMailCreate);
        }

        public void SendGiftLuanKiem()
        {
            List<MUserMail> listMail = new List<MUserMail>();
            var rangeSelect = StaticDatabase.entities.configs.luanKiemConfig.rankPoint.Where(a => a.rank.end != 10000);
            foreach (var rankPoint in rangeSelect)
            {
                List<MUserInfo> listuserInfo =
                    MongoController.UserDb.Info.GetListDataWithRank(rankPoint.rank.start, rankPoint.rank.end);
                foreach (var userInfo in listuserInfo)
                {
                    if (listMail.Any(a => a.user_id.Equals(userInfo._id)))
                        continue;
                    MUserMail mail = new MUserMail();
                    mail.user_id = userInfo._id;
                    mail.title = "Phần thưởng luận kiếm";
                    mail.content = "Chúc mừng bạn đã đạt thứ hạng cao trong bảng xếp hạng luận kiếm";
                    mail.type = UserMailType.Normal;
                    mail.rewards = new List<SubRewardItem>()
                    {
                        new SubRewardItem()
                        {
                            static_id = 1,
                            quantity = rankPoint.silverReward,
                            type_reward = (int)TypeReward.Silver
                        },
                        new SubRewardItem()
                        {
                            static_id = 1,
                            quantity = rankPoint.goldReward,
                            type_reward = (int)TypeReward.Gold
                        },
                        new SubRewardItem()
                        {
                            static_id = 1,
                            quantity = rankPoint.pointReward,
                            type_reward = (int)TypeReward.LuanKiemPoint
                        }
                    };
                    listMail.Add(mail);
                }
            }
            CreateAll(listMail);
        }

        public void SendGiftGlobalBoss(TopUsersGlobalBoss currentTopUsers, MGlobalBossConfig config)
        {
            List<TopReward> listTopReward = config.top_rewards.OrderBy(a => a.index).ToList();

            string[] arrUserId = currentTopUsers.topUsers.Select(a => a.userid).ToArray();

            List<MUserMail> listMails = new List<MUserMail>();
            for (int i = 0; i < listTopReward.Count; i++)
            {
                if (i >= arrUserId.Length)
                    break;
                List<SubRewardItem> listReward = listTopReward.Single(a => a.index == i).rewards;
                MUserMail userMail = new MUserMail()
                {
                    user_id = (arrUserId[i]),
                    title = "Phần thưởng top boss thế giới ",
                    content = "Chúc mừng bạn đã dành được hạng " + (i + 1),
                    rewards = listReward,
                    type = UserMailType.Normal
                };
                listMails.Add(userMail);
            }

            if (currentTopUsers.userKillBoss != null && !string.IsNullOrEmpty(currentTopUsers.userKillBoss.userid))
            {
                MUserMail userMailKillBoss = new MUserMail()
                {
                    user_id = (currentTopUsers.userKillBoss.userid),
                    title = "Phần thưởng kill boss thế giới ",
                    content = "Chúc mừng bạn là người may mắn đã last hit được con boss",
                    rewards = config.kill_boss_rewards,
                    type = UserMailType.Normal
                };
                listMails.Add(userMailKillBoss);
            }

            // create mails
            CreateAll(listMails);
        }

        public void SendGiftGuildBoss(List<MGuild> guilds, List<MBossGuildLog> listBosstGuildLog, List<MGuildMember> listGuildMembers)
        {
            DateTime now = DateTime.Now;

            List<MUserMail> listMails = new List<MUserMail>();

            foreach (var guild in guilds)
            {
                double totalDmg = listBosstGuildLog.Where(x => x.guild_id.Equals(guild._id) &&
                    x.created_at.Day == now.Day &&
                    x.created_at.Month == now.Month &&
                    x.created_at.Year == now.Year).Sum(x => x.dmg);

                List<SubRewardItem> rewards = new List<SubRewardItem>();

                foreach (var item in StaticDatabase.entities.configs.guildConfig.rewardBoss.OrderByDescending(a => a.minRange))
                {
                    int dmg = (int)totalDmg;
                    if (dmg >= item.minRange)
                    {
                        rewards.AddRange(item.rewards.Select(rw => new SubRewardItem()
                        {
                            static_id = rw.staticID,
                            quantity = CommonFunc.RandomNumber(rw.amountMin, rw.amountMax),
                            type_reward = rw.typeReward,
                        }));
                        break;
                    }
                }

                if (rewards.Count == 0)
                    continue;

                List<MGuildMember> listMemberInGuild = listGuildMembers.Where(a => a.guild_id == guild._id).ToList();
                listMails.AddRange(listMemberInGuild.Select(mem => new MUserMail()
                {
                    user_id = mem.user_id,
                    title = "Phần thưởng boss bang",
                    content = "Chúc mừng bạn đã chiến đấu giành được phần thưởng",
                    rewards = rewards,
                    type = UserMailType.Normal
                }));
            }
            CreateAll(listMails);
        }

        public void SendRubyBuyItemMarket(string userid, int priceReceive, int pricePercent)
        {
            MUserMail mail = new MUserMail()
            {
                title = "Bán thành công",
                content = string.Format("Bạn đã bán thành công một trang bị trong sàn giao dịch thu về {0} KNB . Phí giao dịch là {1} KNB", priceReceive, pricePercent),
                readed = false,
                user_id = userid,
                type = UserMailType.Normal,
                rewards = new List<SubRewardItem>(),
            };
            SubRewardItem rw = new SubRewardItem()
            {
                quantity = priceReceive,
                type_reward = (int)TypeReward.Ruby,
            };
            mail.rewards.Add(rw);
            Create(mail);
        }

        public void SendMailAttackedLuanKiem(string nickname, string useridOppenent, int newRank)
        {
            MUserMail mail = new MUserMail()
            {
                title = "Thư chiến báo",
                content = string.Format("Bạn vừa bị người chơi {0} đánh bại trong luận kiếm. Thứ hạng lùi về {1}", nickname, newRank),
                user_id = useridOppenent
            };
            MongoController.UserDb.Mail.Create(mail);
        }

        public void SendMailTopSuKienDoiDo(TopUserDoiDo[] topUsers, List<TopRewardDoiDo> topRewards)
        {
            List<MUserMail> listMails = new List<MUserMail>();

            for (int i = 0; i < topUsers.Length; i++)
            {
                TopUserDoiDo user = topUsers[i];
                List<SubRewardItem> rewards = topRewards[i].rewards;
                MUserMail userMail = new MUserMail()
                {
                    user_id = (user.userid),
                    title = "Phần thưởng top kho báu chiều đình",
                    content = "Chúc mừng bạn đã đạt thứ hạng " + (i + 1),
                    readed = false,
                    type = UserMailType.Normal,
                    rewards = rewards
                };

                listMails.Add(userMail);
            }

            CreateAll(listMails);
        }

        public void SendGiftBangChien(List<MGuildMember> listMembers, List<SubRewardItem> rewards)
        {
            List<MUserMail> mails = new List<MUserMail>();
            foreach (var mem in listMembers)
            {
                MUserMail mail = new MUserMail()
                {
                    rewards = rewards,
                    readed = false,
                    content = "Chúc mừng bang của bạn đã chiến thắng bang chiến",
                    title = "Chiến thắng bang chiến",
                    type = UserMailType.Normal,
                    user_id = mem.user_id,
                };
                mails.Add(mail);
            }
            MongoController.UserDb.Mail.CreateAll(mails);
        }

        public void SendMail2xRuby(List<MTransaction> listTrans)
        {
            List<MUserMail> listUserMail = new List<MUserMail>();
            foreach (var trans in listTrans)
            {

                MUserMail mailBonus = new MUserMail()
                {
                    user_id = trans.user_id,
                    content =
                        string.Format("Chúc mừng bạn đã nạp thẻ thành công và nhận được {0} kim cương từ sự kiên x2", trans.ruby),
                    title = "Thư nhận thưởng kim cương sự kiện x2",
                    readed = false,
                    type = UserMailType.ThuongNapThe,
                    rewards = new List<SubRewardItem>()
                        {
                            new SubRewardItem()
                            {
                                quantity = int.Parse(trans.ruby.ToString()),
                                static_id = 0,
                                type_reward = (int) TypeReward.Ruby
                            }
                        }
                };

                listUserMail.Add(mailBonus);
            }
            CreateAll(listUserMail);
        }

        public void SendMail2xRubyDenBu(List<MTransaction> listTrans)
        {
            List<MUserMail> listUserMail = new List<MUserMail>();
            foreach (var trans in listTrans)
            {

                MUserMail mailBonus = new MUserMail()
                {
                    user_id = trans.user_id,
                    content =
                        string.Format("Chúc mừng bạn đã nạp thẻ thành công và nhận được {0} kim cương đền bù", trans.ruby),
                    title = "Thư đền bù x2 ruby",
                    readed = false,
                    type = UserMailType.ThuongNapThe,
                    rewards = new List<SubRewardItem>()
                        {
                            new SubRewardItem()
                            {
                                quantity = int.Parse(trans.ruby.ToString()),
                                static_id = 0,
                                type_reward = (int) TypeReward.Ruby
                            }
                        },
                    server_id = trans.server_id,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                listUserMail.Add(mailBonus);
            }
            CreateAllImmediately(listUserMail);
        }

        public void SendMailThuongNapLanDau_x2Ruby(string userid, List<MTransaction> listTrans, List<SubRewardItem> thuongNapRewards, bool x2Ruby)
        {
            List<MUserMail> listUserMail = new List<MUserMail>();

            if (x2Ruby)
            {
                foreach (var trans in listTrans)
                {
                    MUserMail mainBonus = new MUserMail()
                    {
                        user_id = userid,
                        content = string.Format("Chúc mừng bạn đã nạp thẻ thành công và nhận được {0} kim cương thưởng thêm cho lần nạp lần đầu", trans.ruby),
                        title = "Thư thưởng x2 kim cương",
                        readed = false,
                        type = UserMailType.ThuongNapThe,
                        rewards = new List<SubRewardItem>()
                        {
                            new SubRewardItem()
                            {
                                quantity = int.Parse(trans.ruby.ToString()),
                                static_id = 0,
                                type_reward = (int) TypeReward.Ruby
                            }
                        }
                    };

                    MUserMail mailBonusx2 = new MUserMail()
                    {
                        user_id = userid,
                        content =
                            string.Format("Chúc mừng bạn đã nạp thẻ thành công và nhận được {0} kim cương từ sự kiên x2", trans.ruby),
                        title = "Thư nhận thưởng kim cương sự kiện x2",
                        readed = false,
                        type = UserMailType.ThuongNapThe,
                        rewards = new List<SubRewardItem>()
                        {
                            new SubRewardItem()
                            {
                                quantity = int.Parse(trans.ruby.ToString()),
                                static_id = 0,
                                type_reward = (int) TypeReward.Ruby
                            }
                        }
                    };

                    listUserMail.Add(mailBonusx2);
                    listUserMail.Add(mainBonus);
                }
            }
            else
            {
                foreach (var trans in listTrans)
                {
                    MUserMail mainBonus = new MUserMail()
                    {
                        user_id = userid,
                        content = string.Format("Chúc mừng bạn đã nạp thẻ thành công và nhận được {0} kim cương thưởng thêm cho lần nạp lần đầu", trans.ruby),
                        title = "Thư thưởng x2 kim cương",
                        readed = false,
                        type = UserMailType.ThuongNapThe,
                        rewards = new List<SubRewardItem>()
                    {
                        new SubRewardItem()
                        {
                            quantity = int.Parse(trans.ruby.ToString()),
                            static_id = 0,
                            type_reward = (int) TypeReward.Ruby
                        }
                    }
                    };

                    listUserMail.Add(mainBonus);
                }
            }

            MUserMail mailThuongNap = new MUserMail()
            {
                user_id = userid,
                content = "Chúc mừng bạn đã nạp thẻ thành công và nhận được phần thưởng nạp lần đầu.",
                title = "Thư thưởng nạp lần đâu",
                rewards = thuongNapRewards
            };
            listUserMail.Add(mailThuongNap);

            CreateAll(listUserMail);
        }

        public void SendGiftPhucLoiThang(string userid, List<Reward> rewards)
        {
            MUserMail userMail = new MUserMail()
            {
                rewards = CommonFunc.ConvertToSubReward(rewards),
                user_id = userid,
                title = "Quà VIP tháng",
                content = "Chúc mừng bạn đã nhận được phần thưởng hấp dẫn từ hoạt động quà VIP tháng",
                type = UserMailType.Normal,
                readed = false
            };
            Create(userMail);
        }

        public void SendGiftPhucLoiThang(string[] userids, List<Reward> rewards)
        {
            List<MUserMail> listUserMail = userids.Select(userid => new MUserMail()
            {
                rewards = CommonFunc.ConvertToSubReward(rewards),
                user_id = userid,
                title = "Quà VIP tháng",
                content = "Chúc mừng bạn đã nhận được phần thưởng hấp dẫn từ hoạt động quà VIP tháng",
                type = UserMailType.Normal,
                readed = false
            }).ToList();
            CreateAll(listUserMail);
        }

        public MUserMail GetData(string mailId)
        {
            return
                GetSingleData(
                    a => a._id.Equals((mailId)));
        }
    }
}
