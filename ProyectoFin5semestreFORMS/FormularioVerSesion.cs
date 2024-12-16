using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFin5semestreFORMS
{
    public partial class FormularioVerSesion : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public FormularioVerSesion()
        {
            InitializeComponent();
        }

        private void FormularioVerSesion_Load(object sender, EventArgs e)
        {
            CargarSesiones();
        }
        private void CargarSesiones()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM sesion";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Asignamos el DataTable al DataGridView
                dgvSesiones.DataSource = dataTable;
            }
        }
    }
}
