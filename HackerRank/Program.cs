using System;
using System.Linq;

class Solution
{
    static void Main(string[] args)
    {
        args = new[] { "4 4 1", "1 2 3 4", "5 6 7 8", "9 10 11 12", "13 14 15 16" };
        var firstInput = args[0].Split(' ').Select(num => int.Parse(num.ToString())).ToArray();
        var numberOfRows = firstInput[0];
        var numberOfColumns = firstInput[1];
        var numberOfRotation = firstInput[2];
        var matrix = new int[numberOfRows, numberOfColumns];
        for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
        {
            var line = args[rowIndex + 1].Split(' ').Select(num => int.Parse(num.ToString())).ToArray();
            for (var columnIndex = 0; columnIndex < numberOfColumns; columnIndex++)
            {
                matrix[rowIndex, columnIndex] = line[columnIndex];
            }
        }

        var swappedMatrix = matrix.Clone() as int[,];
        for (var rotation = 0; rotation < numberOfRotation; rotation++)
        {
            for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < numberOfColumns; columnIndex++)
                {
                    if (rowIndex == 0)
                    {
                        if (columnIndex == 0)
                        {
                            swappedMatrix[rowIndex, columnIndex] = matrix[rowIndex, columnIndex + 1];
                        }
                        else if (columnIndex < numberOfColumns - 1)
                        {
                            swappedMatrix[rowIndex, columnIndex] = matrix[rowIndex, columnIndex + 1];
                        }
                        else if (columnIndex == numberOfColumns - 1)
                        {
                            swappedMatrix[rowIndex, columnIndex] = matrix[rowIndex + 1, columnIndex];
                        }
                    }
                    else if (rowIndex < numberOfRows - 1)
                    {
                        if (columnIndex == 0)
                        {
                            swappedMatrix[rowIndex, columnIndex] = matrix[rowIndex - 1, columnIndex];
                        }
                        else if (columnIndex < numberOfColumns - 1)
                        {
                            if (rowIndex + 1 == numberOfRows - 1)
                            {
                                if (columnIndex + 1 == numberOfColumns - 1)
                                {
                                    swappedMatrix[rowIndex, columnIndex] = matrix[rowIndex, columnIndex - 1];
                                }
                                else
                                {
                                    swappedMatrix[rowIndex, columnIndex] = matrix[rowIndex - 1, columnIndex];
                                }
                            }
                            else if (columnIndex + 1 == numberOfColumns - 1)
                            {
                                swappedMatrix[rowIndex, columnIndex] = matrix[rowIndex + 1, columnIndex];
                            }
                            else
                            {
                                if(rowIndex - 1 != 0)
                                {
                                    swappedMatrix[rowIndex, columnIndex] = matrix[rowIndex - 1, columnIndex];
                                }
                                else
                                {
                                    swappedMatrix[rowIndex, columnIndex] = matrix[rowIndex, columnIndex + 1];
                                }
                            }
                        }
                        else if (columnIndex == numberOfColumns - 1)
                        {
                            swappedMatrix[rowIndex, columnIndex] = matrix[rowIndex + 1, columnIndex];
                        }
                    }
                    else if (rowIndex == numberOfRows - 1)
                    {
                        if (columnIndex == 0)
                        {
                            swappedMatrix[rowIndex, columnIndex] = matrix[rowIndex - 1, columnIndex];
                        }
                        else if (columnIndex < numberOfColumns - 1)
                        {
                            swappedMatrix[rowIndex, columnIndex] = matrix[rowIndex, columnIndex - 1];
                        }
                        else if (columnIndex == numberOfColumns - 1)
                        {
                            swappedMatrix[rowIndex, columnIndex] = matrix[rowIndex, columnIndex - 1];
                        }
                    }
                }
            }
            matrix = swappedMatrix.Clone() as int[,];
        }
        for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
        {
            var output = string.Empty;
            for (var columnIndex = 0; columnIndex < numberOfColumns; columnIndex++)
            {
                output += swappedMatrix[rowIndex, columnIndex].ToString() + ' ';
            }
            Console.WriteLine(output.Trim());
        }
        Console.ReadLine();
    }
}