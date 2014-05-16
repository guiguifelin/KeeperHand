using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game
{
    class ParticleGenerator
    {
        // Fields.
        private Texture2D texture;
        private float spawnWidth, density, timer, lifeTime;
        private List<Particle> particle = new List<Particle>();
        private Random rand1, rand2;

        // Constructor.

        public ParticleGenerator(Texture2D texture, float SpawnWidth, float Density, float lifeTime)
        {
            this.texture = texture;
            this.spawnWidth = SpawnWidth;
            this.density = Density;
            this.lifeTime = lifeTime;
            rand1 = new Random();
            rand2 = new Random();
        }

        // Get & Set.

        // Methods.

        public void createParticule()
        {
            double anything = rand1.Next();
            float randomX = (float)rand1.NextDouble();

            for (int i = 0; i < 6; i++)
			{
			    particle.Add(new Particle(texture, new Vector2(randomX * this.spawnWidth, -100)));
			}
        }

        // Update & Draw.

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            while (timer >= 0)
            {
                timer -= 1f / density;
                createParticule();
            }

            for (int i = 0; i < particle.Count; i++)
            {
                particle[i].Update();

                if (timer > lifeTime)
                {
                    particle.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Particle particule in particle)
            {
                particule.Draw(spriteBatch);
            }
        }
    }
}
