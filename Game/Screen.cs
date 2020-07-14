using System;
using System.IO;

namespace Game
{
    class Screen      // Class containing screen related functions
    {
        public void CenterText(string text)
        {
            for (int i = 0; i < 53 - (text.Length / 2); i++)
            {
                Console.Write(" ");
            }
            Console.Write(text);
        }
        public void PrintDottedLine()
        {
            for (int i = 0; i < 106; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("\n");
        }
        public void PrintIdle()
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
        public void PrintWelcome()         // Just for testing
        {
            PrintDottedLine();

            CenterText("WELCOME TO THE FIRST GAME PROJECT!!!\n\n");
            CenterText("GOOD LUCK, WINDOWSCRASHED!!!(you'll need it...)\n\n");

            PrintDottedLine();
        }
    }
}
