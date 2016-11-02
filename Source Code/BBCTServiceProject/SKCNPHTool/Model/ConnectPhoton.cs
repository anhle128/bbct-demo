using ExitGames.Client.Photon;
using KDQHGameServer.Common.Enum;
using KDQHGameServer.Common.SerializeData.ResponseData;
using KDQHNPHTool.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model
{
    public class ConnectPhoton
    {
        public PlayerPeer PlayerPeer;
        public PhotonPeer Peer;
        bool isConnected = false;
        public int countUsserOnline;

        public void Connectd(string ipServer, string port, string appName)
        {
            PlayerPeer = new PlayerPeer();
            Peer = new PhotonPeer(PlayerPeer, ConnectionProtocol.Udp);
            isConnected = Peer.Connect(ipServer + ":" + port, appName);
            if (isConnected)
            {
                int count = 0;
                countUsserOnline = 0;
                do
                {
                    Peer.Service();
                    System.Threading.Thread.Sleep(500);
                    Peer.OpCustom((byte)OperationCode.CountOnlineUser, null, true);
                    PlayerPeer.OperationResponse += ResponEvent;
                    if (count <= 5)
                    {
                        count++;
                    }
                    else
                    {
                        if (countUsserOnline <= count)
                        {
                            countUsserOnline = 0;
                            isConnected = false;
                            Peer.Disconnect();
                        }
                        //else
                        //{
                        //    countUsserOnline = 0;
                        //    isConnected = false;
                        //    Peer.Disconnect();
                        //}
                    }
                }
                while (isConnected);
            }
            else
            {
                CommonShowDialog.ShowErrorDialog("Không kết nối được server!");
            }
        }

        private void ResponEvent(OperationResponse operationResponse)
        {
            if (operationResponse.ReturnCode == (short)ReturnCode.OK)
            {
                CountOnlineUserResponseData responseData = new CountOnlineUserResponseData();
                responseData.Deserialize(operationResponse.Parameters);
                countUsserOnline = responseData.number;
                isConnected = false;
                Peer.Disconnect();
            }
        }
    }
}
