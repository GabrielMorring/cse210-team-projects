using System;


namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Score : Actor
    {
        private int points = 0;
        private string playerText = "";

        /// <summary>
        /// Constructs a new instance of an Food.
        /// </summary>
        public Score(string player)
        {
            playerText = player;
            AddPoints(0);
        }

        public string GetPlayerText()
        {
            return playerText;
        }
        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points)
        {
            this.points += points;
            SetText($"{GetPlayerText()} : {this.points}");
        }

        public void SetPlayerText(string text)
        {
            playerText = text;
        }
    }
}