namespace ProyectoFin5semestreFORMS
{
    partial class ActualizarMESA
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
            this.btnActualizarEstado = new System.Windows.Forms.Button();
            this.txtMesaIdActualizar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNuevoEstado = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnActualizarEstado
            // 
            this.btnActualizarEstado.Location = new System.Drawing.Point(237, 362);
            this.btnActualizarEstado.Name = "btnActualizarEstado";
            this.btnActualizarEstado.Size = new System.Drawing.Size(89, 33);
            this.btnActualizarEstado.TabIndex = 0;
            this.btnActualizarEstado.Text = "Actualizar";
            this.btnActualizarEstado.UseVisualStyleBackColor = true;
            this.btnActualizarEstado.Click += new System.EventHandler(this.btnActualizarEstado_Click);
            // 
            // txtMesaIdActualizar
            // 
            this.txtMesaIdActualizar.Location = new System.Drawing.Point(60, 60);
            this.txtMesaIdActualizar.Name = "txtMesaIdActualizar";
            this.txtMesaIdActualizar.Size = new System.Drawing.Size(79, 22);
            this.txtMesaIdActualizar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID de la mesa";
            // 
            // cmbNuevoEstado
            // 
            this.cmbNuevoEstado.FormattingEnabled = true;
            this.cmbNuevoEstado.Location = new System.Drawing.Point(60, 141);
            this.cmbNuevoEstado.Name = "cmbNuevoEstado";
            this.cmbNuevoEstado.Size = new System.Drawing.Size(121, 24);
            this.cmbNuevoEstado.TabIndex = 3;
            // 
            // ActualizarMESA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 450);
            this.Controls.Add(this.cmbNuevoEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMesaIdActualizar);
            this.Controls.Add(this.btnActualizarEstado);
            this.Name = "ActualizarMESA";
            this.Text = "ActualizarMESA";
            this.Load += new System.EventHandler(this.ActualizarMESA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnActualizarEstado;
        private System.Windows.Forms.TextBox txtMesaIdActualizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNuevoEstado;
    }
}