using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor
{
    class HUDState
    {
        // Fields.
        protected static bool EnabledSelection, EnabledRemove, EnabledAdd;
        protected static bool modeEdition = false, DrawModeEdition = false;
        protected static bool planB = true, planM = true, planF = true, planA = true;
        protected static bool downNumber = false, upNumber = false;
        protected static int newNumber;

        // Methods.
        protected void InitBackground()
        {
            if (planB && planM && planF && planA)
            {
                planB = false;
                planM = false;
                planF = false;
                planA = false;
            }
        }
    }
}
