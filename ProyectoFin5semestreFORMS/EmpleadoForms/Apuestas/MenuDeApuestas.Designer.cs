namespace ProyectoFin5semestreFORMS.EmpleadoForms.Apuestas
{
    partial class MenuDeApuestas
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
            this.btnActualizarApuesta = new System.Windows.Forms.Button();
            this.btnVerApuesta = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnActualizarApuesta
            // 
            this.btnActualizarApuesta.Location = new System.Drawing.Point(25, 163);
            this.btnActualizarApuesta.Name = "btnActualizarApuesta";
            this.btnActualizarApuesta.Size = new System.Drawing.Size(125, 62);
            this.btnActualizarApuesta.TabIndex = 5;
            this.btnActualizarApuesta.Text = "Actualizar Una Apuesta";
            this.btnActualizarApuesta.UseVisualStyleBackColor = true;
            this.btnActualizarApuesta.Click += new System.EventHandler(this.btnActualizarApuesta_Click);
            // 
            // btnVerApuesta
            // 
            this.btnVerApuesta.Location = new System.Drawing.Point(25, 97);
            this.btnVerApuesta.Name = "btnVerApuesta";
            this.btnVerApuesta.Size = new System.Drawing.Size(125, 38);
            this.btnVerApuesta.TabIndex = 4;
            this.btnVerApuesta.Text = "Ver Apuesta";
            this.btnVerApuesta.UseVisualStyleBackColor = true;
            this.btnVerApuesta.Click += new System.EventHandler(this.btnVerApuesta_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(25, 44);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(125, 38);
            this.btnCrear.TabIndex = 3;
            this.btnCrear.Text = "Crear Apuesta";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // MenuDeApuestas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnActualizarApuesta);
            this.Controls.Add(this.btnVerApuesta);
            this.Controls.Add(this.btnCrear);
            this.Name = "MenuDeApuestas";
            this.Text = "MenuDeApuestas";
            this.Load += new System.EventHandler(this.MenuDeApuestas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnActualizarApuesta;
        private System.Windows.Forms.Button btnVerApuesta;
        private System.Windows.Forms.Button btnCrear;
    }
}