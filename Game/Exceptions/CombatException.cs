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

            _screen.Idle();
            _screen.HealthBar();
            _screen.DottedLine();
            _screen.CenterText("INVALID CHOICE\n");
            _screen.CenterText("Try again\n\n");
            _screen.DottedLine();

            Thread.Sleep(2000);
        }
        public void NoItemFound()
        {
            Console.Clear();

            _screen.Idle();
            _screen.HealthBar();
            _screen.DottedLine();
            _screen.CenterText($"NO ITEM IN THIS SLOT\n\n");
            _screen.DottedLine();

            Thread.Sleep(2000);
        }
    }
}
