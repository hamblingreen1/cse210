using System;
using System.Threading;
using System.Text;

public class Song
{
	private List<Note> _notes = new List<Note>();
	private int _totalDuration;
	private string _title;
	private string _album;
	private string _artist;
	private int _tempo;

	// Song constructor with all values filled in
	public Song(List<Note> notes, string title, int tempo, string artist, string album)
	{
		_notes = notes;
		_title = title;
		_tempo = tempo;
		_album = album;
		_artist = artist;
		_totalDuration = GetTotalDuration();
	}

	// Song constructor without album
	public Song(List<Note> notes, string title, int tempo, string artist)
	{
		_notes = notes;
		_title = title;
		_tempo = tempo;
		_artist = artist;
		_totalDuration = GetTotalDuration();
	}

	// Song constructor without album or artist
	public Song(List<Note> notes, string title, int tempo)
	{
		_notes = notes;
		_title = title;
		_tempo = tempo;
		_totalDuration = GetTotalDuration();
	}


	// Returns total duration as added up in milliseconds
	public int GetTotalDuration()
	{
		int totalDuration = 0;

		foreach (Note note in _notes)
		{
			totalDuration += note.GetDuration();
			totalDuration /= 1000;
		}

		return totalDuration;
	}

	public void Play(CancellationToken token, ManualResetEvent mre, Device _activeDevice)
	{
		while (!token.IsCancellationRequested)
		{
			// Enable play LED
			_activeDevice.SendCommand("2");

			// Play each note
			foreach (Note note in _notes)
			{
				note.Play(_activeDevice);
				mre.WaitOne();
			}

			break;
		}

		// Disable play LED
		_activeDevice.SendCommand("3");
	}

	// Print song info to terminal
	public string GetSongInfo()
	{
		if (_artist == null)
		{
			
			return $"{_title} by Unknown, from {_album}";
		}
		else if (_album == null)
		{
			
			return $"{_title} by {_artist}";
		}
		else
		{
			return $"{_title} by {_artist}, from {_album}";
		}
	}

	// Get string for saving song info
	public string GetStringRepresentation()
	{
		// Bulid lists of frequencies and durations
		StringBuilder frequencyBuilder = new StringBuilder();
		StringBuilder durationBuilder = new StringBuilder();

		foreach (Note note in _notes)
		{
			frequencyBuilder.Append(note.GetFrequency()).Append(",");
			durationBuilder.Append(note.GetDuration()).Append(",");
		}

		// Remove extra trailing commas
		string _frequencies = frequencyBuilder.ToString().TrimEnd(',');
		string _durations = durationBuilder.ToString().TrimEnd(',');

		return $"{_title},{_album},{_artist},{_tempo},\"{_frequencies}\",\"{_durations}\"";
	}

	// Get song title
	public string GetSongTitle()
	{
		return _title;
	}

	// Get list of song notes
	public List<Note> GetSongNotes()
	{
		return _notes;
	}
}

