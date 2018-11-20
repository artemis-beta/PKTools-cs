using System;
using System.Collections.Generic;

namespace PhysicsKit
{
	class PKMatrix
	{
	        List<List<PKVar>> elements_ = new List<List<PKVar>>();
		static PKLogger _matrix_logger = new PKLogger("PKMATRIX");

		public PKMatrix(){}
		public PKMatrix(List<List<PKVar>> x_){elements_ = x_;}

		public void addRow(PKVar x1_, PKVar x2_= default(PKVar),
				   PKVar x3_=default(PKVar),
				   PKVar x4_=default(PKVar),
				   PKVar x5_=default(PKVar),
				   PKVar x6_=default(PKVar),
				   PKVar x7_=default(PKVar),
				   PKVar x8_=default(PKVar),
				   PKVar x9_=default(PKVar),
				   PKVar x10_=default(PKVar))
		{
			_matrix_logger.Info("Adding New Row to Matrix.");
			List<PKVar> temp = new List<PKVar>(new PKVar[]{x1_, x2_, x3_, x4_,
					                               x5_, x6_, x7_, x8_,
								       x9_, x10_});
			List<PKVar> new_list = new List<PKVar>();
			for(int i = 0; i < temp.Count; ++i)
			{
				if(!Double.IsNaN(temp[i].getError()))
				{
					new_list.Add(temp[i]);
				}
			}
                        if(elements_.Count != 0 && new_list.Count != elements_[0].Count)
			{
				_matrix_logger.Error("New Row Length Does Not Match Existing Rows!");
			}

			elements_.Add(new_list);

		}

		public void addRow(List<PKVar> row)
		{
			if(elements_.Count != 0 && row.Count != elements_[0].Count)
			{
				_matrix_logger.Error("New Row Length Does Not Match Existing Rows!");
			}

			elements_.Add(row);
		}


		public void addColumn(PKVar x1_, PKVar x2_=default(PKVar),
				   PKVar x3_=default(PKVar),
				   PKVar x4_=default(PKVar),
				   PKVar x5_=default(PKVar),
				   PKVar x6_=default(PKVar),
				   PKVar x7_=default(PKVar),
				   PKVar x8_=default(PKVar),
				   PKVar x9_=default(PKVar),
				   PKVar x10_=default(PKVar))
		{
			_matrix_logger.Info("Adding New Column to Matrix.");
			List<PKVar> temp = new List<PKVar>(new PKVar[]{x1_, x2_, x3_, x4_, x5_, x6_, x7_,
				        x8_, x9_, x10_});
			List<PKVar> new_list = new List<PKVar>();
			for(int i = 0; i < temp.Count; ++i)
			{
				if(!elements_[i].Equals(null))
				{
					new_list.Add(temp[i]);
				}
			}

			if(elements_.Count != 0 && elements_.Count != new_list.Count)
			{

				_matrix_logger.Error("New Column Length Does Not Match Existing Columns!");
			}

			for(int i = 0; i < elements_.Count; ++i)
			{
				if(!elements_[i].Equals(null))
				{
					elements_[i].Add(new_list[i]);
				}
			}

		}

		public void addColumn(List<PKVar> column)
		{
			if(elements_.Count != 0 && elements_.Count != column.Count)
			{

				_matrix_logger.Error("New Column Length Does Not Match Existing Columns!");
			}
			for(int i = 0; i < elements_.Count; ++i)
			{
				elements_[i].Add(column[i]);
			}
		}


		public void Print()
		{
			Console.Write("[");
			for(int i = 0; i < elements_.Count; ++i)
			{
				for(int j = 0; j < elements_[i].Count; ++j)
				{
					Console.Write(elements_[i][j].ToString());
					if(j+1 < elements_[0].Count){Console.Write(", ");}
					else if(i+1 < elements_.Count){Console.WriteLine();}
				}
			}
			Console.Write("]\n");
		}

		public static PKMatrix operator+ (PKMatrix a, PKMatrix b)
		{
			_matrix_logger.Info("Commencing Matrix Addition...");
			if(b.elements_.Count != a.elements_.Count && b.elements_[0].Count != a.elements_[0].Count)
			{
				_matrix_logger.Error("Cannot Add Matrices with Different Dimensions.");
			}

			_matrix_logger.Debug("Constructing Addition Template");
			_matrix_logger.Debug("Creating New Column");
			List <PKVar> x_ = new List<PKVar>();
			for(int m = 0; m < a.elements_[0].Count; ++m){x_.Add(new PKVar(0,0));}
			_matrix_logger.Debug("Creating New Rows");
			List<List<PKVar>> y_ = new List<List<PKVar>>();
			for(int n = 0; n < a.elements_.Count; ++n){y_.Add(x_);}
			PKMatrix temp = new PKMatrix(y_);
			_matrix_logger.Debug("Inserting Calculated Elements into Template");
			for(int i = 0; i < temp.elements_.Count; ++i)
			{
				for(int j = 0; i < temp.elements_[0].Count; ++j)
				{
					temp.elements_[i][j] = a.elements_[i][j] + b.elements_[i][j];
				}
			}

			return temp;
		}

