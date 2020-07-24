using System;
using System.Threading;

namespace Game.Exceptions
{
    class CombatException      // Stores the fight's exceptions
    {
        private Screen _screen;

        public CombatException(Screen screen)
        {
            _screen = screen;
        }

        public void InvalidChoice()
        {
            Console.Clear();

            _screen.IdlePose();
            _screen.HealthBar();
            _screen.MessageDouble("INVALID CHOICE", "Try again");

            Thread.Sleep(2000);
        }
        public void NoItemFound()
        {
            Console.Clear();

            _screen.IdlePose();
            _screen.CombatUI($"NO ITEM IN THIS SLOT");

            Thread.Sleep(2000);
        }
    }
}
