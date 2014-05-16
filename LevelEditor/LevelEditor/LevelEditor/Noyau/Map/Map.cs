using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LevelEditor
{
    class Map : HUDState
    {
        // Fields.

        private Cursor cursor;
        private SelectionTile selection;
        private List<CollisionTile> collisionsTiles = new List<CollisionTile>();
        private Texture2D tileSet;
        private int tileSetX, tileSetY, xSelector, ySelector;
        private int[,] mapTab;
        private bool mapChanged;

        // Constructor.

        public Map(Texture2D tileSet, Cursor CurrentCursor, SelectionTile currentSelection, int tileSetX, int tileSetY, int[,] mapTab)
        {
            this.cursor = CurrentCursor;
            this.tileSet = tileSet;
            this.tileSetX = tileSetX;
            this.tileSetY = tileSetY;
            this.mapTab = mapTab;
            this.mapChanged = true;
            this.selection = currentSelection;
        }

        // Get & Set.

        internal List<CollisionTile> CollisionsTiles
        {
            get { return collisionsTiles; }
            set { collisionsTiles = value; }
        }
        public bool MapChanged
        {
            get { return mapChanged; }
            set { mapChanged = value; }
        }
        public int[,] MapTab
        {
            get { return mapTab; }
        }

        // Methods.

        public void Generate(int[,] map)
        {
            int sizeX = tileSet.Width;
            int sizeY = tileSet.Height;
            if (tileSetX > 0)
            {
                sizeX = (tileSet.Width / tileSetX);
            }
            if (tileSetY > 0)
            {
                sizeY = (tileSet.Height / tileSetY);
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
                            if (xMap > tileSetX - 1)
                            {
                                xMap = 0;
                                yMap++;
                                if (yMap > tileSetY)
                                {
                                    yMap = 0;
                                }
                            }
                        }
                        collisionsTiles.Add(new CollisionTile(tileSet, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), xMap, yMap, tileSetX, tileSetY));
                    }
                }
            }
        }
        private void CursorPositionTile(MouseState mouse)
        {
            int sizeX = tileSet.Width;
            int sizeY = tileSet.Height;
            if (tileSetX > 0)
            {
                sizeX = (tileSet.Width / tileSetX);
            }
            if (tileSetY > 0)
            {
                sizeY = (tileSet.Height / tileSetY);
            }

            xSelector = (mouse.X / sizeX) * sizeX;
            ySelector = (mouse.Y / sizeY) * sizeY;

            int X = (xSelector / sizeX);
            int Y = (ySelector / sizeY);

            /* Update de la selection du tile du plan */
            selection.Update(sizeX, sizeY, xSelector, ySelector);

            if (modeEdition && EnabledRemove && mouse.RightButton == ButtonState.Pressed)
            {
                mapTab[Y, X] = 0;
                mapChanged = true;
            }
            else if (modeEdition && EnabledAdd && mouse.RightButton == ButtonState.Pressed)
            {
                mapTab[Y, X] = newNumber;
                mapChanged = true;
            }
        }
        public int[,] SaveArrayMap()
        {
            return this.mapTab;
        }
        public void LoadArrayMap(int[,] map)
        {
            this.mapTab = map;
            this.mapChanged = true;
        }

        // Update & Draw.

        public void Update(MouseState mouse)
        {
            if (mapChanged)
            {
                for (int i = 0; i < collisionsTiles.Count; i++)
                {
                    collisionsTiles.RemoveAt(i);
                    i--;
                }
                Generate(mapTab);
                mapChanged = false;
            }

            if (modeEdition)
            {
                CursorPositionTile(mouse);
            }
        }
        public void Draw(SpriteBatch spriteBatch, MouseState mouse)
        {
            foreach (CollisionTile tile in collisionsTiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
