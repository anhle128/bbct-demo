using ProtoBuf;
using StaticDB.Models;

namespace StaticDB
{
    [ProtoContract]
    public class Entity
    {
        [ProtoMember(1)]
        public string version { get; set; }

        [ProtoMember(2)]
        public Character[] characters { get; set; }

        [ProtoMember(3)]
        public Equipment[] equipments { get; set; }

        [ProtoMember(4)]
        public Configs configs { get; set; }

        [ProtoMember(5)]
        public Item[] items { get; set; }

        [ProtoMember(6)]
        public PowerUpItem[] powerUpItems { get; set; }

        [ProtoMember(7)]
        public Map[] maps { get; set; }

        [ProtoMember(8)]
        public StarReward[] starRewards { get; set; }

        [ProtoMember(9)]
        public int baseExpInStage { get; set; }

        [ProtoMember(10)]
        public GroupCharacter[] groupCharacters { get; set; }


        public Entity()
        {

        }

        public int GetExpReceiveInStage(int indexMap, int indexStage)
        {
            int staminaNeed = maps[indexMap].stages[indexStage].stamina;
            return staminaNeed * baseExpInStage;
        }


    }
}
