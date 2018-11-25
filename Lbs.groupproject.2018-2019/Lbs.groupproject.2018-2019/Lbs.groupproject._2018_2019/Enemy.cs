using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lbs.groupproject._2018_2019
{
    public class Enemy
    {
        // TODO: refine documentation and more

        /// <summary>
        /// CollidableObject for this Enemy; contains rotation, position, collision etc.
        /// </summary>
        public CollidableObject CollidableObject;

        /// <summary>
        /// Standard spawning position
        /// </summary>
        private Vector2 spawnPosition;

        // TODO: targeting AI
        /// <summary>
        ///     Position in world
        /// </summary>
        public Vector2 InWorldPosition;


        public bool isAlive;


        /// <summary>
        ///     Creates a new instance of Enemy with a texture, CollidableObject and type
        /// </summary>
        /// <param name="aliveTexture2D">Texture for enemy when alive</param>
        /// <param name="deadTexture2D">Texture for enemy when dead</param>
        /// <param name="spawnPosition">The spawn position of the object</param>
        public Enemy(Texture2D texture, Vector2 spawnPosition)
        {


            InWorldPosition = spawnPosition;
            // Create a new CollidableObject with alive texture and spawn
            CollidableObject = new CollidableObject(texture, spawnPosition);
            //EnemyManager.AddEnemy(out this);
        }

        /// <summary>
        /// Updates position of enemy relative to the background
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            // Moves object relative to player by subtracting upper-left coordinate of the background to the object´s position in world
            CollidableObject.Position.X = InWorldPosition.X - InGame.movableBackground.SourceRectangle.X;
            CollidableObject.Position.Y = InWorldPosition.Y - InGame.movableBackground.SourceRectangle.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw Enemy
            spriteBatch.Draw(CollidableObject.Texture, CollidableObject.Position, null, Color.White, CollidableObject.Rotation, CollidableObject.Origin, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}