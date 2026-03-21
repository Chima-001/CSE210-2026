using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference Reference, string text)
    {
        _reference = Reference;
        _words = [];
        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();

        List<Word> notHidden = [];

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                notHidden.Add(word);
            }
        }

        if (notHidden.Count == 0)
        {
            return;
        }

        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(notHidden.Count);
            notHidden[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        List<string> wordList = [];
        foreach (Word word in _words)
        {
            //Word displayText = word.GetDisplayText()
            wordList.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()}\n{string.Join(" ", wordList)}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}