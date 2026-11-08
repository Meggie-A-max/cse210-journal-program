
using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SearchEntries(string keyword)
    {
        bool found = false;

        foreach (Entry entry in _entries)
        {
            if (entry._prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                entry._response.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                entry.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No matching journal entries found.");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(
                    $"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            if (parts.Length == 3)
            {
                Entry entry = new Entry(
                    parts[0], parts[1], parts[2]);

                _entries.Add(entry);
            }
        }
    }
}
