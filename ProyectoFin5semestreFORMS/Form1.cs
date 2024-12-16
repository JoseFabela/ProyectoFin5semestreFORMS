using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFin5semestreFORMS
{
    public partial class Form1 : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private bool RegistrarInicioTurno(int empleadoId)
        {
            try
            {
                DateTime inicioTurno = DateTime.Now;  // Obtener la fecha y hora actual

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Consulta para insertar un nuevo turno con la fecha y hora de inicio
                    string query = "INSERT INTO turno_trabajo (empleado_id, inicio) " +
                                   "VALUES (@empleadoId, @inicio)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@empleadoId", empleadoId);
                        cmd.Parameters.AddWithValue("@inicio", inicioTurno);  // Usamos la hora actual para el inicio del turno

                        // Ejecutar la consulta
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;  // Si la consulta afectó alguna fila, el turno fue registrado
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el inicio del turno: " + ex.Message);
                return false;
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // Iniciar sesión
            string usuario= txtUsuario.Text;

            string contrasena = txtContrasena.Text;

            // Obtenemos el rol del usuario al autenticarlo
            int rolId;
            int empleadoId = 0; // El ID del empleado se debería obtener de la base de datos al autenticar al usuario
            string estado;
            if (AutenticarUsuario(usuario, contrasena, out rolId, out empleadoId, out estado))
            {
                if (estado == "activo")
                {
                    MessageBox.Show("Inicio Exitoso");
                    // Registrar el inicio del turno
                    if (RegistrarInicioTurno(empleadoId))
                    {
                        // Crear sesión en la base de datos
                        if (CrearSesion(empleadoId))
                        {
                            // Verificar el rol del usuario
                            if (rolId == 2) // Rol administrativo
                            {

                                MenuAdministrativo formulario = new MenuAdministrativo(empleadoId);
                                formulario.Show();
                                this.Hide();

                            }
                            else if (rolId == 1) // Rol empleado
                            {
                                MenuDeEmpleados menuDeEmpleados = new MenuDeEmpleados(empleadoId);
                                menuDeEmpleados.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Rol no reconocido. Acceso denegado.");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No esta activo este usuario");
                }
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Acceso denegado.");
            }

        }


        static string EncriptarContrasena(string contrasena)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir la contraseña a bytes y hacer el hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contrasena));

                // Convertir los bytes a un string hexadecimal
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private bool AutenticarUsuario(string usuario, string contrasena, out int rolId, out int empleadoId, out string estado)
        {
            rolId = 0;
            empleadoId = 0;
            estado = string.Empty;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Consulta SQL para verificar el usuario y la contraseña en la tabla 'empleado'
                string query = "SELECT id, rol_id, estado FROM empleado WHERE usuario = @usuario AND contrasena = @contrasena";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", EncriptarContrasena(contrasena));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            empleadoId = reader.GetInt32(0); // Obtener el ID del empleado
                            rolId = reader.GetInt32(1); // Obtener el rol del usuario
                            estado = reader.GetString(2);
                            return true; // Usuario autenticado
                        }
                    }
                }
            }

            return false; // Si no se encuentra el usuario, autenticación fallida
        }

        private bool CrearSesion(int empleadoId)
        {
            try
            {
                // Generar un token único para la sesión
                string token = Guid.NewGuid().ToString();

                // Definir la fecha de expiración (ejemplo: 1 hora después de la fecha de inicio)
                DateTime fechaInicio = DateTime.Now;
                DateTime fechaExpiracion = fechaInicio.AddHours(1);

                // Establecer el estado de la sesión (puede ser "Activa" o "Inactiva")
                string estado = "Activa";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO sesion (empleado_id, fecha_inicio, fecha_expiracion, token, estado) " +
                                   "VALUES (@empleadoId, @fechaInicio, @fechaExpiracion, @token, @estado)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@empleadoId", empleadoId);
                        cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@fechaExpiracion", fechaExpiracion);
                        cmd.Parameters.AddWithValue("@token", token);
                        cmd.Parameters.AddWithValue("@estado", estado);

                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la sesión: " + ex.Message);
                return false;
            }
        }

        

    }
}
