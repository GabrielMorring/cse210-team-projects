using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawPlayerAction : Action
    {
        private VideoService videoService;
        
        public DrawPlayerAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            
            foreach(Actor actor in cast.GetActors(Constants.PLAYER_GROUP))
            {
                Player player = (Player)actor;
                Body body = player.GetBody();
                Image image = player.GetImage();
                Point position = body.GetPosition();
                videoService.DrawImage(image, position);

                if (player.IsDebug())
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