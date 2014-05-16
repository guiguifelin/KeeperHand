using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class TextManager
    {
        // Fields.
        private StateOptions stateOptions;

        /* Options */
        private string fullscreen, englishMode, frenchMode, mainMenu, mute, volumeUp, volumeDown, setKeys;
        /* Settings hotkeys */
        private string trap1, trap2, trap3, trap4, spell1, spell2, spell3, spell4, mob1, mob2, mob3, mob4, options;
        /* Survival */
        private string SurvivalRestart, SurvivalMenu, SurvivalResume;

        // Constructor.
        public TextManager(StateOptions state) 
        { 
            stateOptions = state;
            SetText();
        }

        // Get.
        #region Gets
        public string FULLSCREEN
        {
            get { return fullscreen; }
        }
        public string ENGLISHMODE
        {
            get { return englishMode; }
        }
        public string FRENCHMODE
        {
            get { return frenchMode; }
        }
        public string MAINMENU
        {
            get { return mainMenu; }
        }
        public string SOUNDMUTED
        {
            get { return mute; }
        }
        public string VOLUMEUP
        {
            get { return volumeUp; }
        }
        public string VOLUMEDOWN
        {
            get { return volumeDown; }
        }
        public string SURVIVALMENU
        {
            get { return SurvivalMenu; }
        }
        public string SURVIVALRESTART
        {
            get { return SurvivalRestart; }
        }
        public string SURVIVALRESUME
        {
            get { return SurvivalResume; }
        }
        public string TRAP1
        {
            get { return trap1; }
            set { trap1 = value; }
        }
        public string TRAP2
        {
            get { return trap2; }
            set { trap2 = value; }
        }
        public string TRAP3
        {
            get { return trap3; }
            set { trap3 = value; }
        }
        public string TRAP4
        {
            get { return trap4; }
            set { trap4 = value; }
        }
        public string SPELL1
        {
            get { return spell1; }
            set { spell1 = value; }
        }
        public string SPELL2
        {
            get { return spell2; }
            set { spell2 = value; }
        }
        public string SPELL3
        {
            get { return spell3; }
            set { spell3 = value; }
        }
        public string SPELL4
        {
            get { return spell4; }
            set { spell4 = value; }
        }
        public string MOB1
        {
            get { return mob1; }
            set { mob1 = value; }
        }
        public string MOB2
        {
            get { return mob2; }
            set { mob2 = value; }
        }
        public string MOB3
        {
            get { return mob3; }
            set { mob3 = value; }
        }
        public string MOB4
        {
            get { return mob4; }
            set { mob4 = value; }
        }
        public string OPTIONS
        {
            get { return options; }
            set { options = value; }
        }
        public string SETKEYS
        {
            get { return setKeys; }
            set { setKeys = value; }
        }
        #endregion

        // Methods.
        private void SetText()
        {
            if (stateOptions.ENGLISHMODE)
            {
                /* Options */
                fullscreen = "Fullscreen";
                englishMode = "English";
                frenchMode = "French";
                mainMenu = "Main Menu";
                mute = "   Mute";
                volumeUp = "Vol. Up";
                volumeDown = "Vol. Down";
                setKeys = "Set Keys";

                /* Survival */
                SurvivalRestart = "Restart";
                SurvivalMenu = "Main Menu";
                SurvivalResume = "Resume";

                /* Settings hotkeys */
                options = "Options";
                trap1 = "Piege 1";
                trap2 = "Piege 2";
                trap3 = "Piege 3";
                trap4 = "Piege 4";
                spell1 = "Sort 1";
                spell2 = "Sort 2";
                spell3 = "Sort 3";
                spell4 = "Sort 4";
                mob1 = "Monstre 1";
                mob2 = "Monstre 2";
                mob3 = "Monstre 3";
                mob4 = "Monstre 4";
            }
            else if (stateOptions.FRENCHMODE)
            {
                /* Options */
                fullscreen = "Plein Ecran";
                englishMode = "Anglais";
                frenchMode = "Francais";
                mainMenu = "   Menu";
                mute = "   Mute";
                volumeUp = "Augmenter";
                volumeDown = "Diminuer";
                setKeys = "Config. C";

                /* Survival */
                SurvivalRestart = "Rejouer";
                SurvivalMenu = "   Menu";
                SurvivalResume = "Continuer";

                /* Settings hotkeys */
                options = "Options";
                trap1 = "Trap 1";
                trap2 = "Trap 2";
                trap3 = "Trap 3";
                trap4 = "Trap 4";
                spell1 = "Spell 1";
                spell2 = "Spell 2";
                spell3 = "Spell 3";
                spell4 = "Spell 4";
                mob1 = "Monster 1";
                mob2 = "Monster 2";
                mob3 = "Monster 3";
                mob4 = "Monster 4";
            }
        }

        // Update.
        public void Update()
        {
            SetText();
        }
    }
}
