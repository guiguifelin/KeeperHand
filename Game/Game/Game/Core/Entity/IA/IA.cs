using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


namespace Game
{
    public class IA : AbstractCaracter
    {
        // Fields.

        // Constructor.

        public IA(Texture2D texture, int xStart, int yStart, int sizeX, int sizeY, int life, int maxLife)
        {
            this.texture = texture;
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

        // Update & Draw.
        public void Update(GameTime time, KeyboardState keyboard)
        {
            hitbox.X += (int)Velocity.X;
            hitbox.Y += (int)Velocity.Y;
            AnimateIA();
            UpdateMovement();
            ControledAI(keyboard);
            SlowMove(time);
            if (keyboard.IsKeyDown(Keys.H))
            {
                MinusLife(4);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, new Rectangle(animateX * (texture.Width / 3), animateY * (texture.Height / 4), texture.Width / 3, texture.Height / 4), Color.White);
            spriteBatch.Draw(Ressources.k_money, new Rectangle(hitbox.X - 25, hitbox.Y - 20, (life * 100) / maxLife, 10), new Rectangle(0, 0, 361, 27), Color.Red);
        }
    }
}
