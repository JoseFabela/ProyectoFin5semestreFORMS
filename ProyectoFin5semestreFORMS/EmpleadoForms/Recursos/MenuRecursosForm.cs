using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFin5semestreFORMS.EmpleadoForms.Recursos
{
    public partial class MenuRecursosForm : Form
    {
        public MenuRecursosForm()
        {
            InitializeComponent();
        }

        private void MenuRecursosForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CreaRecursos creaRecursos = new CreaRecursos();
               creaRecursos.ShowDialog();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            VerRecursosForm verRecursosForm = new VerRecursosForm();
            verRecursosForm.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarRecursos actualizarRecursos = new ActualizarRecursos();
            actualizarRecursos.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
