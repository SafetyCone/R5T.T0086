using System;


namespace R5T.T0086
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class LogLevelName : ILogLevelName
    {
        #region Static
        
        public static LogLevelName Instance { get; } = new();

        #endregion
    }
}