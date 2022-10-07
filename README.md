# Assignment 2 - Recursion to solve a maze

## Author

Cayden Greer


## Description

You must write a program that will traverse a 12 x 12 maze looking for orbs that are placed in the maze. Once all of the orbs have been found, the program must continue traversing the maze and find a successful path from the last collected orb to an exit. You are given a hard coded maze in the program class, as well as some starting coordinates.

Each spot in the maze is represented by either a '#', '.', or '@'. The #'s represent the walls of the maze, the dots represent paths through the maze, and the @'s represent the orbs that must be collected. Moves can be made only up, down, left, or right (not diagonally), one spot at a time, and only over paths / orbs (not into or across a wall).

The exit will be any spot that is on the outside of the array. As your program attempts to collect all the orbs, it will place the character '+' in each spot along the path. If a dead end is reached, your program should replace the '+' with a '-'. Once all orbs have been collected, it should place the character 'X' in each spot along the path. If a dead end is reached, your program should replace the X’s with 'O'.

The output of your program is the maze configuration after each move. In your testing, you may assume that each maze has a path from its starting point to its exit point. If there is no exit, you will arrive at the starting spot again.

In addition to solving the maze as is, I want you to also solve the transposition of the maze. There is a method stub in the main program for transposing the 2D array. This method is just that, a stub. You need to fill out the code to make that transpose method work. The program is already setup to solve both the original maze, and the transposed maze. Your program should be able to solve both of them without any issue.

You are required to use recursion to solve this problem.

Please remember to fill out this README file with the relevant information that is missing.

Also make sure that you comment your name at the top of each file, and add comments for each method.

Comment anything else that isn't obvious about what you are trying to do in the code.

I also want you to comment the recursive method you implement thoroughly to show me that you know what is going on inside your method. By thoroughly, I mean VERY detailed. Much more detail that I have asked for before. You need to show me that you know what is happening inside your recursive method as well as why you are doing the things that you are doing inside of it.

I have included some pictures of sample output at various points of solving below. Note that you do NOT have to change colors, but, you should know how to do that now and it might make reading your output a little easier.

![CIS237 Assignment 2 Output 1](https://barnesbrothers.net/cis237/assignmentImages/cis237_assignment_2_output_1.png)
![CIS237 Assignment 2 Output 2](https://barnesbrothers.net/cis237/assignmentImages/cis237_assignment_2_output_2.png)
![CIS237 Assignment 2 Output 3](https://barnesbrothers.net/cis237/assignmentImages/cis237_assignment_2_output_3.png)

### Notes

It might be useful while developing this program to use a smaller sized maze, and then get it to work with the real ones.

Don't forget that you must have a base case for your recursive method or you will continue to get a stack overflow.

You need to print every step. This means EVERY step. If the maze changes in any way, PRINT!

I strongly encourage you to first create a program that simply uses 'X's and 'O's to find the path from the start to the exit. You will need this functionality anyway and that is probably the most complicated part. Once you have a program that can do that, it should be fairly easy to add the additional functionality of searching for orbs first.

I have a video in Canvas talking about how to approach this assignment. I STRONGLY encourage you to watch it as it should help you understand how to approach it.

## Grading
| Feature             | Points |
|---------------------|--------|
| Solve Maze 1        | 15     |
| Solve Maze 2        | 15     |
| Transpose Maze      | 10     |
| Used Recursion      | 15     |
| README              | 5      |
| Documentation       | 5      |
| Places + & -'s      | 10     |
| Places X & O's      | 10     |
| Prints Each Step    | 10     |
| Print Solved Result | 5      |
| **Total**           | **100**|

## Outside Resources Used

Used to figure out how to transpose a matrix:

https://www.programiz.com/c-programming/examples/matrix-transpose

## Known Problems, Issues, And/Or Errors in the Program

No known problems


