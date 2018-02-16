using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Instructions
    {
        public static void Instruction(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("This game is ripped off the old classic 'Snake' game.\n\nThe purpose of this game is to eat as many apples as possible and avoid hitting the walls. How many apples can you eat?");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPress <BACKSPACE> to return to the menu");

            if(Console.ReadKey().Key == ConsoleKey.Backspace)
            {
                Console.Clear();
                Program.Main(args);
            }
            else
            {
                Console.Clear();
                Instruction(args);
            }
        }
    }
}
