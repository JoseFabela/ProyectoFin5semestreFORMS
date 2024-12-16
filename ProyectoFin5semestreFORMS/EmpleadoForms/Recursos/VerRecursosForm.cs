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

namespace ProyectoFin5semestreFORMS.EmpleadoForms.Recursos
{
    public partial class VerRecursosForm : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public VerRecursosForm()
        {
            InitializeComponent();
        }
        private void CargarRecursos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, tipo, descripcion, cantidad_disponible, estado FROM recurso";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridViewRecursos.DataSource = dt;

                        // Configurar columnas
                        if (dataGridViewRecursos.Columns.Contains("id"))
                        {
                            dataGridViewRecursos.Columns["id"].Visible = false; // Ocultar columna 'id'
                        }

                        if (dataGridViewRecursos.Columns.Contains("tipo"))
                        {
                            dataGridViewRecursos.Columns["tipo"].HeaderText = "Tipo";
                        }

                        if (dataGridViewRecursos.Columns.Contains("descripcion"))
                        {
                            dataGridViewRecursos.Columns["descripcion"].HeaderText = "Descripción";
                        }

                        if (dataGridViewRecursos.Columns.Contains("cantidad_disponible"))
                        {
                            dataGridViewRecursos.Columns["cantidad_disponible"].HeaderText = "Cantidad Disponible";
                        }

                        if (dataGridViewRecursos.Columns.Contains("estado"))
                        {
                            dataGridViewRecursos.Columns["estado"].HeaderText = "Estado";
                        }

                        // Ajustar el modo de autoajuste de columnas
                        dataGridViewRecursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar recursos: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VerRecursosForm_Load(object sender, EventArgs e)
        {
            CargarRecursos();
        }
    }
}
