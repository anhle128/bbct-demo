using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Common.SerializeData.RequestData
{
    public class UpdateQuantityRequestData
    {
        public int quantity;
        public void Deserialize(Dictionary<byte, object> data)
        {
            quantity = (int)data[0];
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, quantity}
            };
            return data;
        }
    }
}
