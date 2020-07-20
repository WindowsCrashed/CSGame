using System.Collections.Generic;
using Game.GameLogic;
using Game.Characters.Inventory;

namespace Game.Characters
{
    abstract class Character          // Generic class for game characters
    {
        public string Name { get; protected set; }
        public int Hp { get; protected set; }
        public int MaxHp { get; protected set; }
        public Character Opponent { get; protected set; }
        public CharInventory Inventory { get; protected set; }
        public Screen Screen { get; private set; }
        public bool ShieldUp { get; private set; } = false;
        public List<Attack> MoveSet { get; private set; } = new List<Attack>();

        public void SetOpponent(Character opponent)    // Previously used for solving an issue with Screen (MAY BE USEFUL LATER)
        {
            Opponent = opponent;
        }
        public void SetScreen(Screen screen)     // Used for solving issue with Screen
        {
            Screen = screen;
        }
        public void SetInventory()    // Used for solving issue with Screen (MAY BE USEFUL LATER)
        {
            Inventory = new CharInventory(this, Screen);
        }
        public void GainHP(int amount)     // Increases this character's HP
        {
            int newHp = Hp + amount;
            
            if (newHp > MaxHp)
            {
                Hp = MaxHp;
            } else
            {
                Hp = newHp;
            }
        }
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
