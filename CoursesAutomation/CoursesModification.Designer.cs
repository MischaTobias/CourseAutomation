
namespace CoursesAutomation
{
    partial class CoursesModification
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnSeleccionarArchivo = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.cbSheets = new System.Windows.Forms.ComboBox();
            this.cbCFIORNOT = new System.Windows.Forms.ComboBox();
            this.btnLoadCourses = new System.Windows.Forms.Button();
            this.dgvNoCumplen = new System.Windows.Forms.DataGridView();
            this.lblNoCumplen = new System.Windows.Forms.Label();
            this.lblCumplen = new System.Windows.Forms.Label();
            this.dgvCumplen = new System.Windows.Forms.DataGridView();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbValidnessType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoCumplen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCumplen)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSeleccionarArchivo
            // 
            this.BtnSeleccionarArchivo.Location = new System.Drawing.Point(15, 30);
            this.BtnSeleccionarArchivo.Name = "BtnSeleccionarArchivo";
            this.BtnSeleccionarArchivo.Size = new System.Drawing.Size(152, 23);
            this.BtnSeleccionarArchivo.TabIndex = 0;
            this.BtnSeleccionarArchivo.Text = "Seleccionar Archivo";
            this.BtnSeleccionarArchivo.UseVisualStyleBackColor = true;
            this.BtnSeleccionarArchivo.Click += new System.EventHandler(this.BtnSeleccionarArchivo_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFile.Location = new System.Drawing.Point(189, 32);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(98, 21);
            this.lblFile.TabIndex = 1;
            this.lblFile.Text = "ejemplo.xls";
            // 
            // cbSheets
            // 
            this.cbSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSheets.Enabled = false;
            this.cbSheets.FormattingEnabled = true;
            this.cbSheets.Location = new System.Drawing.Point(616, 34);
            this.cbSheets.Name = "cbSheets";
            this.cbSheets.Size = new System.Drawing.Size(152, 23);
            this.cbSheets.TabIndex = 2;
            // 
            // cbCFIORNOT
            // 
            this.cbCFIORNOT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCFIORNOT.Enabled = false;
            this.cbCFIORNOT.FormattingEnabled = true;
            this.cbCFIORNOT.Location = new System.Drawing.Point(939, 34);
            this.cbCFIORNOT.Name = "cbCFIORNOT";
            this.cbCFIORNOT.Size = new System.Drawing.Size(152, 23);
            this.cbCFIORNOT.TabIndex = 3;
            // 
            // btnLoadCourses
            // 
            this.btnLoadCourses.Enabled = false;
            this.btnLoadCourses.Location = new System.Drawing.Point(15, 59);
            this.btnLoadCourses.Name = "btnLoadCourses";
            this.btnLoadCourses.Size = new System.Drawing.Size(152, 27);
            this.btnLoadCourses.TabIndex = 4;
            this.btnLoadCourses.Text = "Cargar Cursos a Modificar";
            this.btnLoadCourses.UseVisualStyleBackColor = true;
            this.btnLoadCourses.Click += new System.EventHandler(this.BtnLoadCourses_Click);
            // 
            // dgvNoCumplen
            // 
            this.dgvNoCumplen.AllowUserToAddRows = false;
            this.dgvNoCumplen.AllowUserToDeleteRows = false;
            this.dgvNoCumplen.AllowUserToResizeRows = false;
            this.dgvNoCumplen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNoCumplen.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvNoCumplen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNoCumplen.Location = new System.Drawing.Point(12, 255);
            this.dgvNoCumplen.Name = "dgvNoCumplen";
            this.dgvNoCumplen.ReadOnly = true;
            this.dgvNoCumplen.RowHeadersVisible = false;
            this.dgvNoCumplen.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvNoCumplen.RowTemplate.Height = 25;
            this.dgvNoCumplen.Size = new System.Drawing.Size(1175, 113);
            this.dgvNoCumplen.TabIndex = 5;
            // 
            // lblNoCumplen
            // 
            this.lblNoCumplen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoCumplen.AutoSize = true;
            this.lblNoCumplen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNoCumplen.Location = new System.Drawing.Point(12, 216);
            this.lblNoCumplen.Name = "lblNoCumplen";
            this.lblNoCumplen.Size = new System.Drawing.Size(222, 21);
            this.lblNoCumplen.TabIndex = 6;
            this.lblNoCumplen.Text = "No Cumplen Con Condición";
            // 
            // lblCumplen
            // 
            this.lblCumplen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCumplen.AutoSize = true;
            this.lblCumplen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCumplen.Location = new System.Drawing.Point(12, 383);
            this.lblCumplen.Name = "lblCumplen";
            this.lblCumplen.Size = new System.Drawing.Size(195, 21);
            this.lblCumplen.TabIndex = 7;
            this.lblCumplen.Text = "Cumplen Con Condición";
            // 
            // dgvCumplen
            // 
            this.dgvCumplen.AllowUserToAddRows = false;
            this.dgvCumplen.AllowUserToDeleteRows = false;
            this.dgvCumplen.AllowUserToResizeRows = false;
            this.dgvCumplen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCumplen.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCumplen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCumplen.Location = new System.Drawing.Point(12, 421);
            this.dgvCumplen.Name = "dgvCumplen";
            this.dgvCumplen.ReadOnly = true;
            this.dgvCumplen.RowHeadersVisible = false;
            this.dgvCumplen.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCumplen.RowTemplate.Height = 25;
            this.dgvCumplen.Size = new System.Drawing.Size(1175, 113);
            this.dgvCumplen.TabIndex = 8;
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Enabled = false;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(12, 124);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(964, 23);
            this.cbFilter.TabIndex = 9;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.CbFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(472, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Hoja a analizar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(792, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tipo de Archivo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "Filtrar por curso";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 21);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tipo de Filtro";
            // 
            // cbValidnessType
            // 
            this.cbValidnessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValidnessType.Enabled = false;
            this.cbValidnessType.FormattingEnabled = true;
            this.cbValidnessType.Location = new System.Drawing.Point(12, 184);
            this.cbValidnessType.Name = "cbValidnessType";
            this.cbValidnessType.Size = new System.Drawing.Size(964, 23);
            this.cbValidnessType.TabIndex = 13;
            this.cbValidnessType.SelectedIndexChanged += new System.EventHandler(this.CbValidnessType_SelectedIndexChanged);
            // 
            // CoursesModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 546);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbValidnessType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.dgvCumplen);
            this.Controls.Add(this.lblCumplen);
            this.Controls.Add(this.lblNoCumplen);
            this.Controls.Add(this.dgvNoCumplen);
            this.Controls.Add(this.btnLoadCourses);
            this.Controls.Add(this.cbCFIORNOT);
            this.Controls.Add(this.cbSheets);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.BtnSeleccionarArchivo);
            this.Name = "CoursesModification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validez Secciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoCumplen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCumplen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSeleccionarArchivo;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.ComboBox cbSheets;
        private System.Windows.Forms.ComboBox cbCFIORNOT;
        private System.Windows.Forms.Button btnLoadCourses;
        private System.Windows.Forms.DataGridView dgvNoCumplen;
        private System.Windows.Forms.Label lblNoCumplen;
        private System.Windows.Forms.Label lblCumplen;
        private System.Windows.Forms.DataGridView dgvCumplen;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbValidnessType;
    }
}