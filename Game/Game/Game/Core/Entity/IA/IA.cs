using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


namespace Game
{
    public class IA : AbstractCaracter
    {
        // Fields.
        private bool newPath, currentMoveX, currentMoveY;
        private int currentVelocityX, currentVelocityY;
        private Random rand;
        private Rectangle currentChest;
        private float currentTime, duration, currentOutTime, outTimeDuration;
        private float prev_PosX, prev_PosY;
        public bool online, local, solo, IsCollision;
        private Vector2 prev_Velocity;
        private int aleaDirection;

        // Constructor.

        public IA(Texture2D texture, int xStart, int yStart, int sizeX, int sizeY, int life, int maxLife)
        {
            this.texture = texture;
            this.rand = new Random();
            this.slowMoveEnabled = false;
            this.life = life;
            this.maxLife = maxLife;
            this.Velocity = new Vector2(0, 0);
            this.attack = false;
            this.disable = false;
            this.take = false;
            this.animation = true;
            this.hitbox = new Rectangle(xStart, yStart, sizeX, sizeY);
            this.State = IAState.Standby;
            hitTexture = Ressources.t_ia_2;
            this.animateX = 2;
            this.animateY = 0;
            textureData = new Color[hitTexture.Width * hitTexture.Height];
            hitTexture.GetData(textureData);
            this.tempo = 0;
            this.lightEnabled = true;
            this.newPath = true;
            this.currentMoveX = true;
            this.currentMoveY = false;
            this.duration = 8f;
            this.currentTime = 0f;
            this.currentVelocityX = rand.Next(0, 101);
            this.currentVelocityY = rand.Next(0, 101);
            this.online = false;
            this.local = false;
            this.solo = false;
            this.prev_PosX = 0f;
            this.prev_PosY = 0f;
            this.currentOutTime = 0f;
            this.outTimeDuration = 1.5f;
            this.IsCollision = false;
            this.aleaDirection = rand.Next(0, 2);
        }

        // Get & Set.
        public int Life
        {
            get { return life; }
        }
        public bool SlowMoveEnabled
        {
            get { return slowMoveEnabled; }
            set { slowMoveEnabled = value; }
        }

        // Methods.
        public void MinusLife(int damage)
        {
            if (life > damage)
            {
                life -= damage;
            }
            else
            {
                life = 0;
            }
        }

        private void MoveIA(List<Chest> chests)
        {
            Rectangle origin = new Rectangle(hitbox.X + (hitbox.Width / 2), hitbox.Y + (hitbox.Height / 2), hitbox.Width, hitbox.Height);
            
            if((origin.X == currentChest.X || origin.X == currentChest.X + 1 || origin.X == currentChest.X - 1) && currentMoveX)
            {
                velocity.X = 0f;
                currentMoveX = false;
                currentMoveY = true;
                Console.WriteLine("[IA] Fin de parcours en X.");
            }
            else if (currentChest.X < origin.X && currentMoveX)
            {
                if (currentVelocityX != 1)
                {
                    velocity.X = -2f;
                }
                else
                {
                    velocity.X = -3f;
                }
            }
            else if (currentChest.X > origin.X && currentMoveX)
            {
                if (currentVelocityX != 1)
                {
                    velocity.X = 2f;
                }
                else
                {
                    velocity.X = 3f;
                }
            }

            if ((origin.Y == currentChest.Y || origin.Y == currentChest.Y + 1 || origin.Y == currentChest.Y - 1) && currentMoveY)
            {
                velocity.Y = 0f;
                currentMoveY = false;
                Console.WriteLine("[IA] Fin de parcours en Y.");
            }
            else if (currentChest.Y < origin.Y && currentMoveY)
            {
                if (currentVelocityY != 99)
                {
                    velocity.Y = -2f;
                }
                else
                {
                    velocity.Y = -3f;
                }
            }
            else if (currentChest.Y > origin.Y && currentMoveY)
            {
                if (currentVelocityY != 99)
                {
                    velocity.Y = 2f;
                }
                else
                {
                    velocity.Y = 3f;
                }
            }

            if ((origin.X == currentChest.X || origin.X == currentChest.X + 1 || origin.X == currentChest.X - 1) &&
                (origin.Y == currentChest.Y || origin.Y == currentChest.Y + 1 || origin.Y == currentChest.Y - 1))
            {
                Console.WriteLine("[IA] Choix d'un nouveau coffre...");
                newPath = true;
                currentMoveX = false;
                currentMoveY = false;
            }
        }

