using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip;
using System.Diagnostics;

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
        private List<TextInfo> infos;
        private AbstractGame GameSet;

        /* Different options */
        private Survival survive;
        private SurvivalPause survivePause;

        /* Mise à jour */
        private bool updatedGame, downloadingUpdate, connected;

        /* Sounds */
        bool played;

        #endregion

        // Constructor.

        public Main(Game1 game, Viewport viewport)
        {
            try { GameSet = Data.Deserialization(GameSet, "GameSettings"); }
            catch { GameSet = new AbstractGame(); Data.Serialization(GameSet, "GameSettings"); }
            AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.MainMenu;
            this.viewport = viewport;
            updatedGame = true;
            downloadingUpdate = false;
            connected = false;
            cursor = new Cursor(viewport, Mouse.GetState(), 50, 75);
            infos = new List<TextInfo>();

            /* Sound Management */
            soundManager = new Sound();
            this.played = false;
            
            /* Main menu */
            vm = new VideoManager(Ressources.bg_MainMenu);
            vm.IsLoop(true);
            menu = new Menu(Ressources.m_background, soundManager);

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
                soundManager.MuteNoises();
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

            /* Initialize */
            survive = new Survival(game, this.cursor, soundManager, options.TEXTMANAGER, options.STATES.FRENCHMODE, options.STATES.ENGLISHMODE);
            survivePause = new SurvivalPause(Ressources.bg_Pause);
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
        public List<TextInfo> Infos
        {
            get { return infos; }
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
            foreach (TextInfo info in infos)
            {
                info.Update(gameTime);
            }
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
                    if (!played)
                    {
                        soundManager.SetSong(1.0f, true);
                        soundManager.PlaySong(soundManager.AddSong(Ressources.ambiance1));
                        played = true;
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
                case AbstractStateGame.GameState.Update:
                    if (updatedGame)
                    {
                        try
                        {
                            Console.WriteLine("[UPDATE] Telechargement du fichier de version...");
                            FTP.getHttpVersion();
                            updatedGame = false;
                            Console.WriteLine("[UPDATE] Telechargement fini !");
                        }
                        catch {
                            Console.WriteLine("[UPDATE] Error : Can't download the version file !");
                            AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.MainMenu; 
                        }
                    }
                    if (!updatedGame && FTP.Update())
                    {
                        /* Télécharger la mise à jour du jeu */
                        Console.WriteLine("[UPDATE] Comparaison des versions...");
                        string version = FTP.getVersion();
                        if (GameSet.Version != version)
                        {
                            connected = true;
                            /* Téléchargement */
                            if (!downloadingUpdate)
                            {
                                downloadingUpdate = true;
                                Console.WriteLine("[UPDATE] Version differente !");
                                Console.WriteLine("[UPDATE] Telechargement de l'update en cours...");
                                try
                                {
                                    FTP.getHttpUpdate();
                                }
                                catch
                                {
                                    Console.WriteLine("[UPDATE] Error : Can't download the update package !");
                                    connected = false;
                                }
                            }
                            if (FTP.UpdatedFile())
                            {
                                Console.WriteLine("[UPDATE] Sauvegarde de la version.");
                                GameSet.Version = version;
                                Data.Serialization(GameSet, "GameSettings");
                                Console.WriteLine("[UPDATE] Lancement de la mise a jour...");
                                // Lancer le programme d'update !
                                Process myInfo = new Process();
                                myInfo.StartInfo.FileName = "Update_KeeperHand.exe";
                                myInfo.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                                myInfo.Start();
                                game.Exit();
                            }
                        }
                        else
                        {
                            Console.WriteLine("[UPDATE] Version identique.");
                            AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.MainMenu; 
                        }
                        
                        if (!connected)
                        {
                            Console.WriteLine("[UPDATE] Sauvegarde de la version.");
                            GameSet.Version = version;
                            Data.Serialization(GameSet, "GameSettings");
                            AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.MainMenu;
                        }
                    }
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
                    spriteBatch.DrawString(Ressources.font, "Version : " + GameSet.Version, new Vector2(10, 700), Color.Red);
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
                case AbstractStateGame.GameState.Update:
                    spriteBatch.Draw(Ressources.bg_loading, new Vector2(0, 0), Color.White);
                    break;
            }
            cursor.Draw(spriteBatch);
            foreach (TextInfo info in infos)
            {
                info.Draw(spriteBatch);
            }
        }
    }
}
