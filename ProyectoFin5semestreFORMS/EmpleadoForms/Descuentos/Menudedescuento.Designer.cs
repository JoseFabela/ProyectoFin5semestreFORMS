namespace ProyectoFin5semestreFORMS.EmpleadoForms.Descuentos
{
    partial class Menudedescuento
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
            this.btnCrearDescuento = new System.Windows.Forms.Button();
            this.btnVerDescuento = new System.Windows.Forms.Button();
            this.btnActualizarDescuento = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCrearDescuento
            // 
            this.btnCrearDescuento.Location = new System.Drawing.Point(21, 34);
            this.btnCrearDescuento.Name = "btnCrearDescuento";
            this.btnCrearDescuento.Size = new System.Drawing.Size(139, 39);
            this.btnCrearDescuento.TabIndex = 0;
            this.btnCrearDescuento.Text = "Crear Descuento";
            this.btnCrearDescuento.UseVisualStyleBackColor = true;
            this.btnCrearDescuento.Click += new System.EventHandler(this.btnCrearDescuento_Click);
            // 
            // btnVerDescuento
            // 
            this.btnVerDescuento.Location = new System.Drawing.Point(21, 91);
            this.btnVerDescuento.Name = "btnVerDescuento";
            this.btnVerDescuento.Size = new System.Drawing.Size(139, 44);
            this.btnVerDescuento.TabIndex = 1;
            this.btnVerDescuento.Text = "Ver Descuento";
            this.btnVerDescuento.UseVisualStyleBackColor = true;
            this.btnVerDescuento.Click += new System.EventHandler(this.btnVerDescuento_Click);
            // 
            // btnActualizarDescuento
            // 
            this.btnActualizarDescuento.Location = new System.Drawing.Point(21, 151);
            this.btnActualizarDescuento.Name = "btnActualizarDescuento";
            this.btnActualizarDescuento.Size = new System.Drawing.Size(139, 44);
            this.btnActualizarDescuento.TabIndex = 2;
            this.btnActualizarDescuento.Text = "Actualizar Descuento";
            this.btnActualizarDescuento.UseVisualStyleBackColor = true;
            this.btnActualizarDescuento.Click += new System.EventHandler(this.btnActualizarDescuento_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(251, 273);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(139, 39);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Menudedescuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 341);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnActualizarDescuento);
            this.Controls.Add(this.btnVerDescuento);
            this.Controls.Add(this.btnCrearDescuento);
            this.Name = "Menudedescuento";
            this.Text = "Menudedescuento";
            this.Load += new System.EventHandler(this.Menudedescuento_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrearDescuento;
        private System.Windows.Forms.Button btnVerDescuento;
        private System.Windows.Forms.Button btnActualizarDescuento;
        private System.Windows.Forms.Button btnClose;
    }
}