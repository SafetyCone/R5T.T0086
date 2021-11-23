using System;


namespace R5T.T0086
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class LogLevelOperator : ILogLevelOperator
    {
        #region Static
        
        public static LogLevelOperator Instance { get; } = new();

        #endregion
    }
}