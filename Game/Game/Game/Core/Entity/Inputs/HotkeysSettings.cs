using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Game
{
    public class HotkeysSettings
    {
        // Fields.
        private Menu setting;
        private bool loaded;
        private bool trap1, trap2, trap3, trap4, spell1, spell2, spell3, spell4, mob1, mob2, mob3, mob4;

        // Constructor.
        public HotkeysSettings(Texture2D texture, ref Sound sm)
        {
            setting = new Menu(texture, ref sm);
            loaded = false;
            trap1 = false;
            trap2 = false;
            trap3 = false;
            trap4 = false;
            spell1 = false;
            spell2 = false;
            spell3 = false;
            spell4 = false;
            mob1 = false;
            mob2 = false;
            mob3 = false;
            mob4 = false;
        }

        // Methods. /* 172x60 */
        private void AddButtons(Game1 game)
        {
            setting.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(330, 350, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), game.MAIN.OPTIONS.TEXTMANAGER.TRAP1, "SETTRAP1"));
            setting.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(330, 435, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), game.MAIN.OPTIONS.TEXTMANAGER.TRAP2, "SETTRAP2"));
            setting.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(330, 520, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), game.MAIN.OPTIONS.TEXTMANAGER.TRAP3, "SETTRAP3"));
            setting.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(330, 605, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), game.MAIN.OPTIONS.TEXTMANAGER.TRAP4, "SETTRAP4"));
            setting.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(527, 350, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), game.MAIN.OPTIONS.TEXTMANAGER.SPELL1, "SETSPELL1"));
            setting.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(527, 435, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), game.MAIN.OPTIONS.TEXTMANAGER.SPELL2, "SETSPELL2"));
            setting.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(527, 520, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), game.MAIN.OPTIONS.TEXTMANAGER.SPELL3, "SETSPELL3"));
            setting.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(527, 605, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), game.MAIN.OPTIONS.TEXTMANAGER.SPELL4, "SETSPELL4"));
            setting.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(724, 350, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), game.MAIN.OPTIONS.TEXTMANAGER.MOB1, "SETMOB1"));
            setting.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(724, 435, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), game.MAIN.OPTIONS.TEXTMANAGER.MOB2, "SETMOB2"));
            setting.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(724, 520, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), game.MAIN.OPTIONS.TEXTMANAGER.MOB3, "SETMOB3"));
            setting.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(724, 605, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), game.MAIN.OPTIONS.TEXTMANAGER.MOB4, "SETMOB4"));
            setting.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(10, 650, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), game.MAIN.OPTIONS.TEXTMANAGER.OPTIONS, "BackToOptions"));
        }

        // Get & Set.
        #region Get & Set
        public bool Trap1
        {
            get { return trap1; }
            set { trap1 = value; }
        }
        public bool Trap2
        {
            get { return trap2; }
            set { trap2 = value; }
        }
        public bool Trap3
        {
            get { return trap3; }
            set { trap3 = value; }
        }
        public bool Trap4
        {
            get { return trap4; }
            set { trap4 = value; }
        }
        public bool Spell1
        {
            get { return spell1; }
            set { spell1 = value; }
        }
        public bool Spell2
        {
            get { return spell2; }
            set { spell2 = value; }
        }
        public bool Spell3
        {
            get { return spell3; }
            set { spell3 = value; }
        }
        public bool Spell4
        {
            get { return spell4; }
            set { spell4 = value; }
        }
        public bool Mob1
        {
            get { return mob1; }
            set { mob1 = value; }
        }
        public bool Mob2
        {
            get { return mob2; }
            set { mob2 = value; }
        }
        public bool Mob3
        {
            get { return mob3; }
            set { mob3 = value; }
        }
        public bool Mob4
        {
            get { return mob4; }
            set { mob4 = value; }
        }
        #endregion

        // Update & Draw.
        public void Update(Game1 game, GameTime time, Cursor cursor, MouseState mouse)
        {
            if (!loaded || game.MAIN.OPTIONS.STATES.ENABLEDCHANGELANGKEYSET)
            {
                AddButtons(game);
                loaded = true;
                game.MAIN.OPTIONS.STATES.ENABLEDCHANGELANGKEYSET = false;
            }
            setting.Update(game, time, cursor, mouse);

            // Touches
            if (Inputs.keys.Length != 0)
            {
                Keys prevKey = Inputs.keys[0];
                if (trap1)
                {
                    game.MAIN.HOTKEYS.SetTrap1(Inputs.keys[0]);
                    trap1 = false;
                }
                if (trap2)
                {
                    game.MAIN.HOTKEYS.SetTrap2(Inputs.keys[0]);
                    trap2 = false;
                }
                if (trap3)
                {
                    game.MAIN.HOTKEYS.SetTrap3(Inputs.keys[0]);
                    trap3 = false;
                }
                if (trap4)
                {
                    game.MAIN.HOTKEYS.SetTrap4(Inputs.keys[0]);
                    trap4 = false;
                }
                if (spell1)
                {
                    game.MAIN.HOTKEYS.SetSpell1(Inputs.keys[0]);
                    spell1 = false;
                }
                if (spell2)
                {
                    game.MAIN.HOTKEYS.SetSpell2(Inputs.keys[0]);
                    spell2 = false;
                }
                if (spell3)
                {
                    game.MAIN.HOTKEYS.SetSpell3(Inputs.keys[0]);
                    spell3 = false;
                }
                if (spell4)
                {
                    game.MAIN.HOTKEYS.SetSpell4(Inputs.keys[0]);
                    spell4 = false;
                }
                if (mob1)
                {
                    game.MAIN.HOTKEYS.SetMob1(Inputs.keys[0]);
                    mob1 = false;
                }
                if (mob2)
                {
                    game.MAIN.HOTKEYS.SetMob2(Inputs.keys[0]);
                    mob2 = false;
                }
                if (mob3)
                {
                    game.MAIN.HOTKEYS.SetMob3(Inputs.keys[0]);
                    mob3 = false;
                }
                if (mob4)
                {
                    game.MAIN.HOTKEYS.SetMob4(Inputs.keys[0]);
                    mob4 = false;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            setting.Draw(spriteBatch);
            if (trap1)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(330, 350, 171, 59), Color.White);
            }
            if (trap2)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(330, 435, 171, 59), Color.White);
            }
            if (trap3)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(330, 520, 171, 59), Color.White);
            }
            if (trap4)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(330, 605, 171, 59), Color.White);
            }
            if (spell1)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(527, 350, 171, 59), Color.White);
            }
            if (spell2)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(527, 435, 171, 59), Color.White);
            }
            if (spell3)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(527, 520, 171, 59), Color.White);
            }
            if (spell4)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(527, 605, 171, 59), Color.White);
            }
            if (mob1)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(724, 350, 171, 59), Color.White);
            }
            if (mob2)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(724, 435, 171, 59), Color.White);
            }
            if (mob3)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(724, 520, 171, 59), Color.White);
            }
            if (mob4)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(724, 605, 171, 59), Color.White);
            }
        }
    }
}
