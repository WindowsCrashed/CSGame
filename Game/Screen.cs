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
        public void Encounter(BlackKnight bk)     // Prints the encounter message and decisions 
        {
            DottedLine();
            CenterText($"A {bk.Name.ToUpper()} STEPS INTO YOUR PATH!!!\n\n");
            DottedLine();

            CenterText("What are you going to do?\n\n");
            CenterText("[1] FIGHT    [2] TURN BACK\n\n");
        }
    }
}
