using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SavingMap;

namespace MapEditor
{
    /// <summary>
    /// Précédemment : Fini l'édition de map.
    /// 1) Faire la création de donjon.
    /// </summary>

    public class CreateMap
    {
        enum CreateMapState
        {
            Background,
            Middleground,
            Foreground,
            Action
        }

        // Fields.
        private ArrayMap map;
        private List<Map> maps;
        private CreateMapState State;
        private bool changedMap, drawHelp, createDonjon;
        private int currentNumber, currentX, currentY;

        // Construtor.
        public CreateMap(GraphicsDevice graphics, bool createDonjon)
        {
            State = CreateMapState.Background;
            map = new ArrayMap();
            map.MapBackground = map.InitMap(Ressources.t_background, 6, 0, graphics.Viewport);
            map.MapMiddleground = map.InitMap(Ressources.t_middleground, 5, 4, graphics.Viewport);
            map.MapForeground = map.InitMap(Ressources.t_middleground, 5, 4, graphics.Viewport);
            map.MapAction = map.InitMap(Ressources.t_middleground, 5, 4, graphics.Viewport);
            changedMap = true;
            drawHelp = false;
            this.createDonjon = createDonjon;
            currentNumber = 1;
            currentX = 0;
            currentY = 0;

            /* Initialize */
            maps = new List<Map>();
            maps.Add(new Map(Ressources.t_background, 6, 0));
            maps.Add(new Map(Ressources.t_middleground, 5, 4));

            maps[0].Generate(map.MapBackground);
            maps[1].Generate(map.MapMiddleground);
        }

        // Get & Set.

