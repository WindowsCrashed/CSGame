using Game.GameLogic;
using Game.GameLogic.Enums;

namespace Game.Characters
{
    class Player : Character       // Class to store player data
    {
        public Player()
        {
            Name = "You";     // For now
            Hp = 10;
            MaxHp = 10;
            CreateMoveSet();
        }

        public void CreateMoveSet()     // Just for testing
        {
            MoveSet.Add(new Attack("Downward Strike", 3));
            MoveSet.Add(new Attack("Upward Strike", 3));
            MoveSet.Add(new Attack("Thrust", 5, Animation.Thrust));
            MoveSet.Add(new Attack("PRAISE THE SUN", 9999));
        }
    }
}
