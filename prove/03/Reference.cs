using System;

public class Reference
{
	// Define variables to hold scripture info
	private string _book;
	private int _chapter;
	private int _verse;
	private int _endVerse;

	// Single-verse reference
	public Reference(string book, int chapter, int verse)
	{
		_book = book;
		_chapter = chapter;
		_verse = verse;
	}

	// Multi-verse reference
	public Reference(string book, int chapter, int verse, int endVerse)
	{
		_book = book;
		_chapter = chapter;
		_verse = verse;
		_endVerse = endVerse;
	}

	// Get scripture reference string
	public string GetDisplayText()
	{
		// If end verse exists, include it in the display text. Otherwise, don't
		if (_endVerse != 0)
			return _book + " " + _chapter + ":" + _verse + "-" + _endVerse;
		else
			return _book + " " + _chapter + ":" + _verse;
	}
}