        private void RandomVelocity()
        {
            if (currentTime >= duration)
            {
                currentVelocityX = rand.Next(0, 101);
                currentVelocityY = rand.Next(0, 101);
                currentTime -= duration;
            }
        }

        private void IsVisible()
        {
            float distance = (float)Math.Sqrt((Mouse.GetState().X - hitbox.X) * (Mouse.GetState().X - hitbox.X) + (Mouse.GetState().Y - hitbox.Y) * (Mouse.GetState().Y - hitbox.Y));
            if (distance <= 50f)
            {
                if (rand.Next(0, 21) != 20)
                {
                    lightEnabled = !lightEnabled;
                    if (currentMoveX && rand.Next(0, 51) == 2)
                    {
                        velocity.X += 0.5f;
                    }
                    if (currentMoveY && rand.Next(0, 51) == 49)
                    {
                        velocity.Y += 0.5f;
                    }
                }
            }
        }

        private void MoveOutObstacles()
        {
            if (currentOutTime >= outTimeDuration)
            {
                aleaDirection = rand.Next(0, 2);
                currentOutTime -= outTimeDuration;
                IsCollision = false;
                newPath = true;
                velocity = new Vector2(0, 0);
                currentMoveX = !currentMoveX;
                currentMoveY = !currentMoveY;
                Console.WriteLine("[IA] Fin auto. control.");
            }
            else
            {
                if (prev_Velocity.X < 0) // Gauche.
                {
                    if (aleaDirection == 0)
                    {
                        velocity = new Vector2(0, 2);
                    }
                    else
                    {
                        velocity = new Vector2(0, -2);
                    }
                }
                else if (prev_Velocity.X > 0) // Droite.
                {
                    if (aleaDirection == 1)
                    {
                        velocity = new Vector2(0, -2);
                    }
                    else
                    {
                        velocity = new Vector2(0, 2);
                    }
                }
                else if (prev_Velocity.Y > 0) // Bas.
                {
                    if (aleaDirection == 0)
                    {
                        velocity = new Vector2(2, 0);
                    }
                    else
                    {
                        velocity = new Vector2(-2, 0);
                    }
                }
                else if (prev_Velocity.Y < 0) // Haut.
                {
                    if (aleaDirection == 1)
                    {
                        velocity = new Vector2(-2, 0);
                    }
                    else
                    {
                        velocity = new Vector2(2, 0);
                    }
                }
            }
        }

        // Update & Draw.
        public void Update(GameTime time, KeyboardState keyboard, List<Chest> chests)
        {
            /* General */
            currentTime += (float)time.ElapsedGameTime.TotalSeconds;
            currentOutTime += (float)time.ElapsedGameTime.TotalSeconds;

            prev_PosX = hitbox.X;
            prev_PosY = hitbox.Y;
            if (!IsCollision)
            {
                prev_Velocity = velocity;
            }
            hitbox.X += (int)Velocity.X;
            hitbox.Y += (int)Velocity.Y;

            AnimateIA();
            UpdateMovement();

            /* Solo */
            if (solo)
            {
                RandomVelocity();
                IsVisible();
            }

            /* MultiLocal */
            if (local)
            {
                ControledAI(keyboard);
            }
            
            /* Online */
            if (online)
            {
                // Code ONLINE
            }

            if (solo && newPath)
            {
                Chest chest = chests[rand.Next(0, chests.Count)];
                currentChest = new Rectangle(chest.Hitbox.X + (chest.Hitbox.Width / 2), chest.Hitbox.Y + (chest.Hitbox.Height / 2), chest.Hitbox.Width, chest.Hitbox.Height);
                newPath = false;
                currentMoveX = true;
                currentMoveY = false;
                Console.WriteLine("[IA] Nouveau coffre defini.");
            }
            else if(solo)
            {
                if (!IsCollision)
                {
                    MoveIA(chests);
                    currentOutTime = 0;
                }
                else
                {
                    Console.WriteLine("[IA] Auto Control.");
                    MoveOutObstacles();
                }
            }

            SlowMove(time);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, new Rectangle(animateX * (texture.Width / 3), animateY * (texture.Height / 4), texture.Width / 3, texture.Height / 4), Color.White);
            spriteBatch.Draw(Ressources.k_money, new Rectangle(hitbox.X - 25, hitbox.Y - 20, (life * 100) / maxLife, 10), new Rectangle(0, 0, 361, 27), Color.Red);
        }
    }
}
