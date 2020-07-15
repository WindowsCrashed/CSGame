using Game.Characters;
using System;
using System.Threading;

namespace Game.GameLogic
{
    class PlayerTurn         // Class to manage the player's turn logic
    {
        public Match Match { get; set; }
        public Screen Screen { get; set; }
        public Player Player { get; set; }
        public Character Enemy { get; set; }
        
        public PlayerTurn(Match match, Screen screen, Player player, Character enemy)
        {
            Match = match;
            Screen = screen;
            Player = player;
            Enemy = enemy;
        }

        public void Turn()          // Manages player turns
        {
            int choice = 0;

            while (choice != 1 && choice != 2 && choice != 3 && choice != 4)   // Locks the player until he/she chooses a valid option
            {
                Console.Clear();

                Screen.PlayerTurn(Player, Enemy);      // Prints the main UI

                try
                {
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)     // Choose action
                    {
                        case 1:
                            Attack();
                            break;
                        case 2:
                            Defend();
                            break;
                        case 3:
                            Inventory();
                            break;
                        case 4:
                            Flee();
                            break;            
                        default:
                            Screen.CenterText("INVALID CHOICE\n");
                            Screen.CenterText("Try again");
                            Thread.Sleep(2000);
                            break;
                    }
                }
                catch
                {
                    Screen.CenterText("INVALID CHOICE\n");
                    Screen.CenterText("Try again");
                    Thread.Sleep(2000);
                }
            }
        }
        public void Attack()        // Function to manage attacks
        {
            int choice = 0;

            while (choice != 1 && choice != 2 && choice != 3 && choice != 4)      // Locks the player until he/she chooses a valid option
            {
                Console.Clear();

                Screen.PlayerAttack(Player, Enemy);
                
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    
                    switch (choice)
                    {
                        case 1:
                            MakeAttack(0);
                            break;
                        case 2:
                            MakeAttack(1);
                            break;
                        case 3:
                            MakeAttack(2);
                            break;
                        case 4:
                            MakeAttack(3);
                            break;
                        default:
                            Screen.CenterText("INVALID CHOICE\n");
                            Screen.CenterText("Try again");
                            Thread.Sleep(2000);
                            break;
                    }
                }
                catch
                {
                    Screen.CenterText("INVALID CHOICE\n");
                    Screen.CenterText("Try again");
                    Thread.Sleep(2000);
                }
            }
        }
        public void MakeAttack(int pos)     // Calculates damage (and does other things)
        {
            Enemy.Hp -= Player.MoveSet[pos].Damage;

            Console.Clear();
            Screen.Damage(Player, pos);
            Thread.Sleep(3000);
        }
        public void Defend() { }
        public void Inventory() { }
        public void Flee()   // Function to end game
        {
            Console.Clear();
            Screen.Flee();
            Match.EndMatch();
        }
    }
}
