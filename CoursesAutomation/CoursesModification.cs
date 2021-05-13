using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CoursesAutomation
{
    public partial class CoursesModification : Form
    {
        public CoursesModification()
        {
            InitializeComponent();
        }

        private void BtnSeleccionarArchivo_Click(object sender, System.EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "Excel Worksheets|*.xls",
                Title = "Curso"
            };
            cbFilter.Enabled = false;

            ClearComboBoxes();
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filename = openFileDialog.FileName.Trim();
                    var onlyFileName = Path.GetFileName(filename);

                    DialogResult dialogResult = MessageBox.Show($"¿Quiere continuar y colocar {onlyFileName} como el archivo?", "Confirmar archivo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        EnableAllItems(false);
                        lblFile.Text = "Cargando...";
                        var sheetNames = ExcelManager.LoadExcel(filename);
                        LoadButtonsAndCBoxes(sheetNames, onlyFileName);
                        EnableBeforeCourseLoad(true);
                    }
                    else
                    {
                        ClearComboBoxes();
                        EnableBeforeFileLoad(true);
                    }
                }
            }
            catch
            {
                ClearComboBoxes();
                EnableBeforeFileLoad(true);
                MessageBox.Show("El formato del archivo de entrada es incorrecto, \npor favor inténtelo nuevamente.");
            }
            Refresh();
        }

        private void LoadButtonsAndCBoxes(List<string> sheetNames, string onlyFileName)
        {
            cbSheets.Items.AddRange(sheetNames.ToArray());
            cbSheets.SelectedIndex = 0;
            cbCFIORNOT.Items.Add("Documento CFI");
            cbCFIORNOT.Items.Add("Documento Ingeniería");
            lblFile.Text = onlyFileName;
        }

        private void ClearComboBoxes()
        {
            lblFile.Text = "-";
            cbSheets.Items.Clear();
            cbCFIORNOT.Items.Clear();
            cbFilter.Items.Clear();
            cbValidnessType.Items.Clear();
            dgvCumplen.Rows.Clear();
            dgvCumplen.Refresh();
            dgvNoCumplen.Rows.Clear();
            dgvNoCumplen.Refresh();
        }

        private void EnableAllItems(bool value)
        {
            BtnSeleccionarArchivo.Enabled = value;
            btnLoadCourses.Enabled = value;

            cbSheets.Enabled = value;
            cbCFIORNOT.Enabled = value;

            cbFilter.Enabled = value;
            cbValidnessType.Enabled = value;
        }

        private void EnableAfterFilterChange(bool value)
        {
            BtnSeleccionarArchivo.Enabled = value;
            cbFilter.Enabled = value;
            cbValidnessType.Enabled = value;
        }

        private void EnableBeforeCourseLoad(bool value)
        {
            BtnSeleccionarArchivo.Enabled = value;
            btnLoadCourses.Enabled = value;
            cbSheets.Enabled = value;
            cbCFIORNOT.Enabled = value;
        }

        private void EnableBeforeFileLoad(bool value)
        {
            BtnSeleccionarArchivo.Enabled = value;
        }

        private void BtnLoadCourses_Click(object sender, EventArgs e)
        {
            try
            {
                EnableAllItems(false);
                Refresh();
                var auxvalue = lblFile.Text;
                lblFile.Text = "Cargando...";
                //Añadir valores a diccionarios
                if (cbCFIORNOT.SelectedItem == null)
                {
                    MessageBox.Show("Por favor seleccione un tipo de documento");
                    lblFile.Text = auxvalue;
                    EnableBeforeCourseLoad(true);
                    return;
                }

                ManageCourses();
                CoursesManager.SortByRoom();
                ExcelManager.KillExcelProcess();

                //Actualizar elementos visuales
                cbValidnessType.Items.Add("Cupo");
                cbValidnessType.Items.Add("Cola/Cupo Apartado");
                Storage.Instance.NotFirstTime = false;
                cbValidnessType.SelectedIndex = 0;

                cbFilter.Items.Add("Todos los cursos");
                cbFilter.Items.AddRange(CoursesManager.GetKeys().ToArray());
                Storage.Instance.NotFirstTime = true;
                cbFilter.SelectedIndex = 0;

                EnableAfterFilterChange(true);
                lblFile.Text = auxvalue;
            }
            catch
            {
                ClearComboBoxes();
                EnableBeforeFileLoad(true);
                MessageBox.Show("El formato del archivo de entrada es incorrecto, \npor favor inténtelo nuevamente.");
            }
            Refresh();
        }

        private void ManageCourses()
        {
            if (cbCFIORNOT.SelectedItem.ToString() == "Documento CFI")
            {
                CoursesManager.ProcessCourses(cbSheets.SelectedItem.ToString(), true);
            }
            else
            {
                CoursesManager.ProcessCourses(cbSheets.SelectedItem.ToString(), false);
            }
        }

        private void FillNotValidDGV(List<CourseAttributes> courses, bool byQueue)
        {
            dgvNoCumplen[0, 0].Value = "No. Sección";
            dgvNoCumplen[1, 0].Value = "Curso";
            dgvNoCumplen[2, 0].Value = "Jornada";
            dgvNoCumplen[3, 0].Value = "Catedrático";
            dgvNoCumplen[4, 0].Value = "Salón";
            dgvNoCumplen[5, 0].Value = "Día";
            dgvNoCumplen[6, 0].Value = "Hora Inicio";
            dgvNoCumplen[7, 0].Value = "Hora Fin";
            dgvNoCumplen[8, 0].Value = "Total Inscritos";
            if (byQueue)
            {
                dgvNoCumplen[9, 0].Value = "Cupo Apartado";
                dgvNoCumplen[10, 0].Value = "Cola";
            }
            dgvNoCumplen.Rows[0].Frozen = true;
            for (int i = 1; i < courses.Count + 1; i++)
            {
                dgvNoCumplen[0, i].Value = courses[i-1].Seccion;
                dgvNoCumplen[1, i].Value = courses[i-1].Curso;
                dgvNoCumplen[2, i].Value = courses[i-1].Jornada;
                dgvNoCumplen[3, i].Value = courses[i-1].Catedratico;
                dgvNoCumplen[4, i].Value = courses[i-1].Salon;
                dgvNoCumplen[5, i].Value = courses[i-1].Dia;
                dgvNoCumplen[6, i].Value = courses[i-1].Hora_Inicio;
                dgvNoCumplen[7, i].Value = courses[i-1].Hora_fin;
                dgvNoCumplen[8, i].Value = courses[i - 1].TotalInscritos;
                if (byQueue)
                {
                    dgvNoCumplen[9, i].Value = courses[i-1].CupoApartado;
                    dgvNoCumplen[10, i].Value = courses[i-1].Cola;
                }
            }
        }

        private void FillValidDGV(List<CourseAttributes> courses, bool byQueue)
        {
            dgvCumplen[0, 0].Value = "No. Sección";
            dgvCumplen[1, 0].Value = "Curso";
            dgvCumplen[2, 0].Value = "Jornada";
            dgvCumplen[3, 0].Value = "Catedrático";
            dgvCumplen[4, 0].Value = "Salón";
            dgvCumplen[5, 0].Value = "Día";
            dgvCumplen[6, 0].Value = "Hora Inicio";
            dgvCumplen[7, 0].Value = "Hora Fin";
            dgvCumplen[8, 0].Value = "Total Inscritos";
            if (byQueue)
            {
                dgvCumplen[9, 0].Value = "Cupo Apartado";
                dgvCumplen[10, 0].Value = "Cola";
            }
            dgvCumplen.Rows[0].Frozen = true;
            for (int i = 1; i < courses.Count + 1; i++)
            {
                dgvCumplen[0, i].Value = courses[i-1].Seccion;
                dgvCumplen[1, i].Value = courses[i-1].Curso;
                dgvCumplen[2, i].Value = courses[i-1].Jornada;
                dgvCumplen[3, i].Value = courses[i-1].Catedratico;
                dgvCumplen[4, i].Value = courses[i-1].Salon;
                dgvCumplen[5, i].Value = courses[i-1].Dia;
                dgvCumplen[6, i].Value = courses[i-1].Hora_Inicio;
                dgvCumplen[7, i].Value = courses[i-1].Hora_fin;
                dgvCumplen[8, i].Value = courses[i - 1].TotalInscritos;
                if (byQueue)
                {
                    dgvCumplen[9, i].Value = courses[i - 1].CupoApartado;
                    dgvCumplen[10, i].Value = courses[i - 1].Cola;
                }
            }
        }

        private void RedimensionNotValidDGV(int rows, int columns)
        {
            dgvNoCumplen.Rows.Clear();
            dgvNoCumplen.RowCount = rows;
            dgvNoCumplen.ColumnCount = columns;
        }

        private void RedimensionValidDGV(int rows, int columns)
        {
            dgvCumplen.Rows.Clear();
            dgvCumplen.RowCount = rows;
            dgvCumplen.ColumnCount = columns;
        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var auxvalue = lblFile.Text;
            lblFile.Text = "Cargando...";
            EnableAllItems(false);
            Refresh();
            if (cbValidnessType.SelectedItem.ToString() == "Cupo")
            {
                RefreshDGV(true);
            }
            else
            {
                RefreshDGV(false);
            }
            EnableAfterFilterChange(true);
            lblFile.Text = auxvalue;
        }

        private void CbValidnessType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var auxvalue = lblFile.Text;
            lblFile.Text = "Cargando...";
            EnableAllItems(false);
            Refresh();
            if (cbValidnessType.SelectedItem.ToString() == "Cupo")
            {
                RefreshDGV(true);
            }
            else
            {
                RefreshDGV(false);
            }
            EnableAfterFilterChange(true);
            lblFile.Text = auxvalue;
        }

        private void RefreshDGV(bool ByRoom)
        {
            if (Storage.Instance.NotFirstTime)
            {
                var validCourses = new List<CourseAttributes>();
                var notValidCourses = new List<CourseAttributes>();
                var courseName = cbFilter.SelectedItem.ToString();
                if (courseName == "Todos los cursos")
                {
                    if (ByRoom)
                    {
                        validCourses = CoursesManager.GetValidCoursesByRoom(null);
                        notValidCourses = CoursesManager.GetNotValidCoursesByRoom(null);
                        RedimensionValidDGV(validCourses.Count + 1, 9);
                        RedimensionNotValidDGV(notValidCourses.Count + 1, 9);
                        FillNotValidDGV(notValidCourses, false);
                        FillValidDGV(validCourses, false);
                    }
                    else
                    {
                        validCourses = CoursesManager.GetValidCoursesByQueue(null);
                        notValidCourses = CoursesManager.GetNotValidCoursesByQueue(null);
                        RedimensionValidDGV(validCourses.Count + 1, 11);
                        RedimensionNotValidDGV(notValidCourses.Count + 1, 11);
                        FillNotValidDGV(notValidCourses, true);
                        FillValidDGV(validCourses,true);
                    }
                    return;
                }

                if (courseName.Contains("Teo"))
                {
                    courseName = courseName[0..^6] + "1";
                }
                else
                {
                    courseName = courseName[0..^6] + "0";
                }

                if (ByRoom)
                {
                    validCourses = CoursesManager.GetValidCoursesByRoom(courseName);
                    notValidCourses = CoursesManager.GetNotValidCoursesByRoom(courseName);
                    RedimensionValidDGV(validCourses.Count + 1, 9);
                    RedimensionNotValidDGV(notValidCourses.Count + 1, 9);
                    FillNotValidDGV(notValidCourses, false);
                    FillValidDGV(validCourses, false);
                }
                else
                {
                    validCourses = CoursesManager.GetValidCoursesByQueue(courseName);
                    notValidCourses = CoursesManager.GetNotValidCoursesByQueue(courseName);
                    RedimensionValidDGV(validCourses.Count + 1, 11);
                    RedimensionNotValidDGV(notValidCourses.Count + 1, 11);
                    FillNotValidDGV(notValidCourses, true);
                    FillValidDGV(validCourses, true);
                }

                foreach (DataGridViewColumn column in dgvCumplen.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                foreach (DataGridViewColumn column in dgvNoCumplen.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }
    }
}
