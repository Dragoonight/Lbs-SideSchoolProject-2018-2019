using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Lbs.groupproject._2018_2019
{
    class InGame
    {
        static public MovableBackground background1;

        internal static void LoadContent(ContentManager content)
        {
            // Load Players
            PlayerManager.LoadContent(content);

            background1 = new MovableBackground(content.Load<Texture2D>(@"Textures/Test_Background"), new Rectangle(0, 0, Game1.ScreenBounds.X, Game1.ScreenBounds.Y));

        }

        internal static void Update(GameTime gameTime)
        {
            PlayerManager.Update(gameTime);
            background1.Update();

        }

        internal static void Draw(SpriteBatch spriteBatch)
        {
            background1.Draw(spriteBatch);
            PlayerManager.Draw(spriteBatch);

        }
    }
}
