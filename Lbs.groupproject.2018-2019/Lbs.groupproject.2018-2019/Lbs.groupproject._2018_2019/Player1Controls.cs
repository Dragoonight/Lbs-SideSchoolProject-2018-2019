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
        /// A bool that is used to check if player 1 is actively holding in "W" on their keyboard. Used to make the player walk up when the button is pressed
        /// </summary>
        public bool walkingUp = false;

        /// <summary>
        /// A bool that is used to check if player 1 is actively holding in "A" on their keyboard. Used to make the player walk left when the button is pressed
        /// </summary>
        public bool walkingLeft = false;

        /// <summary>
        /// A bool that is used to check if player 1 is actively holding in "S" on their keyboard. Used to make the player walk down when the button is pressed
        /// </summary>
        public bool walkingDown = false;
        
        /// <summary>
        /// A bool that is used to check if player 1 is actively holding in "D" on their keyboard. Used to make the player walk right when the button is pressed
        /// </summary>
        public bool walkingRight = false;

        /// <summary>
        /// A bool that is used to check if player 1 is actively holding in "J" on their keyboard. Used to make the player perform an action when the button is pressed
        /// </summary>
        public bool actionButton = false; 
        
        /// <summary>
        /// A bool that is used to check if any player is holding down the "F1" button. Used to close down the game when the button is pressed
        /// </summary>
        public bool exitingTheGame = false;

        /// <summary>
        /// A bool that is used to check if any player is holding down the "F" button. Used to fullscreen the window when the button is pressed, and window the fullscreen when pressed again 
        /// </summary>
        public bool instantiatingFullscreen = false;


        private KeyboardState currentKBState;

        private KeyBoardState previousKBState;

        

        /// <summary>
        ///  Player1Controls is the constructor for the respective class 
        /// </summary>
        public Player1Controls ()
            {
            }
       
        /// <summary>
        /// Checks player 1's keyboard input to see if they have a button pressed on the keyboard 
        /// </summary>
        /// <param name="gameTime">gameTime is used to update the game continuously </param>
        public void CheckUser1Input (GameTime gameTime)
        {          
            // Definerar gamePad som en GamePadState så att man kan använda den för att mappa kontroller på en kontroll      
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);

            // The variable "previousKBState" is used to make sure that you only click a button once. This is done by checking the previous update of currentKBState. 
            previousKBState = currentKBState;

            // Definerar keyboard som en KeyBoardState så att man kan använda den för att mappa kontroller på en keyboard    
            KeyboardState currentKBState = Keyboard.GetState();

            


            // Om du trycker på F1 så kommer spelet att stängas ner
            if (currentKBState.IsKeyDown(Keys.F1))
            {
                exitingTheGame = true; 
            }

            // If you press F and instantiatingFullscreen = false, then it becomes = true and the game goes to fullscreen 
            if (currentKBState.IsKeyDown(Keys.F))
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

            //
            if (currentKBState.IsKeyDown(Keys.J) && previousKBState.IsKeyUp(Keys.J))
            {
                actionButton = true;
            }
            // 
            else if (currentKBState.IsKeyUp(Keys.J) && previousKBState.IsKeyDown(Keys.J))
            {
                actionButton = false;
            }

        }


    }
}
