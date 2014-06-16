using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class AbstractStateGame
    {
        /* Fields */
        public enum GameState
        {
            Introduction,
            MainMenu,
            Playing,
            Pause,
            Options,
            Multiplayer,
            Survival,
            SettingsHotkeys,
            Update
        }

        public static GameState CurrentGameState;
        public static bool IsLoop = false;
    }
}
