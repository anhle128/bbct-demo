using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using GameServer.Common;
using GameServer.Common.Core;
using GameServer.GlobalInfo;
using GameServer.MMO.Concepts;
using GameServer.Server.ProtoBuf;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.ServerWebClient;
using log4net.Config;
using Photon.SocketServer;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using GameServer.Quartz;

namespace GameServer.Server
{
    /// <summary>
    ///   Đây là class Application chính của server_id . 
    ///   Mỗi khi server_id bắt đầu chạy sẽ khởi động MMOApplication đầu tiền .
    /// </summary>
    public class MMOApplication : ApplicationBase
    {

        public static bool IsDoneLoadData { get; set; }
        public static string CurrentApplicationRootPath { get; set; }
        public static string CurrentBinaryPath { get; set; }

        //public static string ApplicationRootPath { get; set; }
        //public static string BinaryPath { get; set; }

        public MMOApplication()
        {

        }

        /// <summary>
        /// Được gọi mỗi khi có client kết nối đến server_id
        /// </summary>
        /// <param name="initRequest"></param>
        /// <returns></returns>
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            // Mỗi khi client kết nối đến server_id sẽ khởi tạo một MMOPeer phụ trách xử lý cho client đó
            return new MMOPeer(initRequest.Protocol, initRequest.PhotonPeer);
        }

        /// <summary>
        /// Được gọi mỗi khi MMOApplication được khởi tạo
        /// Dùng để thiết lập các cấu hình ban đầu
        /// </summary>
        protected override void Setup()
        {
            // Thiết lập hệ thống LogDb
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "log");
            CurrentApplicationRootPath = this.ApplicationRootPath;
            var configFileInfo = new FileInfo(Path.Combine(this.BinaryPath, "log4net.config"));
            CurrentBinaryPath = this.BinaryPath;
            if (configFileInfo.Exists)
            {
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
                XmlConfigurator.ConfigureAndWatch(configFileInfo);
            }
            CommonLog.Instance.PrintLog("MMOApplication Setup ...............................");

            MongoController.Connected();

            // Đăng ký sự kiên xử lý mỗi khi server_id bị Exception những không được handler
            AppDomain.CurrentDomain.UnhandledException += AppDomain_OnUnhandledException;

            //  Tạo một world mới
            World world;
            if (WorldCache.Instance.TryCreate(Settings.Instance.WorldName, 15, 1, 300f, new Vector2D(-1700f, -320f), out world))
            {
                CommonLog.Instance.PrintLog(string.Format("Create World {0} Success", world.name));
            }
            else
            {
                CommonLog.Instance.PrintLog("Cannot Create World");
            }

            // init Serializer
            ProtoBufSerializerHelper.InitHandler(new ServerProtoBufSerializer());

            //// Init database

            CommonFunc.LoadStaticDBAndStartTimeCounter();
        }

        //private async void LoadStaticDBAndStartTimeCounter()
        //{
        //    IsDoneLoadData = false;
        //    byte[] arrByte = await WebClientController.Instance.DownloadData();
        //    StaticDatabase.LoadFromBinary(arrByte);
        //    //TimerController.Instance.Start();
        //    QuartzManager.Instance.StartSchedule();
        //    SuKienInfo.StartCheckSuKien();
        //    IsDoneLoadData = true;
        //}

        /// <summary>
        /// Được gọi mỗi khi server_id bị Exception những không được handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void AppDomain_OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            CommonLog.Instance.PrintLog(e.ExceptionObject.ToString());
        }

        /// <summary>
        /// Được gọi mỗi khi server_id bị dừng hoạt động
        /// </summary>
        protected override void TearDown()
        {
            CommonLog.Instance.PrintLog("Server TearDown");
            MongoController.LogDb.ActionGold.SaveLogs();
            //MongoController.LogDb.ChieuMo.SaveLogs();
            //MongoController.LogDb.Request.SaveLogs();
        }
    }
}
