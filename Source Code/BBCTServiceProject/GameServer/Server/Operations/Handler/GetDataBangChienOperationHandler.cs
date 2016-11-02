using DynamicDBModel.Models;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Server.Operations.Core;
using GameServer.Database;
using GameServer.Database.Controller;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataBangChienOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            var bangChienDuring = MongoController.GuildDb.BangChien.GetData(BangChien.State.DangDienRa);

            if (bangChienDuring == null)
            {
                var bangChiensOld = MongoController.GuildDb.BangChien.GetDatas(BangChien.State.DaKetThuc);

                if (bangChiensOld.Count > 0)
                {
                    // Trả về bang chiến đã kết thúc gần nhất
                    var bangChiensOldOrder = bangChiensOld.OrderByDescending(x => x.created_at).ToList();

                    if ((DateTime.Now - bangChiensOldOrder[0].created_at).TotalHours > 24)
                    {
                        GetDataBangChienResponseData responseData = new GetDataBangChienResponseData()
                        {
                            state = 0,
                        };
                        return new OperationResponse()
                        {
                            OperationCode = operationRequest.OperationCode,
                            DebugMessage = "",
                            Parameters = responseData.Serialize(),
                            ReturnCode = (short)ReturnCode.OK
                        };
                    }
                    else
                    {
                        GetDataBangChienResponseData responseData = new GetDataBangChienResponseData()
                        {
                            state = 1,
                        };
                        responseData.bangChien = new BangChien()
                        {
                            _id = bangChiensOldOrder[0]._id.ToString(),
                            state = bangChiensOldOrder[0].state,
                            guilds = new Guild[8],
                            battles = new List<BattleBangChien>(),
                        };

                        for (int i = 0; i < responseData.bangChien.guilds.Length; i++)
                        {
                            var guild = MongoController.GuildDb.Guild.GetDataByUserId(bangChiensOldOrder[0].guilds[i]);
                            if(guild != null)
                            {
                                responseData.bangChien.guilds[i] = new Guild()
                                {
                                    _id = guild._id.ToString(),
                                    name = guild.name,
                                    contribution = guild.contribution,
                                    level = guild.level,
                                };
                            }
                            else
                            {
                                responseData.bangChien.guilds[i] = new Guild()
                                {
                                    _id = "",
                                    name = "[Đã giải tán]",
                                    contribution = 0,
                                    level = 1,
                                };
                            }
                        }

                        var battlesBC = MongoController.GuildDb.BattleBangChien.GetDatas(bangChiensOldOrder[0]._id);
                        foreach (var item in battlesBC)
                        {
                            BattleBangChien battleBC = new BattleBangChien()
                            {
                                _id = item._id.ToString(),
                                guildA = item.guild_a.ToString(),
                                guildB = item.guild_b.ToString(),
                                result = item.result,
                                round = item.round,
                            };
                            responseData.bangChien.battles.Add(battleBC);
                        }

                        return new OperationResponse()
                        {
                            OperationCode = operationRequest.OperationCode,
                            DebugMessage = "",
                            Parameters = responseData.Serialize(),
                            ReturnCode = (short)ReturnCode.OK
                        };
                    }
                }
                else
                {
                    // Không có bang chiến nào trước đó để trả về kết quả
                    GetDataBangChienResponseData responseData = new GetDataBangChienResponseData()
                    {
                        state = 0,
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
            else
            {
                // Trả về bang chiến đang diễn ra
                DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                StaticDatabase.entities.configs.guildConfig.hourStartBangChien.hour,
                StaticDatabase.entities.configs.guildConfig.hourStartBangChien.minute, 0);
                DateTime endTime = startTime +
                new TimeSpan(0,
                    StaticDatabase.entities.configs.guildConfig.minuteDurationBattleBangChien * 3 + StaticDatabase.entities.configs.guildConfig.waitTimeBangChien * 2,
                    0);

                int stateBattle = 0;

                if (DateTime.Now > startTime
                    && DateTime.Now <= startTime + new TimeSpan(0, StaticDatabase.entities.configs.guildConfig.minuteDurationBattleBangChien, 0))
                {
                    stateBattle = 1;
                }
                else if (DateTime.Now > startTime + new TimeSpan(0, StaticDatabase.entities.configs.guildConfig.minuteDurationBattleBangChien + StaticDatabase.entities.configs.guildConfig.waitTimeBangChien, 0)
                    && DateTime.Now <= startTime + new TimeSpan(0, StaticDatabase.entities.configs.guildConfig.minuteDurationBattleBangChien * 2 + StaticDatabase.entities.configs.guildConfig.waitTimeBangChien, 0))
                {
                    stateBattle = 1;
                }
                else if (DateTime.Now > startTime + new TimeSpan(0, StaticDatabase.entities.configs.guildConfig.minuteDurationBattleBangChien * 2 + StaticDatabase.entities.configs.guildConfig.waitTimeBangChien * 2, 0)
                   && DateTime.Now <= endTime)
                {
                    stateBattle = 1;
                }

                GetDataBangChienResponseData responseData = new GetDataBangChienResponseData()
                {
                    state = 2,
                    timeEnd = (endTime - DateTime.Now).TotalSeconds,
                    stateBattle = stateBattle,
                };

                responseData.bangChien = new BangChien()
                {
                    _id = bangChienDuring._id.ToString(),
                    state = bangChienDuring.state,
                    guilds = new Guild[8],
                    battles = new List<BattleBangChien>(),
                };

                for (int i = 0; i < responseData.bangChien.guilds.Length; i++)
                {
                    var guild = MongoController.GuildDb.Guild.GetDataByUserId(bangChienDuring.guilds[i]);
                    responseData.bangChien.guilds[i] = new Guild()
                    {
                        _id = guild._id.ToString(),
                        name = guild.name,
                        contribution = guild.contribution,
                        level = guild.level,
                    };
                }

                var battlesBC = MongoController.GuildDb.BattleBangChien.GetDatas(bangChienDuring._id);
                foreach (var item in battlesBC)
                {
                    BattleBangChien battleBC = new BattleBangChien()
                    {
                        _id = item._id.ToString(),
                        guildA = item.guild_a.ToString(),
                        guildB = item.guild_b.ToString(),
                        result = item.result,
                        round = item.round,
                    };
                    responseData.bangChien.battles.Add(battleBC);
                }

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
