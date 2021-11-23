using System;

using Microsoft.Extensions.Logging;

using R5T.Magyar;

using R5T.T0086;
using R5T.T0086.X001;

using Instances = R5T.T0086.X001.Instances;


namespace System
{
    public static class ILogLevelOperatorExtensions
    {
        /// <summary>
        /// All log levels includes <see cref="LogLevel.None"/>.
        /// </summary>
        public static LogLevel[] GetAllLogLevelsInAscendingOrder(this ILogLevelOperator _)
        {
            var output = new[]
            {
                LogLevel.Trace,
                LogLevel.Debug,
                LogLevel.Information,
                LogLevel.Warning,
                LogLevel.Error,
                LogLevel.Critical,
                LogLevel.None
            };

            return output;
        }

        /// <summary>
        /// Usable log levels does not include <see cref="LogLevel.None"/>.
        /// </summary>
        public static LogLevel[] GetUsableLogLevelsInAscendingOrder(this ILogLevelOperator _)
        {
            var output = new[]
            {
                LogLevel.Trace,
                LogLevel.Debug,
                LogLevel.Information,
                LogLevel.Warning,
                LogLevel.Error,
                LogLevel.Critical
            };

            return output;
        }

        /// <summary>
        /// Chooses usable log levels, in ascending order as the default.
        /// </summary>
        public static LogLevel[] GetLogLevels(this ILogLevelOperator _)
        {
            var output = _.GetUsableLogLevelsInAscendingOrder();
            return output;
        }

        public static string GetLogLevelShortName(this ILogLevelOperator _, LogLevel logLevel)
        {
            var output = logLevel switch
            {
                LogLevel.Trace => Instances.LogLevelName.TraceShort(),
                LogLevel.Debug => Instances.LogLevelName.DebugShort(),
                LogLevel.Information => Instances.LogLevelName.InformationShort(),
                LogLevel.Warning => Instances.LogLevelName.WarningShort(),
                LogLevel.Error => Instances.LogLevelName.ErrorShort(),
                LogLevel.Critical => Instances.LogLevelName.CriticalShort(),
                _ => throw EnumerationHelper.SwitchDefaultCaseException(logLevel),
            };

            return output;
        }
    }
}
