using System;

public class Song
{
	private List<Note> _notes = new List<Note>();
	private int _totalDuration;
	private string _title;
	private string _album;
	private string _artist;

	// Song constructor with all values filled in
	public Song(List<Note> notes, string title, string album, string artist)
	{
		_notes = notes;
		_title = title;
		_album = album;
		_artist = artist;
		_totalDuration = GetTotalDuration();
	}

	// Song constructor without album
	public Song(List<Note> notes, string title, string artist)
	{
		_notes = notes;
		_title = title;
		_artist = artist;
		_totalDuration = GetTotalDuration();
	}

	// Song constructor without album or artist
	public Song(List<Note> notes, string title)
	{
		_notes = notes;
		_title = title;
		_totalDuration = GetTotalDuration();
	}


	public int GetTotalDuration()
	{
		// returns total duration as added up in milliseconds
		return 0;
	}

	// Get song title
	public string GetSongTitle()
	{
		return _title;
	}
}

