using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CoursesAutomation
{
    public partial class CoursesModification : Form
    {
        public CoursesModification()
        {
            InitializeComponent();
            this.Resize += new EventHandler(ResizeDGVs);
        }

        private void ResizeDGVs(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                dgvNoCumplen.Size = new Size(1344, 220);
                dgvCumplen.Size = new Size(1344, 215);
            }
            else
            {
                dgvNoCumplen.Size = new Size(1175, 120);
                dgvCumplen.Size = new Size(1175, 120);
            }
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
            dgvNoCumplen.Columns[0].HeaderText = "No. Sección";
            dgvNoCumplen.Columns[1].HeaderText = "Curso";
            dgvNoCumplen.Columns[2].HeaderText = "Tipo Curso";
            dgvNoCumplen.Columns[3].HeaderText = "Jornada";
            dgvNoCumplen.Columns[4].HeaderText = "Catedrático";
            dgvNoCumplen.Columns[5].HeaderText = "Salón";
            dgvNoCumplen.Columns[6].HeaderText = "Horarios";
            dgvNoCumplen.Columns[7].HeaderText = "Total Inscritos";
            if (byQueue)
            {
                dgvNoCumplen.Columns[8].HeaderText = "Cupo Apartado";
                dgvNoCumplen.Columns[9].HeaderText = "Cola";
            }
            for (int i = 0; i < courses.Count; i++)
            {
                dgvNoCumplen[0, i].Value = courses[i].Seccion;
                dgvNoCumplen[1, i].Value = courses[i].Curso;
                if (courses[i].Teoprac == "1")
                {
                    dgvNoCumplen[2, i].Value = "Teoría";
                }
                else
                {
                    dgvNoCumplen[2, i].Value = "Práctica";
                }
                dgvNoCumplen[3, i].Value = courses[i].Jornada;
                dgvNoCumplen[4, i].Value = courses[i].Catedratico;
                dgvNoCumplen[5, i].Value = courses[i].Salon;
                dgvNoCumplen[6, i].Value = courses[i].Horarios;
                dgvNoCumplen[7, i].Value = courses[i].TotalInscritos;
                if (byQueue)
                {
                    dgvNoCumplen[8, i].Value = courses[i].CupoApartado;
                    dgvNoCumplen[9, i].Value = courses[i].Cola;
                }
            }
        }

        private void FillValidDGV(List<CourseAttributes> courses, bool byQueue)
        {
            dgvCumplen.Columns[0].HeaderText = "No. Sección";
            dgvCumplen.Columns[1].HeaderText = "Curso";
            dgvCumplen.Columns[2].HeaderText = "Tipo Curso";
            dgvCumplen.Columns[3].HeaderText = "Jornada";
            dgvCumplen.Columns[4].HeaderText = "Catedrático";
            dgvCumplen.Columns[5].HeaderText = "Salón";
            dgvCumplen.Columns[6].HeaderText = "Horarios";
            dgvCumplen.Columns[7].HeaderText = "Total Inscritos";
            if (byQueue)
            {
                dgvCumplen.Columns[8].HeaderText = "Cupo Apartado";
                dgvCumplen.Columns[9].HeaderText = "Cola";
            }
            for (int i = 0; i < courses.Count; i++)
            {
                dgvCumplen[0, i].Value = courses[i].Seccion;
                dgvCumplen[1, i].Value = courses[i].Curso;
                if (courses[i].Teoprac == "1")
                {
                    dgvCumplen[2, i].Value = "Teoría";
                }
                else
                {
                    dgvCumplen[2, i].Value = "Práctica";
                }
                dgvCumplen[3, i].Value = courses[i].Jornada;
                dgvCumplen[4, i].Value = courses[i].Catedratico;
                dgvCumplen[5, i].Value = courses[i].Salon;
                dgvCumplen[6, i].Value = courses[i].Horarios;
                dgvCumplen[7, i].Value = courses[i].TotalInscritos;
                if (byQueue)
                {
                    dgvCumplen[8, i].Value = courses[i].CupoApartado;
                    dgvCumplen[9, i].Value = courses[i].Cola;
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
                        RedimensionValidDGV(validCourses.Count, 8);
                        RedimensionNotValidDGV(notValidCourses.Count, 8);
                        FillNotValidDGV(notValidCourses, false);
                        FillValidDGV(validCourses, false);
                    }
                    else
                    {
                        validCourses = CoursesManager.GetValidCoursesByQueue(null);
                        notValidCourses = CoursesManager.GetNotValidCoursesByQueue(null);
                        RedimensionValidDGV(validCourses.Count, 10);
                        RedimensionNotValidDGV(notValidCourses.Count, 10);
                        FillNotValidDGV(notValidCourses, true);
                        FillValidDGV(validCourses,true);
                    }

                    ModifyDGVsDimensions();
                    return;
                }

                if (courseName.Contains("Teo"))
                {
                    courseName = courseName[0..^6] + "1";
                }
                else
                {
                    courseName = courseName[0..^8] + "0";
                }

                if (ByRoom)
                {
                    validCourses = CoursesManager.GetValidCoursesByRoom(courseName);
                    notValidCourses = CoursesManager.GetNotValidCoursesByRoom(courseName);
                    RedimensionValidDGV(validCourses.Count, 8);
                    RedimensionNotValidDGV(notValidCourses.Count, 8);
                    FillNotValidDGV(notValidCourses, false);
                    FillValidDGV(validCourses, false);
                }
                else
                {
                    validCourses = CoursesManager.GetValidCoursesByQueue(courseName);
                    notValidCourses = CoursesManager.GetNotValidCoursesByQueue(courseName);
                    RedimensionValidDGV(validCourses.Count, 10);
                    RedimensionNotValidDGV(notValidCourses.Count, 10);
                    FillNotValidDGV(notValidCourses, true);
                    FillValidDGV(validCourses, true);
                }

                ModifyDGVsDimensions();
            }
        }

        private void ModifyDGVsDimensions()
        {
            dgvCumplen.Columns[1].Width = 400;
            dgvCumplen.Columns[4].Width = 400;
            dgvCumplen.Columns[6].Width = 130;
            dgvNoCumplen.Columns[1].Width = 400;
            dgvNoCumplen.Columns[4].Width = 400;
            dgvNoCumplen.Columns[6].Width = 130;
            foreach (DataGridViewColumn column in dgvCumplen.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            foreach (DataGridViewColumn column in dgvNoCumplen.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }
    }
}
