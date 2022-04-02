using System;
using System.Collections.Generic;
using System.IO;
using Unit06.Game.Casting;
using Unit06.Game.Scripting;
using Unit06.Game.Services;


namespace Unit06.Game.Directing
{
    public class SceneManager
    {
        public static AudioService AudioService = new RaylibAudioService();
        public static KeyboardService KeyboardService = new RaylibKeyboardService();
        public static MouseService MouseService = new RaylibMouseService();
        public static PhysicsService PhysicsService = new RaylibPhysicsService();
        public static VideoService VideoService = new RaylibVideoService(Constants.GAME_NAME,
            Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.BLACK);

        public SceneManager()
        {
        }

        public void PrepareScene(string scene, Cast cast, Script script)
        {
            if (scene == Constants.NEW_GAME)
            {
                PrepareNewGame(cast, script);
            }
            else if (scene == Constants.NEXT_LEVEL)
            {
                PrepareNextLevel(cast, script);
            }
            else if (scene == Constants.IN_PLAY)
            {
                PrepareInPlay(cast, script);
            }
            else if (scene == Constants.GAME_OVER)
            {
                PrepareGameOver(cast, script);
            }
        }

        private void PrepareNewGame(Cast cast, Script script)
        {
            AddStats(cast);
            AddP1Score(cast);
            // AddStats(cast);
            AddP2Score(cast);

            AddPlayers(cast);
            
            AddDialog(cast, Constants.ENTER_TO_START);

            script.ClearAllActions();
            AddInitActions(script);
            AddLoadActions(script);

            ChangeSceneAction a = new ChangeSceneAction(KeyboardService, Constants.NEXT_LEVEL);
            script.AddAction(Constants.INPUT, a);

            AddOutputActions(script);
            AddUnloadActions(script);
            AddReleaseActions(script);
        }


        private void PrepareNextLevel(Cast cast, Script script)
        {
            cast.ClearActors(Constants.WINNER_GROUP);
            AddPlayers(cast);
            AddDialog(cast, Constants.PREP_TO_LAUNCH);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.IN_PLAY, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(script);

            PlaySoundAction sa = new PlaySoundAction(AudioService, Constants.WELCOME_SOUND);
            script.AddAction(Constants.OUTPUT, sa);
        }

        private void PrepareInPlay(Cast cast, Script script)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);

            script.ClearAllActions();

            ControlPlayer1Action action1 = new ControlPlayer1Action(KeyboardService);
            ControlPlayer2Action action2 = new ControlPlayer2Action(KeyboardService);

            AddCourseFeatures(cast);

            script.AddAction(Constants.INPUT, action1);
            AddUpdateActions(script);    
            AddOutputActions(script); 

