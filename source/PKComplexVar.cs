using System;

namespace PhysicsKit
{
	class PKComplexVar
	{
		double real_;
		double imagin_;

		double modulus_;
		double arg_;

		PKLogger _compvar_logger = new PKLogger("PKCOMPLEXVAR");

		void _setReal(double real){real_ = real;}

		void _setImag(double imaginary){imagin_ = imaginary;}

		public PKComplexVar(double real, double imaginary)
		{
			real_ = real;
			imagin_ = imaginary;

			modulus_ = Math.Sqrt(Math.Pow(real_,2)+Math.Pow(imagin_,2));

			if(real_ != 0){arg_ = Math.Tan(imagin_/real_);}
			else{arg_ = 0;}
		}

		public double getRe(){return real_;}

		public double getIm(){return imagin_;}

		public double getMod(){return modulus_;}

		public double getArg(){return arg_;}

		public string returnString(int opt)
		{
			string outstring = "";

			switch(opt)
			{
				case 0:
					if(real_ != 0 || imagin_ == 0)
					{
						outstring += real_.ToString();
					}
					
					if(imagin_ != 0)
					{
						if(imagin_ > 0){outstring += "+";}
						outstring += imagin_.ToString()+"i";
					}
					
					break;

				case 1:
					if(imagin_ == 0){outstring = "1";}
					else
					{
						outstring += modulus_.ToString() + "*exp(";
						outstring += arg_.ToString() + "i)";
					}

					break;

				case 2:
					if(imagin_ == 0){outstring = "1";}
					else
					{
						outstring += real_.ToString() + "*cos(" + arg_.ToString() + ")";
						if(imagin_ > 0){outstring += "+";}
						outstring += imagin_.ToString() + "i*sin(" + arg_.ToString() + ")";
					}

					break;

				default:
					_compvar_logger.Error("Invalid integer argument for PKComplexVar::Print(int) options are 0, 1, 2");
					throw new InvalidOperationException("Bad Argument");

			}

			return outstring;
		}

		public override string ToString()
		{
			return returnString(0);
		}

		public static PKComplexVar operator+ (PKComplexVar a, PKComplexVar b)
		{
			PKComplexVar temp = new PKComplexVar(0,0);
			temp._setReal(a.real_ + b.real_);
			temp._setImag(a.imagin_ + b.imagin_);

			return temp;
		}

		public static PKComplexVar operator- (PKComplexVar a, PKComplexVar b)
		{
			PKComplexVar temp = new PKComplexVar(0,0);
			temp._setReal(a.real_ - b.real_);
			temp._setImag(a.imagin_ - b.imagin_);

			return temp;
		}

		public static PKComplexVar operator* (PKComplexVar a, PKComplexVar b)
		{
			PKComplexVar temp = new PKComplexVar(0,0);
			temp._setReal(a.real_*b.real_ - a.imagin_*b.imagin_);
			temp._setImag(a.real_*b.imagin_ + a.imagin_*b.real_);

			return temp;
		}
		public static PKComplexVar operator* (double a, PKComplexVar b)
		{
			PKComplexVar temp = new PKComplexVar(0,0);
			if(b.real_ != 0){temp._setReal(a*b.real_);}
			if(b.imagin_ != 0){temp._setImag(a*b.imagin_);}

			return temp;
		}

		public static PKComplexVar operator* (PKComplexVar a, double b)
		{
			return b*a;
		}

		public static PKComplexVar operator* (int a, PKComplexVar b)
		{
			return (float)a*b;
		}

		public static PKComplexVar operator/ (PKComplexVar a, PKComplexVar b)
		{
			PKComplexVar temp = new PKComplexVar(0,0);
	                temp.modulus_ = a.getMod()/b.getMod();
	                double arg_temp = a.getArg() - b.getArg();
	                temp._setReal(temp.modulus_/Math.Sqrt(1.0+Math.Atan(arg_temp)));
	                temp._setImag(temp.modulus_*Math.Atan(arg_temp)/Math.Sqrt(1+Math.Pow(Math.Atan(arg_temp),2)));
	                return temp;
		}

		public static PKComplexVar operator/ (double a, PKComplexVar b)
		{
			PKComplexVar temp = new PKComplexVar(0,0);
			if(b.real_ != 0){temp._setReal(a/b.real_);}
			if(b.imagin_ != 0){temp._setImag(a/b.imagin_);}

			return temp;
		}

		public static PKComplexVar operator/ (PKComplexVar a, double b)
		{
			return b/a;
		}

		public static bool operator== (PKComplexVar a, PKComplexVar b)
		{
			if(a.real_ != b.real_){return false;}
			if(a.imagin_ != b.imagin_){return false;}
			return true;
		}

		public static bool operator!= (PKComplexVar a, PKComplexVar b)
		{
			return !(a == b);
		}

	}
}
