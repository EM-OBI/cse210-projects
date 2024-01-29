using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Bassey", "Trig");
        MathAssignment mathAssignment = new MathAssignment("Bassey", "Trig", "Section 7.3", "Problems 8-19");
        WritingAssignment writingAssignment = new WritingAssignment("Bassey", "Mental Health", "A Great Depression");
        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}