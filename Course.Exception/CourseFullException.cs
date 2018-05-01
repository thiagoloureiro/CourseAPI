using System.Net;

namespace Course.Exception
{
    public class CourseFullException : CustomException
    {
        private const HttpStatusCode DefaultCode = HttpStatusCode.Unauthorized;
        public const string DefaultMessage = "Course Full";

        public CourseFullException() : base(DefaultCode, DefaultMessage)
        {
        }

        public CourseFullException(System.Exception innerException) : base(DefaultCode, DefaultMessage)
        {
        }
    }
}