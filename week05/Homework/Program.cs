using System;

class Program
{
    static void Main(string[] args)
    {
        // TEST BASE CLASS
        Assignment a1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        Console.WriteLine();

        // TEST MATH ASSIGNMENT
        MathAssignment math = new MathAssignment(
            "Roberto Rodriguez",
            "Fractions",
            "7.3",
            "8-19"
        );

        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());

        Console.WriteLine();

        // TEST WRITING ASSIGNMENT
        WritingAssignment writing = new WritingAssignment(
            "Mary Waters",
            "European History",
            "The Causes of World War II"
        );

        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
    }
}