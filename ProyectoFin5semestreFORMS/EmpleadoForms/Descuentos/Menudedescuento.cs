using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFin5semestreFORMS.EmpleadoForms.Descuentos
{
    public partial class Menudedescuento : Form
    {
        public Menudedescuento()
        {
            InitializeComponent();
        }

        private void Menudedescuento_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrearDescuento_Click(object sender, EventArgs e)
        {
            CrearDescuentoForm frm = new CrearDescuentoForm();

        frm.ShowDialog();
        }

        private void btnVerDescuento_Click(object sender, EventArgs e)
        {
            VerDescuentosForm frm = new VerDescuentosForm();
            frm.ShowDialog();
        }

        private void btnActualizarDescuento_Click(object sender, EventArgs e)
        {
            ActualizarDescuentoForms frm = new ActualizarDescuentoForms();
            frm.ShowDialog();
        }
    }
}
