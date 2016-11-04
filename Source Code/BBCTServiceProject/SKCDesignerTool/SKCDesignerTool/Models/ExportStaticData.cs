using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
using LitJson;
using StaticDB;
using StaticDB.Models;
using BattleSimulator;
using System.Diagnostics;
using System.Windows.Forms;
using StaticDB.Enum;

namespace BBCTDesignerTool.Models
{
    public class ExportStaticData
    {
        bbctdesignertoolv1Entities cs = new bbctdesignertoolv1Entities();
        Database css = new Database();

        public Entity HandlerExportFile()
        {
            var tmpConfig = cs.dbConfigs.FirstOrDefault();

            Entity entities = new Entity();
            entities.characters = GetCharacters();
            entities.powerUpItems = GetPowerUpItem();
            entities.items = GetItem();
            entities.equipments = GetEquipment();
            entities.configs = GetConfig();
            entities.starRewards = GetStarReward();
            HandlerTotalPowerStage(entities);
            entities.maps = GetMap();
            entities.baseExpInStage = (int)tmpConfig.baseExpInStage;
            return entities;
        }

        private StarReward[] GetStarReward()
        {
            List<StarReward> lsStar = new List<StarReward>();
            var tmpStar = from tmp in css.lsdbStarReward
                          where tmp.status == 1
                          select tmp;

            foreach (var item in tmpStar)
            {
                StarReward star = new StarReward()
                {
                    starRequire = (int)item.starRequire,
                    rewards = HandlerStarReward(item.id)
                };
                lsStar.Add(star);
            }

            return lsStar.ToArray();
        }

