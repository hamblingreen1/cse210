using System;
using System.IO.Ports;
using System.Threading;

public abstract class Device
{
	protected SerialPort _device;
	protected string _name;
	protected string _port;
	protected int _baudRate;

	// Construct basic device
	public Device(string name, string port)
	{
		_name = name;
		_port = port;
	}

	// Automatically get baud rate from device
	public virtual int GetBaudRate(string port)
	{
		// Create temporary test serial port
		SerialPort testPort = new SerialPort(port);

		// Initialize baud rate to 0
		int baudRate = 0;

		// Open test port
		testPort.Open();

		// Get baud rate and close port
		if (testPort.IsOpen)
		{
			baudRate = testPort.BaudRate;
			testPort.Close();
		}

		// Dispose of test port
		testPort.Dispose();

		// Return baud rate
		return baudRate;
	}

	// Connect device serial
	public virtual void Connect()
	{
		// Open device serial port
		_device.Open();

		// Sleep to wait for serial port to stabilize
		Thread.Sleep(5000);
	}

	// Disconnect device serial
	public virtual void Disconnect()
	{
		// Close device serial port
		_device.Close();
	}

	// Return device name
	public virtual string GetName()
	{
		return _name;
	}

	// Return device serial port
	public virtual void Dispose()
	{
		_device.Dispose();
	}

	// Abstract method to send command only
	public abstract void SendCommand(string command);

	// Abstract method to send command only
	public abstract void SendCommand(string command, string frequency, string duration);

	// Abstract method to receive data from connected device
	public abstract void GetData(object sender, SerialDataReceivedEventArgs e);

}

