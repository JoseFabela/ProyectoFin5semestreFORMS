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
    public partial class CreaProveeAlimento : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public CreaProveeAlimento()
        {
            InitializeComponent();
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
        private void CreaProveeAlimento_Load(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtTipo_producto.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            if (txtNombre.Text.Length > 255 || txtTipo_producto.Text.Length > 255)
            {
                MessageBox.Show("Los campos no pueden exceder los 255 caracteres.");
                return;
            }

            string nombre = txtNombre.Text.Trim();
            string tipo_producto = txtTipo_producto.Text.Trim();

            // Validar si el proveedor ya existe
            if (ExisteProveedor(nombre))
            {
                MessageBox.Show("Ya existe un proveedor con ese nombre.");
                return;
            }

            if (Crear(nombre, tipo_producto))
            {
                MessageBox.Show("Proveedor creado con éxito.");
                this.Close();

            }
            else
            {
                MessageBox.Show("Hubo un error al crear el proveedor.");
            }
        }
        private bool Crear(string nombre, string tipo_producto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO proveedor_alimentos (nombre, tipo_producto, estado)
                                     VALUES (@nombre, @tipo_producto, 'Activo')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@tipo_producto", tipo_producto);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el proveedor: " + ex.Message);
                return false;
            }
        }



    }
}
