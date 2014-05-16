using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace SavingMap
{
    [Serializable]
    public class ArrayMap
    {
        // Fields.

        private int[,] mapBackground, mapMiddleground, mapForeground, mapAction;

        // Constructor.
        public ArrayMap() { }
        public ArrayMap(int[,] mapBackground, int[,] mapMiddleground, int[,] mapForeground, int[,] mapAction)
        {
            this.mapBackground = mapBackground;
            this.mapMiddleground = mapMiddleground;
            this.mapForeground = mapForeground;
            this.mapAction = mapAction;
        }

        // Get & Set.
        #region Get & Set

        public int[,] MapBackground
        {
            get { return mapBackground; }
            set { mapBackground = value; }
        }
        public int[,] MapMiddleground
        {
            get { return mapMiddleground; }
            set { mapMiddleground = value; }
        }
        public int[,] MapForeground
        {
            get { return mapForeground; }
            set { mapForeground = value; }
        }
        public int[,] MapAction
        {
            get { return mapAction; }
            set { mapAction = value; }
        }

        #endregion

        // Methods.
        public int[,] InitMap(Texture2D texture, int nbSpriteWidth, int nbSpriteHeight, Viewport viewport)
        {
            int sizeRow;
            int sizeColumn;

            if (nbSpriteWidth != 0)
            {
                sizeRow = viewport.Width / (texture.Width / nbSpriteWidth);
            }
            else
            {
                sizeRow = viewport.Width / (texture.Width / 1);
            }
            if (nbSpriteHeight != 0)
            {
                sizeColumn = viewport.Height / (texture.Height / nbSpriteHeight);
            }
            else
            {
                sizeColumn = viewport.Height / (texture.Height / 1);
            }

            int[,] map = new int[sizeColumn + 50, sizeRow + 50];
            return map;
        }
        public void SaveAllMaps(int[,] mapBackground, int[,] mapMiddleground, int[,] mapForeground, int[,] mapAction)
        {
            this.mapBackground = mapBackground;
            this.mapMiddleground = mapMiddleground;
            this.mapForeground = mapForeground;
            this.mapAction = mapAction;
        }
    }
}
