using ProyectoFin5semestreFORMS.AdministradorForms.Proveedores;
using ProyectoFin5semestreFORMS.AdministradorForms.ProveedoresAlientos;
using ProyectoFin5semestreFORMS.AdministradorForms.ProveedoresSeguridad;
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
    public partial class MenuProveedores : Form
    {
        public MenuProveedores()
        {
            InitializeComponent();
        }

        private void btnCrearProveedor_Click(object sender, EventArgs e)
        {
            CrearProveedor crearProveedor = new CrearProveedor();
            crearProveedor.ShowDialog();
        }

        private void btnVerProveedores_Click(object sender, EventArgs e)
        {
            VerProveedores verProveedores = new VerProveedores();
            verProveedores.ShowDialog();
        }

        private void btnActualizarProveedores_Click(object sender, EventArgs e)
        {
            ActualizarProveedor actualizarProveedor = new ActualizarProveedor();
            actualizarProveedor.ShowDialog();
        }

        private void btnCrearProveAlimento_Click(object sender, EventArgs e)
        {
            CreaProveeAlimento creaProveeAlimento = new CreaProveeAlimento();
            creaProveeAlimento.ShowDialog();
        }

        private void btnVerProveAlimento_Click(object sender, EventArgs e)
        {
            VerProveAlimentos verProveAlimentos = new VerProveAlimentos();
            verProveAlimentos.ShowDialog();
        }

        private void btnActualizaProveAlimento_Click(object sender, EventArgs e)
        {
            ActualizaProveAlimentos actualizaProveAlimentos = new ActualizaProveAlimentos();
            actualizaProveAlimentos.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreaProveSeguridad_Click(object sender, EventArgs e)
        {
            CrearProveeSeguridad crearProveeSeguridad = new CrearProveeSeguridad();
            crearProveeSeguridad.ShowDialog();
        }

        private void btnVerProveSeguridad_Click(object sender, EventArgs e)
        {
            VerProveeSeguridad verProveeSeguridad = new VerProveeSeguridad();
            verProveeSeguridad.ShowDialog();
        }

        private void btnActualizaProveSeguridad_Click(object sender, EventArgs e)
        {
            ActualizaProveeSeguridad actualizaProveeSeguridad = new ActualizaProveeSeguridad();
            actualizaProveeSeguridad.ShowDialog();
        }
    }
}
