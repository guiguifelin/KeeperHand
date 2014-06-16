using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    class TilePath
    {
        private int tilesizeX = Ressources.tileset_middleground.Width / 5, tilesizeY = Ressources.tileset_middleground.Height / 4;
        private Vector2 tilePos;
        public Vector2 TilePos { get{ return tilePos; } }
        private int id = 0;
        public int ID
        { 
            get { return id; }
            set { id = value; }
        }
        public int Type = 0;
        //value 0 : standard
        //value 1 : start
        //value 2 : end
        //value 4 : way
        //value 3 : wall

        public Rectangle recTile
        {
            get { return new Rectangle((int)tilePos.X * tilesizeX, (int)tilePos.Y * tilesizeY, tilesizeX, tilesizeY); }
        }
        public TilePath(Vector2 tilePos, int newId)
        {
            this.tilePos = tilePos;
            this.id = newId;
        }
    }
}
