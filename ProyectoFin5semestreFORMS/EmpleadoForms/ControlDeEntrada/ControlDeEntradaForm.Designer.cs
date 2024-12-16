namespace ProyectoFin5semestreFORMS.EmpleadoForms.ControlDeEntrada
{
    partial class ControlDeEntradaForm
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
            this.btnAgregarEntrada = new System.Windows.Forms.Button();
            this.cmbJugador = new System.Windows.Forms.ComboBox();
            this.dtpFechaEntrada = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewEntradas = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntradas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarEntrada
            // 
            this.btnAgregarEntrada.Location = new System.Drawing.Point(450, 315);
            this.btnAgregarEntrada.Name = "btnAgregarEntrada";
            this.btnAgregarEntrada.Size = new System.Drawing.Size(136, 39);
            this.btnAgregarEntrada.TabIndex = 0;
            this.btnAgregarEntrada.Text = "AgregarEntrada";
            this.btnAgregarEntrada.UseVisualStyleBackColor = true;
            this.btnAgregarEntrada.Click += new System.EventHandler(this.btnAgregarEntrada_Click);
            // 
            // cmbJugador
            // 
            this.cmbJugador.FormattingEnabled = true;
            this.cmbJugador.Location = new System.Drawing.Point(76, 355);
            this.cmbJugador.Name = "cmbJugador";
            this.cmbJugador.Size = new System.Drawing.Size(121, 24);
            this.cmbJugador.TabIndex = 1;
            // 
            // dtpFechaEntrada
            // 
            this.dtpFechaEntrada.Location = new System.Drawing.Point(76, 315);
            this.dtpFechaEntrada.Name = "dtpFechaEntrada";
            this.dtpFechaEntrada.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaEntrada.TabIndex = 2;
            // 
            // dataGridViewEntradas
            // 
            this.dataGridViewEntradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEntradas.Location = new System.Drawing.Point(42, 12);
            this.dataGridViewEntradas.Name = "dataGridViewEntradas";
            this.dataGridViewEntradas.RowHeadersWidth = 51;
            this.dataGridViewEntradas.RowTemplate.Height = 24;
            this.dataGridViewEntradas.Size = new System.Drawing.Size(677, 280);
            this.dataGridViewEntradas.TabIndex = 3;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(638, 399);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(136, 39);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ControlDeEntradaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dataGridViewEntradas);
            this.Controls.Add(this.dtpFechaEntrada);
            this.Controls.Add(this.cmbJugador);
            this.Controls.Add(this.btnAgregarEntrada);
            this.Name = "ControlDeEntradaForm";
            this.Text = "ControlDeEntradaForm";
            this.Load += new System.EventHandler(this.ControlDeEntradaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntradas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarEntrada;
        private System.Windows.Forms.ComboBox cmbJugador;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrada;
        private System.Windows.Forms.DataGridView dataGridViewEntradas;
        private System.Windows.Forms.Button btnSalir;
    }
}