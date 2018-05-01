using System;
using System.Web.Http;
using Course.Service;

namespace Course.API.Controllers
{
    public class CourseController : ApiController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        [Route("signup")]
        public IHttpActionResult CourseSignup(int courseId, int studentId)
        {
            _courseService.CourseSignup(courseId, studentId);
            return Ok();
        }

        [HttpGet]
        [Route("report")]
        public IHttpActionResult CourseReport(int courseId)
        {
            return Json(_courseService.CourseReport(courseId));
        }
    }
}