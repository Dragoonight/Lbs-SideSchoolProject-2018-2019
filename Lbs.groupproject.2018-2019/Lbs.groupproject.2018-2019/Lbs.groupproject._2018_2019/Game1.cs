using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Lbs.groupproject._2018_2019
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static Point ScreenBounds = new Point(1280, 720);
        
        public enum GameStates
        {
            MainMenu,
            InGame
        }

        // Starting gamestate
        public GameStates GameState = GameStates.InGame;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = ScreenBounds.X;
            graphics.PreferredBackBufferHeight = ScreenBounds.Y;
            graphics.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            InGame.LoadContent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            PlayerControls.CheckUniversalInput();

            switch (GameState)
            {
                //case GameStates.MainMenu:
                //    MainMenu.Update();
                //    break;


                case GameStates.InGame:
                    InGame.Update(gameTime);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            // End exits the game
            if (PlayerControls.Exit)
            {
                Exit();
            }

            if (PlayerControls.ToggleFullscreen)
            {
                graphics.IsFullScreen = !graphics.IsFullScreen;
                graphics.ApplyChanges();
            }
            
            
            base.Update(gameTime);
        }
    
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            switch (GameState)
            {
                //case GameStates.MainMenu:
                //    MainMenu.Update();
                //    break;


                case GameStates.InGame:
                    InGame.Draw(spriteBatch);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
