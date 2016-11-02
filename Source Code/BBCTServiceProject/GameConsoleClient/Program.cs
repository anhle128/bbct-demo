using DynamicDBModel.Models;
using GameConsoleClient.Components;
using GameConsoleClient.Configs;
using GameConsoleClient.Cores;
using GameConsoleClient.Helpers.FEnum;
using GameConsoleClient.Models;
using GameServer;
using GameServer.Common.Core;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server;
using GameServer.Server.Operations.Core;
using GameServer.Server.Operations.Handler;
using GameServer.Server.ProtoBuf;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using StaticDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GameConsoleClient
{
    class Program
    {
        public static int AmountPeer = 0;
        public static int CountPeer = 0;

        private static AccountManager _accountManager = new AccountManager();
        private static List<Account> _listAccountLogin = new List<Account>();
        private static List<Account> _listNewAccountLogin = new List<Account>();

        private static List<BatchPlayer> listBatchPlayer;

        private static readonly TimeSpan TimeOutPhoton = new TimeSpan(0, 2, 0);

        private static string _stop = "s";

        public static string UrlPhoton;
        public static string AppName;

        public static List<Account> ListAccountLogin
        {
            get { return _listAccountLogin; }
            set { _listAccountLogin = value; }
        }

        public static List<Account> ListNewAccountLogin
        {
            get { return _listNewAccountLogin; }
            set { _listNewAccountLogin = value; }
        }

        private static void Main(string[] args)
        {

            ProtoBufSerializerHelper.InitHandler(new ServerProtoBufSerializer());

            LoadStaticDb();

            //RunSimulator();

            Console.ReadLine();
        }

        #region Test code

        private static async void LoadStaticDb()
        {
            //byte[] arrByte = await WebClientController.Instance.DownloadData();
            //StaticDatabase.LoadFromBinary(arrByte);

            MongoController.Connected();

            //MongoController.UserDb.Test.Create(new MTest()
            //{
            //    field = "hello em yeu"
            //});

            List<MTest> listData = MongoController.UserDb.Test.GetDatas();
            Console.WriteLine("size: " + listData.Count);
            //CommonFunc.CreateNewServer("DPBB18", "S18. Đảo Hiệp Khách", "57fdf00754cf020da831d273",new MMongoConnection()
            //{
            //    database = "dpbb_data_cum2",
            //    username = "admin",
            //    password = "lungemine2016",
            //    url = "118.107.69.34",
            //    port = "27017"
            //});

            //CommonFunc.ChangeConfigServer("57e4e67f7c515426d0d5ccfd");

            //MongoController.ConfigDb.SkVongQuayMayMan.CheckActivate();

            //GamePlayer playerPeer = new GamePlayer(null)
            //{
            //    cacheData = new PlayerCacheData()
            //};

            //MUserInfo userinfo = MongoController.UserDb.Info.GetData("lonxao8363");
            //playerPeer.SignInTest(userinfo);

            //MongoController.GetEntity(playerPeer.cacheData, userinfo);

            //SendParameters sendParam = new SendParameters();
            //OperationController controller = new OperationController(null, playerPeer);

            //ExchangeGoldToSilverConfig config = StaticDatabase.entities.configs.exchangeGoldToSilverConfig;

            //ThanThapInfo.Start();

            //SuKienDoiDoInfo.CheckStartSuKienDoiDo();

            //Stage stage = StaticDatabase.entities.maps[0].stages[0];

            //string lungemine_payment = "lungemine_payment";
            //string key = AesEncryptor.Encrypt(lungemine_payment);

            //LuanKienInfo.RestartAndSendGift();
            //SuKienInfo.StartCheckSuKien();

            //ThanThapInfo.SendGiftAndRestart();
            //GlobalBossInfo.Start();
            //GlobalBossInfo.RefeshCurrentTopUsersAndHpBoss("anhle2", "anhle2_s1", 100000, 7635);

            //MongoController.GuildDb.BattleBangChien.ProcessEndBangChien(3);


            //MSKDoiDoConfig config = MongoController.ConfigDb.SkDoiDo.GetDatas();
            //MongoController.LogSubDB.SkDoiDo.GetTopUser(config._id.ToString(), config.top_rewards);

            //CommonFunc.CreateBotLuanKiem(10000);
            //CreateDataChieuMoConfig();
            //CreateDataChucPhucConfig();
            //CreateGlobalBossConfig();
            //CreateShopItems();
            //CreateShopLebaos();
            //CreateLuanKiemShopitems();
            //CreateDataTop10ThanThapConfig();
            //CreateDataSk7NgayNhanThuong();
            //CreateDataSkThanTai();
            //CreateVipRewardConfig();
            //CreateDataSkTichLuyTieu();
            //CreateDataSkTichLuyNap();
            //CreateDataSkDoiDo();
            //CreateDataSkRotDo();
            //CreateDataSkVongQuayMayMan();
            //CreateDataSkTranhMuaServer();
            //CreateDataGiftCode();
            Console.WriteLine("Done Create");

            //BangXepHangInfo.Start();
            //SuKienDoiDoInfo.CheckStartSuKienDoiDo();
            //LuanKienInfo.SendGift();

            //MoneyResetThanThap money = StaticDatabase.entities.configs.thanThapConfig.GetMoneyResestThanThap(3);
            //TutorialConfig config = StaticDatabase.entities.configs.tutorialConfig;

            //MongoController.UserDb.Info.DeleteAll(a => a.nickname.StartsWith("Sửu Nhi") && a.server_id == Settings.server_id);
            //MongoController.UserDb.Info.UpdateAll(new Dictionary<string, object>() { { "server_id", Settings.server_id } }, new Dictionary<string, object>() { { "rank_luan_kiem", 10000 } });

            //MUserInfo userInfo = MongoController.UserDb.Info.GetDatas(playerPeer.cacheData.username);
            //SubDataPlayer data = MongoController.UserDb.GetSubDataPlayer(userInfo);
            //string strData = LitJson.JsonMapper.ToJson(data);

            //GetRewardVongQuayMayMan(playerPeer, sendParam, controller);
            //GetDataChieuMo(playerPeer, sendParam, controller);
            //ViewReplayLuanKiem(playerPeer, sendParam, controller);
            //GetDataLuanKiemShop(playerPeer, sendParam, controller);
            //GetFreeStamina(playerPeer, sendParam, controller);
            //GetFriend(playerPeer, sendParam, controller);
            //SuKienInfo.StartCheckSuKien();
            //PowerUpChar(playerPeer, sendParam, controller);
            //QuayVatPham(playerPeer, sendParam, controller);
            //ChangeSkillCharacter(playerPeer, sendParam, controller);
            //UpSkillCharacter(playerPeer, sendParam, controller);
            //UseGiftCode(playerPeer, sendParam, controller);
            //GetDataSkThanTai(playerPeer, sendParam, controller);
            //ThanThapInfo.Start();
            //GetDataThanThap(playerPeer, sendParam, controller);
            //GetDataCuopTieu(playerPeer, sendParam, controller);
            //GetDataShopItem(playerPeer, sendParam, controller);
            //GetDataVanTieu(playerPeer, sendParam, controller);
            //GetVanTieuVehicle(playerPeer, sendParam, controller);
            //GetRewardVanTieu(playerPeer, sendParam, controller);
            //GetRewardLuanKiemRank(playerPeer, sendParam, controller);
            //GetDataLuanKiem(playerPeer, sendParam, controller);
            //StartVanTieu(playerPeer, sendParam, controller);
            //UpStarEquip(playerPeer, sendParam, controller);
            //QuayTuong(playerPeer, sendParam, controller);
            //GetTopLevelGuild(playerPeer, sendParam, controller);
            //RewardCauCa(playerPeer, sendParam, controller);
            //ThachDau(playerPeer, sendParam, controller);
            //GetDataSkRotDo(playerPeer, sendParam, controller);
            //GetDataTichTieu(playerPeer, sendParam, controller);
            //CanQuet(playerPeer, sendParam, controller);
            //GetRewardStarMap(playerPeer, sendParam, controller);
            //GetRewardCuuCuuTriTon(playerPeer, sendParam, controller);
            //CheckTrans(playerPeer, sendParam, controller);
            //GetRewardNhiemVuChinhTuyen(playerPeer, sendParam, controller);
            //RefeshMail(playerPeer, sendParam, controller);
            //GetRewardMail(playerPeer, sendParam, controller);
            //GetDataSkDoiDo(playerPeer, sendParam, controller);
            //RewardMoRuong(playerPeer, sendParam, controller);
            //SendGMMail(playerPeer, sendParam, controller);
            //GetDataSkTranhMuaServer(playerPeer, sendParam, controller);
            //StaticDatabase.entities.configs.thanThapConfig.GetMoneyResestThanThap(2);
            //List<Item> lsItem = StaticDatabase.entities.exchange_items.Where(a => a.type == (short)TypeItem.KinhNhiemDan).ToList();

            //StartAttackStage(playerPeer, sendParam, controller);
            //EndAttackStage(playerPeer, sendParam, controller);

            //SuKienDoiDoInfo.StartSuKien();
            //GetTopSuKienDoiDo(playerPeer, sendParam, controller);
            //GetGuildMember(playerPeer, sendParam, controller);

            Console.ReadLine();
        }


        private static void CreateDataSk7NgayNhanThuong()
        {
            MSK7NgayNhanThuongConfig sk = new MSK7NgayNhanThuongConfig();
            sk.start = DateTime.Now;
            sk.end = sk.start.AddDays(7);
            sk.status = Status.Activate;
            sk.day_rewards = new DayReward[7];
            DateTime timeStart = sk.start;
            for (int i = 0; i < 7; i++)
            {
                DayReward dayReward = new DayReward();
                dayReward.day = timeStart.AddDays(i).Day;
                dayReward.rewards = new List<SubRewardItem>()
                {
                    new SubRewardItem()
                    {
                        type_reward = (int)TypeReward.Gold,
                        quantity = 10 + 10*i
                    },
                    new SubRewardItem()
                    {
                        type_reward = (int)TypeReward.Item,
                        static_id = 2,
                        quantity = 1 + 1*i
                    },
                    new SubRewardItem()
                    {
                        type_reward = (int)TypeReward.Item,
                        static_id = 3,
                        quantity = 1 + 1*i
                    }
                };
                sk.day_rewards[i] = dayReward;
            }

            MongoController.ConfigDb.Sk7NgayNhanThuong.Create(sk);
        }
        private static void CreateDataSkTichLuyTieu()
        {
            MSKTichLuyTieuConfig config = new MSKTichLuyTieuConfig()
            {
                server_id = Settings.Instance.server_id,
                start = DateTime.Today,
                end = DateTime.Today.AddDays(30),
                status = Status.Activate,
                gold_rewards = new List<MGoldReward>()
               {
                   new MGoldReward()
                   {
                       gold_require = 100,
                       rewards = new List<SubRewardItem>()
                       {
                           new SubRewardItem()
                           {
                               static_id = 3,
                               quantity = 5,
                               type_reward = (int)TypeReward.Item
                           }
                       }
                   },
                   new MGoldReward()
                   {
                       gold_require = 500,
                       rewards = new List<SubRewardItem>()
                       {
                           new SubRewardItem()
                           {
                               static_id = 5,
                               quantity = 5,
                               type_reward = (int)TypeReward.Item
                           }
                       }
                   },
                   new MGoldReward()
                   {
                       gold_require = 1000,
                       rewards = new List<SubRewardItem>()
                       {
                           new SubRewardItem()
                           {
                               static_id = 8,
                               quantity = 5,
                               type_reward = (int)TypeReward.Item
                           },
                           new SubRewardItem()
                           {
                               static_id = 3,
                               quantity = 1,
                               type_reward = (int)TypeReward.Equipment
                           },
                           new SubRewardItem()
                           {
                               static_id = 1,
                               quantity = 1,
                               type_reward = (int)TypeReward.Equipment
                           },
                           new SubRewardItem()
                           {
                               static_id = 4,
                               quantity = 1,
                               type_reward = (int)TypeReward.Equipment
                           }
                       }
                   }
               }
            };
            MongoController.ConfigDb.SkTichluyTieu.Create(config);
        }




        private static void CreateDataTop10ThanThapConfig()
        {
            MThanThapConfig thanThapConfig = new MThanThapConfig();
            thanThapConfig.top_rewards = new List<TopReward>();
            List<TopReward> topRewardConfigs = new List<TopReward>();
            for (int i = 9; i >= 0; i--)
            {
                TopReward config = new TopReward();
                config.index = i;
                config.rewards = new List<SubRewardItem>()
                 {
                     new SubRewardItem()
                     {
                         static_id = 1,
                         quantity = i +1,
                         type_reward = (int)TypeReward.Item
                     },
                     new SubRewardItem()
                     {
                         static_id = 0,
                         quantity = 10*(i+1),
                         type_reward = (int)TypeReward.Gold
                     }
                 };
                topRewardConfigs.Add(config);
            }
            thanThapConfig.top_rewards = topRewardConfigs;
            MongoController.ConfigDb.ThanThap.Create(thanThapConfig);
        }

        private static MGroupChar[] CreateMGroupChar()
        {
            return new MGroupChar[]
            {
                new MGroupChar()
                {
                    proc = 5,
                    chars = new List<Reward[]>()
                    {
                        new Reward[]
                        {
                            new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 30},
                            new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 31},
                            new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 32}
                        },
                        null,
                        null,
                        null,
                        null,
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 33}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 34}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 35}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 36}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 37}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 38}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 39}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 40}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 41}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 41}}
                    }
                },
                new MGroupChar()
                {
                    proc = 10,
                    chars = new List<Reward[]>()
                    {
                        new Reward[]
                        {
                            new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 29},
                            new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 28},
                            new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 27}
                        },
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 26}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 25}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 24}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 23}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 22}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 21}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 20}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 19}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 18}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 17}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 16}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 15}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 14}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 13}},

                    }
                },
                new MGroupChar()
                {
                    proc = 85,
                    chars = new List<Reward[]>()
                    {
                        new Reward[]
                        {
                            new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 12},
                            new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 11},
                            new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 10}
                        },
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 9}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 8}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 7}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 6}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 5}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 4}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 3}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 2}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 1}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 2}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 3}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 4}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 5}},
                        new Reward[]{new Reward(){proc = 10,typeReward = (int)TypeReward.Character,staticID = 6}},

                    }
                }
            };
        }
        private static void GetDataLuanKiemShop(GamePlayer player, SendParameters sendParam,
           OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = new Dictionary<byte, object>()
            };

            GetDataLuanKiemShopOperationHandler operationHandler = new GetDataLuanKiemShopOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
            AttackStageResponseData responseData = new AttackStageResponseData();
            responseData.Deserialize(response.Parameters);
        }
        private static void UpStarEquip(GamePlayer player, SendParameters sendParam,
           OperationController controller)
        {
            UpStarEquipRequestData requestData = new UpStarEquipRequestData()
            {
                equip_id = "5788ac37d0642407c8795fa9",
                equip_stocks = new List<string>() { "5788ac37d0642407c8795faa", "5788ac37d0642407c8795fab" }
            };
            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = requestData.Serialize()
            };

            UpStarEquipOperationHandler operationHandler = new UpStarEquipOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetTopLevelGuild(GamePlayer player, SendParameters sendParam,
          OperationController controller)
        {
            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetTopLevelGuildOperationHandler operationHandler = new GetTopLevelGuildOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void EndAttackStage(GamePlayer player, SendParameters sendParam,
            OperationController controller)
        {
            EndAttackStageRequestData requestData = new EndAttackStageRequestData()
            {
                star = 3
            };

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = requestData.Serialize()
            };

            EndAttackStageOperationHandler operationHandler = new EndAttackStageOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
            AttackStageResponseData responseData = new AttackStageResponseData();
            responseData.Deserialize(response.Parameters);
        }

        private static void StartAttackStage(GamePlayer player, SendParameters sendParam,
           OperationController controller)
        {
            ActionStageRequestData requestData = new ActionStageRequestData()
            {
                stage_info = new StageMode()
                {
                    level = 1,
                    map_index = 1,
                    stage_index = 1
                }
            };

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = requestData.Serialize()
            };

            StartAttackStageOperationHandler operationHandler = new StartAttackStageOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
            //AttackStageResponseData responseData = new AttackStageResponseData();
            //responseData.Deserialize(response.Parameters);
        }

        private static void CanQuet(GamePlayer player, SendParameters sendParam,
            OperationController controller)
        {
            CanQuetRequestData requestData = new CanQuetRequestData()
            {
                level = 1,
                stage_index = 6,
                map_index = 0
            };

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = requestData.Serialize()
            };

            CanQuetOperationHandler operationHandler = new CanQuetOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
            //AttackStageResponseData responseData = new AttackStageResponseData();
            //responseData.Deserialize(response.Parameters);
        }

        private static void GetRewardStarMap(GamePlayer player, SendParameters sendParam,
            OperationController controller)
        {
            GetRewardStarMapRequestData requestData = new GetRewardStarMapRequestData()
            {
                level = 1,
                index_reward = 1,
                index_map = 0
            };

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = requestData.Serialize()
            };

            GetRewardStarMapOperationHandler operationHandler = new GetRewardStarMapOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
            //AttackStageResponseData responseData = new AttackStageResponseData();
            //responseData.Deserialize(response.Parameters);
        }

        private static void GetRewardVongQuayMayMan(GamePlayer player, SendParameters sendParam,
            OperationController controller)
        {
            GetRewardVongQuayMayManRequestData requestData = new GetRewardVongQuayMayManRequestData()
            {
                times = 10
            };

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = requestData.Serialize()
            };

            GetRewardVongQuayMayManOperationHandler operationHandler = new GetRewardVongQuayMayManOperationHandler();
            operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void ViewReplayLuanKiem(GamePlayer player, SendParameters sendParam,
            OperationController controller)
        {
            ReplayRequestData requestData = new ReplayRequestData()
            {
                id = "570e51f3f390c51458a1b2d3"
            };

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = requestData.Serialize()
            };

            ViewReplayLuanKiemOperationHandler operationHandler = new ViewReplayLuanKiemOperationHandler();
            operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void QuayVatPham(GamePlayer player, SendParameters sendParam,
            OperationController controller)
        {
            QuayVatPhamRequestData requestData = new QuayVatPhamRequestData()
            {
                times = 1
            };

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = requestData.Serialize()
            };

            QuayVatPhamOperationHandler operationHandler = new QuayVatPhamOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetFreeStamina(GamePlayer player, SendParameters sendParam,
            OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetFreeStamineOperationHandler operationHandler = new GetFreeStamineOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetFriend(GamePlayer player, SendParameters sendParam,
           OperationController controller)
        {
            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetFriendOperationHandler operationHandler = new GetFriendOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void QuayTuong(GamePlayer player, SendParameters sendParam,
           OperationController controller)
        {
            QuayTuongRequestData requestData = new QuayTuongRequestData()
            {
                times = 10,
                type = QuayTuongType.Special
            };

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = requestData.Serialize()
            };

            QuayTuongOperationHandler operationHandler = new QuayTuongOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
            RewardResponseData reward = new RewardResponseData();
            reward.Deserialize(response.Parameters);
        }

        private static void EndCauCa(GamePlayer player, SendParameters sendParam,
          OperationController controller)
        {


            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            EndCauCaOperationHandler operationHandler = new EndCauCaOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetDataSkDoiDo(GamePlayer player, SendParameters sendParam,
          OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetDataDoiDoOperationHandler operationHandler = new GetDataDoiDoOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetDataShopItem(GamePlayer player, SendParameters sendParam,
         OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetDataShopOperationHandler operationHandler = new GetDataShopOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }


        private static void MoRuong(GamePlayer player, SendParameters sendParam,
          OperationController controller)
        {
            UsedItemRequestData requestData = new UsedItemRequestData()
            {
                item_id = "5745504d550dc20954995778",
                quantity = 1
            };
            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = requestData.Serialize()
            };

            MoRuongOperationHandler operationHandler = new MoRuongOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetTopSuKienDoiDo(GamePlayer player, SendParameters sendParam,
         OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetTopDoiDoOperationHandler operationHandler = new GetTopDoiDoOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetGuildMember(GamePlayer player, SendParameters sendParam,
        OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetGuildMemberOperationHandler operationHandler = new GetGuildMemberOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetDataSkTranhMuaServer(GamePlayer player, SendParameters sendParam,
          OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetDataTranhMuaServerOperationHandler operationHandler = new GetDataTranhMuaServerOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void SendGMMail(GamePlayer player, SendParameters sendParam,
         OperationController controller)
        {
            //SendGMMailRequestData requestData = new SendGMMailRequestData()
            //{
            //    mail = new SystemMail()
            //    {
            //        time = DateTime.Now,
            //        content = "hihihihihi",
            //        title = "Chào anh GM đẹp trai"
            //    }
            //};
            //OperationRequest operationRequest = new OperationRequest()
            //{
            //    Parameters = requestData.Serialize()
            //};

            //SendGMMailOperationHandler operationHandler = new SendGMMailOperationHandler();
            //OperationResponse response = operationHandler.Handler(Player, operationRequest, sendParam, controller);
        }

        private static void GetDataSkRotDo(GamePlayer player, SendParameters sendParam,
         OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetDataRotDoOperationHandler operationHandler = new GetDataRotDoOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetRewardNhiemVuChinhTuyen(GamePlayer player, SendParameters sendParam,
         OperationController controller)
        {
            GetRewardNhiemVuChinhTuyenRequestData requestData = new GetRewardNhiemVuChinhTuyenRequestData()
            {
                id = 3
            };

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = requestData.Serialize()
            };

            GetRewardNhiemVuChinhTuyenOperationHandler operationHandler = new GetRewardNhiemVuChinhTuyenOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void CheckTrans(GamePlayer player, SendParameters sendParam,
         OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            CheckTransactionOperationHandler operationHandler = new CheckTransactionOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetRewardCuuCuuTriTon(GamePlayer player, SendParameters sendParam,
        OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetRewardCuuCuuTriTonOperationHandler operationHandler = new GetRewardCuuCuuTriTonOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        //private static void GetDataTichLuyNap(GamePlayer Player, SendParameters sendParam,
        //OperationController controller)
        //{

        //    OperationRequest operationRequest = new OperationRequest()
        //    {
        //        Parameters = null
        //    };

        //    GetDataTichLuyNapOperationHandler operationHandler = new GetDataTichLuyNapOperationHandler();
        //    OperationResponse response = operationHandler.Handler(Player, operationRequest, sendParam, controller);
        //}

        private static void GetDataTichTieu(GamePlayer player, SendParameters sendParam,
        OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetDataTichLuyTieuOperationHandler operationHandler = new GetDataTichLuyTieuOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void RefeshMail(GamePlayer player, SendParameters sendParam,
        OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            RefeshMailOperationHandler operationHandler = new RefeshMailOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetRewardMail(GamePlayer player, SendParameters sendParam,
        OperationController controller)
        {
            GetRewardMailRequestData requestData = new GetRewardMailRequestData()
            {
                mail_id = "575fc811550d960bc80f0f5a"
            };

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = requestData.Serialize()
            };

            GetRewardMailOperationHandler operationHandler = new GetRewardMailOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }


        private static void GetDataLuanKiem(GamePlayer player, SendParameters sendParam,
           OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetDataLuanKiemOperationHandler operationHandler = new GetDataLuanKiemOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);

            DataLuanKiemResponse dataResponse = new DataLuanKiemResponse();
            dataResponse.Deserialize(response.Parameters);


        }


        private static void UseGiftCode(GamePlayer player, SendParameters sendParam,
           OperationController controller)
        {
            UseGiftCodeRequestData requestData = new UseGiftCodeRequestData()
            {
                gift_code = "AA0000000"
            };

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = requestData.Serialize()
            };

            UseGiftCodeOperationHandler operationHandler = new UseGiftCodeOperationHandler();
            operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetDataVanTieu(GamePlayer player, SendParameters sendParam,
          OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetDataVanTieuOperationHandler operationHandler = new GetDataVanTieuOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetDataThanThap(GamePlayer player, SendParameters sendParam,
          OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetDataThanThapOperationHandler operationHandler = new GetDataThanThapOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetDataSkThanTai(GamePlayer player, SendParameters sendParam,
          OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetDataThanTaiOperationHandler operationHandler = new GetDataThanTaiOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetDataCuopTieu(GamePlayer player, SendParameters sendParam,
         OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetDataCuopTieuOperationHandler operationHandler = new GetDataCuopTieuOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetVanTieuVehicle(GamePlayer player, SendParameters sendParam,
          OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetVehicleVanTieuOperationHandler operationHandler = new GetVehicleVanTieuOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }



        private static void GetRewardVanTieu(GamePlayer player, SendParameters sendParam,
         OperationController controller)
        {
            GetRewardVanTieuRequestData requestData = new GetRewardVanTieuRequestData()
            {
                type = GetRewardVanTieuType.Normal
            };

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = requestData.Serialize()
            };

            GetRewardVanTieuOperationHandler operationHandler = new GetRewardVanTieuOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetRewardLuanKiemRank(GamePlayer player, SendParameters sendParam,
         OperationController controller)
        {
            RewardRankLuanKiemRequestData requestData = new RewardRankLuanKiemRequestData()
            {
                index = 3
            };

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = requestData.Serialize()
            };

            GetRewardLuanKiemRankOperationHandler operationHandler = new GetRewardLuanKiemRankOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        //private static void GetRewardNhiemVuChinhTuyen(GamePlayer Player, SendParameters sendParam,
        //OperationController controller)
        //{
        //    RewardRankLuanKiemRequestData requestData = new RewardRankLuanKiemRequestData()
        //    {
        //        index = 3
        //    };

        //    OperationRequest operationRequest = new OperationRequest()
        //    {
        //        Parameters = requestData.Serialize()
        //    };

        //    GetRewardNhiemVuChinhTuyenOperationHandler operationHandler = new GetRewardNhiemVuChinhTuyenOperationHandler();
        //    OperationResponse response = operationHandler.Handler(Player, operationRequest, sendParam, controller);
        //}

        private static void StartVanTieu(GamePlayer player, SendParameters sendParam,
          OperationController controller)
        {

            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            StartVanTieuOperationHandler operationHandler = new StartVanTieuOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        private static void GetDataChieuMo(GamePlayer player, SendParameters sendParam,
           OperationController controller)
        {


            OperationRequest operationRequest = new OperationRequest()
            {
                Parameters = null
            };

            GetDataChieuMoOperationHandler operationHandler = new GetDataChieuMoOperationHandler();
            OperationResponse response = operationHandler.Handler(player, operationRequest, sendParam, controller);
        }

        #endregion

        private static void RunSimulator()
        {

            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;

            LoadAccountManagerAndListAccountLogin();

            //Console.WriteLine("Nhap url photon server_id");
            //UrlPhoton = Console.ReadLine();
            //UrlPhoton = "45.124.93.59";
            UrlPhoton = "118.107.70.99";
            //UrlPhoton = "192.168.1.105";
            //UrlPhoton = "103.48.80.46";

            //Console.WriteLine("Nhap app name photon");
            //AppName = Console.ReadLine();
            AppName = "KDQH1";

            Console.WriteLine("Nhap sso luong bot");
            int numberPlayerInput = int.Parse(s: Console.ReadLine());

            //accountManager.NumberAccountLogin = numberPlayerInput;
            //accountManager.LastTimeLogin = DateTime.Now;

            PrintMainMenu();
            int actionCategoryInput = int.Parse(s: Console.ReadLine());
            if (actionCategoryInput != (int)CommonEnum.Action.EndProgram)
            {

                StartProgram(numberPlayerInput, actionCategoryInput);
                SaveDataAccounts();
                Console.WriteLine("Press \"s\" to stop");

                string input = Console.ReadLine().ToLower();
                if (input == _stop)
                {
                    foreach (var batchPlayer in listBatchPlayer)
                    {
                        batchPlayer.RestartPlayer();
                    }
                    ApplicationStop();
                }
            }
            else
            {
                Environment.Exit(0);
            }

        }

        private static void ApplicationStop()
        {
            PrintMainMenu();
            int actionCategoryInput = int.Parse(Console.ReadLine());
            if (actionCategoryInput != (int)CommonEnum.Action.EndProgram)
            {
                foreach (var batchPlayer in listBatchPlayer)
                {
                    batchPlayer.StartActionPlayer(actionCategoryInput);
                }
                SaveDataAccounts();
                Console.WriteLine("Press \"s\" to stop");
                var readLine = Console.ReadLine();
                if (readLine != null)
                {
                    string input = readLine.ToLower();
                    if (input == _stop)
                    {
                        foreach (var batchPlayer in listBatchPlayer)
                        {
                            batchPlayer.RestartPlayer();
                        }
                        ApplicationStop();
                    }
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private static void StartProgram(int numberPlayerInput, int actionCategory)
        {

            AmountPeer = numberPlayerInput;

            int amountThread = CalcutaleAmountThread(numberPlayerInput);
            Console.WriteLine("Total Thread : " + (amountThread + 1));
            Console.WriteLine("Total playerPeer : " + AmountPeer);

            Tracker tracker = new Tracker();

            List<Thread> listThread = new List<Thread>();
            listBatchPlayer = new List<BatchPlayer>();

            for (int i = 0; i < amountThread; i++)
            {
                int amountTmp = 0;
                if (CountPeer + 10 <= AmountPeer)
                {
                    amountTmp = Config.AMOUNT_PEER_THREAD;
                }
                else
                {
                    amountTmp = AmountPeer - CountPeer;
                }

                Thread thread = new Thread(ProcessComponent);
                listThread.Add(thread);
                List<Account> listAccountUsedInBatch = _listAccountLogin.Skip(i * Config.AMOUNT_PEER_THREAD).Take(Config.AMOUNT_PEER_THREAD).ToList();
                BatchPlayer batch = new BatchPlayer(tracker, amountTmp, listAccountUsedInBatch, actionCategory);
                listBatchPlayer.Add(batch);
            }

            _accountManager.ListAccount.AddRange(_listNewAccountLogin);


            for (int i = 0; i < amountThread; i++)
            {
                listThread[i].Start(listBatchPlayer[i]);
            }

            Thread trTracker = new Thread(ProcessComponent);
            trTracker.Start(tracker);
        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            SaveDataAccounts();
        }

        private static void SaveDataAccounts()
        {
            Console.WriteLine("save account");
            _accountManager.LastTimeLogin = DateTime.Now;
            GameConsoleClient.Helpers.Common.Common.SaveAccountManager(_accountManager);
        }

        private static void PrintMainMenu()
        {
            WriteLineMenu((int)CommonEnum.Action.EndProgram, "Exit");
            WriteLineMenu((int)CommonEnum.Action.Random, "Random hanh dong");
            WriteLineMenu((int)CommonEnum.Action.Move, "Move around");
            WriteLineMenu((int)CommonEnum.Action.AttackMap, "Attack Map ");
            //WriteLineMenu((int)CommonEnum.Category.ChangeAvatar, "Change avatar");
            //WriteLineMenu((int)Category.AttackBoss, "Attack boss");
            //WriteLineMenu((int)Category.AttackLuanKiem, "Attack luan kiem");
            //WriteLineMenu((int)Category.UpLevelEquip, "Up equipment's level");
            //WriteLineMenu((int)Category.UpEvolutionEquip, "Up equipment's evolution");
            //WriteLineMenu((int)Category.ReceiveGiftLevel, "Receive gift level");
            //WriteLineMenu((int)Category.ReceiveGiftLogin, "Receive gift login");
            //WriteLineMenu((int)Category.JoinEquipmentPiece, "Join equipment piece");
            //WriteLineMenu((int)Category.JoinCharacterSoul, "Join character soul");
            //WriteLineMenu((int)Category.UpgradeSkill, "Upgrade skill");
            //WriteLineMenu((int)Category.EquipEquipment, "Equip or Unequip equipment");
        }

        private static void WriteLineMenu(int number, string menuLine)
        {
            Console.WriteLine(string.Format("Nhap {0}: {1}", number, menuLine));
        }

        private static void LoadAccountManagerAndListAccountLogin()
        {
            _accountManager = GameConsoleClient.Helpers.Common.Common.GetAccountManager();
            if (_accountManager.ListAccount == null)
            {
                _accountManager.ListAccount = new List<Account>();
            }
            DateTime timeNow = DateTime.Now;
            TimeSpan timeSpan = timeNow - _accountManager.LastTimeLogin;
            if (timeSpan > TimeOutPhoton)
            {
                _listAccountLogin = _accountManager.ListAccount;
            }
            else
            {
                _listAccountLogin = _accountManager.ListAccount
                    .Skip(_accountManager.NumberAccountLogin)
                    .Take(_accountManager.ListAccount.Count())
                    .ToList();
            }

        }

        private static int CalcutaleAmountThread(int numberPlayerInput)
        {
            //double number =
            //numberPlayerInput / Config.AMOUNT_PEER_THREAD;
            //double amountThread = Math.Round(number);
            int amountThread = numberPlayerInput / Config.AMOUNT_PEER_THREAD;
            if (numberPlayerInput > amountThread * Config.AMOUNT_PEER_THREAD)
            {
                amountThread++;
            }
            return Int32.Parse(amountThread.ToString());
        }

        private static void ProcessComponent(object c)
        {
            IGameComponent com = (IGameComponent)c;

            com.Start();

            DateTime tmpTime = DateTime.Now;
            float targetTime = 1000f / Config.TARGET_FPS;
            while (true)
            {
                if ((DateTime.Now - tmpTime).TotalMilliseconds >= targetTime)
                {
                    com.Update();
                    tmpTime = DateTime.Now;
                }
            }
        }

        public static void AddNewAccount(Account account)
        {
            _listNewAccountLogin.Add(account);
        }

    }
}
