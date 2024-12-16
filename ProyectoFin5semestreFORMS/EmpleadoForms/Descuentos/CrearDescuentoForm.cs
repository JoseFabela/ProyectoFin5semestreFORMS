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
    public partial class CrearDescuentoForm : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public CrearDescuentoForm()
        {
            InitializeComponent();
        }

        private void CrearDescuentoForm_Load(object sender, EventArgs e)
        {
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
        private void InsertarDescuento(decimal porcentaje, string descripcion, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO descuento (porcentaje, descripcion, fecha_inicio, fecha_fin, estado)
                             VALUES (@porcentaje, @descripcion, @fecha_inicio, @fecha_fin, 'activo')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@porcentaje", porcentaje);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@fecha_inicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@fecha_fin", fechaFin);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Descuento agregado correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el descuento: " + ex.Message);
            }
        }

        private void btnCrea_Click(object sender, EventArgs e)
        {
            
            string descripcion = textBox1.Text;
            DateTime fechaInicio = dtpInicio.Value;
            DateTime fechaFin = dtpFinal.Value;
            decimal porcentaje = ObtenerPorcentajeDecimal();

            InsertarDescuento(porcentaje, descripcion, fechaInicio, fechaFin);
            {
                this.Close();
            }
        }
        private decimal ObtenerPorcentajeDecimal()
        {
            // Verifica que se haya seleccionado un valor en el ComboBox
            if (cmbPorcentaje.SelectedItem != null)
            {
                // Extrae el valor seleccionado (por ejemplo: "10%")
                string porcentajeTexto = cmbPorcentaje.SelectedItem.ToString();

                // Elimina el símbolo '%' y convierte el valor restante a decimal
                porcentajeTexto = porcentajeTexto.Replace("%", "");

                // Convierte el porcentaje a decimal
                decimal porcentajeDecimal = Convert.ToDecimal(porcentajeTexto);

                return porcentajeDecimal;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un porcentaje.");
                return 0; // Valor predeterminado si no se selecciona un porcentaje
            }
        }


    }
}
