using System;
using System.IO.Ports;
using System.Threading;

public class DeviceController
{
	private List<Device> _connectedDevices = new List<Device>();
	private Device _activeDevice;

	public DeviceController()
	{
		// Device controller constructor
	}

	public void Start()
	{
		// Start device controller
	}

	public Device GetActiveDevice()
	{
		return _activeDevice;
	}

	public void SetActiveDevice()
	{
		// Set active device from device list
	}

	public void AddDevice()
	{
		// Call appropriate device constructor 
	}

	public void RemoveDevice(Device device)
	{
		// Remove specified device from list
	}

	public void ListDevices()
	{
		// Iterate through each device in list and print name
		foreach (Device device in _connectedDevices)
		{
			Console.WriteLine(device.GetDeviceName());
		}
	}
}

