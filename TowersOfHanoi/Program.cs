namespace TowersOfHanoi
{
    /**
     * Towers of Hanoi
     * 
     * Author: Jacob Garcia
     * Version: 1.0.0
     */
    class Program
    {
        public static void Main(string[] args)
        {
            int entireGame = 0;
            while (entireGame == 0)
            {
                Console.Write("\x1b[37m");
                Console.Clear();
                Console.WriteLine("TOWERS OF HANOI\n");
                Console.WriteLine("Welcome to Towers of Hanoi. If you do not\n" +
                    "know how to play. Please type 1 to view instructions. If not\n" +
                    "type 0 to get started");
                string answer = Console.ReadLine();

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
                        "4. The overall goal is to move all blocks from post 1, to post 3. \n" +
                        "Good luck! \n\n" +
                        "Type 0 to get started: ");
                    Console.ReadLine();
                } //Estimate time for it being done. Take 2^n - 1 times the .seconds / 60
                  //Start game
                Console.Clear();
                Console.WriteLine("GAME START\n\n");
                Console.WriteLine("How many blocks would you like your game to have?");
                int blocks = int.Parse(Console.ReadLine());

                Game game = new Game(blocks);

                bool playing = true;
                //Game loop
                while (playing)
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
                    try
                    {
                        game.MoveBlock(startPost - 1, endPost - 1);
                    }
                    catch
                    {
                        continue;
                    }
                    if (game.CheckIfGameWon())
                    {
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
            Console.ReadLine();
        }
    }
}