using System.IO;

namespace Game.Miscellaneous
{
    class Directories     // Class to locate directories and files
    {
        // ------- Solution which worked for now -------

        public string GetSolutionPath()    // Gets the main project folder
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
        }
        public string GetSpritePath(string name)     // Gets the path of a specific sprite
        {
            return @$"{GetSolutionPath()}\Sprites\{name}.txt";
        }
    }
}
