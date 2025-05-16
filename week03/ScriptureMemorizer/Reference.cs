using System;

class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndVerse { get; private set; }

    public Reference(string referenceText)
    {
        var parts = referenceText.Split(' ', 2);
        if (parts.Length < 2)
            throw new ArgumentException("Invalid reference format.");

        Book = parts[0];

        string chapterAndVerses = parts[1];
        var chapterParts = chapterAndVerses.Split(':');

        Chapter = int.Parse(chapterParts[0]);

        if (chapterParts.Length == 2)
        {
            var verseParts = chapterParts[1].Split('-');
            StartVerse = int.Parse(verseParts[0]);
            if (verseParts.Length == 2)
            {
                EndVerse = int.Parse(verseParts[1]);
            }
        }
        else
        {
            StartVerse = 1;
        }
    }

    public string GetDisplayText()
    {
        if (EndVerse.HasValue)
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse.Value}";
        }
        else
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
    }
}