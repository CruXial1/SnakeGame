using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Controls
    {
        public static void Control(string[] args)
        {
            Console.WriteLine("Controls:\n         Left Arrow - Move Left\n         Right Arrow - Move Right\n         Down Arrow - Move Down\n         Up Arrow - Move Up");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPress <BACKSPACE> to return to the menu.");

            if(Console.ReadKey().Key == ConsoleKey.Backspace)
            {
                Console.Clear();
                Program.Main(args);
            }
            else
            {
                Console.Clear();
                Control(args);
            }
        }
    }
}
