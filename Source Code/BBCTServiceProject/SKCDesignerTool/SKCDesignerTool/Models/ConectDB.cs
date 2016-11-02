using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBCTDesignerTool.Models
{
    public static class ConnectDB
    {
        private static BBCTdesignertoolv1Entities entities;

        public static BBCTdesignertoolv1Entities Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = new BBCTdesignertoolv1Entities();
                }
                return ConnectDB.entities;
            }
        }
    }
}
