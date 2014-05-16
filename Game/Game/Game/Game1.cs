using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Game
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Main game;
        VideoManager introVideo;
        Camera camera;

        #region Get GAME1
        public GraphicsDeviceManager GRAPHICS
        {
            get { return graphics; }
        }
        public Main MAIN
        {
            get { return this.game; }
        }
        public SpriteBatch SPRITEBATCH
        {
            get { return spriteBatch; }
        }
        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "Keeper Hand";
            graphics.PreferredBackBufferWidth = 1240;
            graphics.PreferredBackBufferHeight = 720;
        }

        protected override void Initialize()
        {
            AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.Introduction;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Ressources.LoadContent(Content);

            game = new Main(GraphicsDevice.Viewport);
            camera = new Camera(GraphicsDevice.Viewport);
            introVideo = new VideoManager(Ressources.intro);

            #region APPLYSTATES
            if (MAIN.OPTIONS.STATES.FULLSCREENMODE)
            {
                graphics.ToggleFullScreen();
            }
            #endregion
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            camera.Update();

            if (introVideo.Level)
            {
                if (AbstractStateGame.IsLoop == false)
                {
                    AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.MainMenu;
                    AbstractStateGame.IsLoop = true;
                }
                game.Update(this, gameTime);
            }
            else
            {
                introVideo.Update(Keyboard.GetState());
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);

            if (introVideo.Level)
            {
                game.Draw(gameTime, spriteBatch, GraphicsDevice.Viewport);
            }
            else
            {
                introVideo.Draw(spriteBatch, GraphicsDevice.Viewport);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
