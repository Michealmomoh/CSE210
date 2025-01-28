using System;

class Program
{
    static void Main(string[] args)
    {
    
        var reference = new ScriptureReference("john", 3, 5, 6);
        var scripture = new Scripture(reference, "For God so loved the world that he gave his son");

        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.AreAllWordsHidden())
            {
                Console.WriteLine("\nAll words are hidden. Great job!");
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords();
        }
    }
}
