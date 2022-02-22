namespace Unit04.Game.Casting
{

// Display score from enemy points


public class ScoreBoard : Actor
{
    private int _score = 0;


    public ScoreBoard()
    {
        // Set position of score board 


        SetPosition(new Point(0,0));


        SetText($"Score : {_score}");

        
    }
    public void UpdateScore(int points)
    {
        _score += points;
        SetText($"Score : {_score}");
    }



}

















}