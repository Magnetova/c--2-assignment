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
        char open = '.';
        char tried = 'o';
        char path = 'x';
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
        public bool mazeTraversal(char[,] maze, int yPos, int xPos)
        {
            Console.Clear();
            PrintMaze(maze, yPos, xPos);

            if (maze[yPos, xPos] == '#')
            {
                return false;
            }
            if (maze[yPos, xPos] == '+' || maze[yPos, xPos] == '-')
            {
                return false;
            }
            if (yPos == 0 || yPos == 11 || xPos == 0 || xPos == 11)
            {
                maze[yPos, xPos] = 'X';
                return true;
            }
            maze[yPos,xPos] = '+';

            bool found = mazeTraversal(maze, yPos, xPos - 1) ||//left
                         mazeTraversal(maze, yPos, xPos + 1) ||//right
                         mazeTraversal(maze, yPos - 1, xPos) ||//up
                         mazeTraversal(maze, yPos + 1, xPos);//down
            if (found)
            {
                maze[yPos, xPos] = 'X';
            }
            else
            {
                maze[yPos, xPos] = '-';
            }
            return true;


        }
        private void PrintMaze(char[,] maze, int yPos, int xPos)
        {
            int counter = 0;
            int delay = 500;
            foreach (char c in maze)
            {

                Console.Write(c + " ");
                counter++;
                if (counter == 12)
                {
                    Console.WriteLine();
                    counter = 0;
                }
            }
            Thread.Sleep(delay);

        }

    }
}
