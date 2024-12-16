using ProyectoFin5semestreFORMS.AdministradorForms.ContratosProveedores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFin5semestreFORMS.AdministradorForms
{
    public partial class MenuContratos : Form
    {
        public MenuContratos()
        {
            InitializeComponent();
        }

        private void btnCrearContrato_Click(object sender, EventArgs e)
        {
            CreaContratoProvee creaContratoProvee = new CreaContratoProvee();  
            creaContratoProvee.ShowDialog();
        }

        private void MenuContratos_Load(object sender, EventArgs e)
        {

        }

        private void btnVerContrato_Click(object sender, EventArgs e)
        {
            VerContratoProvee verContratoProvee = new VerContratoProvee();
            verContratoProvee.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizarContrato_Click(object sender, EventArgs e)
        {
            ActualizarContratoProvee actualizarContratoProvee = new ActualizarContratoProvee();
            actualizarContratoProvee.ShowDialog();
        }
    }
}
