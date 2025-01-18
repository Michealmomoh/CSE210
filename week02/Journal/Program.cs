using System;
using System.Collections.Generic;

public class Journal{

    public string _name = "";
    public List<Entry> _entries = new List<Entry>();
    
    public void Display(){

        
        Console.WriteLine($"Name: "+char.ToUpper(_name[0]) + _name.Substring(1));

        
        Console.WriteLine($"Entries:");

        
        
        foreach (Entry elementEntry in _entries)
        {
         
         elementEntry.Display();
         
        }
    }

    }