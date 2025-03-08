using System;
using System.Collections.Generic;
using System.Linq;

class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // Constructor for a single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    // Constructor for a verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Get the formatted reference as a string
    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Hide the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Show the word
    public void Show()
    {
        _isHidden = false;
    }

    // Return the word or underscores if hidden
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }

    // Check if the word is currently hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Get the actual text of the word
    public string GetText()
    {
        return _text;
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        // Split the text into words
        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    // Display the complete scripture
    public void DisplayScripture()
    {
        Console.Clear();
        Console.WriteLine($"{_reference.GetDisplayText()} - ");
        
        for (int i = 0; i < _words.Count; i++)
        {
            Console.Write(_words[i].GetDisplayText());
            
            // Add a space unless it's the last word
            if (i < _words.Count - 1)
            {
                Console.Write(" ");
            }
        }
        
        Console.WriteLine("\n");
        Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
    }

    // Hide a random selection of words
    public bool HideRandomWords(int numberToHide)
    {
        // Find words that are not yet hidden
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        // If all words are hidden, return false
        if (visibleWords.Count == 0)
        {
            return false;
        }

        // Determine how many words to hide (don't try to hide more than available)
        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

        // Hide the selected number of random words
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }

        return true;
    }

    // Check if all words in the scripture are hidden
    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Scripture Memorizer Program");
        Console.WriteLine("==========================");
        
        // Create a scripture
        Reference reference = new Reference("John", 3, 16);
        string scriptureText = "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        Scripture scripture = new Scripture(reference, scriptureText);

        string input = "";
        
        // Main program loop
        while (input.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            // Display the scripture
            scripture.DisplayScripture();
            
            // Wait for user input
            input = Console.ReadLine();
            
            // If not quitting, hide more words
            if (input.ToLower() != "quit")
            {
                // Hide 3 words at a time
                scripture.HideRandomWords(3);
            }
        }
        
        // Final message
        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine("Congratulations! You've completed the memorization exercise.");
            Console.WriteLine($"{reference.GetDisplayText()} - {scriptureText}");
        }
        
        Console.WriteLine("\nThank you for using the Scripture Memorizer!");
    }
}