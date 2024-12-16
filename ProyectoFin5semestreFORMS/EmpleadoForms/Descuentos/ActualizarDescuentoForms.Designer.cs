namespace ProyectoFin5semestreFORMS.EmpleadoForms.Descuentos
{
    partial class ActualizarDescuentoForms
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPorcentaje = new System.Windows.Forms.ComboBox();
            this.btnCrea = new System.Windows.Forms.Button();
            this.cmbNuevoEstado = new System.Windows.Forms.ComboBox();
            this.cmbDescuento = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Fecha de Finalizacion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Fecha de Inicio";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Location = new System.Drawing.Point(211, 254);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(200, 22);
            this.dtpFinal.TabIndex = 15;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(171, 194);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(200, 22);
            this.dtpInicio.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(171, 104);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(222, 50);
            this.textBox1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Descripcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Porcentaje";
            // 
            // cmbPorcentaje
            // 
            this.cmbPorcentaje.FormattingEnabled = true;
            this.cmbPorcentaje.Location = new System.Drawing.Point(171, 58);
            this.cmbPorcentaje.Name = "cmbPorcentaje";
            this.cmbPorcentaje.Size = new System.Drawing.Size(121, 24);
            this.cmbPorcentaje.TabIndex = 10;
            // 
            // btnCrea
            // 
            this.btnCrea.Location = new System.Drawing.Point(358, 311);
            this.btnCrea.Name = "btnCrea";
            this.btnCrea.Size = new System.Drawing.Size(100, 50);
            this.btnCrea.TabIndex = 9;
            this.btnCrea.Text = "Crear";
            this.btnCrea.UseVisualStyleBackColor = true;
            this.btnCrea.Click += new System.EventHandler(this.btnCrea_Click);
            // 
            // cmbNuevoEstado
            // 
            this.cmbNuevoEstado.FormattingEnabled = true;
            this.cmbNuevoEstado.Location = new System.Drawing.Point(70, 336);
            this.cmbNuevoEstado.Name = "cmbNuevoEstado";
            this.cmbNuevoEstado.Size = new System.Drawing.Size(121, 24);
            this.cmbNuevoEstado.TabIndex = 18;
            // 
            // cmbDescuento
            // 
            this.cmbDescuento.FormattingEnabled = true;
            this.cmbDescuento.Location = new System.Drawing.Point(171, 12);
            this.cmbDescuento.Name = "cmbDescuento";
            this.cmbDescuento.Size = new System.Drawing.Size(121, 24);
            this.cmbDescuento.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Descuento";
            // 
            // ActualizarDescuentoForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDescuento);
            this.Controls.Add(this.cmbNuevoEstado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFinal);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPorcentaje);
            this.Controls.Add(this.btnCrea);
            this.Name = "ActualizarDescuentoForms";
            this.Text = "ActualizarDescuentoForms";
            this.Load += new System.EventHandler(this.ActualizarDescuentoForms_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPorcentaje;
        private System.Windows.Forms.Button btnCrea;
        private System.Windows.Forms.ComboBox cmbNuevoEstado;
        private System.Windows.Forms.ComboBox cmbDescuento;
        private System.Windows.Forms.Label label5;
    }
}