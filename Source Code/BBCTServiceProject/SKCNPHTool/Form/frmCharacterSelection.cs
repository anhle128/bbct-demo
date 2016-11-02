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
using KDQHNPHTool.FormBase;
using KDQHNPHTool.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Model_View;

namespace KDQHNPHTool.Form
{
    public partial class frmCharacterSelection : frmFormChange
    {
        List<vCharacterSelection> lsChar = new List<vCharacterSelection>();

        public frmCharacterSelection(List<vCharacterSelection> tmpLsChar)
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lsChar = tmpLsChar;
            LoadDataToGC();
        }

        private void LoadDataToGC()
        {
            gcCharacter.DataSource = null;
            gcCharacter.DataSource = lsChar;
        }

        protected override void OnSave()
        {
            gvCharacter.FocusedRowHandle = -1;
            this.Close();
        }
    }
}