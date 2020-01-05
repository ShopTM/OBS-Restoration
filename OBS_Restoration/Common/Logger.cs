using NLog;
using System;
using System.Runtime.CompilerServices;

namespace Common.Log
{
    public sealed class Logger
    {
        private static NLog.Logger logger;
        private const string logFormat = @"{0}-{1} : {2}";

        /// <summary>
        ///     Default constructor
        /// </summary>
        private Logger()
        {
        }

        /// <summary>
        ///     An instance of a NLog Logger.
        /// </summary>
        private static NLog.Logger NLogger
        {
            get
            {
                if (logger == null)
                {
                    logger = LogManager.GetLogger("logLogger");
                }
                return logger;
            }
        }

        /// <summary>
        ///     Method that logs debug message
        /// </summary>
        /// <param name="message">The message</param>
        public static void LogDebug(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            var className = getClassNameFromPath(sourceFilePath);
            NLogger.Debug(string.Format(logFormat, className, memberName, message));
        }

        /// <summary>
        ///     Method that logs debug exception and message
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="pException">The exception object to log</param>
        public static void LogDebugException(string message, Exception pException, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            var className = getClassNameFromPath(sourceFilePath);
#pragma warning disable CS0618 // 'Logger.Debug(string, Exception)' is obsolete: 'Use Debug(Exception exception, string message, params object[] args) method instead.'
            NLogger.Debug(string.Format(logFormat, className, memberName, message), pException);
#pragma warning restore CS0618 // 'Logger.Debug(string, Exception)' is obsolete: 'Use Debug(Exception exception, string message, params object[] args) method instead.'
        }

        /// <summary>
        ///     Method that logs error message
        /// </summary>
        /// <param name="message">The message to log</param>
        public static void LogError(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            var className = getClassNameFromPath(sourceFilePath);
            NLogger.Error(string.Format(logFormat, className, memberName, message));
        }

        /// <summary>
        ///     Method that logs error message and exception
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="exception">The exception object to log</param>
        public static void LogErrorException(string message, Exception exception, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            var className = getClassNameFromPath(sourceFilePath);
            NLogger.Error(exception, string.Format(logFormat, className, memberName, message));
        }

        /// <summary>
        ///     Method that logs fatal error message
        /// </summary>
        /// <param name="message">The message to log</param>
        public static void LogFatal(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            var className = getClassNameFromPath(sourceFilePath);
            NLogger.Fatal(string.Format(logFormat, className, memberName, message));
        }

        /// <summary>
        ///     Method that logs fatal error message and exception
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="exception">The exception object to log</param>
        public static void LogFatalException(string message, Exception exception, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            var className = getClassNameFromPath(sourceFilePath);
#pragma warning disable CS0618 // 'Logger.Fatal(string, Exception)' is obsolete: 'Use Fatal(Exception exception, string message, params object[] args) method instead.'
            NLogger.Fatal(string.Format(logFormat, className, memberName, message), exception);
#pragma warning restore CS0618 // 'Logger.Fatal(string, Exception)' is obsolete: 'Use Fatal(Exception exception, string message, params object[] args) method instead.'
        }

        /// <summary>
        ///     Method that logs info message
        /// </summary>
        /// <param name="message">The message to log</param>
        public static void LogInfo(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            var className = getClassNameFromPath(sourceFilePath);
            NLogger.Info(string.Format(logFormat, className, memberName, message));
        }

        /// <summary>
        ///     Method that logs info message and exception
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="exception">The exception object to log</param>
        public static void LogInfoException(string message, Exception exception, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            var className = getClassNameFromPath(sourceFilePath);
#pragma warning disable CS0618 // 'Logger.Info(string, Exception)' is obsolete: 'Use Info(Exception exception, string message, params object[] args) method instead.'
            NLogger.Info(string.Format(logFormat, className, memberName, message), exception);
#pragma warning restore CS0618 // 'Logger.Info(string, Exception)' is obsolete: 'Use Info(Exception exception, string message, params object[] args) method instead.'
        }

        /// <summary>
        ///     Method that logs warn message
        /// </summary>
        /// <param name="messag">The message to log</param>
        public static void LogWarn(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            var className = getClassNameFromPath(sourceFilePath);
            NLogger.Warn(string.Format(logFormat, className, memberName, message));
        }

        /// <summary>
        ///     Method that logs warn message and exception
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="exception">The exception object to log</param>
        public static void LogWarnException(string message, Exception exception, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            var className = getClassNameFromPath(sourceFilePath);
#pragma warning disable CS0618 // 'Logger.Warn(string, Exception)' is obsolete: 'Use Warn(Exception exception, string message, params object[] args) method instead.'
            NLogger.Warn(string.Format(logFormat, className, memberName, message), exception);
#pragma warning restore CS0618 // 'Logger.Warn(string, Exception)' is obsolete: 'Use Warn(Exception exception, string message, params object[] args) method instead.'
        }

        /// <summary>
        ///     Method that logs trace message
        /// </summary>
        /// <param name="message">The message to log</param>
        public static void LogTrace(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            var className = getClassNameFromPath(sourceFilePath);
            NLogger.Trace(string.Format(logFormat, className, memberName, message));
        }

        /// <summary>
        ///     Method that logs trace message and exception
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="exception">The exception object to log</param>
        public static void LogTraceException(string message, Exception exception, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            var className = getClassNameFromPath(sourceFilePath);
#pragma warning disable CS0618 // 'Logger.Warn(string, Exception)' is obsolete: 'Use Warn(Exception exception, string message, params object[] args) method instead.'
            NLogger.Trace(string.Format(logFormat, className, memberName, message), exception);
#pragma warning restore CS0618 // 'Logger.Trace(string, Exception)' is obsolete: 'Use Trace(Exception exception, string message, params object[] args) method instead.'
        }


        private static string getClassNameFromPath(string classPath)
        {
            return string.IsNullOrWhiteSpace(classPath) ? "" : System.IO.Path.GetFileNameWithoutExtension(classPath);
        }
    }
}
