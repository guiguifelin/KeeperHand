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
                        ia.Hitbox = new Rectangle(tile.Rect.Left - ia.Hitbox.Width, ia.Hitbox.Y, ia.Hitbox.Width, ia.Hitbox.Height);
                        ia.IsCollision = true;
                    }
                    else if (ia.State == AbstractCaracter.IAState.Left && ia.Hitbox.Intersects(tile.Rect)
                        && CollisionPerPixel.InsersectsPixel(ia.Hitbox, ia.TextureData, tile.Rect, tile.TextureData))
                    {
                        ia.Velocity = new Vector2(0, ia.Velocity.Y);
                        ia.Hitbox = new Rectangle(tile.Rect.Right + 5, ia.Hitbox.Y, ia.Hitbox.Width, ia.Hitbox.Height);
                        ia.IsCollision = true;
                    }
                    if (ia.State == AbstractCaracter.IAState.Up && ia.Hitbox.Intersects(tile.Rect)
                        && CollisionPerPixel.InsersectsPixel(ia.Hitbox, ia.TextureData, tile.Rect, tile.TextureData))
                    {
                        ia.Velocity = new Vector2(ia.Velocity.X, 0);
                        ia.Hitbox = new Rectangle(ia.Hitbox.X, tile.Rect.Bottom + 5, ia.Hitbox.Width, ia.Hitbox.Height);
                        ia.IsCollision = true;
                    }
                    else if (ia.State == AbstractCaracter.IAState.Down && ia.Hitbox.Intersects(tile.Rect)
                        && CollisionPerPixel.InsersectsPixel(ia.Hitbox, ia.TextureData, tile.Rect, tile.TextureData))
                    {
                        ia.Velocity = new Vector2(ia.Velocity.X, 0);
                        ia.Hitbox = new Rectangle(ia.Hitbox.X, tile.Rect.Top - ia.Hitbox.Height, ia.Hitbox.Width, ia.Hitbox.Height);
                        ia.IsCollision = true;
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

        public static void Update(List<Enemy> enemies, Map floor, Map wall)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                bool[] testingChest = new bool[floor.Tiles.Count];
                int j = 0;
                foreach (Tile tile in floor.Tiles)
                {
                    testingChest[j] = tile.Rect.Intersects(enemies[i].Hitbox);
                    j++;
                }
                if (!testingChest.Contains(true))
                {
                    enemies.RemoveAt(i);
                    i--;
                }
                foreach (Tile tile in wall.Tiles)
                {
                    if (i >= 0 && tile.Rect.Intersects(enemies[i].Hitbox))
                    {
                        enemies.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        public static void Update(List<Enemy> enemies)
        {
            foreach (Enemy enemy in enemies)
            {
                foreach (Tile tile in AbstractSetGame.maps[1].Tiles)
                {
                    if (enemy.Velocity.X > 0 && enemy.Hitbox.Intersects(tile.Rect)
                        && CollisionPerPixel.InsersectsPixel(enemy.Hitbox, enemy.TextureData, tile.Rect, tile.TextureData))
                    {
                        enemy.Velocity = new Vector2(0, enemy.Velocity.Y);
                        enemy.Hitbox = new Rectangle((tile.Rect.Left - 1) - (enemy.Hitbox.Width / 6), enemy.Hitbox.Y, enemy.Hitbox.Width, enemy.Hitbox.Height);
                    }
                    else if (enemy.Velocity.X < 0f && enemy.Hitbox.Intersects(tile.Rect)
                        && CollisionPerPixel.InsersectsPixel(enemy.Hitbox, enemy.TextureData, tile.Rect, tile.TextureData))
                    {
                        enemy.Velocity = new Vector2(0, enemy.Velocity.Y);
                        enemy.Hitbox = new Rectangle(tile.Rect.Right + 1, enemy.Hitbox.Y, enemy.Hitbox.Width, enemy.Hitbox.Height);
                    }
                    if (enemy.Velocity.Y < 0 && enemy.Hitbox.Intersects(tile.Rect)
                        && CollisionPerPixel.InsersectsPixel(enemy.Hitbox, enemy.TextureData, tile.Rect, tile.TextureData))
                    {
                        enemy.Velocity = new Vector2(enemy.Velocity.X, 0);
                        enemy.Hitbox = new Rectangle(enemy.Hitbox.X, tile.Rect.Bottom + 1, enemy.Hitbox.Width, enemy.Hitbox.Height);
                    }
                    else if (enemy.Velocity.Y > 0 && enemy.Hitbox.Intersects(tile.Rect)
                        && CollisionPerPixel.InsersectsPixel(enemy.Hitbox, enemy.TextureData, tile.Rect, tile.TextureData))
                    {
                        enemy.Velocity = new Vector2(enemy.Velocity.X, 0);
                        enemy.Hitbox = new Rectangle(enemy.Hitbox.X, (tile.Rect.Top - 1) - (enemy.Hitbox.Height / 6), enemy.Hitbox.Width, enemy.Hitbox.Height);
                    }
                }
            }
        }
    }
}
