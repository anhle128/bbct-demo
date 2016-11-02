
namespace GameServer.Common.Core
{
    public class ProtoBufSerializerHelper
    {
        private static IProtoBufSerializer handler;

        public static void InitHandler(IProtoBufSerializer cHandler)
        {
            handler = cHandler;
        }

        public static IProtoBufSerializer Handler()
        {
            return handler;
        }
    }
}
