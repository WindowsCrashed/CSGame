using Game.Characters;
using System;

namespace Game
{
    class MainProgram
    {
        static void Main(string[] args)       // Change to Main2() when testing
        {
            // Just for experimentation

            Screen sc = new Screen();

            sc.Idle();
            sc.Encounter(new BlackKnight());
            Console.ReadLine();
        }
    }
}
