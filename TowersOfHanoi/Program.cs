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
                    "3. No larger disk may be placed on top of a smaller disk.\n\n" +
                    "Type 0 to get started: ");
                answer = Console.ReadLine();
            }
            //Start game

            Console.Clear();
            Console.WriteLine("GAME START\n\n");
            Console.WriteLine("How many blocks would you like your game to have?");
            int blocks = int.Parse(Console.ReadLine());

            Game game = new Game(blocks);

            Console.WriteLine(game.ToString());

            game.TestMove();
            Console.WriteLine("\n\n" + game.ToString());
            Console.ReadLine();
        }
    }
}