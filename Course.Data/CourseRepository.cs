﻿using Course.Model;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Data
{
    public class CourseRepository : BaseRepository, ICourseRepository
    {
        public async Task CourseSignup(int courseId, string student, int age)
        {
            using (var db = new SqlConnection(Connstring))
            {
                const string sql = @"SP_COURSESIGNUP";

                await db.ExecuteAsync(sql, new { CourseId = courseId, Student = student, Age = age }, commandType: CommandType.StoredProcedure);
            }
        }

        public bool CheckCourseCapacity(int courseId)
        {
            int capacity;
            using (var db = new SqlConnection(Connstring))
            {
                const string sql = @"SELECT StudentLimit FROM Course WHERE Id = @courseId AND StudentLimit > (SELECT COUNT(*) FROM CourseStudent WHERE CourseId = @CourseID)";

                capacity = db.Query<int>(sql, new { CourseId = courseId }, commandType: CommandType.Text).SingleOrDefault();
            }
            return capacity > 0;
        }

        public CourseReport CourseReport(int courseId)
        {
            CourseReport ret;
            using (var db = new SqlConnection(Connstring))
            {
                const string sql = @"SELECT MIN(Age) AS AgeMin, MAX(Age) AS AgeMax, AVG(Age) AS AgeAvg,
                                C.Id, C.Name, C.StudentLimit,
                                T.Id, T.Name FROM Student S
                                INNER JOIN CourseStudent CS on CS.StudentId = S.Id
                                INNER JOIN Course C on C.Id = CS.CourseId
                                INNER JOIN Teacher T on T.Id = C.TeacherId
                                WHERE CS.CourseId = @CourseId
                                group by C.Id, C.Name, C.StudentLimit, T.Id, T.Name";

                ret = db.Query<CourseReport, Model.Course, Teacher, CourseReport>(sql, (coursereport, course, teacher) =>
                    {
                        coursereport.Course = course;
                        coursereport.Course.Teacher = teacher;
                        return coursereport;
                    }, splitOn: "Id, Id", param: new { CourseId = courseId }, commandType: CommandType.Text).SingleOrDefault();
            }
            return ret;
        }
    }
}