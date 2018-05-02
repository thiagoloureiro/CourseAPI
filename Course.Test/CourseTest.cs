using Course.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Course.Test
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void CheckCourseCapacityNotFull()
        {
            var obj = new CourseRepository();
            var ret = obj.CheckCourseCapacity(2);
            Assert.IsTrue(ret);
        }

        [TestMethod]
        public void CheckCourseCapacityFull()
        {
            var obj = new CourseRepository();
            var ret = obj.CheckCourseCapacity(1);
            Assert.IsTrue(!ret);
        }
    }
}