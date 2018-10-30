using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Lbs.groupproject._2018_2019
{
    class Player
    {
        private Vector2 velocity;
        private Vector2 movementSpeed = Vector2.One;

        /// <summary>
        /// Contains position, texture, rotation, origin.
        /// Handles bounding rectangles and collision checks.
        /// </summary>
        public CollidableObject collidableObject;

        public bool IsAlive = true;

        /// <summary>
        /// Constructs a new Player with a texture, position
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        public Player(Texture2D texture, Vector2 position)
        {
            //Create a new CollidableObject
            collidableObject = new CollidableObject(texture, position);
        }
        
        public void Update(GameTime gameTime)
        {
            // Update position
            collidableObject.Position += velocity * gameTime.ElapsedGameTime.Milliseconds;
            // Reset velocity
            velocity = Vector2.Zero;

            CollidableObject collidableObject2 = new CollidableObject(collidableObject.Texture, Vector2.One);
            if (collidableObject.IsColliding(collidableObject2))
            {
                Die();
            }
        }

        /// <summary>
        /// Kill the player
        /// </summary>
        public void Die()
        {
            IsAlive = false;
        }

        public void MoveUp()
        {
            velocity.Y = -movementSpeed.Y;
        }

        public void MoveDown()
        {
            velocity.Y = movementSpeed.Y;
        }

        public void MoveRight()
        {
            velocity.X = movementSpeed.X;
        }

        public void MoveLeft()
        {
            velocity.X = -movementSpeed.X;
        }

        public void Attack()
        {

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(collidableObject.Texture, collidableObject.Position, null, Color.White, collidableObject.Rotation, collidableObject.Origin, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}
