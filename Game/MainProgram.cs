using Game.Characters;
using Game.GameLogic;
using System;
using System.Threading;

namespace Game
{
    class MainProgram
    {
        static void Main(string[] args)       // Change to Main2() when testing
        {
            // Just for experimentation

            Screen sc = new Screen();
            PlayerTurn pt = new PlayerTurn();

            //Player p = new Player();

            sc.Idle();
            sc.Encounter(new BlackKnight());

            //Console.WriteLine(p.MoveSet[0].Name);

            int choice = int.Parse(Console.ReadLine());

            Console.Clear();
            switch (choice)
            {
                case 1:
                    sc.PrepareFight();
                    break;
                case 2:
                    sc.Flee();
                    break;
            }
            Thread.Sleep(4000);

            Console.Clear();
            pt.Turn();
        }
    }
}
