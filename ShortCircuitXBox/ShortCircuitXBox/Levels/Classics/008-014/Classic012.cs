using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic012 : GameLevel
    {
        public Classic012()
            : base("Classic012")
        {
            MapGridSize = 4;
            MinimumMoves = 4;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2},
                {2,2,2,2},
                {2,2,2,2},
                {2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {2,2,2,2},
                {2,2,2,2},
                {2,2,2,2},
                {2,2,2,2}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic013();
            }
        }
    }
}
