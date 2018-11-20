using System;
using PhysicsKit;

class MatrixExample
{
	public static void Main(string[] args)
	{
		PKMatrix a = new PKMatrix();
		a.addRow(new PKVar(12.0, 0.1),
			 new PKVar(15.0, 0.2),
			 new PKVar(11.0, 0.3));

		a.addRow(new PKVar(5.0, 0.2),
			 new PKVar(7.0, 0.1),
			 new PKVar(9.0, 0.3));

		a.addRow(new PKVar(10.0, 0.1),
			 new PKVar(5.0, 0.1),
			 new PKVar(8.0, 0.1));

		Console.Write(a);

		Console.WriteLine("Construct another 3x3 matrix:");


		PKMatrix b = new PKMatrix();
		b.addRow(new PKVar(2.0, 0.1),
			 new PKVar(1.0, 0.2),
			 new PKVar(1.0, 0.3));

		b.addRow(new PKVar(6.0, 0.2),
			 new PKVar(5.0, 0.1),
			 new PKVar(3.0, 0.3));

		b.addRow(new PKVar(0.0, 0.1),
			 new PKVar(2.0, 0.1),
			 new PKVar(1.0, 0.1));

		Console.Write(b);

		Console.WriteLine("Add them together:");

		PKMatrix c = a+b;

		Console.Write(c);

                Console.WriteLine("Multiply them together:");

		PKMatrix d = a*b;

		Console.Write(d);

		Console.WriteLine("Take the Transpose:");

		Console.Write(d.Transpose());

		Console.WriteLine("Let's Try a 2x3 matrix");

		d = new PKMatrix();

		d.addRow(new PKVar(1.4,0.2),
			 new PKVar(5.8,0.2));
		d.addRow(new PKVar(3.2,0.1),
		         new PKVar(1.5,0.4));
		d.addRow(new PKVar(6.0,0.3),
			 new PKVar(5.6,0.1));

		Console.Write(d);

		Console.WriteLine("Take the Transpose:");

		Console.Write(d.Transpose());

		Console.WriteLine("Can't do the Trace!");

		d.Trace();
	}

}
