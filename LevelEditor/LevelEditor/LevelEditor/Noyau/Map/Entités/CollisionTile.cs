using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LevelEditor
{
    class CollisionTile : Tile
    {
        // Fields.

        private int tileSetX, tileSetY;

        // Constructor.

        public CollisionTile(Texture2D texture, Rectangle rect, int x, int y, int TileSetX, int TileSetY)
        {
            this.tileSetX = TileSetX;
            this.tileSetY = TileSetY;

            this.texture = texture;
            this.Rectangle = rect;
            this.x = x;
            this.y = y;

            InitializeSize();
        }

        // Get & Set.

        // Methods.

        private void InitializeSize()
        {
            if (tileSetX > 0)
            {
                this.sizeX = (texture.Width / tileSetX);
            }
            else
            {
                this.sizeX = texture.Width;
            }
            if (tileSetY > 0)
            {
                this.sizeY = (texture.Height / tileSetY);
            }
            else
            {
                this.sizeY = texture.Height;
            }
        }

        // Update & Draw.
    }
}
