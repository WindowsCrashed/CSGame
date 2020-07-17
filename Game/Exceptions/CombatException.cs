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
            _screen.CenterText("INVALID CHOICE\n");
            _screen.CenterText("Try again");
            Thread.Sleep(2000);
        }
    }
}
