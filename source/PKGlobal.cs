using System;

namespace PhysicsKit
{
	public static class PKGlobal
	{
	    public enum Level
	    {
	    	DEBUG,
	    	INFO,
	    	WARNING,
	    	ERROR,
	    	CRITICAL,
	    	FATAL
	    };


	    public static Level _global_logger_level = Level.WARNING;

	    public static void setLoggerLevel(Level level){_global_logger_level = level;}

	    public static void setLoggerLevel(string level_str)
	    {
                 if( level_str == "INFO" )
                {
                    _global_logger_level = Level.INFO;
                }
                else if( level_str == "DEBUG" )
                {
                    _global_logger_level = Level.DEBUG;
                }
                else if( level_str == "WARNING" )
                {
                    _global_logger_level = Level.WARNING;
                }
                else if( level_str == "ERROR" )
                {
                    _global_logger_level = Level.ERROR;
                }
                else if( level_str == "FATAL" )
                {
                    _global_logger_level = Level.FATAL;
                }
                else if( level_str == "CRITICAL" )
                {
                    _global_logger_level = Level.CRITICAL;
                }
                else
                {
                    Console.WriteLine("Invalid logger level option '{0}'. Using default.", level_str);
	        }
	    }
	}

}

