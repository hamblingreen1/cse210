using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

public class GoalManager
{
	protected List<Goal> _goals = new List<Goal>();
	protected int _score;

	public GoalManager()
	{
		_score = 0;
	}

	public void Start()
	{
		while (true)
		{
			// Print point total

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

			// Call option's function
			switch (choice)
			{
				case 1:
					CreateGoal();
					break;
				case 2:
					ListGoalNames();
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
		Console.WriteLine($"You have {_score} points.");
	}

	public void ListGoalNames()
	{
		foreach(Goal goal in _goals)
		{
			Console.WriteLine(goal.GetDetailsString());
		}
	}

	public void ListGoalDetails()
	{
		foreach(Goal goal in _goals)
		{
			Console.WriteLine(goal.GetDetailsString());
		}
	}

	public void CreateGoal()
	{
		Console.WriteLine("The types of Goals are:");
		Console.WriteLine("    1. Simple Goal");
		Console.WriteLine("    2. Eternal Goal");
		Console.WriteLine("    3. Checklist Goal");
		Console.Write("Which type of goal would you like to create? ");

		int choice = int.Parse(Console.ReadLine());

		int target;
		int bonus;
		Console.Write("What is the name of your goal? ");
		string shortName = Console.ReadLine();
		Console.Write("What is a short description of it? ");
		string description = Console.ReadLine();
		Console.Write("What is the amount of points associated with this goal? ");
		int points = int.Parse(Console.ReadLine());

		switch(choice)
		{
			case 1:
				SimpleGoal simpleGoal = new SimpleGoal(shortName, description, points);
				_goals.Add(simpleGoal);
				break;
			case 2:
				EternalGoal eternalGoal = new EternalGoal(shortName, description, points);
				_goals.Add(eternalGoal);
				break;
			case 3:
				Console.Write("How many times does this goal need to be accomplished for a bonus? ");
				target = int.Parse(Console.ReadLine());
				Console.Write("What is the bonus for accomplishing it that many times?");
				bonus = int.Parse(Console.ReadLine());
				ChecklistGoal checklistGoal = new ChecklistGoal(shortName, description, points, target, bonus);
				break;

		}
	}

	public void RecordEvent()
	{
		// List goal names
		ListGoalNames();

		// Select goal
		Console.Write("Which goal did you accomplish?");
		int choice = int.Parse(Console.ReadLine());

		// Run record event method of selected goal
		_goals[choice].RecordEvent();
	}

	public void SaveGoals()
	{
		// Retrieve goal filename
		Console.WriteLine("What is the filename for the goal file? ");
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
		}
	}

	public void LoadGoals()
	{
		// Retrieve goal filename
		Console.WriteLine("What is the filename for the goal file? ");
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
					line = inputFile.ReadLine();

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
							points = int.Parse(values[4]);
							SimpleGoal newSimpleGoal = new SimpleGoal(shortName, description, points);
							_goals.Add(newSimpleGoal);
							break;
						case "EternalGoal":
							EternalGoal newEternalGoal = new EternalGoal(shortName, description, points);
							_goals.Add(newEternalGoal);
							break;
						case "ChecklistGoal":
							int target = int.Parse(values[4]);
							int bonus = int.Parse(values[5]);
							ChecklistGoal newChecklistGoal = new ChecklistGoal(shortName, description, points, target, bonus);
							_goals.Add(newChecklistGoal);
							break;
					}
				}
			}
		}
	}
}
