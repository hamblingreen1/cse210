using System;
using System.IO.Ports;
using System.Threading;

public abstract class Device
{
	protected SerialPort _devicePort;
	protected string _deviceName;
	protected string _portPath;
	protected int _baudRate;

	// Construct basic device
	public Device(string deviceName)
	{
		_deviceName = deviceName;
	}

	// Get device name
	public string GetDeviceName()
	{
		return _deviceName;
	}

	// Get baud rate
	public abstract int GetBaudRate();

	// Connect device serial
	public virtual void Connect()
	{
		// Open device serial port
		_devicePort.Open();

		// Sleep to wait for serial port to stabilize
		Thread.Sleep(5000);
	}

	// Disconnect device serial
	public virtual void Disconnect()
	{
		// Close device serial port
		_devicePort.Close();
	}

	// Abstract method to send command only
	public abstract void SendCommand(string command);

	// Abstract method to receive data from connected device
	public abstract void GetData(object sender, SerialDataReceivedEventArgs e);

	// Get list of available ports
	public List<string> GetAvailablePorts()
	{
		// Get string array of available ports
		List<string> availablePorts = SerialPort.GetPortNames().ToList();

		return availablePorts;
	}

	// Get next port to be used
	public string GetNextPort()
	{
		// Get available ports
		List<string> availablePorts = GetAvailablePorts();
		string nextPort = "";

		// Get next unused port from availablePorts list
		return nextPort;
	}
}

