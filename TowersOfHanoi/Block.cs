using System;
namespace TowersOfHanoi
{
	public class Block
	{
        public int size;
		public int postPos, blockPos;
		private string color;

		public Block(int size, int postPos, int blockPos)
		{
			this.size = size;
			this.postPos = postPos;
			this.blockPos = blockPos;
			color = colorCodes[GetNextColor()];

        }

		override public string ToString()
		{
			string block = "" + color;

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
            //"\u001b[97m"  // White
        };

    }
}

