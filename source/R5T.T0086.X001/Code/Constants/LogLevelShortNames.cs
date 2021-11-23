using System;


namespace R5T.T0086.X001
{
    /// <summary>
    /// See: https://github.com/aspnet/Logging/blob/2d2f31968229eddb57b6ba3d34696ef366a6c71b/src/Microsoft.Extensions.Logging.Console/ConsoleLogger.cs#L227
    /// </summary>
    public static class LogLevelShortNames
    {
        public static string None => "none";

        public static string Trace => "trce";
        public static string Debug => "dbug";
        public static string Information => "info";
        public static string Warning => "warn";
        public static string Error => "fail";
        public static string Critical => "crit";
    }
}
