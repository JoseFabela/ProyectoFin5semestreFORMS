namespace ProyectoFin5semestreFORMS
{
    partial class MenuAdministrativo
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
            this.btnAbrirFormSesiones = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnMenuProveedores = new System.Windows.Forms.Button();
            this.btnMenuDeContratos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAbrirFormSesiones
            // 
            this.btnAbrirFormSesiones.Location = new System.Drawing.Point(648, 287);
            this.btnAbrirFormSesiones.Name = "btnAbrirFormSesiones";
            this.btnAbrirFormSesiones.Size = new System.Drawing.Size(114, 49);
            this.btnAbrirFormSesiones.TabIndex = 0;
            this.btnAbrirFormSesiones.Text = "Ver Historial De Sesiones";
            this.btnAbrirFormSesiones.UseVisualStyleBackColor = true;
            this.btnAbrirFormSesiones.Click += new System.EventHandler(this.btnAbrirFormSesiones_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(648, 362);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(114, 49);
            this.btnCerrarSesion.TabIndex = 1;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnMenuProveedores
            // 
            this.btnMenuProveedores.Location = new System.Drawing.Point(12, 55);
            this.btnMenuProveedores.Name = "btnMenuProveedores";
            this.btnMenuProveedores.Size = new System.Drawing.Size(143, 61);
            this.btnMenuProveedores.TabIndex = 5;
            this.btnMenuProveedores.Text = "Menu de Proveedores";
            this.btnMenuProveedores.UseVisualStyleBackColor = true;
            this.btnMenuProveedores.Click += new System.EventHandler(this.btnMenuProveedores_Click);
            // 
            // btnMenuDeContratos
            // 
            this.btnMenuDeContratos.Location = new System.Drawing.Point(172, 55);
            this.btnMenuDeContratos.Name = "btnMenuDeContratos";
            this.btnMenuDeContratos.Size = new System.Drawing.Size(162, 61);
            this.btnMenuDeContratos.TabIndex = 6;
            this.btnMenuDeContratos.Text = "Menu de Contratos de Proveedores";
            this.btnMenuDeContratos.UseVisualStyleBackColor = true;
            this.btnMenuDeContratos.Click += new System.EventHandler(this.btnMenuDeContratos_Click);
            // 
            // MenuAdministrativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMenuDeContratos);
            this.Controls.Add(this.btnMenuProveedores);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnAbrirFormSesiones);
            this.Name = "MenuAdministrativo";
            this.Text = "MenuAdministrativo";
            this.Load += new System.EventHandler(this.MenuAdministrativo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirFormSesiones;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnMenuProveedores;
        private System.Windows.Forms.Button btnMenuDeContratos;
    }
}