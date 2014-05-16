using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SavingMap;

namespace Game
{
    [Serializable]
    public static class AbstractSetGame
    {
        // Fields.
        #region Fields
        /* Stats */
        public static int lvl = 1;
        /* Base */
        public static SavingMap.ArrayMap arrayMap;
        public static Map[] maps;
        #endregion

        // Methods.
        #region Methods
        public static void LoadMap(int lvl)
        {
            maps = new Map[4];
            arrayMap = SavingMap.Data.Deserialization(lvl, "map");
            maps[0] = new Map(Ressources.tileset_background, 6, 0);
            maps[1] = new Map(Ressources.tileset_middleground, 5, 4);

            /* Modify textures */
            maps[2] = new Map(Ressources.tileset_middleground, 5, 4);
            maps[3] = new Map(Ressources.tileset_middleground, 5, 4);

            /* Generation */
            maps[0].Generate(arrayMap.MapBackground);
            maps[1].Generate(arrayMap.MapMiddleground);
            maps[2].Generate(arrayMap.MapForeground);
            maps[3].Generate(arrayMap.MapAction);
        }
        #endregion
    }
}
