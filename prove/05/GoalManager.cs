using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

public class GoalManager
{
	// Create goals list and score
	protected List<Goal> _goals = new List<Goal>();
	protected int _score;

	// Initialize score to 0
	public GoalManager()
	{
		_score = 0;
	}

	// Start program
	public void Start()
	{
		while (true)
		{
			// Print point total
			DisplayPlayerInfo();

			// Print menu
			Console.WriteLine("Menu Options:");
			Console.WriteLine("    1. Create New Goal");
			Console.WriteLine("    2. List Goals");
			Console.WriteLine("    3. Save Goals");
			Console.WriteLine("    4. Load Goals");
			Console.WriteLine("    5. Record Event");
			Console.WriteLine("    6. Quit");

			// Receive user input
			Console.Write("Select a choice from the menu: ");
			int choice = int.Parse(Console.ReadLine());
			Console.WriteLine();

			// Call option's function
			switch (choice)
			{
				case 1:
					CreateGoal();
					break;
				case 2:
					ListGoalDetails();
					break;
				case 3:
					SaveGoals();
					break;
				case 4:
					LoadGoals();
					break;
				case 5:
					RecordEvent();
					break;
				case 6:
					return;
				default:
					Console.WriteLine("Invalid choice, Please try again");
					break;
			}
		}
	}

	public void DisplayPlayerInfo()
	{
		// Display point total
		Console.WriteLine($"You have {_score} points.");
		Console.WriteLine();
	}

	public void ListGoalNames()
	{
		// List only goal names
		for (int i = 1; i <= _goals.Count; i++)
		{
			Console.WriteLine($"{i}. {_goals[i-1].GetGoalName()}");
		}

		Console.WriteLine();
	}

	public void ListGoalDetails()
	{
		// List goal details
		for (int i = 1; i <= _goals.Count; i++)
		{
			Console.WriteLine($"{i}. {_goals[i-1].GetDetailsString()}");
		}

		Console.WriteLine();
	}

	public void CreateGoal()
	{
		// Menu to create new goal
		Console.WriteLine("The types of Goals are:");
		Console.WriteLine("    1. Simple Goal");
		Console.WriteLine("    2. Eternal Goal");
		Console.WriteLine("    3. Checklist Goal");
		Console.Write("Which type of goal would you like to create? ");

		int choice = int.Parse(Console.ReadLine());

		// Get goal information for all goals
		Console.Write("What is the name of your goal? ");
		string shortName = Console.ReadLine();
		Console.Write("What is a short description of it? ");
		string description = Console.ReadLine();
		Console.Write("What is the amount of points associated with this goal? ");
		int points = int.Parse(Console.ReadLine());

		switch(choice)
		{
			case 1:
				// Create and save simple goal
				SimpleGoal simpleGoal = new SimpleGoal(shortName, description, points);
				_goals.Add(simpleGoal);
				break;
			case 2:
				// Create and save eternal goal
				EternalGoal eternalGoal = new EternalGoal(shortName, description, points);
				_goals.Add(eternalGoal);
				break;
			case 3:
				// Get checklist goal specific information
				Console.Write("How many times does this goal need to be accomplished for a bonus? ");
				int target = int.Parse(Console.ReadLine());
				Console.Write("What is the bonus for accomplishing it that many times? ");
				int bonus = int.Parse(Console.ReadLine());

				// Create and save checklist goal
				ChecklistGoal checklistGoal = new ChecklistGoal(shortName, description, points, bonus, target);
				_goals.Add(checklistGoal);
				break;
			default:
				// Invalid choice
				Console.WriteLine("Invalid choice.");
				break;
		}
	}

	public void RecordEvent()
	{
		// List goal names
		ListGoalNames();

		// Select goal
		Console.Write("Which goal did you accomplish? ");
		int choice = int.Parse(Console.ReadLine());
		choice--;

		// Run record event method of selected goal
		int points = _goals[choice].RecordEvent();
		_score += points;

		// Display message
		Console.WriteLine($"Congratulations! You have earned {points} points!");
		Console.WriteLine();
	}

	public void SaveGoals()
	{
		// Retrieve goal filename
		Console.Write("What is the filename for the goal file? ");
		string filename = Console.ReadLine();

		using (StreamWriter outputFile = new StreamWriter(filename))
		{
			// Write score at top of file
			outputFile.WriteLine(_score);

			// Write goal info on each line
			foreach(Goal goal in _goals)
			{
				outputFile.WriteLine(goal.GetStringRepresentation());
			}

			// Finish with blank line
			outputFile.WriteLine();
		}
	}

	public void LoadGoals()
	{
		// Retrieve goal filename
		Console.Write("What is the filename for the goal file? ");
		string filename = Console.ReadLine();

		if (File.Exists(filename))
		{
			using (StreamReader inputFile = new StreamReader(filename))
			{
				// Parse first line as score
				_score = int.Parse(inputFile.ReadLine());

				string line;

				while ((line = inputFile.ReadLine()) != "")
				{
					string goalType, shortName, description;
					int points;

					string[] values = line.Split(',');
					goalType = values[0];
					shortName = values[1];
					description = values[2];
					points = int.Parse(values[3]);

					switch (goalType)
					{
						case "SimpleGoal":
							bool isComplete = bool.Parse(values[4]);
							SimpleGoal newSimpleGoal = new SimpleGoal(shortName, description, points, isComplete);
							_goals.Add(newSimpleGoal);
							break;
						case "EternalGoal":
							EternalGoal newEternalGoal = new EternalGoal(shortName, description, points);
							_goals.Add(newEternalGoal);
							break;
						case "ChecklistGoal":
							int target = int.Parse(values[4]);
							int bonus = int.Parse(values[5]);
							int amountCompleted = int.Parse(values[6]);
							ChecklistGoal newChecklistGoal = new ChecklistGoal(shortName, description, points, bonus, target, amountCompleted);
							_goals.Add(newChecklistGoal);
							break;
						default:
							// Do nothing
							break;
					}
				}
			}
		}
	}
}
