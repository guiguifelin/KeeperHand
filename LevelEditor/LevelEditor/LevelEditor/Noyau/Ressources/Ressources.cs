using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace LevelEditor
{
    class Ressources
    {
        // Textures.
        public static Texture2D cursor, tileSet1;
        public static Texture2D tileSetInterieur, tileSetFloorInt, tileSetInterieurDetails;
        public static Texture2D SelectionTest;
        public static Texture2D textureHUD;
        /* Texture data */
        public static Texture2D cursorData1, cursorData2;
        /* HUD */
        public static Texture2D buttonHUD, boutonPlanHUD, flecheDroiteHUD, flecheGaucheHUD;

        // Fonts.
        public static SpriteFont font1;

        public static void LoadContent(ContentManager content)
        {
            // Textures.
            tileSet1 = content.Load<Texture2D>("Textures/TileSets/tileSet1");
            tileSetInterieur = content.Load<Texture2D>("Textures/TileSets/tileSetInterieur");
            tileSetFloorInt = content.Load<Texture2D>("Textures/TileSets/tileSetFloorInt");
            tileSetInterieurDetails = content.Load<Texture2D>("Textures/TileSets/tileSetInterieurDetails");

            // Divers.
            cursor = content.Load<Texture2D>("Textures/TileSets/cursorTileSet");
            SelectionTest = content.Load<Texture2D>("Textures/Selection");

            // Fonts.
            font1 = content.Load<SpriteFont>("Fonts/MedievalFont1");

            // TextureData.
            cursorData1 = content.Load<Texture2D>("Textures/TextureData/Cursor/textureDataCursor1");
            cursorData2 = content.Load<Texture2D>("Textures/TextureData/Cursor/textureDataCursor2");

            // HUD.
            textureHUD = content.Load<Texture2D>("Textures/TextureData/HUD/textureHUD");
            buttonHUD = content.Load<Texture2D>("Textures/TextureData/HUD/boutonHUD");
            boutonPlanHUD = content.Load<Texture2D>("Textures/TextureData/HUD/boutonPlanHUD");
            flecheDroiteHUD = content.Load<Texture2D>("Textures/TextureData/HUD/flecheDroiteHUD");
            flecheGaucheHUD = content.Load<Texture2D>("Textures/TextureData/HUD/flecheGaucheHUD");
        }
    }
}
