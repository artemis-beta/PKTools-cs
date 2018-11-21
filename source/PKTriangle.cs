using System;

namespace PhysicsKit
{
	class PKTriangle
	{
		PKLogger _triangle_logger = new PKLogger("PKTRIANGLE");
		string type_;
		double[] angles_;
		double[] sides_;

		public PKTriangle(double val1, double val2, double val3, string type="AAS")
		{
			if(type_ == "AAS")
			{
				angles_.Add(val1);
				angles_.Add(val2);
				sides_.Add(val3);
			}
		}
	}
}	
