using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFin5semestreFORMS.EmpleadoForms.Apuestas
{
    public partial class MenuDeApuestas : Form
    {
        public MenuDeApuestas()
        {
            InitializeComponent();
        }

        private void MenuDeApuestas_Load(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            CreaApuestaForm creaApuestaForm = new CreaApuestaForm();
            creaApuestaForm.ShowDialog();
        }

        private void btnVerApuesta_Click(object sender, EventArgs e)
        {
            VerApuestaForm verApuestaForm=new VerApuestaForm();
            verApuestaForm.ShowDialog();
        }

        private void btnActualizarApuesta_Click(object sender, EventArgs e)
        {
            ActualizaApuestaForm actualizaApuestaForm = new ActualizaApuestaForm();
               actualizaApuestaForm.ShowDialog();
        }
    }
}
