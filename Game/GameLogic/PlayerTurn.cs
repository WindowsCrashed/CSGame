using Game.Characters;
using System;
using System.Threading;

namespace Game.GameLogic
{
    class PlayerTurn         // Class to manage the player's turn logic
    {
        Screen screen = new Screen();
        Player player = new Player();
        BlackKnight enemy = new BlackKnight();   // Change later to include multiple enemies

        public bool Turn()          // Manages player turns
        {
            Console.Clear();

            screen.PlayerTurn();      // Prints the main UI
            int mainChoice = int.Parse(Console.ReadLine());

            Console.Clear();

            switch (mainChoice)     // Choose move
            {
                case 1:
                    Attack();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    screen.Flee();
                    return false;            // Causes the end of the game
            }

            return true;        // Continues the game's execution
        }
        public void Attack()        // Function to manage attacks
        {
            screen.PlayerAttack(new Player());
            int choice = int.Parse(Console.ReadLine());
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
        public void MakeAttack(int pos)     // Calculates damage (and does other things)
        {
            enemy.Hp -= player.MoveSet[pos].Damage;

            Console.Clear();
            screen.Damage(player, pos);
            Thread.Sleep(3000);
        }
    }
}
