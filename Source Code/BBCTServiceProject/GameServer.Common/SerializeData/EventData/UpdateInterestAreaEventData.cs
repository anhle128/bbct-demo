using GameServer.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Common.SerializeData.EventData
{
    public class UpdateInterestAreaEventData : ISerializeData
    {
        public int[] interestCol;
        public int[] interestRow;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, interestCol);
            data.Add(2, interestRow);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            interestCol = (int[])data[1];
            interestRow = (int[])data[2];
        }
    }
}
