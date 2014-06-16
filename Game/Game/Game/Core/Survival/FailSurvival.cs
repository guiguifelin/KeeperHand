using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    public class FailSurvival
    {
        // Fields.
        private Menu menu;
        private Sound soundManager;
        private bool loaded;

        // Constructor.
        public FailSurvival(Texture2D texture)
        {
            soundManager = new Sound();
            menu = new Menu(texture, soundManager);
            this.loaded = false;
        }

        // Get & Set.

        // Methods.

        // Update & Draw.
        public void Update(Game1 game, GameTime time, Cursor cursor, MouseState mouse)
        {
            if (!loaded || game.MAIN.OPTIONS.STATES.ENABLEDCHANGELANGWINFAIL)
            {
                menu.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(140, 383, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), game.MAIN.OPTIONS.TEXTMANAGER.SURVIVALMENU, "MAINMENU"));
                menu.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(926, 383, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), game.MAIN.OPTIONS.TEXTMANAGER.SURVIVALRESTART, "RESTARTSURVIVAL"));
                loaded = true;
                game.MAIN.OPTIONS.STATES.ENABLEDCHANGELANGWINFAIL = false;
            }
            menu.Update(game, time, cursor, mouse);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);
        }
    }
}
