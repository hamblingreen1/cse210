using System;
using System.IO.Ports;
using System.Threading;

public class ArduinoUno : Device
{
	// Automatically determines baud rate
	public ArduinoUno(string name, string port) : base(name, port)
	{
		// Define port name and baud rate
		_baudRate = GetBaudRate(port);

		// New serial port
		_device = new SerialPort(_port, _baudRate);

		// Subscribe to the DataReceived event to read serial data
		_device.DataReceived += GetData;
	}

	public override void Connect()
	{
		// Open device serial port
		_device.Open();

		// Two second sleep to wait for serial port to stabilize
		Thread.Sleep(2000);
	}

	// Send only command
	public override void SendCommand(string command)
	{
		// Convert the integers to a string and send it to device
		_device.WriteLine($"{command} 0 0");

		// Small delay
		Thread.Sleep(50);
	}

	// Send tone command
	public override void SendCommand(string command, string frequency, string duration)
	{
		// Convert the integers to a string and send it to device
		_device.WriteLine($"{command} {frequency} {duration}");

		// Send one command at a time
		Thread.Sleep(int.Parse(duration));
	}

	// Get IR data from serial
	public override void GetData(object sender, SerialDataReceivedEventArgs e)
	{
		string data = _device.ReadLine();
		Console.WriteLine($"\nReceived data: {data}");
	}
}
