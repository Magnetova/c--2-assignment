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
        //This bool is the "stopping" method of the function. When this is true,
        //the program will only return to its previous recursive call until it can exit the method.
        //Created as a class variable to ensure that the variable doesn't get reset with each recursive call
        //as each recursion of the mazeTraversal method creates new variables for it's stack call.
        bool complete = false;

        //a counter that tells the printmaze function if it can clear console or not
        int dontclearconsole = 0;

        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int yStart, int xStart)
        {
            // Do work needed to use mazeTraversal recursive call and solve the maze.
            // Just passes in the initial parameters set in the program class.
            // Will not be returned to until all recursive processes have been completed.
            mazeTraversal(maze, xStart, yStart);

            //resets the class variable so that the transpose of the maze can also be solved
            //during the same running instance of the program
            complete = false;

            
            dontclearconsole++;
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

            //A bool value that determines if the solution has been completed yet.
            //Placed at the top of the method so it can block the rest of the recursive method if the value is true
            //which in turn effectively "ends" the recursive programs.
            if (complete)
            {
                return;
            }
            //Prints the matrix, at the top so any previous changes to a character in the maze will be shown to the user
            PrintMatrix(maze);
            //Sets the bool orbsleft to the bool value returned from the orb checker
            bool orbsLeft = (OrbChecker(maze));

            // This if statement contains a "new" recursive method that can travel over '-', '+', and '.' that are remaining from the previous recursive method
            // of finding all of the orbs.
            // The contents of this if statement can only be reached by the program if all orbs have been collected
            if (!orbsLeft && !complete)
            {
                //Starts by updating the current position with an 'X'
                maze[col, row] = 'X';

                // This is the completion checker. The orbs have already been checked so the program no longer needs to know if
                // all the orbs have been collected. It is now looking to see if the current position is on the outside of the maze.
                // if the current position is on the outside of the maze matrix, then the condition has been met and the bool completed
                // can be turned to true.
                if ((maze.GetLength(0) == col + 1 || maze.GetLength(1) == row + 1) || col == 0 || row == 0)
                {
                    // Prints the maze one last time so the user can see the overall pathing the program took to get through the maze
                    PrintMatrix(maze);
                    complete = true;
                    return;
                }

                // This is a checking condition to make sure the current position is within the bounds of the array.
                // This is needed becuase the program 'reaches' into the next space before determining if it is a suitable
                // space or not. If the current position is at 0 or 11 on either the row or column, it prevents the program
                // from reaching into a space that is outside the bounds of the matrix.
                if (col < maze.GetLength(0) - 1 && row < maze.GetLength(1) - 1 && col > 0 && row > 0)
                {

                    //UP -- moves the program up one space in the matrix by decreasing the value of the column integer.
                    //This is essentially the program 'reaching' into the space directly above the current position
                    //to determine if it is a valid space to move to.
                    //Because all orbs have already been collected, the orbs (@) are no longer a parameter that needs to be met.
                    if (maze[(col - 1), row] == '+' || maze[(col - 1), row] == '-' || maze[(col - 1), row] == '.')
                    {
                        // This recursive call is decreasing the column by 1 so when the method runs again, it is
                        // one spot up from the current position that it is currently located at during the time the call was made.
                        mazeTraversal(maze, col - 1, row);
                    }

                    //RIGHT -- moves the program right one space in the matrix by increasing the value of the row integer.
                    //This is essentially the program 'reaching' into the space directly to the right of the current position
                    //to determine if it is a valid space to move to.
                    //Because all orbs have already been collected, the orbs (@) are no longer a parameter that needs to be met.
                    if (maze[col, (row + 1)] == '+' || maze[col, (row + 1)] == '-' || maze[col, (row + 1)] == '.')
                    {
                        // This recursive call is increasing the row by 1 so when the method runs again, it is
                        // one spot to the right from the current position that it is currently located at during the time the call was made.
                        mazeTraversal(maze, col, row + 1);
                    }

                    //DOWN -- moves the program down one space in the matrix by decreasing the value of the column integer.
                    //This is essentially the program 'reaching' into the space directly below the current position
                    //to determine if it is a valid space to move to.
                    //Because all orbs have already been collected, the orbs (@) are no longer a parameter that needs to be met.
                    if (maze[(col + 1), row] == '+' || maze[(col + 1), row] == '-' || maze[(col + 1), row] == '.')
                    {
                        // This recursive call is increasing the column by 1 so when the method runs again, it is
                        // one spot down from the current position that it is currently located at during the time the call was made.
                        mazeTraversal(maze, col + 1, row);
                    }

                    //LEFT -- moves the program left one space in the matrix by decreasing the value of the row integer.
                    //This is essentially the program 'reaching' into the space directly to the left of the current position
                    //to determine if it is a valid space to move to.
                    //Because all orbs have already been collected, the orbs (@) are no longer a parameter that needs to be met.
                    if (maze[col, (row - 1)] == '+' || maze[col, (row - 1)] == '-' || maze[col, (row - 1)] == '.')
                    {
                        // This recursive call is decreasing the row by 1 so when the method runs again, it is
                        // one spot to the left from the current position that it is currently located at during the time the call was made.
                        mazeTraversal(maze, col, row - 1);
                    }


                    // if none of the conditions for an valid spot have been meet, then the program must have reached a dead end in the maze.
                    // By having this at the end of the method for when orbs have been collected, it only executes turning the current
                    // position in the maze to 'O' when no conditions have been met.
                    if (!complete)
                    {
                        maze[col, row] = 'O';
                        PrintMatrix(maze);
                    }

                    // After the current position in the maze has been set to 'O' and the maze has been printed
                    // it will end the recursive call because nothing else in the method can be reached due to all the orbs
                    // having been collected.
                    // The program will then backtrack to the last recursive call made and then run from there,
                    // effectively resetting the current position to whatever position the program was in in the maze
                    // during the time of the last recursive call



                }

            }








            // This if statement contains a recursive method that can travel over '.' and '@' due to all the orbs NOT having
            // been collected yet
            // The contents of this if statement can only be reached if all orbs have NOT been colleced yet
            if (orbsLeft == true)
            {
                // Because the backtracking of the recursive method will still run inside this if statement
                // even if all orbs have been collected, a second if statement is required to prevent the backtracking from
                // editing the maze as if the orbs havent been collected.
                if (orbsLeft == true)
                {
                    maze[col, row] = '+';
                }

                // This is a checking condition to make sure the current position is within the bounds of the array.
                // This is needed becuase the program 'reaches' into the next space before determining if it is a suitable
                // space or not. If the current position is at 0 or 11 on either the row or column, it prevents the program
                // from reaching into a space that is outside the bounds of the matrix.
                if (col < maze.GetLength(0) - 1 && row < maze.GetLength(1) - 1 && col > 0 && row > 0)
                {
                    //UP -- moves the program up one space in the matrix by decreasing the value of the column integer.
                    //This is essentially the program 'reaching' into the space directly above the current position
                    //to determine if it is a valid space to move to.
                    if (maze[(col - 1), row] == '.' || maze[(col - 1), row] == '@' && orbsLeft == true)
                    {
                        // This recursive call is decreasing the column by 1 so when the method runs again, it is
                        // one spot up from the current position that it is currently located at during the time the call was made.
                        mazeTraversal(maze, col - 1, row);

                        //checking for orbs to make sure this code doesn't execute when backtracking and all orbs have been collected.
                        orbsLeft = OrbChecker(maze);

                        //after the recursive call above has been backtracked to, we need to change every position it is
                        //returning over into an 'X' since all the orbs have been collected
                        if (!orbsLeft && !complete)
                        {
                            maze[col - 1, row] = 'X';
                            mazeTraversal(maze, col, row);
                        }
                    }

                    //RIGHT -- moves the program right one space in the matrix by increasing the value of the row integer.
                    //This is essentially the program 'reaching' into the space directly to the right of the current position
                    //to determine if it is a valid space to move to.
                    if (maze[col, (row + 1)] == '.' || maze[col, (row + 1)] == '@' && orbsLeft == true)
                    {
                        // This recursive call is increasing the row by 1 so when the method runs again, it is
                        // one spot to the right from the current position that it is currently located at during the time the call was made.
                        mazeTraversal(maze, col, row + 1);

                        //checking for orbs to make sure this code doesn't execute when backtracking and all orbs have been collected.
                        orbsLeft = OrbChecker(maze);

                        //after the recursive call above has been backtracked to, we need to change every position it is
                        //returning over into an 'X' since all the orbs have been collected
                        if (!orbsLeft && !complete)
                        {
                            maze[col, row + 1] = 'X';
                            mazeTraversal(maze, col, row);
                        }
                    }

                    //DOWN -- moves the program down one space in the matrix by decreasing the value of the column integer.
                    //This is essentially the program 'reaching' into the space directly below the current position
                    //to determine if it is a valid space to move to.
                    if (maze[(col + 1), row] == '.' || maze[(col + 1), row] == '@' && orbsLeft == true)
                    {
                        // This recursive call is increasing the column by 1 so when the method runs again, it is
                        // one spot down from the current position that it is currently located at during the time the call was made.
                        mazeTraversal(maze, col + 1, row);

                        //checking for orbs to make sure this code doesn't execute when backtracking and all orbs have been collected.
                        orbsLeft = OrbChecker(maze);

                        //after the recursive call above has been backtracked to, we need to change every position it is
                        //returning over into an 'X' since all the orbs have been collected
                        if (!orbsLeft && !complete)
                        {
                            maze[col + 1, row] = 'X';
                            mazeTraversal(maze, col, row);
                        }
                    }

                    //LEFT -- moves the program left one space in the matrix by decreasing the value of the row integer.
                    //This is essentially the program 'reaching' into the space directly to the left of the current position
                    //to determine if it is a valid space to move to.
                    if (maze[col, (row - 1)] == '.' || maze[col, (row - 1)] == '@' && orbsLeft == true)
                    {
                        // This recursive call is decreasing the row by 1 so when the method runs again, it is
                        // one spot to the left from the current position that it is currently located at during the time the call was made.
                        mazeTraversal(maze, col, row - 1);

                        //checking for orbs to make sure this code doesn't execute when backtracking and all orbs have been collected.
                        orbsLeft = OrbChecker(maze);

                        //after the recursive call above has been backtracked to, we need to change every position it is
                        //returning over into an 'X' since all the orbs have been collected
                        if (!orbsLeft && !complete)
                        {
                            maze[col, row - 1] = 'X';
                            mazeTraversal(maze, col, row);
                        }
                    }

                    // if none of the conditions for an valid spot have been meet, then the program must have reached a dead end in the maze.
                    // By having this at the end of the method, it only executes turning the current
                    // position in the maze to '-' when no conditions have been met.
                    // Also checking for orbs to make sure this code doesn't execute when backtracking and all orbs have been collected.
                    orbsLeft = OrbChecker(maze);
                    if (orbsLeft == true)
                    {
  
                        maze[col, row] = '-';
                        PrintMatrix(maze);

                    }

                    // After the current position in the maze has been set to '-' and the maze has been printed
                    // it will end the recursive call because nothing else in the method can be reached due to all the orbs
                    // NOT having been collected.
                    // The program will then backtrack to the last recursive call made and then run from there,
                    // effectively resetting the current position to whatever position the program was in in the maze
                    // during the time of the last recursive call

                }

            }




        }



        /// <summary>
        /// Checks the maze to make sure no orbs '@' are left in the maze by iterating through every character in the maze
        /// and checking to make sure it does not equal '@'
        /// </summary>
        /// <param name="maze"></param>
        /// <returns> If no characters were equal to an orb, 
        /// the bool value of orbs is returned false (meaning NO orbs are located in the maze). 
        /// Otherwise it is returned true (meaning there are orbs still located in the maze).
        /// </returns>
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


        /// <summary>
        /// Creates a new matrix that can be printed to keep one maze for printing and one for editing within the program
        /// Prints out every character in the maze, giving the visual result of a maze in the console.
        /// A delay has been added to see more clearly the path the program is taking to solve the maze.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        public void PrintMatrix<T>(T[,] matrix)
        {
            if (!complete)
            {
                //makes sure console doesn't clear when I try to print maze solutions
                if( dontclearconsole != 2)
                {
                    Console.Clear();
                }
                int delay = 100;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                if(dontclearconsole == 2)
                {
                    Thread.Sleep(delay);
                }
                
            }

        }
    }


}
