using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KDQHDesignerTool.FormBase;
using System.Net;
using RestSharp;
using KDQHDesignerTool.Models;
using KDQHDesignerTool.Common;

namespace KDQHDesignerTool.Form
{
    public partial class frmUploadBunder : frmFormChange
    {
        public frmUploadBunder()
        {
            InitializeComponent();
        }

        string pathWin = "";
        string fileNameWin = "";
        string pathMac = "";
        string fileNameMac = "";
        string pathIOS = "";
        string fileNameIOS = "";
        string pathAndroid = "";
        string fileNameAndroid = "";
        WebClient client = new WebClient();
        string uploadWebUrl = "http://103.48.80.46:8091/DataVersion/AssetBundle";

        private void btnWindowAsset_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogAsset.ShowDialog();
            pathWin = openFileDialogAsset.FileName;
            fileNameWin = openFileDialogAsset.SafeFileName;
            if (result == DialogResult.OK)
            {
                txtWindowAsset.Text = pathWin;
                txtFileNameWin.Text = fileNameWin;
            }
        }

        private void btnMacAsset_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogAsset.ShowDialog();
            pathMac = openFileDialogAsset.FileName;
            fileNameMac = openFileDialogAsset.SafeFileName;
            if (result == DialogResult.OK)
            {
                txtMacAsset.Text = pathMac;
                txtFileNameMac.Text = fileNameMac;
            }
        }

        private void btnIOSAsset_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogAsset.ShowDialog();
            pathIOS = openFileDialogAsset.FileName;
            fileNameIOS = openFileDialogAsset.SafeFileName;
            if (result == DialogResult.OK)
            {
                txtIOSAsset.Text = pathIOS;
                txtxFileIOS.Text = fileNameIOS;
            }
        }

        private void btnAndroidAsset_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogAsset.ShowDialog();
            pathAndroid = openFileDialogAsset.FileName;
            fileNameAndroid = openFileDialogAsset.SafeFileName;
            if (result == DialogResult.OK)
            {
                txtAndroidAsset.Text = pathAndroid;
                txtFileNameAndroid.Text = fileNameAndroid;
            }
        }

        protected override void OnUpload()
        {
            if (pathMac != "")
            {
                CommonShowDialog.ShowWaitForm();
                Dictionary<string, object> postParameters = new Dictionary<string, object>();
                if (pathWin != "")
                {
                    byte[] bytesWin = System.IO.File.ReadAllBytes(pathWin);
                    postParameters.Add("win", new FormUpload.FileParameter(bytesWin, fileNameWin, "application/x-www-form-urlencoded"));
                }
                if (pathMac != "")
                {
                    byte[] bytesMac = System.IO.File.ReadAllBytes(pathMac);
                    postParameters.Add("mac", new FormUpload.FileParameter(bytesMac, fileNameMac, "application/x-www-form-urlencoded"));
                }
                if (pathIOS != "")
                {
                    byte[] bytesIOS = System.IO.File.ReadAllBytes(pathIOS);
                    postParameters.Add("ios", new FormUpload.FileParameter(bytesIOS, fileNameIOS, "application/x-www-form-urlencoded"));
                }
                if (pathAndroid != "")
                {
                    byte[] bytesAndroid = System.IO.File.ReadAllBytes(pathAndroid);
                    postParameters.Add("android", new FormUpload.FileParameter(bytesAndroid, fileNameAndroid, "application/x-www-form-urlencoded"));
                }
                try
                {
                    HttpWebResponse webResponse = FormUpload.MultipartFormDataPost(uploadWebUrl, "tool-design", postParameters);
                    CommonShowDialog.CloseWaitForm();
                    CommonShowDialog.ShowSuccessfulDialog("Upload file asset thành công!");
                }
                catch (Exception)
                {
                    CommonShowDialog.CloseWaitForm();
                    CommonShowDialog.ShowErrorDialog("Đã có lỗi xảy ra!");
                }
            }
            else
            {
                CommonShowDialog.ShowErrorDialog("Bắt buộc phải upload file Mac Asset!");
            }
        }
    }
}