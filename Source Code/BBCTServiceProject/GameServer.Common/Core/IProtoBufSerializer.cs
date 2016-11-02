using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Common.Core
{
    public interface IProtoBufSerializer
    {
        T Deserialize<T>(byte[] arrayData);
        byte[] Serialize<T>(T t);
    }
}
