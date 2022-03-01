using System.Collections.Generic;
using Unit04.Game.Casting;
using Unit04.Game.Services;
using System;




namespace Unit04.Game.Directing
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private KeyboardService keyboardService = null;
        private VideoService videoService = null;
        private Random random = new Random();

        private int _score;

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;
            _score = 0;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {
            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the player.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {
            Actor player = cast.GetFirstActor("player");
            Point velocity = keyboardService.GetDirection();
            player.SetVelocity(velocity);     
        }

        /// <summary>
        /// Updates the player's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
            Actor scoreBoard = cast.GetFirstActor("scoreBoard");
            Actor player = cast.GetFirstActor("player");
            List<Actor> fallingObjects = cast.GetActors("fallingObject");
            
            if (random.Next(0, 25) == 1)
            {

                for (int i = 0; i < 1; i++)
                {
                    // create the fallingObjects
                    FallingObject rock = new FallingObject();
                    rock.SetText("0");
                    rock.SetPosition(new Point( random.Next(0,900), 0));
                    rock.SetFontSize(15);
                    rock.SetColor(new Color(random.Next(0,255), random.Next(0,255), random.Next(0,255)));
                    cast.AddActor("fallingObject", rock);
                }

                for (int i = 0; i < 1; i++)
                {
                    // create the fallingObjects
                    FallingObject gem = new FallingObject();
                    gem.SetText("*");
                    gem.SetPosition(new Point( random.Next(0,900), 0));
                    gem.SetFontSize(15);
                    gem.SetColor(new Color(random.Next(0,255), random.Next(0,255), random.Next(0,255)));
                    cast.AddActor("fallingObject", gem);
                }
            }

            foreach ( Actor actor in fallingObjects)
            {
                if ((Math.Abs(player.GetPosition().GetX() - actor.GetPosition().GetX()) < 10) && (Math.Abs(player.GetPosition().GetY() - actor.GetPosition().GetY()) < 3))
                {

                    if (actor.GetText() == "0")  
                    {
                        _score -= 100;
                        actor.SetColor(new Color(0,0,0));
                    }
                    if (actor.GetText() == "*")  
                    {
                        _score += 100;
                        actor.SetColor(new Color(0,0,0));    
                    }     



                }
            }


                




            scoreBoard.SetText($"Score: {_score}");
            int maxX = videoService.GetWidth();
            int maxY = videoService.GetHeight();
            player.MoveNext(maxX, maxY);

            foreach (FallingObject actor in fallingObjects)
            {
                actor.DoUpdates();
            } 
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            videoService.ClearBuffer();
            videoService.DrawActors(actors);
            videoService.FlushBuffer();
        }

    }
}