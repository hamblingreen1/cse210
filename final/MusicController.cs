using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Linq;
using Microsoft.VisualBasic;

public class MusicController
{
	private DeviceController _deviceController;
	private Device _activeDevice;
	private CancellationTokenSource _cts;
	private ManualResetEvent _mre;
	private List<Playlist> _playlists;
	private List<Song> _songs;
	private bool _isLooping;
	private bool _isPaused;
	private Song _currentlyPlaying;
	private Task _playingTask;

	// Music controller constructor
	public MusicController(DeviceController deviceController)
	{
		// Define the device controller
		_deviceController = deviceController;

		// Set active device to that of the device controller
		_activeDevice = deviceController.GetActiveDevice();

		// Create lists
		_playlists =  new List<Playlist>();
		_songs = new List<Song>();

		// Create new cancellation token source
		_cts = new CancellationTokenSource();

		// Create manual reset event for pausing
		_mre = new ManualResetEvent(false);

		// Set loop value to false initially
		_isLooping = false;

		// Set pause value to false initially
		_isPaused = false;
	}

	public async void DisplayMenu()
	{
		while (true)
		{
			// Print menu
			// Console.Clear();
			Console.WriteLine("Music Controller:");
			Console.WriteLine("    0. Switch to device controller");
			Console.WriteLine("    1. Play song");
			Console.WriteLine("    2. Queue playlist");
			Console.WriteLine("    3. Toggle playback");
			Console.WriteLine("    5. Loop current song");
			Console.WriteLine("    6. Write new song");
			Console.WriteLine("    7. Curate new playlist");
			Console.WriteLine("    8. Delete song");
			Console.WriteLine("    9. Delete playlist");
			Console.WriteLine("   10. Save all data");
			Console.WriteLine("   11. Load data from file");
			Console.WriteLine("   12. Display songs and playlists");
			Console.WriteLine("   13. Quit");

			// Receive user input
			Console.Write("Select a choice from the menu: ");
			int choice = int.Parse(Console.ReadLine());
			Console.WriteLine();

			// Call option's function
			switch (choice)
			{
				case 0:
					_deviceController.DisplayMenu();
					break;
				case 1: Play();		break;
				case 2: QueuePlaylist();	break;
				case 3: TogglePlayback();	break;
				case 5: Loop();		break;
				case 6: NewSong();	break;
				case 7: NewPlaylist();	break;
				case 8: DeleteSong();	break;
				case 9: DeletePlaylist(); break;
				case 10:
					SaveSongs();
					SavePlaylists();
					break;
				case 11:
					LoadSongs();
					LoadPlaylists();
					break;
				case 12:
					DisplaySongs();
					DisplayPlaylists();
					break;
				case 13:
					Environment.Exit(0);
					break;
				default:
					Console.WriteLine("Invalid choice, Please try again");
					break;
			}
		}
	}

	// Play music dialog
	public void Play()
	{
		// Get list of songs
		DisplaySongs();

		// Search for song
		Song foundSong = SearchForSong();

		// Play song
		_mre.Set();
		_playingTask = Task.Run(() => foundSong.Play(_cts.Token, _mre, _activeDevice));
		_currentlyPlaying = foundSong;
	}

	// Play playlist dialog
	public void QueuePlaylist()
	{
		// Get list of playlists
		DisplayPlaylists();

		// Search for playlist
		Playlist foundPlaylist = SearchForPlaylist();

		// Play playlist
		_mre.Set();
		_playingTask = Task.Run(() => foundPlaylist.Play(_activeDevice));
	}

	public void TogglePlayback()
	{
		_isPaused = !_isPaused;

		// Pause music dialog
		if (!_isPaused)
			_mre.Reset();
		else
			_mre.Set();
	}

	// Loop current song 
	public async Task Loop() 
	{ 
		_isLooping = !_isLooping;

		if (_isLooping)
			_activeDevice.SendCommand("6");
		else
			_activeDevice.SendCommand("7");

		// Play in loop until disabled
		while (_isLooping == true)
		{ 
			if (_playingTask != null && !_playingTask.IsCompleted)
			{
				await _playingTask; // Wait for current task to complete
			}

			_playingTask = Task.Run(() => _currentlyPlaying.Play(_cts.Token, _mre, _activeDevice));
			await Task.Yield();
		} 
	}

