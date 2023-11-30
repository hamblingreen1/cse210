using System;

class Program
{
	static void Main(string[] args)
	{
		// Create shapes list
		List<Shape> shapes = new List<Shape>();

		// Create square
		string color = "green";
		double side = 5.3;
		Square s0 = new Square(color, side);
		shapes.Add(s0);

		// Create rectangle
		color = "red";
		double length = 10.6;
		double width = 1.5;
		Rectangle r0 = new Rectangle(color, length, width);
		shapes.Add(r0);

		// Create circle
		color = "black";
		double radius = 9.1;
		Circle c0 = new Circle(color, radius);
		shapes.Add(c0);

		foreach (Shape shape in shapes)
		{
			Console.WriteLine(shape.GetColor());
			Console.WriteLine(shape.GetArea());
		}
	}
}
