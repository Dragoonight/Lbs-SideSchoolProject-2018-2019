using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Lbs.groupproject._2018_2019
{
    /// <summary>
    /// This class is used to check the player 1's keyboard input 
    /// </summary>
    static class PlayerControls
    {

        /// <summary>
        /// A bool that is used to check if any player is holding down the "F" button. Used to fullscreen the window when the button is pressed, and window the fullscreen when pressed again 
        /// </summary>
        //private static bool toggleFullscreen = false;

        /// <summary>
        /// CurrentKBState is a KeyboardState used to check the players input on their keyboard.
        /// </summary>
        private static KeyboardState currentKBState;

        /// <summary>
        /// previousKBState is a KeyboardState that is equal to currentKBState one update ago. 
        /// </summary>
        private static KeyboardState previousKBState;

        public static bool Exit
        {
            get;
            private set;
        }

        /// <summary>
        /// A bool that is used to check if any player is holding down the "F" button. Used to fullscreen the window when the button is pressed, and window the fullscreen when pressed again 
        /// </summary>
        public static bool ToggleFullscreen
        {
            get;
            private set;
        }

        /// <summary>
        /// Check basic input ex. fullscreen, exit.
        /// </summary>
        public static void CheckUniversalInput()
        {
            // set previousKBState to currentKBState
            previousKBState = currentKBState;

            // Update currentKBState
            currentKBState = Keyboard.GetState();

            // If F key is pressed and was not pressed last update then set ToggleFullscreen to true
            ToggleFullscreen = currentKBState.IsKeyDown(Keys.F) && previousKBState.IsKeyUp(Keys.F);
            // If End key is pressed, exit the game.
            Exit = currentKBState.IsKeyDown(Keys.End);
        }


        /// <summary>
        /// Check player 1's keyboard input
        /// </summary>
        public static void CheckPlayer1Input ()
        {          
            // Defines gamePad as a GamePadState so you can use it to map controls on a controller    
            GamePadState gamePad1 = GamePad.GetState(PlayerIndex.One);         



            // If the player is holding down W, then the player 1's character goes upward
            if (currentKBState.IsKeyDown(Keys.W))
            { 
                PlayerManager.player1.MoveUp();
            }

            // If the player is holding down A, then the player 1's character goes left
            if (currentKBState.IsKeyDown(Keys.A))
            {
                PlayerManager.player1.MoveLeft();
            }

            // If the player is holding down S, then the player 1's character goes down
            if (currentKBState.IsKeyDown(Keys.S))
            {
                PlayerManager.player1.MoveDown();
            }

            // If the player is holding down D, then the player 1's character goes right
            if (currentKBState.IsKeyDown(Keys.D))
            {
                PlayerManager.player1.MoveRight();
            }

            // Since previousKBState is one update after currentKBState this will make it a single press.
            if (currentKBState.IsKeyDown(Keys.E) && previousKBState.IsKeyUp(Keys.E))
            {
                PlayerManager.player1.MoveUp();
            }
        }

        /// <summary>
        /// Check player 2's keyboard input
        /// </summary>
        //public void CheckPlayer2Input()
        //{

        //}
    }
}
