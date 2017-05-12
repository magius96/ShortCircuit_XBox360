using ShortCircuitLib;

// 20,11,01
namespace ShortCircuit.Levels
{
    class Advanced004 : GameLevel
    {
        public Advanced004() : base("Advanced004")
        {
            MapGridSize = 3;
            MinimumMoves = 3;
            MapButtonTypes = new int[,]
            {
                {3,2,2},
                {3,2,2},
                {3,3,3}
            };
            MapButtonStates = new int[,]
            {
                {1,0,2},
                {2,0,0},
                {1,1,0}
            };
        }

        public override GameLevel NextLevel
        {
            get { return new Advanced005(); }
        }
    }
}
