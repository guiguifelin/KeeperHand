using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public delegate void DrawMain(SpriteBatch spriteBatch);
    public class LightingEngine
    {
        // Fields.
        private GraphicsDevice graphicsDevice;
        private RenderTarget2D lightMask;
        private Effect lightingEffect;
        private Texture2D blackSquare, lightmask;
        private List<Rectangle> vectors;
        private Game1 game;

        // Constructor.
        public LightingEngine(Game1 game)
        {
            this.game = game;
            this.graphicsDevice = game.GraphicsDevice;
            this.lightingEffect = Ressources.lighting;
            this.lightmask = Ressources.lightmask;
            this.blackSquare = Ressources.blackSquare;
            this.lightMask = new RenderTarget2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth,
                graphicsDevice.PresentationParameters.BackBufferHeight);
            this.vectors = new List<Rectangle>();
        }
        /* Continuer le moteur de lumière en s'inspirant du LightingDemo ! (Les textures ont été chargées !)*/

        // Get & Set.

        // Methods.
        private void DrawLightMask(SpriteBatch spriteBatch)
        {
            graphicsDevice.SetRenderTarget(lightMask);
            graphicsDevice.Clear(Color.Black);

            /* Draw a black screen */
            spriteBatch.Draw(Ressources.blackSquare, new Vector2(0, 0), new Rectangle(0, 0, 1280, 740), Color.White);

            /* Draw the lightmask */
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, null, null, null, null, game.CAMERA.Transform);
            foreach (Rectangle vector in vectors)
            {
                spriteBatch.Draw(lightmask, vector, Color.White);
            }
            graphicsDevice.SetRenderTarget(null);
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, game.CAMERA.Transform);
        }

        public void AddVector(Rectangle vector)
        {
            vectors.Add(vector);
        }

        public void UpdateVectors(List<Rectangle> vectors)
        {
            this.vectors.Clear();
            foreach (Rectangle vector in vectors)
            {
                this.vectors.Add(vector);
            }
        }

        // Update & Draw.
        public void Update(GameTime time)
        {

        }

        public void Draw(SpriteBatch spriteBatch, RenderTarget2D mainScene, DrawMain drawMain)
        {
            graphicsDevice.Clear(Color.Black);
            drawMain(spriteBatch);
            DrawLightMask(spriteBatch);

            graphicsDevice.Clear(Color.Black);
            graphicsDevice.SamplerStates[1] = SamplerState.LinearClamp;

            lightingEffect.Parameters["lightMask"].SetValue(lightMask);
            lightingEffect.CurrentTechnique.Passes[0].Apply();
            spriteBatch.Draw(mainScene, new Vector2(0, 0), Color.White);
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, game.CAMERA.Transform);
        }
    }
}
