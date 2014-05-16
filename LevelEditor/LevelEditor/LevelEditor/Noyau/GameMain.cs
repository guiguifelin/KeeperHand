using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using SavingMap;

namespace LevelEditor
{
    class GameMain : HUDState
    {
        // Fields.

        private Game1 game;
        private SelectionTile selection;
        private Sprite sprite;
        private Map mapMiddleground, mapBackground;
        private HUD hud;
        private Cursor cursor;
        private SavingMap.ArrayMap maps;

        /* States */
        private bool hasSaved = false;
        private bool hasLoad = false;
        private int counter = 0;

        // Constructor.

        public GameMain(Game1 game, int sizeX, int sizeY)
        {
            this.game = game;
            maps = new SavingMap.ArrayMap();
            maps.MapBackground = maps.InitMap(Ressources.tileSetFloorInt, 6, 0, game.GraphicsDevice.Viewport);
            maps.MapMiddleground = maps.InitMap(Ressources.tileSetInterieur, 5, 4, game.GraphicsDevice.Viewport); 
            maps.MapForeground = maps.InitMap(Ressources.tileSetInterieur, 5, 4, game.GraphicsDevice.Viewport);
            maps.MapAction = maps.InitMap(Ressources.tileSetInterieur, 5, 4, game.GraphicsDevice.Viewport);
            selection = new SelectionTile(Ressources.SelectionTest);
            mapBackground = new Map(Ressources.tileSetFloorInt, this.cursor, this.selection, 6, 0, maps.MapBackground);
            mapMiddleground = new Map(Ressources.tileSetInterieur, this.cursor, this.selection, 5, 4, maps.MapMiddleground);
            cursor = new Cursor(50, 50, 2);
            sprite = new Sprite(new Vector2(875, 30), 5, 4, 6, 1, 5, 4);
            hud = new HUD(this.game, Ressources.textureHUD, this.cursor, this.sprite);
        }

        // Get & Set.

        // Methods.

        private void UpdateAllGround(MouseState mouse)
        {
            if (planB)
            {
                mapBackground.Update(mouse);
            }
            if (planM)
            {
                mapMiddleground.Update(mouse);
            }
        }
        private void DrawSelection(SpriteBatch spriteBatch)
        {
            if (planB)
            {
                selection.Draw(spriteBatch);
            }
            else if (planM)
            {
                selection.Draw(spriteBatch);
            }
        }

        // Update & Draw.

        public void Update(GameTime gameTime, KeyboardState keyboard, MouseState mouse)
        {
            UpdateAllGround(mouse);
            InitBackground();
            cursor.Update(gameTime, mouse, keyboard);
            hud.Update(gameTime, mouse);
            sprite.Update(mouse);

            if (keyboard.IsKeyDown(Keys.S))
            {
                maps.SaveAllMaps(mapBackground.MapTab, mapMiddleground.MapTab, maps.MapForeground, maps.MapAction);
                SavingMap.Data.Serialization(maps, 1, "map");
                hasSaved = true;
            }
            else if (keyboard.IsKeyDown(Keys.L))
            {
                maps = SavingMap.Data.Deserialization(1, "map");
                mapBackground.LoadArrayMap(maps.MapBackground);
                mapMiddleground.LoadArrayMap(maps.MapMiddleground);
                hasLoad = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mapBackground.Draw(spriteBatch, Mouse.GetState());
            mapMiddleground.Draw(spriteBatch, Mouse.GetState());
            DrawSelection(spriteBatch);
            hud.Draw(spriteBatch);
            sprite.Draw(spriteBatch);
            cursor.Draw(spriteBatch);

            if (counter < 30)
            {
                if (hasSaved)
                {
                    SetPopUp.AddText(new TextPopUp(Ressources.font1, "All maps are saved !", new Vector2((1150 / 2) - 20, 680 / 2), Color.White));
                }
                else if (hasLoad)
                {
                    SetPopUp.AddText(new TextPopUp(Ressources.font1, "Maps are loaded !", new Vector2((1150 / 2) - 20, 680 / 2), Color.White));
                }
                SetPopUp.Draw(spriteBatch);
            }
            else
            {
                SetPopUp.DeleteAllList();
                hasSaved = false;
                hasLoad = false;
                counter = 0;
            }
            counter++;
        }
    }
}
