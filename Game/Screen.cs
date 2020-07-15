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
        public void PlayerTurn()     // Prints the main UI
        {
            Idle();
            DottedLine();
            CenterText("What is going to be your next move?\n\n");
            DottedLine();
            CenterText("[1] ATTACK    [2] DEFEND\n");
            CenterText("[3] INVENTORY    [4] FLEE\n\n");
        }
        public void PlayerAttack(Player p)     // Prints the Attack Choice UI
        {
            Idle();
            DottedLine();
            CenterText("Which attack are you going to use?\n\n");
            DottedLine();
            CenterText($"[1] {p.MoveSet[0].Name}    [2] {p.MoveSet[1].Name}\n");
            CenterText($"[3] {p.MoveSet[2].Name}    [4] {p.MoveSet[3].Name}\n\n");
        }
        public void Damage(Character c, int pos)    // Prints damage screen
        {
            DottedLine();
            CenterText($"{c.MoveSet[pos].Damage} DAMAGE!!!\n\n");
            DottedLine();
        }
    }
}
