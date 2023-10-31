using System;

class Program
{
	static void DisplayWelcome()
	{
		Console.WriteLine("Welcome to the Program!");
	}

	static string PromptUserName()
	{
		Console.Write("Please enter your name: ");
		string userName = Console.ReadLine();

		return userName;
	}

	static int PromptUserNumber()
	{
		Console.Write("Please enter your favorite number: ");
		string input = Console.ReadLine();
		int userNumber = int.Parse(input);

		return userNumber;
	}

	static int SquareNumber(int userNumber)
	{
		int userNumberSquared = userNumber * userNumber;

		return userNumberSquared;
	}

	static void DisplayResult(string userName, int userNumberSquared)
	{
		Console.WriteLine($"{userName}, the square of your number is {userNumberSquared}");
	}

	static void Main(string[] args)
	{
		DisplayWelcome();
		string userName = PromptUserName();
		int userNumber = PromptUserNumber();
		int userNumberSquared = SquareNumber(userNumber);
		DisplayResult(userName, userNumberSquared);
	}
}