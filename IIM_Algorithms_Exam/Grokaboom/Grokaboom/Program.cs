using System;

namespace Grokaboom
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Press 'X' to exit, any other key to continue.");
            Console.WriteLine("");
            World world = new World();
            world.Initialize();
            do
            {
                world.Grokaboooom();
            } while (Console.ReadKey().Key != ConsoleKey.X);
        }
    }
}
