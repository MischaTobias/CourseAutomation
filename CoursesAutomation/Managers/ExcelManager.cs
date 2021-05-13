using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CoursesAutomation
{
    public class ExcelManager
    {
        public static List<string> LoadExcel(string filename)
        {
            Storage.Instance.ProcessesBefore = Process.GetProcessesByName("excel");
            Storage.Instance.XLApp = new Microsoft.Office.Interop.Excel.Application();
            Storage.Instance.XLWorkbook = Storage.Instance.XLApp.Workbooks.Open(filename);
            var sheetNames = new List<string>();
            foreach (Worksheet worksheet in Storage.Instance.XLWorkbook.Worksheets)
            {
                sheetNames.Add(worksheet.Name);
            }
            return sheetNames;
        }

        public static void KillExcelProcess()
        {
            //Killing excel process
            var processesBeforeIDs = Storage.Instance.ProcessesBefore.Select(p => p.Id);
            var processesAfter = Process.GetProcessesByName("excel");
            var newProcess = processesAfter.FirstOrDefault(p => !processesBeforeIDs.Contains(p.Id));
            var processtoKill = Process.GetProcessById(newProcess.Id);
            processtoKill.Kill();
        }
    }
}
