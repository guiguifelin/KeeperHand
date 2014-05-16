using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LevelEditor
{
    class Sprite : HUDState
    {
        // Fields.
        private Vector2 position;
        protected Texture2D tilesetForeground;
        protected Texture2D tilesetMiddleground = Ressources.tileSetInterieur;
        protected Texture2D tilesetBackground = Ressources.tileSetFloorInt;
        protected int countTileXMid, countTileYMid, countTileXBack, countTileYBack, countTileXFore, countTileYFore;
        protected int number = 1;
        protected int xMap, yMap, sizeX, sizeY;

        // Constructor.

        public Sprite(Vector2 position, int countTileXMid, int countTileYMid, int countTileXBack, int countTileYBack, int countTileXFore, int countTileYFore)
        {
            this.position = position;
            this.countTileXMid = countTileXMid;
            this.countTileYMid = countTileYMid;
            this.countTileXBack = countTileXBack;
            this.countTileYBack = countTileYBack;
            this.countTileXFore = countTileXFore;
            this.countTileYFore = countTileYFore;
        }

        // Get & Set.

        // Methods.
        protected void SelectTile(int number)
        {
            xMap = 0;
            yMap = 0;
            if (planM)
            {
                for (int i = 1; i < number; i++)
                {
                    if (i > countTileXMid - 1)
                    {
                        yMap++;
                        xMap = 0;
                    }
                    if (yMap > countTileYMid - 1)
                    {
                        yMap = 0;
                    }
                    xMap++;
                }
            }
            else if (planB)
            {
                for (int i = 1; i < number; i++)
                {
                    if (i > countTileXBack - 1)
                    {
                        yMap++;
                        xMap = 0;
                    }
                    if (yMap > countTileYBack - 1)
                    {
                        yMap = 0;
                    }
                    xMap++;
                }
            }
            else if (planF)
            {
                for (int i = 1; i < number; i++)
                {
                    if (i > countTileXFore - 1)
                    {
                        yMap++;
                        xMap = 0;
                    }
                    if (yMap > countTileYFore - 1)
                    {
                        yMap = 0;
                    }
                    xMap++;
                }
            }
        }
        protected void IncrementNumber()
        {
            if (planB && upNumber)
            {
                if (number < countTileXBack * countTileYBack)
                {
                    number++;
                    upNumber = false;
                }
                else
                {
                    number = 0;
                    upNumber = false;
                }
            }
            else if (planM && upNumber)
            {
                if (number < countTileXMid * countTileYMid)
                {
                    number++;
                    upNumber = false;
                }
                else
                {
                    number = 0;
                    upNumber = false;
                }
            }
            else if (planF && upNumber)
            {
                if (number < countTileXFore * countTileYFore)
                {
                    number++;
                    upNumber = false;
                }
                else
                {
                    number = 0;
                    upNumber = false;
                }
            }
            else if (planB && downNumber)
            {
                if (number < 0)
                {
                    number = (countTileXBack * countTileYBack) - 1;
                    downNumber = false;
                }
                else
                {
                    number--;
                    downNumber = false;
                }
            }
            else if (planM && downNumber)
            {
                if (number < 0)
                {
                    number = (countTileXMid * countTileYMid) - 1;
                    downNumber = false;
                }
                else
                {
                    number--;
                    downNumber = false;
                }
            }
            else if (planF && downNumber)
            {
                if (number < 0)
                {
                    number = (countTileXFore * countTileYFore) - 1;
                    downNumber = false;
                }
                else
                {
                    number--;
                    downNumber = false;
                }
            }
        }
        protected void SetSize()
        {
            if (planB)
            {
                if (countTileXBack > 0)
                {
                    sizeX = tilesetBackground.Width / countTileXBack;
                }
                else
                {
                    sizeX = tilesetBackground.Width;
                }
                if (countTileYBack > 0)
                {
                    sizeY = tilesetBackground.Height / countTileYBack;
                }
                else
                {
                    sizeY = tilesetBackground.Height;
                }
            }
            else if (planM)
            {
                if (countTileXMid > 0)
                {
                    sizeX = tilesetMiddleground.Width / countTileXMid;
                }
                else
                {
                    sizeX = tilesetMiddleground.Width;
                }
                if (countTileYMid > 0)
                {
                    sizeY = tilesetMiddleground.Height / countTileYMid;
                }
                else
                {
                    sizeY = tilesetMiddleground.Height;
                }
            }
            else if (planF)
            {
                if (countTileXFore > 0)
                {
                    sizeX = tilesetForeground.Width / countTileXFore;
                }
                else
                {
                    sizeX = tilesetForeground.Width;
                }
                if (countTileYFore > 0)
                {
                    sizeY = tilesetForeground.Height / countTileYFore;
                }
                else
                {
                    sizeY = tilesetForeground.Height;
                }
            }
        }

        // Update & Draw.

        public void Update(MouseState mouse)
        {
            if ((upNumber || downNumber) && mouse.LeftButton == ButtonState.Released)
            {
                upNumber = false;
                downNumber = false;
            }

            IncrementNumber();
            SetSize();
            SelectTile(number);
            newNumber = number;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (DrawModeEdition)
            {
                if (planB)
                {
                    spriteBatch.Draw(tilesetBackground, new Rectangle((int)position.X, (int)position.Y, sizeX, sizeY), new Rectangle(xMap * sizeX, yMap * sizeY, sizeX, sizeY), Color.White);
                }
                else if (planM)
                {
                    spriteBatch.Draw(tilesetMiddleground, new Rectangle((int)position.X, (int)position.Y, sizeX, sizeY), new Rectangle(xMap * sizeX, yMap * sizeY, sizeX, sizeY), Color.White);
                }
                else if (planF)
                {
                    spriteBatch.Draw(tilesetForeground, new Rectangle((int)position.X, (int)position.Y, sizeX, sizeY), new Rectangle(xMap * sizeX, yMap * sizeY, sizeX, sizeY), Color.White);
                }
            }
        }
    }
}