        private Reward[] HandlerStarReward(int idStar)
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in css.lsdbStarRewardReward
                            where tmp.status == 1 && tmp.idStar == idStar
                            orderby tmp.procs ascending
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward reward = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(reward);
            }
            return lsReward.ToArray();
        }

        private void HandlerTotalPowerStage(Entity enitities)
        {
            double totalPower = 0;
            var tmpStage = from tmp in cs.dbMapStages
                           where tmp.status == 1
                           select tmp;

            foreach (var item in tmpStage)
            {
                var tmpMonter = from tmp1 in cs.dbMapStageMonters
                                where tmp1.status == 1 && tmp1.idStage == item.id
                                select tmp1;

                foreach (var item1 in tmpMonter)
                {
                    CharacterCalculator chr = new CharacterCalculator()
                    {
                        staticDB = enitities,
                        idInStatic = (int)item1.idMonter,
                        level = (int)item1.levels,
                        star = (int)item1.star,
                        levelPowerUp = (int)item1.levelPower
                    };
                    chr.Calculate();
                    totalPower += chr.GetPower();
                }

                var tmpStageSave = ConnectDB.Entities.dbMapStages.Where(x => x.id == item.id).FirstOrDefault();
                tmpStageSave.totalPower = totalPower;
                ConnectDB.Entities.SaveChanges();
                totalPower = 0;
            }
        }

        private Map[] GetMap()
        {
            css.HandlerMap();
            List<Map> lsMap = new List<Map>();
            var tmpMap = from tmp in css.lsdbMap
                         where tmp.status == 1
                         select tmp;

            foreach (var item in tmpMap)
            {
                Map map = new Map()
                {
                    name = HandlerKeyLanguage(6, (int)item.id)[0],
                    background = (int)item.background,
                    stages = HandlerStage((int)item.id).ToArray(),
                    isAuto = HandlerTrueorFalse((int)item.isAuto)
                };
                lsMap.Add(map);
            }
            return lsMap.ToArray();
        }

        private List<Stage> HandlerStage(int idMap)
        {
            List<Stage> lsStage = new List<Stage>();
            var tmpStage = from tmp in css.lsdbMapStage
                           where tmp.status == 1 && tmp.idMap == idMap
                           select tmp;

            foreach (var item in tmpStage)
            {
                Stage stage = new Stage()
                {
                    name = HandlerKeyLanguage(7, (int)item.id)[0],
                    description = HandlerKeyLanguage(7, (int)item.id)[1],
                    typeStage = (int)item.typeStage,
                    path = HandlerPoint2Stage((int)item.id).ToArray(),
                    maxAttack = (int)item.maxAttack,
                    silverRewardMax = (int)item.silverRewardMax,
                    silverRewardMin = (int)item.silverRewardMin,
                    stamina = (int)item.stamina,
                    rewards = HandlerRewardStage((int)item.id).ToArray(),
                    expRewardMax = (int)item.expRewardMax,
                    expRewardMin = (int)item.expRewardMin,
                    totalPower = (float)item.totalPower,
                    monsters = HandlerMonsterStage((int)item.id).ToArray(),
                    background = (int)item.background,
                    position = HandlerPositionStage((int)item.positionX, (int)item.positionY),
                    rewardsSupper = HandlerRewardStageSupper((int)item.id).ToArray(),
                    monstersSupper = HandlerStageMonterSupper((int)item.id).ToArray()
                };
                lsStage.Add(stage);
            }
            return lsStage;
        }

        private List<MonsterStage> HandlerStageMonterSupper(int idStage)
        {
            List<MonsterStage> lsMonterStage = new List<MonsterStage>();
            var tmpMonterStage = from tmp in css.lsdbMapStageMonterSupper
                                 where tmp.status == 1 && tmp.idStage == idStage
                                 select tmp;

            foreach (var item in tmpMonterStage)
            {
                MonsterStage monter = new MonsterStage()
                {
                    col = (int)item.col,
                    id = (int)item.idMonter,
                    level = (int)item.levels,
                    levelPower = (int)item.levelPower,
                    row = (int)item.row,
                    star = (int)item.star
                };
                lsMonterStage.Add(monter);
            }
            return lsMonterStage;
        }

        private List<Reward> HandlerRewardStageSupper(int idStage)
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in css.lsdbMapStageSupper
                            where tmp.status == 1 && tmp.idStage == idStage
                            orderby tmp.procs ascending
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward reward = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(reward);
            }
            return lsReward;
        }

        private List<Reward> HandlerRewardStage(int idStage)
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in css.lsdbMapStageReward
                            where tmp.status == 1 && tmp.idStage == idStage
                            orderby tmp.procs ascending
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward reward = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(reward);
            }
            return lsReward;
        }

        private Point2 HandlerPositionStage(int xy, int yy)
        {
            Point2 point = new Point2()
            {
                x = xy,
                y = yy
            };
            return point;
        }

        private List<Point2> HandlerPoint2Stage(int idStage)
        {
            List<Point2> lsPoint = new List<Point2>();
            var tmpPath = from tmp in css.lsdbMapStagePath
                          where tmp.status == 1 && tmp.idStage == idStage
                          select tmp;

            foreach (var item in tmpPath)
            {
                Point2 point = new Point2()
                {
                    x = (float)item.positionX,
                    y = (float)item.positionY
                };
                lsPoint.Add(point);
            }
            return lsPoint;
        }

        private List<MonsterStage> HandlerMonsterStage(int idStage)
        {
            List<MonsterStage> lsMonterStage = new List<MonsterStage>();
            var tmpMonterStage = from tmp in css.lsdbMapStageMonter
                                 where tmp.status == 1 && tmp.idStage == idStage
                                 select tmp;

            foreach (var item in tmpMonterStage)
            {
                MonsterStage monter = new MonsterStage()
                {
                    col = (int)item.col,
                    id = (int)item.idMonter,
                    level = (int)item.levels,
                    levelPower = (int)item.levelPower,
                    row = (int)item.row,
                    star = (int)item.star
                };
                lsMonterStage.Add(monter);
            }
            return lsMonterStage;
        }

        public Configs GetConfig()
        {
            var tmpConfig = cs.dbConfigs.FirstOrDefault();

            Configs ag = new Configs()
            {
                battleConfig = HandlerBattleConfig(),
                characterConfig = HandlerCharacterConfig(),
                characterLevelExps = HandlerCharacterLevelExp().ToArray(),
                equipmentConfig = HandlerEquipmentConfig(),
                freeStaminaTimeConfig = HandlerFreeStaminaConfig().ToArray(),
                maxLevelPlayer = (int)tmpConfig.maxLevelPlayer,
                playerLevelExps = HandlerPlayerLevelExps().ToArray(),
                silverSellCommon = (int)tmpConfig.silverSellCommon,
                vipConfigs = HandlerVipConfig().ToArray(),
                pointSkillConfig = HandlerPointSkillConfig((int)tmpConfig.maxPointSkillCanReach, (int)tmpConfig.minuteAutoUpPoint, (int)tmpConfig.pointNeedToUpSkill, (int)tmpConfig.baseGoldToBuy, (int)tmpConfig.stepGoldToBuy),
                friendConfig = HandlerFriend((int)tmpConfig.giftStamina, (int)tmpConfig.numberSuggestFriends, (int)tmpConfig.numberFriendsCanAdded),
                moiRuouConfig = HandlerMoiRuou((int)tmpConfig.staminaMoiruou),
                maxPointSkill = (int)tmpConfig.maxPointSkill,
                maxStamina = (int)tmpConfig.maxStamina,
                timeCooldownPlusPointSkill = (int)tmpConfig.timeCooldownPlusPointSkill,
                timeCooldownPlusStamina = (int)tmpConfig.timeCooldownPlusStamina,
                vanTieuConfig = HandlerVanTieu((int)tmpConfig.VanTieuGoldRequireToEnd, (int)tmpConfig.VanTieuTime, (int)tmpConfig.VanTieuVipRequireToEnd, (int)tmpConfig.VanTieuGoldRefeshVehicle, (int)tmpConfig.levelRequireVanTieu),
                cuopTieuConfig = HandlerCuopTieu(),
                thanThapConfig = HandlerThanThap(),
                globalBossConfig = HandlerGlobalBoss(),
                goldDoPhuongConfig = (int)tmpConfig.goldDoPhuongConfig,
                cauCaConfig = HandlerCauCauConfig(),
                luanKiemConfig = HandlerLuanKiemConfig(),
                chucPhucConfig = HandlerChucPhucConfig(),
                nhiemVuHangNgayConfig = HandlerNhiemVuHangNgayConfig(),
                guildConfig = HandlerGuildConfig(),
                nhiemVuChinhTuyenConfig = HandlerNhiemVuChinhTuyenConfig(),
                hoatDongDiemDanhConfig = HandlerHoatDongDiemDanh(),
                badWord = HandlerBadWord(),
                phucLoiThangConfig = HandlerPhucLoiThang(),
                levelRewardConfig = HandlerLevelRewardConfig(),
                percentBuySuccessMarket = (float)tmpConfig.percentBuySuccessMarket1,
                priceStartBuyMarket = (int)tmpConfig.priceStartBuyMarket,
                levelRequireMarket = (int)tmpConfig.levelRequireMarket,
                tutorialConfig = HandlerTutorialConfig(),
                mailGMConfig = HandlerGMMailConfig(),
                shareFacebookRewards = HandlerShareFacebook(),
                exchangeRubyToGoldConfig = (int)tmpConfig.exchangeRubyToGoldConfig,
                playerDefaultConfig = HandlerPlayerDefaultConfig(),
                phucLoiTruongThanhConfig = HandlerPhucLoiTruongThanhConfig(),
                cuuCuuTriTonConfig = HandlerCuuCuuChiTon(),
                ruongRewardConfigs = HandlerRuongBau(),
                exchangeGoldToSilverConfig = HandlerExchangeGoldToSilverConfig(),
                levelRequireDoPhuong = (int)tmpConfig.levelRequireDoPhuong,
                inviteFriendConfigs = HandlerInviteFriend(),
                maxGoldDoPhuongConfig = (int)tmpConfig.maxGoldDoPhuongConfig,
                huaNguyenConfig = HandlerHuaNguyenConfig(),
                //formationConfig
            };
            return ag;
        }

        private HuaNguyenConfig HandlerHuaNguyenConfig()
        {
            var tmpHuaNguyen = cs.dbHuaNguyenConfigs.FirstOrDefault();
            HuaNguyenConfig conf = new HuaNguyenConfig()
            {
                freeTimes = (int)tmpHuaNguyen.freeTimes,
                levelRequire = (int)tmpHuaNguyen.levelRequire,
                numberSoulReward = (int)tmpHuaNguyen.numberSoulReward,
                procGetCharHuaNguyen = (int)tmpHuaNguyen.procGetCharHuaNguyen
            };
            return conf;
        }

        private InviteFriendConfig[] HandlerInviteFriend()
        {
            List<InviteFriendConfig> lsInvite = new List<InviteFriendConfig>();

            foreach (var item in css.lsdbInviteFriendConfigs.Where(x => x.status == 1))
            {
                InviteFriendConfig conf = new InviteFriendConfig()
                {
                    require = (int)item.require,
                    rewards = HandlerRewardInviteFriend(item.id)
                };
                lsInvite.Add(conf);
            }
            return lsInvite.ToArray();
        }

        private List<Reward> HandlerRewardInviteFriend(int idInvite)
        {
            List<Reward> lsReward = new List<Reward>();

            foreach (var item in css.lsdbInviteFriendRewards.Where(x => x.idInvite == idInvite && x.status == 1))
            {
                Reward re = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (float)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(re);
            }
            return lsReward;
        }

        private ExchangeGoldToSilverConfig HandlerExchangeGoldToSilverConfig()
        {
            var item = cs.dbExchangeGoldToSilverConfigs.FirstOrDefault();

            ExchangeGoldToSilverConfig ex = new ExchangeGoldToSilverConfig()
            {
                baseGold = (int)item.baseGold,
                baseSilver = (int)item.baseSilver,
                bonusSilver = (double)item.bonusSilver,
                freeTimes = (int)item.freeTimes,
                levelRequire = (int)item.levelRequire,
                procBonusSilver = (double)item.procBonusSilver,
                stepUpGold = (double)item.stepUpGold
            };
            return ex;
        }

        private RuongRewardConfig[] HandlerRuongBau()
        {
            List<RuongRewardConfig> lsRuong = new List<RuongRewardConfig>();
            var tmpRuong = from tmp in cs.dbRuongBauConfigs
                           where tmp.status == 1
                           orderby tmp.idRuongBau ascending
                           select tmp;

            foreach (var item in tmpRuong)
            {
                RuongRewardConfig reward = new RuongRewardConfig()
                {
                    idRuong = (int)item.idRuongBau,
                    rewards = HandlerRuongBauReward(item.id)
                };
                lsRuong.Add(reward);
            }
            return lsRuong.ToArray();
        }

        private Reward[] HandlerRuongBauReward(int idGen)
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in cs.dbRuongBauRewards
                            where tmp.status == 1 && tmp.idRuong == idGen
                            orderby tmp.procs ascending
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward reward = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(reward);
            }
            return lsReward.ToArray();
        }

        private CuuCuuTriTonConfig HandlerCuuCuuChiTon()
        {
            var tmpCuu = cs.dbCuuCuuTriTonConfigs.FirstOrDefault();

            CuuCuuTriTonConfig cuu = new CuuCuuTriTonConfig()
            {
                ruby_require = (int)tmpCuu.ruby_require,
                duration = (int)tmpCuu.duration,
                rewards = HandlerCuuCuuTriTonReward()
            };
            return cuu;
        }

        private Reward[] HandlerCuuCuuTriTonReward()
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in cs.dbCuuCuuTriTonConfigRewards
                            where tmp.status == 1
                            orderby tmp.procs ascending
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward reward = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(reward);
            };

            return lsReward.ToArray();
        }

        private PhucLoiTruongThanhConfig HandlerPhucLoiTruongThanhConfig()
        {
            var tmpTruongThanh = cs.dbPhucLoiTruongThanhConfigs.FirstOrDefault();

            PhucLoiTruongThanhConfig phuc = new PhucLoiTruongThanhConfig()
            {
                ruby_require = (int)tmpTruongThanh.ruby_require,
                duration = (int)tmpTruongThanh.duration,
                rewards = HandlerPhucLoiTruongThanhLevel()
            };

            return phuc;
        }

        private List<LevelReward> HandlerPhucLoiTruongThanhLevel()
        {
            List<LevelReward> tmpLSLeve = new List<LevelReward>();
            var tmpLevel = from tmp in cs.dbPhucLoiTruongThanhLevels
                           where tmp.status == 1
                           select tmp;

            foreach (var item in tmpLevel)
            {
                LevelReward level = new LevelReward()
                {
                    level = (int)item.levels,
                    rewards = HandlerPhucLoiTruongThanhLevelReward(item.id)
                };
                tmpLSLeve.Add(level);
            }
            return tmpLSLeve;
        }

        private Reward[] HandlerPhucLoiTruongThanhLevelReward(int idGen)
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in cs.dbPhucLoiTruongThanhLevelRewards
                            where tmp.status == 1 && tmp.idLevel == idGen
                            orderby tmp.procs ascending
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward reward = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(reward);
            };

            return lsReward.ToArray();
        }

        private string[] HandlerTips()
        {
            List<string> lsStr = new List<string>();
            var tmpStr = from tmp in cs.dbTips
                         where tmp.status == 1
                         select tmp;

            foreach (var item in tmpStr)
            {
                lsStr.Add(item.keywords);
            }

            return lsStr.ToArray();
        }

        private PlayerDefaultConfig HandlerPlayerDefaultConfig()
        {
            var tmpPlay = cs.dbPlayerDefaultConfigs.FirstOrDefault();
            PlayerDefaultConfig player = new PlayerDefaultConfig()
            {
                gold = (int)tmpPlay.gold,
                level = (int)tmpPlay.levels,
                silver = (int)tmpPlay.silver,
                stamina = (int)tmpPlay.stamina,
                rewards = HandlerTaoNickReward()
            };
            return player;
        }

        private Reward[] HandlerTaoNickReward()
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in cs.dbTaoNickRewards
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward re = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(re);
            }

            return lsReward.ToArray();
        }

        private Reward[] HandlerShareFacebook()
        {
            List<Reward> tmpReward = new List<Reward>();

            var tmpFace = from tmp in cs.dbShareFacebooks
                          where tmp.status == 1
                          orderby tmp.procs ascending
                          select tmp;

            foreach (var item in tmpFace)
            {
                Reward re = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                tmpReward.Add(re);
            }

            return tmpReward.ToArray();
        }

        private GMMailConfig HandlerGMMailConfig()
        {
            var tmpGmail = cs.dbGMMailConfigs.FirstOrDefault();
            GMMailConfig conf = new GMMailConfig()
            {
                contentLength = (int)tmpGmail.contentLength,
                maxMailCanSentPerDay = (int)tmpGmail.maxMailCanSentPerDay,
                titleLength = (int)tmpGmail.titleLength
            };
            return conf;
        }

        private TutorialConfig HandlerTutorialConfig()
        {
            var tmpTutorial = cs.dbTutorialConfigs.FirstOrDefault();
            TutorialConfig conf = new TutorialConfig()
            {
                normalCharReward = (int)tmpTutorial.normalCharReward,
                specialCharReward = (int)tmpTutorial.specialCharReward
            };
            return conf;
        }

        private LevelReward[] HandlerLevelRewardConfig()
        {
            List<LevelReward> lsReward = new List<LevelReward>();
            var tmpLevel = from tmp in cs.dbLevelRewardConfigs
                           where tmp.status == 1
                           orderby tmp.levels
                           select tmp;

            foreach (var item in tmpLevel)
            {
                LevelReward phuc = new LevelReward()
                {
                    level = (int)item.levels,
                    rewards = HandlerLevelReward_Reward((int)item.id).ToArray()
                };
                lsReward.Add(phuc);
            }

            return lsReward.ToArray();
        }

        private List<Reward> HandlerLevelReward_Reward(int idLevel)
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in cs.dbLevelReward_Reward
                            where tmp.status == 1 && tmp.idLevel == idLevel
                            orderby tmp.procs ascending
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward reward = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(reward);
            }
            return lsReward;
        }

        private PhucLoiThangConfig HandlerPhucLoiThang()
        {
            var tmpPhucLoi = cs.dbPucLoiThangConfigs.FirstOrDefault();
            PhucLoiThangConfig phuc = new PhucLoiThangConfig()
            {
                rubyRequire = (int)tmpPhucLoi.goldRequire,
                ngay = (int)tmpPhucLoi.ngay,
                rewards = HandlerPhucLoiThangReward(tmpPhucLoi.id)
            };
            return phuc;
        }

        private List<Reward> HandlerPhucLoiThangReward(int idPhucLoi)
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in cs.dbPucLoiThangRewards
                            where tmp.status == 1 && tmp.idPhucLoi == idPhucLoi
                            orderby tmp.procs ascending
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward reward = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(reward);
            }
            return lsReward;
        }

        private BadWord HandlerBadWord()
        {
            List<string> lsBadWord = new List<string>();
            Dictionary<string, string> dicBadWord = new Dictionary<string, string>();

            var tmpBad = from tmp in cs.dbBadWords
                         where tmp.status == 1
                         select tmp;

            foreach (var item in tmpBad)
            {
                bool isChar = item.keys.Contains(" ");
                if (isChar == true)
                {
                    lsBadWord.Add(item.keys);
                }
                else
                {
                    dicBadWord.Add(item.keys, item.value);
                }
            }


            BadWord bad = new BadWord()
            {
                listBadWord = lsBadWord,
                dicBadWord = dicBadWord
            };

            return bad;
        }

        private HoatDongDiemDanhConfig HandlerHoatDongDiemDanh()
        {
            var tmpDiemDanh = cs.dbHoatDongDiemDanhConfigs.FirstOrDefault();
            HoatDongDiemDanhConfig conf = new HoatDongDiemDanhConfig()
            {
                goldRequireBuyMissingReward = (int)tmpDiemDanh.goldRequireBuyMissingReward,
                monthRewards = HandlerHoatDongDiemDanhMonth()
            };
            return conf;
        }

        private List<MonthReward> HandlerHoatDongDiemDanhMonth()
        {
            List<MonthReward> lsMonth = new List<MonthReward>();
            var tmpMonth = from tmp in cs.dbHoatDongDiemDanhMonths
                           where tmp.status == 1
                           select tmp;

            foreach (var item in tmpMonth)
            {
                MonthReward month = new MonthReward()
                {
                    month = (int)item.months,
                    rewards = HandlerHoatDongDiemDanhMonthReward((int)item.months)
                };
                lsMonth.Add(month);
            }
            return lsMonth;
        }

        private List<Reward> HandlerHoatDongDiemDanhMonthReward(int idMonth)
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in cs.dbHoatDongDiemDanhMonthRewards
                            where tmp.status == 1 && tmp.idMonth == idMonth
                            orderby tmp.date ascending
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward reward = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(reward);
            }
            return lsReward;
        }

        private NhiemVuChinhTuyenConfig HandlerNhiemVuChinhTuyenConfig()
        {
            NhiemVuChinhTuyenConfig chinhtuyen = new NhiemVuChinhTuyenConfig()
            {
                nhiemVus = HandlerNhiemVuChinhTuyen().ToArray()
            };
            return chinhtuyen;
        }

        private List<NhiemVuChinhTuyen> HandlerNhiemVuChinhTuyen()
        {
            List<NhiemVuChinhTuyen> lsChinhTuyen = new List<NhiemVuChinhTuyen>();
            var tmpChinhTuyen = from tmp in cs.dbNhiemVuChinhTuyens
                                where tmp.status == 1
                                select tmp;

            foreach (var item in tmpChinhTuyen)
            {
                NhiemVuChinhTuyen nhiem = new NhiemVuChinhTuyen()
                {
                    desc = HandlerKeyLanguage(10, (int)item.id)[1],
                    id = (int)item.idNhiemVu,
                    name = HandlerKeyLanguage(10, (int)item.id)[0],
                    numberRequire = (int)item.numberRequire,
                    number = (int)item.number,
                    stepUpNumber = (int)item.stepUpNumber,
                    type = (int)item.types,
                    rewards = HandlerNhiemVuChinhTuyenReward((int)item.id).ToArray()
                };
                lsChinhTuyen.Add(nhiem);
            }
            return lsChinhTuyen;
        }

        private List<NhiemVuChinhTuyenReward> HandlerNhiemVuChinhTuyenReward(int idNhiemVu)
        {
            List<NhiemVuChinhTuyenReward> lsReward = new List<NhiemVuChinhTuyenReward>();
            var tmpReward = from tmp in cs.dbNhiemVuChinhTuyenRewards
                            where tmp.status == 1 && tmp.idNhiemVu == idNhiemVu
                            select tmp;

            foreach (var item in tmpReward)
            {
                NhiemVuChinhTuyenReward nhiem = new NhiemVuChinhTuyenReward()
                {
                    quantity = (int)item.quantity,
                    staticID = (int)item.staticID,
                    stepUpQuantity = (int)item.stepUpQuantity,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(nhiem);
            }
            return lsReward;
        }

        private GuildConfig HandlerGuildConfig()
        {
            var tmpGuild = cs.dbGuildConfigs.FirstOrDefault();
            GuildConfig guild = new GuildConfig()
            {
                defaultAmountMember = (int)tmpGuild.defaultAmountMember,
                defaultContribution = (int)tmpGuild.defaultContribution,
                defaultContributionMember = (int)tmpGuild.defaultContributionMember,
                defaultNotice = tmpGuild.defaultNotice,
                durationLuaTraiMinutes = (int)tmpGuild.durationLuaTraiMinutes,
                goldToFinishNowMission = (int)tmpGuild.goldToFinishNowMission,
                hourLockMember = (int)tmpGuild.hourLockMember,
                idBoss = (int)tmpGuild.idBoss,
                levelContribution = HandlerGuildLevelContribution().ToArray(),
                levelRequireCreateGuild = (int)tmpGuild.levelRequireCreateGuild,
                maxLevel = (int)tmpGuild.maxLevel,
                maxTimeAttackBossGuild = (int)tmpGuild.maxTimeAttackBossGuild,
                missions = HandlerGuildMission().ToArray(),
                priceContribute1 = (int)tmpGuild.priceContribute1,
                priceContribute2 = (int)tmpGuild.priceContribute2,
                priceContribute3 = (int)tmpGuild.priceContribute3,
                priceCreateGuild = (int)tmpGuild.priceCreateGuild,
                recieveContribute1 = (int)tmpGuild.recieveContribute1,
                recieveContribute2 = (int)tmpGuild.recieveContribute2,
                recieveContribute3 = (int)tmpGuild.recieveContribute3,
                recieveContributeMember1 = (int)tmpGuild.recieveContributeMember1,
                recieveContributeMember2 = (int)tmpGuild.recieveContributeMember2,
                recieveContributeMember3 = (int)tmpGuild.recieveContributeMember3,
                rewardBoss = HandlerBossGuild().ToArray(),
                rewardsLuaTrai = HandlerGuildLuaTraiReward().ToArray(),
                timeRewardBoss = HandlerHourSendGift((int)tmpGuild.hourRewardBoss, (int)tmpGuild.minuteRewardBoss),
                dayOfWeekBangChien = (DayOfWeek)tmpGuild.dayOfWeekBangChien,
                minuteDurationBattleBangChien = (int)tmpGuild.minuteDurationBattleBangChien,
                waitTimeBangChien = (int)tmpGuild.waitTimeBangChien,
                hourStartBangChien = HandlerHourSendGift((int)tmpGuild.hourStartBangChien, (int)tmpGuild.minuteStartBangChien),
                bangChienMinMember = (int)tmpGuild.bangChienMinMember,
                rewardBangChien = HandlerRewardBangChien().ToArray()

            };
            return guild;
        }

        private List<Reward> HandlerRewardBangChien()
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in cs.dbGuildRewardBangChiens
                            where tmp.status == 1
                            orderby tmp.procs ascending
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward reward = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(reward);
            }
            return lsReward;
        }

        private List<Reward> HandlerGuildLuaTraiReward()
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in cs.dbGuildRewardsLuaTrais
                            where tmp.status == 1
                            orderby tmp.procs ascending
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward reward = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(reward);
            }
            return lsReward;
        }

        private List<RewardBossGuild> HandlerBossGuild()
        {
            List<RewardBossGuild> lsBoss = new List<RewardBossGuild>();
            var tmpBoss = from tmp in cs.dbGuildBosses
                          where tmp.status == 1
                          select tmp;
            foreach (var item in tmpBoss)
            {
                RewardBossGuild boss = new RewardBossGuild()
                {
                    maxRange = (int)item.maxRange,
                    minRange = (int)item.minRange,
                    rewards = HandlerGuildBossReward((int)item.id).ToArray()
                };
                lsBoss.Add(boss);
            }
            return lsBoss;
        }

        private List<Reward> HandlerGuildBossReward(int idBoss)
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in cs.dbGuildBossRewards
                            where tmp.status == 1 && tmp.idBoss == idBoss
                            orderby tmp.procs ascending
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward reward = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(reward);
            }
            return lsReward;
        }

        private List<MissionGuild> HandlerGuildMission()
        {
            List<MissionGuild> lsMission = new List<MissionGuild>();
            var tmpMission = from tmp in cs.dbGuildMissions
                             where tmp.status == 1
                             select tmp;

            foreach (var item in tmpMission)
            {
                MissionGuild mission = new MissionGuild()
                {
                    name = HandlerKeyLanguage(11, (int)item.id)[0],
                    contribute = (int)item.contribute,
                    contributeMember = (int)item.contributeMember,
                    durationMinutes = (int)item.durationMinutes,
                };
                lsMission.Add(mission);
            }
            return lsMission;
        }

        private List<GuildLevelContribution> HandlerGuildLevelContribution()
        {
            List<GuildLevelContribution> lsLevel = new List<GuildLevelContribution>();
            var tmpGuild = from tmp in cs.dbGuildLevelContributions
                           where tmp.status == 1
                           select tmp;

            foreach (var item in tmpGuild)
            {
                GuildLevelContribution guild = new GuildLevelContribution()
                {
                    contribution = (int)item.value
                };
                lsLevel.Add(guild);
            }
            return lsLevel;
        }

        private NhiemVuHangNgayConfig HandlerNhiemVuHangNgayConfig()
        {
            var tmpNVCT = cs.dbNhiemVuHangNgayConfigs.FirstOrDefault();
            NhiemVuHangNgayConfig nhiem = new NhiemVuHangNgayConfig()
            {
                goldRequireCompolete = (int)tmpNVCT.goldRequireCompolete,
                nhiemVus = HandlerNhiemVu().ToArray()
            };
            return nhiem;
        }

        private List<NhiemVuHangNgay> HandlerNhiemVu()
        {
            List<NhiemVuHangNgay> lsNhiemVu = new List<NhiemVuHangNgay>();
            var tmpNhiemVu = from tmp in css.lsdbNhiemVuHangNgay
                             where tmp.status == 1
                             select tmp;
            foreach (var item in tmpNhiemVu)
            {
                NhiemVuHangNgay nhiem = new NhiemVuHangNgay()
                {
                    type = (int)item.types,
                    quantity = (int)item.quantity,
                    name = HandlerKeyLanguage(9, item.id)[0],
                    desc = HandlerKeyLanguage(9, item.id)[1],
                    rewards = HandlerRewardNhiemVuHangNgay((int)item.id).ToArray()
                };
                lsNhiemVu.Add(nhiem);
            }
            return lsNhiemVu;
        }

        private List<Reward> HandlerRewardNhiemVuHangNgay(int idChinhTuyen)
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in css.lsdbNhiemVuHangNgayReward
                            where tmp.status == 1 && tmp.idNhiemVu == idChinhTuyen
                            orderby tmp.procs ascending
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward reward = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(reward);
            }
            return lsReward;
        }

        private ChucPhucConfig HandlerChucPhucConfig()
        {
            var tmpChucPhuc = cs.dbChucPhucConfigs.FirstOrDefault();
            ChucPhucConfig chuc = new ChucPhucConfig()
            {
                maxChucPhuc = (int)tmpChucPhuc.maxChucPhuc
            };
            return chuc;
        }

        private LuanKiemConfig HandlerLuanKiemConfig()
        {
            var tmpLuanKiem = cs.dbLuanKiemConfigs.FirstOrDefault();
            LuanKiemConfig luan = new LuanKiemConfig()
            {
                levelRequire = (int)tmpLuanKiem.levelRequire,
                timeMinutesCoolDownAttack = (int)tmpLuanKiem.timeMinutesCoolDownAttack,
                goldRequireQuickAttack = (int)tmpLuanKiem.goldRequireQuickAttack,
                rankRewards = HandlerLuanKiemRank((int)tmpLuanKiem.id).ToArray(),
                rangeOpponent = HandlerLuanKiemRange((int)tmpLuanKiem.id).ToArray(),
                rankPoint = HandlerLuanKiemPoint((int)tmpLuanKiem.id).ToArray(),
                hourSendGift = HandlerHourSendGift((int)tmpLuanKiem.hourSendGift, (int)tmpLuanKiem.minuteSendGift),
                loseRewards = HandlerLoseReward(),
                winRewards = HandlerWinReward()
            };
            return luan;
        }

        private Reward[] HandlerWinReward()
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in cs.dbLuanKiemWinRewards
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward conf = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(conf);
            }
            return lsReward.ToArray();
        }

        private Reward[] HandlerLoseReward()
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in cs.dbLuanKiemLoseRewards
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward conf = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(conf);
            }
            return lsReward.ToArray();
        }

        private Hour HandlerHourSendGift(int hr, int mn)
        {
            Hour hour = new Hour()
            {
                hour = hr,
                minute = mn
            };
            return hour;
        }

        private List<RankLuanKiemPoint> HandlerLuanKiemPoint(int idLuanKiem)
        {
            List<RankLuanKiemPoint> lsPoint = new List<RankLuanKiemPoint>();
            var tmpPoint = from tmp in cs.dbLuanKiemPoints
                           where tmp.status == 1 && tmp.idLuanKiem == idLuanKiem
                           select tmp;

            foreach (var item in tmpPoint)
            {
                RankLuanKiemPoint range = new RankLuanKiemPoint()
                {
                    pointReward = (int)item.pointReward,
                    rank = HandlerRange((int)item.rangeStart, (int)item.rangeEnd),
                    goldReward = (int)item.goldReward,
                    silverReward = (int)item.silverReward
                };
                lsPoint.Add(range);
            }
            return lsPoint;
        }

        private List<RangeLuanKiemOpponent> HandlerLuanKiemRange(int idLuanKiem)
        {
            List<RangeLuanKiemOpponent> lsRange = new List<RangeLuanKiemOpponent>();
            var tmpRange = from tmp in cs.dbLuanKiemRanges
                           where tmp.status == 1 && tmp.idLuanKiem == idLuanKiem
                           select tmp;

            foreach (var item in tmpRange)
            {
                RangeLuanKiemOpponent range = new RangeLuanKiemOpponent()
                {
                    range = HandlerRange((int)item.rangeStart, (int)item.rangeEnd),
                    rangeOpponent = HandlerRangeOpponent((int)item.id).ToArray()
                };
                lsRange.Add(range);
            }
            return lsRange;
        }

        private List<Range> HandlerRangeOpponent(int idRange)
        {
            List<Range> lsRange = new List<Range>();
            var tmpRange = from tmp in cs.dbLuanKiemRangeOpponents
                           where tmp.status == 1 && tmp.idRange == idRange
                           select tmp;

            foreach (var item in tmpRange)
            {
                Range range = new Range()
                {
                    start = (int)item.rangeStart,
                    end = (int)item.rangeEnd
                };
                lsRange.Add(range);
            }
            return lsRange;
        }

        private List<RankLuanKiemReward> HandlerLuanKiemRank(int idLuanKiem)
        {
            List<RankLuanKiemReward> lsRank = new List<RankLuanKiemReward>();
            var tmpRank = from tmp in cs.dbLuanKiemRanks
                          where tmp.idLuanKiem == idLuanKiem && tmp.status == 1
                          select tmp;

            foreach (var item in tmpRank)
            {
                RankLuanKiemReward rank = new RankLuanKiemReward()
                {
                    rangeRank = HandlerRange((int)item.rangeStart, (int)item.rangeEnd),
                    rewards = HandlerRewardLuanKiem((int)item.id).ToArray()
                };
                lsRank.Add(rank);
            }
            return lsRank;
        }

        private Range HandlerRange(int tmpStart, int tmpEnd)
        {
            Range ran = new Range()
            {
                start = tmpStart,
                end = tmpEnd
            };
            return ran;
        }

        private List<Reward> HandlerRewardLuanKiem(int idRank)
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in cs.dbLuanKiemRankRewards
                            where tmp.status == 1 && tmp.idRank == idRank
                            orderby tmp.procs ascending
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward reward = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(reward);
            }
            return lsReward;
        }

        private CauCaConfig HandlerCauCauConfig()
        {
            var tmpCauCa = cs.dbCauCaMainConfigs.FirstOrDefault();
            CauCaConfig cauca = new CauCaConfig()
            {
                goldRequireToEnd = (int)tmpCauCa.goldRequireToEnd,
                vipRequireToEnd = (int)tmpCauCa.vipRequireToEnd,
                canCauConfigs = HandlerCanCauConfig().ToArray()
            };
            return cauca;
        }

        private List<CanCauConfig> HandlerCanCauConfig()
        {
            List<CanCauConfig> lsCanCau = new List<CanCauConfig>();
            var tmpCanCau = from tmp in css.lsdbCauCaConfig
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpCanCau)
            {
                CanCauConfig can = new CanCauConfig()
                {
                    duration = (int)item.duration,
                    gold = (int)item.gold,
                    name = item.name,
                    silver = (int)item.silver,
                    vipRequire = (int)item.vipRequire,
                    rewards = HandlerRewardCauCa((int)item.id).ToArray()
                };
                lsCanCau.Add(can);
            }
            return lsCanCau;
        }

        private List<Reward> HandlerRewardCauCa(int idCauCa)
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in css.lsdbCauCaReward
                            where tmp.status == 1 && tmp.idCauca == idCauCa
                            orderby tmp.procs ascending
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward reward = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(reward);
            }
            return lsReward;
        }

        private GlobalBossConfig HandlerGlobalBoss()
        {
            var tmpBoss = cs.dbGlobalBossConfigs.FirstOrDefault();
            GlobalBossConfig boss = new GlobalBossConfig()
            {
                timeAttackBoss = HandlerTimeAttackBoss(),
                growthHp = (int)tmpBoss.growthHp,
                hpBossAtLevel1 = (int)tmpBoss.hpBossAtLevel,
                levelRequire = (int)tmpBoss.levelRequire,
                attackConfigs = HandlerAttackGlobalBoss().ToArray(),
                bonusRewards = HandlerGlobalBossRewardBonus()
            };
            return boss;
        }

        private TimeAttackBoss[] HandlerTimeAttackBoss()
        {
            List<TimeAttackBoss> lsTime = new List<TimeAttackBoss>();
            var timeAttack = from tmp in cs.dbTimeAttackBosses
                             where tmp.status == 1
                             select tmp;

            foreach (var item in timeAttack)
            {
                TimeAttackBoss conf = new TimeAttackBoss()
                {
                    start = HandlerHour((int)item.hoursStart, (int)item.minuteStart),
                    end = HandlerHour((int)item.hoursEnd, (int)item.minuteEnd)
                };
                lsTime.Add(conf);
            }
            return lsTime.ToArray();
        }

        private List<Reward> HandlerGlobalBossRewardBonus()
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in cs.dbGlobalBonusRewardConfigs
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward re = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    typeReward = (int)item.typeReward - 1,
                    staticID = (int)item.staticID
                };
                lsReward.Add(re);
            }

            return lsReward;
        }

        private List<AttackGlobalBossConfig> HandlerAttackGlobalBoss()
        {
            List<AttackGlobalBossConfig> lsAttack = new List<AttackGlobalBossConfig>();
            var tmpAttack = from tmp in cs.dbGlobalAttackConfigs
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpAttack)
            {
                AttackGlobalBossConfig att = new AttackGlobalBossConfig()
                {
                    vipRequire = (int)item.vipRequire,
                    waitTime = (int)item.waitTime
                };
                lsAttack.Add(att);
            }
            return lsAttack;
        }

        private Hour HandlerHour(int hour, int minute)
        {
            Hour hr = new Hour()
            {
                hour = hour,
                minute = minute
            };
            return hr;
        }

        private ThanThapConfig HandlerThanThap()
        {
            var tmpThanThap = cs.dbThanThaps.FirstOrDefault();
            ThanThapConfig conf = new ThanThapConfig()
            {
                attributes = HandlerThanThapArrayInt(1).ToArray(),
                hourEnd = (int)tmpThanThap.hourEnd,
                moneyRest = HandlerMoneyResetThanPhap().ToArray(),
                plushAttributeRequires = HandlerPlusAttributeRequire().ToArray(),
                prefixRestPlusGold = (int)tmpThanThap.prefixRestPlusGold,
                starRewards = HandlerThanThapArrayInt(2).ToArray(),
                levelRequire = (int)tmpThanThap.levelRequire,
                modDifficult = (float)tmpThanThap.modDifficultF,
                modLevel = (float)tmpThanThap.modLevelF,
                modPower = (float)tmpThanThap.modPowerF,
                modStar = (float)tmpThanThap.modStarF,
                stepFloorGetBonusAttribute = (int)tmpThanThap.stepFloorGetBonusAttribute,
                stepFloorGetBonusReward = (int)tmpThanThap.stepFloorGetBonusReward,
                floorRewards = HandlerRewardThanThap((int)tmpThanThap.id).ToArray(),
                monsters = HandlerMonterFormation()
            };
            return conf;
        }

        private List<ThanThapFormation> HandlerMonterFormation()
        {
            List<ThanThapFormation> lsThan = new List<ThanThapFormation>();
            var tmpMonter = from tmp in css.lsdbThanThapMonster
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpMonter)
            {
                ThanThapFormation infor = new ThanThapFormation()
                {
                    monsters = HandlerDetailMonterThanThap((int)item.id),
                };
                lsThan.Add(infor);
            }
            return lsThan;
        }

        private List<MonsterStage> HandlerDetailMonterThanThap(int idThanThapMonter)
        {
            List<MonsterStage> lsMonter = new List<MonsterStage>();
            var tmpMonter = from tmp in css.lsdbThanThapDetailMonster
                            where tmp.status == 1 && tmp.idThanThapMonter == idThanThapMonter
                            select tmp;

            foreach (var item in tmpMonter)
            {
                MonsterStage stage = new MonsterStage()
                {
                    id = (int)item.idMonter,
                    level = (int)item.levels,
                    levelPower = (int)item.levelPower,
                    row = (int)item.row,
                    star = (int)item.star,
                    col = (int)item.col
                };
                lsMonter.Add(stage);
            }

            return lsMonter;
        }

        private List<Reward> HandlerRewardThanThap(int idThanThap)
        {
            List<Reward> lsReward = new List<Reward>();
            var tmpReward = from tmp in cs.dbThanThapFloorRewards
                            where tmp.status == 1 && tmp.idThanThap == idThanThap
                            orderby tmp.procs ascending
                            select tmp;

            foreach (var item in tmpReward)
            {
                Reward reward = new Reward()
                {
                    amountMax = (int)item.amountMax,
                    amountMin = (int)item.amountMin,
                    proc = (double)item.procs,
                    staticID = (int)item.staticID,
                    typeReward = (int)item.typeReward - 1
                };
                lsReward.Add(reward);
            }
            return lsReward;
        }

        private List<PlusAttributeRequire> HandlerPlusAttributeRequire()
        {
            List<PlusAttributeRequire> lsMoney = new List<PlusAttributeRequire>();
            var tmpMoney = from tmp in cs.dbThanThapPlusAttributeRequires
                           where tmp.status == 1
                           select tmp;

            foreach (var item in tmpMoney)
            {
                PlusAttributeRequire money = new PlusAttributeRequire()
                {
                    procReceive = (int)item.procReceive,
                    startRequire = (int)item.startRequire
                };
                lsMoney.Add(money);
            }
            return lsMoney;
        }

        private List<MoneyResetThanThap> HandlerMoneyResetThanPhap()
        {
            List<MoneyResetThanThap> lsMoney = new List<MoneyResetThanThap>();
            var tmpMoney = from tmp in cs.dbThanThapMoneyResets
                           where tmp.status == 1
                           select tmp;

            foreach (var item in tmpMoney)
            {
                MoneyResetThanThap money = new MoneyResetThanThap()
                {
                    type = (int)item.types,
                    quantity = (int)item.quantity
                };
                lsMoney.Add(money);
            }
            return lsMoney;
        }

        private List<int> HandlerThanThapArrayInt(int type)
        {
            List<int> lsInt = new List<int>();
            if (type == 1)
            {
                var tmpAtt = from tmp in cs.dbThanThapAttributes
                             where tmp.status == 1
                             select tmp;

                foreach (var item in tmpAtt)
                {
                    lsInt.Add((int)item.value);
                }
            }
            else if (type == 2)
            {
                var tmpAtt = from tmp in cs.dbThanThapStarRewards
                             where tmp.status == 1
                             select tmp;

                foreach (var item in tmpAtt)
                {
                    lsInt.Add((int)item.value);
                }
            }
            return lsInt;
        }

        private CuopTieuConfig HandlerCuopTieu()
        {
            var tmpCuop = cs.dbCuopTieuConfigs.FirstOrDefault();
            CuopTieuConfig cuop = new CuopTieuConfig()
            {
                //maxTimesCuopTieu = (int)tmpCuop.maxTimesCuopTieu,
                maxTimesVehicleBiCuop = (int)tmpCuop.maxTimesVehicleBiCuop,
                procGetSilver = (int)tmpCuop.procGetSilver,
                procLoseSilver = (int)tmpCuop.procLoseSilver
            };
            return cuop;
        }

        private VanTieuConfig HandlerVanTieu(int x, int y, int z, int a, int b)
        {
            VanTieuConfig vantieu = new VanTieuConfig()
            {
                goldRequireToEnd = x,
                minutesDurationTime = y,
                vipRequireToEnd = z,
                goldRefeshVehicle = a,
                vehicles = HandlerVehicles(),
                levelRequire = b
            };
            return vantieu;
        }

        private List<Reward> HandlerVanTieuReward(int type, int idVanTieu)
        {
            List<Reward> lsReward = new List<Reward>();
            if (type == 1)
            {
                var tmpReward = from tmp in cs.dbVanTieuProtectRewards
                                where tmp.status == 1 && tmp.idVanTieu == idVanTieu
                                orderby tmp.procs ascending
                                select tmp;

                foreach (var item in tmpReward)
                {
                    Reward reward = new Reward()
                    {
                        amountMax = (int)item.amountMax,
                        amountMin = (int)item.amountMin,
                        proc = (double)item.procs,
                        staticID = (int)item.staticID,
                        typeReward = (int)item.typeReward - 1
                    };
                    lsReward.Add(reward);
                }
            }
            else if (type == 2)
            {
                var tmpReward = from tmp in cs.dbVanTieuRobRewards
                                where tmp.status == 1 && tmp.idVanTieu == idVanTieu
                                orderby tmp.procs ascending
                                select tmp;

                foreach (var item in tmpReward)
                {
                    Reward reward = new Reward()
                    {
                        amountMax = (int)item.amountMax,
                        amountMin = (int)item.amountMin,
                        proc = (double)item.procs,
                        staticID = (int)item.staticID,
                        typeReward = (int)item.typeReward - 1
                    };
                    lsReward.Add(reward);
                }
            }
            return lsReward;
        }

        private List<VehicleConfig> HandlerVehicles()
        {
            List<VehicleConfig> lsVehicle = new List<VehicleConfig>();
            var tmpVehicle = from tmp in cs.dbVanTieux
                             where tmp.status == 1
                             select tmp;

            foreach (var item in tmpVehicle)
            {
                VehicleConfig ve = new VehicleConfig()
                {
                    proc = (int)item.procs,
                    silverReward = (int)item.silverReward,
                    protectRewards = HandlerVanTieuReward(1, (int)item.id).ToArray(),
                    robRewards = HandlerVanTieuReward(2, (int)item.id).ToArray()
                };
                lsVehicle.Add(ve);
            }

            return lsVehicle;
        }

        private MoiRuouConfig HandlerMoiRuou(int x)
        {
            MoiRuouConfig conf = new MoiRuouConfig()
            {
                stamina = x
            };
            return conf;
        }

        private FriendConfig HandlerFriend(int x, int y, int z)
        {
            FriendConfig conf = new FriendConfig()
            {
                giftStamina = x,
                numberFriendCanAdd = z,
                numberSuggestFriends = y
            };
            return conf;
        }

        private PointSkillConfig HandlerPointSkillConfig(int max, int mini, int point, int bases, int step)
        {
            PointSkillConfig poi = new PointSkillConfig()
            {
                maxPointSkillCanReach = max,
                minuteAutoUpPoint = mini,
                pointNeedToUpSkill = point,
                baseGoldToBuy = bases,
                stepGoldToBuy = step
            };
            return poi;
        }

        private List<VipConfig> HandlerVipConfig()
        {
            List<VipConfig> lsVip = new List<VipConfig>();

            var tmpVip = from tmp in cs.dbVipConfigs
                         where tmp.status == 1
                         select tmp;

            foreach (var item in tmpVip)
            {
                VipConfig vip = new VipConfig()
                {
                    arenaTimes = (int)item.arenaTimes,
                    challengeTimes = (int)item.challengeTimes,
                    rubyRequire = (int)item.goldRequire,
                    resetStageTimes = (int)item.resetStageTimes,
                    moiRuouTimes = (int)item.moiRuouTimes,
                    vanTieuTimes = (int)item.vanTieuTimes,
                    cauCaTimes = (int)item.cauCaTimes,
                    doPhuongTimes = (int)item.doPhuongTimes,
                    cuopTieuTimes = (int)item.cuopTieuTimes,
                    maxSellMarket = (int)item.maxSellMarket,
                    exchangeGoldToSilverTimes = (int)item.exchangeGoldToSilverTimes,
                    huaNguyenTimes = (int)item.huaNguyenTimes,
                    buyPointSkillTimes = (int)item.buyPointSkillTimes
                };
                lsVip.Add(vip);
            }
            return lsVip;
        }

        private List<PlayerLevelExp> HandlerPlayerLevelExps()
        {
            List<PlayerLevelExp> lsCharacterLevelExp = new List<PlayerLevelExp>();
            var tmpChr = from gh in cs.dbPlayerLevelExps
                         where gh.status == 1
                         select gh;
            foreach (var item in tmpChr)
            {
                PlayerLevelExp chr = new PlayerLevelExp()
                {
                    exp = (int)item.exps,
                    level = (int)item.levels
                };
                lsCharacterLevelExp.Add(chr);
            }
            return lsCharacterLevelExp;
        }

        private List<FreeStaminaConfig> HandlerFreeStaminaConfig()
        {
            List<FreeStaminaConfig> lsFree = new List<FreeStaminaConfig>();
            var tmpFree = from tmp in cs.dbFreeStaminaConfigs
                          where tmp.status == 1
                          select tmp;

            foreach (var item in tmpFree)
            {
                FreeStaminaConfig free = new FreeStaminaConfig()
                {
                    from = (int)item.froms,
                    stamina = (int)item.stamina,
                    to = (int)item.tos
                };
                lsFree.Add(free);
            }
            return lsFree;
        }

        private EquipmentConfig HandlerEquipmentConfig()
        {
            var tmpEqui = cs.dbEquipmentConfigs.FirstOrDefault();
            EquipmentConfig equi = new EquipmentConfig()
            {
                //maxStarCanReach = (int)tmpEqui.maxStarCanReach,
                //pieceNeedToImport = HandlerPieceNeedToImport().ToArray(),
                //pieceExportReceive = HandlerPieceExportReceive().ToArray(),
                //defaultConfig = HandlerEquipDefaultConfig((int)tmpEqui.levelDefault, (int)tmpEqui.starLevelDefault),
                //equipLevelUpConfig = HandlerEquipLevelUpConfig((int)tmpEqui.baseGold),
                //equipStarUpConfig = HandlerEquipStarUpConfig().ToArray(),
                //maxEquipToUpStar = (int)tmpEqui.maxEquipToUpStar,
                //modStar = (float)tmpEqui.procReceivedUpStar
            };
            return equi;
        }

        private EquipLevelUpConfig HandlerEquipLevelUpConfig(int baseGold)
        {
            EquipLevelUpConfig equip = new EquipLevelUpConfig()
            {
                baseGold = baseGold,
                powRateByPromotion = HandlerEquipLevelUpConfigArr()
            };

            return equip;
        }

        private float[] HandlerEquipLevelUpConfigArr()
        {
            List<float> lsFloat = new List<float>();
            var tmpFloat = from tmp in cs.dbPowRateByPromotions
                           where tmp.status == 1
                           select tmp;

            foreach (var item in tmpFloat)
            {
                lsFloat.Add((float)item.powRateByPromotion);
            }

            return lsFloat.ToArray();
        }

        private List<EquipStarUpConfig> HandlerEquipStarUpConfig()
        {
            List<EquipStarUpConfig> lsEquip = new List<EquipStarUpConfig>();
            //var tmpEquip = from tmp in css.lsdbEquipStarUpConfig
            //               where tmp.status == 1
            //               select tmp;

            //foreach (var item in tmpEquip)
            //{
            //    EquipStarUpConfig equi = new EquipStarUpConfig()
            //    {
            //        rateByPromotion = HandlerEquipStarUpDetail((int)item.id).ToArray(),
            //        star = (int)item.equipStockStar,
            //        promotion = (int)item.promotion
            //    };
            //    lsEquip.Add(equi);
            //}
            return lsEquip;
        }

        private List<float> HandlerEquipStarUpDetail(int idEqui)
        {
            List<float> lsEquip = new List<float>();
            //var tmpEquip = from tmp in css.lsdbEquipStarUpDetail
            //               where tmp.status == 1 && tmp.idStarUp == idEqui
            //               select tmp;

            //foreach (var item in tmpEquip)
            //{
            //    lsEquip.Add((float)item.value);
            //}
            return lsEquip;
        }

        private List<int> HandlerPieceNeedToImport()
        {
            List<int> lsSilver = new List<int>();
            //var tmpSilver = from tmp in cs.dbPieceNeedToImports
            //                where tmp.status == 1
            //                select tmp;

            //foreach (var item in tmpSilver)
            //{
            //    lsSilver.Add((int)item.value);
            //}
            return lsSilver;
        }

        private List<int> HandlerPieceExportReceive()
        {
            List<int> lsSilver = new List<int>();
            //var tmpSilver = from tmp in cs.dbpieceExportReceives
            //                where tmp.status == 1
            //                select tmp;

            //foreach (var item in tmpSilver)
            //{
            //    lsSilver.Add((int)item.value);
            //}
            return lsSilver;
        }

        private EquipDefaultConfig HandlerEquipDefaultConfig(int level, int starLevel)
        {
            EquipDefaultConfig equi = new EquipDefaultConfig()
            {
                //level = level,
                //starLevel = starLevel
            };
            return equi;
        }

        private List<CharacterLevelExp> HandlerCharacterLevelExp()
        {
            List<CharacterLevelExp> lsCharacterLevelExp = new List<CharacterLevelExp>();
            var tmpChr = from gh in cs.dbCharacterLevelExps
                         where gh.status == 1
                         select gh;
            foreach (var item in tmpChr)
            {
                CharacterLevelExp chr = new CharacterLevelExp()
                {
                    exp = (int)item.exps,
                    level = (int)item.levels
                };
                lsCharacterLevelExp.Add(chr);
            }
            return lsCharacterLevelExp;
        }

        private CharacterConfig HandlerCharacterConfig()
        {
            var tmpBattle = cs.dbCharacterConfigs.FirstOrDefault();
            CharacterConfig chr = new CharacterConfig()
            {
                defaultConfig = HandlerCharDefaultConfig(),
                defaultCharSelections = HandlerCharSelection().ToArray(),
                //arrCharStarLevelExpConfig
            };
            return chr;
        }

        private List<CharSelection> HandlerCharSelection()
        {
            List<CharSelection> lsSelect = new List<CharSelection>();
            var tmpSelect = from tmp in cs.dbCharSelections
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpSelect)
            {
                CharSelection chr = new CharSelection()
                {
                    background = (int)item.background,
                    id = (int)item.idChr
                };
                lsSelect.Add(chr);
            }

            return lsSelect;
        }

        private CharDefaultConfig HandlerCharDefaultConfig()
        {
            var tmpBattle = cs.dbCharDefaultConfigs.FirstOrDefault();
            CharDefaultConfig chr = new CharDefaultConfig()
            {
                levelChar = (int)tmpBattle.levelChar,
                levelSkill = (int)tmpBattle.levelSkill,
                powerupLevelChar = (int)tmpBattle.powerupLevelChar
            };
            return chr;
        }

        private BattleConfig HandlerBattleConfig()
        {
            var tmpBattle = cs.dbBattleConfigs.FirstOrDefault();
            BattleConfig battle = new BattleConfig()
            {
                maxTurn = (int)tmpBattle.maxTurn,
                posInBattle = HandlerPoint2Array().ToArray(),
                centerBattle = HandlerPoint2((int)tmpBattle.centerBattleX, (int)tmpBattle.centerBattleY),
                distanceFrontTarget = (float)tmpBattle.distanceFrontTarget,
                manaPool = (int)tmpBattle.manaPool,
                manaRegenNormal = (int)tmpBattle.manaRegenNormal,
                manaRegenUltimate = (int)tmpBattle.manaRegenUltimate,
                manaRegenAttacked = (int)tmpBattle.manaRegenAttacked,
                idBackgroundThachDau = (int)tmpBattle.idBackgroundThachDau,
                idBossWorld = (int)tmpBattle.idBossWorld,
                idBackgroundThanThap = (int)tmpBattle.idBackgroundThanThap,
                idBackgroundBoss = (int)tmpBattle.idBackgroundBoss,
                idBackgroundCuopTieu = (int)tmpBattle.idBackgroundCuopTieu,
                idBackgroundLuanKiem = (int)tmpBattle.idBackgroundLuanKiem,
                idBackgroundBangChien = (int)tmpBattle.idBackgroundBangChien,
                levelSpeed = (int)tmpBattle.levelSpeed,
                vipAuto = (int)tmpBattle.vipAuto,
                levelAuto = (int)tmpBattle.levelAuto,
                rangeRandomDamage = (int)tmpBattle.rangeRandomDamage
            };
            return battle;
        }

        private Point2 HandlerPoint2(float tmpX, float tmpY)
        {
            Point2 point = new Point2()
            {
                x = tmpX,
                y = tmpY
            };
            return point;
        }

        private List<Point2Array> HandlerPoint2Array()
        {
            List<Point2Array> lsPoint2 = new List<Point2Array>();
            var tmpPoint = from tmp in css.lsdbBattlePoint2ArrayConfig
                           where tmp.status == 1
                           select tmp;

            foreach (var item in tmpPoint)
            {
                Point2Array point = new Point2Array()
                {
                    values = HandlerPoint2((int)item.id).ToArray()
                };
                lsPoint2.Add(point);
            }
            return lsPoint2;
        }

        private List<Point2> HandlerPoint2(int idPoint)
        {
            List<Point2> lsPoint = new List<Point2>();
            var tmpPoint = from tmp in css.lsdbBattlePoint2Config
                           where tmp.status == 1 && tmp.idPoint2Array == idPoint
                           select tmp;
            foreach (var item in tmpPoint)
            {
                Point2 po = new Point2()
                {
                    x = (float)item.x,
                    y = (float)item.y
                };
                lsPoint.Add(po);
            };
            return lsPoint;
        }

        public Equipment[] GetEquipment()
        {
            List<Equipment> lsEquip = new List<Equipment>();
            var tmpEquip = from tmp in css.lsdbEquipment
                           where tmp.status == 1
                           select tmp;

            foreach (var chr in tmpEquip)
            {
                Equipment newChar = new Equipment()
                {
                    id = (int)chr.idEquipment,
                    category = (CategoryEquipment)chr.category,
                    description = HandlerKeyLanguage(5, (int)chr.id)[1],
                    name = HandlerKeyLanguage(5, (int)chr.id)[0],
                    baseMarketPrice = (int)chr.baseMarketPrice,
                    canSellMarket = HandlerTrueorFalse((int)chr.canSellMarket),
                    icon = (int)chr.icon,
                    lowestStarLevel = (int)chr.lowestStarLevel,
                    highestStarLevel = (int)chr.highestStarLevel,
                    attribute = HandlerEquipmentAttribute((int)chr.attAttribute, (float)chr.attGrowthMod, (float)chr.attMods),
                    bonusAttributes = HandlerEquipBonusAttribute((int)chr.id)
                };
                lsEquip.Add(newChar);
            }
            return lsEquip.ToArray();
        }

        private ElementBonusAttribute[] HandlerEquipBonusAttribute(int idEuip)
        {
            List<ElementBonusAttribute> lsElement = new List<ElementBonusAttribute>();
            foreach (var item in css.lsdbEquipmentElementAttributes.Where(x => x.idEquipment == idEuip))
            {
                ElementBonusAttribute elemt = new ElementBonusAttribute()
                {
                    element = (TypeElement)item.element,
                    bonusAttributes = HandlerBonusEquipment((int)item.id)
                };
                lsElement.Add(elemt);
            }
            return lsElement.ToArray();
        }

        private BonusAttribute[] HandlerBonusEquipment(int idElement)
        {
            List<BonusAttribute> lsBonus = new List<BonusAttribute>();

            foreach (var item in css.lsdbEquipmentBonusAttribute.Where(x => x.idElement == idElement))
            {
                BonusAttribute bonus = new BonusAttribute()
                {
                    attribute = (CharacterAttribute)item.attribute,
                    maxGrowMod = (float)item.minGrowMod,
                    maxMod = (float)item.maxMod,
                    minGrowMod = (float)item.minGrowMod,
                    minMod = (float)item.minMod,
                    proc = (float)item.procs
                };
                lsBonus.Add(bonus);
            }
            return lsBonus.ToArray();
        }

        private MainAttribute HandlerEquipmentAttribute(int x, float y, float z)
        {
            MainAttribute main = new MainAttribute()
            {
                attribute = (CharacterAttribute)x,
                growthMod = y,
                mod = z
            };
            return main;
        }

        public Item[] GetItem()
        {
            List<Item> lsItem = new List<Item>();

            var tmpItem = from tmp in css.lsdbItem
                          where tmp.status == 1
                          orderby tmp.idItem ascending
                          select tmp;

            foreach (var chr in tmpItem)
            {
                Item newChar = new Item()
                {
                    id = (int)chr.idItem,
                    border = (int)chr.border,
                    attribute = HandlerAttributeItem((int)chr.id).ToArray(),
                    description = HandlerKeyLanguage(4, (int)chr.id)[1],
                    name = HandlerKeyLanguage(4, (int)chr.id)[0],
                    sellPrice = (float)chr.sellPrice,
                    type = (short)chr.types
                };
                lsItem.Add(newChar);
            }
            return lsItem.ToArray();
        }

        private List<float> HandlerAttributeItem(int idItem)
        {
            List<float> lsFloat = new List<float>();
            var tmpFloat = from tmp in css.lsdbItemAttribute
                           where tmp.status == 1 && tmp.idItem == idItem
                           select tmp;

            foreach (var item in tmpFloat)
            {
                lsFloat.Add((int)item.value);
            }
            return lsFloat;
        }

        public PowerUpItem[] GetPowerUpItem()
        {
            List<PowerUpItem> lsPow = new List<PowerUpItem>();
            var tmpPow = from tmp in css.lsdbPowerUpItem
                         where tmp.status == 1
                         orderby tmp.idPowerUpItems ascending
                         select tmp;

            foreach (var chr in tmpPow)
            {
                PowerUpItem newChar = new PowerUpItem()
                {
                    id = (int)chr.idPowerUpItems,
                    promotion = (int)chr.promotion,
                    attributes = HandlerAttribute(4, (int)chr.id).ToArray(),
                    levelRequire = (int)chr.levelRequire,
                    name = HandlerKeyLanguage(8, (int)chr.id)[0],
                    description = HandlerKeyLanguage(8, (int)chr.id)[1]
                };
                lsPow.Add(newChar);
            }
            return lsPow.ToArray();
        }

        public Character[] GetCharacters()
        {
            List<Character> lsCharacter = new List<Character>();

            foreach (var chr in css.lsdbCharacter.OrderBy(a => a.idCharacter))
            {
                Character newChar = new Character();
                newChar.id = (int)chr.idCharacter;
                newChar.name = HandlerKeyLanguage(1, (int)chr.idCharacter)[0];
                newChar.description = HandlerKeyLanguage(1, (int)chr.idCharacter)[1];
                newChar.category = (CategoryCharacter)chr.category;
                newChar.element = (TypeElement)chr.classCharacter;
                newChar.isCreep = HandlerTrueorFalse((int)chr.isCreep);
                newChar.idCharHuaNguyen = (int)chr.idCharHuaNguyen;
                newChar.attributes = HandlerAttribute(1, (int)chr.id).ToArray();
                newChar.classChar = (ClassCharacter)chr.classCharacter;
                newChar.duyenphans = HandlerDuyenPhan((int)chr.id).ToArray();
                newChar.highestStarLevel = (int)chr.highestStarLevel;
                newChar.idGroup = (int)chr.idGroup;
                newChar.isMale = HandlerTrueorFalse((int)chr.isMale);
                newChar.lowestStarLevel = (int)chr.lowestStarLevel;
                newChar.quote = chr.quote;
                newChar.type = (TypeCharacter)chr.typeCharacter;
                newChar.normalSkill = HandlerSkill(1, (int)chr.id).Count > 0 ? HandlerSkill(1, (int)chr.id)[0] : null;
                newChar.ultimateSkill = HandlerSkill(2, (int)chr.id).ToArray();
                newChar.passiveSkill = HandlerSkill(3, (int)chr.id).Count > 0 ? HandlerSkill(3, (int)chr.id)[0] : null;
                lsCharacter.Add(newChar);
            }
            return lsCharacter.ToArray();
        }

        private List<Skill> HandlerSkill(int type, int idChr)
        {
            List<Skill> lsSkill = new List<Skill>();
            var tmpSkill = from skill in css.lsdbCharSkill
                           where skill.status == 1 && skill.idCharacter == idChr && skill.types == type
                           select skill;

            if (tmpSkill != null)
            {
                foreach (var item in tmpSkill)
                {
                    Skill sk = new Skill()
                    {
                        name = HandlerKeyLanguage(2, (int)item.id)[0],
                        description = HandlerKeyLanguage(2, (int)item.id)[1],
                        type = HandlerTypeSkill((int)item.types),
                        slot = (int)item.slot,
                        category = (CategoryCharacter)item.category,
                        cooldown = (int)item.cooldown,
                        target = (TargetSkill)item.targets,
                        effect = (EffectSkill)item.effect,
                        range = (RangeSkill)item.ranges,
                        afflictionSkill = (Affliction)item.afflictionSkill,
                        afflictionAttributes = HandlerAttribute(2, (int)item.id).ToArray(),
                        attributes = HandlerAttribute(3, (int)item.id).ToArray(),
                        countTurn = (int)item.countTurn,
                        typeSpawnSkill = (TypeSpawnSkill)item.typeSpawnSkill,
                        afflictionDuration = (int)item.afflictionDuration,
                        afflictionProc = (int)item.afflictionProc,
                        startCooldown = (int)item.startCooldown,
                        typePassive = (TypePassiveSpawnSkill)item.typePassive
                    };
                    lsSkill.Add(sk);
                }

                return lsSkill;
            }
            else
            {
                return null;
            }
        }

        private int HandlerTypeSkill(int num)
        {
            if (num == 1 || num == 2)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        private List<DuyenPhan> HandlerDuyenPhan(int idChr)
        {
            List<DuyenPhan> tmpDuyenPhan = new List<DuyenPhan>();

            foreach (var item in css.lsdbCharDuyenPhan.Where(x => x.idCharacter == idChr))
            {
                DuyenPhan dp = new DuyenPhan()
                {
                    attributes = HandlerDuyenPhanAttribute((int)item.id).ToArray(),
                    category = (short)item.category,
                    isOne = HandlerTrueorFalse((int)item.isOne),
                    name = HandlerKeyLanguage(3, (int)item.id)[0],
                    ids = HandlerDuyenIDS((int)item.id).ToArray(),
                };
                tmpDuyenPhan.Add(dp);
            }
            return tmpDuyenPhan;
        }

        private List<MainAttribute> HandlerDuyenPhanAttribute(int idDuyen)
        {
            List<MainAttribute> lsAttribute = new List<MainAttribute>();

            foreach (var item in css.lsdbCharDuyenPhanAttribute.Where(x => x.idDuyen == idDuyen))
            {
                MainAttribute main = new MainAttribute()
                {
                    mod = (float)item.mods,
                    growthMod = (float)item.growthMod,
                    attribute = (CharacterAttribute)item.attribute
                };
                lsAttribute.Add(main);
            }

            return lsAttribute;
        }

        private List<int> HandlerDuyenIDS(int idDuyen)
        {
            List<int> lsAttribute = new List<int>();
            var lsDuyen = from ls in css.lsdbCharDuyenPhanID
                          where ls.idDuyen == idDuyen && ls.status == 1
                          select ls;

            foreach (var item in lsDuyen)
            {
                lsAttribute.Add((int)item.value);
            }

            return lsAttribute;
        }

        private List<MainAttribute> HandlerAttribute(int type, int idGen)
        {
            List<MainAttribute> tmpAttribute = new List<MainAttribute>();
            if (type == 1)
            {
                foreach (var item in css.lsdbCharAttribute.Where(x => x.idCharacter == idGen))
                {
                    MainAttribute it = new MainAttribute()
                    {
                        attribute = (CharacterAttribute)item.attribute,
                        growthMod = (float)item.growthMod,
                        mod = (float)item.mods
                    };
                    tmpAttribute.Add(it);
                }
            }
            else if (type == 2)
            {
                foreach (var item in css.lsdbCharSkillAfflictionAttribute.Where(x => x.idSkill == idGen))
                {
                    MainAttribute it = new MainAttribute()
                    {
                        attribute = (CharacterAttribute)item.attribute,
                        growthMod = (float)item.growthMod,
                        mod = (float)item.mods
                    };
                    tmpAttribute.Add(it);
                }
            }
            else if (type == 3)
            {
                var lsAttribute = from tmp in css.lsdbCharSkillAttribute
                                  where tmp.idSkill == idGen && tmp.status == 1
                                  select tmp;

                foreach (var item in lsAttribute)
                {
                    MainAttribute it = new MainAttribute()
                    {
                        attribute = (CharacterAttribute)item.attribute,
                        growthMod = (float)item.growthMod,
                        mod = (float)item.mods
                    };
                    tmpAttribute.Add(it);
                }
            }
            else if (type == 4)
            {
                var lsAttribute = from tmp in css.lsdbPowerUpItemsAttribute
                                  where tmp.idPowerUpItems == idGen && tmp.status == 1
                                  select tmp;

                foreach (var item in lsAttribute)
                {
                    MainAttribute it = new MainAttribute()
                    {
                        attribute = (CharacterAttribute)item.attribute,
                        growthMod = (float)item.growthMod,
                        mod = (float)item.mods
                    };
                    tmpAttribute.Add(it);
                }
            }

            else if (type == 5)
            {
                //var lsAttribute = from tmp in css.lsdbEquipmentAttribute
                //                  where tmp.idEquipment == idGen && tmp.status == 1
                //                  select tmp;

                //foreach (var item in lsAttribute)
                //{
                //    MainAttribute it = new MainAttribute()
                //    {
                //        attribute = (CharacterAttribute)item.attribute,
                //        growthMod = (float)item.growthMod,
                //        mod = (float)item.mods
                //    };
                //    tmpAttribute.Add(it);
                //}
            }

            return tmpAttribute;
        }

        public void CreateFileLanguage()
        {
            Dictionary<string, string> dicLanguage = new Dictionary<string, string>();
            var lsCharacter = from chr in cs.dbCharacters
                              where chr.status == 1
                              select chr;

            foreach (var item in lsCharacter)
            {
                dicLanguage.Add("char_" + item.idCharacter + "_name", item.name);
                dicLanguage.Add("char_" + item.idCharacter + "_desc", item.descriptions);
            }

            var lsSkill = from chr in cs.dbCharSkills
                          where chr.status == 1
                          select chr;

            foreach (var item in lsSkill)
            {
                dicLanguage.Add("skill_" + item.id + "_name", item.name);
                dicLanguage.Add("skill_" + item.id + "_desc", item.descriptions);
            }

            var lsDuyenPhan = from chr in cs.dbCharDuyenPhans
                              where chr.status == 1
                              select chr;

            foreach (var item in lsDuyenPhan)
            {
                dicLanguage.Add("duyenphan_" + item.id + "_name", item.name);
            }

            var lsItem = from chr in cs.dbItems
                         where chr.status == 1
                         select chr;

            foreach (var item in lsItem)
            {
                dicLanguage.Add("item_" + item.id + "_name", item.name);
                dicLanguage.Add("item_" + item.id + "_desc", item.descriptions);
            }

            var lsEquipment = from chr in cs.dbEquipments
                              where chr.status == 1
                              select chr;

            foreach (var item in lsEquipment)
            {
                dicLanguage.Add("equipment_" + item.id + "_name", item.name);
                dicLanguage.Add("equipment_" + item.id + "_desc", item.descriptions);
            }

            var lsMap = from chr in cs.dbMaps
                        where chr.status == 1
                        select chr;

            foreach (var item in lsMap)
            {
                dicLanguage.Add("map_" + item.id + "_name", item.name);
            }

            var lsStage = from chr in cs.dbMapStages
                          where chr.status == 1
                          select chr;

            foreach (var item in lsStage)
            {
                dicLanguage.Add("stage_" + item.id + "_name", item.name);
                dicLanguage.Add("stage_" + item.id + "_desc", item.descriptions);
            }

            var lsPowerup = from chr in cs.dbPowerUpItems
                            where chr.status == 1
                            select chr;

            foreach (var item in lsPowerup)
            {
                dicLanguage.Add("powerup_" + item.id + "_name", item.name);
                dicLanguage.Add("powerup_" + item.id + "_desc", item.description);
            }

            var lsNhiemVuHangNgay = from chr in cs.dbNhiemVuHangNgays
                                    where chr.status == 1
                                    select chr;

            foreach (var item in lsNhiemVuHangNgay)
            {
                dicLanguage.Add("nhiemvuhangngay_" + item.id + "_name", item.name);
                dicLanguage.Add("nhiemvuhangngay_" + item.id + "_desc", item.des);
            }

            var lsNhiemVuChinhTuyen = from chr in cs.dbNhiemVuChinhTuyens
                                      where chr.status == 1
                                      select chr;

            foreach (var item in lsNhiemVuChinhTuyen)
            {
                dicLanguage.Add("nhiemvuchinhtuyen_" + item.id + "_name", item.name);
                dicLanguage.Add("nhiemvuchinhtuyen_" + item.id + "_desc", item.des);
            }

            var lsNhiemVuBang = from chr in cs.dbGuildMissions
                                where chr.status == 1
                                select chr;

            foreach (var item in lsNhiemVuBang)
            {
                dicLanguage.Add("nhiemvubang_" + item.id + "_name", item.name);
            }

            string contentDic = JsonMapper.ToJson(dicLanguage).ToString();
            System.IO.File.WriteAllText("language.json", contentDic);
        }

        private List<string> HandlerKeyLanguage(int type, int IdGr)
        {
            List<string> lstemp = new List<string>();
            if (type == 1)
            {
                lstemp.Add("char_" + IdGr + "_name");
                lstemp.Add("char_" + IdGr + "_desc");
            }
            else if (type == 2)
            {
                lstemp.Add("skill_" + IdGr + "_name");
                lstemp.Add("skill_" + IdGr + "_desc");
            }
            else if (type == 3)
            {
                lstemp.Add("duyenphan_" + IdGr + "_name");
            }
            else if (type == 4)
            {
                lstemp.Add("item_" + IdGr + "_name");
                lstemp.Add("item_" + IdGr + "_desc");
            }
            else if (type == 5)
            {
                lstemp.Add("equipment_" + IdGr + "_name");
                lstemp.Add("equipment_" + IdGr + "_desc");
            }
            else if (type == 6)
            {
                lstemp.Add("map_" + IdGr + "_name");
            }
            else if (type == 7)
            {
                lstemp.Add("stage_" + IdGr + "_name");
                lstemp.Add("stage_" + IdGr + "_desc");
            }
            else if (type == 8)
            {
                lstemp.Add("powerup_" + IdGr + "_name");
                lstemp.Add("powerup_" + IdGr + "_desc");
            }
            else if (type == 9)
            {
                lstemp.Add("nhiemvuhangngay_" + IdGr + "_name");
                lstemp.Add("nhiemvuhangngay_" + IdGr + "_desc");
            }
            else if (type == 10)
            {
                lstemp.Add("nhiemvuchinhtuyen_" + IdGr + "_name");
                lstemp.Add("nhiemvuchinhtuyen_" + IdGr + "_desc");
            }
            else if (type == 11)
            {
                lstemp.Add("nhiemvubang_" + IdGr + "_name");
            }
            return lstemp;
        }

        private bool HandlerTrueorFalse(int num)
        {
            if (num == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
