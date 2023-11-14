using System;

public class Word
{
	// Define word attributes
	private string _text;
	private bool _isHidden;

	// Create new word
	public Word(string text)
	{
		_text = text;
		_isHidden = false;
	}

	// Hide word
	public void Hide()
	{
		_isHidden = true;
	}

	// Show word
	public void show()
	{
		_isHidden = false;
	}

	// Return whether word is hidden or not
	public bool IsHidden()
	{
		return _isHidden;
	}

	// Return string to display word
	public string GetDisplayText()
	{
		if (_isHidden == false)
		{
			return _text + " ";
		}
		else 
		{
			string hiddenText = new string('_', _text.Length) + " ";
			return hiddenText;
		}
	}
}
