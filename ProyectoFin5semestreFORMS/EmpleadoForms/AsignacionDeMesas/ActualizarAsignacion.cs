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
    public partial class ActualizarAsignacion : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public ActualizarAsignacion()
        {
            InitializeComponent();
            cmbEstadoAsignacion.Items.Add("Activo");
            cmbEstadoAsignacion.Items.Add("Inactivo");
            // Seleccionar el primer elemento por defecto
            if (cmbEstadoAsignacion.Items.Count > 0)
            {
                cmbEstadoAsignacion.SelectedIndex = 0;
            }
        }

        private void ActualizarAsignacion_Load(object sender, EventArgs e)
        {
            CargarAsignaciones();
            CargarMesas();
            CargarEmpleados();
            // Opcional: Cargar asignaciones en el DataGridView
        }
       

        private void btnActualizarAsignacion_Click(object sender, EventArgs e)
        {
            if (cmbAsignacionId.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona una asignación a actualizar.");
                return;
            }

            int asignacionId;
            if (!int.TryParse(cmbAsignacionId.SelectedValue.ToString(), out asignacionId))
            {
                MessageBox.Show("ID de asignación inválido.");
                return;
            }

            int mesaId;
            int empleadoId;

            if (cmbMesa.SelectedValue == null || !int.TryParse(cmbMesa.SelectedValue.ToString(), out mesaId))
            {
                MessageBox.Show("Por favor, selecciona una mesa válida.");
                return;
            }

            if (cmbEmpleado.SelectedValue == null || !int.TryParse(cmbEmpleado.SelectedValue.ToString(), out empleadoId))
            {
                MessageBox.Show("Por favor, selecciona un empleado válido.");
                return;
            }

            string estado = cmbEstadoAsignacion.SelectedItem.ToString();

            if (ActualizarAsignacionMesa(asignacionId, mesaId, empleadoId, estado))
            {
                MessageBox.Show("Asignación actualizada con éxito.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubo un error al actualizar la asignación.");
            }
        }
        private bool ActualizarAsignacionMesa(int asignacionId, int mesaId, int empleadoId, string estado)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE asignacion_mesa 
                             SET mesa_id = @mesaId, empleado_id = @empleadoId, estado = @estado 
                             WHERE id = @asignacionId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@mesaId", mesaId);
                        cmd.Parameters.AddWithValue("@empleadoId", empleadoId);
                        cmd.Parameters.AddWithValue("@estado", estado);
                        cmd.Parameters.AddWithValue("@asignacionId", asignacionId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la asignación: " + ex.Message);
                return false;
            }
        }
        private void CargarDatosAsignacion(int asignacionId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT mesa_id, empleado_id, estado
                                     FROM asignacion_mesa
                                     WHERE id = @asignacionId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@asignacionId", asignacionId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int mesaId = Convert.ToInt32(reader["mesa_id"]);
                                int empleadoId = Convert.ToInt32(reader["empleado_id"]);
                                string estado = reader["estado"].ToString();

                                cmbMesa.SelectedValue = mesaId;
                                cmbEmpleado.SelectedValue = empleadoId;
                                cmbEstadoAsignacion.SelectedItem = estado;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la asignación: " + ex.Message);
            }
        }
        private void CargarAsignaciones()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT id, CONCAT('Asignación ', id) AS Descripcion FROM asignacion_mesa";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbAsignacionId.DisplayMember = "Descripcion";
                        cmbAsignacionId.ValueMember = "id";
                        cmbAsignacionId.DataSource = dt;
                    }
                }

                if (cmbAsignacionId.Items.Count > 0)
                    cmbAsignacionId.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las asignaciones: " + ex.Message);
            }
        }

        private void CargarMesas()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, tipo_de_juego FROM mesa_de_juego";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbMesa.DisplayMember = "tipo_de_juego";
                        cmbMesa.ValueMember = "id";
                        cmbMesa.DataSource = dt;
                    }
                }

                if (cmbMesa.Items.Count > 0)
                    cmbMesa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las mesas: " + ex.Message);
            }
        }

        private void CargarEmpleados()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, nombre FROM empleado";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbEmpleado.DisplayMember = "nombre";
                        cmbEmpleado.ValueMember = "id";
                        cmbEmpleado.DataSource = dt;
                    }
                }

                if (cmbEmpleado.Items.Count > 0)
                    cmbEmpleado.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los empleados: " + ex.Message);
            }
        }

        private void cmbAsignacionId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAsignacionId.SelectedValue != null)
            {
                int asignacionId;
                if (int.TryParse(cmbAsignacionId.SelectedValue.ToString(), out asignacionId))
                {
                    CargarDatosAsignacion(asignacionId);
                }
            }
        }

        private void cmbEstadoAsignacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
