
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
            this.SuspendLayout();
            // 
            // BtnSeleccionarArchivo
            // 
            this.BtnSeleccionarArchivo.Location = new System.Drawing.Point(45, 34);
            this.BtnSeleccionarArchivo.Name = "BtnSeleccionarArchivo";
            this.BtnSeleccionarArchivo.Size = new System.Drawing.Size(152, 45);
            this.BtnSeleccionarArchivo.TabIndex = 0;
            this.BtnSeleccionarArchivo.Text = "Seleccionar Archivo";
            this.BtnSeleccionarArchivo.UseVisualStyleBackColor = true;
            this.BtnSeleccionarArchivo.Click += new System.EventHandler(this.BtnSeleccionarArchivo_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFile.Location = new System.Drawing.Point(219, 44);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(107, 21);
            this.lblFile.TabIndex = 1;
            this.lblFile.Text = "ejemplo.xlsx";
            // 
            // cbSheets
            // 
            this.cbSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSheets.Enabled = false;
            this.cbSheets.FormattingEnabled = true;
            this.cbSheets.Location = new System.Drawing.Point(45, 111);
            this.cbSheets.Name = "cbSheets";
            this.cbSheets.Size = new System.Drawing.Size(152, 23);
            this.cbSheets.TabIndex = 2;
            // 
            // cbCFIORNOT
            // 
            this.cbCFIORNOT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCFIORNOT.Enabled = false;
            this.cbCFIORNOT.FormattingEnabled = true;
            this.cbCFIORNOT.Location = new System.Drawing.Point(45, 151);
            this.cbCFIORNOT.Name = "cbCFIORNOT";
            this.cbCFIORNOT.Size = new System.Drawing.Size(152, 23);
            this.cbCFIORNOT.TabIndex = 3;
            // 
            // CoursesModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 450);
            this.Controls.Add(this.cbCFIORNOT);
            this.Controls.Add(this.cbSheets);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.BtnSeleccionarArchivo);
            this.Name = "CoursesModification";
            this.Text = "CoursesModification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSeleccionarArchivo;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.ComboBox cbSheets;
        private System.Windows.Forms.ComboBox cbCFIORNOT;
    }
}