using System;
using PhysicsKit;

class PKCompVarExample
{
	public static void Main(string[] args)
	{
		PKComplexVar var1 = new PKComplexVar(3,2);
		PKComplexVar var2 = new PKComplexVar(-5,1);

		Console.WriteLine("Complex Var 1: {0}", var1);
		Console.WriteLine("Complex Var 2: {0}", var2);

		Console.WriteLine("var1+var2 = {0}", var1+var2);
		Console.WriteLine("var1-var2 = {0}", var1-var2);
		Console.WriteLine("var1*var2 = {0}", var1*var2);
		Console.WriteLine("var1/var2 = {0}", var1/var2);
		Console.WriteLine("4*var2 = {0}", 4*var2);
	}
}
