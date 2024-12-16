namespace ProyectoFin5semestreFORMS.EmpleadoForms.AsignacionDeMesas
{
    partial class CrearAsignacionDeMesa
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
            this.cmbMesa = new System.Windows.Forms.ComboBox();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.cmbEstadoAsignacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCrearAsignacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbMesa
            // 
            this.cmbMesa.FormattingEnabled = true;
            this.cmbMesa.Location = new System.Drawing.Point(103, 62);
            this.cmbMesa.Name = "cmbMesa";
            this.cmbMesa.Size = new System.Drawing.Size(121, 24);
            this.cmbMesa.TabIndex = 0;
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(103, 116);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(121, 24);
            this.cmbEmpleado.TabIndex = 1;
            // 
            // cmbEstadoAsignacion
            // 
            this.cmbEstadoAsignacion.FormattingEnabled = true;
            this.cmbEstadoAsignacion.Location = new System.Drawing.Point(103, 176);
            this.cmbEstadoAsignacion.Name = "cmbEstadoAsignacion";
            this.cmbEstadoAsignacion.Size = new System.Drawing.Size(121, 24);
            this.cmbEstadoAsignacion.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mesa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Empleado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Estado";
            // 
            // btnCrearAsignacion
            // 
            this.btnCrearAsignacion.Location = new System.Drawing.Point(209, 268);
            this.btnCrearAsignacion.Name = "btnCrearAsignacion";
            this.btnCrearAsignacion.Size = new System.Drawing.Size(75, 23);
            this.btnCrearAsignacion.TabIndex = 6;
            this.btnCrearAsignacion.Text = "Crear";
            this.btnCrearAsignacion.UseVisualStyleBackColor = true;
            this.btnCrearAsignacion.Click += new System.EventHandler(this.btnCrearAsignacion_Click);
            // 
            // CrearAsignacionDeMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 341);
            this.Controls.Add(this.btnCrearAsignacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEstadoAsignacion);
            this.Controls.Add(this.cmbEmpleado);
            this.Controls.Add(this.cmbMesa);
            this.Name = "CrearAsignacionDeMesa";
            this.Text = "CrearAsignacionDeMesa";
            this.Load += new System.EventHandler(this.CrearAsignacionDeMesa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMesa;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.ComboBox cmbEstadoAsignacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCrearAsignacion;
    }
}