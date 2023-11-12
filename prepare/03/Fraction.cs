using System;

public class Fraction
{
	// Attributes
	private int _numerator;				// Top number
	private int _denomenator;			// Bottom number

	// Constructor without parameters
	public Fraction()
	{
		_numerator = 1;
		_denomenator = 1;
	}

	// Constructor with numerator parameter
	public Fraction(int numerator)
	{
		_numerator = numerator;
		_denomenator = 1;
	}

	// Constructor with two parameters
	public Fraction(int numerator, int denomenator)
	{
		_numerator = numerator;
		_denomenator = denomenator;
	}

	// Numerator getter
	public int GetNumerator()
	{
		return _numerator;
	}

	// Numerator setter
	public void SetNumerator(int numerator)
	{
		_numerator = numerator;
	}

	// Denomenator getter
	public int GetDenomenator()
	{
		return _denomenator;
	}

	// Denomenator setter
	public void SetDenomenator(int denomenator)
	{
		_denomenator = denomenator;
	}

	// Get fraction as string
	public string GetFractionString()
	{
		return $"{_numerator} / {_denomenator}";
	}

	// Get decimal value of fraction as a double
	public double GetDecimalValue()
	{
		return (double) _numerator / _denomenator;
	}

}

