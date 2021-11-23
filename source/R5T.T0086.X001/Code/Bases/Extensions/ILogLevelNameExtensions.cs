using System;

using R5T.T0086;
using R5T.T0086.X001;


namespace System
{
    public static class ILogLevelNameExtensions
    {
        public static string TraceShort(this ILogLevelName _)
        {
            return LogLevelShortNames.Trace;
        }

        public static string DebugShort(this ILogLevelName _)
        {
            return LogLevelShortNames.Debug;
        }

        public static string InformationShort(this ILogLevelName _)
        {
            return LogLevelShortNames.Information;
        }

        public static string WarningShort(this ILogLevelName _)
        {
            return LogLevelShortNames.Warning;
        }

        public static string ErrorShort(this ILogLevelName _)
        {
            return LogLevelShortNames.Error;
        }

        public static string CriticalShort(this ILogLevelName _)
        {
            return LogLevelShortNames.Critical;
        }

        public static string NoneShort(this ILogLevelName _)
        {
            return LogLevelShortNames.None;
        }
    }
}