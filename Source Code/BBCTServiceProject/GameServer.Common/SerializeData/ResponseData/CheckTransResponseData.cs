
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class CheckTransResponseData : ISerializeData
    {
        public int vip;
        public int ruby;
        public double total_ruby_trans;
        public bool haveBonusMail;

        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(4)
            {
                {1, vip},                
                {2, ruby},
                {3, total_ruby_trans},
                {4, haveBonusMail}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            vip = (int)data[1];
            ruby = (int)data[2];
            total_ruby_trans = (double)data[3];
            haveBonusMail = (bool)data[4];
        }
    }
}
