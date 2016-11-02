
using GameServer.Database.Controller;

namespace GameServer.GlobalInfo
{
    public class LuanKienInfo
    {
        public static void RestartAndSendGift()
        {
            MongoController.UserDb.Mail.SendGiftLuanKiem();
        }
    }
}
