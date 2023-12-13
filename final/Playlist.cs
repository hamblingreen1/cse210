using System;
using System.Text;

public class Playlist
{
	private List<Song> _songs = new List<Song>();
	private CancellationTokenSource _cts;
	private ManualResetEvent _mre;
	private int _totalDuration;
	private string _title;

	// Song constructor without album or artist
	public Playlist(List<Song> songs, string title)
	{
		_songs = songs;
		_title = title;
		_totalDuration = GetTotalDuration();
		_cts = new CancellationTokenSource();
		_mre = new ManualResetEvent(false);
	}

	public void Play(Device _activeDevice)
	{
		foreach (Song song in _songs)
		{
			// Play song
			song.Play(_cts.Token, _mre, _activeDevice);

			// 3 second pause between songs
			Thread.Sleep(3000);
		}
	}

	// Returns total duration as added up in milliseconds
	public int GetTotalDuration()
	{
		int totalDuration = 0;

		// returns total duration as added up in milliseconds
		foreach (Song song in _songs)
		{
			totalDuration += song.GetTotalDuration();
		}

		return totalDuration;
	}

	// Print playlist info to terminal
	public string GetPlaylistInfo()
	{
		List<string> songTitles = new List<string>();

		foreach (Song song in _songs)
		{
			songTitles.Append(song.GetSongTitle());
		}

		string playlistSongs = string.Join(", ", _songs);

		return$"{_title} : {_totalDuration}, {playlistSongs}";
	}

	// Get string for playlist song info
	public string GetStringRepresentation()
	{
		// Build list of songs
		StringBuilder songBuilder = new StringBuilder();

		foreach (Song song in _songs)
		{
			songBuilder.Append(song.GetSongTitle()).Append(",");
		}

		// Remove extra trailing commas
		string songsString = songBuilder.ToString().TrimEnd(',');

		return $"{_title},\"{songsString}\"";
	}

	// Get playlist title
	public string GetPlaylistTitle()
	{
		return _title;
	}

	public List<Song> GetPlaylistSongs()
	{
		return _songs;
	}
}

