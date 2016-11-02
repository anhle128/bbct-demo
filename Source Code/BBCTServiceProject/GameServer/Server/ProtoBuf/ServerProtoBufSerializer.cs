using GameServer.Common.Core;
using ProtoBuf;
using System.IO;

namespace GameServer.Server.ProtoBuf
{
    public class ServerProtoBufSerializer : IProtoBufSerializer
    {
        public T Deserialize<T>(byte[] arrayData)
        {
            T result;
            using (MemoryStream memoryStream = new MemoryStream(arrayData))
            {
                T t = (T)Serializer.Deserialize<T>(memoryStream);
                result = t;
            }
            return result;
        }

        public byte[] Serialize<T>(T t)
        {
            MemoryStream memoryStream = new MemoryStream();
            Serializer.Serialize<T>(memoryStream, t);
            return memoryStream.ToArray();
        }
    }
}
