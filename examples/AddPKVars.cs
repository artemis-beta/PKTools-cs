using System;
using PhysicsKit;

class PKVarExample
{
	public static void Main(string[] args)
	{
		PKVar x = new PKVar(100.0, 10.0);
		PKVar y = new PKVar(56.0, 0.34);

		Console.WriteLine("Value 1: {0}", x);
		Console.WriteLine("Value 2: {0}", y);
		Console.WriteLine("Addition: {0}", x+y);
		Console.WriteLine("Subtraction: {0}", x-y);
		Console.WriteLine("Multiplication: {0}", x*y);
		Console.WriteLine("Division: {0}", x/y);
	}
}
