using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace LevelEditor
{
    class SetPopUp
    {
        // Fields.

        private static List<TextPopUp> textPop = new List<TextPopUp>();

        // Classe STATIC.
        public static void DeleteAllList()
        {
            for (int i = 0; i < textPop.Count; i++)
            {
                textPop.RemoveAt(i);
            }
        }
        public static void AddText(TextPopUp textPopUp)
        {
            textPop.Add(textPopUp);
        }

        public static void Update()
        {
            foreach (TextPopUp popUp in textPop)
            {
                popUp.Update();
            }
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach(TextPopUp popUp in textPop)
            {
                popUp.Draw(spriteBatch);
            }
        }
    }
}
