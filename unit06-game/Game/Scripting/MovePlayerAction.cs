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

                    if (x >= obstacle.GetBody().GetPosition().GetX() && x <= obstacle.GetBody().GetPosition().GetX() + Constants.OBSTACLE_WIDTH)
                    {
                        if (y <= obstacle.GetBody().GetPosition().GetY() + Constants.OBSTACLE_HEIGHT && y >= obstacle.GetBody().GetPosition().GetY() - Constants.PLAYER_HEIGHT)
                        {
                            position = new Point(x,y);
                        }
                    }

                    else if (x >= obstacle.GetBody().GetPosition().GetX() - Constants.PLAYER_WIDTH && x <= obstacle.GetBody().GetPosition().GetX() + Constants.OBSTACLE_WIDTH)
                    {
                        if (y <= obstacle.GetBody().GetPosition().GetY() + Constants.OBSTACLE_HEIGHT && y >= obstacle.GetBody().GetPosition().GetY() - Constants.PLAYER_HEIGHT)
                        {
                            position = new Point(obstacle.GetBody().GetPosition().GetX() - (int)(Constants.PLAYER_WIDTH * 1.3), position.GetY());
                        }

                    }
                    body.SetPosition(position);
                } 

                foreach(Actor tempActor in cast.GetActors(Constants.POWERUP_GROUP))
                {
                    PowerUp powerup = (PowerUp)tempActor;

                    if (x >= powerup.GetBody().GetPosition().GetX() && x <= powerup.GetBody().GetPosition().GetX() + Constants.OBSTACLE_WIDTH)
                    {
                        if (y <= powerup.GetBody().GetPosition().GetY() + Constants.OBSTACLE_HEIGHT && y >= powerup.GetBody().GetPosition().GetY() - Constants.PLAYER_HEIGHT)
                        {
                            position = new Point(player.GetBody().GetPosition().GetX() + 250,y);
                        }
                    }

                    else if (x >= powerup.GetBody().GetPosition().GetX() - Constants.PLAYER_WIDTH && x <= powerup.GetBody().GetPosition().GetX() + Constants.OBSTACLE_WIDTH)
                    {
                        if (y <= powerup.GetBody().GetPosition().GetY() + Constants.OBSTACLE_HEIGHT && y >= powerup.GetBody().GetPosition().GetY() - Constants.PLAYER_HEIGHT)
                        {
                            position = new Point(player.GetBody().GetPosition().GetX() + 250,y);
                        }

                    }
                    body.SetPosition(position);
                } 
            }     
        }
    }
}