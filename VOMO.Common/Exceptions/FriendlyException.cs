using System;
using System.Net;

namespace VOMO.Common.Exceptions
{
    public class FriendlyException : VomoException
    {
        public readonly string FriendlyMessage;

        public FriendlyException(Constants.ExceptionSeverity severity, string friendlyMessage, string message)
            : base(severity, message)
        {
            FriendlyMessage = friendlyMessage;
        }

        public FriendlyException(Constants.ExceptionSeverity severity, string friendlyMessage, string message, Exception exception)
            : base(severity, message, exception)
        {
            FriendlyMessage = friendlyMessage;
        }

        public FriendlyException(HttpStatusCode statusCode, Constants.ExceptionSeverity severity, string friendlyMessage, string message)
            : base(statusCode, severity, message)
        {
            FriendlyMessage = friendlyMessage;
        }

        public FriendlyException(HttpStatusCode statusCode, Constants.ExceptionSeverity severity, string friendlyMessage, string message, Exception exception)
            : base(statusCode, severity, message, exception)
        {
            FriendlyMessage = friendlyMessage;
        }
    }

}
