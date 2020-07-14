using System;
using System.IO;

namespace Game
{
    class Screen      // Class containing screen related functions
    {
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
        public void PrintWelcome()
        {
            for (int i = 0; i < 106; i++)
            {
                Console.Write("-");
            }
            
            Console.WriteLine("\n");
            
            for (int i = 0; i < 35; i++)
            {
                Console.Write(" ");
            }
            Console.Write("WELCOME TO THE FIRST GAME PROJECT!!!\n\n");

            for (int i = 0; i < 29; i++)
            {
                Console.Write(" ");
            }
            Console.Write("GOOD LUCK, WINDOWSCRASHED!!! (you'll need it...)\n\n");

            for (int i = 0; i < 106; i++)
            {
                Console.Write("-");
            }
        }
    }
}
