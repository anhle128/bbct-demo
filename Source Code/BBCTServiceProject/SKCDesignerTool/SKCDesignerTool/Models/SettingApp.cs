using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BBCTDesignerTool.Models
{
    public static class SettingApp
    {
        /////BBCT
        public static string gameVersion = "1.0.0.1";
        public static string toolVersion = "Dev";

        ////upload file dev
        public static string accountFPTUploadFile = "tu.hq";
        public static string passwordFPTUploadFile = "123456";
        public static string urlUploadFileStatic = "http://lungemine.com:8093/BBCT/" + gameVersion + "/StaticDB/static.bytes";
        public static string urlUploadFileLanguage = "http://lungemine.com:8093/BBCT/" + gameVersion + "/Language/language.json";

        //Connect mongo dev
        public static string mgUrl = "103.48.80.234";
        public static string mgPort = "27017";
        public static string mgUsername = "admin";
        public static string mgPassword = "lungemine";
        public static string mgDatabase = "bbct";
    }
}
