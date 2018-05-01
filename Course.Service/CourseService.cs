﻿using Course.Data;
using Course.Exception;
using Course.Model;

namespace Course.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void CourseSignup(int courseId, int studentId)
        {
            if (_courseRepository.CheckCourseCapacity(courseId))
                _courseRepository.CourseSignup(courseId, studentId);
            else
                throw new CourseFullException();
        }

        public bool CheckCourseCapacity(int courseId)
        {
            return _courseRepository.CheckCourseCapacity(courseId);
        }

        public CourseReport CourseReport(int courseId)
        {
            return _courseRepository.CourseReport(courseId);
        }
    }
}