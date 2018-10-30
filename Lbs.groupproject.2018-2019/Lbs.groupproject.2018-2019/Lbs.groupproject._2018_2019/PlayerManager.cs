using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lbs.groupproject._2018_2019
{
    /// <summary>
    /// Manages players
    /// </summary>
    static class PlayerManager
    {
        static public Player player1;

        static public Player player2;

        static private Rectangle playerBoundigRectangle = new Rectangle((int)(Game1.ScreenBounds.X * 0.2f), (int)(Game1.ScreenBounds.Y * 0.2f), (int)(Game1.ScreenBounds.X * 0.8f), (int)(Game1.ScreenBounds.Y * 0.8f));

        #region Textures

        /// <summary>
        /// Texture 1 for player 1 // TODO : Add description of playertexture1
        /// </summary>
        static private Texture2D player1Texture1;
        static private Texture2D player2Texture1;

        #endregion

        static public void LoadContent(ContentManager content)
        {
            // Load player1Texture1
            player1Texture1 = content.Load<Texture2D>(@"Textures/Test_Player");
            // Load player1Texture2
            player2Texture1 = content.Load<Texture2D>(@"Textures/Test_Player2");

            // Create player1
            player1 = new Player(player1Texture1, new Vector2(Game1.ScreenBounds.X * 0.75f , Game1.ScreenBounds.Y / 2));
            // Create player2
            player2 = new Player(player2Texture1, new Vector2(Game1.ScreenBounds.X * 0.25f, Game1.ScreenBounds.Y / 2));
        }

        /// <summary>
        /// Update PlayerManager
        /// </summary>
        /// <param name="gameTime"></param>
        static public void Update(GameTime gameTime)
        {
            // If player 1 is alive
            if (player1.isAlive)
            {
                // Then check player 1´s input
                PlayerControls.CheckPlayer1Input();

                UpdatePlayer1Bounding();
                player1.Update(gameTime);
            }

            // If player 2 is alive
            if (player2.isAlive)
            {
                // check player 2´s input
                PlayerControls.CheckPlayer2Input();
                
                UpdatePlayer2Bounding();
                player2.Update(gameTime);
            }
        }

        private static void UpdatePlayer1Bounding()
        {
            // Left bounding
            if (player1.collidableObject.Position.X < playerBoundigRectangle.X)
            {
                if (!InGame.movableBackground.IsSourceMinX)
                {
                    // Move Background
                    InGame.movableBackground.MoveBackground(new Point((int)(player1.collidableObject.Position.X - playerBoundigRectangle.X), 0));                    
                }
                // Move Player
                player1.inWorldPosition.X -= player1.collidableObject.Position.X - playerBoundigRectangle.X;
            }

            // Top bounding
            if (player1.collidableObject.Position.Y < playerBoundigRectangle.Y)
            {
                // Move Background
                InGame.movableBackground.MoveBackground(new Point(0, (int)(player1.collidableObject.Position.Y - playerBoundigRectangle.Y)));
                // Move Player
                player1.inWorldPosition.Y -= player1.collidableObject.Position.Y - playerBoundigRectangle.Y;
            }

            // Bottom bounding
            if (playerBoundigRectangle.Height < player1.collidableObject.Position.Y)
            {
                // Move Background
                InGame.movableBackground.MoveBackground(new Point(0, (int)(player1.collidableObject.Position.Y - playerBoundigRectangle.Height)));
                // Move Player
                player1.inWorldPosition.Y -= player1.collidableObject.Position.Y - playerBoundigRectangle.Height;
            }

            // Right bounding
            if (playerBoundigRectangle.Width < player1.collidableObject.Position.X)
            {
                // Move Background
                InGame.movableBackground.MoveBackground(new Point((int)( player1.collidableObject.Position.X - playerBoundigRectangle.Width) , 0));
                // Move Player
                player1.inWorldPosition.X -= player1.collidableObject.Position.X - playerBoundigRectangle.Width;
            }
        }

        private static void UpdatePlayer2Bounding()
        {
            // Left bounding
            if (player2.collidableObject.Position.X < playerBoundigRectangle.X)
            {
                // Move Background
                InGame.movableBackground.MoveBackground(new Point((int)(player2.collidableObject.Position.X - playerBoundigRectangle.X), 0));
                // Move Player
                player2.inWorldPosition.X -= player2.collidableObject.Position.X - playerBoundigRectangle.X;
            }

            // Top bounding
            if (player2.collidableObject.Position.Y < playerBoundigRectangle.Y)
            {
                // Move Background
                InGame.movableBackground.MoveBackground(new Point(0, (int)(player2.collidableObject.Position.Y - playerBoundigRectangle.Y)));
                // Move Player
                player2.inWorldPosition.Y -= player2.collidableObject.Position.Y - playerBoundigRectangle.Y;
            }

            // Bottom bounding
            if (playerBoundigRectangle.Height < player2.collidableObject.Position.Y)
            {
                // Move World
                InGame.movableBackground.MoveBackground(new Point(0, (int)(player2.collidableObject.Position.Y - playerBoundigRectangle.Height)));
                // Move Player
                player2.inWorldPosition.Y -= player2.collidableObject.Position.Y - playerBoundigRectangle.Height;
            }

            // Right bounding
            if (playerBoundigRectangle.Width < player2.collidableObject.Position.X)
            {
                // Move Background
                InGame.movableBackground.MoveBackground(new Point((int)(player2.collidableObject.Position.X - playerBoundigRectangle.Width), 0));
                // Move Player
                player2.inWorldPosition.X -= player2.collidableObject.Position.X - playerBoundigRectangle.Width;
            }
        }

        /// <summary>
        /// Draw Players
        /// </summary>
        /// <param name="spriteBatch"></param>
        static public void Draw(SpriteBatch spriteBatch)
        {
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
        }
    }
}
