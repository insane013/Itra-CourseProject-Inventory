using Microsoft.Extensions.Logging;

namespace Course.Services.Logging;

public partial class CommonLogs
{
    [LoggerMessage(EventId = 0, Level = LogLevel.Warning, Message = "{message}")]
    public static partial void LogWarningMessage(ILogger logger, string message);
}
