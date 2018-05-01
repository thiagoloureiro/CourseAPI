using System.Collections.Generic;

namespace Course.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentLimit { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
    }
}