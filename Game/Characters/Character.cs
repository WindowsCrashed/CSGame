using System.Collections.Generic;
using Game.GameLogic;

namespace Game.Characters
{
    abstract class Character          // Generic class for game characters
    {
        public string Name { get; protected set; }
        public int Hp { get; protected set; }
        public bool ShieldUp { get; private set; } = false;
        public List<Attack> MoveSet { get; private set; } = new List<Attack>();

        public void ReduceHP(Character attacker, int pos)     // Lowers this character's HP based on the attacker's attack
        {
            Hp -= attacker.MoveSet[pos].Damage;
        }
        public void RaiseShield()    // Change shield status to Raised
        {
            ShieldUp = true;
        }
        public void LowerShield()    // Change shield status to Lowered
        {
            ShieldUp = false;
        }
    }
}
