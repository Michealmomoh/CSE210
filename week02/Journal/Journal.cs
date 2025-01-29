using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> Entries { get; private set; }

    public Journal()
    {
        Entries = new List<Entry>();
    }

    public void AddEntry(string prompt, string response)
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        Entries.Add(new Entry(date, prompt, response));
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in Entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in Entries)
            {
                writer.WriteLine(entry.ToString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        Entries.Clear();
        foreach (string line in File.ReadAllLines(filename))
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entries.Add(new Entry(parts[0].Trim(), parts[1].Trim(), parts[2].Trim()));
            }
        }
    }
}
