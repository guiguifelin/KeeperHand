using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game
{
    class Physics
    {
        // Fields.

        private float gravity;

        // Constructor.

        public Physics(float gravity)
        {
            this.gravity = gravity;
        }

        // Get & Set.

        // Methods.

        public float MakeGravity(Vector2 vectVelocity)
        {
            float i = 1;
            vectVelocity.Y += this.gravity * i;
            return vectVelocity.Y;
        }
    }
}
