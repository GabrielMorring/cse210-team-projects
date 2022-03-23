using Unit06.Game.Casting;

namespace Unit06.Game.Scripting
{
    public class MovePlayerAction : Action
    {
        public MovePlayerAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            
            foreach(Actor actor in cast.GetActors(Constants.PLAYER_GROUP))
            {
                Player player = (Player)actor;
                Body body = player.GetBody();
                Point position = body.GetPosition();
                Point velocity = body.GetVelocity();
                int x = position.GetX();
                int y = position.GetY();

                position = position.Add(velocity);

                if (x < 0)
                {
                    position = new Point(0, position.GetY());
                }
                else if (x > Constants.SCREEN_WIDTH - Constants.PLAYER_WIDTH)
                {
                    position = new Point(Constants.SCREEN_WIDTH - Constants.PLAYER_WIDTH, position.GetY());
                }
                if (y < 0)
                {
                    position = new Point(position.GetX(), 0);
                }
                else if (y > Constants.SCREEN_HEIGHT - Constants.PLAYER_HEIGHT)
                {
                    position = new Point(position.GetX(), Constants.SCREEN_HEIGHT - Constants.PLAYER_HEIGHT);
                }
                body.SetPosition(position);
                


                foreach(Actor tempObstacle in cast.GetActors(Constants.OBSTACLE_GROUP))
                {
                    Obstacle obstacle = (Obstacle)tempObstacle;

                    if ( x >= obstacle.GetBody().GetPosition().GetX() - Constants.PLAYER_WIDTH && x <= obstacle.GetBody().GetPosition().GetX() + Constants.OBSTACLE_WIDTH)
                    {
                        if (y <= obstacle.GetBody().GetPosition().GetY() && y >= obstacle.GetBody().GetPosition().GetY() - Constants.OBSTACLE_HEIGHT)
                        {
                            position = new Point(obstacle.GetBody().GetPosition().GetX() - Constants.PLAYER_WIDTH, obstacle.GetBody().GetPosition().GetY());
                        }
                    }
                    body.SetPosition(position);
                } 
            }     
        }
    }
}