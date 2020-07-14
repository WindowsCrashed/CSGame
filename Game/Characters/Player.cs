namespace Game.Characters
{
    class Player         // Class to store player data
    {
        public string[] MoveSet { get; private set; } = new string[4];

        public Player()
        {
            CreateMoveSet();
        }

        public void CreateMoveSet()
        {
            MoveSet[0] = "Downward Strike";
            MoveSet[1] = "Upward Strike";
            MoveSet[2] = "Thrust";
            MoveSet[3] = "PRAISE THE SUN";
        }
    }
}
