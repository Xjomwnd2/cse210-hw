using System;
using System.Collections.Generic;
using System.IO;
using SYSTEM.Text.Json;

class JournalEntry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public JournalEntry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine();
    }
}

class Journal
{
    private List<JournalEntry> _entries;
    private List<string> _prompts;

    public Journal()
    {
        _entries = new List<JournalEntry>();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What am I grateful for today?",
            "What did I learn today?",
            "What is something I want to remember from today?"
        };
    }

    public void WriteNewEntry()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];
        
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("> ");
        string response = Console.ReadLine();
        
        string date = DateTime.Now.ToShortDateString();
        JournalEntry entry = new JournalEntry(date, prompt, response);
        
        _entries.Add(entry);
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayAllEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        Console.WriteLine("Journal Entries:");
        Console.WriteLine("===============");
        
        foreach (JournalEntry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        
        try
        {
            string jsonString = JsonSerializer.Serialize(_entries);
            File.WriteAllText(filename, jsonString);
            Console.WriteLine("Journal saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        
        try
        {
            if (File.Exists(filename))
            {
                string jsonString = File.ReadAllText(filename);
                _entries = JsonSerializer.Deserialize<List<JournalEntry>>(jsonString);
                Console.WriteLine("Journal loaded successfully!");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;
        
        Console.WriteLine("Welcome to the Journal Program!");
        
        while (running)
        {
            DisplayMenu();
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayAllEntries();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            
            Console.WriteLine();
        }
    }
    
    static void DisplayMenu()
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Quit");
    }
}