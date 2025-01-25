
using System;
class Program
{
    static void Main(string[] args)
    {
        Reference scriptureReference = new Reference("Proverbs", "3", "5-6");
        Scripture scripture = new Scripture(scriptureReference, "Trust in the lord with all thine heart and understanding; in all thy ways acknowledge him, and he shall direct thy paths.");
        ScriptureMemorizer scriptureMemorizer = new ScriptureMemorizer(scripture);

        string userInput = "";

        while (userInput != "quit" && scriptureMemorizer.hasWordsLeft() == true)
        {
            Console.Clear();
            Console.WriteLine(string.Format("{0} {1}", scriptureReference.toString(), scriptureMemorizer.toString()));
            Console.WriteLine();
            userInput = Console.ReadLine();
            scriptureMemorizer.removeWordsFromText();
        }

        Console.Clear();
        Console.WriteLine(string.Format("{0} {1}", scriptureReference.toString(), scriptureMemorizer.toString()));
        Console.WriteLine();
        Console.WriteLine("Good job!");
    }
}