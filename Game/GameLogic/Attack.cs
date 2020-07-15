using Game.GameLogic.Enums;

namespace Game.GameLogic
{
    class Attack
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public Animation Animation { get; set; }

        public Attack(string name, int damage /*Animation animation*/)
        {
            Name = name;
            Damage = damage;
            //Animation = animation;     // Temporarily disabled
        }
    }
}
