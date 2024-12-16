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

namespace ProyectoFin5semestreFORMS.AdministradorForms.ContratosProveedores
{
    public partial class CreaContratoProvee : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public CreaContratoProvee()
        {
            InitializeComponent();
        }
        

        private void CargarProveedores()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, nombre, 'General' AS tipo_proveedor FROM proveedor WHERE estado = 'Activo';";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbProveedor.DisplayMember = "nombre";
                        cmbProveedor.ValueMember = "id";
                        cmbProveedor.DataSource = dt;
                    }
                }

                if (cmbProveedor.Items.Count > 0)
                    cmbProveedor.SelectedIndex = -1; // No seleccionar por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los proveedores: " + ex.Message);
            }
        }

        private void CreaContratoProvee_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {

            if (cmbProveedor.SelectedValue == null ||
       string.IsNullOrWhiteSpace(dtpFechaInicio.Text) ||
       string.IsNullOrWhiteSpace(txtCondiciones.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.");
                return;
            }

            int proveedorId = Convert.ToInt32(cmbProveedor.SelectedValue);
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime? fechaFin = dtpFechaFin.Value != null ? (DateTime?)dtpFechaFin.Value : null;
            string condiciones = txtCondiciones.Text.Trim();

            
                
            


            if (CrearContrato(proveedorId, fechaInicio, fechaFin, condiciones))
            {
                MessageBox.Show("Contrato creado con éxito.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubo un error al crear el contrato.");
            }
        }
        private bool CrearContrato(int proveedorId, DateTime fechaInicio, DateTime? fechaFin, string condiciones)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO contrato_proveedor (proveedor_id, fecha_inicio, fecha_fin, condiciones, estado)
                                     VALUES (@proveedor_id, @fecha_inicio, @fecha_fin, @condiciones, 'activo')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@proveedor_id", SqlDbType.Int).Value = proveedorId;
                        cmd.Parameters.Add("@fecha_inicio", SqlDbType.DateTime).Value = fechaInicio;

                        if (fechaFin.HasValue)
                            cmd.Parameters.Add("@fecha_fin", SqlDbType.DateTime).Value = fechaFin.Value;
                        else
                            cmd.Parameters.Add("@fecha_fin", SqlDbType.DateTime).Value = DBNull.Value;

                        cmd.Parameters.Add("@condiciones", SqlDbType.NVarChar, 255).Value = condiciones;

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el contrato: " + ex.Message);
                return false;
            }
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
