using System.Collections.Generic;
using System.Linq;

namespace CoursesAutomation
{
    public class CoursesByRoom
    {
        public List<CourseAttributes> NotValidCourses;
        public List<CourseAttributes> ValidCourses;

        public CoursesByRoom()
        {
            NotValidCourses = new List<CourseAttributes>();
            ValidCourses = new List<CourseAttributes>();
        }

        public void AddValueToNotValid(CourseAttributes course)
        {
            var exists = NotValidCourses.FirstOrDefault(c => c.Seccion == course.Seccion);
            if (exists != null)
            {
                return;
            }
            NotValidCourses.Add(course);
        }

        public void AddValueToValid(CourseAttributes course)
        {
            var exists = ValidCourses.FirstOrDefault(c => c.Seccion == course.Seccion);
            if (exists != null)
            {
                return;
            }
            ValidCourses.Add(course);
        }
    }
}
