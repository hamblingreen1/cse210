using System;
using System.IO.Ports;
using System.Reflection;

public class DeviceController
{
	private List<Device> _connectedDevices = new List<Device>();
	private Device _activeDevice;

	// Device controller constructor
	public DeviceController()
	{
		_connectedDevices.Clear();
		_activeDevice = null;
	}

	// Start device controller
	public void Start()
	{
		// Welcome message
		Console.Clear();
		Console.WriteLine("Welcome to your 8-Bit Jukebox!");
		Console.WriteLine("Would you like to set up a device? (Y/n)");
		Console.Write("> ");
		string setup = Console.ReadLine().ToLower();

		// If answer is "n", display menu. Otherwise, add new device
		if (setup == "n")
		{
			DisplayMenu();
		}
		else
		{
			AddDevice();
		}
			
	}

	public void DisplayMenu()
	{
		while (true)
		{
			// Print menu
			Console.WriteLine("Device Controller:");
			Console.WriteLine("    0. Switch to music controller");
			Console.WriteLine("    1. Add new device");
			Console.WriteLine("    2. Remove device");
			Console.WriteLine("    3. List connected devices");
			Console.WriteLine("    4. Set activated device");
			Console.WriteLine("    5. Display activated device");
			Console.WriteLine("    6. Quit");

			// Receive user input
			Console.Write("Select a choice from the menu: ");
			int choice = int.Parse(Console.ReadLine());
			Console.WriteLine();

			// Call option's function
			switch (choice)
			{
				case 0: return; // Intended behavior
				case 1: AddDevice();		break;
				case 2: RemoveDevice();		break;
				case 3: ListConnectedDevices();	break;
				case 4: SetActiveDevice();	break;
				case 5: PrintActiveDevice();	break;
				case 6: Environment.Exit(0);	break;
				default:
					Console.WriteLine("Invalid choice, Please try again");
					break;
			}
		}
	}

	// Dialog to add a new device
	public void AddDevice()
	{
		Console.WriteLine("This dialog will help you connect a serial device.");

		// Choose device name
		string name = ChooseDeviceName();

		// Choose and set a device port
		ListAvailablePorts();
		string port = ChooseDevicePort();

		// Choose and set a device type
		ListDeviceTypes();
		string typeName = ChooseDeviceType();

		// Create device and set as active
		Device newDevice = NewDevice(name, port, typeName);
		SetActiveDevice(newDevice);
	}

	// Get a device name from user
	public string ChooseDeviceName()
	{
		// Prompt
		Console.WriteLine("What would you like to call this device?");
		Console.Write("> ");

		// Receive user input
		string name = Console.ReadLine();
		Console.WriteLine();

		return name;
	}

	// List available device ports
	public void ListAvailablePorts()
	{
		// Create list of available serial ports
		List<string> availablePorts = SerialPort.GetPortNames().ToList();

		// Print list
		Console.WriteLine("Below is a list of connected serial devices:");

		for (int i = 1; i <= availablePorts.Count; i++)
		{
			Console.WriteLine($"    {i}. {availablePorts[i-1]}");
		}

		// Debugging instructions
		Console.WriteLine("If your device hasn't shown up, try unplugging it");
		Console.WriteLine("and plugging it back in or rebooting your computer");
	}

	// Get device port name from user
	public string ChooseDevicePort()
	{
		// Prompt
		Console.WriteLine();
		Console.WriteLine("Please select a device by typing its full name:");
		Console.Write("> ");

		// Receive user input
		string port = Console.ReadLine();
		Console.WriteLine();

		return port;
	}

	// List available device types
	public void ListDeviceTypes()
	{
		// Define Device class type
		Type deviceType = typeof(Device);

		// Get list of all Device subclasses
		Assembly assembly = Assembly.GetExecutingAssembly();
		Type[] typesArray = assembly.GetTypes(); // Get all available types as an array
		List<Type> types = typesArray.ToList(); // Convert array to list

		// List available types
		Console.WriteLine("Available device types:");

		for (int i = 1; i <= types.Count; i++)
		{
			if (types[i-1].IsSubclassOf(deviceType))
			{
				Console.WriteLine($"	{i}. {types[i-1].Name}");
			}
		}
	}

	// Get device type from user
	public string ChooseDeviceType()
	{
		// Prompt
		Console.WriteLine("Select a type of device by typing its full name:");
		Console.Write("> ");

		// Receive user input
		string type = Console.ReadLine();
		Console.WriteLine();

		return type;
	}

	// Add new device of specified name, path, and type
	public Device NewDevice(string name, string port, string typeName)
	{
		// Convert typeName string to type
		Type type = Type.GetType(typeName);

		// Instantiate new object of name "name" and class "type"
		Device device = Activator.CreateInstance(type, name, port) as Device;

		// Add object to connected devices list
		_connectedDevices.Add(device);

		return device;
	}

	// Iterate through each device in list and print name
	public void ListConnectedDevices()
	{
		Console.WriteLine("Connected devices:");
		for (int i = 1; i <= _connectedDevices.Count; i++)
		{
			string deviceName = _connectedDevices[i-1].GetName();
			Console.WriteLine($"{i}. {deviceName}");
		}
		Console.WriteLine();
	}

	// Get name of device from user
	public Device ChooseDevice()
	{
		// Prompt
		ListConnectedDevices();
		Console.WriteLine("Enter device:");
		Console.Write("> ");

		// Receive user input
		string searchName = Console.ReadLine();
		Console.WriteLine();

		// Return first device found with matching name
		foreach (Device device in _connectedDevices)
		{
			string deviceName = device.GetName();
			if (deviceName == searchName)
			{
				return device;
			}
		}

		return null;
	}

	// Set active device specified
	public void SetActiveDevice(Device device)
	{
		// Disconnect from active device
		if (_activeDevice != null)
		{
			_activeDevice.Disconnect();
		}

		// Set new active device
		_activeDevice = device;

		// Connect to new active device
		_activeDevice.Connect();
	}

	// Set active device from list
	public void SetActiveDevice()
	{
		// Disconnect from active device
		if (_activeDevice != null)
		{
			_activeDevice.Disconnect();
		}

		// Set new active device
		_activeDevice = ChooseDevice();

		// Connect to new active device
		_activeDevice.Connect();
	}

	// Deactivate active device
	public void DeactivateDevice()
	{
		Device device = _activeDevice;

		_activeDevice.Disconnect();
		_activeDevice = null;

		Console.WriteLine($"Deactivated device: {device}\n");
	}

	// Remove specified device passed
	public void RemoveDevice(Device device)
	{
		// Activate a different device before removing this one
		if (_activeDevice == device)
		{
			DeactivateDevice();
		}

		// Disconnect from device
		device.Disconnect();

		// Remove connected device from list
		_connectedDevices.Remove(device);

		// Dispose of device
		device.Dispose();
	}

	// Remove specified device from list
	public void RemoveDevice()
	{
		// Get device to remove
		Device device = ChooseDevice();

		// Activate a different device before removing this one
		if (_activeDevice == device)
		{
			DeactivateDevice();
		}

		// Disconnect from device
		device.Disconnect();

		// Remove connected device from list
		_connectedDevices.Remove(device);

		// Dispose of device
		device.Dispose();
	}

	public Device GetActiveDevice()
	{
		return _activeDevice;
	}

	public void PrintActiveDevice()
	{
		Console.WriteLine(GetActiveDevice());
	}
}

