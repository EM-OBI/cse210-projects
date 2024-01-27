public class Scripture
{
    private Reference _reference; 
    private List<Word> _words;
    private string _verse;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] splitText = text.Split(new char[] {' '});
        foreach (string word in splitText)
        {
            Word listWord = new Word(word);
            _words.Add(listWord);
        }

    }

    public void HideRandomWords(int numberToHide)
    {
        Random randomGen = new Random();
        // numberToHide = randomGen.Next(0, _words.Count);

        for (int i = 0; i < numberToHide; i++)
        {
            int indexToHide = randomGen.Next(0, _words.Count);

            while (_words[indexToHide].IsHidden())
            {
                if (IsCompletelyHidden())
                {
                    break;
                }
                else
                {
                    indexToHide = randomGen.Next(0, _words.Count);
                }
            }

            _words[indexToHide].Hide();
        }
    }

    public string GetDisplayText()
    {
        List<string> sentence = new List<string>();
        foreach (Word word in _words)
        {
            sentence.Add(word.GetDisplayText());
        }
        _verse = string.Join(" ", sentence);
        return $"{_reference.GetDisplayText()}: {_verse}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}