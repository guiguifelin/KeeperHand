using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.Xna.Framework;

namespace Game
{
    class Data
    {
        // Fields.

        private static BinaryFormatter serializer;
        private static FileStream fs;

        // Methods.

        /* Game */

        public static void Serialization(AbstractGame game_set, string name)
        {
            fs = new FileStream(Environment.CurrentDirectory + "\\Data\\" + name + ".KH", FileMode.Create);
            serializer = new BinaryFormatter();
            serializer.Serialize(fs, game_set);
            fs.Close();
        }
        public static AbstractGame Deserialization(AbstractGame game_set, string nameGameSet)
        {
            AbstractGame newGameSet = new AbstractGame();
            fs = new FileStream(Environment.CurrentDirectory + "\\Data\\" + nameGameSet + ".KH", FileMode.Open);
            serializer = new BinaryFormatter();
            newGameSet = (AbstractGame)serializer.Deserialize(fs);
            fs.Close();
            return newGameSet;
        }

        /* StateOption */

        public static void Serialization(StateOptions options, string name)
        {
            fs = new FileStream(Environment.CurrentDirectory + "\\Data\\" + name + ".dat", FileMode.Create);
            serializer = new BinaryFormatter();
            serializer.Serialize(fs, options);
            fs.Close();
        }
        public static StateOptions Deserialization(StateOptions options, string nameOptions)
        {
            StateOptions newOptions = new StateOptions();
            fs = new FileStream(Environment.CurrentDirectory + "\\Data\\" + nameOptions + ".dat", FileMode.Open);
            serializer = new BinaryFormatter();
            newOptions = (StateOptions)serializer.Deserialize(fs);
            fs.Close();
            return newOptions;
        }

        /* Player */
        /* Hotkeys */
        public static void Serialization(Hotkeys hotkeys, string name)
        {
            fs = new FileStream(Environment.CurrentDirectory + "\\Data\\" + name + ".dat", FileMode.Create);
            serializer = new BinaryFormatter();
            serializer.Serialize(fs, hotkeys);
            fs.Close();
        }
        public static Hotkeys Deserialization(Hotkeys hotkeys, string nameHotkeys)
        {
            Hotkeys newHotkeys = new Hotkeys();
            fs = new FileStream(Environment.CurrentDirectory + "\\Data\\" + nameHotkeys + ".dat", FileMode.Open);
            serializer = new BinaryFormatter();
            newHotkeys = (Hotkeys)serializer.Deserialize(fs);
            fs.Close();
            return newHotkeys;
        } 
        /* Level */
        public static void Serialization(Gameplay level, string name)
        {
            fs = new FileStream(Environment.CurrentDirectory + "\\Data\\" + name + ".dat", FileMode.Create);
            serializer = new BinaryFormatter();
            serializer.Serialize(fs, level);
            fs.Close();
        }
        public static Gameplay Deserialization(Gameplay level, string nameGameplay)
        {
            Gameplay newLevel = new Gameplay();
            fs = new FileStream(Environment.CurrentDirectory + "\\Data\\" + nameGameplay + ".dat", FileMode.Open);
            serializer = new BinaryFormatter();
            newLevel = (Gameplay)serializer.Deserialize(fs);
            fs.Close();
            return newLevel;
        }
    }
}
