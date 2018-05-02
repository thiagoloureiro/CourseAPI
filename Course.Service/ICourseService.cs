using System.Threading.Tasks;
using Course.Model;

namespace Course.Service
{
    public interface ICourseService
    {
        Task CourseSignup(int courseId, int studentId);

        bool CheckCourseCapacity(int courseId);

        CourseReport CourseReport(int courseId);
    }
}