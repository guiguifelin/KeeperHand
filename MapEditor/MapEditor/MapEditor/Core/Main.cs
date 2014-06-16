using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MapEditor
{
    public enum EditorState
    {
        MainMenu,
        CreateMap,
        CreateDonjon
    }

    public class Main
    {
        // Fields.
        private Cursor cursor;
        private Camera camera;
        private Menu mainMenu;
        private CreateMap createMap;
        private CreateDonjon createDonjon;
        public EditorState State;

        // Constructor.
        public Main(GraphicsDevice graphics)
        {
            cursor = new Cursor(graphics.Viewport, Mouse.GetState(), 50, 75);
            mainMenu = new Menu(Ressources.background_MainMenu);
            camera = new Camera(graphics.Viewport);
            createMap = new CreateMap(graphics, false);
            createDonjon = new CreateDonjon(graphics, cursor);
            State = EditorState.MainMenu;

            /* Set up the menu */
            mainMenu.AddButton(new Button(Ressources.data_button, new Rectangle(350, 370, 172, 60), "New Map", "NEWMAP"));
            mainMenu.AddButton(new Button(Ressources.data_button, new Rectangle(550, 370, 172, 60), "New Donjon", "NEWDONJON"));
            mainMenu.AddButton(new Button(Ressources.data_button, new Rectangle(750, 370, 172, 60), "   Exit", "EXIT"));
        }

        // Get & Set.
        public CreateDonjon CreateDonjon
        {
            get { return createDonjon; }
        }

        // Methods.

        // Update & Draw.

        public void Update(Game1 game, GameTime time)
        {
            camera.Update();
            cursor.Update(Mouse.GetState());

            switch (State)
            {
                case EditorState.MainMenu:
                    mainMenu.Update(game, time, cursor, Mouse.GetState());
                    break;
                case EditorState.CreateMap:
                    createMap.Update(game, time, cursor);
                    break;
                case EditorState.CreateDonjon:
                    createDonjon.Update(game, time);
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (State)
            {
                case EditorState.MainMenu:
                    mainMenu.Draw(spriteBatch);
                    cursor.Draw(spriteBatch);
                    break;
                case EditorState.CreateMap:
                    createMap.Draw(spriteBatch);
                    break;
                case EditorState.CreateDonjon:
                    createDonjon.Draw(spriteBatch);
                    break;
            }
        }
    }
}
