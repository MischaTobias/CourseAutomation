using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursesAutomation
{
    public class CoursesManager
    {
        public static void ProcessCourses(string selectedSheet, bool CFI)
        {
            var xlWorksheet = Storage.Instance.XLWorkbook.Sheets[selectedSheet]; //llamar variable
            var xlRange = xlWorksheet.UsedRange;
            var rowCount = xlRange.Rows.Count;
            Storage.Instance.CoursesByRoom = new Dictionary<string, CoursesByValidness>();
            Storage.Instance.CoursesByQueue = new Dictionary<string, CoursesByValidness>();

            for (int i = 7; i <= rowCount; i++)
            {
                var newCourse = new CourseAttributes
                {
                    Seccion = xlWorksheet.Cells[i, 5].value,
                    Jornada = xlWorksheet.Cells[i, 4].value,
                    Catedratico = xlWorksheet.Cells[i, 25].value,
                    Salon = xlWorksheet.Cells[i, 21].value,
                    Hora_Inicio = xlWorksheet.Cells[i, 22].value,
                    Hora_fin = xlWorksheet.Cells[i, 23].value,
                    Dia = xlWorksheet.Cells[i, 24].value,
                    Curso = xlWorksheet.Cells[i, 10].value,
                    Teoprac = xlWorksheet.Cells[i, 8].value,
                    TotalInscritos = Convert.ToInt32(xlWorksheet.Cells[i, 7].value),
                    Cola = Convert.ToInt32(xlWorksheet.Cells[i, 18].value),
                    CupoApartado = Convert.ToInt32(xlWorksheet.Cells[i, 17].value)
                };
                if (CFI)
                {
                    if (newCourse.Seccion[0].ToString() == "2" || newCourse.Curso == "ESTRATEGIAS DE RAZONAMIENTO (CFI)")
                    {
                        CoursesByValidness.AddCourse(newCourse);
                    }
                }
                else
                {
                    CoursesByValidness.AddCourse(newCourse);
                }
            }
        }

        public static List<string> GetKeys()
        {
            var tempList = Storage.Instance.CoursesByRoom.Keys.ToList();
            for (int i = 0; i < tempList.Count; i++)
            {
                if (tempList[i][^1].ToString() == "1")
                {
                    tempList[i] = tempList[i][0..^1] + "Teoría";
                }
                else
                {
                    tempList[i] = tempList[i][0..^1] + "Práctica";
                }
            }
            tempList.Sort();
            return tempList;
        }

        public static void SortByRoom()
        {
            foreach (var course in Storage.Instance.CoursesByQueue.Values)
            {
                course.ValidCourses = course.ValidCourses.OrderBy(c => c.TotalInscritos).ToList();
            }

            foreach (var course in Storage.Instance.CoursesByRoom.Values)
            {
                course.ValidCourses = course.ValidCourses.OrderBy(c => c.TotalInscritos).ToList();
            }
        }

        public static List<CourseAttributes> GetValidCoursesByRoom(string filterByCourse)
        {
            if (filterByCourse == null)
            {
                return Storage.Instance.CoursesByRoom.Values
                    .Select(c => c.ValidCourses).SelectMany(x => x).ToList();
            }

            return Storage.Instance.CoursesByRoom[filterByCourse].ValidCourses;
        }

        public static  List<CourseAttributes> GetNotValidCoursesByRoom(string filterByCourse)
        {
            if (filterByCourse == null)
            {
                return Storage.Instance.CoursesByRoom.Values
                    .Select(c => c.NotValidCourses).SelectMany(x => x).ToList();
            }

            return Storage.Instance.CoursesByRoom[filterByCourse].NotValidCourses;
        }

        public static List<CourseAttributes> GetValidCoursesByQueue(string filterByCourse)
        {
            if (filterByCourse == null)
            {
                return Storage.Instance.CoursesByQueue.Values
                .Select(c => c.ValidCourses).SelectMany(x => x).ToList();
            }

            return Storage.Instance.CoursesByQueue[filterByCourse].ValidCourses;
        }

        public static List<CourseAttributes> GetNotValidCoursesByQueue(string filterByCourse)
        {
            if (filterByCourse == null)
            {
                return Storage.Instance.CoursesByQueue.Values
                .Select(c => c.NotValidCourses).SelectMany(x => x).ToList();
            }

            return Storage.Instance.CoursesByQueue[filterByCourse].NotValidCourses;
        }
    }
}
