namespace Game.Characters.Inventory
{
    abstract class Item
    {
        public string Name { get; protected set; }
        public Character User { get; protected set; }
        public Screen Screen { get; protected set; }

        public abstract void Use();
    }
}
