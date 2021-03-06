﻿using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class PointVongQuayMayManReward
    {
        [ProtoMember(1)]
        public int point_require { get; set; }
        [ProtoMember(2)]
        public List<SubRewardItem> rewards { get; set; }
    }
}
