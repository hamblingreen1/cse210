using System;
using System.IO.Ports;
using System.Threading;

public class ArduinoUno : Device
{
	// Automatically determines port name and baud rate
	public ArduinoUno(string deviceName) : base(deviceName)
	{
		// Define port name and baud rate
		_portPath = GetNextPort();
		_baudRate = GetBaudRate();

		// New serial port
		SerialPort _devicePort = new SerialPort(_portPath, _baudRate);

		// Subscribe to the DataReceived event to read serial data
		_devicePort.DataReceived += GetData;
	}

	// Creates arduino uno if port name and baud rate are provided
	public ArduinoUno(string deviceName, string portPath, int baudRate) : base(deviceName)
	{
		_portPath = portPath;
		_baudRate = baudRate;
		SerialPort _devicePort = new SerialPort(_portPath, _baudRate);
	}

	public override void Connect()
	{
		// Open device serial port
		_devicePort.Open();

		// Two second sleep to wait for serial port to stabilize
		Thread.Sleep(2000);
	}

	// Send only command
	public override void SendCommand(string command)
	{
		// Convert the integers to a string and send it to device
		_devicePort.WriteLine($"{command} 0 0");
		Console.WriteLine($"{command} 0 0");
	}

	// Send tone command
	public void SendCommand(string command, string frequency, string duration)
	{
		// Convert the integers to a string and send it to device
		_devicePort.WriteLine($"{command} {frequency} {duration}");
		Console.WriteLine($"{command} {frequency} {duration}");
	}

	// Get IR data from serial
	public override void GetData(object sender, SerialDataReceivedEventArgs e)
	{
	    string data = _devicePort.ReadLine();
	    Console.WriteLine($"Received data: {data}");
	}

	// Get baud rate from arduino
	public override int GetBaudRate()
	{
		return _devicePort.BaudRate;
	}
}
