using System;
using System.IO;

namespace Game.ForTesting
{
    class Tests          // Class exclusive for crazy tests
    {
        public void Test1()
        {

            string sourcePath = @"d:\CSharp Game Project\Game\Sprites\DefaultPose(For testing).txt";
            string sourcePath2 = @"..\..\..\..\Sprites\DefaultPose(For testing).txt";
            string targetPath = @"Sprites\DefaultPose(For testing).txt";

            try
            {
                
                string test = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

                string finalPath = @$"{test}\{targetPath}";

                //Console.WriteLine(finalPath);
                
                
                string[] lines = File.ReadAllLines(finalPath);

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
