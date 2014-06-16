using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace MapEditor
{
    class Menu 
    {
        //Fields
        private Texture2D texture;
        private List<Button> lbutton = new List<Button>();

        //Constructors

        public Menu(Texture2D texture)
        {
            this.texture = texture;
        }
        //Get & Set

        //Methods
        public void AddButton(Button button)
        {
            lbutton.Add(button);
        }
        public void DeleteButtons()
        {
            lbutton.Clear();
        }

        //Update & Draw
        public void Update(Game1 game, GameTime time, Cursor cursor, MouseState mouse)
        {
            foreach (Button button in lbutton)
            {
                button.Update(game, cursor);
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, new Vector2(0, 0), Color.White);
            foreach (Button button in lbutton)
            {
                button.Draw(spritebatch);
            }
        }
    }
}
