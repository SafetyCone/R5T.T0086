using System;


namespace R5T.T0086
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class Logger : ILogger
    {
        #region Static
        
        public static Logger Instance { get; } = new();

        #endregion
    }
}