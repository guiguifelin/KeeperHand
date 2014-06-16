using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MapEditor
{
    public class Map
    {
        // Fields.
        #region Fields

        private List<Tile> tiles = new List<Tile>();
        private Texture2D tileset;
        private int sizeTilesetX, sizeTilesetY;

        #endregion

        // Constructor.

        public Map(Texture2D tileset, int sizeTilesetX, int sizeTilesetY)
        {
            this.tileset = tileset;
            this.sizeTilesetX = sizeTilesetX;
            this.sizeTilesetY = sizeTilesetY;
        }

        // Get & Set.
        #region Get & Set

        public List<Tile> Tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }

        #endregion

        // Methods.
        public void Generate(int[,] map)
        {
            int sizeX = tileset.Width;
            int sizeY = tileset.Height;
            if (sizeTilesetX > 0)
            {
                sizeX = (tileset.Width / sizeTilesetX);
            }
            if (sizeTilesetY > 0)
            {
                sizeY = (tileset.Height / sizeTilesetY);
            }

            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];
                    int xMap = 0;
                    int yMap = 0;

                    if (number > 0)
                    {
                        for (int n = 1; n < number; n++)
                        {
                            xMap++;
                            if (xMap > sizeTilesetX - 1)
                            {
                                xMap = 0;
                                yMap++;
                                if (yMap > sizeTilesetY)
                                {
                                    yMap = 0;
                                }
                            }
                        }
                        tiles.Add(new Tile(tileset, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), 
                            new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY)); 
                    }
                }
            }
        }
        
        // Update & Draw.

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in tiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
