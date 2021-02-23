using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;


namespace QRFoodyWa.Helpers
{
    public class Log : ILog
    {
        #region Constructors

        public Log(ISettings settings)
        {
            this._settings = settings ?? throw new ArgumentNullException("settings", "log Settings cannot be null.");
            this.telemetryClient = new TelemetryClient();
        }

        #endregion

        #region Private Members

        private readonly TelemetryClient telemetryClient;

        private readonly ISettings _settings;

        #endregion

        #region Behavior

        public string LogException(Exception exception)
        {
            var guid = Guid.NewGuid().ToString();

            var properties = new Dictionary<string, string>
            {
                { "Application", _settings.GetApplicationName() },
                { "ErrorId", guid }
            };

            var key = telemetryClient.InstrumentationKey;

            telemetryClient.TrackException(exception, properties);

            return guid;
        }

        public string LogEvent(string @event, string message)
        {
            var guid = Guid.NewGuid().ToString();

            var properties = new Dictionary<string, string> {
                { "Message", message }
            };

            telemetryClient.TrackEvent(@event, properties);

            return guid;
        }

        #endregion
    }
}