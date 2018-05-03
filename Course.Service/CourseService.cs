using System.Threading.Tasks;
using Course.Data;
using Course.Exception;
using Course.Model;
using TestaCache.Cache;

namespace Course.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [AffectedCacheableMethods("CourseReport")]
        public async Task CourseSignup(int courseId, string student, int age)
        {
            if (_courseRepository.CheckCourseCapacity(courseId))
                await _courseRepository.CourseSignup(courseId, student, age);
            else
                throw new CourseFullException();
        }

        public bool CheckCourseCapacity(int courseId)
        {
            return _courseRepository.CheckCourseCapacity(courseId);
        }

        [CacheableResult(600)]
        public CourseReport CourseReport(int courseId)
        {
            return _courseRepository.CourseReport(courseId);
        }
    }
}