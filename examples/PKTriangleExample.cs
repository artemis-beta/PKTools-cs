using System;
using PhysicsKit;

class PKTriangleExample
{
	public static void Main(string[] args)
	{
		PKTriangle triangle = new PKTriangle(3,3,(4.0/3.0)*Math.Atan(1.0), "SSA");

		Console.WriteLine("Triangle 1: {0}", triangle);
		
		PKTriangle triangle2 = new PKTriangle(2*Math.Atan(1.0),
						     (4.0/3.0)*Math.Atan(1.0), 
						     15.0, "AAS");

		Console.WriteLine("Triangle 2: {0}", triangle2);

		Console.WriteLine("Is Triangle 1 Right Angled?");

		Console.WriteLine(triangle.isRightAngled());

		Console.WriteLine("Is Triangle 2 Right Angled?");

		Console.WriteLine(triangle2.isRightAngled());

	}

}
