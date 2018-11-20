using System;

namespace PhysicsKit
{
	class PKLogger
	{
		string _logger_name;
	        void _global_out(PKGlobal.Level type, string type_str, string _logger_name,
	            	    string msg, string a, string b, string c, string d,
	            	    string e, string f, string g)
                {
	                string msg_w_args = string.Format(msg, a, b, c, d, e, f, g);

	                if(type >= PKGlobal._global_logger_level)
                        {
	            	    Console.WriteLine("{0}: {1}: {2}", _logger_name, type.ToString(),
	            			      msg_w_args);
	                }

                }


		public PKLogger(string name){_logger_name = name;}

		public void Error(string msg, string a="", 
				  string b="", string c="", 
				  string d="", string e="", 
				  string f="", string g="")
		{
			_global_out(PKGlobal.Level.ERROR, "ERROR", _logger_name, msg,
					a, b, c, d, e, f, g);
		}

		public void Warning(string msg, string a="", 
				  string b="", string c="", 
				  string d="", string e="", 
				  string f="", string g="")
		{
			_global_out(PKGlobal.Level.WARNING, "WARNING", _logger_name, msg,
					a, b, c, d, e, f, g);
		}

		public void Info(string msg, string a="", 
				  string b="", string c="", 
				  string d="", string e="", 
				  string f="", string g="")
		{
			_global_out(PKGlobal.Level.INFO, "INFO", _logger_name, msg,
					a, b, c, d, e, f, g);
		}

		public void Critical(string msg, string a="", 
				  string b="", string c="", 
				  string d="", string e="", 
				  string f="", string g="")
		{
			_global_out(PKGlobal.Level.CRITICAL, "CRITICAL", _logger_name, msg,
					a, b, c, d, e, f, g);
		}

		public void Fatal(string msg, string a="", 
				  string b="", string c="", 
				  string d="", string e="", 
				  string f="", string g="")
		{
			_global_out(PKGlobal.Level.FATAL, "FATAL", _logger_name, msg,
					a, b, c, d, e, f, g);
		}

		public void Debug(string msg, string a="", 
				  string b="", string c="", 
				  string d="", string e="", 
				  string f="", string g="")
		{
			_global_out(PKGlobal.Level.DEBUG, "DEBUG", _logger_name, msg,
					a, b, c, d, e, f, g);
		}
	}

}
