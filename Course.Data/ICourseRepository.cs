using System.Threading.Tasks;
using Course.Model;

namespace Course.Data
{
    public interface ICourseRepository
    {
        Task CourseSignup(int courseId, int studentId);

        bool CheckCourseCapacity(int courseId);

        CourseReport CourseReport(int courseId);
    }
}