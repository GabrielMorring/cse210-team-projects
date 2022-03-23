using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawObstacleAction : Action
    {
        private VideoService videoService;
        
        public DrawObstacleAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
           foreach(Actor actor in cast.GetActors(Constants.OBSTACLE_GROUP))
            {
                Obstacle obstacle = (Obstacle)actor;
                Body body = obstacle.GetBody();
                Image image = obstacle.GetImage();
                Point position = body.GetPosition();
                videoService.DrawImage(image, position);

                if (obstacle.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    videoService.DrawRectangle(size, pos, Constants.PURPLE, false);

                }
            }                
        }
    }
}