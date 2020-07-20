using Game.Exceptions;
using System.Threading;
using System.Collections.Generic;

namespace Game.Characters.Inventory
{
    class CharInventory
    {
        public List<Item> Items { get; private set; } = new List<Item>();
        public Character Owner { get; private set; }
        private Screen _screen;
        private CombatException _exception;

        public CharInventory(Character owner, Screen screen)
        {
            _screen = screen;
            _exception = new CombatException(_screen);
            Owner = owner;
            AddItem();     // FIX LATER
        }

        public void AddItem()    // Adds item to inventory (ONLY FOR TESTING FOR NOW)
        {
            Items.Add(new HealthPotion(Owner, _screen));
            Items.Add(null);
            Items.Add(null);      // In order to avoid errors
            Items.Add(null);
        }
        public void UseItem(int pos)     // For now, search item in iventory by index
        {
            if (Items[pos] == null)
            {
                _exception.NoItemFound();
            } else
            {
                _screen.UseItem(this, pos);

                Thread.Sleep(3000);

                Items[pos].Use();

                Items.RemoveAt(pos);       // After consumes item, it's gone from inventory
                Items.Insert(pos, null);    // In order to avoid errors

                Thread.Sleep(3000);
            }
        }
        public string CheckItemSlot(int pos)      // For UI purposes
        {
            if (Items[pos] == null)
            {
                return "Empty Slot";
            }

            return Items[pos].Name;
        }
        public bool ValidateSlot(int pos)     // Used for stopping or continuing the loop in PlayerTurn
        {
            if (Items[pos] != null)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
