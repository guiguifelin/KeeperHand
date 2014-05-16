using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class HUD
    {
         //Fields
        Texture2D texture;
        List<HUDButton> lbutton = new List<HUDButton>();
        //Constructors

        public HUD(Texture2D texture)
        {
            this.texture = texture;
            lbutton.Add(new HUDButton(Ressources.t_UnexpectedStep, new Rectangle(205, 30, 50, 50), "Unexpected Step", "UnexpectedStep"));
            lbutton.Add(new HUDButton(Ressources.t_Marbles, new Rectangle(267, 30, 50, 50), "Marbles", "Marbles"));
            lbutton.Add(new HUDButton(Ressources.t_HotStep, new Rectangle(335, 30, 50, 50), "Hot Step", "HotStep"));
            lbutton.Add(new HUDButton(Ressources.t_Needle, new Rectangle(399, 30, 50, 50), "Needle", "Needle"));
            lbutton.Add(new HUDButton(Ressources.t_Frozen, new Rectangle(482, 30, 50, 50), "Frozen", "Frozen"));
            lbutton.Add(new HUDButton(Ressources.t_Juste1Second, new Rectangle(548, 30, 50, 50), "Hourglass", "Hourglass"));
            lbutton.Add(new HUDButton(Ressources.t_AttractiveNoise, new Rectangle(610, 30, 50, 50), "Attractive Noise", "AttractiveNoise"));
            lbutton.Add(new HUDButton(Ressources.t_LostMyGlasses, new Rectangle(678, 30, 50, 50), "Lost My Glasses", "LostMyGlasses"));
            lbutton.Add(new HUDButton(Ressources.t_Gobelin, new Rectangle(762, 30, 50, 50), "Gobelin", "Gobelin"));
            lbutton.Add(new HUDButton(Ressources.t_Elf, new Rectangle(827, 30, 50, 50), "Elf", "Elf"));
            lbutton.Add(new HUDButton(Ressources.t_Wizard, new Rectangle(890, 30, 50, 50), "Wizard", "Wizard"));
            lbutton.Add(new HUDButton(Ressources.t_Troll, new Rectangle(957, 30, 50, 50), "Troll", "Troll"));
            lbutton.Add(new HUDButton(Ressources.t_bmenu, new Rectangle(1040, 28, 162, 50), "Menu", "PAUSE"));
        }

        //Get & Set

        //Methods

        //Update & Draw
        public void Update(Cursor cursor, MouseState mouse, GameTime gt)
        {
            foreach (HUDButton button in lbutton)
            {
                button.Update(cursor, mouse, gt);
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, new Vector2(187, 4), Color.White);
            foreach (HUDButton button in lbutton)
            {
                button.Draw(spritebatch);
            }
        }
    }
}
