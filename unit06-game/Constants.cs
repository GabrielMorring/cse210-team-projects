using System.Collections.Generic;
using Unit06.Game.Casting;


namespace Unit06
{
    public class Constants
    {
        // ----------------------------------------------------------------------------------------- 
        // GENERAL GAME CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // GAME
        public static string GAME_NAME = "Batter";
        public static int FRAME_RATE = 60;

        // SCREEN
        public static int SCREEN_WIDTH = 1040;
        public static int SCREEN_HEIGHT = 680;
        public static int CENTER_X = SCREEN_WIDTH / 2;
        public static int CENTER_Y = SCREEN_HEIGHT / 2;

        // FIELD
        public static int FIELD_TOP = 60;
        public static int FIELD_BOTTOM = SCREEN_HEIGHT;
        public static int FIELD_LEFT = 0;
        public static int FIELD_RIGHT = SCREEN_WIDTH;

        // FONT
        public static string FONT_FILE = "Assets/Fonts/zorque.otf";
        public static int FONT_SIZE = 32;

        // SOUND
        public static string BOUNCE_SOUND = "Assets/Sounds/boing.wav";
        public static string WELCOME_SOUND = "Assets/Sounds/start.wav";
        public static string OVER_SOUND = "Assets/Sounds/over.wav";

        // TEXT
        public static int ALIGN_LEFT = 0;
        public static int ALIGN_CENTER = 1;
        public static int ALIGN_RIGHT = 2;


        // COLORS
        public static Color BLACK = new Color(0, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color PURPLE = new Color(255, 0, 255);

        // KEYS
        public static string W = "w";
        public static string A = "a";
        public static string S = "s";
        public static string D = "d";

        public static string LEFT = "left";
        public static string RIGHT = "right";
        public static string UP = "up";
        public static string DOWN = "down";

        public static string SPACE = "space";
        public static string ENTER = "enter";
        public static string PAUSE = "p";

        // SCENES
        public static string NEW_GAME = "new_game";
        public static string TRY_AGAIN = "try_again";
        public static string NEXT_LEVEL = "next_level";
        public static string IN_PLAY = "in_play";
        public static string GAME_OVER = "game_over";

        // LEVELS
        public static string LEVEL_FILE = "Assets/Data/level-{0:000}.txt";
        public static int BASE_LEVELS = 5;

        // ----------------------------------------------------------------------------------------- 
        // SCRIPTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // PHASES
        public static string INITIALIZE = "initialize";
        public static string LOAD = "load";
        public static string INPUT = "input";
        public static string UPDATE = "update";
        public static string OUTPUT = "output";
        public static string UNLOAD = "unload";
        public static string RELEASE = "release";

        // ----------------------------------------------------------------------------------------- 
        // CASTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // STATS
        public static string STATS_GROUP = "stats";
        public static int DEFAULT_LIVES = 3;
        public static int MAXIMUM_LIVES = 5;

        // HUD
        public static int HUD_MARGIN = 15;
        public static string LEVEL_GROUP = "level";
        public static string LIVES_GROUP = "lives";
        public static string SCORE_GROUP = "score";
        public static string LEVEL_FORMAT = "LEVEL: {0}";
        public static string LIVES_FORMAT = "LIVES: {0}";
        public static string SCORE1_FORMAT = "P1 WINS: {0}";
        public static string SCORE2_FORMAT = "P2 WINS: {0}";

        // PLAYER
        public static string WINNER_GROUP = "winner";
        public static string PLAYER_GROUP = "players";
        public static string PLAYER1_IMAGE = "Assets/Images/p1.png";
        public static string PLAYER2_IMAGE = "Assets/Images/p2.png";
        public static int PLAYER_WIDTH = 25;
        public static int PLAYER_HEIGHT = 25;
        public static int PLAYER_VELOCITY = 6;

        // COURSE FEATURE
        public static string COURSEFEATURE_GROUP = "course features";
        public static int COURSEFEATURE_VELOCITY = -5;

        
        // OBSTACLE
        public static string OBSTACLE_GROUP = "obstacles";
        public static string OBSTACLE_IMAGE = "Assets/Images/obstacle.png";
        public static int OBSTACLE_WIDTH = 50;
        public static int OBSTACLE_HEIGHT = 50;

        // POWERUP
        public static string POWERUP_GROUP = "powerup";
        public static string POWERUP_IMAGE = "Assets/Images/powerUp.png";
        public static int POWERUP_WIDTH = 25;
        public static int POWERUP_HEIGHT = 25;

        // FINISH LINE
        public static string FINISH_LINE_GROUP = "finishLine";
        public static string FINISH_LINE_IMAGE = "Assets/Images/finishLine.png";
        public static int FINISH_LINE_WIDTH = 25;
        public static int FINISH_LINE_HEIGHT = 25;
        public static int FINISH_LINE_DISTANCE = 3000;

       
        // DIALOG
        public static string DIALOG_GROUP = "dialogs";
        public static string ENTER_TO_START = "PRESS ENTER TO START";
        public static string PREP_TO_LAUNCH = "READY SET GO!";
        public static string WAS_GOOD_GAME = "GAME OVER";
        public static string PLAYER_ONE_WINS = "PLAYER ONE WINS";
        public static string PLAYER_TWO_WINS = "PLAYER TWO WINS";



    }
}