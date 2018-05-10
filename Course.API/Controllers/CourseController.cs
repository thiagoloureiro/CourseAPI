using System;
using System.Threading.Tasks;
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
        public async Task<IHttpActionResult> CourseSignup(int courseId, string student, int age)
        {
            await _courseService.CourseSignup(courseId, student, age);
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