using System;


namespace R5T.T0086
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class LoggerOperator : ILoggerOperator
    {
        #region Static
        
        public static LoggerOperator Instance { get; } = new();

        #endregion
    }
}