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

namespace ProyectoFin5semestreFORMS.AdministradorForms.ProveedoresAlientos
{
    public partial class ActualizaProveAlimentos : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public ActualizaProveAlimentos()
        {
            InitializeComponent();
        }

        private void ActualizaProveAlimentos_Load(object sender, EventArgs e)
        {
            CargarSeleccionarProveedores();
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cmbSeleccionarProveedor.Items.Count > 0)
            {
                cmbSeleccionarProveedor.SelectedIndex = 0;
            }
            if (cmbEstado.Items.Count > 0)
            {
                cmbEstado.SelectedIndex = 0;
            }
        }

        private bool ActualizarProveedorr(int id, string nombre, string tipo_producto, string estado)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE proveedor_alimentos
                             SET nombre = @nombre, tipo_producto = @tipo_producto, estado = @estado
                             WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Recomendación: Usar Add en lugar de AddWithValue para mayor control sobre los tipos de datos
                        cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 255).Value = nombre;
                        cmd.Parameters.Add("@tipo_producto", SqlDbType.NVarChar, 255).Value = tipo_producto;
                        cmd.Parameters.Add("@estado", SqlDbType.NVarChar, 50).Value = estado;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Manejar errores específicos de SQL
                MessageBox.Show("Error al actualizar el proveedor: " + sqlEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el proveedor: " + ex.Message);
                return false;
            }
             
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cmbSeleccionarProveedor.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona un proveedor para actualizar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtTipo_Producto.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            int proveedorId;
            if (!int.TryParse(cmbSeleccionarProveedor.SelectedValue.ToString(), out proveedorId))
            {
                MessageBox.Show("ID de proveedor inválido.");
                return;
            }

            string nombre = txtNombre.Text.Trim();
            string tipo_producto = txtTipo_Producto.Text.Trim();
            string estado = cmbEstado.SelectedItem.ToString();
            
            // Validar si el proveedor con el nuevo nombre ya existe (si cambió el nombre)
            string proveedorSeleccionadoNombre = cmbSeleccionarProveedor.Text;
            if (nombre != proveedorSeleccionadoNombre && ExisteProveedor(nombre))
            {
                MessageBox.Show("Ya existe un proveedor con ese nombre.");
                return;
            }

            if (ActualizarProveedorr(proveedorId, nombre, tipo_producto, estado))
            {
                MessageBox.Show("Proveedor actualizado con éxito.");
                this.Close();

            }
            else
            {
                MessageBox.Show("Hubo un error al actualizar el proveedor.");
            }
        }
        // Método para cargar proveedores en el ComboBox de selección
        private void CargarSeleccionarProveedores()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, nombre FROM proveedor_alimentos";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbSeleccionarProveedor.DisplayMember = "nombre";
                        cmbSeleccionarProveedor.ValueMember = "id";
                        cmbSeleccionarProveedor.DataSource = dt;
                    }
                }

                if (cmbSeleccionarProveedor.Items.Count > 0)
                    cmbSeleccionarProveedor.SelectedIndex = -1; // No seleccionar ningún proveedor por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los proveedores en el ComboBox: " + ex.Message);
            }
        }


        private bool ExisteProveedor(string nombre)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM proveedor_alimentos WHERE nombre = @nombre";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el proveedor: " + ex.Message);
                return false;
            }
        }

        private void cmbSeleccionarProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSeleccionarProveedor.SelectedValue != null)
            {
                int proveedorId;
                if (int.TryParse(cmbSeleccionarProveedor.SelectedValue.ToString(), out proveedorId))
                {
                    CargarDatosProveedor(proveedorId);
                }
            }
        }
        private void CargarDatosProveedor(int proveedorId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT nombre, tipo_producto
                                     FROM proveedor_alimentos
                                     WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", proveedorId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNombre.Text = reader["nombre"].ToString();
                                txtTipo_Producto.Text = reader["tipo_producto"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del proveedor: " + ex.Message);
            }
        }
    }
}
