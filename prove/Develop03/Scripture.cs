public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] wordArray = text.Split(' ');
        foreach (var word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int wordsHidden = 0;
        foreach (var word in _words)
        {
            if (!word.IsHidden && random.Next(2) == 0)
            {
                word.HideWord();
                wordsHidden++;
                if (wordsHidden >= numberToHide)
                {
                    break;
                }
            }
        }
    }

    public string GetDisplayText()
    {
        string displayText = $"{_reference.GetReferenceString()}: ";
        foreach (var word in _words)
        {
            displayText += word.IsHidden ? "***** " : word.Text + " ";
        }
        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden)
            {
                return false;
            }
        }
        return true;
    }
}