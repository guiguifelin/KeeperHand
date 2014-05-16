using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    public class Option
    {
        // Fields.
        private Menu option;
        private StateOptions state;
        private TextManager tm;

        // Constructor.

        public Option(Texture2D texture, ref Sound sm)
        {
            option = new Menu(texture, ref sm);
            try
            {
                state = StateOptions.LoadStateOptions(state);
            }
            catch
            {
                state = new StateOptions(false);
            }
            tm = new TextManager(state);
            AddButtons();
        }

        // Get & Set.
        public StateOptions STATES
        {
            get { return state; }
            set { state = value; }
        }
        public TextManager TEXTMANAGER
        {
            get { return tm; }
        }

        // Methods.
        private void AddButtons()
        {
            option.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(535, 329, 171, 59), tm.FULLSCREEN, "FULLSCREENMODE"));
            option.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(15, 650, 171, 59), tm.MAINMENU, "BackToMenu"));
            option.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(450, 428, 171, 59), tm.ENGLISHMODE, "ENGLISHMODE"));
            option.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(631, 428, 171, 59), tm.FRENCHMODE, "FRENCHMODE"));
            option.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(365, 527, 171, 59), tm.SOUNDMUTED, "SOUNDMUTED"));
            option.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(546, 527, 171, 59), tm.VOLUMEUP, "VOLUMEUP"));
            option.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(727, 527, 171, 59), tm.VOLUMEDOWN, "VOLUMEDOWN"));
            option.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(10, 527, 171, 59), "Qwerty", "QWERTY"));
            option.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(10, 428, 171, 59), "Azerty", "AZERTY"));
            option.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(10, 329, 171, 59), "Custom", "SETCUSTOMKEYS"));
            option.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(10, 230, 171, 59), tm.SETKEYS, "SETKEYS"));
        }

        // Update & Draw.

        public void Update(Game1 game, GameTime time, Cursor cursor, MouseState mouse)
        {
            tm.Update();
            if (state.ENABLEDCHANGELANGOPTIONS)
            {
                option.DeleteButtons();
                AddButtons();
                state.ENABLEDCHANGELANGOPTIONS = false;
            }
            option.Update(game, time, cursor, mouse);
            state.Update(game);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            option.Draw(spriteBatch);
            if (state.FULLSCREENMODE)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(535, 329, 171, 59), Color.White);
            }
            if (state.ENGLISHMODE)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(450, 428, 171, 59), Color.White);
            }
            if (state.FRENCHMODE)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(631, 428, 171, 59), Color.White);
            }
            if (state.SOUDNMUTED)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(365, 527, 171, 59), Color.White);
            }
            if (state.ENABLEDAZ)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(10, 428, 171, 59), Color.White);
            }
            if (state.ENABLEDQW)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(10, 527, 171, 59), Color.White);
            }
            if (state.ENABLEDCUSTOMKEYS)
            {
                spriteBatch.Draw(Ressources.t_buttonOptionsEnabled, new Rectangle(10, 329, 171, 59), Color.White);
            }
        }
    }
}
