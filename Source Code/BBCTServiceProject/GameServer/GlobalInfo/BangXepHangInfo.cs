using BattleSimulator;
using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Database;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using StaticDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.GlobalInfo
{
    public class BangXepHangInfo
    {
        private static List<TopUser> _listTopLevel;
        private static List<TopUser> _listTopLucChien;

        public static void Start()
        {
            CalculateTop();
        }

        private static void CalculateTop()
        {
            _listTopLevel = MongoController.UserDb.Info.GetTopUsers(10).Select(a => new TopUser()
            {
                userid = a.username,
                level = a.level,
                nickname = a.nickname,
                vip = a.vip,
                avatar = a.avatar,
                power = 0
            }).ToList();

            List<TopUser> listCurrentTopLucChienUser = new List<TopUser>();
            List<MUserInfo> listTop50User = MongoController.UserDb.Info.GetTopUsers(40);
            foreach (var topUser in listTop50User)
            {
                double totalPower = Math.Round(CalculateTotalPowerUser(topUser));

                if (listCurrentTopLucChienUser.Any(a => a.power < totalPower) || listCurrentTopLucChienUser.Count < 10)
                {
                    TopUser user = new TopUser()
                    {
                        userid = topUser.username,
                        level = topUser.level,
                        nickname = topUser.nickname,
                        vip = topUser.vip,
                        avatar = topUser.avatar,
                        power = totalPower

                    };
                    listCurrentTopLucChienUser.Add(user);
                }
            }
            _listTopLucChien = listCurrentTopLucChienUser.OrderByDescending(a => a.power).Skip(0).Take(10).ToList();
        }

        public static List<TopUser>[] GetTopUsers(bool isNow)
        {
            return new List<TopUser>[]
            {
                _listTopLevel,
                _listTopLucChien
            };
        }

        private static double CalculateTotalPowerUser(MUserInfo topUser)
        {
            List<MUserCharacter> listAllUserCharacter = MongoController.UserDb.Char.GetDatas(topUser._id);
            List<MUserEquip> listAllEquipment = MongoController.UserDb.Equip.GetEquipUsed(topUser._id);
            int[] arrIdAllChar = listAllUserCharacter.Select(a => a.static_id).ToArray();
            double totalPower = 0;
            for (int i = 0; i < topUser.formation.Length; i++)
            {
                for (int j = 0; j < topUser.formation[i].columns.Length; j++)
                {
                    if (topUser.formation[i].columns[j] == "-1")
                        continue;
                    MUserCharacter userChar =
                        listAllUserCharacter.FirstOrDefault(
                            a => a._id == topUser.formation[i].columns[j]);
                    if (userChar == null)
                        continue;
                    List<MUserEquip> listEquip = listAllEquipment.Where(a => a.char_equip == userChar._id.ToString()).ToList();
                    totalPower += CalculatePowerChar(userChar, listEquip, arrIdAllChar);
                }
            }
            return totalPower;
        }

        private static double CalculatePowerChar(MUserCharacter userCharacter, List<MUserEquip> listUserEquip, int[] formation)
        {
            List<EquipmentCalculator> equipmentsCalculators = new List<EquipmentCalculator>();
            foreach (var userEquip in listUserEquip)
            {
                EquipmentCalculator equipCal = new EquipmentCalculator()
                {
                    star = userEquip.star_level,
                    idStatic = userEquip.static_id,
                    levelPowerUp = userEquip.powerup_level,
                };
                equipmentsCalculators.Add(equipCal);
            }

            Character character = StaticDatabase.entities.characters.Single(a => a.id == userCharacter.static_id);
            //for (int i = 0; i < powerupItem.Length; i++)
            //{
            //    //if (userCharacter.powerup_items[i] == EquipPowerupItemStatus.Equiped)
            //    //    powerupItem[i] = character.GetPowerUpReceipt(userCharacter.powerup_level).items[i].idItem;
            //    //else
            //    //    powerupItem[i] = -1;
            //}
            CharacterCalculator characterCalculator = new CharacterCalculator()
            {
                levelPowerUp = userCharacter.powerup_level,
                star = userCharacter.star_level,
                formation = formation,
                level = userCharacter.level,
                equipments = equipmentsCalculators,
                idInStatic = userCharacter.static_id,
                staticDB = StaticDatabase.entities
            };
            characterCalculator.Calculate();

            return characterCalculator.GetPower();
        }
    }
}
