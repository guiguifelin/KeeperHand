using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor
{
    public class Ressources
    {
        // Fields
        public static Texture2D t_background, t_middleground, t_cursor;
        public static SpriteFont font1, font2;
        public static Texture2D data_cursorState1, data_cursorState2, data_button;
        public static Texture2D background_MainMenu, selection, bg_console;

        // Methods
        public static void LoadContent(ContentManager content)
        {
            /* Tilesets */
            t_background = content.Load<Texture2D>("Ressources/Tilesets/tileset_background");
            t_middleground = content.Load<Texture2D>("Ressources/Tilesets/tileset_middleground");
            t_cursor = content.Load<Texture2D>("Ressources/Tilesets/cursorTileSet");

            /* Font */
            font1 = content.Load<SpriteFont>("Ressources/Font/font");
            font2 = content.Load<SpriteFont>("Ressources/Font/medieval");

            /* Textures data */
            data_cursorState1 = content.Load<Texture2D>("Ressources/TexturesData/Cursor/textureDataCursor01");
            data_cursorState2 = content.Load<Texture2D>("Ressources/TexturesData/Cursor/textureDataCursor02");
            data_button = content.Load<Texture2D>("Ressources/TexturesData/Buttons/b_Options");

            /* Textures */
            background_MainMenu = content.Load<Texture2D>("Ressources/Textures/Menus/Background");
            selection = content.Load<Texture2D>("Ressources/Textures/Selection");
            bg_console = content.Load<Texture2D>("Ressources/Textures/bg_ConsoleKH");
        }
    }
}
