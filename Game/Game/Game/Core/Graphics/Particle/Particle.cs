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

        // Constructor.

        public Particle(Texture2D texture, Vector2 vectPos)
        {
            this.texture = texture;
            this.position = vectPos;
            this.velocity = new Vector2(0, 0);
            this.physics = new Physics(0.15f);
        }

        // Get & Set.

        public Vector2 Position
        {
            get { return position; }
        }

        // Methods.

        // Update & Draw.

        public void Update()
        {
            this.position += this.velocity;
            this.velocity.Y = physics.MakeGravity(this.velocity);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.position, Color.White);
        }
    }
}
