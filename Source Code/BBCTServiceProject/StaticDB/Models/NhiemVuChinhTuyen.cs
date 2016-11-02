
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class NhiemVuChinhTuyen
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public int type { get; set; }

        [ProtoMember(3)]
        public string name { get; set; }
        [ProtoMember(4)]
        public string desc { get; set; }
        [ProtoMember(5)]
        public int number { get; set; }
        [ProtoMember(6)]
        public int stepUpNumber { get; set; }
        /// <summary>
        /// biến yêu cầu, tùy vào mỗi nhiệm vụ
        /// GetChar - promotion yêu cầu
        /// GetEquip - promotion yêu cầu
        /// UpLevelEquip - số lượng equipment cần để lên level nhiệm vụ tiếp theo
        /// </summary>
        [ProtoMember(7)]
        public int numberRequire { get; set; }
        [ProtoMember(8)]
        public NhiemVuChinhTuyenReward[] rewards { get; set; }
    }
}
