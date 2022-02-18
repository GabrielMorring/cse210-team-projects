using System;


namespace Unit04.Game.Casting
{
    
    public class ScoreBoard : Actor
    {

        public ScoreBoard()
        {
            SetText("Score:");
            SetFontSize(25);
            SetPosition(new Point(0,5));
        }

        public void UpdateText(int score)
        {
            SetText($"Score: {score}");
        }
    }
}