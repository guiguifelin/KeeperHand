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
        public enum SurvivalState
        {
            None,
            Solo,
            MultiLocal,
            MultiOnline
        }
        // Fields.
        private List<IA> IAs;
        private List<Enemy> enemies;
        private List<Chest> chests;
        private HUD hud;
        private Keeper keeper;
        private WinSurvival win;
        private FailSurvival fail;
        private Cursor cursor;
        private Game1 game;
        private Menu typeGame;
        private ParticleGenerator particles;
        private bool chestsReady, layering;
        private float currentTime, countDuration;
        public SurvivalState s_state;

        // Constructor.
        public Survival(Game1 game, Cursor cursor, Sound sm, TextManager tm, bool french, bool english)
        {
            this.game = game;
            this.cursor = cursor;
            this.currentTime = 0f;
            this.countDuration = 0.5f;
            this.chestsReady = false;
            this.layering = true;
            this.s_state = SurvivalState.None;
            particles = null;
            IAs = new List<IA>();
            chests = new List<Chest>();
            enemies = new List<Enemy>();
            win = new WinSurvival(Ressources.bg_Win);
            fail = new FailSurvival(Ressources.bg_Fail);
            IAs.Add(new IA(Ressources.tileset_ia1, 400, 200, 32, 32, 100, 100));
            hud = new HUD(Ressources.bg_HUD);
            keeper = new Keeper(cursor, hud, ref IAs, 500, 1000, 1000);
            AbstractSetGame.LoadMap(AbstractSetGame.lvl);
            if (french)
            {
                typeGame = new Menu(Ressources.bg_choiceModeFR, sm);
            }
            if (english)
            {
                typeGame = new Menu(Ressources.bg_choiceModeEn, sm);
            }
            typeGame.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(200, 370, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), tm.SURVIVALCHOOSESOLO, "MODESOLOSURVIVAL"));
            typeGame.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(500, 370, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), tm.SURVIVALCHOOSELOCAL, "MODELOCALSURVIVAL"));
            typeGame.AddButton(new Button(Ressources.t_buttonOptions, new Rectangle(800, 370, Ressources.t_buttonOptions.Width, Ressources.t_buttonOptions.Height), tm.SURVIVALCHOOSEMULTI, "MODEMULTISURVIVAL"));
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
        public List<Enemy> Enemies
        {
            get { return enemies; }
            set { enemies = value; }
        }

        // Methods.

        public void RestartSurvival()
        {
            chestsReady = false;
            IAs.Clear();
            IAs.Add(new IA(Ressources.tileset_ia1, 400, 200, 32, 32, 100, 100));
            chests.Clear();
            enemies.Clear();
            keeper.ResetPlayer();
            keeper.MONEY = 1000;
            keeper.MANA = 500;
            s_state = SurvivalState.None;
            foreach (IA ia in IAs)
            {
                ia.local = false;
                ia.online = false;
                ia.solo = false;
            }
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
            if (s_state == SurvivalState.MultiLocal || s_state == SurvivalState.MultiOnline || s_state == SurvivalState.Solo)
            {
                CollisionMap.Update(IAs);
                List<Rectangle> vectors = new List<Rectangle>();
                vectors.Add(new Rectangle(mouse.X - ((Ressources.lightmask.Width / 2) / 3), mouse.Y - ((Ressources.lightmask.Height / 2) / 3), Ressources.lightmask.Width / 3, Ressources.lightmask.Height / 3));
                if (chestsReady && IAs.Count != 0 && keeper.MONEY != 0)
                {
                    CheckAndRemoveIA();
                    foreach (IA ia in IAs)
                    {
                        ia.Update(gameTime, keyboard, chests);
                    }
                    foreach (IA ia in IAs)
                    {
                        if (ia.LightEnabled)
                        {
                            vectors.Add(new Rectangle(ia.Hitbox.X - (Ressources.lightmask.Width / 4), ia.Hitbox.Y - (Ressources.lightmask.Height / 4), Ressources.lightmask.Width / 2, Ressources.lightmask.Height / 2));
                        }
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
                            particles = new ParticleGenerator(Ressources.tileset_coins, new Vector2(chests[i].Hitbox.X + (chests[i].Hitbox.Width / 2), chests[i].Hitbox.Y + (chests[i].Hitbox.Height / 2)), 5, 1, 0.05f, -0.005f, 5, true);
                            chests.RemoveAt(i);
                            i--;
                        }
                    }
                    hud.Update(cursor, mouse, gameTime);
                    keeper.Update(game, gameTime, keyboard, mouse);
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        enemies[i].Update(gameTime, IAs);
                        if (enemies[i].Died)
                        {
                            enemies.RemoveAt(i);
                            i--;
                        }
                    }
                    if (keeper.EnabledMob1 || keeper.EnabledMob2 || keeper.EnabledMob3 || keeper.EnabledMob4)
                    {
                        CollisionMap.Update(enemies, AbstractSetGame.maps[0], AbstractSetGame.maps[1]);
                    }
                    CollisionMap.Update(enemies);
                    if (particles != null)
                    {
                        particles.Update(gameTime);
                    }
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
                game.LIGHTENGINE.UpdateVectors(vectors);
                WinOrNot(game, gameTime, mouse);
            }
            else
            {
                typeGame.Update(game, gameTime, cursor, Mouse.GetState());
            }
        }

        public void DrawMain(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.SetRenderTarget(game.MainScene);
            spriteBatch.Draw(Ressources.blackSquare, new Vector2(0, 0), new Rectangle(0, 0, 1280, 740), Color.White);
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
                foreach (Enemy enemy in enemies)
                {
                    enemy.Draw(spriteBatch);
                }
                
            }
            game.GraphicsDevice.SetRenderTarget(null);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (s_state == SurvivalState.MultiLocal || s_state == SurvivalState.MultiOnline || s_state == SurvivalState.Solo)
            {
                game.LIGHTENGINE.Draw(spriteBatch, game.MainScene, DrawMain);
                if (IAs.Count != 0 && keeper.MONEY != 0)
                {
                    hud.Draw(spriteBatch);
                    keeper.Draw(spriteBatch);
                    if (particles != null)
                    {
                        particles.Draw(spriteBatch);
                    }
                }
                if (IAs.Count == 0)
                {
                    win.Draw(spriteBatch);
                }
                else if (keeper.MONEY == 0)
                {
                    fail.Draw(spriteBatch);
                }
            }
            else
            {
                typeGame.Draw(spriteBatch);
            }
        }
        #endregion
    }
}
