using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the cycler 
    /// collides with the food, or the cycler collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleSegmentCollisions(cast);
                HandlePlayerCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Sets the game over flag if the cycler collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private async void HandleSegmentCollisions(Cast cast)
        {
            List<Actor> players = cast.GetActors("cycler");
            List<Actor> scores = cast.GetActors("score");

            for ( int i = 0; i < players.Count; i++)
            {
                Cycler cycler = (Cycler)players[i];
                Actor head = cycler.GetHead();
                List<Actor> body = cycler.GetBody();

                foreach (Actor segment in body)
                {
                    if (segment.GetPosition().Equals(head.GetPosition()))
                    {
                        if (i == 0)
                        {
                            Score score = (Score)scores[0];
                            score.AddPoints(1);
                        }
                        if (i == 1)
                        {
                            Score score = (Score)scores[1];
                            score.AddPoints(1);
                        }
                        isGameOver = true;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the game over flag if a cycler collides with another cycler.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandlePlayerCollisions(Cast cast)
        {
            List<Actor> players = cast.GetActors("cycler");
            List<Actor> scores = cast.GetActors("score");

            Cycler p1 = (Cycler) players[0];
            Cycler p2 = (Cycler) players[1];

            Actor p1Head = p1.GetHead();
            List<Actor> p1Body = p1.GetBody();

            Actor p2Head = p2.GetHead();
            List<Actor> p2Body = p2.GetBody();

            Score p1Score = (Score)scores[1];
            Score p2Score = (Score)scores[0];

            // if heads colide
            if (p1Head.GetPosition().Equals(p2Head.GetPosition()))
            {
                isGameOver = true;
            }

            //if player2 colides with player1
            foreach (Actor segment in p1Body)
            {
                if (segment.GetPosition().Equals(p2Head.GetPosition()))
                {
                    p1Score.AddPoints(1);
                    isGameOver = true;
                }
            }

            //if player1 colides with player2
            foreach (Actor segment in p2Body)
            {
                if (segment.GetPosition().Equals(p1Head.GetPosition()))
                {
                    p2Score.AddPoints(1);
                    isGameOver = true;
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                List<Actor> players = cast.GetActors("cycler");

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetColor(Constants.RED);
                message.SetText("Game Over!");
                message.SetPosition(position);
                message.SetFontSize(25);
                cast.AddActor("messages", message);


                foreach (Actor player in players)
                {
                    Cycler cycler = (Cycler)player;
                    List<Actor> segments = cycler.GetSegments();

                    foreach (Actor segment in segments)
                    {
                        segment.SetColor(Constants.WHITE);
                    }
                    cycler.SetIsGameOver(true);
                }
            }
        }
    }
}