using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class TextInfo
    {
        // Fields.
        private string text;
        private Vector2 vector;
        private float duration, currentTime;
        private bool draw;

        // Constructor.
        public TextInfo(string text, Vector2 vector, float duration)
        {
            this.text = text;
            this.duration = duration;
            this.vector = vector;
            this.currentTime = 0;
            this.draw = false;
        }

        // Get & Set.

        // Methods.

        // Update & Draw.
        public void Update(GameTime time)
        {
            currentTime += (float)time.ElapsedGameTime.TotalSeconds;
            if (currentTime >= duration)
            {
                currentTime -= duration;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentTime < duration && draw)
            {
                spriteBatch.DrawString(Ressources.medieval, text, vector, Color.Red);
            }
        }

    }
}
