using ShortCircuitLib;

// 01,41,23,12,32,20,04,44
namespace ShortCircuit.Levels
{
    class Advanced019 : GameLevel
    {
        public Advanced019()
            : base("Advanced019")
        {
            MapGridSize = 5;
            MinimumMoves = 8;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2,2},
                {2,3,3,3,2},
                {3,2,2,2,3},
                {2,3,2,3,2},
                {2,2,3,2,2}
            };
            MapButtonStates = new int[,]
            {
                {2,2,2,2,2},
                {2,2,1,2,2},
                {2,2,2,2,2},
                {2,2,2,2,2},
                {2,2,1,2,2}
            };
        }
        public override GameLevel NextLevel
        {
            get { return new Advanced020(); }
        }
    }
}
