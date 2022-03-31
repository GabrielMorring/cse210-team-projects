using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class ControlPlayer2Action : Action
    {
        private KeyboardService keyboardService;

        public ControlPlayer2Action(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player)cast.GetActors(Constants.PLAYER_GROUP)[cast.GetActors(Constants.PLAYER_GROUP).Count - 1];

            Body body = player.GetBody();
            Point position = body.GetPosition();
            
            if (keyboardService.IsKeyDown(Constants.A))
            {
                player.MoveLeft();
            }
            else if (keyboardService.IsKeyDown(Constants.D))
            {
                player.MoveRight();
            }
            else if (keyboardService.IsKeyDown(Constants.W))
            {
                player.MoveUp();
            }
            else if (keyboardService.IsKeyDown(Constants.S))
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