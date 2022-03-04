using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the cycler.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the cycler's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;
        private Point p1Direction = new Point(Constants.CELL_SIZE, 0);
        private Point p2Direction = new Point(Constants.CELL_SIZE, 0);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left
            if (keyboardService.IsKeyDown("a"))
            {
                p1Direction = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("d"))
            {
                p1Direction = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("w"))
            {
                p1Direction = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("s"))
            {
                p1Direction = new Point(0, Constants.CELL_SIZE);
            }

            Cycler player1 = (Cycler)cast.GetFirstActor("cycler");
            player1.TurnHead(p1Direction);

            // left
            if (keyboardService.IsKeyDown("j"))
            {
                p2Direction = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("l"))
            {
                p2Direction = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("i"))
            {
                p2Direction = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("k"))
            {
                p2Direction = new Point(0, Constants.CELL_SIZE);
            }
            
            Cycler player2 = (Cycler)cast.GetLastActor("cycler");
            player2.TurnHead(p2Direction);
        }
    }
}