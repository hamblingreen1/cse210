using System;

public class SimpleGoal : Goal
{
	// Goal complete boolean
	private bool _isComplete;

	// Constructor without isComplete passed
	public SimpleGoal(string name, string description, int points) : base(name, description, points)
	{
		_isComplete = false;
	}

	// Constructor with isComplete passed
	public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
	{
		_isComplete = isComplete;
	}

	public override int RecordEvent()
	{
		// Record goal as completed and return points
		if (_isComplete == false)
		{
			_isComplete = true;
			return _points;
		}
		else
		{
			// Goal already complete!
			return 0;
		}
	}

	public override bool IsComplete()
	{
		// Return whether goal is complete
		return _isComplete;
	}

	public override string GetStringRepresentation()
	{
		// String representation for saving/loading
		return $"SimpleGoal,{_shortName},{_description},{_points},{_isComplete}";
	}
}
