using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LevelEditor
{
    class SelectionTile : HUDState
    {
        // Fields.
        private Texture2D texture;
        private Rectangle hitbox;

        // Constructor.

        public SelectionTile(Texture2D texture)
        {
            this.texture = texture;
        }

        // Get & Set.

        // Methods.

        // Update & Draw.

        public void Update(int sizeX, int sizeY, int x, int y)
        {
            hitbox = new Rectangle(x, y, sizeX, sizeY);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (EnabledSelection)
            {
                spriteBatch.Draw(texture, hitbox, Color.White);
            }
        }
    }
}
