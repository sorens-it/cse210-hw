using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create a scripture
        var scripture = new Scripture(new Reference("John", 11, 35), "Jesus wept.");

        // Run the program
        RunProgram(scripture);

        Console.WriteLine("Program ended.");
    }

    static void RunProgram(Scripture scripture)
    {
        while (!scripture.IsCompletelyHidden())
        {
            // Clear console
            Console.Clear();

            // Display scripture with hidden words
            Console.WriteLine(scripture.GetDisplayText());

            // Prompt user to continue or quit
            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;

            // Hide a random number of words (1-4)
            Random rand = new Random();
            int numToHide = rand.Next(1, 5);
            scripture.HideRandomWords(numToHide);
        }
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        // Split text into words and initialize Word objects
        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        // Get visible words
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        if (visibleWords.Count == 0)
        {
            return;
        }

        // Hide a random number of words
        Random rand = new Random();
        int numToHide = Math.Min(numberToHide, visibleWords.Count);
        for (int i = 0; i < numToHide; i++)
        {
            int index = rand.Next(0, visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        // Reconstruct text with hidden words
        string result = "";
        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()}: {result}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}

class Word
{
    private string _text;
    private bool _isHidden = false;

    public Word(string text)
    {
        _text = text;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    // Constructor for single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    // Constructor for verse range
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_endVerse == 0)
            return $"{_book} {_chapter}:{_verse}";
        else
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}
