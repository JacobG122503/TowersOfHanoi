using System;
namespace TowersOfHanoi
{
	public class Game
	{
		private const int POSTS = 3;
		public int blocks;
		public Block[ , ] game; // [post, blocks]

		public Game(int blocks)
		{
			this.blocks = blocks;
			game = new Block[POSTS, blocks];

			//Fill array
			for (int i = 0; i < blocks; i++)
			{
				if (i == 0)
				{
					game[0, 0] = new Block(this, 1, 0, 0);
					continue;
				}
				game[0, i] = new Block(this, game[0, i-1].size + 2, 0, i);
			}
		}

        public void TestMove()
        {
            game[0, 0].TryMove(2);
            this.ToString();
        }

        public override string ToString()
        {
			string gameStr = "";
            //Find biggest block size
            int maxBlockSize = 0;
            for (int i = 0; i < blocks; i++)
            {
                for (int j = 0; j < POSTS; j++)
                {
                    Block currentBlock = game[j, i];
                    if (currentBlock != null && currentBlock.size > maxBlockSize)
                    {
                        maxBlockSize = currentBlock.size;
                    }
                }
            }
            //Print rows
            for (int i = 0; i < blocks; i++)
            {
                for (int j = 0; j < POSTS; j++)
                {
                    Block currentBlock = game[j, i];
                    if (currentBlock == null) continue;

                    int spaces = (maxBlockSize - currentBlock.size) / 2;

                    for (int s = 0; s < spaces; s++)
                    {
                        gameStr += " ";
                    }

                    gameStr += currentBlock.ToString();

                    for (int s = 0; s < spaces; s++)
                    {
                        gameStr += " ";
                    }
                }
                gameStr += "\n";
            }

            for (int i = 0; i < 3; i++)
            {
                int postSpaces;
                if (i == 0)
                {
                    postSpaces = maxBlockSize / 2;
                } else
                {
                    postSpaces = maxBlockSize;
                }
                for (int j = 0; j < postSpaces; j++)
                {
                    gameStr += " ";
                }
                gameStr += "" + (i+1);
            }

            return gameStr;
        }
    }
}

