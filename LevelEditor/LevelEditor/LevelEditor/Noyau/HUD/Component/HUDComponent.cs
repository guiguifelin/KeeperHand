using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace LevelEditor
{
    class HUDComponent : HUDState
    {
        // Fields.

        protected List<Button> buttons = new List<Button>();
        protected Cursor cursor;
        protected Game1 game;
        protected Sprite sprite;
        protected Texture2D texture;

        // Get & Set.

        // Methods.

        protected void InitComponent()
        {
            /* Initialisation des boutons de l'HUD */
            buttons.Add(new Button(game, cursor, Ressources.flecheGaucheHUD, new Vector2(725, 75), "DownNumber", ""));
            buttons.Add(new Button(game, cursor, Ressources.flecheDroiteHUD, new Vector2(1065, 75), "UpNumber", ""));
            buttons.Add(new Button(game, cursor, Ressources.buttonHUD, new Vector2(10, 10), "Add", "Add"));
            buttons.Add(new Button(game, cursor, Ressources.buttonHUD, new Vector2(Ressources.buttonHUD.Width + 20, 10), "Remove", "Remove"));
            buttons.Add(new Button(game, cursor, Ressources.buttonHUD, new Vector2((2 * Ressources.buttonHUD.Width) + 30, 10), "Selection", "Selection"));
            buttons.Add(new Button(game, cursor, Ressources.buttonHUD, new Vector2(3 * Ressources.boutonPlanHUD.Width + 140, 130), "OnOffModeEdition", "On/Off"));
            buttons.Add(new Button(game, cursor, Ressources.boutonPlanHUD, new Vector2(30, 125), "EnableBackground", "B"));
            buttons.Add(new Button(game, cursor, Ressources.boutonPlanHUD, new Vector2(Ressources.boutonPlanHUD.Width + 40, 125), "EnableMiddleground", "M"));
            buttons.Add(new Button(game, cursor, Ressources.boutonPlanHUD, new Vector2(2 * Ressources.boutonPlanHUD.Width + 50, 125), "", "F"));
            buttons.Add(new Button(game, cursor, Ressources.boutonPlanHUD, new Vector2(3 * Ressources.boutonPlanHUD.Width + 60, 125), "", "A"));
        }

        // Update & Draw.

        public void Update(GameTime gameTime, MouseState mouse)
        {
            if (DrawModeEdition)
            {
                foreach (Button button in buttons)
                {
                    button.Update(gameTime, mouse);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (DrawModeEdition)
            {
                spriteBatch.Draw(texture, new Vector2(0, 0), Color.White);
                foreach (Button button in buttons)
                {
                    button.Draw(spriteBatch, 3, 2);
                }
            }
        }
    }
}
