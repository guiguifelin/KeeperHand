using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LevelEditor
{
    class Tile
    {
        // Fields.

        protected Texture2D texture;
        protected int x, y;
        protected int sizeX, sizeY;
        private Rectangle rectangle;

        // Constructor.

        // Get & Set.

        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value; }
        }

        // Methods.

        // Update & Draw.

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), Color.White);
        }
    }
}
