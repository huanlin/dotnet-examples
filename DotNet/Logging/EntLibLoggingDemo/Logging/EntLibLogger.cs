using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Diagnostics;

namespace EntLibLoggingDemo.Logging
{
    public class EntLibLogger : ILog
    {
        static EntLibLogger()
        {
            // If you are using EntLib v5, the folowing two statements must be commented.
            var logWriter = new LogWriterFactory().Create();
            Logger.SetLogWriter(logWriter);
        }

        private string _logName;

        public EntLibLogger()
        {
            _logName = String.Empty;
        }

        public EntLibLogger(Type type)
        {
            _logName = type.FullName;
        }

        public EntLibLogger(string typeName)
        {
            _logName = typeName;
        }

        private LogEntry NewLogEntry(object message, TraceEventType severity = TraceEventType.Verbose)
        {
            LogEntry entry = new LogEntry();
            entry.Message = message == null? String.Empty : message.ToString();
            entry.EventId = 100;
            entry.Categories = new string[] { _logName };
            entry.Severity = severity;
            return entry;
        }

        public void Debug(object message)
        {
            if (!Logger.IsLoggingEnabled())
                return;
            
            var entry = NewLogEntry(message, TraceEventType.Verbose);
            Logger.Write(entry);
        }

        public void Debug(object message, Exception exception)
        {
            if (!Logger.IsLoggingEnabled())
                return;
            
            var entry = NewLogEntry(message, TraceEventType.Verbose);
            entry.AddErrorMessage(exception.GetBaseException().ToString());

            Logger.Write(entry);            
        }

        public void DebugFormat(string format, params object[] args)
        {
            if (!Logger.IsLoggingEnabled())
                return;

            string message = String.Format(format, args);
            var entry = NewLogEntry(message, TraceEventType.Verbose);            

            Logger.Write(entry);            
        }

        public void Error(object message)
        {
            if (!Logger.IsLoggingEnabled())
                return;

            var entry = NewLogEntry(message, TraceEventType.Error);

            Logger.Write(entry);            
        }

        public void Error(object message, Exception exception)
        {
            if (!Logger.IsLoggingEnabled())
                return;
            
            var entry = NewLogEntry(message, TraceEventType.Error);
            entry.AddErrorMessage(exception.GetBaseException().ToString());

            Logger.Write(entry);            
        }

        public void ErrorFormat(string format, params object[] args)
        {
            if (!Logger.IsLoggingEnabled())
                return;

            string message = String.Format(format, args);
            var entry = NewLogEntry(message, TraceEventType.Error);

            Logger.Write(entry);            
        }

        public void Fatal(object message)
        {
            if (!Logger.IsLoggingEnabled())
                return;

            var entry = NewLogEntry(message, TraceEventType.Critical);

            Logger.Write(entry);            
        }

        public void Fatal(object message, Exception exception)
        {
            if (!Logger.IsLoggingEnabled())
                return;

            var entry = NewLogEntry(message, TraceEventType.Critical);
            entry.AddErrorMessage(exception.GetBaseException().ToString());

            Logger.Write(entry);            

        }

        public void FatalFormat(string format, params object[] args)
        {
            if (!Logger.IsLoggingEnabled())
                return;

            string message = String.Format(format, args);
            var entry = NewLogEntry(message, TraceEventType.Critical);

            Logger.Write(entry);
        }

        public void Info(object message)
        {
            if (!Logger.IsLoggingEnabled())
                return;

            var entry = NewLogEntry(message, TraceEventType.Information);

            Logger.Write(entry);            
        }

        public void Info(object message, Exception exception)
        {
            if (!Logger.IsLoggingEnabled())
                return;

            var entry = NewLogEntry(message, TraceEventType.Error);
            entry.AddErrorMessage(exception.GetBaseException().ToString());

            Logger.Write(entry);            
        }

        public void InfoFormat(string format, params object[] args)
        {
            if (!Logger.IsLoggingEnabled())
                return;

            string message = String.Format(format, args);
            var entry = NewLogEntry(message, TraceEventType.Information);

            Logger.Write(entry);
        }

        public void Warn(object message)
        {
            if (!Logger.IsLoggingEnabled())
                return;

            var entry = NewLogEntry(message, TraceEventType.Warning);

            Logger.Write(entry);
        }

        public void Warn(object message, Exception exception)
        {
            if (!Logger.IsLoggingEnabled())
                return;

            var entry = NewLogEntry(message, TraceEventType.Warning);
            entry.AddErrorMessage(exception.GetBaseException().ToString());

            Logger.Write(entry);            
        }

        public void WarnFormat(string format, params object[] args)
        {
            if (!Logger.IsLoggingEnabled())
                return;

            string message = String.Format(format, args);
            var entry = NewLogEntry(message, TraceEventType.Warning);

            Logger.Write(entry);            
        }
    }
}
