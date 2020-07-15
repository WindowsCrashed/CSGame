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
            // ----------- INITIALIZATION -------------

            Match m = new Match();
            Screen s = new Screen();
            Player p = new Player();
            BlackKnight bk = new BlackKnight();
            PlayerTurn pt = new PlayerTurn(m, s, p, bk);

            
            // ------------ FIRST CHOICE --------------

            int startingChoice = 0;

            while (startingChoice != 1 && startingChoice != 2)   // Locks the player until he/she chooses a valid option
            {
                Console.Clear();

                s.Idle();   // Change sprite later
                s.Encounter(new BlackKnight());     // Make it possible to fight other opponents latar

                try
                {
                    startingChoice = int.Parse(Console.ReadLine());

                    switch (startingChoice)
                    {
                        case 1:
                            Console.Clear();
                            s.PrepareFight();
                            break;
                        case 2:
                            Console.Clear();
                            s.Flee();
                            break;
                        default:
                            s.CenterText("INVALID CHOICE\n");
                            s.CenterText("Try again");
                            Thread.Sleep(2000);
                            break;
                    }
                }
                catch
                {
                    s.CenterText("INVALID CHOICE\n");
                    s.CenterText("Try again");
                    Thread.Sleep(2000);
                }
            }

            Thread.Sleep(4000);


            // ---------------- TURNS -------------------

            while (startingChoice == 1)   // Turns loop until a character dies or flees
            {
                if (!m.MatchInProgress)
                {
                    break;
                }

                pt.Turn();
            }
        }
    }
}
