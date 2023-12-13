using System;

public class Note
{
	private string _note;
	private int _octave;
	private int _frequency;
	private int _duration;

	// Note constructor
	public Note(string note, int octave, int duration)
	{
		_note = note;
		_octave = octave;
		_duration = duration;
		_frequency = ConvertNotes(note, octave);
	}

	public Note(int frequency, int duration)
	{
		_frequency = frequency;
		_duration = duration;
	}

	// Convert note leter to frequency
	public int ConvertNotes(string note, int octave)
	{
		int frequency = 0;

		// Define frequency by note letter
		switch (note)
		{
			case "A":	frequency = 220;	break;
			case "Bb":	frequency = 233;	break;
			case "B":	frequency = 247;	break;
			case "C":	frequency = 261;	break;
			case "C#":	frequency = 277;	break;
			case "D":	frequency = 293;	break;
			case "D#":	frequency = 311;	break;
			case "E":	frequency = 329;	break;
			case "F":	frequency = 349;	break;
			case "F#":	frequency = 370;	break;
			case "G":	frequency = 392;	break;
			case "Ab":	frequency = 415;	break;
			default:	frequency = 0;		break;
		}

		// Shift by octave
		if (octave > 0)
			frequency = frequency * 2;
		else if (octave < 0)
			frequency = frequency / 2;

		// Prevent negative frequencies
		frequency = Math.Abs(frequency);

		return frequency;
	}

	public void Play(Device _activeDevice)
	{
		// Play note
		_activeDevice.SendCommand("1", _frequency.ToString(), _duration.ToString());
	}

	// Get frequency
	public int GetFrequency()
	{
		return _frequency;
	}

	// Get duration
	public int GetDuration()
	{
		return _duration;
	}
}

