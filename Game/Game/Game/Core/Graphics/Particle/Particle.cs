using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game
{
    class Particle
    {
        // Fields.
        private Vector2 position, velocity;
        private Texture2D texture;
        private Physics physics;
        private bool animated;
        private int frame;
        private float currentTime, duration;

        // Constructor.

        public Particle(Texture2D texture, Vector2 vectPos, float gravity, bool animated)
        {
            this.texture = texture;
            this.position = vectPos;
            this.animated = animated;
            this.currentTime = 0f;
            this.duration = 0.10f;
            this.velocity = new Vector2(0, 0);
            this.physics = new Physics(gravity);
        }

        // Get & Set.

        public Vector2 Position
        {
            get { return position; }
        }

        // Methods.
        private void Animate(bool animated)
        {
            if (currentTime >= duration)
            {
                if (frame < 3)
                {
                    frame++;
                }
                else
                {
                    frame = 0;
                }
                currentTime -= duration;
            }
        }

        // Update & Draw.

        public void Update(GameTime time)
        {
            this.currentTime += (float)time.ElapsedGameTime.TotalSeconds;
            this.position += this.velocity;
            this.velocity.Y = physics.MakeGravity(this.velocity);

            Animate(animated);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!animated)
            {
                spriteBatch.Draw(this.texture, this.position, Color.White);
            }
            else
            {
                spriteBatch.Draw(this.texture, new Rectangle((int)position.X, (int)position.Y, 17, (71 / 4)), new Rectangle(0, frame * (71 / 4), 17, (71 / 4)), Color.White);
            }
        }
    }
}
