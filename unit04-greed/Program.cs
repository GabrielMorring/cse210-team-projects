using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unit04.Game.Casting;
using Unit04.Game.Directing;
using Unit04.Game.Services;


namespace Unit04
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        private static int FRAME_RATE = 12;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 5;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;
        private static string CAPTION = "Greed";
        private static Color WHITE = new Color(255, 255, 255);
        private static int DEFAULT_ARTIFACTS = 40;


        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();

            // create the scoreBoard
            Actor scoreBoard = new Actor();
            scoreBoard.SetText("");
            scoreBoard.SetFontSize(FONT_SIZE);
            scoreBoard.SetColor(WHITE);
            scoreBoard.SetPosition(new Point(0,0));
            cast.AddActor("scoreBoard", scoreBoard);

            // create the player
            Actor player = new Actor();
            player.SetText("#");
            player.SetPosition(new Point(MAX_X/2, MAX_Y-15));
            player.SetFontSize(FONT_SIZE);
            player.SetColor(WHITE);
            cast.AddActor("player", player);


            // create the fallingObjects
            FallingObject rock = new FallingObject();
            rock.SetText("0");
            rock.SetPosition(new Point(400, 500));
            rock.SetFontSize(FONT_SIZE);
            rock.SetColor(WHITE);
            cast.AddActor("fallingObject", rock);


            ScoreBoard score = new ScoreBoard();
            cast.AddActor("scoreBoard", score);

            // start the game
            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService 
                = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.StartGame(cast);
        }
    }
}