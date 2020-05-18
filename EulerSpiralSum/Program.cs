using System;

namespace EulerSpiralSum
{
    class Program
    {//the purpose of this program is to familiarize myself with the tools of C#. The following program is written procedurally, as that is what I am familiar with, but 
        static void Main(string[] args)
        {
            Console.WriteLine("This program will create a spiraled two dimensional matrix, and then sum the numbers along the diagonals of that matrix.");
            Console.WriteLine("A form of this problem can be found at ProjectEuler.net problem 28, but mine is more robust.");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("What odd n x n matrix do you want us to print? Please enter an odd integer n:");
            string input = Console.ReadLine();
            CheckInput(input);

        }

        static void CheckInput(string matrixSizeString)
        {
            int matrixSizeInt;
            if (int.TryParse(matrixSizeString, out matrixSizeInt))
            {
                if (matrixSizeInt % 2 != 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Thank you for following the instructions.");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    CreateMatrix(matrixSizeInt);
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("You did not follow the instructions. Please enter an odd integer n:");
                    string input = Console.ReadLine();
                    CheckInput(input);
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("You did not follow the instructions. Please enter an odd integer n:");
                string input = Console.ReadLine();
                CheckInput(input);
            }
        }

        static void CreateMatrix(int n)
        {
            int[,] array = new int[n, n];                                         //creates an n x n 2d matrix 
            int center = n / 2;
            int currentx = center;
            int currenty = center;
            string[] direction = { "right", "down", "left", "up" };
            int currentDirection = 0;
            int hopsNeeded = 1;
            int hopsDone = 0;
            int directionChanged = 0;
            int i = 1;
            int totalHops = n * n;

            array[currentx, currenty] = 1;                                          //we always start at 1 here 

            for (i = 1; i < totalHops; i++)                                           //while we are less than the total matrix, we must keep hopping
            {

                if (hopsDone == hopsNeeded)
                {
                    //change direction, after up we go to right
                    currentDirection = (currentDirection + 1);
                    if (currentDirection > 3)
                        currentDirection = 0;
                    hopsDone = 0;
                    directionChanged += 1;
                }

                //every time we change direction twice, we must hop in the next direction one more time
                if (directionChanged == 2)
                {
                    hopsNeeded += 1;
                    directionChanged = 0;
                }

                switch (direction[currentDirection])
                {
                    case "right":   //right is down
                        currenty = currenty + 1;
                        array[currentx, currenty] = i + 1;
                        break;
                    case "down":    //down is left
                        currentx = currentx + 1;
                        array[currentx, currenty] = i + 1;
                        break;
                    case "left":  //left is up
                        currenty = currenty - 1;
                        array[currentx, currenty] = i + 1;
                        break;
                    case "up":  //up is right
                        currentx = currentx - 1;
                        array[currentx, currenty] = i + 1;
                        break;
                }
                //Console.WriteLine("Current Hop: " + i);
                //Console.WriteLine("Hop Direction: " + direction[currentDirection]);
                //Console.WriteLine("Coordinate: (" + currentx + "," + currenty + ")");
                //Console.WriteLine("Inserted Value: " + array[currentx, currenty]);
                //Console.WriteLine("");
                hopsDone += 1;
            }
            printMatrix(array, n);
            calculateDiagonals(array, n);
        }

        static void printMatrix(int[,] matrix, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write("   ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        static void calculateDiagonals(int[,] matrix, int size)
        {
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                //don't add the center value twice
                if (i != size - 1 - i)
                {
                    sum += matrix[i, i];
                    sum += matrix[i, (size - 1) - i];
                }
                else
                    sum += 1;
            }

            Console.WriteLine("The sum of the diagonals is: " + sum);
            string input = Console.ReadLine();
        }
    }
}
