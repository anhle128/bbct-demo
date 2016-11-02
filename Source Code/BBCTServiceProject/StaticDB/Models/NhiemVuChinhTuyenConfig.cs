using ProtoBuf;
using StaticDB.Enum;
using System.Collections.Generic;

namespace StaticDB.Models
{
    [ProtoContract]
    public class NhiemVuChinhTuyenConfig
    {
        [ProtoMember(1)]
        public NhiemVuChinhTuyen[] nhiemVus { get; set; }


        /// <summary>
        /// Lấy số lượng cần để hoàn thành nhiệm vụ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentLevel"></param>
        /// <returns></returns>
        public int GetNumberRequire(int id, int currentLevel)
        {
            NhiemVuChinhTuyen nhiemVu = nhiemVus[id - 1];
            if (nhiemVu.type != (int)TypeNhiemVuChinhTuyen.UpLevelEquip)
            {
                return nhiemVu.number + currentLevel * nhiemVu.stepUpNumber;
            }
            else
            {
                return nhiemVu.numberRequire;
            }
        }


        public int GetLevelEquipRequire(int currentLevel)
        {
            foreach (var nhiemVu in nhiemVus)
            {
                if (nhiemVu.type != (int)TypeNhiemVuChinhTuyen.UpLevelEquip)
                    continue;
                return nhiemVu.number + currentLevel * nhiemVu.stepUpNumber;
            }
            return 0;
        }


        /// <summary>
        /// Get reward của nhiệm vụ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentLevel"></param>
        /// <returns></returns>
        public Reward[] GetRewards(int id, int currentLevel)
        {
            NhiemVuChinhTuyen nhiemVu = nhiemVus[id - 1];
            Reward[] rewards = new Reward[nhiemVu.rewards.Length];
            int count = 0;
            foreach (var dataReward in nhiemVu.rewards)
            {
                Reward reward = new Reward();
                reward.staticID = dataReward.staticID;
                reward.typeReward = dataReward.typeReward;
                reward.amountMax = dataReward.quantity + currentLevel * dataReward.stepUpQuantity;
                reward.amountMin = reward.amountMax;
                rewards[count] = reward;
                count++;
            }
            return rewards;
        }

        public List<NhiemVuChinhTuyen> GetNhiemVuByType(TypeNhiemVuChinhTuyen type)
        {
            List<NhiemVuChinhTuyen> listData = new List<NhiemVuChinhTuyen>();
            foreach (var nhiemVu in nhiemVus)
            {
                if (nhiemVu.type == (int)type)
                    listData.Add(nhiemVu);
            }
            return listData;
        }
    }
}
