using DynamicDBModel.Enum;
using DynamicDBModel.Models;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.GlobalInfo;
using GameServer.Quartz;
using GameServer.Server;
using GameServer.ServerWebClient;
using MongoDBModel.MainDatabaseModels;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using StaticDB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameServer.Common
{
    public class CommonFunc
    {

        private static readonly Random random = new Random();

        public static string GetUsername(string token)
        {
            string data = EncryptLiblary.CryptLib.Instance.AesDecrypt(token);
            //CommonLog.Instance.PrintLog("data: " + data);
            string[] split = data.Split('-');
            string username = split[0];
            //CommonLog.Instance.PrintLog("split[0]: " + split[0]);
            return username;
        }


        public static DateTime GetNextDay()
        {
            return DateTime.Today.AddDays(1);
        }

        public static int GetHashCodeTime()
        {
            return DateTime.Today.GetHashCode();
        }

        public static int GetPrevHashCodeTime()
        {
            return DateTime.Today.AddDays(-1).GetHashCode();
        }

        public static double CalculateSecondTimeSpand(int stepMinutes, DateTime lastTimeFree)
        {
            DateTime timeFree = lastTimeFree.AddMinutes(stepMinutes);
            double resetFreeTime = timeFree < DateTime.Now ? 0 : (timeFree - DateTime.Now).TotalSeconds;
            return resetFreeTime;
        }

        public static void Shuffle<T>(List<T> listData)
        {
            int n = listData.Count;
            for (int i = 0; i < n; i++)
            {
                int r = i + (int)(random.NextDouble() * (n - i));
                T t = listData[r];
                listData[r] = listData[i];
                listData[i] = t;
            }
        }

        public static void Shuffle<T>(T[] arrayData)
        {
            int n = arrayData.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + (int)(random.NextDouble() * (n - i));
                T t = arrayData[r];
                arrayData[r] = arrayData[i];
                arrayData[i] = t;
            }
        }

        public static StringArray[] ConvertToStringArray(MStringArray[] stringArray)
        {
            StringArray[] resultArray = new StringArray[stringArray.Length];

            for (int i = 0; i < stringArray.Length; i++)
            {
                resultArray[i] = new StringArray();
                resultArray[i].columns = new string[stringArray[0].columns.Length];

                for (int j = 0; j < stringArray[0].columns.Length; j++)
                {
                    resultArray[i].columns[j] = stringArray[i].columns[j];

                }
            }
            return resultArray;
        }

        public static MStringArray[] ConvertToMStringArray(StringArray[] stringArray)
        {
            MStringArray[] resultArray = new MStringArray[stringArray.Length];

            for (int i = 0; i < stringArray.Length; i++)
            {
                resultArray[i] = new MStringArray();
                resultArray[i].columns = new string[stringArray[0].columns.Length];

                for (int j = 0; j < stringArray[0].columns.Length; j++)
                {
                    resultArray[i].columns[j] = stringArray[i].columns[j];

                }
            }
            return resultArray;
        }

        public static OperationResponse SimpleResponse(OperationRequest operationRequest, ReturnCode code)
        {
            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "",
                Parameters = new Dictionary<byte, object>(),
                ReturnCode = (short)code
            };
        }

        //public static string Getstring(string id)
        //{
        //    return new string(id);
        //}



        public static double RandomNumberDouble(int min, int max)
        {
            if (max != 1)
            {
                int number = random.Next(min, max);
                double plusDouble = number + random.NextDouble();
                return plusDouble;
            }
            else
            {
                return random.NextDouble();
            }
        }

        public static double RandomNumberDouble()
        {
            return random.NextDouble();
        }

        public static int RandomNumber(int min, int max)
        {
            int number = random.Next(min, max);
            return number;
        }

        public static float RandomNumber(float min, float max)
        {
            if (min > max)
                return 0;

            double numberRandom = random.NextDouble() * (max - min) + min;

            return float.Parse(Math.Round(numberRandom, 3).ToString());
        }

        public static int GetMaxLevelCharacter(int levelPlayer)
        {
            int maxLevel = StaticDatabase.entities.configs.characterLevelExps.Max(a => a.level);

            if (levelPlayer < maxLevel)
            {
                return levelPlayer;
            }
            else
            {
                return maxLevel;
            }
        }

        public static int RandomNumber(int min, int max, int ignor)
        {
            //Random random = new Random();
            int number = random.Next(min, max);
            while (number >= ignor)
            {
                number = random.Next(min, max);
            }
            return number;
        }

        public static double RandomNumber()
        {
            return random.NextDouble();
        }

        public static List<UserEquip> GetUserEquips(List<MUserEquip> userEquips)
        {
            var result = from a in userEquips
                         select new UserEquip
                         {
                             _id = a._id.ToString(),
                             equip_id = a.static_id,
                             powerup_level = a.powerup_level,
                             star_level = a.star_level,
                             element = a.element,
                             bonusAttribute = a.bonus_attribute,
                             bonusAttributeMod = a.bonus_attribute_mod,
                             bonusAttributeGrowMod = a.bonus_attribute_grow_mod,
                             char_equip = a.char_equip,
                         };
            return result.ToList();
        }

        public static List<UserItem> GetUserItem(List<MUserItem> listUserItem)
        {
            var result = listUserItem.Where(a => a.quantity > 0).Select(a => new UserItem()
            {
                static_id = a.static_id,
                quantity = a.quantity,
                rewards = a.rewards,
                _id = a._id.ToString()
            }).ToList();
            return result;
        }

        public static string ReadFile(string fileName)
        {
            string dataResult = "";
            try
            {
                var readStream = new FileStream(fileName, FileMode.Open);
                StreamReader reader = new StreamReader(readStream);
                dataResult = reader.ReadToEnd();
                readStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return dataResult;
        }

        public static List<UserCharacter> GetUserChars(List<MUserCharacter> userCharacters)
        {
            var result = from a in userCharacters
                         select new UserCharacter
                         {
                             _id = a._id.ToString(),
                             char_id = a.static_id,
                             level = a.level,
                             exp = a.exp,
                             powerup_level = a.powerup_level,
                             star_level = a.star_level,
                             active_skills = a.active_skills,
                             passive_skills = a.passive_skills,
                             equipments = a.equipments,
                         };
            return result.ToList();
        }

        public static List<SubRewardItem> RandomSubRewardItem(Reward[] arrReward)
        {
            List<SubRewardItem> listRealReward = new List<SubRewardItem>();
            if (arrReward == null || arrReward.Length == 0)
                return listRealReward;
            foreach (var reward in arrReward)
            {
                SubRewardItem subRewardItem = new SubRewardItem();

                double procRandom = RandomNumberDouble(0, 100);

                if (procRandom > reward.proc)
                    continue;

                subRewardItem.quantity = reward.amountMax == reward.amountMin
                    ? reward.amountMax
                    : RandomNumber(reward.amountMin, reward.amountMax);
                subRewardItem.static_id = reward.staticID;
                subRewardItem.type_reward = reward.typeReward;
                listRealReward.Add(subRewardItem);
            }
            return listRealReward;
        }

        public static SubRewardItem RandomOneSubRewardItem(IEnumerable<Reward> arrReward)
        {
            double totalProc = arrReward.Sum(a => a.proc);

            double randomProc = RandomNumberDouble(0, Convert.ToInt32(totalProc));
            if (randomProc > totalProc)
                randomProc = totalProc;

            double currentProc = 0;
            Reward rewardSelect = null;
            foreach (var currentReward in arrReward)
            {
                currentProc += currentReward.proc;
                if (currentProc < randomProc)
                    continue;
                rewardSelect = currentReward;
                break;
            }

            SubRewardItem resultReward = new SubRewardItem()
            {
                static_id = rewardSelect.staticID,
                quantity = rewardSelect.amountMax == rewardSelect.amountMin
                    ? rewardSelect.amountMax : RandomNumber(rewardSelect.amountMin, rewardSelect.amountMax),
                type_reward = rewardSelect.typeReward
            };

            return resultReward;
        }

        public static SubRewardItem RandomOneSubRewardItem(MVatPham[] arrReward)
        {
            double totalProc = arrReward.Sum(a => a.proc);

            double randomProc = RandomNumberDouble(0, Convert.ToInt32(totalProc));
            if (randomProc > totalProc)
                randomProc = totalProc;

            double currentProc = 0;
            MVatPham rewardSelect = null;
            foreach (var currentReward in arrReward)
            {
                currentProc += currentReward.proc;
                if (currentProc < randomProc)
                    continue;
                rewardSelect = currentReward;
                break;
            }

            SubRewardItem resultReward = new SubRewardItem()
            {
                static_id = rewardSelect.static_id,
                quantity = rewardSelect.quantity,
                type_reward = (int)rewardSelect.type
            };

            return resultReward;
        }

        public static void UpLevelPlayer(PlayerCacheData userInfo, double exp)
        {
            try
            {
                int levelPlayer = userInfo.level;
                if (levelPlayer > StaticDatabase.entities.configs.playerLevelExps.Length)
                    return;
                PlayerLevelExp playerLevelExp = StaticDatabase.entities.configs.playerLevelExps[levelPlayer - 1];
                if ((userInfo.exp + exp) < playerLevelExp.exp)
                {
                    userInfo.exp = (int)(userInfo.exp + exp);
                    return;
                }

                if (userInfo.level + 1 > StaticDatabase.entities.configs.playerLevelExps.Length)
                {
                    userInfo.exp = playerLevelExp.exp;
                    return;
                }

                double balancesExp = userInfo.exp + exp - playerLevelExp.exp;
                userInfo.level++;
                userInfo.exp = 0;
                if (balancesExp > 0)
                {
                    UpLevelPlayer(userInfo, balancesExp);
                }
            }
            catch (Exception)
            {
                CommonLog.Instance.PrintLog("error level: " + userInfo.level);
            }

        }

        public static List<CharBattleResult> UpCharAfterBattle(PlayerCacheData cachdeData, int exp, int maxLevel)
        {
            List<CharBattleResult> listChar = new List<CharBattleResult>();
            List<MUserCharacter> listUserChar = cachdeData.listUserChar;
            listChar.AddRange(UpLevelCharInArray(listUserChar, cachdeData.formation, exp, maxLevel));
            return listChar;
        }

        private static List<CharBattleResult> UpLevelCharInArray(List<MUserCharacter> listUserChar, StringArray[] formationRows, int exp, int maxLevel)
        {
            List<CharBattleResult> listChar = new List<CharBattleResult>();
            foreach (var colums in formationRows)
            {
                foreach (var idChar in colums.columns)
                {
                    if (idChar.Equals("-1"))
                        continue;

                    MUserCharacter userChar = listUserChar.FirstOrDefault(a => a._id == idChar);
                    if (userChar == null)
                        continue;

                    bool isUpLevel = UpLevelCharacter(userChar, exp, maxLevel, false);


                    CharBattleResult charBattle = new CharBattleResult()
                    {
                        _id = userChar._id.ToString(),
                        char_id = userChar.static_id,
                        exp = userChar.exp,
                        is_up_level = isUpLevel,
                        level = userChar.level
                    };

                    listChar.Add(charBattle);
                }

            }
            return listChar;
        }

        public static bool UpLevelCharacter(MUserCharacter character, double exp, int maxLevel, bool isUpLevel)
        {
            bool uplevel = isUpLevel;
            int levelChar = character.level;
            CharacterLevelExp charLevelExp = StaticDatabase.entities.configs.characterLevelExps.FirstOrDefault(a => a.level == levelChar);

            if (charLevelExp == null)
                return uplevel;

            if ((character.exp + exp) < charLevelExp.exp)
            {
                character.exp = (int)(character.exp + exp);
                return uplevel;
            }

            if (character.level >= maxLevel)
            {
                character.exp = charLevelExp.exp - 1;
                return uplevel;
            }

            double balancesExp = character.exp + exp - charLevelExp.exp;
            character.level++;
            MongoController.LogSubDB.NhiemVuHangNgay.SaveLogNhiemVu(character.user_id, TypeNhiemVuHangNgay.UpLevelChar);
            character.exp = 0;

            if (balancesExp > 0)
            {
                UpLevelCharacter(character, balancesExp, maxLevel, true);
            }
            return uplevel;
        }

        //public static List<RewardItem> ConvertToRewardItems(List<SubRewardItem> listDataReward)
        //{
        //    return
        //    (
        //        from a in listDataReward
        //        select new RewardItem()
        //        {
        //            quantity = a.quantity,
        //            type_reward = a.type_reward,
        //            static_id = a.static_id,
        //            _id = ""
        //        }
        //    ).ToList();
        //}

        public static bool CheckValidTimeToBuyLeBao(TypeLeBaoActivationTime activationType, string start, string end)
        {
            switch (activationType)
            {
                case TypeLeBaoActivationTime.None:
                    return true;

                case TypeLeBaoActivationTime.ActivateDateInWeek:
                    int dayOfWeek = (int)DateTime.Today.DayOfWeek;
                    if (dayOfWeek == int.Parse(start))
                        return true;
                    break;

                case TypeLeBaoActivationTime.ActivateDaysInMonth:
                    int dayInMonth = DateTime.Today.Day;
                    if (dayInMonth >= int.Parse(start) && dayInMonth <= int.Parse(end))
                        return true;
                    break;

                case TypeLeBaoActivationTime.ActivateHoursInDay:
                    int hourInDay = DateTime.Now.Hour;
                    if (hourInDay >= int.Parse(start) && hourInDay <= int.Parse(end))
                        return true;
                    break;

                case TypeLeBaoActivationTime.ActivateInTimeRange:
                    if (DateTime.Now >= DateTime.Parse(start) && DateTime.Now <= DateTime.Parse(end))
                        return true;
                    break;

                default:
                    return false;
            }
            return false;
        }

        public static int GetTimesCanBuyLeBao(MLebao lebao, int vip)
        {
            switch (lebao.buy_times)
            {
                case TypeLeBaoBuyTimes.Manytimes:
                    return lebao.max_buy_times;
                case TypeLeBaoBuyTimes.ManytimesWithVip:
                    return lebao.vip_buy_times[vip];
                case TypeLeBaoBuyTimes.OnlyOne:
                    return 1;
                default:
                    return 0;

            }
        }

        public static List<Reward> ConvertToRewards(List<SubRewardItem> listDataReward)
        {
            return (from a in listDataReward
                    select new Reward()
                    {
                        staticID = a.static_id,
                        proc = 100,
                        typeReward = a.type_reward,
                        amountMax = a.quantity,
                        amountMin = a.quantity
                    }).ToList();
        }

        public static int[] GetRandomMoster()
        {
            int number = StaticDatabase.entities.configs.thanThapConfig.monsters.Count;
            //CommonLog.Instance.PrintLog("StaticDatabase.entities.configs.thanThapConfig.monsters.CoundLogInDay: " + number);
            int[] arrResult = new int[3];
            for (int i = 0; i < 3; i++)
            {
                arrResult[i] = RandomNumber(0, number);
            }
            return arrResult;
        }



        public static double GetInterval(DateTime target)
        {
            return (target - DateTime.Now).TotalMilliseconds;
        }

        public static double GetSecondsRangeTime(DateTime target)
        {
            return (target - DateTime.Now).TotalSeconds;
        }

        public static int[] GetBonusAttributeSelectionThanThap()
        {
            int[] arrAttribute = new int[] { 1, 2, 4, 5 };
            Shuffle(arrAttribute);

            return arrAttribute.Skip(0).Take(3).ToArray();
        }

        public static int GetBonusAttributeIndex(int attribute)
        {
            if (attribute > 3)
                return attribute - 2;
            return attribute - 1;
        }

        public static double GetCoolTimeSecond(DateTime dateTime, double maxCoolTime)
        {
            double totalSecond = (DateTime.Now - dateTime).TotalSeconds;
            return totalSecond > maxCoolTime ? 0 : maxCoolTime - totalSecond;
        }

        public static List<SubRewardItem> ConvertToSubReward(Reward[] listReward)
        {
            return listReward.Select(a => new SubRewardItem()
            {
                static_id = a.staticID,
                quantity = a.amountMax,
                type_reward = a.typeReward,
            }).ToList();
        }

        public static List<SubRewardItem> ConvertToSubReward(List<Reward> listReward)
        {
            return listReward.Select(a => new SubRewardItem()
            {
                static_id = a.staticID,
                quantity = a.amountMax,
                type_reward = a.typeReward,
            }).ToList();
        }



        public static void CreateBotLuanKiem(int number)
        {
            Console.WriteLine("create bot luan kiem");
            List<MUserInfo> listUserInfo = new List<MUserInfo>();
            List<MUserCharacter> listUserChar = new List<MUserCharacter>();
            for (int i = 1; i <= number; i++)
            {

                string username = Guid.NewGuid().ToString();
                MUserInfo newMUserInfo = new MUserInfo()
                {
                    username = username,
                    rank_luan_kiem = i,
                    nickname = "Sửu Nhi " + i,
                    last_time_update_stamina = DateTime.Now,
                    level = 10,
                    isBot = true
                };
                listUserInfo.Add(newMUserInfo);

            }
            MongoController.UserDb.Info.CreateAll(listUserInfo);

            foreach (var userInfo in listUserInfo)
            {
                List<int> listIdCharSelect = new List<int>();
                int numberChar = CommonFunc.RandomNumber(1, 5);
                for (int j = 0; j < numberChar; j++)
                {
                    //int idChar = 1;
                    int idChar = 0;
                    do
                    {
                        idChar = CommonFunc.RandomNumber(1, 13);
                    }
                    while (listIdCharSelect.Any(a => a == idChar));
                    listIdCharSelect.Add(idChar);
                    listUserChar.Add(new MUserCharacter()
                    {
                        user_id = userInfo._id,
                        static_id = idChar

                    });
                }
                userInfo.avatar = listIdCharSelect.Last();
            }

            MongoController.UserDb.Char.CreateAll(listUserChar);

            for (int i = 0; i < number; i++)
            {
                MUserInfo userInfo = listUserInfo[i];
                List<MUserCharacter> listChar = listUserChar.Where(a => a.user_id.Equals(userInfo._id)).ToList();
                userInfo.formation = CreateNewMFormation(listChar.Select(a => a._id.ToString()).ToList());
                MongoController.UserDb.Info.Update(userInfo);
            }
        }

        private static StringArray[] CreateNewMFormation(List<string> listIdChar)
        {
            StringArray[] stringArray = new StringArray[3];

            stringArray[0] = new StringArray();
            stringArray[0].columns = new string[] { "-1", "-1", "-1" };

            stringArray[1] = new StringArray();
            stringArray[1].columns = new string[] { "-1", "-1", "-1" };

            stringArray[2] = new StringArray();
            stringArray[2].columns = new string[] { "-1", "-1", "-1" };


            foreach (var idChar in listIdChar)
            {
                int randomRow = 0;
                int randomColumn = 0;
                do
                {
                    randomRow = CommonFunc.RandomNumber(0, 2);
                    randomColumn = CommonFunc.RandomNumber(0, 2);
                }
                while (stringArray[randomRow].columns[randomColumn] != "-1");
                stringArray[randomRow].columns[randomColumn] = idChar;
            }

            return stringArray;
        }

        public static bool IsPassDay(DateTime timeCompare)
        {
            bool isPass = true;
            if (timeCompare.Year < DateTime.Now.Year)
            {
                isPass = true;
            }
            else if (timeCompare.Year > DateTime.Now.Year)
            {
                isPass = false;
            }
            else if (timeCompare.Year == DateTime.Now.Year)
            {
                if (timeCompare.Month < DateTime.Now.Month)
                {
                    isPass = true;
                }
                else if (timeCompare.Month > DateTime.Now.Month)
                {
                    isPass = false;
                }
                else if (timeCompare.Month == DateTime.Now.Month)
                {
                    if (timeCompare.Day < DateTime.Now.Day)
                    {
                        isPass = true;
                    }
                    else if (timeCompare.Day > DateTime.Now.Day)
                    {
                        isPass = false;
                    }
                    else if (timeCompare.Day == DateTime.Now.Day)
                    {
                        isPass = false;
                    }
                }
            }
            return isPass;
        }

        public static SubRewardItem[] ConvertToSubRewardItem(MVatPham[] vatPhams)
        {
            SubRewardItem[] result = new SubRewardItem[vatPhams.Length];
            int count = 0;
            foreach (var vatPham in vatPhams)
            {
                SubRewardItem reward = new SubRewardItem()
                {
                    static_id = vatPham.static_id,
                    quantity = vatPham.quantity,
                    type_reward = (int)vatPham.type
                };
                result[count] = reward;
                count++;
            }
            return result;
        }

        //public static List<SubRewardItem> RandomIteSubRewardItem(MVatPham[] rewards)
        //{
        //    CommonFunc.Shuffle(rewards);
        //    int totalProc = int.Parse(Math.Round(rewards.Sum(a => a.proc)).ToString());
        //    double number = CommonFunc.RandomNumberDouble(0, totalProc);
        //    double currentProc = 0;
        //    MVatPham vatPhaSubRewardItem = null;
        //    foreach (var reward in rewards)
        //    {
        //        currentProc += reward.proc;
        //        if (currentProc >= number)
        //        {
        //            vatPhaSubRewardItem = reward;
        //            break;
        //        }
        //    }
        //    if (vatPhaSubRewardItem == null)
        //    {
        //        vatPhaSubRewardItem = rewards.Last();
        //    }
        //    return new List<SubRewardItem>()
        //    {
        //        new SubRewardItem()
        //        {
        //           static_id = vatPhaSubRewardItem.static_id,
        //           quantity = vatPhaSubRewardItem.quantity == 0 ? 1 : vatPhaSubRewardItem.quantity,
        //           type_reward = (int)vatPhaSubRewardItem.type
        //        }
        //    };
        //}

        public static DateTime GetStartTimeInDay()
        {
            return new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);
        }

        public static DateTime GetEndTimeInDay()
        {
            return new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 0);
        }

        public static SubRewardItem RandomSubReward()
        {
            TypeReward[] typeIteSubRewardItem = new TypeReward[]
            {
                TypeReward.Item,
                TypeReward.Ruby,
                TypeReward.Silver,
            };
            TypeReward typeItem = typeIteSubRewardItem[RandomNumber(0, typeIteSubRewardItem.Length - 1)];
            SubRewardItem result = new SubRewardItem();
            result.type_reward = (int)typeItem;
            switch (typeItem)
            {
                case TypeReward.Item:
                    result.static_id = RandomNumber(1, StaticDatabase.entities.items.Length);
                    result.quantity = RandomNumber(1, 4);
                    return result;
                case TypeReward.Silver:
                    result.quantity = RandomNumber(100, 500);
                    return result;
                case TypeReward.Ruby:
                    result.quantity = RandomNumber(5, 50);
                    return result;
                default:
                    return null;
            }
        }

        public static double GetRestTimeSecond(DateTime dateTime, double maxSecondRangeTime)
        {
            double totalSecond = (DateTime.Now - dateTime).TotalSeconds;
            return totalSecond > maxSecondRangeTime ? 0 : maxSecondRangeTime - totalSecond;
        }


        public static GetCooldownPointResponseData CheckStaminaAndCooldownTime(GamePlayer player)
        {
            double time = 0;

            if (player.cacheData.stamina >= StaticDatabase.entities.configs.maxStamina)
            {
                time = -1;
            }
            else
            {
                int maxStaminaCanReceive = StaticDatabase.entities.configs.maxStamina - player.cacheData.stamina;

                TimeSpan timeSpan = DateTime.Now - player.cacheData.last_time_update_stamina;
                double coolDownTime = StaticDatabase.entities.configs.GetSecondCoolDownPlusStamina();
                double totalSecond = timeSpan.TotalSeconds;
                if (timeSpan.TotalSeconds > coolDownTime)
                {
                    double staminaReceived = totalSecond / coolDownTime;

                    if (staminaReceived > maxStaminaCanReceive)
                        staminaReceived = maxStaminaCanReceive;

                    player.cacheData.last_time_update_stamina = DateTime.Now;
                    player.cacheData.stamina += (int)staminaReceived;

                    MongoController.UserDb.Info.UpdatePlusStamina(player.cacheData);

                    if (player.cacheData.stamina == StaticDatabase.entities.configs.maxStamina)
                    {
                        time = -1;
                    }
                    else
                    {
                        DateTime nextTimePlusStamina =
                            player.cacheData.last_time_update_stamina.AddMinutes(
                                StaticDatabase.entities.configs.timeCooldownPlusStamina);
                        time = (nextTimePlusStamina - DateTime.Now).TotalSeconds;
                    }
                }
                else
                {
                    time = coolDownTime - timeSpan.TotalSeconds;
                }
            }
            GetCooldownPointResponseData responseData = new GetCooldownPointResponseData()
            {
                point = player.cacheData.stamina,
                cooldown_time = time
            };
            return responseData;
        }

        public static async void LoadStaticDBAndStartTimeCounter()
        {
            CommonLog.Instance.PrintLog("LoadStaticDBAndStartTimeCounter");
            byte[] arrByte = await WebClientController.Instance.DownloadData();
            StaticDatabase.LoadFromBinary(arrByte);
            QuartzManager.Instance.StartSchedule();
            SuKienInfo.StartCheckSuKien();
            MMOApplication.IsDoneLoadData = true;
        }

        public static void CreateNewServer(string appName, string name, string groupId, MMongoConnection mongoConnection)
        {

            MServer serverCopy = MongoController.ServerDb.Server.GetServer(Settings.Instance.server_id);

            MServer mserver = new MServer();
            mserver.name = name;
            mserver.status = 0;
            mserver.is_main = true;
            mserver.group_id = groupId;
            mserver.mongo_connection = mongoConnection;
            mserver.photon_connection = serverCopy.photon_connection;
            mserver.photon_connection.app_name = appName;

            MongoController.ServerDb.Server.Create(mserver);

            MChieuMoConfig chieuMoConfig = MongoController.ConfigDb.ChieuMo.GetData();
            MChucPhucConfig chucPhucConfig = MongoController.ConfigDb.ChucPhuc.GetData();
            MGlobalBossConfig globalBossConfig = MongoController.ConfigDb.GlobalBoss.GetData();
            MThanThapConfig thanThapConfig = MongoController.ConfigDb.ThanThap.GetData();
            MThuongNapLanDauConfig thuongNapLanDauConfig = MongoController.ConfigDb.ThuongNapLanDau.GetData();
            List<MVipRewardConfig> listVipRewardConfig = MongoController.ConfigDb.VipReward.GetDatas();
            List<MRuongBauConfig> listRuongBauConfig = MongoController.ConfigDb.RuongBau.GetDatas();

            List<MLebao> listLeBaos = MongoController.ShopDb.LeBao.GetDatas();
            List<MShopItem> listShopItem = MongoController.ShopDb.Item.GetDatas();
            List<MLuanKiemShopItem> listLuanKiemShopItems = MongoController.ShopDb.LuanKiem.GetDatas();

            Settings.Instance.ChangeServerId(mserver._id);
            // new connect
            MongoController.Connected();

            MongoController.ConfigDb.ChieuMo.Create(chieuMoConfig);
            MongoController.ConfigDb.ChucPhuc.Create(chucPhucConfig);
            MongoController.ConfigDb.GlobalBoss.Create(globalBossConfig);
            MongoController.ConfigDb.ThanThap.Create(thanThapConfig);
            MongoController.ConfigDb.ThuongNapLanDau.Create(thuongNapLanDauConfig);
            MongoController.ConfigDb.VipReward.CreateAll(listVipRewardConfig);
            MongoController.ConfigDb.RuongBau.CreateAll(listRuongBauConfig);

            MongoController.ShopDb.LeBao.CreateAll(listLeBaos);
            MongoController.ShopDb.Item.CreateAll(listShopItem);
            MongoController.ShopDb.LuanKiem.CreateAll(listLuanKiemShopItems);

            CreateBotLuanKiem(10000);
        }

        /// <summary>
        /// Change config server
        /// le bao - qua vip - chieu mo - shop item
        /// </summary>
        /// <param name="idServer"></param>
        public static void ChangeConfigServer(string idServer)
        {
            MServer serverChange = MongoController.ServerDb.Server.GetServer(idServer);

            MChieuMoConfig chieuMoConfig = MongoController.ConfigDb.ChieuMo.GetData();
            List<MVipRewardConfig> listVipRewardConfig = MongoController.ConfigDb.VipReward.GetDatas();
            List<MLebao> listLeBaos = MongoController.ShopDb.LeBao.GetDatas();
            List<MShopItem> listShopItem = MongoController.ShopDb.Item.GetDatas();
            Settings.Instance.ChangeServerId(serverChange._id);
            // new connect
            MongoController.Connected();

            MongoController.ConfigDb.ChieuMo.DeleteAll(a => a.server_id == idServer);
            MongoController.ConfigDb.VipReward.DeleteAll(a => a.server_id == idServer);
            MongoController.ShopDb.LeBao.DeleteAll(a => a.server_id == idServer);
            MongoController.ShopDb.Item.DeleteAll(a => a.server_id == idServer);

            MongoController.ConfigDb.ChieuMo.Create(chieuMoConfig);
            MongoController.ConfigDb.VipReward.CreateAll(listVipRewardConfig);
            MongoController.ShopDb.LeBao.CreateAll(listLeBaos);
            MongoController.ShopDb.Item.CreateAll(listShopItem);
        }


        public static void ChangeUsername(string newUsername, string oldUsername)
        {
            Dictionary<string, object> dictFilter = new Dictionary<string, object>(1)
            {
                {"userid",oldUsername}
            };
            Dictionary<string, object> dictUpdate = new Dictionary<string, object>(1)
            {
                 {"userid",newUsername},
            };

            Dictionary<string, object> dictFilterUser = new Dictionary<string, object>(1)
            {
                {"user.userid",oldUsername}
            };
            Dictionary<string, object> dictUpdateUser = new Dictionary<string, object>(1)
            {
                 {"user.userid",newUsername},
            };

            Dictionary<string, object> dictFilterUserOpp = new Dictionary<string, object>(1)
            {
                {"user_opponent.userid",oldUsername}
            };
            Dictionary<string, object> dictUpdateUserOpp = new Dictionary<string, object>(1)
            {
                 {"user_opponent.userid",newUsername},
            };

            //MongoController.LogDb.ActionGold.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogDb.UserLevelUp.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogDb.LoginLog.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogDb.UsedSilver.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.BuyLeBao.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.BuyLuanKiemShopItem.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.BuyShopItem.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogDb.GiftCode.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.ChieuMo.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.ContributeLog.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.DoPhuong.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.ExchangeGoldToSilver.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.FreeStamina.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.LuaTraiRewardLog.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.MissionGuildLog.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.MoiRuou.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.MoRuong.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.NhiemVuHangNgay.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.Sk7NgayNhanThuong.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.SkDoiDo.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.SkPhucLoiTruongThanh.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.SkRotDo.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.SkThanTai.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.SkTichLuyNap.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.SkTichLuyTieu.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.SkTranhMuaServer.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.SkVongQuayMayMan.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.ThachDau.DeleteAll(a => a.userid == newUsername);
            //MongoController.LogSubDB.TopThanThap.DeleteAll(a => a.user.userid == newUsername || a.user.userid == oldUsername);
            //MongoController.LogSubDB.LuanKiem.DeleteAll(a => a.user.userid == newUsername || a.user_opponent.userid == newUsername);
            //MongoController.LogSubDB.LuanKiem.DeleteAll(a => a.user.userid == oldUsername || a.user_opponent.userid == oldUsername);
            //MongoController.GuildDb.GuildMember.DeleteAll(a => a.userid == newUsername);
            //MongoController.GuildDb.RequestJoin.DeleteAll(a => a.userid == newUsername);
            //MongoController.MarketDb.ItemSelling.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.CauCa.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.CharSoul.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.Char.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.VanTieu.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.CuopTieu.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.CuuCuuTriTon.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.DiemDanhThang.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.EquipPiece.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.Equip.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.Friend.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.GlobalBoss.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.Info.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.Item.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.Mail.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.NhiemVuChinhTuyen.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.PhucLoiThang.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.PowerUpItem.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.Stage.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.StarReward.DeleteAll(a => a.userid == newUsername);
            //MongoController.UserDb.ThanThap.DeleteAll(a => a.userid == newUsername);

            MongoController.LogDb.GiftCode.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogDb.ActionGold.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogDb.UserLevelUp.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogDb.LoginLog.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogDb.UsedSilver.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogDb.ChieuMo.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.BuyLeBao.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.BuyLuanKiemShopItem.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.BuyShopItem.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.ContributeLog.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.DoPhuong.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.ExchangeGoldToSilver.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.FreeStamina.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.LuaTraiRewardLog.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.MissionGuildLog.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.MoiRuou.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.MoRuong.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.NhiemVuHangNgay.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.Sk7NgayNhanThuong.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.SkDoiDo.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.SkPhucLoiTruongThanh.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.SkRotDo.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.SkThanTai.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.SkTichLuyNap.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.SkTichLuyTieu.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.SkTranhMuaServer.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.SkVongQuayMayMan.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.ThachDau.UpdateAll(dictFilter, dictUpdate);
            MongoController.LogSubDB.TopThanThap.UpdateAll(dictFilterUser, dictUpdateUser);
            MongoController.LogSubDB.LuanKiem.UpdateAll(dictFilterUser, dictUpdateUser);
            MongoController.LogSubDB.LuanKiem.UpdateAll(dictFilterUserOpp, dictUpdateUserOpp);
            MongoController.GuildDb.Guild.UpdateAll(dictFilter, dictUpdate);
            MongoController.GuildDb.GuildMember.UpdateAll(dictFilter, dictUpdate);
            MongoController.GuildDb.RequestJoin.UpdateAll(dictFilter, dictUpdate);
            MongoController.MarketDb.ItemSelling.UpdateAll(dictFilter, dictUpdate);
            MongoController.UserDb.CauCa.UpdateAll(dictFilter, dictUpdate);
            MongoController.UserDb.Char.UpdateAll(dictFilter, dictUpdate);
            MongoController.UserDb.VanTieu.UpdateAll(dictFilter, dictUpdate);
            MongoController.UserDb.CuopTieu.UpdateAll(dictFilter, dictUpdate);
            MongoController.UserDb.CuuCuuTriTon.UpdateAll(dictFilter, dictUpdate);
            MongoController.UserDb.DiemDanhThang.UpdateAll(dictFilter, dictUpdate);
            MongoController.UserDb.Equip.UpdateAll(dictFilter, dictUpdate);
            MongoController.UserDb.Friend.UpdateAll(dictFilter, dictUpdate);
            MongoController.UserDb.GlobalBoss.UpdateAll(dictFilter, dictUpdate);
            MongoController.UserDb.Info.UpdateAll(dictFilter, dictUpdate);
            MongoController.UserDb.Item.UpdateAll(dictFilter, dictUpdate);
            MongoController.UserDb.Mail.UpdateAll(dictFilter, dictUpdate);
            MongoController.UserDb.NhiemVuChinhTuyen.UpdateAll(dictFilter, dictUpdate);
            MongoController.UserDb.PhucLoiThang.UpdateAll(dictFilter, dictUpdate);
            MongoController.UserDb.Stage.UpdateAll(dictFilter, dictUpdate);
            MongoController.UserDb.StarReward.UpdateAll(dictFilter, dictUpdate);
            MongoController.UserDb.ThanThap.UpdateAll(dictFilter, dictUpdate);

            Console.WriteLine("Done!");
        }



    }
}
