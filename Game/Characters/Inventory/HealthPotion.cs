using System;

namespace Game.Characters.Inventory
{
    class HealthPotion : Item     // Later make a specific type for the potion and then the health potion
    {
        public int Healing { get; private set; }

        public HealthPotion(Character user, Screen screen)
        {
            Name = "Health Potion";
            Healing = 5;
            User = user;
            Screen = screen;
        }

        public override void Use()         // Applies the items effect
        {
            User.GainHP(Healing);

            Console.Clear();
            Screen.HealthPotion(Healing);
        }
    }
}
