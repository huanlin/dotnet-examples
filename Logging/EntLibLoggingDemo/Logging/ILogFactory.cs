using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLibLoggingDemo.Logging
{
    public interface ILogFactory
    {
        ILog GetLogger();

        /// <summary>
        /// Gets the logger.
        /// </summary>
        ILog GetLogger(Type type);

        /// <summary>
        /// Gets the logger.
        /// </summary>
        ILog GetLogger(string typeName);
    }
}
