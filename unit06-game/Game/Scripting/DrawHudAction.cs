using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawHudAction : Action
    {
        private VideoService videoService;
        
        public DrawHudAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            
            Stats stat1 = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            Stats stat2 = (Stats)cast.GetLastActor(Constants.STATS_GROUP);
            

            // DrawLabel(cast, Constants.LEVEL_GROUP, Constants.LEVEL_FORMAT, stats.GetLevel());
            // DrawLabel(cast, Constants.LIVES_GROUP, Constants.LIVES_FORMAT, stats.GetLives());
            DrawLabel(cast, Constants.SCORE_GROUP, Constants.SCORE1_FORMAT, stat1.GetScore(), (Label)cast.GetFirstActor(Constants.SCORE_GROUP));
            DrawLabel(cast, Constants.SCORE_GROUP, Constants.SCORE2_FORMAT, stat2.GetScore(), (Label)cast.GetLastActor(Constants.SCORE_GROUP));

        }

        private void DrawLabel(Cast cast, string group, string format, int data, Label label)
        {
            
            // Label label = (Label)cast.GetFirstActor(group);
            Text text = label.GetText();
            text.SetValue(string.Format(format, data));
            Point position = label.GetPosition();
            videoService.DrawText(text, position);
        }
    }
}