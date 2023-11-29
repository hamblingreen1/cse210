/****************************************
* mindfulness -- take a break		*
* Author: Bobby Hamblin			*
*   <hamblingreen@hotmail.com>		*
* Purpose: Demonstate an application of	*
*   inheritance				*
* Usage: Choose activity at menu and	*
*   follow instructions			*
* Creativity: I added a check to make	*
*   sure the session duration is more	*
*   than 0, which would otherwise throw	*
*   an exception and crash the program.	*
*   Also, I added letter menu options	*
****************************************/

using System;

class Program
{
	static void Main(string[] args)
	{
		while (true)
		{
			// Print menu
			Console.Clear();
			Console.WriteLine("Menu Options:");
			Console.WriteLine("    1/b. Start breathing activity");
			Console.WriteLine("    2/r. Start reflecting activity");
			Console.WriteLine("    3/l. Start listing activity");
			Console.WriteLine("    4/q. Quit");

			// Receive user input
			Console.Write("Select a choice from the menu: ");
			string choice = Console.ReadLine();
			choice = choice.ToLower();

			// Call option's function
			switch (choice)
			{
				case "1":
				case "b":
					BreathingActivity breathingActivity = new BreathingActivity();
					breathingActivity.Run();
					break;
				case "2":
				case "r":
					ReflectingActivity reflectingActivity = new ReflectingActivity();
					reflectingActivity.Run();
					break;
				case "3":
				case "l":
					ListingActivity listingActivity = new ListingActivity();
					listingActivity.Run();
					break;
				case "4":
				case "q":
					return;
				default:
					Console.WriteLine("Invalid choice, Please try again");
					break;
			}
		}
	}
}
