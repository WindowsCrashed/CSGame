using Game.Characters;
using System;
using System.Threading;

namespace Game.GameLogic
{
    class EnemyTurn       // Class to manage the opponent's turn logic
    {
        private Match _match;
        private Screen _screen;
        private Character _enemy;
        private Player _player;
        private Random _random;

        public EnemyTurn(Match match, Screen screen, Player player, Character enemy)
        {
            _match = match;
            _screen = screen;
            _enemy = enemy;
            _player = player;
            _random = new Random();
        }

        public void Turn()   // Manages opponent's turns
        {
            if (_match.MatchInProgress)        // If the match is not in progress, doesn't start turn
            {
                _enemy.LowerShield();  // Lowers enemy shield at the beginning of the turn

                int choice = _random.Next(1, 3);       // Most Basic AI

                Console.Clear();
                _screen.EnemyTurn();
                Thread.Sleep(3000);

                switch (choice)
                {
                    case 1:
                        Attack();
                        break;
                    case 2:
                        Defend();
                        break;
                }

                _match.Defeat(_player);   // Checks if player's health bar is empty
            }
        }
        public void Attack()    // Function to manage attacks 
        {
            int choice = _random.Next(1, 5);

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
            }
        }
        public void MakeAttack(int pos)    // Calculates damage and displays the UI
        {
            Console.Clear();
            _screen.EnemyAttack(pos);
            Thread.Sleep(3000);

            Console.Clear();
            
            if (_player.ShieldUp)      // Only deals damage if player's shield is lowered
            {
                _screen.BlockAttack(_player);
                _player.LowerShield();
            } else
            {
                _player.ReduceHP(_enemy, pos);
                _screen.Damage(_enemy, pos);
            }

            Thread.Sleep(3000);
        }
        public void Defend()   // Raises enemy shield
        {
            _enemy.RaiseShield();

            Console.Clear();
            _screen.Defence(_enemy);
            Thread.Sleep(3000);
        }
    }
}
