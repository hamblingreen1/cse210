/****************************************
* 8-bit jukebox -- control music on a	*
* 	connected serial device		*
* Author: Bobby Hamblin			*
*   <hamblingreen@hotmail.com>		*
* Purpose: Provide a user interface for	*
*   playing music on a serial device	*
*   with a buzzer. Composed of 2 parts,	*
*   a device controller and music	*
*   controller. The device controller	*
*   can be used seperately from the	*
*   music controller to connect and	*
*   manage serial devices		*
* Usage: On program startup, you will	*
*   be asked if you'd like to set up a	*
*   serial device. If the "yes" option	*
*   is selected, a prompt will appear	*
*   to add a device. Otherwise, you	*
*   will be dropped into the device	*
*   controller menu. 			*
*					*
*   DEVICE CONTROLLER:			*
*      0. Switch to music controller	*
*      1. Add new device		*
*      2. Remove device			*
*      3. List connected devices	*
*      4. Set activated device		*
*      5. Display activated device	*
*      6. Quit				*
*   A note on the activated device: You	*
*   can add and manage multiple serial	*
*   connections using this manager, but	*
*   commands from the music controller	*
*   will only be sent to the device the	*
*   user marks as active. The first	*
*   device added is marked as active by	*
*   default.				*
*					*
*  MUSIC CONTROLLER:			*
*    0. Switch to device controller	*
*    1. Play song			*
*    2. Queue playlist			*
*    3. Toggle playback			*
*    5. Loop current sont		*
*    6. Write new song			*
*    7. Curate new playlist		*
*    8. Delete song			*
*    9. Delete playlist			*
*    10. Save all data			*
*    11. Load data from file		*
*    12. Display songs and playlists	*
*    13. Quit				*
*   Most options are pretty self	*
*   explanatory. Toggle playback will	*
*   just pause and play any song	*
*   currently playing, and looping the	*
*   currently playing song is another	*
*   option that toggles on and off	*
*					*
*  Writing a new song: At the new song	*
*  prompt, you'll be posed with 7	*
*  questions. The first 3 are metadata	*
*  for the purposes of displaying the	*
*  song. The fourth asks you to input	*
*  the songs tempo. This is important	*
*  because the duration of each		*
*  frequency played is determined by	*
*  this tempo. Then, you'll be asked to	*
*  input a list of notes separated by	*
*  spaces. Accepted notes are (A, Bb, B	*
*  C, C#, D, D#, E, F, F#, G, Ab). Any	*
*  other letters input will be		*
*  interpreted as silence. Next you'll	*
*  input a list of how many octaves	*
*  above or below middle C that note is	*
*  Finally you'll be asked to input a	*
*  list of beats. This determines how	*
*  long each note is played. 		*
* File formats: Comma-Separated Values	*
*   (CSV) - plain text tabular storage	*
* Restrictions: When composing a new	*
*   song, no field may be left empty	*
*   and all three lists determining	*
*   note information must have the same	*
*   quantity of items.			*
****************************************/

using System;
using System.IO.Ports;
using System.Threading;

class Program
{
	static void Main(string[] args)
	{
		// Create and start new device controller
		DeviceController deviceController = new DeviceController();
		deviceController.Start();

		// Create and start new music controller
		MusicController musicController = new MusicController(deviceController);

		// Start music controller menu
		musicController.DisplayMenu();

	}
}
