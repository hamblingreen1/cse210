using System;

public class MusicController
{
	private List<Playlist> _playlists = new List<Playlist>();
	private List<Song> _songs = new List<Song>();
	private Device _activeDevice;

	public MusicController()
	{
		// Music controller constructor
	}

	public void Start()
	{
		while (true)
		{
			// Print menu
			Console.WriteLine("Music Controller:");
			Console.WriteLine("    1. Play song");
			Console.WriteLine("    2. Pause playback");
			Console.WriteLine("    3. Previous song");
			Console.WriteLine("    4. Next song");
			Console.WriteLine("    5. Loop current song");
			Console.WriteLine("    6. Write new song");
			Console.WriteLine("    7. Curate new playlist");
			Console.WriteLine("    8. Delete song");
			Console.WriteLine("    9. Delete playlist");
			Console.WriteLine("   10. Save all data");
			Console.WriteLine("   11. Load data from file");
			Console.WriteLine("    0. Quit");

			// Receive user input
			Console.Write("Select a choice from the menu: ");
			int choice = int.Parse(Console.ReadLine());
			Console.WriteLine();

			// Call option's function
			switch (choice)
			{
				case 1: Play();		break;
				case 2: Pause();	break;
				case 3: Previous();	break;
				case 4: Next();		break;
				case 5: Loop();		break;
				case 6: NewSong();	break;
				case 7: NewPlaylist();	break;
				case 8: DeleteSong();	break;
				case 9: DeletePlaylist(); break;
				case 10: SaveData();	break;
				case 11: LoadData();	break;
				case 0: return;
				default:
					Console.WriteLine("Invalid choice, Please try again");
					break;
			}
		}
	}

	public void Play()
	{
		// Play music dialog
	}

	public void Pause()
	{
		// Pause music dialog
	}

	public void Previous()
	{
		// Play previous song in playlist
	}

	public void Next()
	{
		// Play next song in playlist
	}

	public void Loop()
	{
		// Loop current song
	}

	public void NewSong()
	{
		// Create new song
	}

	public void NewPlaylist()
	{
		// Curate new playlist
	}

	public void DeleteSong()
	{
		// Delete song
	}

	public void DeletePlaylist()
	{
		// Delete playlist
	}

	public void SaveData()
	{
		// Save all playlists and songs to a file
	}

	public void LoadData()
	{
		// Load playlists and songs from a file
	}
}

