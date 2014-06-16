using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Game
{
    public class Ressources
    {
        // Fields.

        #region Tilesets

        public static Texture2D Cursor;
        public static Texture2D tileset_background, tileset_middleground;
        public static Texture2D tileset_particule;
        public static Texture2D tileset_ia1;
        public static Texture2D tileset_Chest, tileset_MovingChest;
        public static Texture2D tileset_gobelin;
        public static Texture2D tileset_coins;

        #endregion
        #region TextureData

        public static Texture2D t_CursorState1, t_CursorState2;
        /* IA */
        public static Texture2D t_ia_1, t_ia_2, t_ia_3, t_ia_4, t_ia_5, t_ia_6, 
            t_ia_7, t_ia_8, t_ia_9, t_ia_10, t_ia_11, t_ia_12;
        /*HUDButtons*/
        public static Texture2D t_AttractiveNoise, t_BrokenGlass, t_Elf,
            t_FireWall, t_FlameThrower, t_Frozen, t_Gobelin, t_HotStep, t_Juste1Second, t_LavaRiver, t_LostMyGlasses,
            t_Marbles, t_Needle, t_Spikes, t_Troll, t_UnexpectedStep, t_Wizard, bg_HUD, t_bmenu;
        /* Options */
        public static Texture2D t_buttonOptions, t_buttonOptionsEnabled;
        /* Fields */
        public static Texture2D f_24, f_50, f_100;
        /* Items */
        public static Texture2D t_Chest, t_MovingChest;
        /* Collision map */
        public static Texture2D t_sprite1, t_sprite2, t_sprite3, t_sprite4, t_sprite5, t_sprite6, t_sprite7,
            t_sprite8, t_sprite9, t_sprite10, t_sprite11, t_sprite12, t_sprite13, t_sprite14, t_sprite15, t_sprite16, t_sprite17;
        /* Mobs */
        public static Texture2D t_goblin_down1, t_goblin_down2, t_goblin_down3, t_goblin_down4,
            t_goblin_up1, t_goblin_up2, t_goblin_up3, t_goblin_up4,
            t_goblin_left1, t_goblin_left2, t_goblin_left3, t_goblin_left4,
            t_goblin_right1, t_goblin_right2, t_goblin_right3, t_goblin_right4;

        #endregion
        #region Font

        public static SpriteFont font, medieval;

        #endregion
        #region Textures

        public static Texture2D m_background, m_FRNew, m_FRLoad, m_FRSurvival, m_FRMultiplayer, m_FROptions, m_FRExit,
            m_ENNew, m_ENLoad, m_ENSurvival, m_ENMultiplayer, m_ENOptions, m_ENExit;
        public static Texture2D k_mana, k_money, k_cadre, k_validate, k_field;
        public static Texture2D bg_Win, bg_Fail, bg_Pause, bg_loading, bg_console, bg_choiceModeEn, bg_choiceModeFR;

        #endregion
        #region Video

        public static Video intro, bg_MainMenu;

        #endregion
        #region Sounds
        public static SoundEffect b_Beep;
        public static Song ambiance1;
        #endregion
        #region LightingEngine
        public static Texture2D blackSquare, lightmask;
        public static Effect lighting;
        #endregion

        // Methods.

        public static void LoadContent(ContentManager content)
        {
            /* LightingEngine */
            blackSquare = content.Load<Texture2D>("Ressources/Textures/Light/blacksquare");
            lightmask = content.Load<Texture2D>("Ressources/Textures/Light/lightmask");
            lighting = content.Load<Effect>("Ressources/Effects/lighting");

            /* Textures */
            Cursor = content.Load<Texture2D>("Ressources/Tileset/cursorTileSet");
            tileset_background = content.Load<Texture2D>("Ressources/Tileset/tileset_background");
            tileset_middleground = content.Load<Texture2D>("Ressources/Tileset/tileset_middleground");
            tileset_particule = content.Load<Texture2D>("Ressources/Textures/particles");
            tileset_ia1 = content.Load<Texture2D>("Ressources/Tileset/tileset_ia1");
            bg_Win = content.Load<Texture2D>("Ressources/Textures/WinBG");
            bg_Fail = content.Load<Texture2D>("Ressources/Textures/FailBG");
            bg_Pause = content.Load<Texture2D>("Ressources/Textures/Pause");
            bg_loading = content.Load<Texture2D>("Ressources/Textures/Loading");
            bg_console = content.Load<Texture2D>("Ressources/Textures/bg_ConsoleKH");
            bg_choiceModeEn = content.Load<Texture2D>("Ressources/Textures/Survival/bg_typeSurvival_EN");
            bg_choiceModeFR = content.Load<Texture2D>("Ressources/Textures/Survival/bg_typeSurvival_FR");


            /* Keeper */
            k_mana = content.Load<Texture2D>("Ressources/Textures/KeeperStats/mana");
            k_money = content.Load<Texture2D>("Ressources/Textures/KeeperStats/money");
            k_cadre = content.Load<Texture2D>("Ressources/Textures/KeeperStats/cadre_mana_money");
            k_validate = content.Load<Texture2D>("Ressources/Textures/KeeperStats/validate");
            k_field = content.Load<Texture2D>("Ressources/Textures/KeeperStats/Field");

            /* Items */
            tileset_Chest = content.Load<Texture2D>("Ressources/Tileset/tileset_Chest");
            tileset_MovingChest = content.Load<Texture2D>("Ressources/Tileset/tileset_MovingChest");
            tileset_coins = content.Load<Texture2D>("Ressources/Tileset/tileset_Coins");

            /* Mobs */
            tileset_gobelin = content.Load<Texture2D>("Ressources/Tileset/tileset_goblin1");

            // Main Menu
            m_background = content.Load<Texture2D>("Ressources/Textures/Background");
            m_FRNew = content.Load<Texture2D>("Ressources/Textures/buttons/FR_New");
            m_FRLoad = content.Load<Texture2D>("Ressources/Textures/buttons/FR_Load");
            m_FRSurvival = content.Load<Texture2D>("Ressources/Textures/buttons/FR_Survival");
            m_FRMultiplayer = content.Load<Texture2D>("Ressources/Textures/buttons/FR_Multiplayers");
            m_FROptions = content.Load<Texture2D>("Ressources/Textures/buttons/FR_Options");
            m_FRExit = content.Load<Texture2D>("Ressources/Textures/buttons/FR_Exit");
            m_ENNew = content.Load<Texture2D>("Ressources/Textures/buttons/EN_New");
            m_ENLoad = content.Load<Texture2D>("Ressources/Textures/buttons/EN_Load");
            m_ENSurvival = content.Load<Texture2D>("Ressources/Textures/buttons/EN_Survival");
            m_ENMultiplayer = content.Load<Texture2D>("Ressources/Textures/buttons/EN_Multiplayer");
            m_ENOptions = content.Load<Texture2D>("Ressources/Textures/buttons/EN_Options");
            m_ENExit = content.Load<Texture2D>("Ressources/Textures/buttons/EN_Exit");

            /* Texture data */
            t_CursorState1 = content.Load<Texture2D>("Ressources/TextureData/textureDataCursor01");
            t_CursorState2 = content.Load<Texture2D>("Ressources/TextureData/textureDataCursor02");
            f_24 = content.Load<Texture2D>("Ressources/Textures/KeeperStats/field24");
            f_50 = content.Load<Texture2D>("Ressources/Textures/KeeperStats/field50");
            f_100 = content.Load<Texture2D>("Ressources/Textures/KeeperStats/field100");
            t_Chest = content.Load<Texture2D>("Ressources/TextureData/Items/textureData_Chest");
            t_MovingChest = content.Load<Texture2D>("Ressources/TextureData/Items/textureData_MovingChest");
            t_sprite1 = content.Load<Texture2D>("Ressources/TextureData/Map/Middle/Sprite1");
            t_sprite2 = content.Load<Texture2D>("Ressources/TextureData/Map/Middle/Sprite2");
            t_sprite3 = content.Load<Texture2D>("Ressources/TextureData/Map/Middle/Sprite3");
            t_sprite4 = content.Load<Texture2D>("Ressources/TextureData/Map/Middle/Sprite4");
            t_sprite5 = content.Load<Texture2D>("Ressources/TextureData/Map/Middle/Sprite5");
            t_sprite6 = content.Load<Texture2D>("Ressources/TextureData/Map/Middle/Sprite6");
            t_sprite7 = content.Load<Texture2D>("Ressources/TextureData/Map/Middle/Sprite7");
            t_sprite8 = content.Load<Texture2D>("Ressources/TextureData/Map/Middle/Sprite8");
            t_sprite9 = content.Load<Texture2D>("Ressources/TextureData/Map/Middle/Sprite9");
            t_sprite10 = content.Load<Texture2D>("Ressources/TextureData/Map/Middle/Sprite10");
            t_sprite11 = content.Load<Texture2D>("Ressources/TextureData/Map/Middle/Sprite11");
            t_sprite12 = content.Load<Texture2D>("Ressources/TextureData/Map/Middle/Sprite12");
            t_sprite13 = content.Load<Texture2D>("Ressources/TextureData/Map/Middle/Sprite13");
            t_sprite14 = content.Load<Texture2D>("Ressources/TextureData/Map/Middle/Sprite14");
            t_sprite15 = content.Load<Texture2D>("Ressources/TextureData/Map/Middle/Sprite15");
            t_sprite16 = content.Load<Texture2D>("Ressources/TextureData/Map/Middle/Sprite16");
            t_sprite17 = content.Load<Texture2D>("Ressources/TextureData/Map/Middle/Sprite17");

            /* IA */
            t_ia_1 = content.Load<Texture2D>("Ressources/TextureData/ia/1/textureDataIa1_1");
            t_ia_2 = content.Load<Texture2D>("Ressources/TextureData/ia/1/textureDataIa1_2");
            t_ia_3 = content.Load<Texture2D>("Ressources/TextureData/ia/1/textureDataIa1_3");
            t_ia_4 = content.Load<Texture2D>("Ressources/TextureData/ia/1/textureDataIa1_4");
            t_ia_5 = content.Load<Texture2D>("Ressources/TextureData/ia/1/textureDataIa1_5");
            t_ia_6 = content.Load<Texture2D>("Ressources/TextureData/ia/1/textureDataIa1_6");
            t_ia_7 = content.Load<Texture2D>("Ressources/TextureData/ia/1/textureDataIa1_7");
            t_ia_8 = content.Load<Texture2D>("Ressources/TextureData/ia/1/textureDataIa1_8");
            t_ia_9 = content.Load<Texture2D>("Ressources/TextureData/ia/1/textureDataIa1_9");
            t_ia_10 = content.Load<Texture2D>("Ressources/TextureData/ia/1/textureDataIa1_10");
            t_ia_11 = content.Load<Texture2D>("Ressources/TextureData/ia/1/textureDataIa1_11");
            t_ia_12 = content.Load<Texture2D>("Ressources/TextureData/ia/1/textureDataIa1_12");

            /* Mobs */
            t_goblin_down1 = content.Load<Texture2D>("Ressources/TextureData/Mobs/gobelin/goblin_down1");
            t_goblin_down2 = content.Load<Texture2D>("Ressources/TextureData/Mobs/gobelin/goblin_down2");
            t_goblin_down3 = content.Load<Texture2D>("Ressources/TextureData/Mobs/gobelin/goblin_down3");
            t_goblin_down4 = content.Load<Texture2D>("Ressources/TextureData/Mobs/gobelin/goblin_down4");
            t_goblin_up1 = content.Load<Texture2D>("Ressources/TextureData/Mobs/gobelin/goblin_up1");
            t_goblin_up2 = content.Load<Texture2D>("Ressources/TextureData/Mobs/gobelin/goblin_up2");
            t_goblin_up3 = content.Load<Texture2D>("Ressources/TextureData/Mobs/gobelin/goblin_up3");
            t_goblin_up4 = content.Load<Texture2D>("Ressources/TextureData/Mobs/gobelin/goblin_up4");
            t_goblin_left1 = content.Load<Texture2D>("Ressources/TextureData/Mobs/gobelin/goblin_left1");
            t_goblin_left2 = content.Load<Texture2D>("Ressources/TextureData/Mobs/gobelin/goblin_left2");
            t_goblin_left3 = content.Load<Texture2D>("Ressources/TextureData/Mobs/gobelin/goblin_left3");
            t_goblin_left4 = content.Load<Texture2D>("Ressources/TextureData/Mobs/gobelin/goblin_left4");
            t_goblin_right1 = content.Load<Texture2D>("Ressources/TextureData/Mobs/gobelin/goblin_right1");
            t_goblin_right2 = content.Load<Texture2D>("Ressources/TextureData/Mobs/gobelin/goblin_right2");
            t_goblin_right3 = content.Load<Texture2D>("Ressources/TextureData/Mobs/gobelin/goblin_right3");
            t_goblin_right4 = content.Load<Texture2D>("Ressources/TextureData/Mobs/gobelin/goblin_right4");

            /*HUD*/
            bg_HUD = content.Load<Texture2D>("Ressources/TextureData/HUD/bg_HUD");

            /*HUDButtons*/
            t_AttractiveNoise = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/AttractiveNoise");
            t_BrokenGlass = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/Broken Glass");
            t_Elf = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/Elf");
            t_FireWall = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/Fire Wall");
            t_FlameThrower = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/Flame Thrower");
            t_Frozen = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/Frozen");
            t_Gobelin = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/Gobelin");
            t_HotStep = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/Hot Step");
            t_Juste1Second = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/Just1second");
            t_LavaRiver = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/Lava River");
            t_LostMyGlasses = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/LostMyGlasses");
            t_Marbles = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/Marbles");
            t_Needle = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/Needle");
            t_Spikes = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/Spikes");
            t_Troll = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/Troll");
            t_UnexpectedStep = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/UnexpectedStep");
            t_Wizard = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/Wizard");
            t_bmenu = content.Load<Texture2D>("Ressources/TextureData/HUD/Buttons/menu");

            /* Options */
            t_buttonOptions = content.Load<Texture2D>("Ressources/TextureData/Options/b_Options");
            t_buttonOptionsEnabled = content.Load<Texture2D>("Ressources/TextureData/Options/b_OptionsV");

            /* Font */
            font = content.Load<SpriteFont>("Ressources/Font/font");
            medieval = content.Load<SpriteFont>("Ressources/Font/medieval");

            /* Video */
            intro = content.Load<Video>("Ressources/Videos/Intro_Eubision");
            bg_MainMenu = content.Load<Video>("Ressources/Videos/MATRIX");

            /* Sounds */
            b_Beep = content.Load<SoundEffect>("Ressources/Sounds/beep");
            ambiance1 = content.Load<Song>("Ressources/Sounds/KeeperHand_Ambiance1");
        }
    }
}
