using ShortCircuitLib;

// 00,01,02,03,04,40,41,42,43,44,32,22,12
namespace ShortCircuit.Levels
{
    class Advanced021 : GameLevel
    {
        public Advanced021()
            : base("Advanced021")
        {
            MapGridSize = 5;
            MinimumMoves = 13;
            MapButtonTypes = new int[,]
            {
                {3,3,3,3,3},
                {3,2,2,2,3},
                {3,2,3,2,3},
                {3,2,2,2,3},
                {3,3,3,3,3}
            };
            MapButtonStates = new int[,]
            {
                {2,1,0,1,2},
                {0,0,2,0,0},
                {1,2,0,2,1},
                {0,0,2,0,0},
                {2,1,0,1,2}
            };
        }
        public override GameLevel NextLevel
        {
            get { return new Advanced022(); }
        }
    }
}
