using GameServer.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class DoXucXacDoPhuongResponseData : ISerializeData
    {
        public int xucXac1;
        public int xucXac2;
        public int xucXac3;
        public bool isWin;
        public int goldReward; 

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, xucXac1);
            data.Add(2, xucXac2);
            data.Add(3, xucXac3);
            data.Add(4, isWin);
            data.Add(5, goldReward);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            xucXac1 = int.Parse(data[1].ToString());
            xucXac2 = int.Parse(data[2].ToString());
            xucXac3 = int.Parse(data[3].ToString());
            isWin = bool.Parse(data[4].ToString());
            goldReward = int.Parse(data[5].ToString());
        }
    }
}
