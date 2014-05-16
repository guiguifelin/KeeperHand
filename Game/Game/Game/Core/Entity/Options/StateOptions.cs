using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    [Serializable]
    public class StateOptions
    {
        // Fields.
        private bool FullScreenMode;
        private bool EnabledSave, EnabledChangeLangMenu, EnabledChangeLangOptions, EnabledChangeLangWinFail, EnabledChangeLangKeyset;
        private bool FR, EN;
        private bool SoundMuted, EnabledChangeVol;
        private bool EnabledAz, EnabledQw, EnabledCustomKeys;

        // Constructors.
        public StateOptions() { }
        public StateOptions(bool fullscreen)
        {
            FullScreenMode = fullscreen;
            EnabledSave = false;
            EnabledChangeLangMenu = false;
            EnabledChangeLangOptions = false;
            EnabledChangeLangWinFail = false;
            EnabledChangeVol = false;
            SoundMuted = false;
            EnabledQw = false;
            EnabledAz = true;
            EN = true;
            FR = false;
            EnabledChangeLangKeyset = false;
            EnabledCustomKeys = false;
            SaveStateOptions();
        }

        // Get.
        public bool FULLSCREENMODE
        {
            get { return FullScreenMode; }
            set { FullScreenMode = value; }
        }
        public bool ENABLEDSAVE
        {
            get { return EnabledSave; }
            set { EnabledSave = value; }
        }
        public bool ENGLISHMODE
        {
            get { return EN; }
            set { EN = value; }
        }
        public bool FRENCHMODE
        {
            get { return FR; }
            set { FR = value; }
        }
        public bool ENABLEDCHANGELANGMENU
        {
            get { return EnabledChangeLangMenu; }
            set { EnabledChangeLangMenu = value; }
        }
        public bool ENABLEDCHANGELANGOPTIONS
        {
            get { return EnabledChangeLangOptions; }
            set { EnabledChangeLangOptions = value; }
        }
        public bool ENABLEDCHANGELANGWINFAIL
        {
            get { return EnabledChangeLangWinFail; }
            set { EnabledChangeLangWinFail = value; }
        }
        public bool SOUDNMUTED
        {
            get { return SoundMuted; }
            set { SoundMuted = value; }
        }
        public bool ENABLEDCHANGEVOL
        {
            get { return EnabledChangeVol; }
            set { EnabledChangeVol = value; }
        }
        public bool ENABLEDQW
        {
            get { return EnabledQw; }
            set { EnabledQw = value; }
        }
        public bool ENABLEDAZ
        {
            get { return EnabledAz; }
            set { EnabledAz = value; }
        }
        public bool ENABLEDCHANGELANGKEYSET
        {
            get { return EnabledChangeLangKeyset; }
            set { EnabledChangeLangKeyset = value; }
        }
        public bool ENABLEDCUSTOMKEYS
        {
            get { return EnabledCustomKeys; }
            set { EnabledCustomKeys = value; }
        }

        // Methods.
        public static StateOptions LoadStateOptions(StateOptions state)
        {
            return Data.Deserialization(state, "StateOptions");
        }
        public void SaveStateOptions()
        {
            Data.Serialization(this, "StateOptions");
        }
        public void SaveHotkeys(Game1 game)
        {
            Data.Serialization(game.MAIN.HOTKEYS, "Hotkeys");
        }

        public void Update(Game1 game)
        {
            if (EnabledSave != false)
            {
                SaveHotkeys(game);
                SaveStateOptions();
                EnabledSave = false;
            }
        }
    }
}
