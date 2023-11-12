using System;

class Program
{
	static void Main(string[] args)
	{
		Fraction f0 = new Fraction();		// No-argument constructor
		Fraction f1 = new Fraction(6);		// One argument constructor
		Fraction f2 = new Fraction(6, 7);	// Two argument constructor

		// Print initial values as fraction strings
		Console.WriteLine(f0.GetFractionString());
		Console.WriteLine(f1.GetFractionString());
		Console.WriteLine(f2.GetFractionString());

		// Print initial values as decimals
		Console.WriteLine(f0.GetDecimalValue());
		Console.WriteLine(f1.GetDecimalValue());
		Console.WriteLine(f2.GetDecimalValue());

		// Set fraction 0 to 3/4
		f0.SetNumerator(3);
		f0.SetDenomenator(4);

		// Print 3/4 as a fraction string and decimal
		Console.WriteLine(f0.GetFractionString());
		Console.WriteLine(f0.GetDecimalValue());
	}
}

