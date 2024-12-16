namespace ProyectoFin5semestreFORMS.AdministradorForms.ContratosProveedores
{
    partial class VerContratoProvee
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
            this.dataGridViewContratos = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContratos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewContratos
            // 
            this.dataGridViewContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContratos.Location = new System.Drawing.Point(24, 12);
            this.dataGridViewContratos.Name = "dataGridViewContratos";
            this.dataGridViewContratos.RowHeadersWidth = 51;
            this.dataGridViewContratos.RowTemplate.Height = 24;
            this.dataGridViewContratos.Size = new System.Drawing.Size(753, 345);
            this.dataGridViewContratos.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(678, 403);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 35);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // VerContratoProvee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewContratos);
            this.Controls.Add(this.btnClose);
            this.Name = "VerContratoProvee";
            this.Text = "VerContratoProvee";
            this.Load += new System.EventHandler(this.VerContratoProvee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContratos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewContratos;
        private System.Windows.Forms.Button btnClose;
    }
}