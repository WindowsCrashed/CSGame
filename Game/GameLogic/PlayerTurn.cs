using Game.Characters;
using System;

namespace Game.GameLogic
{
    class PlayerTurn         // Class to manage the player's turn logic
    {
        Screen screen = new Screen();
        Player player = new Player();

        public bool Turn()
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
            Console.ReadLine();
        }
    }
}
