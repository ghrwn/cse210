using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] wordTexts = text.Split(' ');

        foreach (var w in wordTexts)
        {
            _words.Add(new Word(w));
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + "\n";

        foreach (var word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText.TrimEnd();
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();

        int totalWords = _words.Count;
        for (int i = 0; i < count; i++)
        {
            int index = random.Next(totalWords);
            _words[index].Hide();
        }
    }

    public bool AllWordsHidden()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }
}