using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class HoatDongDiemDanhConfig
    {
        [ProtoMember(1)]
        public int goldRequireBuyMissingReward { get; set; }

        [ProtoMember(2)]
        public List<MonthReward> monthRewards { get; set; }

        public int GetCurrentIndex()
        {
            return (int)(DateTime.Now - new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).TotalDays;
        }
    }
}
