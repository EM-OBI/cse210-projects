using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squareNumber = SquareNumber(userNumber);
        DisplayResult(userName, squareNumber);

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to my program!");
        }

         static string PromptUserName()
         {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();

            return name;
         }

         static int PromptUserNumber()
         {
            Console.Write("Please enter your favorite number: ");
            int favNumber = int.Parse(Console.ReadLine());

            return favNumber;
         }

        static int SquareNumber(int number)
        {
            int squaredNumber = number * number;
            return squaredNumber;
        }

        static void DisplayResult(string name, int squaredNumber)
        {
            Console.WriteLine($"Hi {name}, the square of your favorite number is {squaredNumber}.");
        }

    }
}