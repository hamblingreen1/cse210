using System;

public class Circle : Shape
{
	private double _radius;

	public Circle(string color, double radius)
	{
		_color = color;
		_radius = radius;
	}

	public override double GetArea()
	{
		return 3.14 * (_radius * _radius);
	}
}
