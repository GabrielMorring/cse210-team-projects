using Unit05.Game.Casting;
using Unit05.Game.Directing;
using Unit05.Game.Scripting;
using Unit05.Game.Services;
using Unit05.Game;
using System;
using System.Collections.Generic;




namespace unit05_cycle
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();

            Cycler player1 = new Cycler((int)(Constants.MAX_X / 2), Constants.MAX_Y / 3, Constants.GREEN);
            Cycler player2 = new Cycler((int)(Constants.MAX_X / 2), (int)(Constants.MAX_Y / 1.5), Constants.BLUE);
            
            Score score1 = new Score("Player One");
            score1.SetPosition(new Point(0,0));

            Score score2 = new Score("Player Two");
            score2.SetPosition(new Point(Constants.MAX_X - 140, 0));
            
            
            cast.AddActor("cycler", player2);
            cast.AddActor("cycler", player1);
            cast.AddActor("score", score1);
            cast.AddActor("score", score2);


            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}