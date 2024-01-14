using System.Diagnostics.CodeAnalysis;

namespace Play_investe.Logging
{
    [ExcludeFromCodeCoverage]
    public class CustomLoggerProviderConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
        public int EventId { get; set; } = 0;
    }
}
