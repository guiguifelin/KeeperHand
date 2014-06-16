using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor
{
    public class Tile
    {
        // Fields.
        private int sizeTilesetX, sizeTilesetY, sizeX, sizeY;
        private Rectangle rect;
        private Vector2 vect;
        private Texture2D texture;

        // Constructor.

        public Tile(Texture2D texture, Rectangle rect, Vector2 vect, int sizeX, int sizeY)
        {
            this.texture = texture;
            this.rect = rect;
            this.vect = vect;
            this.sizeTilesetX = sizeX;
            this.sizeTilesetY = sizeY;

            Initialize();
        }

        // Get & Set.

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        public Rectangle Rect
        {
            get { return rect; }
        }

        // Methods.
        private void Initialize()
        {
            if (sizeTilesetX > 0)
            {
                this.sizeX = (texture.Width / sizeTilesetX);
            }
            else
            {
                this.sizeX = texture.Width;
            }
            if (sizeTilesetY > 0)
            {
                this.sizeY = (texture.Height / sizeTilesetY);
            }
            else
            {
                this.sizeY = texture.Height;
            }
        }

        // Draw.

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, new Rectangle((int)vect.X * sizeX, (int)vect.Y * sizeY, sizeX, sizeY), Color.White);
        }
    }
}
