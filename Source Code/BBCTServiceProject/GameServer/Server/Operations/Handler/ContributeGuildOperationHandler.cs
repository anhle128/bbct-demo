using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class ContributeGuildOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ContributeGuildRequestData requestData = new ContributeGuildRequestData();
            requestData.Deserialize(operationRequest.Parameters);


            if (requestData.type < 1 || requestData.type > 3)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }


            var member = MongoController.GuildDb.GuildMember.GetData(player.cacheData.info._id);

            if (member == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsNotMemberInGuild);
            }

            var guild = MongoController.GuildDb.Guild.GetDataByUserId(member.guild_id);

            if (guild == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            var log = MongoController.LogSubDB.ContributeLog.GetData(player.cacheData.info._id);

            bool isCan = true;
            if (log != null)
            {
                isCan = CommonFunc.IsPassDay(log.created_at);
            }

            if (!isCan)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }

            int contribution = GetContribution(requestData.type);
            int contributionMember = GetContributionMember(requestData.type);
            int price = GetPrice(requestData.type);

            if (!IsEnough(requestData.type, price, player))
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);
            }
            if (requestData.type == 1)
            {
                //CommonLog.Instance.PrintLog("tru silver");
                player.cacheData.info.silver -= price;
                MongoController.UserDb.Info.UpdateSilver(player.cacheData, TypeUseSilver.UpContributeGuild, price);
            }
            else
            {
                player.cacheData.info.gold -= price;
                //CommonLog.Instance.PrintLog("tru gold");
                //CommonLog.Instance.PrintLog("Player.cacheData.gold: " + Player.cacheData.gold);
                MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.UpContributeGuild, price);
            }

            if (log != null)
            {
                MongoController.LogSubDB.ContributeLog.UpdateTime(log._id);
            }
            else
            {
                MContributeGuildLog nLog = new MContributeGuildLog()
                {
                    user_id = player.cacheData.info._id,
                };
                MongoController.LogSubDB.ContributeLog.Create(nLog);
            }

            guild.contribution = guild.contribution + contribution;
            guild.tmp_contribution = guild.tmp_contribution + contribution;

            bool isUpLevel = MongoController.GuildDb.Guild.CheckUpLevelGuild(guild);

            member.contribution += contributionMember;
            MongoController.GuildDb.GuildMember.Update(member);

            ContributeGuildResponseData responseData = new ContributeGuildResponseData()
            {
                isUpLevel = isUpLevel,
                level = guild.level,
                contribution = guild.contribution,
                contributionMember = member.contribution,
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }

        private int GetContribution(int type)
        {
            if (type == 1)
            {
                return StaticDatabase.entities.configs.guildConfig.recieveContribute1;
            }
            if (type == 2)
            {
                return StaticDatabase.entities.configs.guildConfig.recieveContribute2;
            }
            if (type == 3)
            {
                return StaticDatabase.entities.configs.guildConfig.recieveContribute3;
            }
            return 0;
        }

        private int GetPrice(int type)
        {
            if (type == 1)
            {
                return StaticDatabase.entities.configs.guildConfig.priceContribute1;
            }
            if (type == 2)
            {
                return StaticDatabase.entities.configs.guildConfig.priceContribute2;
            }
            if (type == 3)
            {
                return StaticDatabase.entities.configs.guildConfig.priceContribute3;
            }
            return 0;
        }

        private bool IsEnough(int type, int price, GamePlayer player)
        {
            if (type == 1)
            {
                if (player.cacheData.info.silver < price)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (player.cacheData.info.gold < price)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private int GetContributionMember(int type)
        {
            if (type == 1)
            {
                return StaticDatabase.entities.configs.guildConfig.recieveContributeMember1;
            }
            if (type == 2)
            {
                return StaticDatabase.entities.configs.guildConfig.recieveContributeMember2;
            }
            if (type == 3)
            {
                return StaticDatabase.entities.configs.guildConfig.recieveContributeMember3;
            }
            return 0;
        }
    }


}