            script.AddAction(Constants.INPUT, action2);
            AddUpdateActions(script);    
            AddOutputActions(script);
        
        }

        private void PrepareGameOver(Cast cast, Script script)
        {
            AddPlayers(cast);
            
            AddDialog(cast, Constants.WAS_GOOD_GAME);

            foreach(Player player in cast.GetActors(Constants.PLAYER_GROUP))
            {

                Player winner = (Player)cast.GetFirstActor(Constants.WINNER_GROUP);

                if(winner.GetPlayerNum() == 1)
                {
                    AddDialog(cast, Constants.PLAYER_ONE_WINS);
                } 
                if(winner.GetPlayerNum() == 2)
                {
                    AddDialog(cast, Constants.PLAYER_TWO_WINS);
                }
            }

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.NEW_GAME, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(script);
        }

        // -----------------------------------------------------------------------------------------
        // casting methods
        // -----------------------------------------------------------------------------------------

        private void AddPlayers(Cast cast)
        {
            cast.ClearActors(Constants.PLAYER_GROUP);
        
            int x = Constants.PLAYER_WIDTH * 3;
            int y = (int)Constants.SCREEN_HEIGHT / 3;
        
            Point position = new Point(x, y);
            Point position2 = new Point(x, (int)(y * 1.5));

            Point size = new Point(Constants.PLAYER_WIDTH, Constants.PLAYER_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.PLAYER1_IMAGE);
            Player player1 = new Player(body, image, 1, false);
            
            Body body2 = new Body(position2, size, velocity);
            Image image2 = new Image(Constants.PLAYER2_IMAGE);
            Player player2 = new Player(body2, image2, 2, false);
            
            cast.AddActor(Constants.PLAYER_GROUP, player1);        
            cast.AddActor(Constants.PLAYER_GROUP, player2);
        }

        private void AddObstacle(Cast cast, int height, int distance)
        {
            // cast.ClearActors(Constants.OBSTACLE_GROUP);
        
            int x = Constants.SCREEN_WIDTH + distance;
            int y = height;
            if(height > Constants.SCREEN_HEIGHT)
            {
                y = Constants.SCREEN_HEIGHT - Constants.OBSTACLE_HEIGHT;
            }
            if(height < 0)
            {
                y = 0;
            }


            Point position = new Point(x, y);

            Point size = new Point(Constants.OBSTACLE_WIDTH * 2, Constants.OBSTACLE_HEIGHT * 2);
            Point velocity = new Point(Constants.COURSEFEATURE_VELOCITY, 0);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.OBSTACLE_IMAGE);
            Obstacle obstacle = new Obstacle(body, image, false);
            
            cast.AddActor(Constants.OBSTACLE_GROUP, obstacle);
            cast.AddActor(Constants.COURSEFEATURE_GROUP, obstacle);        
        }

        private void AddFinishLine(Cast cast)
        {
            cast.ClearActors(Constants.FINISH_LINE_GROUP);
        
            int x = Constants.SCREEN_WIDTH + Constants.FINISH_LINE_DISTANCE;
            int y = 0;
        
            Point position = new Point(x, y);

            Point size = new Point(Constants.PLAYER_WIDTH, Constants.PLAYER_HEIGHT);
            Point velocity = new Point(Constants.COURSEFEATURE_VELOCITY, 0);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.FINISH_LINE_IMAGE);
            FinishLine finishLine = new FinishLine(body, image, false);
            
            
            
            cast.AddActor(Constants.FINISH_LINE_GROUP, finishLine);   
            cast.AddActor(Constants.COURSEFEATURE_GROUP, finishLine);           
        }

        // Course Features for that go in a level


        private void AddCourseFeatures(Cast cast)
        {
            cast.ClearActors(Constants.COURSEFEATURE_GROUP);
        
            AddFinishLine(cast);
            AddObstacle(cast, 100, 200);
            AddObstacle(cast, 400, 200);

            AddObstacle(cast, 200, 300);
            AddObstacle(cast, 300, 400);
            AddObstacle(cast, 400, 500);
            AddObstacle(cast, 500, 600);
            AddObstacle(cast, 600, 700);

            AddObstacle(cast, 700, 800);
            AddObstacle(cast, 100, 800);
            AddObstacle(cast, 300, 800);

            AddObstacle(cast, 600, 700);

            AddObstacle(cast, 200, 500);
            


            AddObstacle(cast, 100, 900);
            AddObstacle(cast, 400, 950);
            
            AddObstacle(cast, 400, 1500);
            AddObstacle(cast, 300, 1550);

            AddObstacle(cast, 700, 2000);
            AddObstacle(cast, 500, 2000);
            AddObstacle(cast, 700, 2500);

            AddObstacle(cast, 100, 2500);
            AddObstacle(cast, 400, 2250);

            
        }


     

        private void AddDialog(Cast cast, string message)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);

            Text text = new Text(message, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.WHITE);
            Point position = new Point(Constants.CENTER_X, Constants.CENTER_Y);

            Label label = new Label(text, position);
            cast.AddActor(Constants.DIALOG_GROUP, label);   
        }

        private void AddLevel(Cast cast)
        {
            cast.ClearActors(Constants.LEVEL_GROUP);

            Text text = new Text(Constants.LEVEL_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_LEFT, Constants.WHITE);
            Point position = new Point(Constants.HUD_MARGIN, Constants.HUD_MARGIN);

            Label label = new Label(text, position);
            cast.AddActor(Constants.LEVEL_GROUP, label);
        }

        private void AddLives(Cast cast)
        {
            //cast.ClearActors(Constants.LIVES_GROUP);

            Text text = new Text(Constants.LIVES_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_RIGHT, Constants.WHITE);
            Point position = new Point(Constants.SCREEN_WIDTH - Constants.HUD_MARGIN, 
                Constants.HUD_MARGIN);

            Label label = new Label(text, position);
            cast.AddActor(Constants.LIVES_GROUP, label);   
        }

        

        private void AddP1Score(Cast cast)
        {
            // cast.ClearActors(Constants.SCORE_GROUP);
    
            Text text = new Text(Constants.SCORE1_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.WHITE);
            Point position = new Point(Constants.SCREEN_WIDTH - 100, Constants.HUD_MARGIN);
            
            Label label = new Label(text, position);
            cast.AddActor(Constants.SCORE_GROUP, label);   
        }

        private void AddP2Score(Cast cast)
        {
            // cast.ClearActors(Constants.SCORE_GROUP);

            Text text = new Text(Constants.SCORE2_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.WHITE);
            Point position = new Point(100, Constants.HUD_MARGIN);
            
            Label label = new Label(text, position);
            cast.AddActor(Constants.SCORE_GROUP, label);   
        }

        private void AddStats(Cast cast)
        {
            // cast.ClearActors(Constants.STATS_GROUP);
            Stats stats = new Stats();
            cast.AddActor(Constants.STATS_GROUP, stats);
        }

        private List<List<string>> LoadLevel(string filename)
        {
            List<List<string>> data = new List<List<string>>();
            using(StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    List<string> columns = new List<string>(row.Split(',', StringSplitOptions.TrimEntries));
                    data.Add(columns);
                }
            }
            return data;
        }

        // -----------------------------------------------------------------------------------------
        // scriptig methods
        // -----------------------------------------------------------------------------------------

        private void AddInitActions(Script script)
        {
            script.AddAction(Constants.INITIALIZE, new InitializeDevicesAction(AudioService, 
                VideoService));
        }

        private void AddLoadActions(Script script)
        {
            script.AddAction(Constants.LOAD, new LoadAssetsAction(AudioService, VideoService));
        }

        private void AddOutputActions(Script script)
        {
            script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawPlayerAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawObstacleAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawFinishLineAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawDialogAction(VideoService));
            script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService));
        }

        private void AddUnloadActions(Script script)
        {
            script.AddAction(Constants.UNLOAD, new UnloadAssetsAction(AudioService, VideoService));
        }

        private void AddReleaseActions(Script script)
        {
            script.AddAction(Constants.RELEASE, new ReleaseDevicesAction(AudioService, 
                VideoService));
        }

        private void AddUpdateActions(Script script)
        {
            script.AddAction(Constants.UPDATE, new MovePlayerAction());
            script.AddAction(Constants.UPDATE, new MovePlayerAction());
            script.AddAction(Constants.UPDATE, new MoveCourseFeatureAction());
            script.AddAction(Constants.UPDATE, new CollideBordersAction(PhysicsService, AudioService));
            script.AddAction(Constants.UPDATE, new CheckOverAction());     
        }
    }
}