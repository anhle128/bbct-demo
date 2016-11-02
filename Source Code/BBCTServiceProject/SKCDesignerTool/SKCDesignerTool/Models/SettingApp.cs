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
        public static string gameVersion = "1.0.0.4";
        public static string toolVersion = "Release";

        ////upload file dev
        public static string accountFPTUploadFile = "dpbb";
        public static string passwordFPTUploadFile = "JtXHMyn6THPid77ih4Vr";
        public static string urlUploadFileStatic = "http://cdn.dpbb.vtcmobile.vn/" + gameVersion + "/StaticDB/static.bytes";
        public static string urlUploadFileLanguage = "http://cdn.dpbb.vtcmobile.vn/" + gameVersion + "/Language/language.json";

        //Connect mongo dev
        public static string mgUrl = "118.107.70.207";
        public static string mgPort = "27017";
        public static string mgUsername = "admin";
        public static string mgPassword = "lungemine2016";
        public static string mgDatabase = "BBCT";

        ////upload file
        //public static string accountFPTUploadFile = "dpbb";
        //public static string passwordFPTUploadFile = "JtXHMyn6THPid77ih4Vr";
        //public static string urlUploadFileStatic = "http://cdn.dpbb.vtcmobile.vn/StaticDB/static.bytes";
        //public static string urlUploadFileLanguage = "http://cdn.dpbb.vtcmobile.vn/Language/language.json";

        //Connect mongo dang chay
        //public static string mgUrl = "118.107.70.207";
        //public static string mgPort = "27017";
        //public static string mgUsername = "admin";
        //public static string mgPassword = "lungemine2016";
        //public static string mgDatabase = "BBCT";

        /////BBCT
        //upload file
        //public static string accountFPTUploadFile = "tu.hq";
        //public static string passwordFPTUploadFile = "123456";
        //public static string urlUploadFileStatic = "http://lungemine.com:8093/BBCT/StaticDB/static.bytes";
        //public static string urlUploadFileLanguage = "http://lungemine.com:8093/BBCT/Language/language.json";

        ////Connect mongo
        //public static string mgUrl = "103.48.80.234";
        //public static string mgPort = "27017";
        //public static string mgUsername = "admin";
        //public static string mgPassword = "lungemine";
        //public static string mgDatabase = "bbct";
    }
}
