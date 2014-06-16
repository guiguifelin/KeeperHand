using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    class Console
    {
        public static List<string> TextConsole = new List<string>();
        private bool afficher;

        public Console()
        {
            this.afficher = false;
        }

        public static void WriteLine(string str)
        {
            TextConsole.Add(str);
        }
     
        public void Update()
        {
            if (Inputs.isKeyRelease(Keys.LeftControl))
            {
                afficher = !afficher;
            }
            
            if (TextConsole.Count>50)
            {
                TextConsole.RemoveAt(0);
            }
            
        }

        public void Draw(SpriteBatch s)
        {
            if (afficher)
            {
                s.Draw(Ressources.bg_console, new Rectangle(0, 0, 1280, 740), Color.White);
                for (int i = 0; i < TextConsole.Count; i++)
                {
                    s.DrawString(Ressources.font, TextConsole[i], new Vector2(10, i * 20), Color.White);
                }
            }
        }
    }
}
