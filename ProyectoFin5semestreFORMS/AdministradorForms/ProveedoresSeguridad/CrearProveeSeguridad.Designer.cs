namespace ProyectoFin5semestreFORMS.AdministradorForms.ProveedoresSeguridad
{
    partial class CrearProveeSeguridad
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
            this.label2 = new System.Windows.Forms.Label();
            this.labelnombre = new System.Windows.Forms.Label();
            this.txtTipo_producto = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tipo De Producto";
            // 
            // labelnombre
            // 
            this.labelnombre.AutoSize = true;
            this.labelnombre.Location = new System.Drawing.Point(76, 52);
            this.labelnombre.Name = "labelnombre";
            this.labelnombre.Size = new System.Drawing.Size(56, 16);
            this.labelnombre.TabIndex = 13;
            this.labelnombre.Text = "Nombre";
            this.labelnombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTipo_producto
            // 
            this.txtTipo_producto.Location = new System.Drawing.Point(171, 131);
            this.txtTipo_producto.Name = "txtTipo_producto";
            this.txtTipo_producto.Size = new System.Drawing.Size(100, 22);
            this.txtTipo_producto.TabIndex = 12;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(171, 52);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 22);
            this.txtNombre.TabIndex = 11;
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(278, 237);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(79, 28);
            this.btnCrear.TabIndex = 10;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // CrearProveeSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 318);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelnombre);
            this.Controls.Add(this.txtTipo_producto);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnCrear);
            this.Name = "CrearProveeSeguridad";
            this.Text = "CrearProveeSeguridad";
            this.Load += new System.EventHandler(this.CrearProveeSeguridad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelnombre;
        private System.Windows.Forms.TextBox txtTipo_producto;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnCrear;
    }
}