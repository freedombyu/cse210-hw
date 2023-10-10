public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void HideWord()
    {
        IsHidden = true;
    }
}
// In this implementation:

//The Scripture class encapsulates the scripture text, the reference, and methods to hide words, check if all words are hidden, and get the display text.
//The Reference class encapsulates the scripture reference and provides a method to get the formatted reference string.
//The Word class represents a word in the scripture, storing its text and a boolean indicating whether it's hidden or not.
//This setup adheres to the principles of encapsulation and provides a clean separation of concerns between the classes.








