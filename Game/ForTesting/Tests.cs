using System;
using System.IO;

namespace Game.ForTesting
{
    class Tests          // Class exclusive for crazy tests
    {
        public void Test1()
        {
            string sourcePath = @"..\..\..\..\Sprites\DefaultPose(For testing).txt";

            try
            {
                string[] lines = File.ReadAllLines(sourcePath);

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            } catch (IOException e)
            {
                Console.WriteLine("ERROR 404");
                Console.WriteLine(e.Message);
            }
        }
    }
}
