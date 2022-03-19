using System;
using System.Collections.Generic;


namespace Unit06.Game.Casting
{
    /// <summary>
    /// 
    /// </summary>
    public class FinishLine : Actor
    {
        private static Random random = new Random();

        private Body body;
        private Image image;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public FinishLine(Body body, Image image, bool debug = false) : base(debug)
        {
            this.body = body;
            this.image = image;
        }
        
        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public Body GetBody()
        {
            return body;
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <returns>The image.</returns>
        public Image GetImage()
        {
            return image;
        }

        public void MoveNext()
        {
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            Point newPosition = position.Add(velocity);
            body.SetPosition(newPosition);
        }

        /// <summary>
        /// </summary>
        public void MoveLeft()
        {
            Point velocity = new Point(-Constants.PLAYER_VELOCITY, 0);
            body.SetVelocity(velocity);
        }

        /// <summary>
        /// </summary>
        public void MoveRight()
        {
            Point velocity = new Point(Constants.PLAYER_VELOCITY, 0);
            body.SetVelocity(velocity);
        }
        
        public void MoveUp()
        {
            Point velocity = new Point(0, -Constants.PLAYER_VELOCITY);
            body.SetVelocity(velocity);
        }

        /// <summary>
        /// Swings the racket to the right.
        /// </summary>
        public void MoveDown()
        {
            Point velocity = new Point(0, Constants.PLAYER_VELOCITY);
            body.SetVelocity(velocity);
        }

        /// <summary>
        /// Stops the racket from moving.
        /// </summary>
        public void StopMoving()
        {
            Point velocity = new Point(0, 0);
            body.SetVelocity(velocity);
        }
        
    }
}