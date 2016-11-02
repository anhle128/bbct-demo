using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace KDQHNPHTool.Common
{
    class CommonFunc
    {
        public static string EncodeMD5(string input)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sbHash = new StringBuilder();
            foreach (byte b in bHash)
            {
                sbHash.Append(String.Format("{0:x2}", b));
            }
            return sbHash.ToString();
        }

        public static void ShowForm(XtraForm form)
        {
            CommonShowDialog.ShowWaitForm();
            form.ShowDialog();
            CommonShowDialog.CloseWaitForm();
        }

        public static void AddTab(XtraTabControl tabControl, XtraUserControl uc, string name, string text)
        {
            CommonShowDialog.ShowWaitForm();
            XtraTabPage pageNT = new XtraTabPage()
            {
                Name = name,
                Text = text
            };
            pageNT.Controls.Add(uc);
            pageNT.Controls[0].Dock = DockStyle.Fill;
            tabControl.TabPages.Add(pageNT);
            tabControl.SelectedTabPage = pageNT;
            CommonShowDialog.CloseWaitForm();
        }

        public static string ReadFile(string fileName)
        {
            FileStream readStream;
            string dataResult = "";
            try
            {
                readStream = new FileStream(fileName, FileMode.Open);
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

        public static string GenerateCode(int lengthStringResult)
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            string stringRandom = BitConverter.ToInt64(buffer, 0).ToString();
            Random rnd = new Random();
            int startPosition = rnd.Next(0, stringRandom.Length - lengthStringResult);
            string resultCode = "";
            IEnumerable<char> ienumChar = stringRandom.Skip(startPosition).Take(lengthStringResult);
            foreach (var c in ienumChar)
            {
                resultCode = resultCode + c;
            }
            return resultCode;
        }

        public static string GetVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion;
        }

        public static DateTime GetStartDate(DateEdit de)
        {
            return de.DateTime;
        }

        public static DateTime GetEndDate(DateEdit de)
        {
            return de.DateTime;
        }

        public static int GetHashCodeTime()
        {
            return DateTime.Today.GetHashCode();
        }
    }
}
