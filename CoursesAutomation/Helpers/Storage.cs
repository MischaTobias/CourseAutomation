using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Diagnostics;

namespace CoursesAutomation
{
    public class Storage
    {
        public static Storage _instance;

        public static Storage Instance
        {
            get
            {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }

        public Process[] ProcessesBefore;
        public Application XLApp;
        public Dictionary<string, CoursesByValidness> CoursesByRoom = new();
        public Dictionary<string, CoursesByValidness> CoursesByQueue = new();
        public bool NotFirstTime;
        public Workbook XLWorkbook;
    }
}
