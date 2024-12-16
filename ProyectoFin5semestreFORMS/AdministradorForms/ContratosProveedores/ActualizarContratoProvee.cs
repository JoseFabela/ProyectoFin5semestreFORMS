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
    public partial class ActualizarContratoProvee : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public ActualizarContratoProvee()
        {
            InitializeComponent();
        }
       
        private void ActualizarContratoProvee_Load(object sender, EventArgs e)
        {
            // Configurar el ComboBox de Estado
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;

            // Cargar proveedores y contratos
            CargarProveedores();
            CargarContratos();

            // Seleccionar el primer contrato si existe
            if (cmbContrato.Items.Count > 0)
            {
                cmbContrato.SelectedIndex = 0;
            }

            // Seleccionar el primer estado si existe
            if (cmbEstado.Items.Count > 0)
            {
                cmbEstado.SelectedIndex = 0;
            }

            // Cargar los detalles del contrato seleccionado
            if (cmbContrato.SelectedValue != null && int.TryParse(cmbContrato.SelectedValue.ToString(), out int contratoId))
            {
                CargarDetallesContrato(contratoId);
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            // Validar selección de contrato
            if (!int.TryParse(cmbContrato.SelectedValue?.ToString(), out int contratoId))
            {
                MessageBox.Show("Por favor, selecciona un contrato válido.");
                return;
            }

            // Validar selección de proveedor
            if (!int.TryParse(cmbProveedor.SelectedValue?.ToString(), out int proveedorId))
            {
                MessageBox.Show("Por favor, selecciona un proveedor válido.");
                return;
            }

            // Obtener valores de los controles
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime? fechaFin = dtpFechaFin.Checked ? (DateTime?)dtpFechaFin.Value : null;
            string condiciones = txtCondiciones.Text.Trim();

            // Validar fechas
            if (fechaFin.HasValue && fechaFin.Value < fechaInicio)
            {
                MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio.");
                return;
            }

            // Validar longitud de condiciones
            if (condiciones.Length > 255)
            {
                MessageBox.Show("Las condiciones no pueden exceder los 255 caracteres.");
                return;
            }

            // Obtener el estado seleccionado
            string estado = cmbEstado.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(estado))
            {
                MessageBox.Show("Por favor, selecciona un estado para el contrato.");
                return;
            }

            // Actualizar el contrato en la base de datos
            if (ActualizarContrato(contratoId, proveedorId, fechaInicio, fechaFin, condiciones, estado))
            {
                MessageBox.Show("Contrato actualizado con éxito.");
                Close();
            }
            else
            {
                MessageBox.Show("Hubo un error al actualizar el contrato.");
            }
        }
       

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbContrato.SelectedValue != null && int.TryParse(cmbContrato.SelectedValue.ToString(), out int contratoId))
            {
                CargarDetallesContrato(contratoId);
            }
        }
        private void CargarProveedores()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, nombre FROM proveedor";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbProveedor.DisplayMember = "nombre"; // Nombre visible
                        cmbProveedor.ValueMember = "id";       // Valor subyacente
                        cmbProveedor.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message);
            }
        }

        private void CargarContratos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id FROM contrato_proveedor";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbContrato.DisplayMember = "id";
                        cmbContrato.ValueMember = "id";
                        cmbContrato.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar contratos: " + ex.Message);
            }
        }

        private void CargarDetallesContrato(int contratoId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT fecha_inicio, fecha_fin, condiciones, proveedor_id, estado 
                                     FROM contrato_proveedor 
                                     WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = contratoId;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dtpFechaInicio.Value = Convert.ToDateTime(reader["fecha_inicio"]);

                                if (reader["fecha_fin"] != DBNull.Value)
                                {
                                    dtpFechaFin.Value = Convert.ToDateTime(reader["fecha_fin"]);
                                    dtpFechaFin.Checked = true;
                                }
                                else
                                {
                                    dtpFechaFin.Checked = false;
                                }

                                txtCondiciones.Text = reader["condiciones"].ToString();
                                cmbProveedor.SelectedValue = reader["proveedor_id"];

                                // Establecer el estado en el ComboBox cmbEstado
                                string estado = reader["estado"].ToString();
                                if (cmbEstado.Items.Contains(estado))
                                {
                                    cmbEstado.SelectedItem = estado;
                                }
                                else
                                {
                                    cmbEstado.SelectedIndex = -1; // No seleccionar si el estado no está en la lista
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los detalles del contrato: " + ex.Message);
            }
        }

        private bool ActualizarContrato(int contratoId, int proveedorId, DateTime fechaInicio, DateTime? fechaFin, string condiciones, string estado)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE contrato_proveedor
                                     SET proveedor_id = @proveedor_id,
                                         fecha_inicio = @fecha_inicio,
                                         fecha_fin = @fecha_fin,
                                         condiciones = @condiciones,
                                         estado = @estado
                                     WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@proveedor_id", SqlDbType.Int).Value = proveedorId;
                        cmd.Parameters.Add("@fecha_inicio", SqlDbType.DateTime).Value = fechaInicio;

                        if (fechaFin.HasValue)
                            cmd.Parameters.Add("@fecha_fin", SqlDbType.DateTime).Value = fechaFin.Value;
                        else
                            cmd.Parameters.Add("@fecha_fin", SqlDbType.DateTime).Value = DBNull.Value;

                        cmd.Parameters.Add("@condiciones", SqlDbType.NVarChar, 255).Value = condiciones;
                        cmd.Parameters.Add("@estado", SqlDbType.NVarChar, 50).Value = estado; // Nuevo parámetro para estado
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = contratoId;

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el contrato: " + ex.Message);
                return false;
            }
        }
    }
}
