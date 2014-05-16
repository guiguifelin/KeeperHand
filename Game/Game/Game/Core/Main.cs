using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    public class Main
    {
        // Fields.
        #region Fields

        private Viewport viewport;
        private Cursor cursor;
        private Menu menu;
        private Option options;
        private Sound soundManager;
        private VideoManager vm;
        private Hotkeys hotkeys;
        private HotkeysSettings HSettings;

        /* Different options */
        private Survival survive;
        private SurvivalPause survivePause;

        #endregion

        // Constructor.

        public Main(Viewport viewport)
        {
            this.viewport = viewport;
            cursor = new Cursor(viewport, Mouse.GetState(), 50, 75);
            soundManager = new Sound();
            /* Main menu */
            vm = new VideoManager(Ressources.bg_MainMenu);
            vm.IsLoop(true);
            menu = new Menu(Ressources.m_background, ref soundManager);
            /* Options */
            options = new Option(Ressources.m_background, ref soundManager);
            /* Hotkeys */
            try
            {
                this.hotkeys = Data.Deserialization(hotkeys, "Hotkeys");
            }
            catch
            {
                this.hotkeys = new Hotkeys(Keys.Enter, Keys.A, Keys.Z, Keys.E, Keys.R, Keys.Q, Keys.S, Keys.D, Keys.F, Keys.W, Keys.X, Keys.C, Keys.V);
            }
            HSettings = new HotkeysSettings(Ressources.m_background, ref soundManager);
            /* Initialize */
            survive = new Survival(this.cursor);
            survivePause = new SurvivalPause(Ressources.bg_Pause);
            /* Buttons Main Menu */
            if (options.STATES.ENGLISHMODE)
            {
                AddEnglishButtons();
            }
            else if (options.STATES.FRENCHMODE)
            {
                AddFrenchButtons();
            }
            /* Sound Manager */
            if (options.STATES.SOUDNMUTED)
            {
                soundManager.Mute();
            }
            /* Hotkeys */
            if (options.STATES.ENABLEDAZ)
            {
                hotkeys = new Hotkeys(Keys.Enter, Keys.A, Keys.Z, Keys.E, Keys.R, Keys.Q, Keys.S, Keys.D, Keys.F, Keys.W, Keys.X, Keys.C, Keys.V);
            }
            else if (options.STATES.ENABLEDQW)
            {
                hotkeys = new Hotkeys(Keys.Enter, Keys.Q, Keys.W, Keys.E, Keys.R, Keys.A, Keys.S, Keys.D, Keys.F, Keys.Z, Keys.X, Keys.C, Keys.V);
            }
            else if (options.STATES.ENABLEDCUSTOMKEYS)
            {
                hotkeys.SetHotkeysCustoms(true);
            }
        }

        // Get & Set.
        #region Get & Set
        public Option OPTIONS
        {
            get { return options; }
        }
        public Sound SOUNDMANAGER
        {
            get { return soundManager; }
        }
        public Survival SURVIVAL
        {
            get { return survive; }
        }
        public HotkeysSettings KEYSET
        {
            get { return HSettings; }
        }
        public Hotkeys HOTKEYS
        {
            get { return hotkeys; }
            set { hotkeys = value; }
        }
        #endregion

        // Methods.
        private void AddEnglishButtons()
        {
            menu.AddButton(new Button(Ressources.m_ENNew, new Rectangle(500, 350, 99, 45), "", "new"));
            menu.AddButton(new Button(Ressources.m_ENLoad, new Rectangle(650, 348, 99, 45), "", "load"));
            menu.AddButton(new Button(Ressources.m_ENSurvival, new Rectangle(280, 475, 174, 45), "", "survival"));
            menu.AddButton(new Button(Ressources.m_ENMultiplayer, new Rectangle(510, 474, 250, 50), "", "multiplayer"));
            menu.AddButton(new Button(Ressources.m_ENOptions, new Rectangle(810, 480, 130, 45), "", "options"));
            menu.AddButton(new Button(Ressources.m_ENExit, new Rectangle(585, 596, 99, 45), "", "exit"));
        }
        private void AddFrenchButtons()
        {
            menu.AddButton(new Button(Ressources.m_FRNew, new Rectangle(470, 340, 150, 52), "", "new"));
            menu.AddButton(new Button(Ressources.m_FRLoad, new Rectangle(670, 346, 125, 51), "", "load"));
            menu.AddButton(new Button(Ressources.m_FRSurvival, new Rectangle(315, 472, 129, 45), "", "survival"));
            menu.AddButton(new Button(Ressources.m_FRMultiplayer, new Rectangle(510, 474, 270, 46), "", "multiplayer"));
            menu.AddButton(new Button(Ressources.m_FROptions, new Rectangle(830, 476, 130, 45), "", "options"));
            menu.AddButton(new Button(Ressources.m_FRExit, new Rectangle(585, 596, 105, 45), "", "exit"));
        }

        // Update & Draw.
        public void Update(Game1 game, GameTime gameTime)
        {
            Inputs.Update();
            switch (AbstractStateGame.CurrentGameState)
            {
                case AbstractStateGame.GameState.Introduction:
                    break;
                case AbstractStateGame.GameState.MainMenu:
                    if (options.STATES.ENABLEDCHANGELANGMENU && options.STATES.ENGLISHMODE)
                    {
                        menu.DeleteButtons();
                        AddEnglishButtons();
                        options.STATES.ENABLEDCHANGELANGMENU = false;
                    }
                    else if (options.STATES.ENABLEDCHANGELANGMENU && options.STATES.FRENCHMODE)
                    {
                        menu.DeleteButtons();
                        AddFrenchButtons();
                        options.STATES.ENABLEDCHANGELANGMENU = false;
                    }
                    vm.Update(Keyboard.GetState());
                    menu.Update(game, gameTime, cursor, Mouse.GetState());
                    break;
                case AbstractStateGame.GameState.Playing:
                    break;
                case AbstractStateGame.GameState.Options:
                    options.Update(game, gameTime, cursor, Mouse.GetState());
                    break;
                case AbstractStateGame.GameState.Multiplayer:
                    break;
                case AbstractStateGame.GameState.Survival:
                    survive.Update(game, gameTime, Mouse.GetState(), Keyboard.GetState());
                    break;
                case AbstractStateGame.GameState.Pause:
                    survivePause.Update(game, gameTime, cursor, Mouse.GetState());
                    break;
                case AbstractStateGame.GameState.SettingsHotkeys:
                    HSettings.Update(game, gameTime, cursor, Mouse.GetState());
                    break;
            }
            /* On ne comprends pas.. MAIS NE TOUCHE PAS !!!!!!! C'est pour la video du menu (sinon elle ne se lance pas) */
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                vm.Level = false;
                vm.Playing();
            }
            /* FIN ON NE TOUCHE PAS */
            cursor.Update(Mouse.GetState());
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Viewport view)
        {
            switch (AbstractStateGame.CurrentGameState)
            {
                case AbstractStateGame.GameState.Introduction:
                    break;
                case AbstractStateGame.GameState.MainMenu:
                    vm.Draw(spriteBatch, view);
                    menu.Draw(spriteBatch);
                    break;
                case AbstractStateGame.GameState.Playing:
                    break;
                case AbstractStateGame.GameState.Options:
                    options.Draw(spriteBatch);
                    break;
                case AbstractStateGame.GameState.Multiplayer:
                    break;
                case AbstractStateGame.GameState.Survival:
                    survive.Draw(spriteBatch);
                    break;
                case AbstractStateGame.GameState.Pause:
                    survivePause.Draw(spriteBatch);
                    break;
                case AbstractStateGame.GameState.SettingsHotkeys:
                    HSettings.Draw(spriteBatch);
                    break;
            }
            cursor.Draw(spriteBatch);
        }
    }
}
