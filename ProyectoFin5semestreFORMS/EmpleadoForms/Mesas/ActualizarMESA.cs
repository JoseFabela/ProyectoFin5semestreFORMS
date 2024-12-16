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
    public partial class ActualizarMESA : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public ActualizarMESA()
        {
            InitializeComponent();
            // Agregar estados al ComboBox
            cmbNuevoEstado.Items.Add("Abierta");
            cmbNuevoEstado.Items.Add("Cerrada");
            // Agrega más estados si es necesario

            // Seleccionar el primer elemento por defecto
            if (cmbNuevoEstado.Items.Count > 0)
            {
                cmbNuevoEstado.SelectedIndex = 0;
            }
        }

        private void btnActualizarEstado_Click(object sender, EventArgs e)
        {
            int mesaId;
            if (!int.TryParse(txtMesaIdActualizar.Text, out mesaId))
            {
                MessageBox.Show("Por favor, ingresa un ID de mesa válido.");
                return;
            }

            if (cmbNuevoEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un nuevo estado.");
                return;
            }

            string nuevoEstado = cmbNuevoEstado.SelectedItem.ToString();

            if (ActualizarEstadoMesa(mesaId, nuevoEstado))
            {
                MessageBox.Show("Estado de la mesa actualizado correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar el estado de la mesa.");
            }
        }
        private bool ActualizarEstadoMesa(int mesaId, string nuevoEstado)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "UPDATE mesa_de_juego SET estado = @estado WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                        cmd.Parameters.AddWithValue("@id", mesaId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el estado de la mesa: " + ex.Message);
                return false;
            }
        }

        private void ActualizarMESA_Load(object sender, EventArgs e)
        {

        }
    }
}
