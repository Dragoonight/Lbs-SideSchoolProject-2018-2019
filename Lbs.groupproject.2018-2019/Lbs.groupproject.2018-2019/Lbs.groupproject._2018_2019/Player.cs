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
        /// <summary>
        /// Amount to increase velocity by when player is moving
        /// </summary>
        private Vector2 movementSpeed = new Vector2(0.5f);
        /// <summary>
        /// Position in world
        /// </summary>
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
            // Create a new CollidableObject
            collidableObject = new CollidableObject(texture, position);
        }
        
        /// <summary>
        /// Update Player logical
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {

            UpdatePlayerBounding(gameTime);
            // Update position
            UpdateInWorldPosition(gameTime);

            // Moves object by subtracting the upper-left coordinate of the backgrounds location to the player´s in world position 
            collidableObject.Position.X = MathHelper.Clamp(inWorldPosition.X - InGame.movableBackground.SourceRectangle.X, 0 + collidableObject.Origin.X, Game1.ScreenBounds.X - collidableObject.Origin.X);
            collidableObject.Position.Y = MathHelper.Clamp(inWorldPosition.Y - InGame.movableBackground.SourceRectangle.Y, 0 + collidableObject.Origin.Y, Game1.ScreenBounds.Y - collidableObject.Origin.Y);

            // Reset velocity for next update
            velocity = Vector2.Zero;
        }

        /// <summary>
        /// Moves player with velocity whilst limiting position to remain within the screen
        /// </summary>
        /// <param name="gameTime"></param>
        private void UpdateInWorldPosition(GameTime gameTime)
        {
            Vector2 moveValue = velocity * gameTime.ElapsedGameTime.Milliseconds;

            inWorldPosition = new Vector2(
                MathHelper.Clamp(moveValue.X + inWorldPosition.X, 0 + collidableObject.Origin.X, InGame.movableBackground.Texture.Width - collidableObject.Origin.X),
                MathHelper.Clamp(moveValue.Y + inWorldPosition.Y, 0 + collidableObject.Origin.Y, InGame.movableBackground.Texture.Height - collidableObject.Origin.Y));

        }

        private void UpdatePlayerBounding(GameTime gameTime)
        {
            // Left bounding
            // when player goes outside the rectangle move 
            if (collidableObject.Position.X <= PlayerManager.playerBoundigRectangle.X)
            {
                // Move Background
                InGame.movableBackground.MoveBackground(new Point((int)(collidableObject.Position.X - PlayerManager.playerBoundigRectangle.X), 0));
                // 
                if (!InGame.movableBackground.IsSourceMinX)
                {
                    // Move Player
                    velocity.X = ;
                    // (collidableObject.Position.X - PlayerManager.playerBoundigRectangle.X) / gameTime.ElapsedGameTime.Milliseconds;
                }

            }

            // Top bounding
            if (collidableObject.Position.Y <= PlayerManager.playerBoundigRectangle.Y)
            {
                if (!InGame.movableBackground.IsSourceMinY)
                {
                    // Move Player
                    inWorldPosition.Y -= collidableObject.Position.Y - PlayerManager.playerBoundigRectangle.Y;
                }
                // Move Background
                InGame.movableBackground.MoveBackground(new Point(0, (int)(collidableObject.Position.Y - PlayerManager.playerBoundigRectangle.Y)));
            }

            // Bottom bounding
            if (collidableObject.Position.Y >= PlayerManager.playerBoundigRectangle.Height)
            {
                if (!InGame.movableBackground.IsSourceMaxY)
                {
                    // Move Player
                    inWorldPosition.Y -= collidableObject.Position.Y - PlayerManager.playerBoundigRectangle.Height;
                }
                // Move Background
                InGame.movableBackground.MoveBackground(new Point(0, (int)(collidableObject.Position.Y - PlayerManager.playerBoundigRectangle.Height)));
            }

            // Right bounding
            if (collidableObject.Position.X >= PlayerManager.playerBoundigRectangle.Width)
            {
                if (InGame.movableBackground.IsSourceMaxX)
                {
                    // Move Player
                    inWorldPosition.X -= collidableObject.Position.X - PlayerManager.playerBoundigRectangle.Width;
                }
                // Move Background
                InGame.movableBackground.MoveBackground(new Point((int)(collidableObject.Position.X - PlayerManager.playerBoundigRectangle.Width), 0));
            }
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
