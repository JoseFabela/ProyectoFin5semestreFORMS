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

namespace ProyectoFin5semestreFORMS.AdministradorForms.Proveedores
{
    public partial class CrearProveedor : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public CrearProveedor()
        {
            InitializeComponent();
        }

        private void CrearProveedor_Load(object sender, EventArgs e)
        {

        }
        // Método para verificar si un proveedor ya existe
        private bool ExisteProveedor(string nombre)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM proveedor WHERE nombre = @nombre";

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
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            if (txtNombre.Text.Length > 255 || txtCategoria.Text.Length > 255)
            {
                MessageBox.Show("Los campos no pueden exceder los 255 caracteres.");
                return;
            }

            string nombre = txtNombre.Text.Trim();
            string categoria = txtCategoria.Text.Trim();

            // Validar si el proveedor ya existe
            if (ExisteProveedor(nombre))
            {
                MessageBox.Show("Ya existe un proveedor con ese nombre.");
                return;
            }

            if (Crear(nombre, categoria))
            {
                MessageBox.Show("Proveedor creado con éxito.");
                
            }
            else
            {
                MessageBox.Show("Hubo un error al crear el proveedor.");
            }
        }
        // Método para crear un nuevo proveedor
        private bool Crear(string nombre, string categoria)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO proveedor (nombre, categoria, estado)
                                     VALUES (@nombre, @categoria, 'Activo')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@categoria", categoria);

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
