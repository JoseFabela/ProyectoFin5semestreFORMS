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

namespace ProyectoFin5semestreFORMS.EmpleadoForms.Descuentos
{
    public partial class ActualizarDescuentoForms : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public ActualizarDescuentoForms()
        {
            InitializeComponent();
        }
        private void ActualizarDescuento(int id, decimal porcentaje, string descripcion, DateTime fechaInicio, DateTime fechaFin, string nuevoEstado)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE descuento
                             SET porcentaje = @porcentaje,
                                 descripcion = @descripcion,
                                 fecha_inicio = @fecha_inicio,
                                 fecha_fin = @fecha_fin
                             WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@porcentaje", porcentaje);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@fecha_inicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@fecha_fin", fechaFin);
                        cmd.Parameters.AddWithValue("@estado", nuevoEstado);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Descuento actualizado correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el descuento: " + ex.Message);
            }
        }

        private void ActualizarDescuentoForms_Load(object sender, EventArgs e)
        {
            CargaComboBoxDescuentos();
            // Agregar estados al ComboBox
            cmbNuevoEstado.Items.Add("Abierta");
            cmbNuevoEstado.Items.Add("Cerrada");
            // Agrega más estados si es necesario

            // Seleccionar el primer elemento por defecto
            if (cmbNuevoEstado.Items.Count > 0)
            {
                cmbNuevoEstado.SelectedIndex = 0;
            }
            cmbPorcentaje.Items.Add("10%");
            cmbPorcentaje.Items.Add("20%");
            cmbPorcentaje.Items.Add("30%");
            cmbPorcentaje.Items.Add("40%");
            cmbPorcentaje.Items.Add("50%");
            cmbPorcentaje.Items.Add("60%");
            cmbPorcentaje.Items.Add("70%");
            cmbPorcentaje.Items.Add("80%");
            cmbPorcentaje.Items.Add("90%");
            cmbPorcentaje.Items.Add("100%");

            dtpInicio.Format = DateTimePickerFormat.Custom;
            dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpInicio.Value = DateTime.Now; // Establecer la fecha y hora actuales por defecto
            // Seleccionar el primer elemento por defecto
            if (cmbPorcentaje.Items.Count > 0)
            {
                cmbPorcentaje.SelectedIndex = 0;
            }
        }
        private decimal ObtenerPorcentajeDecimal()
        {
            // Verifica que se haya seleccionado un valor en el ComboBox
            if (cmbPorcentaje.SelectedItem != null)
            {
                // Extrae el valor seleccionado (por ejemplo: "10%")
                string porcentajeTexto = cmbPorcentaje.SelectedItem.ToString();

                // Elimina el símbolo de porcentaje '%' y convierte el valor a decimal
                decimal porcentaje = Convert.ToDecimal(porcentajeTexto.Replace("%", ""));

                return porcentaje;
            }
            else
            {
                // Si no hay selección, retornar 0 o algún valor por defecto
                MessageBox.Show("Por favor, seleccione un porcentaje.");
                return 0;
            }
        }
        private void CargaComboBoxDescuentos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, descripcion FROM descuento WHERE estado = 'Activo';"; // Solo recursos activos

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbDescuento.DisplayMember = "descripcion";
                        cmbDescuento.ValueMember = "id";
                        cmbDescuento.DataSource = dt;
                    }
                }

                if (cmbDescuento.Items.Count > 0)
                    cmbDescuento.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar recursos: " + ex.Message);
            }
        }
        private void btnCrea_Click(object sender, EventArgs e)
        {
            if (cmbNuevoEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un nuevo estado.");
                return;
            }
            string nuevoEstado = cmbNuevoEstado.SelectedItem.ToString();

            string descripcion = textBox1.Text;
            DateTime fechaInicio = dtpInicio.Value;
            DateTime fechaFin = dtpFinal.Value;
            decimal porcentaje = ObtenerPorcentajeDecimal();
            int DescuentoId = Convert.ToInt32(cmbDescuento.SelectedValue);
            ActualizarDescuento(DescuentoId, porcentaje, descripcion, fechaInicio, fechaFin, nuevoEstado);
            {
                this.Close();
            }
        }
    }
}