	// Create new song
	public void NewSong()
	{
		string title = "";
		string album = "";
		string artist = "";
		string input = "";
		int tempo = 0;

		// Input title
		Console.WriteLine("What is the title of your song?");
		Console.Write("> ");
		title = Console.ReadLine();

		// Input album
		Console.WriteLine("What album is it from?");
		Console.Write("> ");
		input = Console.ReadLine();
		if (!string.IsNullOrEmpty(input))
			album = input;

		// Input artist
		Console.WriteLine("Who is the song by?");
		Console.Write("> ");
		input = Console.ReadLine();
		if (!string.IsNullOrEmpty(input))
			artist = input;

		// Input tempo
		Console.WriteLine("What is the tempo in BPM? (e.g. 120)");
		Console.Write("> ");
		tempo = int.Parse(Console.ReadLine());

		// Input notes
		Console.WriteLine("Input a list of notes separated by a space,");
		Console.WriteLine("typing 'S' for silence. (e.g. C D E F G A B C)");
		Console.Write("> ");
		string noteString = Console.ReadLine();

		// Split note input into list of strings
		List<string> noteLetters = new List<string>(noteString.Split(' '));

		// Input octaves
		Console.WriteLine("Input a list of how many octaves above or below");
		Console.WriteLine("middle C those notes are. (e.g. 0 0 0 0 0 0 0 1)");
		Console.Write("> ");
		string octaveString = Console.ReadLine();

		// Split octave input into list of strings, then convert to ints
		List<string> octaveStrings = new List<string>(octaveString.Split(' '));
		List<int> octaves = new List<int>(); 

		foreach (string str in octaveStrings)
		{
			int octave = int.Parse(str);
			octaves.Add(octave);
		}

		// Input beats
		Console.WriteLine("Input a list of beats separated by a space");
		Console.WriteLine("(e.g. 4 2 1 2 4 2 1 2)");
		Console.Write("> ");
		string beatString = Console.ReadLine();

		// Split beat input into list of strings, then convert to ints
		List<string> beatStrings = new List<string>(beatString.Split(' '));
		List<int> beats = beatStrings.ConvertAll(int.Parse);

		// Convert each beat to a duration in milliseconds
		float secondsPerBeat = 60f / tempo;
		int millisecondsPerBeat = (int) (secondsPerBeat * 1000);

		for (int i = 0; i < beats.Count; i++)
		{
			beats[i] = beats[i] * millisecondsPerBeat;
		}

		// Create empty list of notes
		List<Note> notes = new List<Note>();

		// Populate notes list with input
		for (int i = 0; i < noteLetters.Count; i++)
		{
			string note = noteLetters[i];
			int octave = octaves[i];
			int duration = beats[i];
			notes.Add(new Note(note, octave, duration));
		}

		// Create new song
		Song newSong = new Song(notes, title, tempo, artist, album);

		// Add song to song list
		_songs.Add(newSong);
	}

	// Curate new playlist
	public void NewPlaylist()
	{
		// Input title
		Console.WriteLine("What is the title of your playlist?");
		Console.Write("> ");
		string title = Console.ReadLine();

		// Display song info
		DisplaySongs();

		// Create song list
		List<Song> songs = new List<Song>();
		string searchQuery = "search";

		// Prompt user for song input
		Console.WriteLine("Enter titles of songs to select, and a blank line to exit:");
		searchQuery = Console.ReadLine();

		while (searchQuery != "")
		{
			Console.Write("> ");
			searchQuery = Console.ReadLine();

			// Search for the song in the list
			Song foundSong = _songs.Find(song => song.GetSongTitle().Equals(searchQuery));

			// Delete the song if found
			if (foundSong != null)
				songs.Add(foundSong);
			else
				break;
		}
		
		// Create new playlist
		Playlist newPlaylist = new Playlist(songs, title);
		_playlists.Add(newPlaylist);
	}

	// Delete song
	public void DeleteSong()
	{
		DisplaySongs(); // Display list of songs

		Song foundSong = SearchForSong(); // Search for song

		// Remove song from list
		_songs.Remove(foundSong);
		Console.WriteLine("Song deleted successfully.");
		Console.WriteLine();
	}

	// Delete playlist
	public void DeletePlaylist()
	{
		DisplayPlaylists(); // Display list of songs

		Playlist foundPlaylist = SearchForPlaylist(); // Search for song

		// Remove song from list
		_playlists.Remove(foundPlaylist);
		Console.WriteLine("Playlist deleted successfully.");
		Console.WriteLine();
	}

	// Save all playlists and songs to a file
	public void SaveSongs()
	{
		// Retrieve filename
		Console.WriteLine("What is the filename to save your songs?");
		Console.Write("> ");
		string filename = Console.ReadLine();

		using (StreamWriter outputFile = new StreamWriter(filename))
		{
			// Write songs data
			outputFile.WriteLine("Title,Album,Artist,Tempo,Notes");

			foreach (Song song in _songs)
			{
				outputFile.WriteLine(song.GetStringRepresentation());
			}

			outputFile.WriteLine();
		}
	}

	// Save all playlists to a file
	public void SavePlaylists()
	{
		// Retrieve filename
		Console.WriteLine("What is the filename to save your playlists?");
		Console.Write("> ");
		string filename = Console.ReadLine();

		using (StreamWriter outputFile = new StreamWriter(filename))
		{
			// Write playlists data
			outputFile.WriteLine("Title,Songs");

			foreach (Playlist playlist in _playlists)
			{
				outputFile.WriteLine(playlist.GetStringRepresentation());
			}

			outputFile.WriteLine();
		}
	}

