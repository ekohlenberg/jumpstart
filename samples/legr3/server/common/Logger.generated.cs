using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using Npgsql;

namespace legr3
{

    public interface ILogWriter
    {
        void Write(string level, string message);
    }

    public abstract class BaseLogWriter
    {
        protected readonly string ProgramName;
        protected readonly object Lock = new();

        protected BaseLogWriter()
        {
             ProgramName = Process.GetCurrentProcess().ProcessName ?? "UnknownProgram";
        }

        protected string FormatLogMessage(string level, string message)
        {
            string timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            string currentUser = Environment.UserName;
            return $"{timestamp} {level} {currentUser} {ProgramName} {message}\n";
        }
    }

    public class LogFileWriter : BaseLogWriter, ILogWriter
    {
        private readonly string _baseFileName;
        private string _currentFileName;

        public LogFileWriter()
            : base()
        {
            _baseFileName = $"{ProgramName}.log";
            _currentFileName = _baseFileName;
        }

        public void Write(string level, string message)
        {
            lock (Lock)
            {
                DateTime now = DateTime.UtcNow;

                // Check if the file needs to be rolled over based on file's last write time
                if (File.Exists(_currentFileName))
                {
                    DateTime lastWriteTime = File.GetLastWriteTimeUtc(_currentFileName);
                    if (lastWriteTime.Date < now.Date)
                    {
                        RollOverLogFile(lastWriteTime);
                    }
                }

                string logMessage = FormatLogMessage(level, message);
                File.AppendAllText(_currentFileName, logMessage + Environment.NewLine);
            }
        }

        private void RollOverLogFile(DateTime lastWriteTime)
        {
            lock (Lock)
            {
                if (File.Exists(_currentFileName))
                {
                    string newFileName = $"{ProgramName}-{lastWriteTime:yyyy-MM-dd}.log";
                    File.Move(_currentFileName, newFileName);
                }

                _currentFileName = _baseFileName;
            }
        }
    }

    public class Logger
    {	
        public enum Level 
        {
            info,
            debug
        }

        private static List<ILogWriter> LogWriters = null;
        private static Level level = Level.info;


        protected static void Init()
        {
            if (LogWriters == null)
            {
                string logWriterNames = Config.getString("logwriters");
                
                LogWriters = CreateLogWriters(logWriterNames);

                string logLevel = Config.getString("loglevel").ToLower();
                if (logLevel == "debug")
                {
                        level = Level.debug;
                }
            }

        }

        public static List<ILogWriter> CreateLogWriters(string logWriterClasses)
        {
            var logWriters = new List<ILogWriter>();
            var classNames = logWriterClasses.Split(',');

            foreach (var className in classNames)
            {
                var type = Assembly.GetExecutingAssembly().GetType(className);
                if (type == null || !typeof(ILogWriter).IsAssignableFrom(type))
                {
                    throw new InvalidOperationException($"Class {className} does not exist or does not implement ILogWriter.");
                }

                var instance = Activator.CreateInstance(type) as ILogWriter;
                if (instance != null)
                {
                    logWriters.Add(instance);
                }
            }

            return logWriters;
        }

        public static void Error(string message)
        {
            Init();
            Write("ERROR", message);
        }
        
        public static void Error(string message, Exception x)
        {
            Init();
            string m = string.Empty;
            string s = string.Empty;

            while (x != null)
            {
                m += x.Message;
                m += "\n";
                s += x.StackTrace;
                s += "\n";				
                x = x.InnerException;
            }
            
            Write("ERROR", m + "\n" + s);
        }

        public static void Info( string message )
        {
            Init();
            Write("INFO", message );
        }


        public static void Debug( string message )
        {
            Init();

            if (level == Level.debug) 
            {
                Write("DEBUG", message );
            }
        }

        private static void Write( string level, string message )
        {
            foreach( var logWriter in LogWriters)
            {
                logWriter.Write(level, message);
            }
        }
    }

    public class LogTableWriter : BaseLogWriter, ILogWriter
    {
        public void Write(string level, string message)
        {

            lock (Lock)
            {
                string sql = string.Empty;
                try
                {
                    string connectionStr = Config.getString("db.connection");
                    NpgsqlConnection connection = new NpgsqlConnection(connectionStr);
                    connection.Open();

                   
                    sql = "INSERT INTO audit.log (level, message, timestamp, username, program) " +
                                "VALUES (@level, @message, @timestamp, @username, @program);";

                    using var command = new NpgsqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@level", level);
                    command.Parameters.AddWithValue("@message", message);
                    command.Parameters.AddWithValue("@timestamp", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@username", Environment.UserName);
                    command.Parameters.AddWithValue("@program", ProgramName);
            
                    command.ExecuteNonQuery();
                        
                            
                    
                }
                catch(Exception x)
                {
                    Console.Error.WriteLine(x.Message + ": " + sql);
                }
            }
        }
    }

    public class LogConsoleWriter : BaseLogWriter, ILogWriter
    {
        public void Write(string level, string message)
        {
            lock (Lock)
            {
                string logMessage = FormatLogMessage(level, message);
								
                Console.WriteLine(logMessage);
            }
        }
    }

}