		public static PKMatrix operator- (PKMatrix a, PKMatrix b)
		{
			_matrix_logger.Info("Commencing Matrix Addition...");
			if(b.elements_.Count != a.elements_.Count && b.elements_[0].Count != a.elements_[0].Count)
			{
				_matrix_logger.Error("Cannot Add Matrices with Different Dimensions.");
			}

			_matrix_logger.Debug("Constructing Subtraction Template");
			_matrix_logger.Debug("Creating New Column");
			List<PKVar> x_ = new List<PKVar>();
			for(int m = 0; m < a.elements_[0].Count; ++m){x_.Add(new PKVar(0,0));}
			_matrix_logger.Debug("Creating New Rows");
			List<List<PKVar>> y_ = new List<List<PKVar>>();
			for(int n = 0; n < a.elements_.Count; ++n){y_.Add(x_);}
			PKMatrix temp = new PKMatrix(y_);
			_matrix_logger.Debug("Inserting Calculated Elements into Template");
			for(int i = 0; i < temp.elements_.Count; ++i)
			{
				for(int j = 0; i < temp.elements_[0].Count; ++j)
				{
					temp.elements_[i][j] = a.elements_[i][j] - b.elements_[i][j];
				}
			}

			return temp;
		}

		public PKMatrix Transpose()
		{
			_matrix_logger.Info("Calculating Matrix Transpose...");
			_matrix_logger.Debug("Constructing Transpose Template");
			_matrix_logger.Debug("Creating New Columns");
			List<PKVar> x_ = new List<PKVar>();
			for(int m = 0; m < elements_.Count; ++m){x_.Add(new PKVar(0,0));}
			_matrix_logger.Debug("Creating New Rows");
			List<List<PKVar>> y_ = new List<List<PKVar>>();
			for(int n = 0; n < elements_[0].Count; ++n){y_.Add(x_);}
			PKMatrix temp_ = new PKMatrix(y_);
			_matrix_logger.Debug("Inserting Calculated Elements into Template");
			for(int i = 0; i < temp_.elements_.Count; ++i)
			{
				for(int j = 0; j < temp_.elements_[0].Count; ++j)
				{
					temp_.elements_[i][j] = elements_[j][i];
				}
			}

			return temp_;
		}

		public static PKMatrix operator* (PKMatrix a, PKMatrix b)
		{
			_matrix_logger.Info("Commencing Matrix Multiplication...");
			_matrix_logger.Debug("Constructing Multiplication Template");
			if(b.elements_.Count != a.elements_[0].Count)
			{
				_matrix_logger.Error("Cannot Multiply Matrices with Dimensions {0} and {1}", b.elements_.Count.ToString(), a.elements_[0].Count.ToString());
			}
			_matrix_logger.Debug("Creating New Columns");
			List<PKVar> x_ = new List<PKVar>();
			for(int m = 0; m < a.elements_[0].Count; ++m)
			{
				x_.Add(new PKVar(0,0));
			}

			_matrix_logger.Debug("Creating New Rows");
			List<List<PKVar>> y_ = new List<List<PKVar>>();
			for(int n = 0; n < a.elements_.Count; ++n){y_.Add(x_);}
			PKMatrix temp_ = new PKMatrix(y_);
			_matrix_logger.Debug("Inserting Calculated Elements into Template");
			for(int i = 0; i < temp_.elements_.Count; ++i)
			{
				for(int j = 0; j < temp_.elements_[0].Count; ++j)
				{
				     for(int l = 0; l < a.elements_[0].Count; ++l)
			             {
                                         temp_.elements_[i][j] = a.elements_[i][j] + b.elements_[i][l];
				     }
				}
	                }

			return temp_;
		}

		public PKVar Trace()
		{
			_matrix_logger.Info("Calculated Matrix Trace...");
			PKVar x_ = new PKVar(0,0);

			if(elements_[0].Count != elements_.Count)
			{
				_matrix_logger.Error("Trace can only be calculated for a square matrix!");
			}

			_matrix_logger.Debug("Adding Trace Components");

			for(int i = 0; i < elements_.Count; ++i)
			{
				x_ = x_ + elements_[i][i];
			}

			return x_;
		}
	}

}
