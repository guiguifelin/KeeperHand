using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SavingMap
{
    public static class SaveDonjon
    {
        // Fields.

        private static BinaryFormatter serializer;
        private static FileStream fs;

        // Methods.

        /* Maps */
        public static void Serialization(Donjon dj, int donjonNumber, string name)
        {
            fs = new FileStream(Environment.CurrentDirectory + "\\Data\\" + name + donjonNumber + ".dj", FileMode.Create);
            serializer = new BinaryFormatter();
            serializer.Serialize(fs, dj);
            fs.Close();
        }
        public static Donjon Deserialization(int donjonNumber, string name)
        {
            Donjon maps = new Donjon();
            fs = new FileStream(Environment.CurrentDirectory + "\\Data\\" + name + donjonNumber + ".dj", FileMode.Open);
            serializer = new BinaryFormatter();
            maps = (Donjon)serializer.Deserialize(fs);
            fs.Close();
            return maps;
        }
    }
}
