using System;
using System.Collections.Generic;


namespace Unit06.Game.Casting
{
    /// <summary>
    /// 
    /// </summary>
    public class FinishLine : CourseFeature
    {

        private static Random random = new Random();

        private Body body;
        private Image image;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public FinishLine(Body body, Image image, bool debug = false) : base(body, image, debug)
        {
            
        }
    }
}