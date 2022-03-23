using Unit06.Game.Casting;

namespace Unit06.Game.Scripting
{
    public class MoveCourseFeatureAction : Action
    {
        public MoveCourseFeatureAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            
            foreach(Actor actor in cast.GetActors(Constants.COURSEFEATURE_GROUP))
            {
                CourseFeature feature = (CourseFeature)actor;
                Body body = feature.GetBody();
                Point position = body.GetPosition();
                Point velocity = body.GetVelocity();
                int x = position.GetX();
                int y = position.GetY();

                position = position.Add(velocity);
                body.SetPosition(position);  
            }     
        }
    }
}