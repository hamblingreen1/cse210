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
		// MusicController musicController = new MusicController();
		// musicController.Start();
	}
}
