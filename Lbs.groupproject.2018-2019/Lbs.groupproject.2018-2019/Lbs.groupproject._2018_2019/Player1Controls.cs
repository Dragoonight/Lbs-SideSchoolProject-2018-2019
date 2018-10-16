using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Lbs.groupproject._2018_2019
{
    /// <summary>
    /// This class is used to check the player 1's keyboard input 
    /// </summary>
    public class Player1Controls
    {
        /// <summary>
        /// A bool that is used to check if player 1 is actively holding in "W" on their keyboard
        /// </summary>
        public bool walkingUp = false;

        /// <summary>
        /// A bool that is used to check if player 1 is actively holding in "A" on their keyboard
        /// </summary>
        public bool walkingLeft = false;

        /// <summary>
        /// A bool that is used to check if player 1 is actively holding in "S" on their keyboard
        /// </summary>
        public bool walkingDown = false;
        
        /// <summary>
        /// A bool that is used to check if player 1 is actively holding in "D" on their keyboard
        /// </summary>
        public bool walkingRight = false;

        /// <summary>
        /// A bool that is used to check if any player is holding down the exit button
        /// </summary>
        public bool exitingTheGame = false;

        /// <summary>
        /// 
        /// </summary>
        public bool instantiatingFullscreen = false; 

        /// <summary>
        ///  Player1Controls is the constructor for the respective class 
        /// </summary>
        public Player1Controls ()
            {
            }
       
        /// <summary>
        /// Checks 
        /// </summary>
        /// <param name="gameTime">gameTime is used to update the game continuously </param>
        public void CheckUser1Input (GameTime gameTime)
        {
           
            GraphicsDeviceManager graphics;

            // Defines 
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboard = Keyboard.GetState();
            
            
            if (keyboard.IsKeyDown(Keys.Escape))
            {
                exitingTheGame = true; 
            }
            
            //Tryck på F för att gå full-screen
            if (keyboard.IsKeyDown(Keys.F))
            {
                instantiatingFullscreen = true; 
            }
            
        }


    }
}
