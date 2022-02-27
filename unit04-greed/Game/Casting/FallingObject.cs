using System;


namespace Unit04.Game.Casting
{
  /// <summary>
    /// <para>A thing that participates in the game.</para>
    /// <para>
    /// The responsibility of Falling Object is to keep track of its appearance, position and velocity in 2d 
    /// space as it falls down the screen.
    /// </para>
    /// </summary>
  
  public class FallingObject : Actor
  {
    private Point _velocity = new Point(0,0);
    
    /// <summary>
    /// Constructs a new instance of FallingObject.
    /// </summary>
    public FallingObject()
    {
      SetPosition(new Point(0,2));
      SetVelocity(new Point(0,5));
       
    }

    /// <summary>
    /// Updates the position of the falling object, causing the object to 'fall' down the screen.
    /// </summary>
    /// <returns> void </returns>
    public void DoUpdates()
    {
      // 
      SetPosition(GetPosition().Add(GetVelocity()));

    }
  }
}
//comment