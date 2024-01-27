using System.Runtime.CompilerServices;

public class Word
{
    private string _text;
    private bool _isHidden = false;

    public Word(string text)
    {
        _text = text;
    }

    public void Hide()
    {
      if (!_isHidden)
      {
        char[] hidden = new char[_text.Length];
        for (int i = 0; i < _text.Length; i++)
        {
            if (char.IsLetter(_text[i]))
            {
                hidden[i] = '_';
            }
            else
            {
                hidden[i] = _text[i];
            }
        }
        _isHidden = true;
        _text = new string(hidden);
      }
    }
    public void Show()
    {
      if (_isHidden)
      {
        char[] text = new char[_text.Length];
        for (int i = 0; i < _text.Length; i++)
        {
            text[i] = _text[i];
        }
        _isHidden = false;
        _text = new string(text); 
      }
    }

    public bool IsHidden()
    {
        return _isHidden;
    }
    public string GetDisplayText()
    {
        return _text;
    }

}