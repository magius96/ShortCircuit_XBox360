using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic016 : GameLevel
    {
        public Classic016()
            : base("Classic016")
        {
            MapGridSize = 5;
            MinimumMoves = 5;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2,2},
                {2,2,2,2,2},
                {2,2,2,2,2},
                {2,2,2,2,2},
                {2,2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {2,0,0,0,2},
                {2,2,2,2,2},
                {0,2,2,2,0},
                {2,2,2,2,2},
                {2,0,0,0,2}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic017();
            }
        }
    }
}
