using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private ScriptureReference _reference;
    private List<Word> _words;

    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

 
    public void Display()
    {
        Console.WriteLine(_reference.ToString());
        Console.WriteLine(string.Join(" ", _words.Select(word => word.Display())));
    }


    public void HideRandomWords(int count = 3)
    {
        Random random = new Random();
        var visibleWords = _words.Where(word => !word.IsHidden()).ToList();

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AreAllWordsHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}
