using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        Console.WriteLine($"\nTotal Entries: {_entries.Count}");
        Console.WriteLine();
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetSaveString());
            }
        }
    }

    public void LoadFromFile(string file)
    {
        if (!System.IO.File.Exists(file))
        {
            Console.WriteLine("File not found. Please check the file name and try again.");
            return;
        }
        _entries = new List<Entry>();
        string[] lines = System.IO.File.ReadAllLines(file);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            string date = parts[0];
            string promptText = parts[1];
            string entryText = parts[2];

            Entry entry = new Entry(date, promptText, entryText);
            _entries.Add(entry);
        }
    }
}