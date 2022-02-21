using System;


namespace Unit04.Game.Casting
{
    
    public class Player : Actor
    {

      public Player(int max_x, int max_y)
      {
          SetText("#");
          SetPosition(new Point(max_x/2, max_y));


      }

      public void MovePlayerNext(int maxX, int maxY)
      {
          if (GetVelocity().GetY() != 0)
          {
              
              SetVelocity(new Point(GetVelocity().GetX(), 0));
              MoveNext(maxX, maxY);
          }
          else
          {
              MoveNext(maxX,maxY);
          }
      }  
    }
}