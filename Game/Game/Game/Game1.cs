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
        LightingEngine lights;
        RenderTarget2D mainScene, foreground;
        VideoManager introVideo;
        Camera camera;
        BlendState blendState;
        Console console;

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
        public LightingEngine LIGHTENGINE
        {
            get { return lights; }
        }
        public RenderTarget2D MainScene
        {
            get { return mainScene; }
        }
        public RenderTarget2D Foreground
        {
            get { return foreground; }
        }
        public Camera CAMERA
        {
            get { return camera; }
        }
        public BlendState BLENDSTATE
        {
            get { return blendState; }
            set { blendState = value; }
        }
        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "Keeper Hand";
            graphics.PreferredBackBufferWidth = 1240;
            graphics.PreferredBackBufferHeight = 720;
            blendState = BlendState.AlphaBlend;
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

            console = new Console();
            mainScene = new RenderTarget2D(graphics.GraphicsDevice, graphics.GraphicsDevice.PresentationParameters.BackBufferWidth, graphics.GraphicsDevice.PresentationParameters.BackBufferHeight);
            foreground = new RenderTarget2D(graphics.GraphicsDevice, graphics.GraphicsDevice.PresentationParameters.BackBufferWidth, graphics.GraphicsDevice.PresentationParameters.BackBufferHeight);
            game = new Main(this, GraphicsDevice.Viewport);
            camera = new Camera(GraphicsDevice.Viewport);
            introVideo = new VideoManager(Ressources.intro);
            lights = new LightingEngine(this);

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
            lights.Update(gameTime);
            console.Update();

            if (introVideo.Level)
            {
                if (AbstractStateGame.IsLoop == false)
                {
                    AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.Update;
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

            spriteBatch.Begin(SpriteSortMode.Immediate, blendState, null, null, null, null, camera.Transform);
            if (introVideo.Level)
            {
                game.Draw(gameTime, spriteBatch, GraphicsDevice.Viewport);
            }
            else
            {
                introVideo.Draw(spriteBatch, GraphicsDevice.Viewport);
            }
            console.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
