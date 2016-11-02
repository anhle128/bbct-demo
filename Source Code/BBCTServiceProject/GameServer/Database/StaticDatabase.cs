
using GameServer.Common;
using ProtoBuf;
using StaticDB;
using System.IO;
using StaticDB.Models;

namespace GameServer.Database
{
    public class StaticDatabase
    {
        public static Entity entities;

        public static void LoadFromBinary(byte[] arrByte)
        {
            using (MemoryStream stream = new MemoryStream(arrByte))
            {
                entities = Serializer.Deserialize<Entity>(stream);
                CommonLog.Instance.PrintLog("-------------- Load StaticDB done! --------------");
            }
        }
    }

}
