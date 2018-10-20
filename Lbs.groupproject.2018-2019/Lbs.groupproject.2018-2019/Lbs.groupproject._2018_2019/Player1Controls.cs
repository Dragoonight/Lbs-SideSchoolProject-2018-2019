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
    public static class Player1Controls
    {
        /// <summary>
        /// A bool that is used to check if player 1 is actively holding in "W" on their keyboard. Used to make the player walk up when the button is pressed
        /// </summary>
        public static bool walkingUp = false;

        /// <summary>
        /// A bool that is used to check if player 1 is actively holding in "A" on their keyboard. Used to make the player walk left when the button is pressed
        /// </summary>
        public static bool walkingLeft = false;

        /// <summary>
        /// A bool that is used to check if player 1 is actively holding in "S" on their keyboard. Used to make the player walk down when the button is pressed
        /// </summary>
        public static bool walkingDown = false;
        
        /// <summary>
        /// A bool that is used to check if player 1 is actively holding in "D" on their keyboard. Used to make the player walk right when the button is pressed
        /// </summary>
        public static bool walkingRight = false;

        /// <summary>
        /// A bool that is used to check if player 1 is actively holding in "J" on their keyboard. Used to make the player perform an action when the button is pressed
        /// </summary>
        public static bool actionButton = false; 
        
        /// <summary>
        /// A bool that is used to check if any player is holding down the "ESC" button. Used to close down the game when the button is pressed
        /// </summary>
        public static bool exitingTheGame = false;

        /// <summary>
        /// A bool that is used to check if any player is holding down the "F" button. Used to fullscreen the window when the button is pressed, and window the fullscreen when pressed again 
        /// </summary>
        public static bool instantiatingFullscreen = false;

        /// <summary>
        /// CurrentKBState is a KeyboardState that is used to check the player inputs on their keyboard 
        /// </summary>
        private static KeyboardState currentKBState;


        /// <summary>
        /// previousKBState is a KeyboardState that is equal to currentKBState. It is used to make buttons single presses 
        /// </summary>
        private static KeyboardState previousKBState;

        
        /// <summary>
        ///  Player1Controls is the constructor for the respective class 
        /// </summary>
        //public static Player1Controls ()
         //   {
           // }
       
        /// <summary>
        /// Checks player 1's keyboard input to see if they have a button pressed on the keyboard 
        /// </summary>
        /// <param name="gameTime">gameTime is used to update the game continuously </param>
        public static void CheckUser1Input (GameTime gameTime)
        {          
            // Defines gamePad as a GamePadState so you can use it to map controls on a controller    
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);         

            // Defines currentKBState as a KeyboardState so you can use it to map controls on a controller       
            KeyboardState currentKBState = Keyboard.GetState();

            // The variable "previousKBState" is used to make sure that you only click a button once. This is done because previousKBState is one frame after currentKBState 
            previousKBState = currentKBState;

            // If the player presses ESC then the game will close down 
            if (currentKBState.IsKeyDown(Keys.Escape))
            {
                exitingTheGame = true; 
            }

            // If you press F and instantiatingFullscreen = false, then it becomes = true and the game goes to fullscreen 
            if (currentKBState.IsKeyDown(Keys.F) && previousKBState.IsKeyUp(Keys.J))
            {
                instantiatingFullscreen = true; 
            }

            // If you press F and instantiatingFullscreen = true, then it becomes = false and the game goes from fullscreen to windowed mode
            if (instantiatingFullscreen = true && currentKBState.IsKeyDown(Keys.F))
            {
                instantiatingFullscreen = false;
            }

            // If the player is holding down W, then the player 1's character goes upward until the button is released, then the character stops walking
            if (currentKBState.IsKeyDown(Keys.W))
            { 
                walkingUp = true;
            }
            else
            {
                walkingUp = false;
            }

            // If the player is holding down A, then the player 1's character goes left until the button is released, then the character stops walking
            if (currentKBState.IsKeyDown(Keys.A))
            {
                walkingLeft = true;
            }
            else
            {
                walkingLeft = false;
            }

            // If the player is holding down S, then the player 1's character goes left until the button is released, then the character stops walking
            if (currentKBState.IsKeyDown(Keys.S))
            {
                walkingDown = true;
            }
            else
            {
                walkingDown = false;
            }

            // If the player is holding down D, then the player 1's character goes left until the button is released, then the character stops walking
            if (currentKBState.IsKeyDown(Keys.D))
            {
                walkingRight = true;
            }
            else
            {
                walkingRight = false;
            }

            // Since previousKBState is one update after currentKBState this will make it a single press. The action button is used for anything we currently want
            if (currentKBState.IsKeyDown(Keys.J) && previousKBState.IsKeyUp(Keys.J))
            {
                actionButton = true;
            }
            // Since previousKBState will become .IsKeyDown one update after the player has pressed a button, actionButton will become false
            else
            {
                actionButton = false; 
            }

            //else if (currentKBState.IsKeyUp(Keys.J) && previousKBState.IsKeyDown(Keys.J))
            //{
            //    actionButton = false;
            //}

        }


    }
}
