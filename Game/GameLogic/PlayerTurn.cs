using Game.Characters;
using Game.Exceptions;
using System;
using System.Threading;

namespace Game.GameLogic
{
    class PlayerTurn         // Class to manage the player's turn logic
    {
        private Match _match; 
        private Screen _screen;
        private Player _player;
        private Character _enemy;
        private CombatException _exception;
        
        public PlayerTurn(Match match, Screen screen, Player player, Character enemy, CombatException exception)
        {
            _match = match;
            _screen = screen;
            _player = player;
            _enemy = enemy;
            _exception = exception;
        }

        public void Turn()          // Manages player turns
        {
            if (_match.MatchInProgress)   // If the match is not in progress, doesn't start turn
            {
                int choice = 0;

                while (choice != 1 && choice != 2 && choice != 3 && choice != 4)   // Locks the player until he/she chooses a valid option
                {
                    Console.Clear();

                    _screen.PlayerTurn(_player, _enemy);      // Prints the main UI

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
                                _exception.InvalidChoice();
                                break;
                        }

                        _match.Victory(_enemy);   // Checks if enemy's health bar is empty
                    }
                    catch
                    {
                        _exception.InvalidChoice();
                    }
                }
            }
        }
        public void Attack()        // Function to manage attacks
        {
            int choice = 0;

            while (choice != 1 && choice != 2 && choice != 3 && choice != 4)      // Locks the player until he/she chooses a valid option
            {
                Console.Clear();

                _screen.PlayerAttack(_player, _enemy);
                
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
                            _exception.InvalidChoice();
                            break;
                    }
                }
                catch
                {
                    _exception.InvalidChoice();
                }
            }
        }
        public void MakeAttack(int pos)     // Calculates damage and displays UI
        {
            _enemy.ReduceHP(_player, pos);

            Console.Clear();
            _screen.Damage(_player, pos);
            Thread.Sleep(3000);
        }
        public void Defend() { }   // Empty for now
        public void Inventory() { }  // Empty for now
        public void Flee()   // Function to end game
        {
            Console.Clear();
            _screen.Flee();
            _match.EndMatch();
        }
    }
}
