using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    public class AbstractCaracter
    {
        // State
        public enum IAState
        {
            Standby,
            Up,
            Down,
            Left,
            Right
        }

        // Fields.
        protected Rectangle hitbox;
        protected Vector2 velocity;
        protected bool attack, disable, take, animation;
        protected Texture2D texture;
        protected Texture2D hitTexture;
        protected Color[] textureData;
        private IAState state;
        protected int animateX, animateY, tempo;
        protected int life, maxLife;
        protected float countDuration, currentTime;
        protected bool slowMoveEnabled;
        protected bool lightEnabled;

        // Get & Set.
        public Color[] TextureData
        {
            get { return textureData; }
        }
        public Rectangle Hitbox
        {
            get { return hitbox; }
            set { hitbox = value; }
        }
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public IAState State
        {
            get { return state; }
            set { state = value; }
        }
        public bool LightEnabled
        {
            get { return lightEnabled; }
        }

        // Methods.
        protected void AnimateIA()
        {
            switch (state)
            {
                case IAState.Standby:
                    /* Nothing */
                    break;
                case IAState.Up:
                    animateY = 3;
                    switch (animateX)
	                {
                        case 0:
                            hitTexture = Ressources.t_ia_10;
                            break;
                        case 1:
                            hitTexture = Ressources.t_ia_11;
                            break;
                        case 2:
                            hitTexture = Ressources.t_ia_12;
                            break;
	                }
                    break;
                case IAState.Down:
                    animateY = 0;
                    switch (animateX)
                    {
                        case 0:
                            hitTexture = Ressources.t_ia_1;
                            break;
                        case 1:
                            hitTexture = Ressources.t_ia_2;
                            break;
                        case 2:
                            hitTexture = Ressources.t_ia_3;
                            break;
                    }
                    break;
                case IAState.Left:
                    animateY = 1;
                    switch (animateX)
                    {
                        case 0:
                            hitTexture = Ressources.t_ia_4;
                            break;
                        case 1:
                            hitTexture = Ressources.t_ia_5;
                            break;
                        case 2:
                            hitTexture = Ressources.t_ia_6;
                            break;
                    }
                    break;
                case IAState.Right:
                    animateY = 2;
                    switch (animateX)
                    {
                        case 0:
                            hitTexture = Ressources.t_ia_7;
                            break;
                        case 1:
                            hitTexture = Ressources.t_ia_8;
                            break;
                        case 2:
                            hitTexture = Ressources.t_ia_9;
                            break;
                    }
                    break;
            }
            hitTexture.GetData(textureData);
            tempo++;
            if (tempo >= 10 && state != IAState.Standby && animateX <= 2)
            {
                if (animation)
                {
                    tempo = 0;
                    animateX++;
                }
                else
                {
                    tempo = 0;
                    animateX--;
                }
            }
            else if (state != IAState.Standby && animateX > 2)
            {
                animateX = 2;
                animation = false;
            }
            else if (state != IAState.Standby && animateX < 0)
            {
                animateX = 0;
                animation = true;
            }
        }
        protected void UpdateMovement()
        {
            if (velocity.X > 0f && velocity.Y == 0f)
            {
                state = IAState.Right;
            }
            else if (velocity.X == 0f && velocity.Y > 0f)
            {
                state = IAState.Down;
            }
            else if (velocity.X < 0f && velocity.Y == 0f)
            {
                state = IAState.Left;
            }
            else if (velocity.X == 0f && velocity.Y < 0f)
            {
                state = IAState.Up;
            }
            else
            {
                state = IAState.Standby;
            }
        }
        protected void ControledAI(KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.Up))
            {
                velocity = new Vector2(0, -2);
            }
            else
            {
                if (keyboard.IsKeyDown(Keys.Down))
                {
                    velocity = new Vector2(0, 2);
                }
                else
                {
                    if (keyboard.IsKeyDown(Keys.Right))
                    {
                        velocity = new Vector2(2, 0);
                    }
                    else
                    {
                        if (keyboard.IsKeyDown(Keys.Left))
                        {
                            velocity = new Vector2(-2, 0);
                        }
                        else
                        {
                            velocity = new Vector2(0, 0);
                        }
                    }
                }
            }
            if (Inputs.isKeyRelease(Keys.RightShift))
            {
                lightEnabled = !lightEnabled;
            }
        }
        protected void SlowMove(GameTime time)
        {
            if (slowMoveEnabled)
            {
                countDuration = 3f;
                currentTime += (float)time.ElapsedGameTime.TotalSeconds;
                if (currentTime >= countDuration)
                {
                    slowMoveEnabled = false;
                    currentTime -= countDuration;
                }
                else
                {
                    if (velocity.X > 0)
                    {
                        velocity.X = -1f;
                    }
                    else if (velocity.X < 0)
                    {
                        velocity.X = 1f;
                    }
                    else if (velocity.Y > 0)
                    {
                        velocity.Y = -1f;
                    }
                    else if (velocity.Y < 0)
                    {
                        velocity.Y = 1f;
                    }
                }
            }
        }
    }
}
