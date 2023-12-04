using System;

public class ChecklistGoal : Goal
{
	// Data specific to checklist goals
	private int _amountCompleted;
	private int _target;
	private int _bonus;

	// Checklist Goal constructor
	public ChecklistGoal(string name, string description, int points, int bonus, int target) : base(name, description, points)
	{
		_amountCompleted = 0;
		_target = target;
		_bonus = bonus;
	}

	// Constructor if amountCompleted passed
	public ChecklistGoal(string name, string description, int points, int bonus, int target, int amountCompleted) : base(name, description, points)
	{
		_amountCompleted = amountCompleted;
		_target = target;
		_bonus = bonus;
	}
	public override int RecordEvent()
	{
		// Return no points if already completed
		if (_amountCompleted == _target)
		{
			return 0;
		}

		// Add one to amount completed
		if (_amountCompleted < _target)
		{
			_amountCompleted += 1;
		}

		// Return points
		if (_amountCompleted < _target)
		{
			return _points;
		}
		else
		{
			return _points + _bonus;
		}
	}

	public override bool IsComplete()
	{
		// Return whether goal is complete or not
		if (_amountCompleted < _target)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	public override string GetDetailsString()
	{
		// Return details string depending on whether goal is complete
		if (IsComplete() == false)
		{
			return $"[ ] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
		}
		else
		{
			return $"[x] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
		}
	}

	public override string GetStringRepresentation()
	{
		// String representation for saving and loading
		return $"ChecklistGoal,{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
	}
}
