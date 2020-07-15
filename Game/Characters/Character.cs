using System.Collections.Generic;
using Game.GameLogic;

namespace Game.Characters
{
    abstract class Character          // Generic class for game characters
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public List<Attack> MoveSet { get; private set; } = new List<Attack>();
    }
}
