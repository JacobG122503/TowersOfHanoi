using System.Diagnostics;

namespace TowersOfHanoi
{
    /**
     * Towers of Hanoi
     * 
     * Author: Jacob Garcia
     * Version: 1.0.0
     * Last Updated: 10/27/23
     */
    static class Program
    {
        public static void Main(string[] args)
        {
            int entireGame = 0;
            Game game = null;
            while (entireGame == 0)
            {
                try
                {
                    Console.Write("\x1b[37m");
                    Console.Clear();
                    Console.WriteLine("TOWER OF HANOI\n");
                    Console.WriteLine("Welcome to Tower of Hanoi! \n\n" +
                        "Type 1 to view instructions.\n" +
                        "Type 0 to play.\n" +
                        "Type r to enter auto solving mode and watch the computer solve it by itself!\n" +
                        "Type x to exit.");
                    string answer = Console.ReadLine();

                    if (answer == "x") break;

                    if (answer == "r")
                    {
                        AutoSolveMode();
                        Console.WriteLine("\nDone!! Hit enter to continue");
                        Console.ReadLine();
                        continue;
                    }

                    if (answer == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("The objective of TOH is to move all blocks onto a different post\n" +
                            "in the same order it starts in. So from top-bottom the blocks increase in size.\n");
                        Console.WriteLine("RULES: \n" +
                            "1. Only one disk can be moved at a time.\n" +
                            "2. Each move consists of taking the upper disk from one of the stacks and \n" +
                            "placing it on top of another stack. In other words, a disk can only be moved if it is the \n" +
                            "uppermost disk on a stack.\n" +
                            "3. No larger disk may be placed on top of a smaller disk.\n" +
                            "Good luck! \n\n" +
                            "Hit enter to continue ");
                        Console.ReadLine();
                        continue;
                    }
                    //Start game
                    Console.Clear();
                    Console.WriteLine("GAME START\n\n");
                    Console.WriteLine("How many blocks would you like your game to have?");
                    int blocks = int.Parse(Console.ReadLine());
                    game = new Game(blocks);
                    LoadingAnimation();
                } catch
                {
                    continue;
                }
                bool playing = true;
                //Game loop
                while (playing)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine(game.ToString());
                        Console.WriteLine("\x1b[37m \nWhat post would you like to grab a block from?");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int startPost = int.Parse(Console.ReadLine());
                        Console.WriteLine("\x1b[37m What post would you like to move the block to?");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int endPost = int.Parse(Console.ReadLine());
                        Console.Write("\x1b[37m");
                        game.MoveBlock(startPost - 1, endPost - 1);
                    }
                    catch
                    {
                        continue;
                    }
                    if (game.CheckIfGameWon())
                    {
                        Console.Clear();
                        Console.WriteLine("\x1b[37m" + game.ToString());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("YOU WON!! Good job!\n");
                        Console.WriteLine("Moves: " + game.moves +
                            "\nLeast possible moves: " + game.bestPossibleMoves);
                        Console.WriteLine("\nType 0 to play again or 1 to exit");
                        entireGame = int.Parse(Console.ReadLine());
                        break;
                    }
                }
            }
            Console.WriteLine("\n\n\nThanks for playing! :)");
            Thread.Sleep(1000);
        }

        private static int sleepTime;
        private static void AutoSolveMode()
        {
            Console.Clear();
            Console.WriteLine("AUTO SOLVING MODE\n\n");
            Console.Write("Number of blocks: ");
            int blocks = int.Parse(Console.ReadLine());
            Game game = new Game(blocks);
            bool typedCorrectly = false;
            while (!typedCorrectly)
            {
                Console.Write("\nMilliseconds between each move: ");
                sleepTime = int.Parse(Console.ReadLine());

                //Get time estimate
                long timeMilli = game.bestPossibleMoves * sleepTime;

                Console.WriteLine("\nEstimated time of completion: " + FormatTime(timeMilli) + " (Dependending on your computer's power)");
                Console.WriteLine("Is this okay? (y/n): ");
                string answer = Console.ReadLine();

                typedCorrectly = (answer == "y");
            }
            LoadingAnimation();

            stopWatch.Start();
            RecursiveSolve(blocks, 0, 1, 2, game);
            stopWatch.Stop();
        }

        private static Stopwatch stopWatch = new Stopwatch();
        private static void RecursiveSolve(int n, int firstPost, int lastPost, int midPost, Game game)
        {
            if (n == 0)
            {
                return;
            }
            RecursiveSolve(n - 1, firstPost, midPost, lastPost, game);

            game.MoveBlock(firstPost, lastPost);
            Thread.Sleep(sleepTime);
            if (n != 0) Console.Clear();
            Console.WriteLine(game.ToString());
            int movesLeft = (game.bestPossibleMoves - game.moves);
            Console.WriteLine("Moves left: " + movesLeft);
            Console.WriteLine("\nTime elapsed: " + stopWatch.Elapsed);
            double movesPS = game.moves / stopWatch.Elapsed.TotalSeconds;
            Console.WriteLine("Moves per second: " + movesPS.ToString(".00") + " m/s");
            string estTimeLeft = FormatTime((long) (movesLeft / movesPS) * 1000);
            Console.WriteLine("Est time left: " + estTimeLeft);

            RecursiveSolve(n - 1, midPost, lastPost, firstPost, game);
        }

        private static string FormatTime(long milliseconds)
        {
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(milliseconds);
            string formattedTime = "";

            if (timeSpan.Days > 0)
            {
                formattedTime += $"{timeSpan.Days} days, ";
            }

            if (timeSpan.Hours > 0)
            {
                formattedTime += $"{timeSpan.Hours} hours, ";
            }

            if (timeSpan.Minutes > 0)
            {
                formattedTime += $"{timeSpan.Minutes} minutes, ";
            }

            if (timeSpan.Seconds > 0)
            {
                formattedTime += $"{timeSpan.Seconds} seconds ";
            }

            //formattedTime += $"{timeSpan.Milliseconds} milliseconds";

            /*formattedTime += " (Depending on computers processing power...)";

            if (milliseconds == 0) formattedTime = "n/a Will depend entirely on your machines processing power.";*/

            return formattedTime;
        }

        private static void LoadingAnimation()
        {
            string bar = "[";
            int loadTime = 1000;
            int barLength = 50;

            int delay = loadTime / barLength;
            //Create empty bar
            for (int i = 0; i < barLength; i++)
            {
                bar += " ";
            }
            bar += "]";


            for (int i = 1; i < barLength + 2; i++)
            {
                Thread.Sleep(delay);
                Console.Clear();
                Console.WriteLine(bar);

                bar = bar.Remove(i, 1);
                bar = bar.Insert(i, "=");
            }
            Thread.Sleep(300);
        }
    }
}