	// Load songs from a file
	public void LoadSongs()
	{
		Console.WriteLine("What is the filename that has your songs saved?");
		Console.Write("> ");
		string filename = Console.ReadLine();

		if (File.Exists(filename))
		{
			string line;

			using (StreamReader inputFile = new StreamReader(filename))
			{
				// Skip first line of file
				inputFile.ReadLine();

				while ((line = inputFile.ReadLine()) != null)
				{
					List<Note> songNotes = new List<Note>();

					List<string> splitLine = new List<string>();

					int quoteCount = 0;
					int startIndex = 0;

					for (int i = 0; i < line.Length; i++)
					{
						if (line[i] == ',')
						{
							if (quoteCount % 2 == 0) // even number of quotes
							{
								splitLine.Add(line.Substring(startIndex, i - startIndex));
								startIndex = i + 1;
							}
						}
						else if (line[i] == '"')
						{
							quoteCount++;
						}
					}

					splitLine.Add(line.Substring(startIndex));


					string title = splitLine[0];
					string album = splitLine[1];
					string artist = splitLine[2];
					string tempo = splitLine[3];
					string frequencyString = splitLine[4].Trim('\"');
					string durationString = splitLine[5].Trim('\"');

					List<string> frequencies = new List<string>(frequencyString.Split(','));
					List<string> durations = new List<string>(durationString.Split(','));

					// Add your song object creation code and other operations here
					for (int i = 0; i < frequencies.Count; i++)
					{
						Note newNote = new Note(int.Parse(frequencies[i]), int.Parse(durations[i]));
						songNotes.Add(newNote);
					}

					Song newSong = new Song(songNotes, title, int.Parse(tempo), artist, album);
					_songs.Add(newSong);

				}
			}
		}
	}

	// Load playlists and songs from a file
	public void LoadPlaylists()
	{
		Console.WriteLine("What is the filename that has your playlists saved?");
		Console.Write("> ");
		string filename = Console.ReadLine();

		if (File.Exists(filename))
		{
			string line;

			using (StreamReader inputFile = new StreamReader(filename))
			{
				// Skip first line of file
				inputFile.ReadLine();

				while ((line = inputFile.ReadLine()) != "")
				{
					string songsString;
					string title;
					List<Song> playlistSongs = new List<Song>();
					
					Regex regex = new Regex(@"\s*"".*?""\s*");
					Match match = regex.Match(line);


					// Move everything within quotes to songsString, deleting extra comma and quotes
					songsString = match.Value.Trim(); // Trim the surrounding whitespace
					line = line.Replace(match.Value, string.Empty); // Remove the extracted string from the initial string
					title = line.Substring(0, line.Length - 1); // Trim trailing comma from line and set as title

					// Split songsString into list of song names
					List<string> songNames = new List<string>(songsString.Split(','));

					// For each item in songNames, append matching song object from _songs to new playlist
					foreach (string songName in songNames)
					{
						Song foundSong = _songs.FirstOrDefault(s => s.GetSongTitle() == songName);
						playlistSongs.Add(foundSong);
					}

					// Save new playlist to _playlists
					Playlist newPlaylist = new Playlist(playlistSongs, title);
					_playlists.Add(newPlaylist);
				}
			}
		}
	}

	public void DisplaySongs()
	{
		// Display saved songs
		if (_songs.Count > 0)
		{
			Console.WriteLine("Saved songs:");
			for (int i = 1; i <= _songs.Count; i++)
			{
				Console.WriteLine($"{i}. {_songs[i-1].GetSongInfo()}");
			}
		}
		else
		{
			Console.WriteLine("No songs found!");
		}
		Console.WriteLine();
	}

	public void DisplayPlaylists()
	{
		if (_playlists.Count > 0)
		{
			// Display saved playlists
			Console.WriteLine("Created playlists:");
			for (int i = 1; i < _playlists.Count; i++)
			{
				Console.WriteLine($"{i}. {_playlists[i-1].GetPlaylistInfo()}");
			}
		}
		else
		{
			Console.WriteLine("No playlists found!");
		}
		Console.WriteLine();
	}

	public Song SearchForSong()
	{
		// Prompt the user to enter the song name to search for
		Console.WriteLine("Enter the title of the song to find:");
		Console.Write("> ");
		string searchQuery = Console.ReadLine();

		// Search for the song in the list
		Song foundSong = _songs.Find(song => song.GetSongTitle().Equals(searchQuery));

		// Delete the song if found
		if (foundSong != null)
		{
			return foundSong;
		}
		else
		{
			return null;
		}
	}

	public Playlist SearchForPlaylist()
	{
		// Prompt the user to enter the song name to search for
		Console.WriteLine("Enter the name of the playlist to find:");
		Console.Write("> ");
		string searchQuery = Console.ReadLine();

		// Search for the song in the list
		Playlist foundPlaylist = _playlists.Find(playlist => playlist.GetPlaylistTitle().Equals(searchQuery));

		// Delete the song if found
		if (foundPlaylist != null)
		{
			return foundPlaylist;
		}
		else
		{
			return null;
		}
	}
}

