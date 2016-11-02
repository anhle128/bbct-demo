using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.SubDatataseCollection
{
    public class GuildCollection : AbsCollectionController<MGuild>
    {
        public GuildCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }


        protected override void SetDefaultValue(MGuild data)
        {
            data.server_id = Settings.Instance.server_id;
        }

        public MGuild GetData(string guildId)
        {
            return GetSingleData(x => x._id.Equals(guildId));
        }

        public MGuild GetDataByUserId(string userid)
        {
            return GetSingleData(x => x.user_id.Equals(userid));
        }

        public List<MGuild> GetTopContributionGuils()
        {
            return GetListData(x => x.server_id.Equals(Settings.Instance.server_id)).OrderByDescending(x => x.tmp_contribution).ThenBy(x => x.level).ToList();
        }


        public List<MGuild> GetTopLevelGuils()
        {
            return GetListData(x => x.server_id.Equals(Settings.Instance.server_id)).OrderByDescending(x => x.level).ToList();
        }

        public List<MGuild> GetDatas()
        {
            return GetListData(a => a.server_id.Equals(Settings.Instance.server_id));
        }

        public List<MGuild> FindGuilds(string keyword)
        {
            return GetListData(x => x.server_id.Equals(Settings.Instance.server_id) && x.name.ToLower().Contains(keyword));
        }


        public bool CheckExistGuildName(string name)
        {
            return CountData(x => x.name.Equals(name) && x.server_id.Equals(Settings.Instance.server_id)) == 1;
        }

        public void UpdateMaster(string guildId, string newMasterUsername)
        {
            Dictionary<string, string> dictData = new Dictionary<string, string>(1)
            {
                {"userid",newMasterUsername}
            };
            UpdateFields(guildId, dictData);
        }

        public void UpdateContribution(string guildId, int newContribution, int tmpContribute)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>(1)
            {
                {"contribution", newContribution},
                {"tmp_contribution", tmpContribute},
            };
            UpdateFields(guildId, dictData);
        }

        public void ResetAllTmpContribution()
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>(1)
            {
                {"tmp_contribution", 0},
            };

            Dictionary<string, string> filterData = new Dictionary<string, string>(1)
            {
                {"server_id", Settings.Instance.server_id},
            };

            UpdateAll(filterData, dictData);
        }

        public void UpdateLevelConstruction(string guildId, int newLevel)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>(1)
            {
                {"level", newLevel}
            };
            UpdateFields(guildId, dictData);
        }

        public void UpdateNotice(string guildId, string newNotice)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>(1)
            {
                {"notice", newNotice}
            };
            UpdateFields(guildId, dictData);
        }

        public bool CheckUpLevelGuild(MGuild guild)
        {
            int level = guild.level;
            int contribution = guild.contribution;
            bool isUpLevel = false;
            while (contribution >= StaticDatabase.entities.configs.guildConfig.levelContribution[level - 1].contribution)
            {
                if (level >= StaticDatabase.entities.configs.guildConfig.maxLevel)
                {
                    contribution = StaticDatabase.entities.configs.guildConfig.levelContribution[level - 1].contribution - 1;
                    Dictionary<string, object> dictData = new Dictionary<string, object>(1)
                    {
                        {"contribution",contribution},
                        {"tmp_contribution",guild.tmp_contribution}
                    };
                    UpdateFields(guild._id, dictData);
                    break;
                }
                else
                {
                    isUpLevel = true;
                    contribution -= StaticDatabase.entities.configs.guildConfig.levelContribution[level - 1].contribution;
                    level++;
                }
            }
            if (isUpLevel)
            {
                guild.level = level;
                guild.contribution = contribution;
                Dictionary<string, object> dictData = new Dictionary<string, object>(1)
                {
                    {"level", level},
                    {"contribution",contribution},
                    {"tmp_contribution",guild.tmp_contribution}
                };
                UpdateFields(guild._id, dictData);
            }
            else
            {
                Dictionary<string, object> dictData = new Dictionary<string, object>(1)
                {
                    {"contribution",contribution},
                    {"tmp_contribution",guild.tmp_contribution}
                };
                UpdateFields(guild._id, dictData);
            }
            return isUpLevel;
        }
    }
}
