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
        private Vector2 movementSpeed = new Vector2(0.5f);
        public Vector2 inWorldPosition;

        /// <summary>
        /// Contains position, texture, rotation, origin.
        /// Handles bounding rectangles and collision checks.
        /// </summary>
        public CollidableObject collidableObject;

        public bool isAlive = true;

        /// <summary>
        /// Constructs a new Player with a texture, position
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        public Player(Texture2D texture, Vector2 position)
        {
            inWorldPosition = position;
            //Create a new CollidableObject
            collidableObject = new CollidableObject(texture, position);
        }
        
        public void Update(GameTime gameTime)
        {
            // Moves object by subtracting the upper-left coordinate of the background to the player´s position in world
            collidableObject.Position.X = inWorldPosition.X - InGame.movableBackground.SourceRectangle.X;
            collidableObject.Position.Y = inWorldPosition.Y - InGame.movableBackground.SourceRectangle.Y;

            // Update position
            inWorldPosition += velocity * gameTime.ElapsedGameTime.Milliseconds;
            // Reset velocity
            velocity = Vector2.Zero;

        }

        /// <summary>
        /// Kill the player
        /// </summary>
        public void Die()
        {
            isAlive = false;
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
