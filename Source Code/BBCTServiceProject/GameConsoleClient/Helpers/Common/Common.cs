using GameConsoleClient.Helpers.FEnum;
using GameConsoleClient.Models;
using GameServer.Common.Enum;
using System;
using System.Collections;
using System.IO;
using System.Text;

namespace GameConsoleClient.Helpers.Common
{
    public class Common
    {
        public static string UrlLogin = "http://www.lungemine.com:8094/";
        public static string UserName = "playerSimulator";

        private static readonly string FilePathSaveAccount = Directory.GetCurrentDirectory() + @"\AccountData\data.json";


        public static CommonEnum.Action RandomCategory()
        {
            Random rd = new Random();
            return CommonEnum.Action.AttackMap;
            //return (CommonEnum.Action)rd.Next(2, Enum.GetValues(typeof(CommonEnum.Action)).Length - 4);
        }



        public static int RandomNumber(int min, int max)
        {
            Random rd = new Random();
            return rd.Next(min, max);
        }

        public static string GetName()
        {
            Guid ids = Guid.NewGuid();
            return ids.ToString().Replace("-", "");
        }

        public static void SaveAccountManager(AccountManager accountManager)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(accountManager);
            WriteFile(json, FilePathSaveAccount);
        }

        private static void WriteFile(string json, string path)
        {
            try
            {
                FileStream file = File.Create(path);
                StreamWriter bw = new StreamWriter(file, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
                bw.Write(json);
                bw.Close();
                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static AccountManager GetAccountManager()
        {
            string json = ReadFile(FilePathSaveAccount);
            if (json != "")
            {
                AccountManager listAccount = new AccountManager();
                listAccount = (AccountManager)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(AccountManager));
                return listAccount;
            }
            else
            {
                return new AccountManager();
            }
        }

        public static string ReadFile(string url)
        {
            try
            {
                StreamReader streamReader = new StreamReader(url);
                string text = streamReader.ReadToEnd();
                streamReader.Close();
                return text;
            }
            catch (Exception)
            {

                return "";
            }

        }

        public static CommonEnum.STATUS GetStatusResponse(string dataResponse)
        {
            Hashtable ht = Newtonsoft.Json.JsonConvert.DeserializeObject<Hashtable>(dataResponse);
            if (ht.ContainsKey("status"))
            {
                return (CommonEnum.STATUS)int.Parse(ht["status"].ToString());
            }
            else
            {
                return (CommonEnum.STATUS)0;
            }
        }

        public static string GetTokenResponse(string dataResponse)
        {
            Hashtable ht = Newtonsoft.Json.JsonConvert.DeserializeObject<Hashtable>(dataResponse);
            Hashtable htData = Newtonsoft.Json.JsonConvert.DeserializeObject<Hashtable>(ht["data"].ToString());
            if (htData.ContainsKey("token"))
            {
                return htData["token"].ToString();
            }
            else
            {
                return "";
            }
        }


        public static Account CreateNewAccount()
        {
            Account account = new Account(GetName(), "123456");
            return account;
        }

        public static void PrintLog(short operationCode, short returnCode)
        {
            Console.WriteLine(string.Format("{0} - {1}", (OperationCode)operationCode, (ReturnCode)returnCode));
        }

        #region Random
        static int lastedDouble = 0;
        static double lastedInt = 0;
        public int RandomFloat(int min, int max, int seed)
        {
            Random rnd = new Random(seed);
            int number = 0;
            do
            {
                number = rnd.Next(min, max);
            } while (lastedDouble == number);
            lastedDouble = number;
            return number;
        }

        public int RandomInt(int min, int max)
        {
            int number = 0;
            do
            {
                number = new Random().Next(min, max);
            } while (number == lastedInt);
            return number;
        }
        #endregion
    }
}
