using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Cycler player1 = (Cycler)cast.GetFirstActor("cycler");
            List<Actor> p1Segments = player1.GetSegments();
            Cycler player2 = (Cycler)cast.GetLastActor("cycler");
            List<Actor> p2Segments = player2.GetSegments();
            Actor score = cast.GetFirstActor("score");
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(p1Segments);
            videoService.DrawActors(p2Segments);
            videoService.DrawActor(score);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}