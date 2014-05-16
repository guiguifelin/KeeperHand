using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LevelEditor
{
    class HUD : HUDComponent
    {
        // Fields.

        // Constructor.

        public HUD(Game1 game, Texture2D texture, Cursor cursor, Sprite sprite)
        {
            this.texture = texture;
            this.cursor = cursor;
            this.game = game;
            this.sprite = sprite;

            InitComponent();
        }

        // Get & Set.

        // Methods.
    }
}
