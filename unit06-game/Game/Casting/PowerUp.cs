using System;
using System.Collections.Generic;


namespace Unit06.Game.Casting
{
    /// <summary>
    /// 
    /// </summary>
    public class PowerUp : CourseFeature
    {
        private static Random random = new Random();

        private Body body;
        private Image image;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public PowerUp(Body body, Image image, bool debug = false) : base(body, image, debug)
        {
            
        }

        /// <summary>
        /// Bounces the ball horizontally.
        /// </summary>
        public void BounceX()
        {
            Point velocity = body.GetVelocity();
            double rn = (random.NextDouble() * (1.2 - 0.8) + 0.8);
            double vx = velocity.GetX() * -1;
            double vy = velocity.GetY();
            Point newVelocity = new Point((int)vx, (int)vy);
            body.SetVelocity(newVelocity);
        }

        /// <summary>
        /// Bounces the ball vertically.
        /// </summary>
        public void BounceY()
        {
            Point velocity = body.GetVelocity();
            double rn = (random.NextDouble() * (1.2 - 0.8) + 0.8);
            double vx = velocity.GetX();
            double vy = velocity.GetY() * -1;
            Point newVelocity = new Point((int)vx, (int)vy);
            body.SetVelocity(newVelocity);
        }

        /// <summary>
        /// Releases ball in random horizontal direction.
        /// </summary>

        public void Release()
        {
            Point velocity = body.GetVelocity();
            List<int> velocities = new List<int> {Constants.PLAYER_VELOCITY, Constants.PLAYER_VELOCITY};
            int index = random.Next(velocities.Count);
            double vx = velocities[index];
            double vy = -Constants.PLAYER_VELOCITY;
            Point newVelocity = new Point((int)vx, (int)vy);
            body.SetVelocity(newVelocity);
        }
    }
}