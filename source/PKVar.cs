using System;

namespace PhysicsKit
{
	class PKVar
	{
		double value_;
		double error_;

		public double getVal(){return value_;}
		public double getError(){return error_;}
		public PKVar(){value_=0; error_=0;}
		public PKVar(double a, double b)
		{
			value_ = a;
			error_ = b;
		}
		public static PKVar operator+ (PKVar a, PKVar b)
		{
			PKVar _new = new PKVar();
			_new.value_ = a.value_+b.value_;
			_new.error_ = Math.Sqrt(Math.Pow(a.error_,2)+Math.Pow(b.error_,2));
			return _new;
		}
		public static PKVar operator- (PKVar a, PKVar b)
		{
			PKVar _new = new PKVar();
			_new.value_ = a.value_-b.value_;
			_new.error_ = Math.Sqrt(Math.Pow(a.error_,2)+Math.Pow(b.error_,2));
			return _new;
		}
		public static PKVar operator* (PKVar a, PKVar b)
		{
			PKVar _new = new PKVar();
			_new.value_ = a.value_*b.value_;
			_new.error_ = Math.Sqrt(Math.Pow(b.value_*a.error_,2)+Math.Pow(a.value_*b.error_,2));
			return _new;
		}
		public static PKVar operator/ (PKVar a, PKVar b)
		{
			PKVar _new = new PKVar();
			_new.value_ = a.value_/b.value_;
			_new.error_ = Math.Sqrt(Math.Pow(a.error_/b.value_,2)+Math.Pow(a.value_*b.error_,2)*Math.Pow(b.value_,-4));
			return _new;
		}
		public PKVar Power(double a)
		{
			PKVar _new = new PKVar();
			if(value_ == 0 && a < 1){Console.WriteLine("Cannot Raise 0 to a negative power!"); Environment.Exit(1);}
			_new.value_ = Math.Pow(value_, a);
			_new.error_ = a*Math.Pow(value_, a-1)*error_;
			return _new;
		}
		public PKVar Sqrt()
		{
			return Power(0.5);
		}
		public override string ToString()
		{
                        if(error_ > 0){return string.Format("{0} +/- {1}", value_, error_);}
			else{return value_.ToString("0.####");}
		}

	}
}
