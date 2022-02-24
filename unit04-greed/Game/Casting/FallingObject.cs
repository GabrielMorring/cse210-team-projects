using System;


namespace Unit04.Game.Casting
{
  
  
  public class FallingObject : Actor
  {
    private Point _velocity = new Point(0,0);
    
    public FallingObject()
    {
      SetPosition(new Point(0,2));
      SetVelocity(new Point(0,2));
       
    }


    public void DoUpdates()
    {
      // 
      SetPosition(GetPosition().Add(GetVelocity()));

    }
  }
}
//comment