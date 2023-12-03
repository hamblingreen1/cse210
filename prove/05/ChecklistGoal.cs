using System;

public class ChecklistGoal : Goal
{
	private int _amountCompleted;
	private int _target;
	private int _bonus;

	public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
	{
		_amountCompleted = 0;
		_target = target;
		_bonus = bonus;
	}

	public override int RecordEvent()
	{
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
		if (IsComplete() == false)
		{
			return $"[ ] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
		}
		else
		{
			return "[x] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
		}
	}

	public override string GetStringRepresentation()
	{
		return $"ChecklistGoal,{_shortName},{_description},{_points},{_bonus}{_target},{_amountCompleted}";
	}
}
