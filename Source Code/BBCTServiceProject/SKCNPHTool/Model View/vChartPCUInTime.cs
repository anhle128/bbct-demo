﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model_View
{
    [ProtoContract]
    public class vChartPCUInTime
    {
        [ProtoMember(1)]
        public string date { get; set; }
        [ProtoMember(2)]
        public int value { get; set; }
        [ProtoMember(3)]
        public int aven  { get; set; }
        public vChartPCUInTime()
        {

        }
    }
}
