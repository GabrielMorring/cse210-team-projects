using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawPowerUpAction : Action
    {
        private VideoService videoService;
        
        public DrawPowerUpAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
           foreach(Actor actor in cast.GetActors(Constants.POWERUP_GROUP))
            {
                PowerUp powerup = (PowerUp)actor;
                Body body = powerup.GetBody();
                Image image = powerup.GetImage();
                Point position = body.GetPosition();
                videoService.DrawImage(image, position);

                if (powerup.IsDebug())
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