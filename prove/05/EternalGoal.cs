using System;

public class EternalGoal : Goal
{
	// Eternal goal constructor
	public EternalGoal(string name, string description, int points) : base(name, description, points)
	{

	}

	public override int RecordEvent()
	{
		// Return points
		return _points;
	}

	public override bool IsComplete()
	{
		// Goal is never complete
		return false;
	}

	public override string GetStringRepresentation()
	{
		// String representation for saving and loading
		return $"EternalGoal,{_shortName},{_description},{_points}";
	}
}
