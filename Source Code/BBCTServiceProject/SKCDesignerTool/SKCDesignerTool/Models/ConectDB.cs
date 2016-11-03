using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBCTDesignerTool.Models
{
    public static class ConnectDB
    {
        private static bbctdesignertoolv1Entities entities;

        public static bbctdesignertoolv1Entities Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = new bbctdesignertoolv1Entities();
                }
                return ConnectDB.entities;
            }
        }
    }
}
