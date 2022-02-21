using System;


namespace Unit04.Game.Casting
{
  
  
  public class FallingObject : Actor
  {
    private Point _velocity = new Point(0,0);
    
    public FallingObject()
    {
      SetPosition(new Point(3,2));
      SetVelocity(new Point(3,2));
       
    }
  }
}