
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server;
using MongoDBModel.Enum;
using MongoDBModel.MainDatabaseModels;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.NapThe
{
    public class NapTheHandler
    {
        public static void CheckSuKienPhucLoiThang(GamePlayer player, double totalRubyTrans)
        {
            MUserPhucLoiThang lastPhucLoiThang =
                MongoController.UserDb.PhucLoiThang.GetData(player.cacheData.id);
            if (lastPhucLoiThang == null)
            {
                ProcessPhucLoiThang(player.cacheData, totalRubyTrans);
            }
            else
            {
                if (lastPhucLoiThang.day_end < DateTime.Now)
                {
                    double totalRubyTransInTime = MongoController.LogDb.Trans.GetTotalRuby
                        (
                            player.cacheData.id,
                            lastPhucLoiThang.day_end,
                            DateTime.Now
                        );
                    ProcessPhucLoiThang(player.cacheData, totalRubyTransInTime);
                }
            }
        }

        public static void CheckSuKienCuuCuuTriTon(GamePlayer player, double totalRubyTrans, double totalDayCreateAccount)
        {

            if (totalDayCreateAccount <=
                StaticDatabase.entities.configs.cuuCuuTriTonConfig.duration)
            {
                if (totalRubyTrans < StaticDatabase.entities.configs.cuuCuuTriTonConfig.ruby_require)
                    return;

                if (MongoController.UserDb.CuuCuuTriTon.CheckExist(player.cacheData.id))
                    return;

                MUserCuuCuuTriTon cuuCuuTriTon = new MUserCuuCuuTriTon()
                {
                    user_id = player.cacheData.id
                };

                MongoController.UserDb.CuuCuuTriTon.Create(cuuCuuTriTon);
            }
        }

        public static void CheckSuKienPhucLoiTruongThanh(GamePlayer player, double totalRubyTrans, double totalDayCreateAccount)
        {

            if (totalDayCreateAccount <=
                StaticDatabase.entities.configs.phucLoiTruongThanhConfig.duration)
            {
                if (totalRubyTrans < StaticDatabase.entities.configs.phucLoiTruongThanhConfig.ruby_require)
                    return;
                if (MongoController.LogSubDB.SkPhucLoiTruongThanh.CheckActivate(player.cacheData.id))
                    return;
                MPhucLoiTruongThanhLog log = new MPhucLoiTruongThanhLog()
                {
                    user_id = player.cacheData.id,
                    status = Status.Activate
                };
                MongoController.LogSubDB.SkPhucLoiTruongThanh.Create(log);
            }
        }

        private static void ProcessPhucLoiThang(PlayerCacheData cacheData, double totalRubyTrans)
        {
            if (totalRubyTrans >= StaticDatabase.entities.configs.phucLoiThangConfig.rubyRequire)
            {
                MUserPhucLoiThang newPhucLoiThang = new MUserPhucLoiThang()
                {
                    user_id = cacheData.id,
                    day_start = DateTime.Now,
                    day_end = DateTime.Now.AddDays(StaticDatabase.entities.configs.phucLoiThangConfig.ngay)
                };
                MongoController.UserDb.PhucLoiThang.Create(newPhucLoiThang);
                MongoController.UserDb.Mail.SendGiftPhucLoiThang(cacheData.id, StaticDatabase.entities.configs.phucLoiThangConfig.rewards);
            }
        }

        public static OperationResponse CheckTrans(GamePlayer player, OperationRequest operationRequest, List<MTransaction> listNewTrans, MSKx2NapConfig x2Config)
        {
            bool haveBonusMail = false;

            double totalRuby = listNewTrans.Sum(a => a.ruby);

            if (player.cacheData.total_ruby_trans == 0) // nap lần đầu tiên
            {
                haveBonusMail = true;

                MTransaction firstTrans = listNewTrans.FirstOrDefault();
                List<MTransaction> listOtherTrans = listNewTrans.Skip(1).ToList();
                MThuongNapLanDauConfig thuongNapConfig = MongoController.ConfigDb.ThuongNapLanDau.GetData();
                if (x2Config != null)
                {
                    MongoController.UserDb.Mail.SendMailThuongNapLanDau_x2Ruby(player.cacheData.id, new List<MTransaction>() { firstTrans },
                        thuongNapConfig.rewards, true);
                    if (listOtherTrans.Count != 0)
                        MongoController.UserDb.Mail.SendMail2xRuby(listOtherTrans);
                }
                else
                {
                    MongoController.UserDb.Mail.SendMailThuongNapLanDau_x2Ruby(player.cacheData.id, new List<MTransaction>() { firstTrans },
                        thuongNapConfig.rewards, false);
                }
            }
            else
            {
                if (x2Config != null)
                {
                    haveBonusMail = true;
                    MongoController.UserDb.Mail.SendMail2xRuby(listNewTrans);
                }
            }

            //string[] trans_ids = listNewTrans.Select(a => a._id.ToString()).ToArray();

            player.cacheData.total_ruby_trans += totalRuby;
            player.cacheData.ruby += Convert.ToInt32(totalRuby);

            UpVip(player, player.cacheData.total_ruby_trans);



            MongoController.UserDb.Info.UpdateRuby(player.cacheData);
            MongoController.UserDb.Info.UpdateTotalRubyTrans(player.cacheData);
            MongoController.LogDb.Trans.UpdateDoneTrans(listNewTrans);

            double totalDayCreateAccount = (DateTime.Now - player.cacheData.create_at).TotalDays;
            // su kien phuc loi thang
            CheckSuKienPhucLoiThang(player, player.cacheData.total_ruby_trans);
            // su kien phuc loi truong thanh
            CheckSuKienPhucLoiTruongThanh(player, player.cacheData.total_ruby_trans, totalDayCreateAccount);
            // su kien cuu cuu tri ton
            CheckSuKienCuuCuuTriTon(player, player.cacheData.total_ruby_trans, totalDayCreateAccount);

            CheckTransResponseData responseData = new CheckTransResponseData()
            {
                haveBonusMail = haveBonusMail,
                ruby = player.cacheData.ruby,
                total_ruby_trans = player.cacheData.total_ruby_trans,
                vip = player.cacheData.vip
            };

            // response
            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "CheckTransactionOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }

        public static void UpVip(GamePlayer player, double totalRubyTrans)
        {
            if (player.cacheData.vip >= StaticDatabase.entities.configs.vipConfigs.Length)
                return;
            if (player.cacheData.vip == StaticDatabase.entities.configs.vipConfigs.Length - 1)
                return;

            double totalRubyCurrentVip = StaticDatabase.entities.configs.GetTotalRubyVip(player.cacheData.vip);
            double rubyPlusVip = totalRubyTrans - totalRubyCurrentVip;
            bool isUpVip = UpVipPlayer(player.cacheData, rubyPlusVip, false);

            if (isUpVip)
                MongoController.UserDb.Info.UpdateVip(player.cacheData);
        }

        private static bool UpVipPlayer(PlayerCacheData cacheData, double ruby, bool isUpVip)
        {
            bool upVip = isUpVip;
            if (cacheData.vip == StaticDatabase.entities.configs.vipConfigs.Length - 1)
                return upVip;
            int rubyRequireUpVip = StaticDatabase.entities.configs.vipConfigs[cacheData.vip].rubyRequire;
            if (ruby >= rubyRequireUpVip)
            {
                ruby -= rubyRequireUpVip;
                cacheData.vip++;
                upVip = UpVipPlayer(cacheData, ruby, true);
                return upVip;
            }
            else
            {
                return upVip;
            }
        }
    }
}
