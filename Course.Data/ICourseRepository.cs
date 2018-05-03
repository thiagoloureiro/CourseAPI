using System.Threading.Tasks;
using Course.Model;

namespace Course.Data
{
    public interface ICourseRepository
    {
        Task CourseSignup(int courseId, string student, int age);

        bool CheckCourseCapacity(int courseId);

        CourseReport CourseReport(int courseId);
    }
}