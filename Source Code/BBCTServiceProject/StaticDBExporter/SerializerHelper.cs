using ProtoBuf;
using StaticDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDBExporter
{
    class SerializerHelper
    {
        public static void Serialize(Entity entities, string path)
        {
            try
            {
                using (var file = File.Create(path))
                {
                    Serializer.Serialize(file, entities);
                }
            }
            catch (DirectoryNotFoundException)
            {
                string[] arrPath = path.Split('\\');
                string folderName = arrPath[arrPath.Length - 2];
                Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + "\\" + folderName);
                Serialize(entities, path);
            }

        }

        public static Entity Deserialize(string path)
        {
            Entity entities;
            using (var file = File.OpenRead(path))
            {
                entities = Serializer.Deserialize<Entity>(file);
            }
            return entities;
        }

    }
}
