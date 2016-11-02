using Photon.SocketServer;
using Photon.SocketServer.Rpc;
using PhotonHostRuntimeInterfaces;

namespace GameServer.Server
{
    public class ServerPeer : Peer
    {
        public ServerPeer(IRpcProtocol rpcProtocol, IPhotonPeer photonPeer)
            : base(rpcProtocol, photonPeer)
        {
        }
    }
}
