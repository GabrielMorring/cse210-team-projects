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

            Cycler player1 = new Cycler((int)(Constants.MAX_X * .3), Constants.MAX_Y / 2, Constants.Green);
            Cycler player2 = new Cycler((int)(Constants.MAX_X * .6), Constants.MAX_Y / 2, Constants.BLUE);

            cast.AddActor("cycler", player1);
            cast.AddActor("cycler", player2);
            cast.AddActor("score", new Score());

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