using ProyectoFin5semestreFORMS.AdministradorForms;
using ProyectoFin5semestreFORMS.AdministradorForms.Proveedores;
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
    public partial class MenuAdministrativo : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";
        private int empleadoId;  // Variable para almacenar el empleadoId

        public MenuAdministrativo(int empleadoId)
        {
            InitializeComponent();
            this.empleadoId = empleadoId;  // Asignamos el empleadoId recibido al campo de la clase

        }

        private void btnAbrirFormSesiones_Click(object sender, EventArgs e)
        {
            FormularioVerSesion formulario = new FormularioVerSesion();
            formulario.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {

            // Registrar el fin del turno
            if (RegistrarFinTurno(empleadoId)& EncontrarIdSesion(empleadoId))
            {

                MessageBox.Show("Turno registrado como finalizado.");
                MessageBox.Show("Sesion registrado como expirada.");

                // Cerrar el formulario actual
                this.Close();

                // Abrir el formulario de inicio de sesión
                Form1 loginForm = new Form1();
                loginForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error al registrar el fin del turno.");
            }
        }
        // Método para registrar el fin del turno en la base de datos
        private bool RegistrarFinTurno(int empleadoId)
        {
            try
            {
                DateTime finTurno = DateTime.Now;  // Obtener la fecha y hora actual

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Consulta para actualizar la hora de fin del turno
                    string query = "UPDATE turno_trabajo SET fin = @fin WHERE empleado_id = @empleadoId AND fin IS NULL";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@empleadoId", empleadoId);
                        cmd.Parameters.AddWithValue("@fin", finTurno);  // Usamos la hora actual para el fin del turno

                        // Ejecutar la consulta y obtener el número de filas afectadas
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;  // Si la consulta afectó alguna fila, el turno fue actualizado
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el fin del turno: " + ex.Message);
                return false;
            }
        }
        private bool EncontrarIdSesion(int empleadoId)
        {
            try
            {
                DateTime finTurno = DateTime.Now;  // Obtener la fecha y hora actual

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Consulta para actualizar la hora de fin del turno
                    string query = "UPDATE sesion SET estado = 'expirada' WHERE empleado_id = @empleadoId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@empleadoId", empleadoId);

                        // Ejecutar la consulta y obtener el número de filas afectadas
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;  // Si la consulta afectó alguna fila, el turno fue actualizado
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el fin del turno: " + ex.Message);
                return false;
            }
        }
        private void btnMenuProveedores_Click(object sender, EventArgs e)
        {
            MenuProveedores menuProveedores = new MenuProveedores();
            menuProveedores.ShowDialog();
        }

        private void btnMenuDeContratos_Click(object sender, EventArgs e)
        {
           MenuContratos menuContratos = new MenuContratos();
            menuContratos.ShowDialog();
        }

        private void MenuAdministrativo_Load(object sender, EventArgs e)
        {

        }
    }
}