using System;
using System.Text;
using System.Collections.Generic;

public class Scripture
{
	// Define scripture variables
	private Reference _reference;
	private List<Word> _words = new List<Word>();

	// Create new scripture
	public Scripture(Reference Reference, string text)
	{
		_reference = Reference;

		string[] textArray = text.Split(' ');
		foreach (string word in textArray)
		{
			_words.Add(new Word(word));
		}
	}

	// Hide a random number of words
	public void HideRandomWords(int numberToHide)
	{
		// Declare lists
		Random random = new Random();
		HashSet<int> randomIndicies = new HashSet<int>();
		List<int> shownIndicies = new List<int>();

		// Create list of indicies of shown words
		for (int i = 0; i < _words.Count; i++)
		{
			if (!_words[i].IsHidden())
			{
				shownIndicies.Add(i);
			}
		}

		// Logic for hiding the number of words specified
		if (shownIndicies.Count >= numberToHide)
		{
			// Get random indicies of shown words
			while (randomIndicies.Count < numberToHide)
			{
				int randomIndex = random.Next(0, shownIndicies.Count);
				randomIndicies.Add(shownIndicies[randomIndex]);
				shownIndicies.RemoveAt(randomIndex);
			}

			// Hide the words at the selected indicies
			foreach (int i in randomIndicies)
			{
				_words[i].Hide();
			}
		}
		else // Hide the rest of the words
		{
			foreach (int i in shownIndicies)
			{
				_words[i].Hide();
			}
		}
	}

	// Get display text for entire scripture
	public string GetDisplayText()
	{
		// Result string
		string result = "";

		// Iterate through each word, concatenating result
		for (int i = 0; i < _words.Count; i++)
		{
			result += _words[i].GetDisplayText();
		}

		return result;
	}

	// Return whether the string is completely hidden
	public bool IsCompletelyHidden()
	{
		foreach (Word word in  _words)
		{
			if (!word.IsHidden())
			{
				return false;
			}
		}

		return true;
	}
}

