using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game
{
    /// <summary>
    /// RAPPEL DE CE QU'IL FAUT FAIRE :
    /// 1) Gérer le nombre de particules générées afin de gérer l'apparition des pièces.
    /// 2) Recoder la classe "donjon" dans la .dll "SavingMap" et y ajouter une liste de "ArrayMap".
    /// 3) Commencer le solo avec la classe donjon.
    /// </summary>
    
    class ParticleGenerator
    {
        // Fields.
        private Texture2D texture;
        private float spawnWidth, density, timer, lifeTime;
        private List<Particle> particle = new List<Particle>();
        private Random rand1, rand2;
        private float gravity;
        private bool animated;
        private Vector2 position;
        private int nb_particles, nb;

        // Constructor.

        public ParticleGenerator(Texture2D texture, Vector2 position, float spawnWidth, float density, float lifeTime, float gravity, int nb_particles, bool animated)
        {
            this.texture = texture;
            this.nb_particles = nb_particles;
            this.position = position;
            this.spawnWidth = spawnWidth;
            this.density = density;
            this.lifeTime = lifeTime;
            this.animated = animated;
            this.gravity = gravity;
            this.nb = 0;
            rand1 = new Random();
            rand2 = new Random();
        }

        // Get & Set.

        // Methods.

        public void createParticule()
        {
            double anything = rand1.Next();
            float randomX = (float)rand1.NextDouble();

			particle.Add(new Particle(texture, new Vector2(position.X + (randomX * this.spawnWidth), position.Y), gravity, animated));
        }

        // Update & Draw.

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            while (timer >= 0 || (nb_particles != -1 && nb < nb_particles))
            {
                timer -= 1f / density;
                createParticule();
                nb++;
            }

            for (int i = 0; i < particle.Count; i++)
            {
                particle[i].Update(gameTime);

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
