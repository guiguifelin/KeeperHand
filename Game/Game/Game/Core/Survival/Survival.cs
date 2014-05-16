using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    public class Survival
    {
        // Fields.
        private List<IA> IAs;
        private List<Chest> chests;
        private HUD hud;
        private Keeper keeper;
        private WinSurvival win;
        private FailSurvival fail;
        private Cursor cursor;
        private bool chestsReady, layering;
        private float currentTime, countDuration;

        // Constructor.
        public Survival(Cursor cursor)
        {
            this.cursor = cursor;
            this.currentTime = 0f;
            this.countDuration = 0.5f;
            this.chestsReady = false;
            this.layering = true;
            IAs = new List<IA>();
            chests = new List<Chest>();
            win = new WinSurvival(Ressources.bg_Win);
            fail = new FailSurvival(Ressources.bg_Fail);
            IAs.Add(new IA(Ressources.tileset_ia1, 400, 200, 32, 32, 100, 100));
            hud = new HUD(Ressources.bg_HUD);
            keeper = new Keeper(cursor, hud, ref IAs, 500, 1000, 1000);
            AbstractSetGame.LoadMap(AbstractSetGame.lvl);
        }

        // Get & Set.
        public List<IA> LISTIA
        {
            get { return IAs; }
            set { IAs = value; }
        }
        public Keeper KEEPER
        {
            get { return keeper; }
        }

        // Methods.

        public void RestartSurvival()
        {
            chestsReady = false;
            IAs.Clear();
            IAs.Add(new IA(Ressources.tileset_ia1, 400, 200, 32, 32, 100, 100));
            chests.Clear();
            keeper.MONEY = 1000;
            keeper.MANA = 500;
        }

        private void WinOrNot(Game1 game, GameTime time, MouseState mouse)
        {
            if (IAs.Count == 0)
            {
                win.Update(game, time, cursor, mouse);
            }
            else if (keeper.MONEY == 0)
            {
                fail.Update(game, time, cursor, mouse);
            }
        }

        #region Map

        private void DrawMap(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < AbstractSetGame.maps.Length; i++)
            {
                AbstractSetGame.maps[i].Draw(spriteBatch);
            }
        }

        #endregion
        #region IAs
        public void CheckAndRemoveIA()
        {
            for (int i = 0; i < IAs.Count; i++)
            {
                if (IAs[i].Life == 0)
                {
                    IAs.RemoveAt(i);
                    i--;
                }
            }
        }
        #endregion

        // Update & Draw.
        #region Update & Draw

        public void Update(Game1 game, GameTime gameTime, MouseState mouse, KeyboardState keyboard)
        {
            CollisionMap.Update(IAs);
            if (chestsReady && IAs.Count != 0 && keeper.MONEY != 0)
            {
                CheckAndRemoveIA();
                foreach (IA ia in IAs)
                {
                    ia.Update(gameTime, keyboard);
                }
                for (int i = 0; i < chests.Count; i++)
                {
                    chests[i].Update(gameTime, IAs);
                    if (chests[i].OPENED)
                    {
                        keeper.MinusMoney(chests[i].MONEY);
                    }
                    if (chests[i].LIFE == 0)
                    {
                        chests.RemoveAt(i);
                        i--;
                    }
                }
                hud.Update(cursor, mouse, gameTime);
                keeper.Update(game, gameTime, keyboard, mouse);
            }
            else
            {
                CollisionMap.Update(chests, AbstractSetGame.maps[0], AbstractSetGame.maps[1]);
                currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (chests.Count < 10)
                {
                    if (mouse.LeftButton == ButtonState.Pressed && layering)
                    {
                        chests.Add(new Chest(Ressources.tileset_Chest, Ressources.t_Chest, new Vector2(mouse.X, mouse.Y), false, 100, 100, 100));
                        layering = false;
                    }
                    else if (currentTime >= countDuration)
                    {
                        layering = true;
                        currentTime -= countDuration;
                    }
                }
                else
                {
                    chestsReady = true;
                }
            }
            WinOrNot(game, gameTime, mouse);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IAs.Count != 0 && keeper.MONEY != 0)
            {
                DrawMap(spriteBatch);
                /* Vérification collision par pixel grace aux textures data.
                AbstractSetGame.maps[1].DrawTextureData(spriteBatch); */
                foreach (Chest chest in chests)
                {
                    chest.Draw(spriteBatch);
                }
                if (chestsReady)
                {
                    foreach (IA ia in IAs)
                    {
                        ia.Draw(spriteBatch);
                    }
                }
                hud.Draw(spriteBatch);
                keeper.Draw(spriteBatch);
            }
            else
            {
                if (IAs.Count == 0)
                {
                    win.Draw(spriteBatch);
                }
                else if (keeper.MONEY == 0)
                {
                    fail.Draw(spriteBatch);
                }
            }
        }

        #endregion
    }
}
