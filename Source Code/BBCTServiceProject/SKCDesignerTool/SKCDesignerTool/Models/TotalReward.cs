﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace BBCTDesignerTool.Models
{
    [ProtoContract]
    public class TotalReward
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public string value { get; set; }

        public TotalReward()
        {

        }
    }
}
