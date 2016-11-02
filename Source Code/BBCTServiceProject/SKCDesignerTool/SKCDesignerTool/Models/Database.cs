using StaticDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHDesignerTool.Models
{
    public class Database
    {
        kdqhdesignertoolv1Entities cs = new kdqhdesignertoolv1Entities();
        public List<dbPowerUpItem> lsdbPowerUpItem = new List<dbPowerUpItem>();
        public List<dbPowerUpItemsAttribute> lsdbPowerUpItemsAttribute = new List<dbPowerUpItemsAttribute>();
        public List<dbCharacter> lsdbCharacter = new List<dbCharacter>();
        public List<dbCharAttribute> lsdbCharAttribute = new List<dbCharAttribute>();
        public List<dbCharDuyenPhan> lsdbCharDuyenPhan = new List<dbCharDuyenPhan>();
        public List<dbCharDuyenPhanAttribute> lsdbCharDuyenPhanAttribute = new List<dbCharDuyenPhanAttribute>();
        public List<dbCharDuyenPhanID> lsdbCharDuyenPhanID = new List<dbCharDuyenPhanID>();
        public List<dbCharSkill> lsdbCharSkill = new List<dbCharSkill>();
        public List<dbCharSkillAfflictionAttribute> lsdbCharSkillAfflictionAttribute = new List<dbCharSkillAfflictionAttribute>();
        public List<dbCharSkillAttribute> lsdbCharSkillAttribute = new List<dbCharSkillAttribute>();
        public List<dbCharPowerUpReceipt> lsdbCharPowerUpReceipt = new List<dbCharPowerUpReceipt>();
        public List<dbCharDetailPowerUpReceipt> lsdbCharDetailPowerUpReceipt = new List<dbCharDetailPowerUpReceipt>();
        public List<dbEquipmentReceipt> lsdbEquipmentReceipt = new List<dbEquipmentReceipt>();
        public List<dbEquipmentAttribute> lsdbEquipmentAttribute = new List<dbEquipmentAttribute>();
        public List<dbItem> lsdbItem = new List<dbItem>();
        public List<dbItemAttribute> lsdbItemAttribute = new List<dbItemAttribute>();
        public List<dbEquipment> lsdbEquipment = new List<dbEquipment>();
        public List<dbEquipmentStarUp> lsdbEquipmentStarUp = new List<dbEquipmentStarUp>();
        public List<dbStarReward> lsdbStarReward = new List<dbStarReward>();
        public List<dbStarRewardReward> lsdbStarRewardReward = new List<dbStarRewardReward>();
        public List<dbMap> lsdbMap = new List<dbMap>();
        public List<dbMapStage> lsdbMapStage = new List<dbMapStage>();
        public List<dbMapStagePath> lsdbMapStagePath = new List<dbMapStagePath>();
        public List<dbMapStageReward> lsdbMapStageReward = new List<dbMapStageReward>();
        public List<dbMapStageMonter> lsdbMapStageMonter = new List<dbMapStageMonter>();
        public List<dbMapStageMonterSupper> lsdbMapStageMonterSupper = new List<dbMapStageMonterSupper>();
        public List<dbMapStageSupper> lsdbMapStageSupper = new List<dbMapStageSupper>();
        public List<dbBattlePoint2ArrayConfig> lsdbBattlePoint2ArrayConfig = new List<dbBattlePoint2ArrayConfig>();
        public List<dbBattlePoint2Config> lsdbBattlePoint2Config = new List<dbBattlePoint2Config>();
        public List<dbNhiemVuHangNgay> lsdbNhiemVuHangNgay = new List<dbNhiemVuHangNgay>();
        public List<dbNhiemVuHangNgayReward> lsdbNhiemVuHangNgayReward = new List<dbNhiemVuHangNgayReward>();
        public List<dbEquipStarUpConfig> lsdbEquipStarUpConfig = new List<dbEquipStarUpConfig>();
        public List<dbEquipStarUpDetail> lsdbEquipStarUpDetail = new List<dbEquipStarUpDetail>();
        public List<dbThanThapMonster> lsdbThanThapMonster = new List<dbThanThapMonster>();
        public List<dbThanThapDetailMonster> lsdbThanThapDetailMonster = new List<dbThanThapDetailMonster>();
        public List<dbCauCaConfig> lsdbCauCaConfig = new List<dbCauCaConfig>();
        public List<dbCauCaReward> lsdbCauCaReward = new List<dbCauCaReward>();
        public List<dbInviteFriendConfig> lsdbInviteFriendConfigs = new List<dbInviteFriendConfig>();
        public List<dbInviteFriendReward> lsdbInviteFriendRewards = new List<dbInviteFriendReward>();

        public Database()
        {
            /////
            var tmpdbInviteFriendRewards = from tmp in cs.dbInviteFriendRewards
                                           where tmp.status == 1
                                           select tmp;

            foreach (var item in tmpdbInviteFriendRewards)
            {
                dbInviteFriendReward conf = new dbInviteFriendReward()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    id = item.id,
                    idInvite = item.idInvite,
                    procs = item.procs,
                    staticID = item.staticID,
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsdbInviteFriendRewards.Add(conf);
            }

            /////
            var tmpdbInviteFriendConfigs = from tmp in cs.dbInviteFriendConfigs
                                           where tmp.status == 1
                                           select tmp;

            foreach (var item in tmpdbInviteFriendConfigs)
            {
                dbInviteFriendConfig conf = new dbInviteFriendConfig()
                {
                    id = item.id,
                    require = item.require,
                    status = item.status
                };
                lsdbInviteFriendConfigs.Add(conf);
            }

            /////
            var tmpdbCauCaReward = from tmp in cs.dbCauCaRewards
                                   where tmp.status == 1
                                   select tmp;

            foreach (var item in tmpdbCauCaReward)
            {
                dbCauCaReward db = new dbCauCaReward()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    id = item.id,
                    idCauca = item.idCauca,
                    procs = item.procs,
                    staticID = item.staticID,
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsdbCauCaReward.Add(db);
            }

            /////////////
            var tmpdbCauCaConfig = from tmp in cs.dbCauCaConfigs
                                   where tmp.status == 1
                                   select tmp;

            foreach (var item in tmpdbCauCaConfig)
            {
                dbCauCaConfig db = new dbCauCaConfig()
                {
                    duration = item.duration,
                    gold = item.gold,
                    id = item.id,
                    idConfig = item.idConfig,
                    name = item.name,
                    silver = item.silver,
                    status = item.status,
                    vipRequire = item.vipRequire
                };
                lsdbCauCaConfig.Add(db);
            }

            ////////
            var tmpdbThanThapDetailMonster = from tmp in cs.dbThanThapDetailMonsters
                                             where tmp.status == 1
                                             select tmp;

            foreach (var item in tmpdbThanThapDetailMonster)
            {
                dbThanThapDetailMonster db = new dbThanThapDetailMonster()
                {
                    col = item.col,
                    id = item.id,
                    idMonter = item.idMonter,
                    idThanThapMonter = item.idThanThapMonter,
                    levelPower = item.levelPower,
                    levels = item.levels,
                    row = item.row,
                    star = item.star,
                    status = item.status
                };
                lsdbThanThapDetailMonster.Add(db);
            }

            ///////////
            var tmpdbThanThapMonster = from tmp in cs.dbThanThapMonsters
                                       where tmp.status == 1
                                       select tmp;

            foreach (var item in tmpdbThanThapMonster)
            {
                dbThanThapMonster db = new dbThanThapMonster()
                {
                    id = item.id,
                    idThanThap = item.idThanThap,
                    status = item.status
                };
                lsdbThanThapMonster.Add(db);
            }

            ////////////
            var tmpdbEquipStarUpDetail = from tmp in cs.dbEquipStarUpDetails
                                         where tmp.status == 1
                                         select tmp;

            foreach (var item in tmpdbEquipStarUpDetail)
            {
                dbEquipStarUpDetail db = new dbEquipStarUpDetail()
                {
                    id = item.id,
                    idStarUp = item.idStarUp,
                    status = item.status,
                    value = item.value
                };
                lsdbEquipStarUpDetail.Add(db);
            }

            ///////////
            var tmpdbEquipStarUpConfig = from tmp in cs.dbEquipStarUpConfigs
                                         where tmp.status == 1
                                         select tmp;

            foreach (var item in tmpdbEquipStarUpConfig)
            {
                dbEquipStarUpConfig db = new dbEquipStarUpConfig()
                {
                    id = item.id,
                    idEquipmentConfig = item.idEquipmentConfig,
                    status = item.status,
                    value = item.value,
                    promotion = item.promotion,
                    equipStockStar = item.equipStockStar
                };
                lsdbEquipStarUpConfig.Add(db);
            }

            ///////////
            var tmpdbNhiemVuHangNgayReward = from tmp in cs.dbNhiemVuHangNgayRewards
                                             where tmp.status == 1
                                             select tmp;

            foreach (var item in tmpdbNhiemVuHangNgayReward)
            {
                dbNhiemVuHangNgayReward db = new dbNhiemVuHangNgayReward()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    id = item.id,
                    idNhiemVu = item.idNhiemVu,
                    procs = item.procs,
                    staticID = item.staticID,
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsdbNhiemVuHangNgayReward.Add(db);
            }

            //////////
            var tmpdbNhiemVuHangNgay = from tmp in cs.dbNhiemVuHangNgays
                                       where tmp.status == 1
                                       select tmp;

            foreach (var item in tmpdbNhiemVuHangNgay)
            {
                dbNhiemVuHangNgay db = new dbNhiemVuHangNgay()
                {
                    des = item.des,
                    id = item.id,
                    idChinhTuyen = item.idChinhTuyen,
                    name = item.name,
                    quantity = item.quantity,
                    status = item.status,
                    types = item.types
                };
                lsdbNhiemVuHangNgay.Add(db);
            }

            ///////////
            var tmpdbBattlePoint2Config = from tmp in cs.dbBattlePoint2Config
                                          where tmp.status == 1
                                          select tmp;

            foreach (var item in tmpdbBattlePoint2Config)
            {
                dbBattlePoint2Config db = new dbBattlePoint2Config()
                {
                    id = item.id,
                    idPoint2Array = item.idPoint2Array,
                    status = item.status,
                    x = item.x,
                    y = item.y
                };
                lsdbBattlePoint2Config.Add(db);
            }

            /////////////
            var tmpdbBattlePoint2ArrayConfig = from tmp in cs.dbBattlePoint2ArrayConfig
                                               where tmp.status == 1
                                               select tmp;

            foreach (var item in tmpdbBattlePoint2ArrayConfig)
            {
                dbBattlePoint2ArrayConfig db = new dbBattlePoint2ArrayConfig()
                {
                    id = item.id,
                    status = item.status
                };
                lsdbBattlePoint2ArrayConfig.Add(db);
            }

            /////////////
            var tmpdbStarRewardReward = from tmp in cs.dbStarRewardRewards
                                        where tmp.status == 1
                                        select tmp;

            foreach (var item in tmpdbStarRewardReward)
            {
                dbStarRewardReward db = new dbStarRewardReward()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    id = item.id,
                    idStar = item.idStar,
                    procs = item.procs,
                    staticID = item.staticID,
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsdbStarRewardReward.Add(db);
            }

            ///////////////
            var tmpdbStarReward = from tmp in cs.dbStarRewards
                                  where tmp.status == 1
                                  select tmp;

            foreach (var item in tmpdbStarReward)
            {
                dbStarReward db = new dbStarReward()
                {
                    id = item.id,
                    starRequire = item.starRequire,
                    status = item.status
                };
                lsdbStarReward.Add(db);
            }

            //////////////////
            var tmpdbEquipmentStarUp = from tmp in cs.dbEquipmentStarUps
                                       where tmp.status == 1
                                       select tmp;

            foreach (var item in tmpdbEquipmentStarUp)
            {
                dbEquipmentStarUp db = new dbEquipmentStarUp()
                {
                    id = item.id,
                    idEquipment = item.idEquipment,
                    status = item.status,
                    value = item.value
                };
                lsdbEquipmentStarUp.Add(db);
            }

            ///////////////
            var tmpdbEquipment = from tmp in cs.dbEquipments
                                 where tmp.status == 1
                                 select tmp;

            foreach (var item in tmpdbEquipment)
            {
                dbEquipment db = new dbEquipment()
                {
                    baseMarketPrice = item.baseMarketPrice,
                    canSellMarket = item.canSellMarket,
                    category = item.category,
                    descriptions = item.descriptions,
                    icon = item.icon,
                    id = item.id,
                    idEquipment = item.idEquipment,
                    name = item.name,
                    promotion = item.promotion,
                    status = item.status
                };
                lsdbEquipment.Add(db);
            }

            /////////////////
            var tmpdbItemAttribute = from tmp in cs.dbItemAttributes
                                     where tmp.status == 1
                                     select tmp;

            foreach (var item in tmpdbItemAttribute)
            {
                dbItemAttribute db = new dbItemAttribute()
                {
                    id = item.id,
                    idItem = item.idItem,
                    status = item.status,
                    value = item.value
                };
                lsdbItemAttribute.Add(db);
            }

            //////////////////
            var tmpdbItem = from tmp in cs.dbItems
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpdbItem)
            {
                dbItem db = new dbItem()
                {
                    border = item.border,
                    descriptions = item.descriptions,
                    id = item.id,
                    idItem = item.idItem,
                    name = item.name,
                    sellPrice = item.sellPrice,
                    status = item.status,
                    types = item.types
                };
                lsdbItem.Add(db);
            }

            ////////////////
            var tmpdbEquipmentAttribute = from tmp in cs.dbEquipmentAttributes
                                          where tmp.status == 1
                                          select tmp;

            foreach (var item in tmpdbEquipmentAttribute)
            {
                dbEquipmentAttribute db = new dbEquipmentAttribute()
                {
                    attribute = item.attribute,
                    growthMod = item.growthMod,
                    id = item.id,
                    idEquipment = item.idEquipment,
                    mods = item.mods,
                    status = item.status
                };
                lsdbEquipmentAttribute.Add(db);
            }

            ///////////
            var tmpdbEquipmentReceipt = from tmp in cs.dbEquipmentReceipts
                                        where tmp.status == 1
                                        select tmp;

            foreach (var item in tmpdbEquipmentReceipt)
            {
                dbEquipmentReceipt db = new dbEquipmentReceipt()
                {
                    amount = item.amount,
                    id = item.id,
                    idItem = item.idItem,
                    idStarUp = item.idStarUp,
                    status = item.status
                };
                lsdbEquipmentReceipt.Add(db);
            }

            //////////////////
            var tmpdbCharDetailPowerUpReceipt = from tmp in cs.dbCharDetailPowerUpReceipts
                                                where tmp.status == 1
                                                select tmp;

            foreach (var item in tmpdbCharDetailPowerUpReceipt)
            {
                dbCharDetailPowerUpReceipt db = new dbCharDetailPowerUpReceipt()
                {
                    amount = item.amount,
                    id = item.id,
                    idItem = item.idItem,
                    idReceipt = item.idReceipt,
                    status = item.status
                };
                lsdbCharDetailPowerUpReceipt.Add(db);
            }

            /////////////
            var tmpdbCharPowerUpReceipt = from tmp in cs.dbCharPowerUpReceipts
                                          where tmp.status == 1
                                          select tmp;

            foreach (var item in tmpdbCharPowerUpReceipt)
            {
                dbCharPowerUpReceipt db = new dbCharPowerUpReceipt()
                {
                    gen = item.gen,
                    id = item.id,
                    idCharacter = item.idCharacter,
                    status = item.status
                };
                lsdbCharPowerUpReceipt.Add(db);
            }


            /////////////////
            var tmpdbCharSkillAttribute = from tmp in cs.dbCharSkillAttributes
                                          where tmp.status == 1
                                          select tmp;

            foreach (var item in tmpdbCharSkillAttribute)
            {
                dbCharSkillAttribute db = new dbCharSkillAttribute()
                {
                    attribute = item.attribute,
                    growthMod = item.growthMod,
                    id = item.id,
                    idSkill = item.idSkill,
                    mods = item.mods,
                    status = item.status
                };
                lsdbCharSkillAttribute.Add(db);
            }

            ///////
            var tmpdbCharSkillAfflictionAttribute = from tmp in cs.dbCharSkillAfflictionAttributes
                                                    where tmp.status == 1
                                                    select tmp;

            foreach (var item in tmpdbCharSkillAfflictionAttribute)
            {
                dbCharSkillAfflictionAttribute db = new dbCharSkillAfflictionAttribute()
                {
                    attribute = item.attribute,
                    growthMod = item.growthMod,
                    id = item.id,
                    idSkill = item.idSkill,
                    mods = item.mods,
                    status = item.status
                };
                lsdbCharSkillAfflictionAttribute.Add(db);
            }

            //////////////////////
            var tmpdbCharSkill = from tmp in cs.dbCharSkills
                                 where tmp.status == 1
                                 select tmp;

            foreach (var item in tmpdbCharSkill)
            {
                dbCharSkill db = new dbCharSkill()
                {
                    afflictionDuration = item.afflictionDuration,
                    afflictionProc = item.afflictionProc,
                    afflictionSkill = item.afflictionSkill,
                    category = item.category,
                    cooldown = item.cooldown,
                    countTurn = item.countTurn,
                    descriptions = item.descriptions,
                    effect = item.effect,
                    id = item.id,
                    idCharacter = item.idCharacter,
                    manaCost = item.manaCost,
                    name = item.name,
                    orders = item.orders,
                    ranges = item.ranges,
                    slot = item.slot,
                    status = item.status,
                    targets = item.targets,
                    types = item.types,
                    typeSpawnSkill = item.typeSpawnSkill
                };
                lsdbCharSkill.Add(db);
            }

            /////////
            var tmpdbCharDuyenPhanID = from tmp in cs.dbCharDuyenPhanIDS
                                       where tmp.status == 1
                                       select tmp;

            foreach (var item in tmpdbCharDuyenPhanID)
            {
                dbCharDuyenPhanID db = new dbCharDuyenPhanID()
                {
                    id = item.id,
                    idDuyen = item.idDuyen,
                    status = item.status,
                    value = item.value
                };
                lsdbCharDuyenPhanID.Add(db);
            }

            //////////
            var tmpdbCharDuyenPhanAttribute = from tmp in cs.dbCharDuyenPhanAttributes
                                              where tmp.status == 1
                                              select tmp;

            foreach (var item in tmpdbCharDuyenPhanAttribute)
            {
                dbCharDuyenPhanAttribute db = new dbCharDuyenPhanAttribute()
                {
                    attribute = item.attribute,
                    growthMod = item.growthMod,
                    id = item.id,
                    idDuyen = item.idDuyen,
                    status = item.status,
                    value = item.value
                };
                lsdbCharDuyenPhanAttribute.Add(db);
            }

            ///////////////
            var tmpdbCharDuyenPhan = from tmp in cs.dbCharDuyenPhans
                                     where tmp.status == 1
                                     select tmp;

            foreach (var item in tmpdbCharDuyenPhan)
            {
                dbCharDuyenPhan db = new dbCharDuyenPhan()
                {
                    category = item.category,
                    id = item.id,
                    idCharacter = item.idCharacter,
                    isOne = item.isOne,
                    name = item.name,
                    status = item.status
                };
                lsdbCharDuyenPhan.Add(db);
            }

            //////////////////////
            var tmpdbCharAttribute = from tmp in cs.dbCharAttributes
                                     where tmp.status == 1
                                     select tmp;

            foreach (var item in tmpdbCharAttribute)
            {
                dbCharAttribute db = new dbCharAttribute()
                {
                    attribute = item.attribute,
                    growthMod = item.growthMod,
                    id = item.id,
                    idCharacter = item.idCharacter,
                    mods = item.mods,
                    status = item.status
                };
                lsdbCharAttribute.Add(db);
            }

            ////////////////////////
            var tmpCharacter = from tmp in cs.dbCharacters
                               where tmp.status == 1
                               select tmp;

            foreach (var item in tmpCharacter)
            {
                dbCharacter db = new dbCharacter()
                {
                    amountPieceToImport = item.amountPieceToImport,
                    category = item.category,
                    classCharacter = item.classCharacter,
                    descriptions = item.descriptions,
                    id = item.id,
                    idCharacter = item.idCharacter,
                    isCreep = item.isCreep,
                    isMain = item.isMain,
                    name = item.name,
                    orders = item.orders,
                    promotion = item.promotion,
                    status = item.status,
                    idCharHuaNguyen = item.idCharHuaNguyen
                };
                lsdbCharacter.Add(db);
            }

            /////////////////////
            var tmpdbPowerUpItem = from tmp in cs.dbPowerUpItems
                                   where tmp.status == 1
                                   select tmp;

            foreach (var item in tmpdbPowerUpItem)
            {
                dbPowerUpItem db = new dbPowerUpItem()
                {
                    description = item.description,
                    id = item.id,
                    idPowerUpItems = item.idPowerUpItems,
                    levelRequire = item.levelRequire,
                    name = item.name,
                    promotion = item.promotion,
                    status = item.status
                };
                lsdbPowerUpItem.Add(db);
            }

            //////////////////////
            var tmpdbPowerUpItemsAttribute = from tmp in cs.dbPowerUpItemsAttributes
                                             where tmp.status == 1
                                             select tmp;

            foreach (var item in tmpdbPowerUpItemsAttribute)
            {
                dbPowerUpItemsAttribute db = new dbPowerUpItemsAttribute()
                {
                    attribute = item.attribute,
                    growthMod = item.growthMod,
                    id = item.id,
                    idPowerUpItems = item.idPowerUpItems,
                    mods = item.mods,
                    status = item.status
                };
                lsdbPowerUpItemsAttribute.Add(db);
            }
        }

        public void HandlerMap()
        {
            ///////////////////
            var tmpdbMapStageSupper = from tmp in cs.dbMapStageSuppers
                                      where tmp.status == 1
                                      select tmp;

            foreach (var item in tmpdbMapStageSupper)
            {
                dbMapStageSupper db = new dbMapStageSupper()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    id = item.id,
                    idStage = item.idStage,
                    procs = item.procs,
                    staticID = item.staticID,
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsdbMapStageSupper.Add(db);
            }

            //////////////////
            var tmpdbMapStageMonterSupper = from tmp in cs.dbMapStageMonterSuppers
                                            where tmp.status == 1
                                            select tmp;

            foreach (var item in tmpdbMapStageMonterSupper)
            {
                dbMapStageMonterSupper db = new dbMapStageMonterSupper()
                {
                    col = item.col,
                    id = item.id,
                    idMonter = item.idMonter,
                    idStage = item.idStage,
                    levelPower = item.levelPower,
                    levels = item.levels,
                    row = item.row,
                    star = item.star,
                    status = item.status
                };
                lsdbMapStageMonterSupper.Add(db);
            }

            /////////////
            var tmpdbMapStageMonter = from tmp in cs.dbMapStageMonters
                                      where tmp.status == 1
                                      select tmp;

            foreach (var item in tmpdbMapStageMonter)
            {
                dbMapStageMonter db = new dbMapStageMonter()
                {
                    col = item.col,
                    id = item.id,
                    idMonter = item.idMonter,
                    idStage = item.idStage,
                    levelPower = item.levelPower,
                    levels = item.levels,
                    row = item.row,
                    star = item.star,
                    status = item.status
                };
                lsdbMapStageMonter.Add(db);
            }

            ///////////
            var tmpdbMapStageReward = from tmp in cs.dbMapStageRewards
                                      where tmp.status == 1
                                      select tmp;

            foreach (var item in tmpdbMapStageReward)
            {
                dbMapStageReward db = new dbMapStageReward()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    id = item.id,
                    idStage = item.idStage,
                    procs = item.procs,
                    staticID = item.staticID,
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsdbMapStageReward.Add(db);
            }

            ////////////
            var tmpdbMapStagePath = from tmp in cs.dbMapStagePaths
                                    where tmp.status == 1
                                    select tmp;

            foreach (var item in tmpdbMapStagePath)
            {
                dbMapStagePath db = new dbMapStagePath()
                {
                    id = item.id,
                    idStage = item.idStage,
                    positionX = item.positionX,
                    positionY = item.positionY,
                    status = item.status
                };
                lsdbMapStagePath.Add(db);
            }

            ////////////
            var tmpdbMapStage = from tmp in cs.dbMapStages
                                where tmp.status == 1
                                select tmp;

            foreach (var item in tmpdbMapStage)
            {
                dbMapStage db = new dbMapStage()
                {
                    background = item.background,
                    descriptions = item.descriptions,
                    expPlayer = item.expPlayer,
                    expRewardMax = item.expRewardMax,
                    expRewardMin = item.expRewardMin,
                    id = item.id,
                    idMap = item.idMap,
                    maxAttack = item.maxAttack,
                    name = item.name,
                    positionX = item.positionX,
                    positionY = item.positionY,
                    silverRewardMax = item.silverRewardMax,
                    silverRewardMin = item.silverRewardMin,
                    stamina = item.stamina,
                    status = item.status,
                    totalPower = item.totalPower,
                    typeStage = item.typeStage
                };
                lsdbMapStage.Add(db);
            }

            ////////
            var tmpdbMap = from tmp in cs.dbMaps
                           where tmp.status == 1
                           select tmp;

            foreach (var item in tmpdbMap)
            {
                dbMap db = new dbMap()
                {
                    background = item.background,
                    id = item.id,
                    name = item.name,
                    isAuto = item.isAuto,
                    status = item.status
                };
                lsdbMap.Add(db);
            }
        }
    }
}
