
using GameServer.Common.Enum;
using GameServer.Server;
using Photon.SocketServer;
using System.Collections.Generic;

namespace GameServer.NotifyMessage
{
    public class NotifyMessageController
    {
        private static NotifyMessageController _instance;

        public static NotifyMessageController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NotifyMessageController();
                return _instance;
            }
        }

        public void SendTop1GlobalBoss(string nickname)
        {
            string message = string.Format("Chúc mừng {0} đã đứng đầu đợt tấn công boss lần này, thật lợi hại!", nickname);
            Dictionary<byte, object> subParam = new Dictionary<byte, object>();
            subParam.Add(1, message);
            SendMessage(subParam);
        }

        public void SendKillGlobalBoss(string nickname)
        {
            string message = string.Format("Chúc mừng {0} đã chớp đúng thời cơ, ra tay hạ BOSS, phần thưởng hậu hĩnh.", nickname);
            Dictionary<byte, object> subParam = new Dictionary<byte, object>();
            subParam.Add(1, message);
            SendMessage(subParam);
        }

        public void SendTop1WarGild(string gildname)
        {
            string message = string.Format("Chúc mừng bang hội {0} đã đứng đầu Bang chiến lần này, mọi người hãy mau chúc mừng.", gildname);
            Dictionary<byte, object> subParam = new Dictionary<byte, object>();
            subParam.Add(1, message);
            SendMessage(subParam);
        }

        private void SendMessage(Dictionary<byte, object> subParam)
        {
            GameController.Instance.FireEvent
            (
                null,
                new SendParameters(),
                (byte)EventCode.NotifyMessage,
                new Dictionary<byte, object>(),
                subParam
            );
        }
    }
}
