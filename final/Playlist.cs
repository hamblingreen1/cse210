using System;

public class Playlist
{
	private List<Song> _songs = new List<Song>();
	private int _totalDuration;
	private string _title;

	// Song constructor without album or artist
	public Playlist(List<Song> songs, string title)
	{
		_songs = songs;
		_title = title;
		_totalDuration = GetTotalDuration();
	}


	public int GetTotalDuration()
	{
		// returns total duration as added up in milliseconds
		return 0;
	}

	// Get playlist title
	public string GetPlaylistTitle()
	{
		return _title;
	}
}

