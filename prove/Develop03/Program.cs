// Author: Godwin Bassey
// I exceeded requirements by including the Stopwatch class that measures the time the user spent memorizing the verse. I also printed different exit messages depending on if the user finished the program or if the user quit midway.
using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        Reference reference = null;
        Scripture scripture = null;

        Console.Write("How many verses would you like to memorize today?: ");
        int singleOrMultiple = int.Parse(Console.ReadLine());
        //Logic to check if single or multiple verses are being memorized.
        if (singleOrMultiple == 1)
        {
            Console.Write("Book: ");
            string book = Console.ReadLine();
            Console.Write("Chapter: ");
            int chapter = int.Parse(Console.ReadLine());
            Console.Write("Verse: ");
            int verse = int.Parse(Console.ReadLine());
            Console.WriteLine("Text: ");
            string text = Console.ReadLine();

            reference = new Reference(book, chapter, verse);
            scripture = new Scripture(reference, text);

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            stopwatch.Start();
            string response;
            Console.WriteLine();
            Console.WriteLine("Press ENTER to continue or type QUIT to exit: ");
            response = Console.ReadLine();
            do
            {
                Console.Clear();
                scripture.HideRandomWords(3);
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("Press ENTER to continue or type QUIT to exit: ");
                response = Console.ReadLine();


            } while (scripture.IsCompletelyHidden() != true && response.ToLower() != "quit");
        }

        
        else if (singleOrMultiple > 1 && singleOrMultiple != 0)
        {
            Console.Write("Book: ");
            string book = Console.ReadLine();
            Console.Write("Chapter: ");
            int chapter = int.Parse(Console.ReadLine());
            Console.Write("Start Verse: ");
            int startVerse = int.Parse(Console.ReadLine());
            Console.Write("End Verse: ");
            int endVerse = int.Parse(Console.ReadLine());
            Console.WriteLine("Text: ");
            string text = Console.ReadLine();

            reference = new Reference(book, chapter, startVerse, endVerse);
            scripture = new Scripture(reference, text);

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            stopwatch.Start();
            string response;
            Console.WriteLine();
            Console.WriteLine("Press ENTER to continue or type QUIT to exit: ");
            response = Console.ReadLine();

            do
            {
                Console.Clear();
                scripture.HideRandomWords(3);
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("Press ENTER to continue or type QUIT to exit: ");
                response = Console.ReadLine();


            } while (scripture.IsCompletelyHidden() != true && response.ToLower() != "quit");
        }

        Console.Clear();
        stopwatch.Stop();
        TimeSpan elapsedTime = stopwatch.Elapsed;
        if (scripture.IsCompletelyHidden())
        {
            int hour = elapsedTime.Hours;
            int minute = elapsedTime.Minutes;
            int second = elapsedTime.Seconds;

            Console.WriteLine($"Congratulations! You memorized the scripture in: {hour} Hours, {minute} Minutes and {second} Seconds.");
        }
        else{
            Console.WriteLine($"You did well. Try and complete it next time!");
        }
        
    }
}