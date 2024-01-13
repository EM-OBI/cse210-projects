using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
       List<int> numbers = new List<int>();
       int newNumber = 1;
       float total = 0;
       int largest = 0;
       while (newNumber != 0)
       {
        Console.Write("Enter number to include in list: ");
        newNumber = int.Parse(Console.ReadLine());
        if (newNumber != 0)
        {
            numbers.Add(newNumber);
        }
       }
        foreach (int number in numbers)
        {
            total += number;
            if (number > largest)
            {
                largest = number;
            }
        }
       
        int numNumbers = numbers.Count;
        float average = total / numNumbers;

        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}