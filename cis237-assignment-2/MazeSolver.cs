using System;
using System.Threading;

namespace cis237_assignment_2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        bool complete = false;
        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public async void SolveMaze(char[,] maze, int yStart, int xStart)
        {
            // Do work needed to use mazeTraversal recursive call and solve the maze.
            mazeTraversal(maze, xStart, yStart);
            complete = false;
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// More than likely you will need to pass in at a minimum the current position
        /// in X and Y maze coordinates. EX: mazeTraversal(int currentX, int currentY)
        /// </summary>
        public void mazeTraversal(char[,] maze, int col, int row)
        {


            if(complete)
            {
                return;
            }
            PrintMatrix(maze);
            bool orbsLeft = (OrbChecker(maze));

            // Did we reach an exit and collect all orbs? If so, exit
            if (orbsLeft == false)
            {

                maze[col, row] = 'X';
                if ((maze.GetLength(0) == col + 1 || maze.GetLength(1) == row + 1) || col == 0 || row == 0)
                {
                    PrintMatrix(maze);
                    complete = true;
                    return;
                }
                if (col < maze.GetLength(0) - 1 && row < maze.GetLength(1) - 1)
                {
                    
                    //UP
                    if (maze[(col - 1), row] == '+' || maze[(col - 1), row] == '-' || maze[(col - 1), row] == '.')
                    {
                        mazeTraversal(maze, col - 1, row);
                    }

                    //RIGHT
                    if (maze[col, (row + 1)] == '+' || maze[col, (row + 1)] == '-' || maze[col, (row + 1)] == '.')
                    {
                        mazeTraversal(maze, col, row + 1);
                    }

                    //DOWN
                    if (maze[(col + 1), row] == '+' || maze[(col + 1), row] == '-' || maze[(col + 1), row] == '.')
                    {
                        mazeTraversal(maze, col + 1, row);
                    }

                    //LEFT
                    if (maze[col, (row - 1)] == '+' || maze[col, (row - 1)] == '-' || maze[col, (row - 1)] == '.')
                    {
                        mazeTraversal(maze, col, row - 1);
                    }


                    // if no valid path, then dead end
                    maze[col, row] = 'O';
                    PrintMatrix(maze);



                }

            }

            if (orbsLeft == true)
            {
                if(orbsLeft == true)
                {
                    maze[col, row] = '+';
                }
                if (col < maze.GetLength(0) - 1 && row < maze.GetLength(1) - 1 && col > 0 && row > 0)
                {
                    //UP
                    if (maze[(col - 1), row] == '.' || maze[(col - 1), row] == '@' && orbsLeft == true)
                    {

                        mazeTraversal(maze, col - 1, row);
                        orbsLeft = OrbChecker(maze);
                        if (!orbsLeft)
                        {
                            maze[col - 1, row] = 'X';
                            mazeTraversal(maze, col, row);
                        }
                    }
                    //RIGHT
                    if (maze[col, (row + 1)] == '.' || maze[col, (row + 1)] == '@' && orbsLeft == true)
                    {
                        mazeTraversal(maze, col, row + 1);
                        orbsLeft = OrbChecker(maze);
                        if (!orbsLeft)
                        {
                            maze[col, row + 1] = 'X';
                            mazeTraversal(maze, col, row);
                        }
                    }
                    //DOWN
                    if (maze[(col + 1), row] == '.' || maze[(col + 1), row] == '@' && orbsLeft == true)
                    {

                        mazeTraversal(maze, col + 1, row);
                        orbsLeft = OrbChecker(maze);
                        if (!orbsLeft)
                        {
                            maze[col + 1, row] = 'X';
                            mazeTraversal(maze, col, row);
                        }
                    }
                    //LEFT
                    if (maze[col, (row - 1)] == '.' || maze[col, (row - 1)] == '@' && orbsLeft == true)
                    {

                        mazeTraversal(maze, col, row - 1);
                        orbsLeft = OrbChecker(maze);
                        if (orbsLeft == false)
                        {
                            maze[col, row - 1] = 'X';
                            mazeTraversal(maze, col, row);
                        }
                    }
                    orbsLeft = OrbChecker(maze);
                    if (orbsLeft == true)
                    {
                        // if no valid path, then dead end
                        maze[col, row] = '-';
                        PrintMatrix(maze);

                    }
                }
                
            }
         



        }

        public bool OrbChecker(char[,] maze)
        {
            bool orbs = false;
            foreach (char c in maze)
            {
                if (c == '@')
                {
                    orbs = true;
                    return true;
                }
            }
            return orbs;
        }

        private void PrintMatrix<T>(T[,] matrix)
        {
            if (!complete)
            {
                Console.Clear();
                int delay = 150;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                Thread.Sleep(delay);
            }
        }
    }


}
