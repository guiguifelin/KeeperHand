using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Game
{
    class Effects
    {
        //Fields
        
        //Constructors

        //Get & Set 

        //Methods
        protected void function(Game1 game, string gs)
        {
            switch (gs)
            {
                case "new":
                    //AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.Playing;
                    break;
                case "options":
                    AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.Options;
                    break;
                case "exit":
                    game.Exit();
                    break;
                case "survival":
                    game.MAIN.SURVIVAL.RestartSurvival();
                    AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.Survival;
                    break;
                case "multiplayer":
                    //AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.Multiplayer;
                    break;
                case "load":
                    //AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.Playing;
                    break;
                case "FULLSCREENMODE":
                    game.GRAPHICS.ToggleFullScreen();
                    game.MAIN.OPTIONS.STATES.FULLSCREENMODE = !game.MAIN.OPTIONS.STATES.FULLSCREENMODE;
                    game.MAIN.OPTIONS.STATES.ENABLEDSAVE = true;
                    break;
                case "BackToMenu":
                    AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.MainMenu;
                    break;
                case "ENGLISHMODE":
                    if (!game.MAIN.OPTIONS.STATES.ENGLISHMODE && game.MAIN.OPTIONS.STATES.FRENCHMODE)
                    {
                        game.MAIN.OPTIONS.STATES.ENGLISHMODE = true;
                        game.MAIN.OPTIONS.STATES.FRENCHMODE = false;
                    }
                    game.MAIN.OPTIONS.STATES.ENABLEDSAVE = true;
                    game.MAIN.OPTIONS.STATES.ENABLEDCHANGELANGMENU = true;
                    game.MAIN.OPTIONS.STATES.ENABLEDCHANGELANGOPTIONS = true;
                    game.MAIN.OPTIONS.STATES.ENABLEDCHANGELANGWINFAIL = true;
                    game.MAIN.OPTIONS.STATES.ENABLEDCHANGELANGKEYSET = true;
                    break;

                case "FRENCHMODE":
                    if (game.MAIN.OPTIONS.STATES.ENGLISHMODE && !game.MAIN.OPTIONS.STATES.FRENCHMODE)
                    {
                        game.MAIN.OPTIONS.STATES.ENGLISHMODE = false;
                        game.MAIN.OPTIONS.STATES.FRENCHMODE = true;
                    }
                    game.MAIN.OPTIONS.STATES.ENABLEDSAVE = true;
                    game.MAIN.OPTIONS.STATES.ENABLEDCHANGELANGMENU = true;
                    game.MAIN.OPTIONS.STATES.ENABLEDCHANGELANGOPTIONS = true;
                    game.MAIN.OPTIONS.STATES.ENABLEDCHANGELANGWINFAIL = true;
                    game.MAIN.OPTIONS.STATES.ENABLEDCHANGELANGKEYSET = true;
                    break;
                case "SOUNDMUTED":
                    game.MAIN.OPTIONS.STATES.SOUDNMUTED = !game.MAIN.OPTIONS.STATES.SOUDNMUTED;
                    if (game.MAIN.OPTIONS.STATES.SOUDNMUTED)
                    {
                        game.MAIN.SOUNDMANAGER.MuteNoises();
                        game.MAIN.SOUNDMANAGER.Mute();
                    }
                    else
                    {
                        game.MAIN.SOUNDMANAGER.UnmuteNoises();
                        game.MAIN.SOUNDMANAGER.Unmute();
                    }
                    game.MAIN.OPTIONS.STATES.ENABLEDSAVE = true;
                    game.MAIN.OPTIONS.STATES.ENABLEDCHANGEVOL = true;
                    break;
                case "VOLUMEUP":
                    if (!game.MAIN.OPTIONS.STATES.SOUDNMUTED)
                    {
                        game.MAIN.SOUNDMANAGER.VolumeUpNoises();
                        game.MAIN.SOUNDMANAGER.Volume_Up();
                    }
                    break;
                case "VOLUMEDOWN":
                    if (!game.MAIN.OPTIONS.STATES.SOUDNMUTED)
                    {
                        game.MAIN.SOUNDMANAGER.VolumeDownNoises();
                        game.MAIN.SOUNDMANAGER.Volume_Down();
                    }
                    break;
                case "MAINMENU":
                    AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.MainMenu;
                    break;
                case "RESTARTSURVIVAL":
                    game.MAIN.SURVIVAL.RestartSurvival();
                    AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.Survival;
                    break;
                case "RESUME":
                    AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.Survival;
                    break;
                case "AZERTY":
                    game.MAIN.HOTKEYS = new Hotkeys(Keys.Enter, Keys.A, Keys.Z, Keys.E, Keys.R, Keys.Q, Keys.S, Keys.D, Keys.F, Keys.W, Keys.X, Keys.C, Keys.V);
                    game.MAIN.OPTIONS.STATES.ENABLEDQW = !game.MAIN.OPTIONS.STATES.ENABLEDQW;
                    game.MAIN.OPTIONS.STATES.ENABLEDAZ = !game.MAIN.OPTIONS.STATES.ENABLEDAZ;
                    game.MAIN.OPTIONS.STATES.ENABLEDSAVE = true;
                    break;
                case "QWERTY":
                    game.MAIN.HOTKEYS = new Hotkeys(Keys.Enter, Keys.Q, Keys.W, Keys.E, Keys.R, Keys.A, Keys.S, Keys.D, Keys.F, Keys.Z, Keys.X, Keys.C, Keys.V);
                    game.MAIN.OPTIONS.STATES.ENABLEDQW = !game.MAIN.OPTIONS.STATES.ENABLEDQW;
                    game.MAIN.OPTIONS.STATES.ENABLEDAZ = !game.MAIN.OPTIONS.STATES.ENABLEDAZ;
                    game.MAIN.OPTIONS.STATES.ENABLEDSAVE = true;
                    break;
                case "SETTRAP1":
                    game.MAIN.KEYSET.Trap1 = true;
                    break;
                case "SETTRAP2":
                    game.MAIN.KEYSET.Trap2 = true;
                    break;
                case "SETTRAP3":
                    game.MAIN.KEYSET.Trap3 = true;
                    break;
                case "SETTRAP4":
                    game.MAIN.KEYSET.Trap4 = true;
                    break;
                case "SETSPELL1":
                    game.MAIN.KEYSET.Spell1 = true;
                    break;
                case "SETSPELL2":
                    game.MAIN.KEYSET.Spell2 = true;
                    break;
                case "SETSPELL3":
                    game.MAIN.KEYSET.Spell3 = true;
                    break;
                case "SETSPELL4":
                    game.MAIN.KEYSET.Spell4 = true;
                    break;
                case "SETMOB1":
                    game.MAIN.KEYSET.Mob1 = true;
                    break;
                case "SETMOB2":
                    game.MAIN.KEYSET.Mob2 = true;
                    break;
                case "SETMOB3":
                    game.MAIN.KEYSET.Mob3 = true;
                    break;
                case "SETMOB4":
                    game.MAIN.KEYSET.Mob4 = true;
                    break;
                case "BackToOptions":
                    Data.Serialization(game.MAIN.HOTKEYS, "Hotkeys");
                    game.MAIN.HOTKEYS.SetHotkeysCustoms(true);
                    AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.Options;
                    game.MAIN.OPTIONS.STATES.ENABLEDSAVE = true;
                    game.MAIN.OPTIONS.STATES.ENABLEDAZ = false;
                    game.MAIN.OPTIONS.STATES.ENABLEDQW = false;
                    game.MAIN.OPTIONS.STATES.ENABLEDCUSTOMKEYS = true;
                    break;
                case "SETCUSTOMKEYS":
                    if (!game.MAIN.OPTIONS.STATES.ENABLEDCUSTOMKEYS)
                    {
                        game.MAIN.HOTKEYS.SetHotkeysCustoms(true);
                        game.MAIN.OPTIONS.STATES.ENABLEDAZ = false;
                        game.MAIN.OPTIONS.STATES.ENABLEDQW = false;
                    }
                    else 
                    {
                        game.MAIN.HOTKEYS = new Hotkeys(Keys.Enter, Keys.A, Keys.Z, Keys.E, Keys.R, Keys.Q, Keys.S, Keys.D, Keys.F, Keys.W, Keys.X, Keys.C, Keys.V);
                        game.MAIN.OPTIONS.STATES.ENABLEDAZ = !game.MAIN.OPTIONS.STATES.ENABLEDAZ;
                    }
                    game.MAIN.OPTIONS.STATES.ENABLEDCUSTOMKEYS = !game.MAIN.OPTIONS.STATES.ENABLEDCUSTOMKEYS;
                    game.MAIN.OPTIONS.STATES.ENABLEDSAVE = true;
                    break;
                case "SETKEYS":
                    AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.SettingsHotkeys;
                    break;
                case "MODESOLOSURVIVAL":
                    foreach (IA ia in game.MAIN.SURVIVAL.LISTIA)
                    {
                        ia.solo = true;
                        ia.local = false;
                        ia.online = false;
                    }
                    game.MAIN.SURVIVAL.s_state = Survival.SurvivalState.Solo;
                    break;
                case "MODELOCALSURVIVAL":
                    foreach (IA ia in game.MAIN.SURVIVAL.LISTIA)
                    {
                        ia.solo = false;
                        ia.local = true;
                        ia.online = false;
                    }
                    game.MAIN.SURVIVAL.s_state = Survival.SurvivalState.MultiLocal;
                    break;
                case "MODEMULTISURVIVAL":
                    /* Non disponible
                    foreach (IA ia in game.MAIN.SURVIVAL.LISTIA)
                    {
                        ia.solo = false;
                        ia.local = false;
                        ia.online = true;
                    }
                    game.MAIN.SURVIVAL.s_state = Survival.SurvivalState.MultiOnline;
                     * */
                    break;
            }
        }
        //Update & Draw

    }
}
