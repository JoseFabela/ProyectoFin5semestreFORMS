namespace ProyectoFin5semestreFORMS.EmpleadoForms.Apuestas
{
    partial class VerApuestaForm
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
            this.dataGridViewApuestas = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApuestas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewApuestas
            // 
            this.dataGridViewApuestas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewApuestas.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewApuestas.Name = "dataGridViewApuestas";
            this.dataGridViewApuestas.RowHeadersWidth = 51;
            this.dataGridViewApuestas.RowTemplate.Height = 24;
            this.dataGridViewApuestas.Size = new System.Drawing.Size(712, 304);
            this.dataGridViewApuestas.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(564, 345);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 59);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // VerApuestaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 431);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridViewApuestas);
            this.Name = "VerApuestaForm";
            this.Text = "VerApuestaForm";
            this.Load += new System.EventHandler(this.VerApuestaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApuestas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewApuestas;
        private System.Windows.Forms.Button btnClose;
    }
}