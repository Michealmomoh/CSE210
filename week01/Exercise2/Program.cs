using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.Write("ENTER YOUR SCORE ");
        string score = Console.ReadLine();
        int number = int.Parse(score);
        if (number >= 90){
            string letter = "A";
            Console.WriteLine($"your grade is {letter} you passed ");
        }
        else if (number >= 80){
            string letter = "B";
            Console.WriteLine($"grade is {letter} you passed ");
        }
        else if (number >= 70){
            string letter = "C";
            Console.WriteLine($"your garede is {letter} you passed ");
        }
        else if (number >= 60 ){
            string letter = "D";
            Console.WriteLine($"YOUR grade is {letter} you passed ");
        }
        else if (number < 60){
            string letter = "F";
            Console.WriteLine($"you grade is {letter}ss ");

        }
        if (number >= 90){
            Console.WriteLine("congratulation you passed ");
        }
        else if (number <= 60){
            Console.WriteLine("BTEER LUCKY NEXT TIME ");
        }
        

        
    }
}