using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game
{
    public class Chest
    {
        // Fields.
        private Texture2D tileset, t_textureData;
        private Vector2 position, velocity;
        private Rectangle hitbox;
        private Color[] textureData;
        private int moneyContent, life, maxLife, frame;
        private bool enabledMove, opened;
        private float currentTime, countDuration;

        // Constructor.
        public Chest(Texture2D tileset, Texture2D t_textureData, Vector2 position, bool enabledMove,
            int moneyContent, int life, int maxLife)
        {
            this.tileset = tileset;
            this.frame = 1;
            this.currentTime = 0f;
            this.countDuration = 1f;
            this.t_textureData = t_textureData;
            this.position = position;
            this.enabledMove = enabledMove;
            this.opened = false;
            this.moneyContent = moneyContent;
            this.life = life;
            this.maxLife = maxLife;
            this.hitbox = new Rectangle((int)position.X, (int)position.Y, t_textureData.Height, t_textureData.Width);
            this.textureData = new Color[t_textureData.Height * t_textureData.Width];
            this.t_textureData.GetData(textureData);
        }

        // Get & Set.
        public bool OPENED
        {
            get { return opened; }
        }
        public int LIFE
        {
            get { return life; }
        }
        public int MONEY
        {
            get { return moneyContent; }
        }
        public Rectangle Hitbox
        {
            get { return hitbox; }
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
        public void Update(GameTime time, List<IA> IAs)
        {
            currentTime += (float)time.ElapsedGameTime.TotalSeconds;
            foreach (IA ia in IAs)
            {
                if (CollisionPerPixel.InsersectsPixel(hitbox, textureData, ia.Hitbox, ia.TextureData))
                {
                    if (currentTime >= countDuration)
                    {
                        MinusLife(2);
                        currentTime -= countDuration;
                    }
                }
            }
            if (life == 0)
            {
                frame = 0;
                opened = true;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tileset, hitbox, new Rectangle(frame * t_textureData.Width, 0, t_textureData.Width, t_textureData.Height), Color.White);
            spriteBatch.Draw(Ressources.k_money, new Rectangle(hitbox.X - 20, hitbox.Y - 20, (life * 100) / maxLife, 10), new Rectangle(0, 0, 361, 27), Color.Green);
        }
    }
}
