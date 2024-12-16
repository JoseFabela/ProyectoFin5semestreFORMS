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
    public partial class ActualizarRecursos : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public ActualizarRecursos()
        {
            InitializeComponent();
        }

        private void ActualizarRecursos_Load(object sender, EventArgs e)
        {
            CargarRecursos();
            // Configurar el ComboBox de Estado
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            // Seleccionar el primer estado si existe
            if (cmbEstado.Items.Count > 0)
            {
                cmbEstado.SelectedIndex = 0;
            }
        }
        private void CargarRecursos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, tipo FROM recurso";

                   
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbRecurso.DisplayMember = "tipo"; // Nombre visible
                        cmbRecurso.ValueMember = "id";       // Valor subyacente
                        cmbRecurso.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar recursos: " + ex.Message);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
           

            int recursoId = Convert.ToInt32(cmbRecurso.SelectedValue.ToString());
            string tipo = txtTipo.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            int cantidadDisponible = (int)nudCantidadDisponible.Value;
            string estado = cmbEstado.SelectedItem.ToString();

            // Validaciones
            if (string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            if (ActualizarRecurso(recursoId, tipo, descripcion, cantidadDisponible, estado))
            {
                MessageBox.Show("Recurso actualizado con éxito.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubo un error al actualizar el recurso.");
            }
        }
        private bool ActualizarRecurso(int id, string tipo, string descripcion, int cantidadDisponible, string estado)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE recurso
                             SET tipo = @tipo,
                                 descripcion = @descripcion,
                                 cantidad_disponible = @cantidad_disponible,
                                 estado = @estado
                             WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@tipo", SqlDbType.NVarChar, 255).Value = tipo;
                        cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar, 255).Value = descripcion;
                        cmd.Parameters.Add("@cantidad_disponible", SqlDbType.Int).Value = cantidadDisponible;
                        cmd.Parameters.Add("@estado", SqlDbType.NVarChar, 255).Value = estado;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el recurso: " + ex.Message);
                return false;
            }
        }
    }
}
