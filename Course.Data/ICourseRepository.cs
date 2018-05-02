using Course.Model;

namespace Course.Data
{
    public interface ICourseRepository
    {
        void CourseSignup(int courseId, int studentId);

        bool CheckCourseCapacity(int courseId);

        CourseReport CourseReport(int courseId);
    }
}