
using ProtoBuf;
using StaticDB.Enum;

namespace StaticDB.Models
{
    [ProtoContract]
    public class NhiemVuHangNgayConfig
    {
        [ProtoMember(1)]
        public int goldRequireCompolete { get; set; }
        [ProtoMember(2)]
        public NhiemVuHangNgay[] nhiemVus { get; set; }

        public Reward[] GetReward(TypeNhiemVuHangNgay type, int currentLevel)
        {
            NhiemVuHangNgay nhiemVu = null;
            foreach (var data in nhiemVus)
            {
                if (data.type == (int)type)
                {
                    nhiemVu = data;
                    break;
                }
            }
            int proc = currentLevel / 20;
            if (proc == 0)
                proc = 1;
            Reward[] rewards = new Reward[nhiemVu.rewards.Length];
            for (int i = 0; i < nhiemVu.rewards.Length; i++)
            {
                rewards[i] = new Reward()
                {
                    staticID = nhiemVu.rewards[i].staticID,
                    typeReward = nhiemVu.rewards[i].typeReward,
                    amountMax = nhiemVu.rewards[i].amountMax
                };
                if (rewards[i].typeReward == (int)TypeReward.Silver ||
                    rewards[i].typeReward == (int)TypeReward.Ruby ||
                    rewards[i].typeReward == (int)TypeReward.ExpPlayer)
                {
                    rewards[i].amountMax = rewards[i].amountMax * proc;
                }

            }
            return rewards;
        }
    }
}
