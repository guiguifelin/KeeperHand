using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace MapEditor
{
    class Effects
    {
        //Methods
        protected void function(Game1 game, string gs)
        {
            switch (gs)
            {
                case "NEWMAP":
                    game.MAIN.State = EditorState.CreateMap;
                    break;
                case "NEWDONJON":
                    game.MAIN.State = EditorState.CreateDonjon;
                    break;
                case "EXIT":
                    game.Exit();
                    break;
                case "VALIDATESETTINGS":
                    game.MAIN.CreateDonjon.validate = true;
                    break;
            }
        }
    }
}
