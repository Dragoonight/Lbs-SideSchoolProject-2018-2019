using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lbs.groupproject._2018_2019
{
    /// <summary>
    ///     Moves the InGame background to create the illusion that the Player is moving
    /// </summary>
    public class MovableBackground 
    {
        /// <summary>
        /// The texture minus the screen size
        /// </summary>
        private Point maxSourceBounds;
        public Rectangle SourceRectangle;
        
        public bool IsSourceMaxX;
        public bool IsSourceMaxY;
        public bool IsSourceMinX;
        public bool IsSourceMinY;

        /// <summary>
        ///     Creates a new MovableBackground with a texture, sourceRectangle and a default destinationRectangle  
        /// </summary>
        /// <param name="texture">The texture associated with the object</param>
        /// <param name="sourceRectangle">The source rectangle used to pick what piece of the texture will be drawn</param>        
        public MovableBackground(Texture2D texture, Rectangle sourceRectangle) : this(texture, new Rectangle(0, 0, Game1.ScreenBounds.X, Game1.ScreenBounds.Y), sourceRectangle)
        {
        }

        /// <summary>
        ///     Creates a new MovableBackground with a texture, destinationRectangle and a sourceRectangle
        /// </summary>
        /// <param name="texture">The texture associated with the object</param>
        /// <param name="destinationRectangle">The rectangle of the object in world space</param>
        /// <param name="sourceRectangle">The source rectangle used to pick what piece of the texture will be drawn</param>
        public MovableBackground(Texture2D texture, Rectangle destinationRectangle, Rectangle sourceRectangle)
        {
            Texture = texture;
            DestinationRectangle = destinationRectangle;
            SourceRectangle = sourceRectangle;

            maxSourceBounds = new Point(Texture.Bounds.Width - Game1.ScreenBounds.X, Texture.Bounds.Height - Game1.ScreenBounds.Y);
        }

        /// <summary>
        ///     The currently loaded texture
        /// </summary>
        public Texture2D Texture { get; set; }

        /// <summary>
        ///     The rectangle of where to draw on-screen
        /// </summary>
        public Rectangle DestinationRectangle { get; set; }

        /// <summary>
        /// Update Bounds detection
        /// </summary>
        public void Update()
        {
            // Checks if sourceRectangle is not outside texture
            IsSourceMaxX = SourceRectangle.X >= maxSourceBounds.X;
            IsSourceMaxY = SourceRectangle.Y >= maxSourceBounds.Y;
            IsSourceMinX = SourceRectangle.X <= 0;
            IsSourceMinY = SourceRectangle.Y <= 0;
        }

        /// <summary>
        /// Moves SourceRectangle by a point.
        /// </summary>
        /// <param name="moveByPoint">Point to move background by</param>
        public void MoveBackground(Point moveByPoint)
        {
            SourceRectangle.X = (int)MathHelper.Clamp(SourceRectangle.X + moveByPoint.X, 0, maxSourceBounds.X);
            SourceRectangle.Y = (int)MathHelper.Clamp(SourceRectangle.Y + moveByPoint.Y, 0, maxSourceBounds.Y);
        }

        /// <summary>
        /// Draws background with a texture, DestinationRectangle, SourceRectangle and a color
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw Background
            spriteBatch.Draw(Texture, DestinationRectangle, SourceRectangle, Color.White);
        }
    }
}