        // Methods.
        private void UpdateCurrentNumber(int max, int max_X, int max_Y)
        {
            int MAX_X, MAX_Y;
            if (max_X > 0)
            {
                MAX_X = max_X - 1;
            }
            else
            {
                MAX_X = max_X;
            }

            if (max_Y > 0)
            {
                MAX_Y = max_Y - 1;
            }
            else
            {
                MAX_Y = max_Y;
            }

            if (Inputs.isKeyRelease(Keys.Up))
            {
                if(currentNumber < max)
                {
                    currentNumber++;
                }
                else
                {
                    currentNumber = 1;
                }
                if (currentNumber != 0)
                {
                    if (currentX < MAX_X)
                    {
                        currentX++;
                    }
                    else
                    {
                        currentX = 0;
                        if (currentY < MAX_Y)
                        {
                            currentY++;
                        }
                        else
                        {
                            currentY = 0;
                        }
                    }
                }
            }
            else if (Inputs.isKeyRelease(Keys.Down))
            {
                if (currentNumber > 0)
                {
                    currentNumber--;
                }
                else
                {
                    currentNumber = max;
                }
                if (currentNumber != 0)
                {
                    if (currentX > 0)
                    {
                        currentX--;
                    }
                    else
                    {
                        currentX = MAX_X;
                        if (currentY > 0)
                        {
                            currentY--;
                        }
                        else
                        {
                            currentY = MAX_Y;
                        }
                    }
                }
            }
            if (currentNumber == 1)
            {
                currentX = 0;
                currentY = 0;
            }
            if (currentNumber == max)
            {
                currentX = MAX_X;
                currentY = MAX_Y;
            }
            Console.WriteLine("[INFO] Current number : " + currentNumber);
        }
        private void PutNumber(int x, int y)
        {
            switch (State)
            {
                case CreateMapState.Background:
                    map.MapBackground[y / (Ressources.t_background.Width / 6), x / Ressources.t_background.Height] = currentNumber;
                    changedMap = true;
                    break;
                case CreateMapState.Middleground:
                    map.MapMiddleground[y / (Ressources.t_middleground.Height / 4), x / (Ressources.t_middleground.Width / 5)] = currentNumber;
                    changedMap = true;
                    break;
                case CreateMapState.Foreground:
                    break;
                case CreateMapState.Action:
                    break;
            }
        }
        private void RemoveNumber(int x, int y)
        {
            switch (State)
            {
                case CreateMapState.Background:
                    map.MapBackground[y / (Ressources.t_background.Width / 6), x / Ressources.t_background.Height] = 0;
                    changedMap = true;
                    break;
                case CreateMapState.Middleground:
                    map.MapMiddleground[y / (Ressources.t_middleground.Height / 4), x / (Ressources.t_middleground.Width / 5)] = 0;
                    changedMap = true;
                    break;
                case CreateMapState.Foreground:
                    break;
                case CreateMapState.Action:
                    break;
            }
        }
        private void DrawHelp(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Ressources.font1, "Background : A\nMiddleground : Z\nForeground : E\nAction : R\n\nPut : Left click\nRemove : Right click\nDrop : D\nNext tile : Up\nPrev. tile : Down\n\nFullscreen : F\nMain menu : Escape\n\nReset Map : F1\nSave map : F2\nLoad Map : F3", new Vector2(10, 10), Color.White);
        }
        private void RemoveMap()
        {
            switch (State)
            {
                case CreateMapState.Background:
                    for (int i = 0; i < map.MapBackground.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.MapBackground.GetLength(1); j++)
                        {
                            map.MapBackground[i, j] = 0;
                        }
                    }
                    break;
                case CreateMapState.Middleground:
                    for (int i = 0; i < map.MapMiddleground.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.MapMiddleground.GetLength(1); j++)
                        {
                            map.MapMiddleground[i, j] = 0;
                        }
                    }
                    break;
                case CreateMapState.Foreground:
                    for (int i = 0; i < map.MapForeground.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.MapForeground.GetLength(1); j++)
                        {
                            map.MapForeground[i, j] = 0;
                        }
                    }
                    break;
                case CreateMapState.Action:
                    for (int i = 0; i < map.MapAction.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.MapAction.GetLength(1); j++)
                        {
                            map.MapAction[i, j] = 0;
                        }
                    }
                    break;
            }
            changedMap = true;
        }
        private int FindNumber(int x, int y)
        {
            switch (State)
            {
                case CreateMapState.Background:
                    return map.MapBackground[y / (Ressources.t_background.Width / 6), x / Ressources.t_background.Height];
                case CreateMapState.Middleground:
                    return map.MapMiddleground[y / (Ressources.t_middleground.Height / 4), x / (Ressources.t_middleground.Width / 5)];
                case CreateMapState.Foreground:
                    return map.MapMiddleground[y / (Ressources.t_middleground.Height / 4), x / (Ressources.t_middleground.Width / 5)];
                case CreateMapState.Action:
                    return map.MapMiddleground[y / (Ressources.t_middleground.Height / 4), x / (Ressources.t_middleground.Width / 5)];
                default:
                    return 0;
            }
        }

        // Update & Draw.
        public void Update(Game1 game, GameTime time, Cursor cursor)
        {
            if (Inputs.isKeyRelease(Keys.A))
            {
                State = CreateMapState.Background;
            }
            else if (Inputs.isKeyRelease(Keys.Z))
            {
                State = CreateMapState.Middleground;
            }
            else if (Inputs.isKeyRelease(Keys.E))
            {
                State = CreateMapState.Foreground;
            }
            else if (Inputs.isKeyRelease(Keys.R))
            {
                State = CreateMapState.Action;
            }
            else if (!createDonjon && Inputs.isKeyRelease(Keys.H))
            {
                drawHelp = !drawHelp;
            }
            else if (Inputs.isKeyRelease(Keys.F1))
            {
                RemoveMap();
            }
            else if (!createDonjon && Inputs.isKeyRelease(Keys.F2))
            {
                Data.Serialization(map, 0, "map");
            }
            else if (!createDonjon && Inputs.isKeyRelease(Keys.F3))
            {
                map = Data.Deserialization(0, "map");
                changedMap = true;
            }
            else if (Inputs.isKeyRelease(Keys.D))
            {
                int prevNumber = currentNumber;
                currentNumber = FindNumber(Mouse.GetState().X, Mouse.GetState().Y);
                if (currentNumber > prevNumber)
                {
                    currentX += currentNumber - prevNumber;
                    currentY += currentNumber - prevNumber;
                }
                else if (currentNumber < prevNumber)
                {
                    currentX -= prevNumber - currentNumber;
                    currentY -= prevNumber - currentNumber;
                }
            }

            if (Inputs.isKeyRelease(Keys.Escape))
            {
                RemoveMap();
                game.MAIN.State = EditorState.MainMenu;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                PutNumber(Mouse.GetState().X, Mouse.GetState().Y);
            }
            else if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                RemoveNumber(Mouse.GetState().X, Mouse.GetState().Y);
            }

            switch (State)
            {
                case CreateMapState.Background:
                    UpdateCurrentNumber(6, 6, 0);
                    break;
                case CreateMapState.Middleground:
                    UpdateCurrentNumber(20, 5, 4);
                    break;
                case CreateMapState.Foreground:
                    UpdateCurrentNumber(20, 5, 4);
                    break;
                case CreateMapState.Action:
                    UpdateCurrentNumber(20, 5, 4);
                    break;
            }

            if (changedMap)
            {
                maps[0].Tiles.Clear();
                maps[1].Tiles.Clear();
                maps[0].Generate(map.MapBackground);
                maps[1].Generate(map.MapMiddleground);
                changedMap = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Map item in maps)
            {
                item.Draw(spriteBatch);
            }

            switch (State)
            {
                case CreateMapState.Background:
                    spriteBatch.Draw(Ressources.selection, new Rectangle((Mouse.GetState().X / (Ressources.t_background.Width / 6)) * (Ressources.t_background.Width / 6), (Mouse.GetState().Y / Ressources.t_background.Height) * Ressources.t_background.Height, Ressources.t_background.Width / 6, Ressources.t_background.Height), Color.White);
                    spriteBatch.Draw(Ressources.t_background, new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, Ressources.t_background.Width / 6, Ressources.t_background.Height),
                        new Rectangle(currentX * (Ressources.t_background.Width / 6), currentY * Ressources.t_background.Height, Ressources.t_background.Width / 6, Ressources.t_background.Height),
                        Color.White);
                    break;
                case CreateMapState.Middleground:
                    spriteBatch.Draw(Ressources.selection, new Rectangle((Mouse.GetState().X / (Ressources.t_middleground.Width / 5)) * (Ressources.t_middleground.Width / 5), (Mouse.GetState().Y / (Ressources.t_middleground.Height / 4)) * (Ressources.t_middleground.Height / 4), Ressources.t_middleground.Width / 5, Ressources.t_middleground.Height / 4), Color.White);
                    spriteBatch.Draw(Ressources.t_middleground, new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, Ressources.t_middleground.Width / 5, Ressources.t_middleground.Height / 4),
                        new Rectangle(currentX * (Ressources.t_middleground.Width / 5), currentY * (Ressources.t_middleground.Height / 4), Ressources.t_middleground.Width / 5, Ressources.t_middleground.Height / 4),
                        Color.White);
                    break;
                case CreateMapState.Foreground:
                    spriteBatch.Draw(Ressources.selection, new Rectangle((Mouse.GetState().X / (Ressources.t_middleground.Width / 5)) * (Ressources.t_middleground.Width / 5), (Mouse.GetState().Y / Ressources.t_middleground.Height / 4) * (Ressources.t_middleground.Height / 4), Ressources.t_middleground.Width / 5, Ressources.t_middleground.Height / 4), Color.White);
                    spriteBatch.Draw(Ressources.t_middleground, new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, Ressources.t_middleground.Width / 5, Ressources.t_middleground.Height / 4),
                        new Rectangle(currentX * (Ressources.t_middleground.Width / 5), currentY * (Ressources.t_middleground.Height / 4), Ressources.t_middleground.Width / 5, Ressources.t_middleground.Height / 4),
                        Color.White);
                    break;
                case CreateMapState.Action:
                    spriteBatch.Draw(Ressources.selection, new Rectangle((Mouse.GetState().X / (Ressources.t_middleground.Width / 5)) * (Ressources.t_middleground.Width / 5), (Mouse.GetState().Y / Ressources.t_middleground.Height / 4) * (Ressources.t_middleground.Height / 4), Ressources.t_middleground.Width / 5, Ressources.t_middleground.Height / 4), Color.White);
                    spriteBatch.Draw(Ressources.t_middleground, new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, Ressources.t_middleground.Width / 5, Ressources.t_middleground.Height / 4),
                        new Rectangle(currentX * (Ressources.t_middleground.Width / 5), currentY * (Ressources.t_middleground.Height / 4), Ressources.t_middleground.Width / 5, Ressources.t_middleground.Height / 4),
                        Color.White);
                    break;
            }

            if (drawHelp)
            {
                DrawHelp(spriteBatch);
            }
            else
            {
                spriteBatch.DrawString(Ressources.font1, "Help : H", new Vector2(10, 10), Color.White);
            }
        }
    }
}
