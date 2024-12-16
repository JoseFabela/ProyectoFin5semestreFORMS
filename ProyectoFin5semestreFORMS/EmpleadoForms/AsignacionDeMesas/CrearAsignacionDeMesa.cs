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
    public partial class CrearAsignacionDeMesa : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public CrearAsignacionDeMesa()
        {
            InitializeComponent();
            // Agregar estados al ComboBox
            cmbEstadoAsignacion.Items.Add("Abierta");
            cmbEstadoAsignacion.Items.Add("Cerrada");
            // Agrega más estados si es necesario

            // Seleccionar el primer elemento por defecto
            if (cmbEstadoAsignacion.Items.Count > 0)
            {
                cmbEstadoAsignacion.SelectedIndex = 0;
            }
        }

        private void btnCrearAsignacion_Click(object sender, EventArgs e)
        {

            if (cmbMesa.SelectedItem == null || cmbEmpleado.SelectedItem == null || cmbEstadoAsignacion.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona una mesa, un empleado y un estado.");
                return;
            }

            // Verificar que SelectedValue no sea null y sea convertible a int
            if (cmbMesa.SelectedValue == null || cmbEmpleado.SelectedValue == null)
            {
                MessageBox.Show("Error al obtener los IDs de la mesa o del empleado.");
                return;
            }

            int mesaId;
            int empleadoId;

            if (!int.TryParse(cmbMesa.SelectedValue.ToString(), out mesaId))
            {
                MessageBox.Show("ID de mesa inválido.");
                return;
            }

            if (!int.TryParse(cmbEmpleado.SelectedValue.ToString(), out empleadoId))
            {
                MessageBox.Show("ID de empleado inválido.");
                return;
            }

            string estado = cmbEstadoAsignacion.SelectedItem.ToString();

            if (CrearAsignacionMesa(mesaId, empleadoId, estado))
            {
                MessageBox.Show("Asignación creada con éxito.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubo un error al crear la asignación.");
            }
        }
        private bool CrearAsignacionMesa(int mesaId, int empleadoId, string estado)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO asignacion_mesa (mesa_id, empleado_id, fecha, estado)
                             VALUES (@mesaId, @empleadoId, @fecha, @estado)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@mesaId", mesaId);
                        cmd.Parameters.AddWithValue("@empleadoId", empleadoId);
                        cmd.Parameters.AddWithValue("@fecha", DateTime.Now); // Fecha y hora actual
                        cmd.Parameters.AddWithValue("@estado", estado);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la asignación: " + ex.Message);
                return false;
            }
        }

        private void CrearAsignacionDeMesa_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarMesas();
        }
        private void CargarMesas()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, tipo_de_juego FROM mesa_de_juego WHERE estado = 'Abierta'"; // Ajusta el filtro según tu lógica

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbMesa.DisplayMember = "tipo_de_juego"; // Campo que se mostrará
                        cmbMesa.ValueMember = "id"; // Campo que representará el valor
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

                        cmbEmpleado.DisplayMember = "nombre"; // Campo que se mostrará
                        cmbEmpleado.ValueMember = "id"; // Campo que representará el valor
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



    }
}
