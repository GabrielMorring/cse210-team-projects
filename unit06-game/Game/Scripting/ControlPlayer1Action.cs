using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class ControlPlayer1Action : Action
    {
        private KeyboardService keyboardService;

        public ControlPlayer1Action(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player)cast.GetFirstActor(Constants.PLAYER_GROUP);

            Body body = player.GetBody();
            Point position = body.GetPosition();
            
            if (keyboardService.IsKeyDown(Constants.LEFT))
            {
                player.MoveLeft();
            }
            else if (keyboardService.IsKeyDown(Constants.RIGHT))
            {
                player.MoveRight();
            }
            else if (keyboardService.IsKeyDown(Constants.UP))
            {
                player.MoveUp();
            }
            else if (keyboardService.IsKeyDown(Constants.DOWN))
            {
                player.MoveDown();
            }
            else
            {
                player.StopMoving();
                position = position.Add(new Point(Constants.COURSEFEATURE_VELOCITY * 2, 0));
                body.SetPosition(position);
            }
        }
    }
}