using System;


namespace Unit04.Game.Casting
{
    
    public class ScoreBoard : Actor
    {
        public void UpdateText(int score)
        {
            SetText($"Score: {score}");
        }
    }
}