using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SavingMap;

namespace MapEditor
{
    public class CreateDonjon
    {
        enum CreateDonjonState
        {
            Setup,
            Create
        }

        // Fields.
        private CreateMap createMap;
        private Donjon donjonMaps;
        private GraphicsDevice graphics;
        private CreateDonjonState State;
        private Cursor cursor;
        private Button validateSettings;
        public bool validate;

        /* Set */
        private int number, nb_torch, num_Donjon;
        private string str_number, str_nb_torch;

        // Constructor.
        public CreateDonjon(GraphicsDevice graphics, Cursor cursor)
        {
            this.graphics = graphics;
            this.State = CreateDonjonState.Setup;
            this.cursor = cursor;
            num_Donjon = 0;
            validate = false;
            str_number = string.Empty;
            str_nb_torch = string.Empty;
            validateSettings = new Button(Ressources.data_button, new Rectangle(523, 551, Ressources.data_button.Width, Ressources.data_button.Height), "     Ok", "VALIDATESETTINGS");
        }

        // Get & Set.

        // Methods.
        private void DrawHelp(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Ressources.font1, "Background : A\nMiddleground : Z\nForeground : E\nAction : R\n\nPut : Left click\nRemove : Right click\nDrop : D\nNext tile : Up\nPrev. tile : Down\nNext map : Right\nPrev. map : Left\n\nFullscreen : F\nMain menu : Escape\n\nReset Map : F1\nSave donjon : F2\nLoad donjon : F3", new Vector2(10, 10), Color.White);
        }
        private void GetSettings()
        {

        }
        private void CheckOutSettings()
        {
            if (validate)
            {

            }
        }

        // Update & Draw.
        public void Update(Game1 game, GameTime time)
        {
            switch (State)
            {
                case CreateDonjonState.Setup:
                    cursor.Update(Mouse.GetState());
                    GetSettings();
                    CheckOutSettings();
                    break;
                case CreateDonjonState.Create:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (State)
            {
                case CreateDonjonState.Setup:
                    spriteBatch.DrawString(Ressources.font1, str_number, new Vector2(691, 382), Color.White);
                    spriteBatch.DrawString(Ressources.font1, str_nb_torch, new Vector2(691, 463), Color.White);
                    cursor.Draw(spriteBatch);
                    break;
                case CreateDonjonState.Create:
                    break;
            }
        }
    }
}
