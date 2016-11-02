using GameServer.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Common.SerializeData.RequestData
{
    public class DoXucXacDoPhuongRequestData : ISerializeData
    {
        public int goldBet;
        public bool isChan;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, goldBet);
            data.Add(2, isChan);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            goldBet = int.Parse(data[1].ToString());
            isChan = bool.Parse(data[2].ToString());
        }
    }
}
