using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    class Button : Effects
    {
        //Fields
        private Rectangle rect;
        private Texture2D texture;
        private string name;
        private string effect; 
        private SpriteFont font;
        private Color[] texture_data;
        private Color color;

        //Constructors

        public Button(Texture2D texture, Rectangle rect, string name, string effect)
        {
            this.font = Ressources.medieval;
            this.texture = texture;
            this.name = name;
            this.effect = effect;
            this.rect = rect;
            this.texture_data = new Color[texture.Width * texture.Height];
            texture.GetData(texture_data);
            color = Color.White;
        }

        //Get & Set

        //Methods
        
        //Update & Draw
        public void Update(Game1 game, Cursor cursor, Sound soundManager, int beep, MouseState mouse)
        {
            if (CollisionPerPixel.InsersectsPixel(rect, texture_data, cursor.Rect, cursor.TextureData))
            {
                color = Color.Red;
            }
            else
            {
                color = Color.White;
            }
            if (CollisionPerPixel.InsersectsPixel(rect, texture_data, cursor.Rect, cursor.TextureData) && Inputs.isLMBClick())
            {
                soundManager.PlayNoise(beep);
                function(game, this.effect);
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, rect, color);
            spritebatch.DrawString(font, name, new Vector2(rect.X+(rect.Width/4),rect.Y+(rect.Height/3)), Color.Black);
        }

    }
}
