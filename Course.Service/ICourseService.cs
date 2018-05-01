﻿using Course.Model;

namespace Course.Service
{
    public interface ICourseService
    {
        void CourseSignup(int courseId, int studentId);

        bool CheckCourseCapacity(int courseId);

        CourseReport CourseReport(int courseId);
    }
}