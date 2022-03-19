using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class CheckOverAction : Action
    {
        public CheckOverAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            foreach(Player player in cast.GetActors(Constants.PLAYER_GROUP))
            {
                Body body = player.GetBody();
                
                FinishLine finish = (FinishLine)cast.GetFirstActor(Constants.FINISH_LINE_GROUP);
                Body finishBody = finish.GetBody();

                if (body.GetPosition().GetX() >= finishBody.GetPosition().GetX())
                {
                    Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
                    stats.AddLevel();
                    
                    callback.OnNext(Constants.GAME_OVER);

                    if(player.GetPlayerNum() == 1)
                    {
                        callback.OnNext(Constants.PLAYER_ONE_WINS);
                    } 
                    else if(player.GetPlayerNum() == 2)
                    {
                        callback.OnNext(Constants.PLAYER_TWO_WINS);
                    } 
                    
                    
                }
            }    
        }
    }
}