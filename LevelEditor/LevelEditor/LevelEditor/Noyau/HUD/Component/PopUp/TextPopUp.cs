using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LevelEditor
{
    class TextPopUp
    {
        // Fields.

        SpriteFont font;
        string text;
        Vector2 vect;
        Color color;

        // Constructor.

        public TextPopUp(SpriteFont font, string text, Vector2 vector, Color color)
        {
            this.font = font;
            this.text = text;
            this.vect = vector;
            this.color = color;
        }

        // Get & Set.

        // Methods.

        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, vect, color);
        }
    }
}
