using System;

namespace PhysicsKit
{
	class PKTriangle
	{
		PKLogger _triangle_logger = new PKLogger("PKTRIANGLE");
		string type_ = "";
		double[] angles_ = new double[3];
		double[] sides_  = new double[3];

		public double CosineRuleSide(double side1, double side2, double angle)
		{
			return Math.Sqrt(Math.Pow(side1,2)+Math.Pow(side2,2)-2*side1*side2*Math.Cos(angle));
		}

		public double CosineRuleAngle(double side1, double side2, double side3)
		{
			return Math.Acos((Math.Pow(side1, 2)+Math.Pow(side2,2)+Math.Pow(side3,2))/(2*side1*side2));
		}

		public PKTriangle(double val1, double val2, double val3, string type="AAS")
		{
			type_ = type;

			if(type_ == "AAS")
			{
				angles_[0] = val1;
				angles_[1] = val2;
				sides_[2]  = val3;
                             
                                angles_[2] = Math.PI - (val1+val2);
				sides_[1]  = (sides_[2]/Math.Sin(angles_[2]))*Math.Sin(angles_[1]);
				sides_[0]  = (sides_[0]/Math.Sin(angles_[2]))*Math.Sin(angles_[0]);
			}

			else if(type_ == "SSA")
			{
				sides_[0]  = val1;
				sides_[1]  = val2;
				angles_[2] = val3;

				sides_[2] = CosineRuleSide(sides_[0],
							   sides_[1],
							   angles_[2]);

				angles_[0] = Math.Asin((Math.Sin(angles_[2])/sides_[2])*sides_[0]);
			}

			else
			{
				_triangle_logger.Error("Invalid Type of {0}, options are 'AAS' and 'SSA'", type_);
				throw new InvalidOperationException("Invalid Type");
			}
		}

		public override string ToString()
		{
			return string.Format("PKTriangle_{0}(ANGLES[{1}, {2}, {3}],"+
				             "SIDES[{4}, {5}, {6}])", type_,
					     angles_[0], angles_[1], angles_[2], 
					     sides_[0], sides_[1], sides_[2]);
		}

		public bool isRightAngled()
		{
			foreach(double angle in angles_)
			{
				if(angle > 0.5*0.99*Math.PI && angle < 0.5*1.01*Math.PI)
				{
					return true;
				}
			}

			return false;
		}
		
	}
}	
