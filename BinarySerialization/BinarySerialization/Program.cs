using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* Ne pas oublier d'apporter les namespaces adéquats */
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BinarySerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Map[] maps = { new Map("Background", "B", new int[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }), new Map("Middleground", "M", new int[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }), new Map("Foreground", "F", new int[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }) };
            BinarySerializationMaps(maps);
        }

        /* Création d'une procédure pour la sérialisation binaire des maps */
        static void BinarySerializationMaps(Map[] maps)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            Console.WriteLine("What do you want ? Load or Save ? (load/save)");
            string answer = Console.ReadLine();

            if (answer == "save")
            {
                /* A comprendre --> */
                FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Maps.dat", FileMode.Create);
                serializer.Serialize(fs, maps);
                fs.Close();
                /* <-- Fin */
                Console.WriteLine("Serialization is a success !");
            }
            else if (answer == "load")
            {
                /* A comprendre --> */
                FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Maps.dat", FileMode.Open);
                Map[] serializedData = (Map[])serializer.Deserialize(fs);
                /* <-- Fin */
                foreach (Map map in serializedData)
                {
                    Console.WriteLine("Id : {1}\nDescription : {0}\nTilemap :\n", map.Texture, map.Description);
                    for (int i = 0; i < map.Tilemap.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.Tilemap.GetLength(1); j++)
                        {
                            Console.Write(map.Tilemap[i, j]);
                        }
                        Console.Write("\n");
                    }
                    Console.Write("\n");
                }
            }
            else
            {
                Console.WriteLine("Read is too hard for you noob ?!");
            }
            Console.ReadLine();
        }
    }
}
