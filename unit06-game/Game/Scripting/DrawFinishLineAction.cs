using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawFinishLineAction : Action
    {
        private VideoService videoService;
        
        public DrawFinishLineAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            
            
            FinishLine finishLine = (FinishLine)cast.GetFirstActor(Constants.FINISH_LINE_GROUP);
            Body body = finishLine.GetBody();
            Image image = finishLine.GetImage();
            Point position = body.GetPosition();
            videoService.DrawImage(image, position);

            if (finishLine.IsDebug())
            {
                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
            }
            
                            
        }
    }
}