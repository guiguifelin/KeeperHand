using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    class HUDButton : HUDEffects
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

        public HUDButton(Texture2D texture, Rectangle rect, string name, string effect)
        {
            this.font = Ressources.font;
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
        public void Update(Cursor cursor, MouseState mouse, GameTime gt)
        {
            if (CollisionPerPixel.InsersectsPixel(rect, texture_data, cursor.Rect, cursor.TextureData) && Inputs.isLMBClick())
            {
                color = Color.Gray;
                function(this.effect);
            }
            else
            {
                if (CollisionPerPixel.InsersectsPixel(rect, texture_data, cursor.Rect, cursor.TextureData))
                {
                    color = Color.Red;
                }
                else
                {
                    color = Color.White;
                }
            }
           
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, rect, color);
        }

    }
}
