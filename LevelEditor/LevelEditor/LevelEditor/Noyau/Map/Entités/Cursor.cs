using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LevelEditor
{
    class Cursor : HUDState
    {
        // Fields.
        private Texture2D texture;
        private Vector2 position;
        private Rectangle hitbox;
        private int i, intState, timer;
        private int sizeX, sizeY;

        /* Collisions. */
        private Color[] textureData;

        // Constructor.

        public Cursor(int sizeRectX, int sizeRectY, int state)
        {
            this.texture = Ressources.cursor;
            this.i = 1;
            this.intState = state;
            this.sizeX = texture.Width / intState;
            this.sizeY = texture.Height;
            this.hitbox = new Rectangle(0, 0, sizeRectX, sizeRectY);
            this.timer = 0;

            /* Init : Collisions */
            this.textureData = new Color[Ressources.cursorData1.Width * Ressources.cursorData1.Height];
        }

        // Get & Set.

        public Rectangle Hitbox
        {
            get { return hitbox; }
        }

        public Color[] TextureData
        {
            get { return textureData; }
        }

        // Methods.

        private void SetPositionHitbox()
        {
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;
        }

        private void UpdateME(GameTime gameTime, KeyboardState key)
        {
            if (key.IsKeyDown(Keys.A))
            {
                timer += gameTime.ElapsedGameTime.Milliseconds;
                if (timer > 125 && DrawModeEdition)
                {
                    DrawModeEdition = false;
                    timer = 0;
                }
                else if (timer > 125)
                {
                    DrawModeEdition = true;
                    timer = 0;
                }
            }
        }

        // Update & Draw.

        public void Update(GameTime gameTime, MouseState mouse, KeyboardState keyboard)
        {
            position = new Vector2(mouse.X, mouse.Y);
            SetPositionHitbox();

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                this.i = 2;
            }
            else if (mouse.LeftButton == ButtonState.Released)
            {
                this.i = 1;
            }

            /* Mode Edition */
            UpdateME(gameTime, keyboard);

            /* Collisions */
            switch (i)
            {
                case 1:
                    Ressources.cursorData1.GetData(textureData);
                    break;
                case 2:
                    Ressources.cursorData2.GetData(textureData);
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, new Rectangle((i - 1) * (texture.Width / intState), 0, sizeX, sizeY), Color.White);
        }
    }
}
