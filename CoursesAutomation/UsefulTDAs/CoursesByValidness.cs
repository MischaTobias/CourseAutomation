using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursesAutomation
{
    public class CoursesByValidness
    {
        public List<CourseAttributes> NotValidCourses;
        public List<CourseAttributes> ValidCourses;

        public CoursesByValidness()
        {
            NotValidCourses = new List<CourseAttributes>();
            ValidCourses = new List<CourseAttributes>();
        }

        public void AddValueToNotValid(CourseAttributes course)
        {
            var exists = NotValidCourses.FirstOrDefault(c => c.Seccion == course.Seccion);
            if (exists != null)
            {
                if (!exists.Horarios.Contains(course.Horarios))
                {
                    exists.Horarios += $"{Environment.NewLine}{course.Horarios}";
                }
                return;
            }
            NotValidCourses.Add(course);
        }

        public void AddValueToValid(CourseAttributes course)
        {
            var exists = ValidCourses.FirstOrDefault(c => c.Seccion == course.Seccion);
            if (exists != null)
            {
                if (!exists.Horarios.Contains(course.Horarios))
                {
                    exists.Horarios += $"{Environment.NewLine}{course.Horarios}";
                }
                return;
            }
            ValidCourses.Add(course);
        }

        public static void AddCourse(CourseAttributes course)
        {
            AddByRoom(course);
            AddByQueue(course);
        }

        private static void AddByRoom(CourseAttributes course)
        {
            Storage.Instance.CoursesByRoom.TryAdd(course.Curso + "-" + course.Teoprac, new CoursesByValidness());
            if (course.Teoprac == "1" && course.TotalInscritos < 22 || course.Teoprac == "0" && course.TotalInscritos < 11)
            {
                Storage.Instance.CoursesByRoom[course.Curso + "-" + course.Teoprac].AddValueToNotValid(course);
                return;
            }
            Storage.Instance.CoursesByRoom[course.Curso + "-" + course.Teoprac].AddValueToValid(course);
        }

        private static void AddByQueue(CourseAttributes course)
        {
            Storage.Instance.CoursesByQueue.TryAdd(course.Curso + "-" + course.Teoprac, new CoursesByValidness());
            if (course.Cola > 0 || course.CupoApartado > 0)
            {
                Storage.Instance.CoursesByQueue[course.Curso + "-" + course.Teoprac].AddValueToNotValid(course);
                return;
            }
            Storage.Instance.CoursesByQueue[course.Curso + "-" + course.Teoprac].AddValueToValid(course);
        }
    }
}
