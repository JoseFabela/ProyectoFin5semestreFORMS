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

namespace ProyectoFin5semestreFORMS.EmpleadoForms.AsignacionDeMesas
{
    public partial class VerAsignacionesDeMesa : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public VerAsignacionesDeMesa()
        {
            InitializeComponent();
        }

        private void VerAsignacionesDeMesa_Load(object sender, EventArgs e)
        {
            CargarAsignaciones();
        }
        private void CargarAsignaciones()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT am.id, mj.tipo_de_juego AS Mesa, e.nombre AS Empleado, am.fecha AS Fecha, am.estado AS Estado
                             FROM asignacion_mesa am
                             JOIN mesa_de_juego mj ON am.mesa_id = mj.id
                             JOIN empleado e ON am.empleado_id = e.id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewAsignaciones.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las asignaciones: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
