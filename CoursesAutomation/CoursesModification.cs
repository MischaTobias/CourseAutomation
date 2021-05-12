using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CoursesAutomation
{
    public partial class CoursesModification : Form
    {
        Process[] ProcessesBefore;
        Microsoft.Office.Interop.Excel.Application XLApp;
        Workbook XLWorkbook;

        public CoursesModification()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(ClosingApp);
        }

        private void ClosingApp(object sender, EventArgs e)
        {
            //Killing excel process
            var processesBeforeIDs = ProcessesBefore.Select(p => p.Id);
            var processesAfter = Process.GetProcessesByName("excel");
            var newProcess = processesAfter.FirstOrDefault(p => !processesBeforeIDs.Contains(p.Id));
            var processtoKill = Process.GetProcessById(newProcess.Id);
            processtoKill.Kill();
        }

        private void BtnSeleccionarArchivo_Click(object sender, System.EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "Excel Worksheets|*.xls",
                Title = "Curso"
            };

            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filename = openFileDialog.FileName.Trim();
                    var onlyFileName = Path.GetFileName(filename);

                    DialogResult dialogResult = MessageBox.Show($"¿Quiere continuar y colocar {onlyFileName} como el archivo?", "Confirmar archivo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ProcessesBefore = Process.GetProcessesByName("excel");
                        XLApp = new Microsoft.Office.Interop.Excel.Application();
                        XLWorkbook = XLApp.Workbooks.Open(filename);
                        var listonames = new List<string>();
                        foreach (Worksheet worksheet in XLWorkbook.Worksheets)
                        {
                            listonames.Add(worksheet.Name);
                        }

                        lblFile.Text = onlyFileName;
                        cbSheets.Enabled = true;
                        cbSheets.Items.AddRange(listonames.ToArray());
                        cbCFIORNOT.Enabled = true;
                        cbCFIORNOT.Items.Add("Documento CFI");
                        cbCFIORNOT.Items.Add("Documento Normal");
                    }
                }
            }
            catch
            {
                MessageBox.Show("El formato del archivo de entrada es incorrecto, \npor favor inténtelo nuevamente.");
            }
        }

        private void AddValueToDictionary(Dictionary<string, CoursesByRoom> dict, CourseAttributes course)
        {
            dict.TryAdd(course.Curso + "-" + course.Teoprac, new CoursesByRoom());
            if (course.Teoprac == "1" && course.TotalInscritos < 22 || course.Teoprac == "0" && course.TotalInscritos < 11)
            {

                dict[course.Curso + "-" + course.Teoprac].AddValueToNotValid(course);
                return;
            }
            dict[course.Curso + "-" + course.Teoprac].AddValueToValid(course);
        }

        private void ManageCourses()
        {
            var xlWorksheet = XLWorkbook.Sheets["cupos-1c-2021"]; //llamar variable
            var xlRange = xlWorksheet.UsedRange;
            var rowCount = xlRange.Rows.Count;
            var coursesDictionary = new Dictionary<string, CoursesByRoom>();


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
                    TotalInscritos = Convert.ToInt16(xlWorksheet.Cells[i, 7].value)
                };
                AddValueToDictionary(coursesDictionary, newCourse);
            }
        }
    }
}
