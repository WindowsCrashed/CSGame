using Game.GameLogic;

namespace Game.Characters
{
    class BlackKnight : Character           // Class to store enemy data
    {
        public BlackKnight()
        {
            Name = "Black Knight";
            Hp = 10;
            MaxHp = 10;
            CreateMoveSet();
        }

        public void CreateMoveSet()     // Just for testing
        {
            MoveSet.Add(new Attack("Downward Strike", 3));
            MoveSet.Add(new Attack("Upward Strike", 3));
            MoveSet.Add(new Attack("Thrust", 5));
            MoveSet.Add(new Attack("ULTIMATE NOT OVERPOWERED ATTACK", 9999));
        }
    }
}
