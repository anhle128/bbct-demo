using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model
{
    public class ListReward
    {
        ListServer server = new ListServer();

        public List<TotalReward> LoadTypeReward()
        {
            List<TotalReward> lsType = new List<TotalReward>();
            var tmpTypeReward = from tmp in ConnectDB.Entities.dbCTTypeRewards
                                where tmp.status == 1
                                select tmp;

            foreach (var item in tmpTypeReward)
            {
                TotalReward total = new TotalReward()
                {
                    id = item.id,
                    value = item.value
                };
                lsType.Add(total);
            }
            return lsType;
        }

        public int HandlerLoadStaticID(int type, int staticID)
        {
            int num = 0;
            if (type == 1)
            {
                num = 2000 + staticID;
            }
            else if (type == 2 || type == 3)
            {
                num = staticID;
            }
            else if (type == 4 || type == 5)
            {
                num = 1000 + staticID;
            }
            else if (type == 6)
            {
                num = 3000 + staticID;
            }
            return num;
        }

        public int HandlerSaveStaticID(int type, int staticID)
        {
            int num = 0;
            if (type == 1)
            {
                num = staticID - 2000;
            }
            else if (type == 2 || type == 3)
            {
                num = staticID;
            }
            else if (type == 4 || type == 5)
            {
                num = staticID - 1000;
            }
            else if (type == 6)
            {
                num = staticID - 3000;
            }
            return num;
        }

        public List<TotalReward> LoadTotalReward()
        {
            List<TotalReward> lsTotalReward = new List<TotalReward>();

            TotalReward reward = new TotalReward()
            {
                id = 0,
                value = "Không"
            };
            lsTotalReward.Add(reward);

            var lsCharacter = from chr in ConnectDB.Entities.dbCharacters
                              where chr.status == 1
                              select chr;

            foreach (var item in lsCharacter)
            {
                TotalReward chr = new TotalReward()
                {
                    id = (int)item.idCharacter,
                    value = item.name
                };
                lsTotalReward.Add(chr);
            }

            var lsEquipment = from chr in ConnectDB.Entities.dbEquipments
                              where chr.status == 1
                              select chr;

            foreach (var item in lsEquipment)
            {
                TotalReward chr = new TotalReward()
                {
                    id = 1000 + (int)item.idEquipment,
                    value = item.name
                };
                lsTotalReward.Add(chr);
            }

            var lsItem = from chr in ConnectDB.Entities.dbItems
                         where chr.status == 1
                         select chr;

            foreach (var item in lsItem)
            {
                TotalReward chr = new TotalReward()
                {
                    id = 2000 + (int)item.idItem,
                    value = item.name
                };
                lsTotalReward.Add(chr);
            }

            var lsPower = from chr in ConnectDB.Entities.dbPowerUpItems
                          where chr.status == 1
                          select chr;

            foreach (var item in lsPower)
            {
                TotalReward chr = new TotalReward()
                {
                    id = 3000 + (int)item.idPowerUpItems,
                    value = item.name
                };
                lsTotalReward.Add(chr);
            }

            return lsTotalReward;
        }
    }
}
