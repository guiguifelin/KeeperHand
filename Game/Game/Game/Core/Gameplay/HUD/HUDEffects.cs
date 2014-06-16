using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class HUDEffects
    {
        //Fields

        //Get & Set 

        //Methods

        protected void function(string str)
        {
            switch (str)
            {
                case "PAUSE":
                    AbstractStateGame.CurrentGameState = AbstractStateGame.GameState.Pause;
                    break;
                case "TRAP1":

                    break;
                case "SPELL1":

                    break;
                case "MOB1":

                    break;
                default:
                    // None.
                    break;
            }
        }

        protected void k_function(Keeper keeper, ref List<IA> IAs, List<Enemy> enemies,string str)
        {
            switch (str)
            {
                case "TRAP1":
                    foreach(IA ia in IAs)
                    {
                        if (CollisionPerPixel.InsersectsPixel(keeper.FieldBox50, keeper.TextureData50, ia.Hitbox, ia.TextureData))
                        {
                             ia.MinusLife(5);
                        }
                    }
                    break;
                case "SPELL1":
                    foreach (IA ia in IAs)
                    {
                        if (CollisionPerPixel.InsersectsPixel(keeper.FieldBox100, keeper.TextureData100, ia.Hitbox, ia.TextureData))
                        {
                            ia.MinusLife(2);
                            ia.SlowMoveEnabled = true;
                        }
                    }
                    break;
                case "MOB1":
                    enemies.Add(new Enemy(Ressources.tileset_gobelin, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), 
                        50f, 100f, true, false, false, false));
                    break;
                default:
                    // None.
                    break;
            }
        }
    }
}
