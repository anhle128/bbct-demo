using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Models
{
    public static class ConnectDB
    {
        private static kdqhdesignertoolv1Entities entities;
        //
        public static kdqhdesignertoolv1Entities Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = new kdqhdesignertoolv1Entities();
                }
                return ConnectDB.entities;
            }
        }
    }
}
