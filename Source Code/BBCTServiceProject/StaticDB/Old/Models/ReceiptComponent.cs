using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class ReceiptComponent
    {
         [ProtoMember(1)]
         public int equipmentId { get; set; }
         [ProtoMember(2)]
         public int amount { get; set; }
         public ReceiptComponent()
         {

         }
    }
}
