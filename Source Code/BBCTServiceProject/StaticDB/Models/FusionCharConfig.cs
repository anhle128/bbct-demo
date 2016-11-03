using ProtoBuf;
using System.Collections.Generic;

namespace StaticDB.Models
{
    [ProtoContract]
    public class FusionCharConfig
    {
        [ProtoMember(1)]
        public int timesToGetSpecialReward { get; set; }
        [ProtoMember(2)]
        public Reward[] normalRewards { get; set; }
        [ProtoMember(3)]
        public Reward[] specialRewards { get; set; }

        private Dictionary<int, List<Reward>> dictStarNormalReward = new Dictionary<int, List<Reward>>();
        private Dictionary<int, List<Reward>> dictStarSpecialReward = new Dictionary<int, List<Reward>>();

        public void ProcessReward(Character[] chars, int maxStar)
        {
            AddCharToDictStarReward(chars, normalRewards, dictStarNormalReward, maxStar);
            AddCharToDictStarReward(chars, specialRewards, dictStarSpecialReward, maxStar);
        }

        private void AddCharToDictStarReward(Character[] chars, Reward[] rewards, Dictionary<int, List<Reward>> dictStarReward, int maxStar)
        {
            for (int star = 2; star <= maxStar; star++)
            {
                dictStarNormalReward.Add(star, new List<Reward>());
                foreach (var reward in rewards)
                {
                    Character character = GetCharInReward(chars, reward, star);

                    if (character == null)
                        continue;

                    dictStarNormalReward[star].Add(reward);
                }
            }
        }

        private Character GetCharInReward(Character[] chars, Reward reward, int star)
        {
            foreach (var character in chars)
            {
                if (character.id != reward.staticID)
                    continue;

                if (character.lowestStarLevel >= star && character.highestStarLevel <= star)
                    return character;
            }
            return null;
        }

        public List<Reward> GetNormalRewards(int star)
        {
            return dictStarNormalReward[star];
        }

        public List<Reward> GetSpecialReward(int star)
        {
            return dictStarSpecialReward[star];
        }

    }
}
