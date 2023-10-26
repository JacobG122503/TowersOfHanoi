using System;
namespace TowersOfHanoi
{
	public class Game
	{
		private const int POSTS = 3;
		private int blocks;
		public Block[ , ] game; // [post, blocks]
        public int moves = 0;
        public int bestPossibleMoves;

		public Game(int blocks)
		{
			this.blocks = blocks;
			game = new Block[POSTS, blocks];
            bestPossibleMoves = (int) Math.Pow(2, blocks) - 1;

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

            //If post is empty already
            if (belowTarget == null) 
            {
                game[targetPost, blocks - 1] = movingBlock;
                game[startPost, movingBlock.blockPos] = null;
                movingBlock.postPos = targetPost;
                movingBlock.blockPos = blocks - 1;

                moves++;
                return true;
            }
            //If targetPos + 1 size is greater
            if (belowTarget.size > movingBlock.size)
            {
                game[targetPost, belowTarget.blockPos - 1] = movingBlock;
                game[startPost, movingBlock.blockPos] = null;
                movingBlock.postPos = targetPost;
                movingBlock.blockPos = belowTarget.blockPos - 1;

                moves++;
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

        public bool CheckIfGameWon()
        {
            Block block = FindTopBlock(2);
            if (block == null) return false;
            if (block.blockPos == 0) return true;

            return false;
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
                    if (currentBlock == null) //If null print emtpy post "|"
                    {
                        int emptyPostSpaces = (maxBlockSize - 1) / 2;
                        for (int s = 0; s < emptyPostSpaces; s++)
                        {
                            gameStr += " ";
                        }
                        
                        gameStr += "\x1b[37m" + "|";

                        for (int s = 0; s < emptyPostSpaces + 1; s++)
                        {
                            gameStr += " ";
                        }
                        continue;
                    }

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
            gameStr += "\n\nMoves: " + moves;
            return gameStr;
        }
    }
}

