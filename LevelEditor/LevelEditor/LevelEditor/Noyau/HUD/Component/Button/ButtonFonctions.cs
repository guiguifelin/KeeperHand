using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor
{
    class ButtonFonctions : HUDState
    {
        //Fields.
        protected string function;
        protected Game1 game;

        // Methods.

        private void EnableSelection()
        {
            switch (EnabledSelection)
            {
                case true:
                    EnabledSelection = false;
                    break;
                default:
                    EnabledSelection = true;
                    break;
            }
        }
        private void EnableRemove()
        {
            switch (EnabledRemove)
            {
                case true:
                    EnabledRemove = false;
                    break;
                default:
                    EnabledRemove = true;
                    break;
            }
        }
        private void EnableAdd()
        {
            switch (EnabledAdd)
            {
                case true:
                    EnabledAdd = false;
                    break;
                default:
                    EnabledAdd = true;
                    break;
            }
        }
        private void EnableMiddleground()
        {
            switch (planM)
            {
                case true:
                    planM = false;
                    break;
                default:
                    planM = true;
                    break;
            }
        }
        private void EnableBackground()
        {
            switch (planB)
            {
                case true:
                    planB = false;
                    break;
                default:
                    planB = true;
                    break;
            }
        }
        private void SetModeEdition()
        {
            switch (modeEdition)
            {
                case true:
                    modeEdition = false;
                    break;
                default:
                    modeEdition = true;
                    break;
            }
        }
        private void SetNumberMapUp()
        {
            upNumber = !upNumber;
        }
        private void SetNumberMapDown()
        {
            downNumber = !downNumber;
        }

        // Get & Set.

        // Gestion des fonctions.
        protected void Function(string func)
        {
            switch (func)
            {
                case "Exit":
                    game.Exit();
                    break;
                case "Selection":
                    EnableSelection();
                    break;
                case "Remove":
                    EnableRemove();
                    break;
                case "Add":
                    EnableAdd();
                    break;
                case "EnableMiddleground":
                    EnableMiddleground();
                    break;
                case "EnableBackground":
                    EnableBackground();
                    break;
                case "OnOffModeEdition":
                    SetModeEdition();
                    break;
                case "UpNumber":
                    SetNumberMapUp();
                    break;
                case "DownNumber":
                    SetNumberMapDown();
                    break;
                default:
                    break;
            }
        }
    }
}
