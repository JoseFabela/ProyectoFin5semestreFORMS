using ProyectoFin5semestreFORMS.EmpleadoForms.Apuestas;
using ProyectoFin5semestreFORMS.EmpleadoForms.AsignacionDeMesas;
using ProyectoFin5semestreFORMS.EmpleadoForms.ControlDeEntrada;
using ProyectoFin5semestreFORMS.EmpleadoForms.Descuentos;
using ProyectoFin5semestreFORMS.EmpleadoForms.Recursos;
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
    public partial class MenuDeEmpleados : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";
        private int empleadoId;  // Variable para almacenar el empleadoId

        public MenuDeEmpleados(int empleadoId)
        {
            InitializeComponent();
            this.empleadoId = empleadoId;  // Asignamos el empleadoId recibido al campo de la clase

        }

        private void MenuDeEmpleados_Load(object sender, EventArgs e)
        {

        }


        private void CrearMesa_Click(object sender, EventArgs e)
        {
            CrearMesa crearMesa = new CrearMesa();
            crearMesa.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //VerMESA
            VerMesaDeJuego verMesaDeJuego = new VerMesaDeJuego();
            verMesaDeJuego.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Actualizar MESA
            ActualizarMESA actualizarMESA = new ActualizarMESA();
            actualizarMESA.ShowDialog();
        }

        private void tbnAsignarUnaMesa_Click(object sender, EventArgs e)
        {
           CrearAsignacionDeMesa crearAsignacionDeMesa = new CrearAsignacionDeMesa();
            crearAsignacionDeMesa.ShowDialog();
        }

        private void btnVerAsignaciones_Click(object sender, EventArgs e)
        {
            VerAsignacionesDeMesa verAsignacionesDeMesa = new VerAsignacionesDeMesa();
            verAsignacionesDeMesa.ShowDialog();
        }

        private void btnActualizarAsignacion_Click(object sender, EventArgs e)
        {
            ActualizarAsignacion actualizarAsignacion = new ActualizarAsignacion();
            actualizarAsignacion.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Registrar el fin del turno
            if (RegistrarFinTurno(empleadoId) & EncontrarIdSesion(empleadoId))
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

        private void btnAgregarEntrada_Click(object sender, EventArgs e)
        {
            ControlDeEntradaForm controlDeEntradaForm = new ControlDeEntradaForm();
            controlDeEntradaForm.ShowDialog();
        }

        private void btnRecursos_Click(object sender, EventArgs e)
        {
            MenuRecursosForm menuRecursosForm = new MenuRecursosForm();
            menuRecursosForm.ShowDialog();
        }





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

        private void btnMenuDeApuestas_Click(object sender, EventArgs e)
        {
            MenuDeApuestas menuDeApuestas = new MenuDeApuestas();
            menuDeApuestas.ShowDialog();
        }

        private void btnMenuDeDescuentos_Click(object sender, EventArgs e)
        {
            Menudedescuento menudedescuento = new Menudedescuento();
            menudedescuento.ShowDialog();
        }
    }
}
