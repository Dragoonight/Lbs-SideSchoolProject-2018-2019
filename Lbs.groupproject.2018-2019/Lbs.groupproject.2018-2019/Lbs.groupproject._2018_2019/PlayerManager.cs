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

        static public Rectangle playerBoundigRectangle = new Rectangle((int)(Game1.ScreenBounds.X * 0.2f), (int)(Game1.ScreenBounds.Y * 0.2f), (int)(Game1.ScreenBounds.X * 0.8f), (int)(Game1.ScreenBounds.Y * 0.8f));

        #region Textures
        // TODO : Add description of textures
        /// <summary>
        /// Texture 1 for player 1 
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
                // Check player 1´s input
                PlayerControls.CheckPlayer1Input();

                // Update player 1
                player1.Update(gameTime);
            }

            // If player 2 is alive
            if (player2.isAlive)
            {
                // check player 2´s input
                PlayerControls.CheckPlayer2Input();
                
                // Update player 2
                player2.Update(gameTime);
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
