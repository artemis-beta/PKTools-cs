using System;

namespace PhysicsKit
{
	class PKLorentzVector
	{
		PKVar[] X = new PKVar[4];
		PKVar Magn_;

		public PKLorentzVector()
		{
			for(int i = 0; i < X.Length; ++i)
			{
				X[i] = new PKVar(0,0);
			}

			PKVar Magn2_ = X[0].Power(2);
			Magn2_ += X[1].Power(2);
			Magn2_ -= X[2].Power(2);
		        Magn2_ -= X[3].Power(2);
			Magn_ = Magn2_.Sqrt();
		}

		public PKLorentzVector(PKVar x0_, PKVar x1_, PKVar x2_, PKVar x3_)
		{
			X[0] = x0_; 
			X[1] = x1_; 
			X[2] = x2_; 
			X[3] = x3_;
			PKVar Magn2_ = X[0].Power(2);
			Magn2_ += X[1].Power(2);
			Magn2_ -= X[2].Power(2);
		        Magn2_ -= X[3].Power(2);
			Magn_ = Magn2_.Sqrt();
		}

		public PKLorentzVector(double x0_, double x1_, double x2_, double x3_,
			               double x0err_=0, double x1err_=0, double x2err_=0,
				       double x3err_=0)
		{
			X[0] = new PKVar(x0_, x0err_); 
			X[1] = new PKVar(x1_, x1err_);
			X[2] = new PKVar(x2_, x2err_);
			X[3] = new PKVar(x3_, x3err_);
			PKVar Magn2_ = X[0].Power(2);
			Magn2_ += X[1].Power(2);
			Magn2_ -= X[2].Power(2);
		        Magn2_ -= X[3].Power(2);
			Magn_ = Magn2_.Sqrt();
		}

		public PKVar getMagnitude(){return Magn_;}

		public static PKLorentzVector operator+ (PKLorentzVector a, PKLorentzVector b)
		{
			PKLorentzVector temp = new PKLorentzVector();
		        for(int i = 0; i < a.X.Length; ++i)
			{
				temp.X[i] = a.X[i] + b.X[i];
			}

			return temp;
		}

		public static PKLorentzVector operator- (PKLorentzVector a, PKLorentzVector b)
		{
			PKLorentzVector temp = new PKLorentzVector();
		        for(int i = 0; i < a.X.Length; ++i)
			{
				temp.X[i] = a.X[i] - b.X[i];
			}

			return temp;
		}

		public void Print()
		{
			Console.WriteLine("({0}, {1}, {2}, {3})", X[0], 
					                          X[1], 
								  X[2], 
								  X[3]);
		}
	}

}


