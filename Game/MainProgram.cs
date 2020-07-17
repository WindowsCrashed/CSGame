using Game.Characters;
using Game.GameLogic;
using Game.Exceptions;
using System;
using System.Threading;

namespace Game
{
    class MainProgram
    {
        static void Main(string[] args)       // Change to Main2() when testing
        {
            // ----------- INITIALIZATION -------------
            
            Screen s = new Screen();
            CombatException e = new CombatException(s);
            Match m = new Match(s);
            Player p = new Player();
            BlackKnight bk = new BlackKnight();
            PlayerTurn pt = new PlayerTurn(m, s, p, bk, e);

            
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
                            Thread.Sleep(4000);
                            break;
                        case 2:
                            Console.Clear();
                            s.Flee();
                            break;
                        default:
                            e.InvalidChoice();
                            break;
                    }
                }
                catch
                {
                    e.InvalidChoice();
                }
            }


            // ---------------- TURNS -------------------

            while (startingChoice == 1)
            {
                // ----- Checks if the player has stopped the game -----
                if (!m.MatchInProgress)
                {
                    break;
                }


                // ----- Turns -----

                pt.Turn();


                // ----- Checks if any of the health bars are empty -----

                m.Victory(bk);
                m.Defeat(p);
            }
        }
    }
}
