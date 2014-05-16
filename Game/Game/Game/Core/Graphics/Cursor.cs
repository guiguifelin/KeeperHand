using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    public class Cursor
    {
        // Fields.
        #region Fields

        private Texture2D texture, t_data;
        private Rectangle rect;
        private Color[] textureData;
        private int state, sizeX, sizeY;

        #endregion

        // Constructor.

        public Cursor(Viewport viewport, MouseState mouse, int sizeX, int sizeY)
        {
            this.texture = Ressources.Cursor;
            this.t_data = Ressources.t_CursorState1;
            this.state = 0;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            /* Get array of color texture */
            textureData = new Color[t_data.Width * t_data.Height];
            t_data.GetData(textureData);
        }

        // Get & Set.
        #region Get & Set

        public Rectangle Rect
        {
            get { return rect; }
        }
        public Color[] TextureData
        {
            get { return textureData; }
        }

        #endregion

        // Methods.

        private void GetPositionCursor(MouseState mouse)
        {
            this.rect = new Rectangle((int)mouse.X, (int)mouse.Y, sizeX, sizeY);
        }

        // Update & Draw.

        public void Update(MouseState mouse)
        {
            /* Update position */
            GetPositionCursor(mouse);
            /* Update texture data */
            switch (mouse.LeftButton)
            {
                case ButtonState.Pressed:
                    t_data = Ressources.t_CursorState1;
                    state = 1;
                    break;
                case ButtonState.Released:
                    t_data = Ressources.t_CursorState2;
                    state = 0;
                    break;
            }
            t_data.GetData(textureData);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, new Rectangle(state * (texture.Width / 2), 0, texture.Width / 2, texture.Height), Color.White);
        }
    }
}
