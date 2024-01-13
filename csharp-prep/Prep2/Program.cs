using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your score: ");
        string gradeStr = Console.ReadLine();
        int gradeInt = int.Parse(gradeStr);
        string gradeValue = "";
        string sign = "";

        if (gradeInt % 10 >= 7)
        {
            sign = "+";
        }
        else if (gradeInt % 10 < 3)
        {
            sign = "-";
        }
    
        if (gradeInt >= 90) 
        {
            gradeValue = "A";
        }
        else if (gradeInt >= 80) 
        {
            gradeValue = "B";
        }
        else if (gradeInt >= 70) 
        {
            gradeValue = "C";
        }
        else if (gradeInt >= 60) 
        {
            gradeValue = "D";
        }
        else 
        {
            gradeValue = "F";
        }

        if (gradeValue == "F" )
            {
                Console.WriteLine(gradeValue); 
            }
        else if (gradeInt % 10 >= 7 && gradeValue == "A")
            {
                Console.WriteLine(gradeValue);
            }
        else 
        {
            Console.WriteLine($"{gradeValue}{sign}");
        }

        if (gradeInt >= 70)
        {
            Console.WriteLine("Congratualtions! You Passed!");
        }
        else 
        {
            Console.WriteLine("You didn't pass this time. Do better next time!");
        }
    }
}