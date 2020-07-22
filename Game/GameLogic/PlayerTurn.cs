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
                _player.LowerShield();   // Lowers player shield at the beginning of the turn

                int choice = 0;   // Anything other than 1, 2, 3, 4

                while (choice != 1 && choice != 2 && choice != 3 && choice != 4)   // Locks the player until he/she chooses a valid option
                {
                    Console.Clear();

                    _screen.PlayerTurn();      // Prints the main UI

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
            int choice = 10;     // Anything other than 1, 2, 3, 4 and 0

            while (choice != 1 && choice != 2 && choice != 3 && choice != 4 && choice != 0)      // Locks the player until he/she chooses a valid option
            {
                Console.Clear();

                _screen.PlayerAttackMenu();
                
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
                        case 0:    // Returns to main menu
                            Turn();
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
            Console.Clear();

            if (_enemy.ShieldUp)        // Only deals damage if enemy's shield is lowered
            {
                _screen.BlockAttack();
                _enemy.LowerShield();
            } else
            {
                _enemy.ReduceHP(_player, pos);
                _screen.Damage(_player, pos);
            }
            
            Thread.Sleep(3000);
        }
        public void Defend()      // Cancels enemy damage
        {
            _player.RaiseShield();

            Console.Clear();
            _screen.PlayerDefence();
            Thread.Sleep(3000);
        }   
        public void Inventory()   // Manages inventory choice
        {
            int choice = 10;    // Anything other than 1, 2, 3, 4 and 0
            bool validItem = true;   // Just for initialization

            while (choice != 0)
            {
                Console.Clear();

                _screen.PlayerInventory(_player.Inventory);

                try
                {
                    choice = int.Parse(Console.ReadLine());

                    if (choice != 0) // Position is 1 less then choice number (0 brings bugs)
                    {
                        validItem = _player.Inventory.ValidateSlot(choice - 1);
                    }

                    switch (choice)
                    {
                        case 1:
                            UseItem(0);
                            break;
                        case 2:
                            UseItem(1);
                            break;
                        case 3:
                            UseItem(2);
                            break;
                        case 4:
                            UseItem(3);
                            break;
                        case 0:         // Returns to main menu
                            Turn(); 
                            break;
                        default:
                            _exception.InvalidChoice();
                            break;
                    }

                    
                    if (validItem)     // Locks the player until he/she chooses a valid option
                    {
                        break;
                    }
                }
                catch
                {
                    _exception.InvalidChoice();
                }
            }
        }
        public void UseItem(int pos)   // Uses item selected in inventory
        {
            Console.Clear();
            _player.Inventory.UseItem(pos);
        }
        public void Flee()   // Function to end game
        {
            Console.Clear();
            _screen.Flee();
            _match.EndMatch();
        }
    }
}
