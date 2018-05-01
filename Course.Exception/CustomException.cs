using System.Net;

namespace Course.Exception
{
    public class CustomException : System.Exception
    {
        public HttpStatusCode Code { get; }

        public CustomException() : base()
        {
        }

        public CustomException(HttpStatusCode code)
        {
            Code = code;
        }

        public CustomException(HttpStatusCode code, string message)
            : base(message)
        {
            Code = code;
        }

        public CustomException(HttpStatusCode code, string message, System.Exception innerException)
            : base(message, innerException)
        {
            Code = code;
        }
    }
}