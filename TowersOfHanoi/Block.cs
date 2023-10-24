using System;
namespace TowersOfHanoi
{
	public class Block
	{
        public int size;
		public int postPos, blockPos;
		private Game game;

		public Block(Game game, int size, int postPos, int blockPos)
		{
			this.size = size;
			this.postPos = postPos;
			this.blockPos = blockPos;
			this.game = game;
		}

		public bool TryMove(int targetPost)
		{
			Block lowerBlock = null;
			//Find lower block
			for (int i = game.blocks-1; i >= 0; i--)
			{
				if (game.game[targetPost, i] != null)
				{
					lowerBlock = game.game[targetPost, i];

                } 
			}

			if (lowerBlock == null)
			{
				game.game[targetPost, game.blocks - 1] = this;
				game.game[postPos, blockPos] = null;
				postPos = targetPost;
				blockPos = game.blocks - 1;
				return true;
			}

			return false;
		}

		override public string ToString()
		{
			string block = "" + colorCodes[GetNextColor()];

			for (int i = 0; i < size; i++)
			{
				block += "0";
			}

			return block;
		}

		private static int GetNextColor()
		{
			if (colorNmb == colorCodes.Length - 1)
			{
				colorNmb = 0;
			}
            return colorNmb++;
		}

        private static int colorNmb = 0;
        private static string[] colorCodes = new string[]
        {
            //"\u001b[30m", // Black
			"\u001b[96m", // Cyan
			"\u001b[91m", // Red
            "\u001b[95m", // Magenta
            "\u001b[93m", // Yellow
			"\u001b[34m", // DarkBlue
            "\u001b[32m", // DarkGreen
            "\u001b[31m", // DarkRed
            "\u001b[35m", // DarkMagenta
            "\u001b[33m", // DarkYellow
            //"\u001b[37m", // Gray
            //"\u001b[90m", // DarkGray
            "\u001b[94m", // Blue
            "\u001b[92m", // Green
            "\u001b[36m", // DarkCyan
            "\u001b[97m"  // White
        };

    }
}

