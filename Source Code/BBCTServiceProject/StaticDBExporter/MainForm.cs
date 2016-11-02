using EPocalipse.Json.Viewer;
using Newtonsoft.Json;
using ProtoBuf.Meta;
using StaticDB;
using StaticDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaticDBExporter
{
    public partial class MainForm : Form
    {
        public string data;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JSON (.json)|*.json";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                data = File.ReadAllText(openFileDialog1.FileName);
            }

            openFileDialog1.Dispose();
            openFileDialog1 = null;

            LoadViewer();
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = "json";
            saveFileDialog1.Filter = "JSON |*.json";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Title = "Where do you want to save the file?";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, data);
            }

            saveFileDialog1.Dispose();
            saveFileDialog1 = null;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Entity entities = JsonConvert.DeserializeObject<Entity>(data);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = "bytes";
            saveFileDialog1.Filter = "StaticDB |*.bytes";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Title = "Where do you want to save the file?";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Entity entities;
                using (TextReader reader = new StringReader(data))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    JsonReader jReader = new JsonReader(reader);
                    entities = (Entity)serializer.Deserialize(jReader, typeof(Entity));
                }
                entities.version = System.DateTime.Now.ToLongDateString() + System.DateTime.Now.ToLongTimeString();
                SerializerHelper.Serialize(entities, saveFileDialog1.FileName);
            }
            saveFileDialog1.Dispose();
            saveFileDialog1 = null;
        }

        private void btnExportSerializer_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = "dll";
            saveFileDialog1.Filter = "Serializer |*.dll";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Title = "Where do you want to save the file?";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var model = TypeModel.Create();

                model.Add(typeof(Entity), true);
                model.Add(typeof(Character), true);
                model.Add(typeof(Skill), true);

                model.Compile("StaticDBSerializer", saveFileDialog1.FileName);
            }

            saveFileDialog1.Dispose();
            saveFileDialog1 = null;
        }

        private void btnLoadBinary_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "StaticDB (.bytes)|*.bytes";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Entity entities = SerializerHelper.Deserialize(openFileDialog1.FileName);
                //data = JsonConvert.SerializeObject(entities);
                using (TextWriter writer = new StringWriter())
                {
                    JsonSerializer serializer = new JsonSerializer();
                    JsonWriter jWriter = new JsonWriter(writer);
                    serializer.Serialize(jWriter, entities);
                    data = writer.ToString();
                }
            }

            openFileDialog1.Dispose();
            openFileDialog1 = null;

            LoadViewer();
        }

        public void LoadViewer()
        {
            jsonViewer1.ShowTab(Tabs.Viewer);
            jsonViewer1.Json = data;
        }

    }
}
