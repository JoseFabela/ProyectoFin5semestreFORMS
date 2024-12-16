namespace ProyectoFin5semestreFORMS.AdministradorForms
{
    partial class MenuContratos
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
            this.btnCrearContrato = new System.Windows.Forms.Button();
            this.btnVerContrato = new System.Windows.Forms.Button();
            this.btnActualizarContrato = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCrearContrato
            // 
            this.btnCrearContrato.Location = new System.Drawing.Point(12, 33);
            this.btnCrearContrato.Name = "btnCrearContrato";
            this.btnCrearContrato.Size = new System.Drawing.Size(94, 48);
            this.btnCrearContrato.TabIndex = 0;
            this.btnCrearContrato.Text = "Crear Contrato";
            this.btnCrearContrato.UseVisualStyleBackColor = true;
            this.btnCrearContrato.Click += new System.EventHandler(this.btnCrearContrato_Click);
            // 
            // btnVerContrato
            // 
            this.btnVerContrato.Location = new System.Drawing.Point(12, 109);
            this.btnVerContrato.Name = "btnVerContrato";
            this.btnVerContrato.Size = new System.Drawing.Size(94, 48);
            this.btnVerContrato.TabIndex = 1;
            this.btnVerContrato.Text = "Ver Contrato";
            this.btnVerContrato.UseVisualStyleBackColor = true;
            this.btnVerContrato.Click += new System.EventHandler(this.btnVerContrato_Click);
            // 
            // btnActualizarContrato
            // 
            this.btnActualizarContrato.Location = new System.Drawing.Point(12, 182);
            this.btnActualizarContrato.Name = "btnActualizarContrato";
            this.btnActualizarContrato.Size = new System.Drawing.Size(94, 48);
            this.btnActualizarContrato.TabIndex = 2;
            this.btnActualizarContrato.Text = "Actualizar Contrato";
            this.btnActualizarContrato.UseVisualStyleBackColor = true;
            this.btnActualizarContrato.Click += new System.EventHandler(this.btnActualizarContrato_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(190, 245);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 48);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MenuContratos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 305);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnActualizarContrato);
            this.Controls.Add(this.btnVerContrato);
            this.Controls.Add(this.btnCrearContrato);
            this.Name = "MenuContratos";
            this.Text = "MenuContratos";
            this.Load += new System.EventHandler(this.MenuContratos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrearContrato;
        private System.Windows.Forms.Button btnVerContrato;
        private System.Windows.Forms.Button btnActualizarContrato;
        private System.Windows.Forms.Button btnClose;
    }
}