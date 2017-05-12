using ShortCircuitLib;

// 33,22,42,44,24,15,55,51,11,00,60,66,06,35,31,53,13
namespace ShortCircuit.Levels
{
    class Advanced029 : GameLevel
    {
        public Advanced029()
            : base("Advanced029")
        {
            MapGridSize = 7;
            MinimumMoves = 17;
            UseInDemo = true;
            MapButtonTypes = new int[,]
            {
                {2,3,2,2,2,3,2},
                {3,3,3,2,3,3,3},
                {2,3,3,3,3,3,2},
                {2,2,3,3,3,2,2},
                {2,3,3,3,3,3,2},
                {3,3,3,2,3,3,3},
                {2,3,2,2,2,3,2}
            };
            MapButtonStates = new int[,]
            {
                {2,2,0,2,0,2,2},
                {2,1,0,2,0,1,2},
                {0,0,1,1,1,0,0},
                {2,2,1,1,1,2,2},
                {0,0,1,1,1,0,0},
                {2,1,0,2,0,1,2},
                {2,2,0,2,0,2,2}
            };
        }
        public override GameLevel NextLevel
        {
            get { return new Advanced030(); }
        }
    }
}
