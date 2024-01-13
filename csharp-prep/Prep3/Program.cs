using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {

        String yesOrNo = "yes";

        while (yesOrNo.ToLower() == "yes")
        {
            Random randomGenerator = new Random();
            int intMagicNumber = randomGenerator.Next(1, 101);
            int numGuesses = 0;
            int intPlayerGuess = 0;
            while (intMagicNumber != intPlayerGuess)
        
            {
                numGuesses += 1;
                Console.Write("What is your guess? (1-100) ");
                intPlayerGuess = int.Parse(Console.ReadLine());

                if (intPlayerGuess > intMagicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (intPlayerGuess < intMagicNumber)
                {
                    Console.WriteLine("Higher");
                }
                
            }
            Console.WriteLine($"Correct! It took you {numGuesses} guesses!");
            Console.Write("Do you want to play again? (yes or no) ");
            yesOrNo = Console.ReadLine();
        }

        Console.WriteLine("Thanks for playing!");
    }
}