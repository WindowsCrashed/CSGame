using Game.GameLogic.Enums;

namespace Game.GameLogic
{
    class Attack
    {
        public string Name { get; private set; }
        public int Damage { get; private set; }
        public Animation Animation { get; private set; }

        public Attack(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }
        public Attack(string name, int damage, Animation animation)
        {
            Name = name;
            Damage = damage;
            Animation = animation;
        }
    }
}
