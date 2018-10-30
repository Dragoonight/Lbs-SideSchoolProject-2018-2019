using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Lbs.groupproject._2018_2019
{
    static public class EnemyManager
    {
        /// <summary>
        /// List of all alive Enemies
        /// </summary>
        public static List<Enemy> Enemies = new List<Enemy>();

        private static Texture2D enemyTexture1;
        
        public static void AddEnemy(ref Enemy enemy)
        {
            Enemies.Add(enemy);
        }

        internal static void LoadContent(ContentManager content)
        {
            enemyTexture1 = content.Load<Texture2D>(@"Textures/Test_Enemy");
        }

        public static void ClearEnemies()
        {
            Enemies.Clear();
        }

        public static bool CheckCollisionToAnyEnemy(CollidableObject collidableObject)
        {
            foreach (Enemy enemy in Enemies)
            {
                if (enemy.CollidableObject.IsColliding(collidableObject))
                {
                    return true;
                }
            }

            return false;
        }

        public static void Update(GameTime gameTime)
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.Update(gameTime);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }
    }
}
