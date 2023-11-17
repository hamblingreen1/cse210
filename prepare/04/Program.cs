using System;

class Program
{
	static void Main(string[] args)
	{
		// Create base assignment
		string studentName = "Samuel Bennet";
		string topic = "Multiplication";
		Assignment a0 = new Assignment(studentName, topic);
		Console.WriteLine(a0.GetSummary());

		// Create math assignment
		studentName = "Roberto Rodriguez";
		topic = "Fractions";
		string textbookSection = "7.3";
		string problems = "8-19";
		MathAssignment m0 = new MathAssignment(studentName, topic, textbookSection, problems);
		Console.WriteLine(m0.GetSummary());
		Console.WriteLine(m0.GetHomeworkList());

		// Create math assignment
		studentName = "Mary Waters";
		topic = "European History";
		string title = "The Causes of World War II by Mary Waters";
		WritingAssignment w0 = new WritingAssignment(studentName, topic, title);
		Console.WriteLine(w0.GetSummary());
		Console.WriteLine(w0.GetWritingInformation());
	}
}

