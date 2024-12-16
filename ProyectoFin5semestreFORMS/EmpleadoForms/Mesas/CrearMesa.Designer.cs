namespace ProyectoFin5semestreFORMS
{
    partial class CrearMesa
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
            this.btnCrearMesa = new System.Windows.Forms.Button();
            this.txtCapacidad = new System.Windows.Forms.TextBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoDeJuego = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCrearMesa
            // 
            this.btnCrearMesa.Location = new System.Drawing.Point(12, 286);
            this.btnCrearMesa.Name = "btnCrearMesa";
            this.btnCrearMesa.Size = new System.Drawing.Size(120, 42);
            this.btnCrearMesa.TabIndex = 0;
            this.btnCrearMesa.Text = "Crear Mesa";
            this.btnCrearMesa.UseVisualStyleBackColor = true;
            this.btnCrearMesa.Click += new System.EventHandler(this.btnCrearMesa_Click);
            // 
            // txtCapacidad
            // 
            this.txtCapacidad.Location = new System.Drawing.Point(103, 122);
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.Size = new System.Drawing.Size(159, 22);
            this.txtCapacidad.TabIndex = 2;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(11, 208);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(121, 24);
            this.cmbEstado.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tipo de Juego";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Capacidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Estado";
            // 
            // cmbTipoDeJuego
            // 
            this.cmbTipoDeJuego.FormattingEnabled = true;
            this.cmbTipoDeJuego.Location = new System.Drawing.Point(121, 70);
            this.cmbTipoDeJuego.Name = "cmbTipoDeJuego";
            this.cmbTipoDeJuego.Size = new System.Drawing.Size(121, 24);
            this.cmbTipoDeJuego.TabIndex = 8;
            // 
            // CrearMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 379);
            this.Controls.Add(this.cmbTipoDeJuego);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.txtCapacidad);
            this.Controls.Add(this.btnCrearMesa);
            this.Name = "CrearMesa";
            this.Text = "CrearMesa";
            this.Load += new System.EventHandler(this.CrearMesa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrearMesa;
        private System.Windows.Forms.TextBox txtCapacidad;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoDeJuego;
    }
}