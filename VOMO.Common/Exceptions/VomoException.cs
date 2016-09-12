using System;
using System.Net;

namespace VOMO.Common.Exceptions
{
    public class VomoException : Exception
    {
        public readonly Constants.ExceptionSeverity Severity;
        public readonly HttpStatusCode StatusCode;

        public VomoException(Constants.ExceptionSeverity severity, string message)
            : base(message)
        {
            StatusCode = HttpStatusCode.InternalServerError;
            Severity = severity;
        }

        public VomoException(Constants.ExceptionSeverity severity, string message, Exception exception)
            : base(message, exception)
        {
            StatusCode = HttpStatusCode.InternalServerError;
            Severity = severity;
        }


        public VomoException(HttpStatusCode statusCode, Constants.ExceptionSeverity severity, string message)
            : base(message)
        {
            StatusCode = statusCode;
            Severity = severity;
        }

        public VomoException(HttpStatusCode statusCode, Constants.ExceptionSeverity severity, string message, Exception exception)
            : base(message, exception)
        {
            StatusCode = statusCode;
            Severity = severity;
        }
    }

}
