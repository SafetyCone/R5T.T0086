using System;


namespace R5T.T0086.X001
{
    public static class Instances
    {
        public static ILogLevelName LogLevelName { get; } = T0086.LogLevelName.Instance;
        public static ILogLevelOperator LogLevelOperator { get; } = T0086.LogLevelOperator.Instance;
    }
}
