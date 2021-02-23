using System;

namespace QRFoodyWa.Helpers
{
    public interface ILog
    {
        string LogException(Exception exception);

        string LogEvent(string @event, string message);
    }
}