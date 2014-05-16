using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game
{
    public class CollisionMap
    {
        // Update.
        public static void Update(List<IA> IAs)
        {
            foreach (IA ia in IAs)
            {
                foreach (Tile tile in AbstractSetGame.maps[1].Tiles)
                {
                    if (ia.State == AbstractCaracter.IAState.Right && ia.Hitbox.Intersects(tile.Rect) 
                        && CollisionPerPixel.InsersectsPixel(ia.Hitbox, ia.TextureData, tile.Rect, tile.TextureData))
                    {
                        ia.Velocity = new Vector2(0, ia.Velocity.Y);
                        ia.Hitbox = new Rectangle((tile.Rect.Left - 1) - (ia.Hitbox.Width / 6), ia.Hitbox.Y, ia.Hitbox.Width, ia.Hitbox.Height);
                    }
                    else if (ia.State == AbstractCaracter.IAState.Left && ia.Hitbox.Intersects(tile.Rect)
                        && CollisionPerPixel.InsersectsPixel(ia.Hitbox, ia.TextureData, tile.Rect, tile.TextureData))
                    {
                        ia.Velocity = new Vector2(0, ia.Velocity.Y);
                        ia.Hitbox = new Rectangle(tile.Rect.Right + 1, ia.Hitbox.Y, ia.Hitbox.Width, ia.Hitbox.Height);
                    }
                    if (ia.State == AbstractCaracter.IAState.Up && ia.Hitbox.Intersects(tile.Rect)
                        && CollisionPerPixel.InsersectsPixel(ia.Hitbox, ia.TextureData, tile.Rect, tile.TextureData))
                    {
                        ia.Velocity = new Vector2(ia.Velocity.X, 0);
                        ia.Hitbox = new Rectangle(ia.Hitbox.X, tile.Rect.Bottom + 1, ia.Hitbox.Width, ia.Hitbox.Height);
                    }
                    else if (ia.State == AbstractCaracter.IAState.Down && ia.Hitbox.Intersects(tile.Rect)
                        && CollisionPerPixel.InsersectsPixel(ia.Hitbox, ia.TextureData, tile.Rect, tile.TextureData))
                    {
                        ia.Velocity = new Vector2(ia.Velocity.X, 0);
                        ia.Hitbox = new Rectangle(ia.Hitbox.X, (tile.Rect.Top - 1) - (ia.Hitbox.Height / 6), ia.Hitbox.Width, ia.Hitbox.Height);
                    }
                }
            }
        }
        public static void Update(List<Chest> chests, Map floor, Map wall)
        {
            for (int i = 0; i < chests.Count; i++)
            {
                bool[] testingChest = new bool[floor.Tiles.Count];
                int j = 0;
                foreach (Tile tile in floor.Tiles)
                {
                    testingChest[j] = tile.Rect.Intersects(chests[i].Hitbox);
                    j++;
                }
                if (!testingChest.Contains(true))
                {
                    chests.RemoveAt(i);
                    i--;
                }
                foreach (Tile tile in wall.Tiles)
                {
                    if (i >= 0 && tile.Rect.Intersects(chests[i].Hitbox))
                    {
                        chests.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
    }
}
