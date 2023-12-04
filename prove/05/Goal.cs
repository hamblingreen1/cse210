using System;

public abstract class Goal
{
	// Common attributes of all goals
	protected string _shortName;
	protected string _description;
	protected int _points;

	// Generic goal constructor
	public Goal(string name, string description, int points)
	{
		_shortName = name;
		_description = description;
		_points = points;
	}

	// Record event implemented in child goals
	public abstract int RecordEvent();

	// IsComplete implemented in child goals
	public abstract bool IsComplete();

	// Get details string for non-checklist goals
	public virtual string GetDetailsString()
	{
		bool isComplete = IsComplete();
		if (IsComplete() == false)
		{
			return $"[ ] {_shortName} ({_description})";
		}
		else
		{
			return $"[x] {_shortName} ({_description})";
		}
	}

	// Return goal name
	public virtual string GetGoalName()
	{
		return _shortName;
	}

	// String representation implemented in child goals
	public abstract string GetStringRepresentation();
}
