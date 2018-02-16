using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.CursorVisible = false;

            Console.WriteLine("Welcome to the Snake Game V.1.1");
            Console.WriteLine("Proceed by selecting one of the following options..\n\n");

            Console.WriteLine("1) Start Game\n2) Instructions\n3) Controls\n");

            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Game(args);
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    Instructions.Instruction(args);
                    break;

                case ConsoleKey.D3:
                    Console.Clear();
                    Controls.Control(args);
                    break;

                default:
                    Console.WriteLine("\n\nInvalid key, please restart the application.", Console.ForegroundColor = ConsoleColor.Red);
                    break;
            }
        }

        static void Game(string[] args)
        {
            int[] xPos = new int[50];
            int[] yPos = new int [50];

            xPos[0] = 35;
            yPos[0] = 20;

            int appleXpos = 10;
            int appleYpos = 10;

            int applesEaten = 0;

            bool isGameOn = true;
            bool isWallHit = false;
            bool isAppleEaten = false;

            decimal gameSpeed = 150m;

            Random rng = new Random();

            //Get snake to appear on screen
            paintSnake(applesEaten, xPos, yPos, out xPos, out yPos);

            //Set apple position
            setApplePosition(rng, out appleXpos, out appleYpos);
            colorApple(appleXpos, appleYpos);

            //Build boundary
            buildwall();

            //Get snake to move

            ConsoleKey command = Console.ReadKey().Key;

            do
            {
                switch (command)
                {
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(xPos[0], yPos[0]);
                        Console.Write(" ");
                        xPos[0]--;
                        break;

                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(xPos[0], yPos[0]);
                        Console.Write(" ");
                        yPos[0]--;
                        break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(xPos[0], yPos[0]);
                        Console.Write(" ");
                        xPos[0]++;
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(xPos[0], yPos[0]);
                        Console.Write(" ");
                        yPos[0] ++;
                        break;
                }

                //Paint the snake
                paintSnake(applesEaten, xPos, yPos, out xPos, out yPos);

                isWallHit = didSnakeHitWall(xPos[0], yPos[0]);

                //Detect when snake hits the boundary
                if (isWallHit)
                {
                    isGameOn = false;

                    Console.SetCursorPosition(28, 20);
                    Console.WriteLine("GAME OVER!");
                }

                //Detect when apple was eaten
                isAppleEaten = wasAppleEaten(xPos[0], yPos[0], appleXpos, appleYpos);

                //Place apple on board(random)
                if (isAppleEaten)
                {
                    setApplePosition(rng, out appleXpos, out appleYpos);
                    colorApple(appleXpos, appleYpos);
                    applesEaten++;
                    gameSpeed *= .925m;
                }

                if (Console.KeyAvailable) command = Console.ReadKey().Key;

                //Slow game down
                Thread.Sleep(Convert.ToInt32(gameSpeed));

            } while (isGameOn);
        }

        private static void paintSnake(int applesEaten, int[] xPosIn, int[] yPosIn, out int[] xPosOut, out int[] yPosOut)
        {
            //Paint the head
            Console.SetCursorPosition(xPosIn[0], yPosIn[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine((char)214);

            //Paint the body
            for (int i = 1; i < applesEaten + 1; i++)
            {
                Console.SetCursorPosition(xPosIn[i], yPosIn[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("o");
            }

            //Erase last part of snake
            Console.SetCursorPosition(xPosIn[applesEaten + 1], yPosIn[applesEaten + 1]);
            Console.WriteLine(" ");

            //Record snake location
            for (int i = applesEaten; i > 0; i--)
            {
                xPosIn[i] = xPosIn[i - 1];
                yPosIn[i] = yPosIn[i - 1];
            }

            //Return new array
            xPosOut = xPosIn;
            yPosOut = yPosIn;
        }

        private static bool didSnakeHitWall(int xPos, int yPos)
        {
            if (xPos == 1 || xPos == 70 || yPos == 1 || yPos == 40)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void buildwall()
        {
            for (int i = 1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);

                Console.Write("█");

                Console.SetCursorPosition(70, i);
                Console.Write("█");
            }

            for (int i = 1; i < 71; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 1);

                Console.Write("▀");

                Console.SetCursorPosition(i, 40);
                Console.Write("▀");
            }
        }

        private static void setApplePosition(Random rng, out int appleXpos, out int appleYpos)
        {
            appleXpos = rng.Next(0 + 2, 70 - 2);
            appleYpos = rng.Next(0 + 2, 40 - 2);
        }

        private static void colorApple(int appleXpos, int appleYpos)
        {
            Console.SetCursorPosition(appleXpos, appleYpos);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write((char)64);
        }

        private static bool wasAppleEaten(int xPos, int yPos, int appleXpos, int appleYpos)
        {
            if (xPos == appleXpos && yPos == appleYpos) return true; return false;
        }
    }
}
