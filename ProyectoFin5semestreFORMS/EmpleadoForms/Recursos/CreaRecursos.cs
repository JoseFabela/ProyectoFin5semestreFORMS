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
    public partial class CreaRecursos : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public CreaRecursos()
        {
            InitializeComponent();
        }

        private void CreaRecursos_Load(object sender, EventArgs e)
        {

        }
        private bool AgregarRecurso(string tipo, string descripcion, int cantidadDisponible)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO recurso (tipo, descripcion, cantidad_disponible, estado)
                                     VALUES (@tipo, @descripcion, @cantidad_disponible, 'activo')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@tipo", SqlDbType.NVarChar, 255).Value = tipo;
                        cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar, 255).Value = descripcion;
                        cmd.Parameters.Add("@cantidad_disponible", SqlDbType.Int).Value = cantidadDisponible;

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el recurso: " + ex.Message);
                return false;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string tipo = txtTipo.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            int cantidadDisponible = (int)nudCantidadDisponible.Value;

            // Validaciones
            if (string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            if (AgregarRecurso(tipo, descripcion, cantidadDisponible))
            {
                MessageBox.Show("Recurso agregado con éxito.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubo un error al agregar el recurso.");
            }
        }
    }
}
