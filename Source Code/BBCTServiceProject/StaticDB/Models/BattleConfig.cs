using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class BattleConfig
    {
        [ProtoMember(1)]
        public int maxTurn { get; set; }

        [ProtoMember(2)]
        public Point2Array[] posInBattle { get; set; }

        [ProtoMember(3)]
        public Point2 centerBattle { get; set; }

        [ProtoMember(4)]
        public float distanceFrontTarget { get; set; }

        [ProtoMember(5)]
        public int manaPool { get; set; }

        [ProtoMember(6)]
        public int manaRegenNormal { get; set; }

        [ProtoMember(7)]
        public int manaRegenUltimate { get; set; }

        [ProtoMember(8)]
        public int manaRegenAttacked { get; set; }

        [ProtoMember(9)]
        public int idBackgroundThanThap { get; set; }

        [ProtoMember(10)]
        public int idBackgroundBoss { get; set; }

        [ProtoMember(11)]
        public int idBossWorld { get; set; }

        [ProtoMember(12)]
        public int idBackgroundCuopTieu { get; set; }

        [ProtoMember(13)]
        public int idBackgroundLuanKiem { get; set; }

        [ProtoMember(14)]
        public int idBackgroundBangChien { get; set; }

        [ProtoMember(15)]
        public int idBackgroundThachDau { get; set; }

        [ProtoMember(16)]
        public int levelSpeed { get; set; }

        [ProtoMember(17)]
        public int vipAuto { get; set; }

        [ProtoMember(18)]
        public int levelAuto { get; set; }

        [ProtoMember(19)]
        public int rangeRandomDamage { get; set; }

        [ProtoMember(20)]
        public int vipSkip { get; set; }
        [ProtoMember(21)]
        public float modZ { get; set; }
        [ProtoMember(22)]
        public float modX { get; set; }
        [ProtoMember(23)]
        public float modY { get; set; }
        [ProtoMember(24)]
        public float modF { get; set; }
        [ProtoMember(25)]
        public float modU { get; set; }
        [ProtoMember(26)]
        public float modKH { get; set; }

    }
}
