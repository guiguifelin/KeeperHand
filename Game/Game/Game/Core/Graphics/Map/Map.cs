using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game
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
                        switch(number)
                        {
                            case 1:
                                tiles.Add(new Tile(tileset, Ressources.t_sprite1,new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY));
                                break;
                            case 2:
                                tiles.Add(new Tile(tileset, Ressources.t_sprite2, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY));
                                break;
                            case 3:
                                tiles.Add(new Tile(tileset, Ressources.t_sprite3, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY));
                                break;
                            case 4:
                                tiles.Add(new Tile(tileset, Ressources.t_sprite4, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY));
                                break;
                            case 5:
                                tiles.Add(new Tile(tileset, Ressources.t_sprite5, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY));
                                break;
                            case 6:
                                tiles.Add(new Tile(tileset, Ressources.t_sprite6, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY));
                                break;
                            case 7:
                                tiles.Add(new Tile(tileset, Ressources.t_sprite7, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY));
                                break;
                            case 8:
                                tiles.Add(new Tile(tileset, Ressources.t_sprite8, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY));
                                break;
                            case 9:
                                tiles.Add(new Tile(tileset, Ressources.t_sprite9, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY));
                                break;
                            case 10:
                                tiles.Add(new Tile(tileset, Ressources.t_sprite10, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY));
                                break;
                            case 11:
                                tiles.Add(new Tile(tileset, Ressources.t_sprite11, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY));
                                break;
                            case 12:
                                tiles.Add(new Tile(tileset, Ressources.t_sprite12, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY));
                                break;
                            case 13:
                                tiles.Add(new Tile(tileset, Ressources.t_sprite13, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY));
                                break;
                            case 14:
                                tiles.Add(new Tile(tileset, Ressources.t_sprite14, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY));
                                break;
                            case 15:
                                tiles.Add(new Tile(tileset, Ressources.t_sprite15, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY));
                                break;
                            case 16:
                                tiles.Add(new Tile(tileset, Ressources.t_sprite16, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY));
                                break;
                            case 17:
                                tiles.Add(new Tile(tileset, Ressources.t_sprite17, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), new Vector2(xMap, yMap), sizeTilesetX, sizeTilesetY));
                                break;
                        }
                        
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
        public void DrawTextureData(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in tiles)
            {
                tile.DrawTextureData(spriteBatch);
            }
        }
    }
}
