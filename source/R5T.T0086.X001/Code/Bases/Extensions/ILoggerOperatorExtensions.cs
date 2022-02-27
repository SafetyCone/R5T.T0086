using System;
using System.IO;
using System.Text;

using Microsoft.Extensions.Logging;

using R5T.Magyar;

using R5T.T0086;

using IMicrosoftLogger = Microsoft.Extensions.Logging.ILogger;

using Instances = R5T.T0086.X001.Instances;


namespace System
{
    public static class ILoggerOperatorExtensions
    {
        public static bool IsEnabled(this ILoggerOperator _, LogLevel logLevel,
            string name,
            Func<string, LogLevel, bool> filter)
        {
            if (logLevel == LogLevel.None)
            {
                return false;
            }

            var output = filter(name, logLevel);
            return output;
        }

        public static Func<string, LogLevel, bool> GetTrueFilter(this ILoggerOperator _)
        {
            static bool Output(string categoryName, LogLevel logLevel)
            {
                return true;
            }

            return Output;
        }

        public static Func<string, LogLevel, bool> GetFalseFilter(this ILoggerOperator _)
        {
            static bool Output(string categoryName, LogLevel logLevel)
            {
                return false;
            }

            return Output;
        }

        public static void TestLogLevelOutput(this ILoggerOperator _,
            IMicrosoftLogger logger)
        {
            logger.LogTrace("Trace");
            logger.LogDebug("Debug");
            logger.LogInformation("Information");
            logger.LogWarning("Warning");
            logger.LogError("Error");
            logger.LogCritical("Critical");
        }

        public static void TestLogLevelEnabled(this ILoggerOperator _,
            IMicrosoftLogger logger,
            TextWriter textWriter)
        {
            var allLogLevels = Instances.LogLevelOperator.GetLogLevels();

            foreach (var logLevel in allLogLevels)
            {
                _.TestLogLevelEnabled(logger, textWriter, logLevel);
            }
        }

        public static void TestLogLevelEnabled(this ILoggerOperator _,
            IMicrosoftLogger logger,
            TextWriter textWriter,
            LogLevel logLevel)
        {
            var levelIsEnabled = logger.IsEnabled(logLevel);

            var enabledDescription = levelIsEnabled
                ? "enabled"
                : "disabled"
                ;

            var message = $"{logLevel}: {enabledDescription}";

            textWriter.WriteLine(message);
        }

        public static void AppendLogMessageTextWithoutLogLevel(this ILoggerOperator _,
            StringBuilder logBuilder,
            string logName, int eventId, string message, Exception exception)
        {
            // Category and Event ID. Example:
            //
            // INFO: ConsoleApp.Program[10]
            //       Request received

            var logLevelPadding = ": ";

            logBuilder.Append(logLevelPadding)
                .Append(logName)
                .Append(Characters.OpenBrace)
                .Append(eventId)
                .Append(Characters.CloseBrace)
                .AppendLine()
                ;

            // Message
            if (StringHelper.IsNotNullOrEmpty(message))
            {
                var messageTabinationCount = 6;
                var messageTabination = new String(Characters.Space, messageTabinationCount);

                logBuilder.Append(messageTabination);

                // Indent all new lines in the message.
                var length = logBuilder.Length;

                logBuilder.AppendLine(message);
                logBuilder.Replace(Environment.NewLine, Environment.NewLine + messageTabination, length, message.Length);
            }

            // Exception message. Example:
            //
            // System.InvalidOperationException
            //    at Namespace.Class.Function() in File:line X

            if (exception != null)
            {
                logBuilder.AppendLine(exception.ToString());
            }
        }

        public static string GetLogMessageTextWithoutLogLevel(this ILoggerOperator _,
            string logName, int eventId, string message, Exception exception)
        {
            var output = new StringBuilder()
                .GetString(logBuilder =>
                {
                    _.AppendLogMessageTextWithoutLogLevel(logBuilder,
                        logName, eventId, message, exception);
                });

            return output;
        }

        public static void AppendLogMessageTextWithLogLevel(this ILoggerOperator _,
            StringBuilder logBuilder,
            LogLevel logLevel, string logName, int eventId, string message, Exception exception)
        {
            var logLevelString = Instances.LogLevelOperator.GetLogLevelShortName(logLevel);

            logBuilder.Append(logLevelString);

            _.AppendLogMessageTextWithoutLogLevel(logBuilder,
                logName, eventId, message, exception);
        }

        public static string GetLogMessageTextWithLogLevel(this ILoggerOperator _,
            LogLevel logLevel, string logName, int eventId, string message, Exception exception)
        {
            var output = new StringBuilder()
                .GetString(logBuilder =>
                {
                    _.AppendLogMessageTextWithLogLevel(logBuilder,
                        logLevel, logName, eventId, message, exception);
                });

            return output;
        }

        /// <summary>
        /// Chooses <see cref="GetLogMessageTextWithLogLevel(ILoggerOperator, LogLevel, string, int, string, Exception)"/> as the default.
        /// </summary>
        public static string GetLogMessageText(this ILoggerOperator _,
            LogLevel logLevel, string logName, int eventId, string message, Exception exception)
        {
            var output = _.GetLogMessageTextWithLogLevel(
                logLevel, logName, eventId, message, exception);

            return output;
        }
    }
}
