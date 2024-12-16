namespace ProyectoFin5semestreFORMS.EmpleadoForms.AsignacionDeMesas
{
    partial class VerAsignacionesDeMesa
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
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridViewAsignaciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsignaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(649, 395);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 34);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridViewAsignaciones
            // 
            this.dataGridViewAsignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAsignaciones.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewAsignaciones.Name = "dataGridViewAsignaciones";
            this.dataGridViewAsignaciones.RowHeadersWidth = 51;
            this.dataGridViewAsignaciones.RowTemplate.Height = 24;
            this.dataGridViewAsignaciones.Size = new System.Drawing.Size(762, 354);
            this.dataGridViewAsignaciones.TabIndex = 1;
            // 
            // VerAsignacionesDeMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewAsignaciones);
            this.Controls.Add(this.btnClose);
            this.Name = "VerAsignacionesDeMesa";
            this.Text = "VerAsignacionesDeMesa";
            this.Load += new System.EventHandler(this.VerAsignacionesDeMesa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsignaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridViewAsignaciones;
    }
}