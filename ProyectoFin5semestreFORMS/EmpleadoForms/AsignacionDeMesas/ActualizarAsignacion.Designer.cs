namespace ProyectoFin5semestreFORMS.EmpleadoForms.AsignacionDeMesas
{
    partial class ActualizarAsignacion
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
            this.btnActualizarAsignacion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMesa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEstadoAsignacion = new System.Windows.Forms.ComboBox();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAsignacionId = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnActualizarAsignacion
            // 
            this.btnActualizarAsignacion.Location = new System.Drawing.Point(339, 250);
            this.btnActualizarAsignacion.Name = "btnActualizarAsignacion";
            this.btnActualizarAsignacion.Size = new System.Drawing.Size(76, 32);
            this.btnActualizarAsignacion.TabIndex = 0;
            this.btnActualizarAsignacion.Text = "Actualizar";
            this.btnActualizarAsignacion.UseVisualStyleBackColor = true;
            this.btnActualizarAsignacion.Click += new System.EventHandler(this.btnActualizarAsignacion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Id Asignacion";
            // 
            // cmbMesa
            // 
            this.cmbMesa.FormattingEnabled = true;
            this.cmbMesa.Location = new System.Drawing.Point(161, 158);
            this.cmbMesa.Name = "cmbMesa";
            this.cmbMesa.Size = new System.Drawing.Size(121, 24);
            this.cmbMesa.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mesa";
            // 
            // cmbEstadoAsignacion
            // 
            this.cmbEstadoAsignacion.FormattingEnabled = true;
            this.cmbEstadoAsignacion.Location = new System.Drawing.Point(161, 263);
            this.cmbEstadoAsignacion.Name = "cmbEstadoAsignacion";
            this.cmbEstadoAsignacion.Size = new System.Drawing.Size(121, 24);
            this.cmbEstadoAsignacion.TabIndex = 5;
            this.cmbEstadoAsignacion.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoAsignacion_SelectedIndexChanged);
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(161, 215);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(121, 24);
            this.cmbEmpleado.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Estado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Empleado";
            // 
            // cmbAsignacionId
            // 
            this.cmbAsignacionId.FormattingEnabled = true;
            this.cmbAsignacionId.Location = new System.Drawing.Point(161, 107);
            this.cmbAsignacionId.Name = "cmbAsignacionId";
            this.cmbAsignacionId.Size = new System.Drawing.Size(121, 24);
            this.cmbAsignacionId.TabIndex = 9;
            this.cmbAsignacionId.SelectedIndexChanged += new System.EventHandler(this.cmbAsignacionId_SelectedIndexChanged);
            // 
            // ActualizarAsignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 337);
            this.Controls.Add(this.cmbAsignacionId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbEmpleado);
            this.Controls.Add(this.cmbEstadoAsignacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMesa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnActualizarAsignacion);
            this.Name = "ActualizarAsignacion";
            this.Text = "ActualizarAsignacion";
            this.Load += new System.EventHandler(this.ActualizarAsignacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnActualizarAsignacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMesa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEstadoAsignacion;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAsignacionId;
    }
}