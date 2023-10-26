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
					game[0, 0] = new Block(1, 0, 0);
					continue;
				}
				game[0, i] = new Block(game[0, i-1].size + 2, 0, i);
			}
		}

        public bool MoveBlock(int startPost, int targetPost)
        {
            //Find top block
            Block movingBlock = FindTopBlock(startPost);
            if (movingBlock == null) return false;

            Block belowTarget = FindTopBlock(targetPost);

            if (belowTarget == null) //If post is empty already
            {
                game[targetPost, blocks - 1] = movingBlock;
                game[startPost, movingBlock.blockPos] = null;
                movingBlock.postPos = targetPost;
                movingBlock.blockPos = blocks - 1;
                return true;
            }

            return false;
        }

        private Block FindTopBlock(int post)
        {
            Block currentBlock = game[post, 0];
            for (int i = 1; currentBlock == null && i < blocks; i++)
            {
                currentBlock = game[post, i];
            }
            return currentBlock;
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
                    
                    for (int s = 0; s < spaces + 1; s++)
                    {
                        gameStr += " ";
                    }
                }
                gameStr += "\n";
            }
            //Print post numbers
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
                    gameStr += "\x1b[37m" + " ";
                }
                gameStr += (i+1);
            }

            return gameStr;
        }
    }
}

