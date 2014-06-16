using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    class VideoManager
    {
        // Fields.

        private Texture2D texture;
        private Video video;
        private VideoPlayer videoP;
        private bool level;

        // Constructor.

        public VideoManager(Video video)
        {
            this.video = video;
            this.level = false;
            this.videoP = new VideoPlayer();

            if (level == false)
            {
                videoP.Play(video);
            }
        }

        // Get & Set.

        public bool Level
        {
            get { return level; }
            set { level = value; }
        }

        // Methods.

        public void IsLoop(bool enabled)
        {
            videoP.IsLooped = enabled;
        }

        public void Playing()
        {
            videoP.Play(video);
        }

        public void Dispose()
        {
            videoP.Dispose();
        }

        // Update & Draw.

        public void Update(KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.W) && keyboard.IsKeyDown(Keys.T) && keyboard.IsKeyDown(Keys.F))
            {
                level = true;
            }
            switch (level)
            {
                case true:
                    videoP.Stop();
                    break;
                default:
                    if (videoP.State == MediaState.Stopped)
                    {
                        level = true; 
                    }
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Viewport viewport)
        {
            if (videoP.State != MediaState.Stopped)
            {
                texture = videoP.GetTexture();
            }
            if (texture != null && level == false)
            {
                spriteBatch.Draw(texture, viewport.Bounds, Color.White);
            }
        }
    }
}
