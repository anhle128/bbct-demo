using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.EventData
{
    public class ItemSubscribedEventData : ISerializeData
    {
        public string username;
        public string nickname;
        public byte itemType;
        public float posX;
        public float posY;
        public int avatar;
        public int level;
        public int vip;
        public int title;
        public int star;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, username);
            data.Add(2, itemType);
            data.Add(3, posX);
            data.Add(4, posY);
            data.Add(5, avatar);
            data.Add(6, level);
            data.Add(7, nickname);
            data.Add(8, vip);
            data.Add(9, title);
            data.Add(10, star);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            username = data[1].ToString();
            itemType = (byte)data[2];
            posX = float.Parse(data[3].ToString());
            posY = float.Parse(data[4].ToString());
            avatar = int.Parse(data[5].ToString());
            level = int.Parse(data[6].ToString());
            nickname = data[7].ToString();
            vip = int.Parse(data[8].ToString());
            title = int.Parse(data[9].ToString());
            star = int.Parse(data[10].ToString());
        }
    }
}
