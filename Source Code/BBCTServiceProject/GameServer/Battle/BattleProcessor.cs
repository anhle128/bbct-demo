using BattleSimulator;
using DynamicDBModel.Models;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server;
using MongoDBModel.SubDatabaseModels;
using StaticDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Battle
{
    public class BattleProcessor
    {
        private int user_level;
        public BattleProcessor()
        {

        }

        public BattleSimulator.Battle BattleThanThap(PlayerCacheData cacheData, int indexMonster, int floor, int difficult)
        {
            BattleSimulator.Battle battleSim = new BattleSimulator.Battle(StaticDatabase.entities,
                    GetDataInputThanThap(cacheData, indexMonster, floor, difficult),
                    true, true, new BattleLogger(), true, cacheData.info.level, user_level);
            battleSim.StartBattle();
            return battleSim;
        }

        public BattleSimulator.Battle BattleGhk(PlayerCacheData cacheData, Stage stage, int level)
        {
            BattleSimulator.Battle battleSim = new BattleSimulator.Battle(StaticDatabase.entities,
                    GetDataInputGHK(cacheData, stage, level),
                    true, true, new BattleLogger(), true, cacheData.info.level, user_level);
            battleSim.StartBattle();
            return battleSim;
        }

        public BattleSimulator.Battle BattleGlobalBoss(PlayerCacheData cacheData, int level)
        {
            BattleSimulator.Battle battleSim = new BattleSimulator.Battle(StaticDatabase.entities,
                   GetDataInputGlobalBoss(cacheData, level),
                   true, true, new BattleLogger(), true, cacheData.info.level, user_level);
            battleSim.StartBattle();
            return battleSim;
        }

        public BattleSimulator.Battle BattlePvp(PlayerCacheData cacheData, string userIdB)
        {
            BattleSimulator.Battle battleSim = new BattleSimulator.Battle(StaticDatabase.entities,
                    GetDataInput(cacheData, userIdB),
                    true, true, new BattleLogger(), true, cacheData.info.level, user_level);
            battleSim.StartBattle();
            return battleSim;
        }

        #region Helper

        public DataInputBattle GetDataInput(PlayerCacheData cacheData, string userIdB)
        {
            DataInputBattle inputBattle = new DataInputBattle();
            inputBattle.idBackground = StaticDatabase.entities.configs.battleConfig.idBackgroundBangChien;
            inputBattle.mode = DataInputBattle.Mode.Normal;
            inputBattle.teamA = GetTeamParameterWithCacheData(cacheData);
            inputBattle.teamB = GetTeamParameterWithUserId(userIdB);
            return inputBattle;
        }

        public DataInputBattle GetDataInputGHK(PlayerCacheData cacheData, Stage stage, int level)
        {
            DataInputBattle inputBattle = new DataInputBattle();
            inputBattle.idBackground = stage.background;
            inputBattle.teamA = GetTeamParameterWithCacheData(cacheData);
            if (level == 1)
            {
                inputBattle.teamB = GetMonster(stage.monsters);
            }
            else
            {
                inputBattle.teamB = GetMonster(stage.monstersSupper);
            }
            return inputBattle;
        }

        public DataInputBattle GetDataInputGlobalBoss(PlayerCacheData cacheData, int level)
        {
            DataInputBattle inputBattle = new DataInputBattle();
            inputBattle.mode = DataInputBattle.Mode.Boss;
            inputBattle.idBackground = StaticDatabase.entities.configs.battleConfig.idBackgroundBoss;
            inputBattle.teamA = GetTeamParameterWithCacheData(cacheData);
            inputBattle.teamB = GetBossWorld(level);

            return inputBattle;
        }

        private TeamParameter GetBossWorld(int level)
        {
            TeamParameter team = new TeamParameter();
            team.mainChars = new List<CharacterParameter>();
            team.level = 100;
            this.user_level = team.level;

            Character info = StaticDatabase.entities.characters.Single(a => a.id == StaticDatabase.entities.configs.battleConfig.idBossWorld);

            CharacterParameter cpBoss = new CharacterParameter()
            {
                idInDatabase = "NULL",
                idInStatic = StaticDatabase.entities.configs.battleConfig.idBossWorld,
                level = level,
                levelNormalSkill = 1,
                levelPassiveSkill1 = 1,
                levelPowerUp = 0,
                levelUltimateSkill = 1,
                rowFormation = 2,
                star = 15,
                colFormation = 2,
                indexSkillUltimate = 0,
                indexSkillPassive1 = 0,
                indexSkillPassive2 = 0,
                typeElement = info.element,
            };
            team.mainChars.Add(cpBoss);
            team.subChars = new List<CharacterParameter>();
            return team;
        }

        public DataInputBattle GetDataInputThanThap(PlayerCacheData cacheData, int indexMonster, int floor, int difficult)
        {
            DataInputBattle inputBattle = new DataInputBattle();
            inputBattle.idBackground = StaticDatabase.entities.configs.battleConfig.idBackgroundThanThap;
            inputBattle.teamA = GetTeamParameterWithCacheData(cacheData);
            inputBattle.teamB = GetMonsterThanThap
            (
                StaticDatabase.entities.configs.thanThapConfig.monsters[indexMonster].monsters.ToArray(),
                floor,
                difficult
            );
            return inputBattle;
        }

        public TeamParameter GetMonster(MonsterStage[] monsters)
        {
            TeamParameter team = new TeamParameter();
            team.mainChars = new List<CharacterParameter>();
            team.level = 100;
            this.user_level = team.level;

            foreach (var mon in monsters)
            {
                Character info = StaticDatabase.entities.characters.FirstOrDefault(a => a.id == mon.id);

                CharacterParameter cpA = new CharacterParameter()
                {
                    idInDatabase = "NULL",
                    idInStatic = mon.id,
                    level = mon.level,
                    levelNormalSkill = 1,
                    levelPassiveSkill1 = 1,
                    levelPowerUp = mon.levelPower,
                    levelUltimateSkill = 1,
                    rowFormation = mon.row,
                    star = mon.star,
                    colFormation = mon.col,
                    indexSkillUltimate = 0,
                    indexSkillPassive1 = 0,
                    indexSkillPassive2 = 0,
                    typeElement = info.element,
                };
                team.mainChars.Add(cpA);
            }

            team.subChars = new List<CharacterParameter>();

            return team;
        }

        public TeamParameter GetMonsterThanThap(MonsterStage[] monsters, int floor, int difficult)
        {
            TeamParameter team = new TeamParameter();
            team.mainChars = new List<CharacterParameter>();
            team.level = 100;
            this.user_level = team.level;

            foreach (var mon in monsters)
            {
                Character info = StaticDatabase.entities.characters.Single(a => a.id == mon.id);
                int power = (int)(floor / StaticDatabase.entities.configs.thanThapConfig.modPower);
                int star = (int)(floor / StaticDatabase.entities.configs.thanThapConfig.modStar);

                CharacterParameter cpA = new CharacterParameter()
                {
                    idInDatabase = "NULL",
                    idInStatic = mon.id,
                    level = (int)(floor * StaticDatabase.entities.configs.thanThapConfig.modLevel + (difficult * StaticDatabase.entities.configs.thanThapConfig.modDifficult)),
                    levelNormalSkill = 1,
                    levelPassiveSkill1 = 1,
                    //levelPowerUp = (power > info.powerupReceipt.Length) ? info.powerupReceipt.Length : power,
                    levelUltimateSkill = 1,
                    rowFormation = mon.row,
                    //star = (star > StaticDatabase.entities.configs.characterConfig.maxStarCanUp) ? StaticDatabase.entities.configs.characterConfig.maxStarCanUp : star,
                    colFormation = mon.col,
                    indexSkillUltimate = 0,
                    indexSkillPassive1 = 0,
                    indexSkillPassive2 = 0,
                    typeElement = info.element,
                };
                team.mainChars.Add(cpA);
            }

            team.subChars = new List<CharacterParameter>();

            return team;
        }

        public TeamParameter GetTeamParameterWithUserId(string userId)
        {
            MUserInfo userInfo = MongoController.UserDb.Info.GetData(userId);
            var characters = MongoController.UserDb.Char.GetDatas(userId);
            var equipments = MongoController.UserDb.Equip.GetDatas(userId);
            DataFormation dataFormation = userInfo.formations[userInfo.last_formation_used];
            var formation = dataFormation.main;
            var doiHinhDuBi = dataFormation.sub;

            user_level = userInfo.level;
            var team = GetTeamParameter(characters, equipments, formation, doiHinhDuBi, userInfo.level);
            return team;
        }

        public TeamParameter GetTeamParameterWithCacheData(PlayerCacheData cacheData)
        {
            var characters = cacheData.listUserChar;
            var equipments = cacheData.listUserEquip;
            DataFormation dataFormation = cacheData.info.formations[cacheData.info.last_formation_used];
            var formation = dataFormation.main;
            var doiHinhDuBi = dataFormation.sub;

            var team = GetTeamParameter(characters, equipments, formation, doiHinhDuBi, cacheData.info.level);
            return team;
        }

        private static TeamParameter GetTeamParameter(List<MUserCharacter> characters, List<MUserEquip> equipments, StringArray[] formation,
            List<string> doiHinhDuBi, int level)
        {
            TeamParameter team = new TeamParameter();
            team.mainChars = new List<CharacterParameter>();
            team.subChars = new List<CharacterParameter>();
            team.level = level;

            if (doiHinhDuBi == null)
                doiHinhDuBi = new List<string>();

            // get mainChars from formation
            int[] arrIdChar = new int[characters.Count];

            for (int i = 0; i < arrIdChar.Length; i++)
            {
                arrIdChar[i] = characters[i].static_id;
            }

            for (int row = 0; row < formation.Length; row++)
            {
                for (int column = 0; column < formation[row].columns.Length; column++)
                {
                    if (formation[row].columns[column] != "-1")
                    {
                        string id = formation[row].columns[column];
                        var userCharacter = characters.FirstOrDefault(x => x._id.Equals(id));

                        if (userCharacter == null)
                            continue;

                        var chP = CreateCharacterParameter
                            (
                                userCharacter,
                                column,
                                row,
                                arrIdChar,
                                equipments,
                                true
                            );

                        team.mainChars.Add(chP);
                    }
                }
            }

            // get subChars from doi_hinh_du_bi
            for (int i = 0; i < doiHinhDuBi.Count; i++)
            {
                if (doiHinhDuBi[i] != "-1")
                {
                    string id = doiHinhDuBi[i];
                    var userCharacter = characters.FirstOrDefault(x => x._id.Equals(id));

                    if (userCharacter == null)
                        continue;

                    var chP = CreateCharacterParameter
                        (
                            userCharacter,
                            0,
                            0,
                            arrIdChar,
                            equipments,
                            false
                        );

                    team.subChars.Add(chP);
                }
            }
            return team;
        }

        private static CharacterParameter CreateCharacterParameter(MUserCharacter userCharacter, int column, int r, int[] formation,
            List<MUserEquip> equipments, bool isMain)
        {
            var info = StaticDatabase.entities.characters.FirstOrDefault(x => x.id == userCharacter.static_id);

            //int[] powerUpItems = new int[userCharacter.powerup_items.Length];

            //for (int a = 0; a < powerUpItems.Length; a++)
            //{
            //    if (userCharacter.powerup_items[a] == DynamicDBModel.Enum.EquipPowerupItemStatus.None)
            //    {
            //        powerUpItems[a] = -1;
            //    }
            //    else
            //    {
            //        //powerUpItems[a] = info.powerupReceipt[userCharacter.powerup_level].items[a].idItem;
            //    }
            //}

            CharacterParameter chP = new CharacterParameter()
            {
                bonusThanThap = null,
                colFormation = column + 1,
                rowFormation = r + 1,
                equipments = new List<EquipmentParameter>(),
                formation = formation,
                idInDatabase = userCharacter._id.ToString(),
                idInStatic = userCharacter.static_id,
                level = userCharacter.level,
                levelNormalSkill = 1,
                //levelPassiveSkill1 =
                //    userCharacter.level_skills[(int)TypeSkill.Passive].levels[
                //        userCharacter.index_used_skills[(int)TypeSkill.Passive]],
                //levelUltimateSkill =
                //    userCharacter.level_skills[(int)TypeSkill.Active].levels[
                //        userCharacter.index_used_skills[(int)TypeSkill.Active]],
                //levelUltimateSkill2 =
                //    userCharacter.level_skills[(int)TypeSkill.Ultimate].levels[
                //        userCharacter.index_used_skills[(int)TypeSkill.Ultimate2]],
                levelPowerUp = userCharacter.powerup_level,
                star = userCharacter.star_level,
                //indexSkillUltimate = userCharacter.index_used_skills[(int)TypeSkill.Active],
                //indexSkillPassive1 = userCharacter.index_used_skills[(int)TypeSkill.Passive],
                isMainTeam = isMain,
                typeElement = info.element,
            };


            foreach (var item in userCharacter.equipments)
            {
                if (item != "-1")
                {
                    var eq = equipments.FirstOrDefault(x => x._id.Equals(item));
                    if (eq == null)
                        continue;
                    EquipmentParameter eqP = new EquipmentParameter()
                    {
                        idStatic = eq.static_id,
                        //levelPowerUp = eq.level,
                        star = eq.star_level,
                    };
                    chP.equipments.Add(eqP);
                }
            }
            return chP;
        }
        #endregion
    }
}
