using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using GameServer.Common;
using log4net.Config;
using Photon.SocketServer;
using Photon.SocketServer.ServerToServer;
using SKCSimulatorServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace GameServer.Server
{
    public class SimulatorApplication : ApplicationBase
    {
        private ServerPeerBase outboundPeer;
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            throw new NotImplementedException();
        }

        protected override void Setup()
        {
            // Thiết lập hệ thống LogDb
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "log");
            var configFileInfo = new FileInfo(Path.Combine(this.BinaryPath, "log4net.config"));
            if (configFileInfo.Exists)
            {
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
                XmlConfigurator.ConfigureAndWatch(configFileInfo);
            }

            CommonLog.Instance.PrintLog("SimulatorApplication Setup ...............................");

            bool checkConnected = this.ConnectToServerUdp(new IPEndPoint(IPAddress.Parse("103.48.80.46"), 5055), "SKC2", null, 0, null);

            CommonLog.Instance.PrintLog("check connect to UDP server: " + checkConnected);
        }

        protected override ServerPeerBase CreateServerPeer(InitResponse initResponse, object state)
        {
            CommonLog.Instance.PrintLog("CreateServerPeer ...............................");
            this.outboundPeer = new MyOutboundPeer(initResponse.Protocol, initResponse.PhotonPeer);
            return this.outboundPeer;
        }

        protected override void OnServerConnectionFailed(int errorCode, string errorMessage, object state)
        {
            CommonLog.Instance.PrintLog("OnServerConnectionFailed ...............................");
        }

        public void SendMessageToMaster(string message)
        {
            var parameters = new Dictionary<byte, object>();
            parameters[0] = message;

            this.outboundPeer.SendOperationRequest(new OperationRequest { OperationCode = 100, Parameters = parameters }, new SendParameters());
        }

        protected override void TearDown()
        {

        }
    }
}
