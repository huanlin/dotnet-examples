using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntLibLoggingDemo.Logging
{
    public class EntLibLogFactory : ILogFactory
    {
        private readonly string _defaultCategoryName;

        public EntLibLogFactory()
        {
            _defaultCategoryName = String.Empty;
        }

        public EntLibLogFactory(string defaultCategoryName)
        {
            _defaultCategoryName = defaultCategoryName;
        }

        public ILog GetLogger()
        {
            if (String.IsNullOrEmpty(_defaultCategoryName))
            {
                string callerClassName = GetCallerClassFullName();
                return new EntLibLogger(callerClassName);
            }
            return new EntLibLogger(_defaultCategoryName);
        }

        public ILog GetLogger(Type type)
        {
            return new EntLibLogger(type);
        }

        public ILog GetLogger(string typeName)
        {
            return new EntLibLogger(typeName);
        }

        /// <summary>
        /// Gets the fully qualified name of the class invoking the LogManager, including the 
        /// namespace but not the assembly.    
        /// </summary>
        private static string GetCallerClassFullName()
        {
            string className;
            Type declaringType;
            int framesToSkip = 2;

            do
            {
                StackFrame frame = new StackFrame(framesToSkip, false);
                MethodBase method = frame.GetMethod();
                declaringType = method.DeclaringType;
                if (declaringType == null)
                {
                    className = method.Name;
                    break;
                }

                framesToSkip++;
                className = declaringType.FullName;
            } while (declaringType.Module.Name.Equals("mscorlib.dll", StringComparison.OrdinalIgnoreCase));

            return className;
        }
    }
}
