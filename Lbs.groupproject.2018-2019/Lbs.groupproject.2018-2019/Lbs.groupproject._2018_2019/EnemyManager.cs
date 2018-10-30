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
    public class EnemyManager
    {
        /// <summary>
        /// List of all alive Enemies
        /// </summary>
        /// 
        CollidableObject CollidableObject;

        public static List<EnemyManager> Enemies = new List<EnemyManager>();

        public static void AddEnemy(EnemyManager enemy)
        {
            Enemies.Add(enemy);
        }

        public static void ClearEnemies()
        {
            Enemies.Clear();
        }

        public static bool CheckCollisionToPlayer()
        {
            foreach (EnemyManager enemy in Enemies)
            {
                if (enemy.CollidableObject.IsColliding(InGame.Player.CollidableObject))
                {
                    return true;
                }
            }

            return false;
        }

        public void Update(GameTime gameTime)
        {
            foreach (EnemyManager enemy in Enemies)
            {
                enemy.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (EnemyManager enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }
    }
}
