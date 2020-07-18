using System;
using Game.Miscellaneous;

namespace Game.ForTesting
{
    class Program         // Class to run the crazy tests
    {
        static void Main2(string[] args)      // Change to Main() when testing
        {
            Tests tests = new Tests();
            Directories d = new Directories();

            Console.WriteLine(d.GetSpritePath("Idle"));
            
            //tests.Test1();
        }
    }
}
