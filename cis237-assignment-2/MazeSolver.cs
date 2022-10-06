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
        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public async void SolveMaze(char[,] maze, int yStart, int xStart)
        {
            // Do work needed to use mazeTraversal recursive call and solve the maze.
            mazeTraversal(maze, xStart, yStart);
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
            // place an X
            maze[col, row] = char.Parse("X");

            // draw the maze
            // Console.Write(writer.WriteMaze(maze));
            Console.Clear();
            PrintMatrix(maze);
            

            // Did we reach an exit? If so, exit
            if (maze.GetLength(0) == col + 1 || maze.GetLength(1) == row + 1)
            {
                Console.Write("Solved!");
                Environment.Exit(0);
            }

            if (maze[(col - 1), row] == '.')
            {
                mazeTraversal(maze, col - 1, row); // up
            }

            if (maze[col, (row + 1)] == '.')
            {
                mazeTraversal(maze, col, row + 1);// right
            }

            if (maze[(col + 1), row] == '.')
            {
                mazeTraversal(maze, col + 1, row);// down
            }

            if (maze[col, (row - 1)] == '.')
            {
                mazeTraversal(maze, col, row - 1);// left
            }

            maze[col, row] = 'O';

        }
        private static void PrintMatrix<T>(T[,] matrix)
        {
            int delay = 300;
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
