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
        public float playerSpeed = 1.0f;
        public Vector2 position;
        public Texture2D playerSprite;
        public Rectangle playeRectangle;
        public Player1Controls playerControls;


        // Communicating between Class and MainCodePage
        public float Speed
        {
            get { return playerSpeed; }
            set { playerSpeed = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Texture2D Texture
        {
            get { return playerSprite; }
            set { playerSprite = value; }
        }


        // Constructor
        public Player(Texture2D texture, Vector2 position, float speed)
        {

        }


        public void Update(GameTime gameTime, Rectangle windowsize)
        {
            
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            
        }




    }
}
