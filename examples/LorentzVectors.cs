using System;
using PhysicsKit;

class LorentzExample
{
	public static void Main(string[] args)
	{
		PKLorentzVector a = new PKLorentzVector(new PKVar(432.0,2.0),
				                        new PKVar(-5.6, 0.1),
							new PKVar(1.8, 0.1),
							new PKVar(0,0));

		PKLorentzVector b = new PKLorentzVector(new PKVar(511.0, 3.0),
				                        new PKVar(5.6,0.1),
							new PKVar(-1.8,0.1),
							new PKVar(0,0));

		Console.WriteLine("Lorentz Vector 1: {0}", a);
		Console.WriteLine("Lorentz Vector 2: {0}", b);

		Console.WriteLine("Addition: {0}", a+b);
	}
}
