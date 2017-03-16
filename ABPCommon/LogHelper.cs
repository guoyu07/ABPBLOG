using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCommon
{
    public class LogHelper
    {
        public static void debug(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("LogOut");
            if (log.IsDebugEnabled)
            {
                log.Debug(message);
            }
            log = null;
        }

        public static void error(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("LogOut");
            if (log.IsErrorEnabled)
            {
                log.Error(message);
            }
            log = null;
        }

        public static void fatal(string message)
        {

            log4net.ILog log = log4net.LogManager.GetLogger("LogOut");
            if (log.IsFatalEnabled)
            {
                log.Fatal(message);
            }
            log = null;
        }
        public static void info(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("LogOut");
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
            log = null;
        }

        public static void warn(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("LogOut");
            if (log.IsWarnEnabled)
            {
                log.Warn(message);
            }
            log = null;
        }
    }
}
