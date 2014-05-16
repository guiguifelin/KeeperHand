using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SavingMap
{
        public class Data
        {
            // Fields.

            private static BinaryFormatter serializer;
            private static FileStream fs;

            // Methods.

            /* Maps */
            public static void Serialization(ArrayMap array, int mapNumber, string name)
            {
                fs = new FileStream(Environment.CurrentDirectory + "\\Data\\" + name + mapNumber + ".dat", FileMode.Create);
                serializer = new BinaryFormatter();
                serializer.Serialize(fs, array);
                fs.Close();
            }
            public static ArrayMap Deserialization(int mapNumber, string name)
            {
                ArrayMap maps = new ArrayMap();
                fs = new FileStream(Environment.CurrentDirectory + "\\Data\\" + name + mapNumber + ".dat", FileMode.Open);
                serializer = new BinaryFormatter();
                maps = (ArrayMap)serializer.Deserialize(fs);
                fs.Close();
                return maps;
            }
        }
}
