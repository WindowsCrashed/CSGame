using System;
using System.IO;
using Game.Characters;

namespace Game
{
    class Screen      // Class containing screen related functions
    {
        public void CenterText(string text)     // Used for centering messages
        {
            for (int i = 0; i < 53 - (text.Length / 2); i++)
            {
                Console.Write(" ");
            }
            Console.Write(text);
        }
        public void HealthBarLogic(Character c)  // Used for calculating the health bar length
        {
            int relativeHP = c.Hp * 2;      // Used for the printing

            for (int i = 1; i <= 20; i++)
            {
                if (relativeHP - i < 0)
                {
                    Console.Write("-");
                }
                else
                {
                    Console.Write("H");
                }
            }
        }


        // ---------- PRINTING FUNCTIONS -------------

        public void DottedLine()      // Prints those lines
        {
            for (int i = 0; i < 106; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("\n");
        }
        public void Idle()        // Prints the standard position of the characters
        {
            string sourcePath = @"d:\CSharp Game Project\Game\Sprites\Idle.txt";

            try
            {
                string[] lines = File.ReadAllLines(sourcePath);

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR 404");
                Console.WriteLine(e.Message);
            }
        }
        public void Welcome()       // Just for testing
        {
            DottedLine();

            CenterText("WELCOME TO THE FIRST GAME PROJECT!!!\n\n");
            CenterText("GOOD LUCK, WINDOWSCRASHED!!!(you'll need it...)\n\n");

            DottedLine();
        }
        public void Encounter(Character e)     // Prints the encounter message and decisions 
        {
            DottedLine();
            CenterText($"A {e.Name.ToUpper()} STEPS INTO YOUR PATH!!!\n\n");
            DottedLine();

            CenterText("What are you going to do?\n\n");
            CenterText("[1] FIGHT    [2] TURN BACK\n\n");
        }
        public void PrepareFight()      // Prints the first option's message
        {
            DottedLine();
            CenterText("Taking the sword and preparing to fight!\n\n");
            DottedLine();
        }
        public void Flee()     // Prints the exit message
        {
            DottedLine();
            CenterText("Turning back and seeking another path...\n\n");
            DottedLine();
        }
        public void PlayerTurn(Player player, Character opponent)     // Prints the main UI
        {
            Idle();
            HealthBar(player, opponent);
            DottedLine();
            CenterText("What is going to be your next move?\n\n");
            DottedLine();
            CenterText("[1] ATTACK    [2] DEFEND\n");
            CenterText("[3] INVENTORY    [4] FLEE\n\n");
        }
        public void PlayerAttack(Player player, Character opponent)     // Prints the Attack Choice UI
        {
            Idle();
            HealthBar(player, opponent);
            DottedLine();
            CenterText("Which attack are you going to use?\n\n");
            DottedLine();
            CenterText($"[1] {player.MoveSet[0].Name}    [2] {player.MoveSet[1].Name}\n");
            CenterText($"[3] {player.MoveSet[2].Name}    [4] {player.MoveSet[3].Name}\n\n");
        }
        public void EnemyTurn(Player player, Character opponent)   // Prints the Enemy Turn UI
        {
            Idle();
            HealthBar(player, opponent);
            DottedLine();
            CenterText($"The {opponent.Name} is preparing to move...\n\n");
            DottedLine();
        }
        public void EnemyAttack(Player player, Character opponent, int pos)   // Prints the Enemy Attack UI
        {
            Idle();
            HealthBar(player, opponent);
            DottedLine();
            CenterText($"{opponent.MoveSet[pos].Name.ToUpper()} INCOMING!!!\n\n");
            DottedLine();
        }
        public void Damage(Character c, int pos)    // Prints damage screen
        {
            DottedLine();
            CenterText($"{c.MoveSet[pos].Damage} DAMAGE!!!\n\n");
            DottedLine();
        }
        public void HealthBar(Player player, Character opponent)   // Prints the health bars of player and opponent
        {
            Console.WriteLine();

            for (int i = 0; i < 14; i++)
            {
                Console.Write(" ");
            }

            HealthBarLogic(player);

            for (int i = 0; i < 36; i++)
            {
                Console.Write(" ");
            }

            HealthBarLogic(opponent);

            Console.WriteLine("\n");
        }
        public void Victory()   // Prints the victory message
        {
            DottedLine();
            CenterText("Enemy defeated!\n");
            CenterText("YOU WIN!!!\n\n");
            DottedLine();
        }
        public void Defeat()    // Prints the defeat message
        {
            DottedLine();
            CenterText("You've been defeated...\n");
            CenterText("YOU LOSE...\n\n");
            DottedLine();
        }
    }
}
