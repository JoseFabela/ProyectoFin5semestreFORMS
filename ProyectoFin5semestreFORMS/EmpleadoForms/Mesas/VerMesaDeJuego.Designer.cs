namespace ProyectoFin5semestreFORMS
{
    partial class VerMesaDeJuego
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
            this.dataGridViewMesas = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMesas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMesas
            // 
            this.dataGridViewMesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMesas.Location = new System.Drawing.Point(43, 28);
            this.dataGridViewMesas.Name = "dataGridViewMesas";
            this.dataGridViewMesas.RowHeadersWidth = 51;
            this.dataGridViewMesas.RowTemplate.Height = 24;
            this.dataGridViewMesas.Size = new System.Drawing.Size(716, 362);
            this.dataGridViewMesas.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(43, 415);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Close";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // VerMesaDeJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dataGridViewMesas);
            this.Name = "VerMesaDeJuego";
            this.Text = "VerMesaDeJuego";
            this.Load += new System.EventHandler(this.VerMesaDeJuego_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMesas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMesas;
        private System.Windows.Forms.Button btnCerrar;
    }
}