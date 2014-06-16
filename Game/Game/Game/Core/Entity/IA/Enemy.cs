using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class Enemy
    {
        // Fields.
        private Texture2D tileset;
        private Vector2 position;
        private Vector2 velocity;
        private Rectangle hitbox;
        private float distance, oldDistance;
        private bool right, looking, died;
        private int frameX, frameY;
        private float iaDistanceX, iaDistanceY, vision;
        private float duration, currentTime;
        private bool goblin, troll, magician, elf;
        private Color[] textureData;
        private float currentTimeDie, durationDie;
        private float dps_goblin, dpsGoblin_currentTime;

        // Constructor.
        public Enemy(Texture2D tileset, Vector2 position, float distance, float vision, 
            bool goblin, bool troll, bool magician, bool elf)
        {
            this.tileset = tileset;
            this.durationDie = 3f;
            this.currentTimeDie = 0f;
            this.textureData = new Color[(tileset.Width / 4) * (tileset.Height / 4)];
            this.goblin = goblin;
            this.magician = magician;
            this.troll = troll;
            this.elf = elf;
            this.vision = vision;
            this.position = position;
            this.velocity = new Vector2(0, 0);
            this.hitbox = new Rectangle((int)position.X, (int)position.Y, tileset.Width / 4, tileset.Height / 4);
            this.distance = distance;
            this.oldDistance = distance;
            this.frameX = 0;
            this.frameY = 0;
            this.duration = 0.1f;
            this.currentTime = 0f;
            this.dpsGoblin_currentTime = 0f;
            this.dps_goblin = 0.5f;
            this.looking = false;
            this.died = false;
        }

        // Get & Set.
        public Rectangle Hitbox
        {
            get { return hitbox; }
            set { hitbox = value; }
        }
        public Color[] TextureData
        {
            get { return textureData; }
        }
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public bool Died
        {
            get { return died; }
        }

        // Methods.
        private void AnimateEnemy(ref float currentTime)
        {
            if (velocity.X > 0)
            {
                frameY = 2;
            }
            else if (velocity.X < 0)
            {
                frameY = 1;
            }
            else if (velocity.Y > 0)
            {
                frameY = 0;
            }
            else if (velocity.Y < 0)
            {
                frameY = 3;
            }
            if (currentTime >= duration && frameX >= 0 && frameX < 3)
            {
                frameX++;
                currentTime -= duration;
            }
            else if(currentTime >= duration)
            {
                frameX = 0;
                currentTime -= duration;
            }
            switch (frameY)
            {
                case 0:
                    switch (frameX)
                    {
                        case 0:
                            if(goblin)
                                Ressources.t_goblin_down1.GetData(textureData);
                            break;
                        case 1:
                            if (goblin)
                                Ressources.t_goblin_down2.GetData(textureData);
                            break;
                        case 2:
                            if (goblin)
                                Ressources.t_goblin_down3.GetData(textureData);
                            break;
                        case 3:
                            if (goblin)
                                Ressources.t_goblin_down4.GetData(textureData);
                            break;
                    }
                    break;
                case 1:
                    switch (frameX)
                    {
                        case 0:
                            if (goblin)
                                Ressources.t_goblin_left1.GetData(textureData);
                            break;
                        case 1:
                            if (goblin)
                                Ressources.t_goblin_left2.GetData(textureData);
                            break;
                        case 2:
                            if (goblin)
                                Ressources.t_goblin_left3.GetData(textureData);
                            break;
                        case 3:
                            if (goblin)
                                Ressources.t_goblin_left4.GetData(textureData);
                            break;
                    }
                    break;
                case 2:
                    switch (frameX)
                    {
                        case 0:
                            if (goblin)
                                Ressources.t_goblin_right1.GetData(textureData);
                            break;
                        case 1:
                            if (goblin)
                                Ressources.t_goblin_right2.GetData(textureData);
                            break;
                        case 2:
                            if (goblin)
                                Ressources.t_goblin_right3.GetData(textureData);
                            break;
                        case 3:
                            if (goblin)
                                Ressources.t_goblin_right4.GetData(textureData);
                            break;
                    }
                    break;
                case 3:
                    switch (frameX)
                    {
                        case 0:
                            if (goblin)
                                Ressources.t_goblin_up1.GetData(textureData);
                            break;
                        case 1:
                            if (goblin)
                                Ressources.t_goblin_up2.GetData(textureData);
                            break;
                        case 2:
                            if (goblin)
                                Ressources.t_goblin_up3.GetData(textureData);
                            break;
                        case 3:
                            if (goblin)
                                Ressources.t_goblin_up4.GetData(textureData);
                            break;
                    }
                    break;
            }
        }

        // Update & Draw.
        public void Update(GameTime time, List<IA> IAs)
        {
            currentTime += (float)time.ElapsedGameTime.TotalSeconds;
            dpsGoblin_currentTime += (float)time.ElapsedGameTime.TotalSeconds;
            currentTimeDie += (float)time.ElapsedGameTime.TotalSeconds;
            position += velocity;
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;
            AnimateEnemy(ref currentTime);

            if (!looking && distance <= 0)
            {
                right = true;
                velocity.X = 1f;
            }
            else if (!looking && distance >= oldDistance)
            {
                right = false;
                velocity.X = -1f;
            }
            if (right) distance += 1f; else distance -= 1f;

            foreach (IA ia in IAs)
            {
                iaDistanceX = ia.Hitbox.X - (position.X + (tileset.Width / 4) / 2);
                iaDistanceY = ia.Hitbox.Y - (position.Y + +(tileset.Height / 4) / 2);
                /* Patrouille en X */
                if (iaDistanceX >= -vision && iaDistanceX <= vision && (iaDistanceY >= -vision && iaDistanceY <= vision))
                {
                    if (iaDistanceX < -1)
                    {
                        velocity.X = -2.5f;
                    }
                    else if (iaDistanceX > 1)
                    {
                        velocity.X = 2.5f;
                    }
                    else if (iaDistanceX == 0)
                    {
                        velocity.X = 0f;
                    }
                    if (iaDistanceY < -1)
                    {
                        velocity.Y = -2.5f;
                    }
                    else if (iaDistanceY > 1)
                    {
                        velocity.Y = 2.5f;
                    }
                    else if (iaDistanceY == 0)
                    {
                        velocity.Y = 0f;
                    }
                    looking = true;
                }
                else { looking = false; }
                if (CollisionPerPixel.InsersectsPixel(this.hitbox, this.textureData, ia.Hitbox, ia.TextureData))
                {
                    if (goblin)
                    {
                        if (currentTimeDie >= durationDie)
                        {
                            died = true;
                            currentTimeDie -= durationDie;
                        }
                        else { died = false; }
                        if (dpsGoblin_currentTime >= dps_goblin)
                        {
                            ia.MinusLife(3);
                            dpsGoblin_currentTime -= dps_goblin;
                        }
                    }
                    if (troll)
                    {

                    }
                    if (magician)
                    {

                    }
                    if (elf)
                    {

                    }
                }
                else
                {
                    currentTimeDie = 0f;
                    dpsGoblin_currentTime = 0f;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tileset, hitbox, new Rectangle(frameX * (tileset.Width / 4), frameY * (tileset.Height / 4), tileset.Width / 4, tileset.Height / 4), Color.White);
        }
    }
}
