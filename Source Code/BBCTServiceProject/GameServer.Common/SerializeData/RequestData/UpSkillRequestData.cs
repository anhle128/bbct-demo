using GameServer.Common.Core;
using StaticDB.Enum;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class UpSkillRequestData : ISerializeData
    {
        public string char_id;
        public TypeSkill type_skill;
        public int index_skill;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(3)
            {
                {0, char_id},
                {1, type_skill},
                {2, index_skill}
            };
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            char_id = data[0].ToString();
            type_skill = (TypeSkill)data[1];
            index_skill = (int)data[2];
        }
    }
}
