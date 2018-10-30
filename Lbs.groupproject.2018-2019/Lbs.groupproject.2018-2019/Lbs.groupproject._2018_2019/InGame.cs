using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Lbs.groupproject._2018_2019
{
    static class InGame
    {
        static public MovableBackground movableBackground;

        static public void LoadContent(ContentManager content)
        {
            // Load Players
            PlayerManager.LoadContent(content);
            EnemyManager.LoadContent(content);
            movableBackground = new MovableBackground(content.Load<Texture2D>(@"Textures/Test_Background"), new Rectangle(0, 0, Game1.ScreenBounds.X, Game1.ScreenBounds.Y));
        }

        static public void Update(GameTime gameTime)
        {
            PlayerManager.Update(gameTime);
            EnemyManager.Update(gameTime);
            movableBackground.Update();
        }

        /// <summary>
        /// Moves the entire world
        /// </summary>
        /// <param name="moveByVector">value to move by</param>
        public static void MoveWorld(Vector2 moveByVector)
        {
            movableBackground.MoveBackground(new Point((int)moveByVector.X, (int)moveByVector.Y));

            PlayerManager.player1.inWorldPosition += moveByVector;
            PlayerManager.player2.inWorldPosition += moveByVector;


        }



        static public void Draw(SpriteBatch spriteBatch)
        {
            movableBackground.Draw(spriteBatch);
            EnemyManager.Draw(spriteBatch);
            PlayerManager.Draw(spriteBatch);

        }
    }
}
