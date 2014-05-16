using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace LevelEditor
{
    class Button : ButtonFonctions
    {
        // Fields.
        private enum BackButtonState
        {
            Pressed, Released
        };

        private Texture2D texture;
        private Cursor cursor;
        private Color[] textureData;
        private Rectangle hitbox;
        private string title;
        private Color colorTitle, colorAlpha;
        private BackButtonState backState;

        // Constructor.

        public Button(Game1 game, Cursor cursor, Texture2D texture, Vector2 position, string function, string title)
        {
            this.game = game;
            this.texture = texture;
            this.cursor = cursor;
            this.hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            this.title = title;
            this.colorTitle = Color.Black;
            this.colorAlpha = Color.White;
            this.function = function;
            this.backState = BackButtonState.Released;

            /* Collsions */
            this.textureData = new Color[this.texture.Width * this.texture.Height];
            this.texture.GetData(this.textureData);
        }

        // Get & Set.

        // Methods.

        // Update & Draw.

        public void Update(GameTime gameTime, MouseState mouse)
        {
            if (backState == BackButtonState.Released && mouse.LeftButton == ButtonState.Pressed && CollisionPerPixel.InsersectsPixel(hitbox, textureData, cursor.Hitbox, cursor.TextureData))
            {
                Function(this.function);
                backState = BackButtonState.Pressed;
            }
            else if (CollisionPerPixel.InsersectsPixel(hitbox, textureData, cursor.Hitbox, cursor.TextureData))
            {
                colorAlpha.A = 180;
                colorTitle = Color.White;
            }
            else
            {
                colorAlpha.A = 255;
                colorTitle = Color.Black;
            }

            if (mouse.LeftButton == ButtonState.Released && backState == BackButtonState.Pressed)
            {
                backState = BackButtonState.Released;
            }
        }

        public void Draw(SpriteBatch spriteBatch, int divX, int divY)
        {
            spriteBatch.Draw(texture, hitbox, colorAlpha);
            spriteBatch.DrawString(Ressources.font1, title, new Vector2(hitbox.X + (texture.Width / divX), (hitbox.Y - 10) + (texture.Height / divY)), colorTitle);
        }
    }
}
