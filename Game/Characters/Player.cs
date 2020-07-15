using Game.GameLogic;

namespace Game.Characters
{
    class Player : Character       // Class to store player data
    {
        public Player()
        {
            Name = "Player";     // For now
            Hp = 10;
            CreateMoveSet();
        }

        public void CreateMoveSet()     // Just for testing
        {
            MoveSet.Add(new Attack("Downward Strike", 3));
            MoveSet.Add(new Attack("Upward Strike", 3));
            MoveSet.Add(new Attack("Thrust", 5));
            MoveSet.Add(new Attack("PRAISE THE SUN", 1000));
        }
    }
}
