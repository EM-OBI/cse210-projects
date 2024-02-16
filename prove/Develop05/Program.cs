// I exceeded requirements by including an error handling blck of code that exits gracefully incase an error occurs while retrieving a file
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}