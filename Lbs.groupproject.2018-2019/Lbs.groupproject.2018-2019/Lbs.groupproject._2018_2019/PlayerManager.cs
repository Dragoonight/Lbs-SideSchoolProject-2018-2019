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

        // static public Player player2;

        #region Textures

        /// <summary>
        /// Texture 1 for player 1 // TODO : Add description of playertexture1
        /// </summary>
        static private Texture2D player1Texture1;

        #endregion

        static public void LoadContent(ContentManager content)
        {
            // Load player1Texture1
            player1Texture1 = content.Load<Texture2D>(@"Textures/Test_Player");

            // Create player1
            player1 = new Player(player1Texture1, new Vector2(Game1.ScreenBounds.X * (3 / 7), Game1.ScreenBounds.Y / 2));
            // Create player2
            // player2 = new Player(player1Texture1, new Vector2(Game1.ScreenBounds.X * (4 / 7), Game1.ScreenBounds.Y / 2));
        }

        /// <summary>
        /// Update PlayerManager
        /// </summary>
        /// <param name="gameTime"></param>
        static public void Update(GameTime gameTime)
        {
            // If player 1 is alive
            if (player1.IsAlive)
            {
                // Then check player 1´s input
                PlayerControls.CheckPlayer1Input();
            }

            //// If player 2 is alive
            //if (player1.IsAlive)
            //{
            //    // Then check player 2´s input
            //    PlayerControls.CheckPlayer1Input();
            //}

            // Update players postion
            player1.Update(gameTime);
            // player2.Update(gameTime);

            player1.collidableObject.Position
        }


        /// <summary>
        /// Draw Players
        /// </summary>
        /// <param name="spriteBatch"></param>
        static public void Draw(SpriteBatch spriteBatch)
        {
            player1.Draw(spriteBatch);
            // player2.Draw(spriteBatch);
        }
    }
}
