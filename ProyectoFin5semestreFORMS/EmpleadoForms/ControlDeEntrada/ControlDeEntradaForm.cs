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

namespace ProyectoFin5semestreFORMS.EmpleadoForms.ControlDeEntrada
{
    public partial class ControlDeEntradaForm : Form
    {
        public ControlDeEntradaForm()
        {
            InitializeComponent();
        }
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";
        private void CargarJugadores()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, nombre FROM jugador WHERE estado = 'Activo';"; // Ajusta según tu estructura

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbJugador.DisplayMember = "nombre"; // Nombre visible
                        cmbJugador.ValueMember = "id";       // Valor subyacente
                        cmbJugador.DataSource = dt;
                    }
                }

                if (cmbJugador.Items.Count > 0)
                    cmbJugador.SelectedIndex = -1; // No seleccionar por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar jugadores: " + ex.Message);
            }
        }

        private void CargarEntradas()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            ce.id, 
                            j.nombre AS Jugador, 
                            ce.fecha_entrada
                        FROM control_entradas ce
                        INNER JOIN jugador j ON ce.jugador_id = j.id
                        ORDER BY ce.fecha_entrada DESC;
                    ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridViewEntradas.DataSource = dt;

                        // Configurar columnas
                        if (dataGridViewEntradas.Columns.Contains("id"))
                        {
                            dataGridViewEntradas.Columns["id"].Visible = false; // Ocultar columna 'id'
                        }

                        if (dataGridViewEntradas.Columns.Contains("Jugador"))
                        {
                            dataGridViewEntradas.Columns["Jugador"].HeaderText = "Nombre del Jugador";
                        }

                        if (dataGridViewEntradas.Columns.Contains("fecha_entrada"))
                        {
                            dataGridViewEntradas.Columns["fecha_entrada"].HeaderText = "Fecha de Entrada";
                            dataGridViewEntradas.Columns["fecha_entrada"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                        }

                        // Ajustar el modo de autoajuste de columnas
                        dataGridViewEntradas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar entradas: " + ex.Message);
            }
        }
        private void ControlDeEntradaForm_Load(object sender, EventArgs e)
        {
            CargarJugadores();
            CargarEntradas();

            // Opcional: Establecer la fecha de entrada por defecto al momento actual
            dtpFechaEntrada.Value = DateTime.Now;
        }
        private bool AgregarEntrada(int jugadorId, DateTime fechaEntrada)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO control_entradas (jugador_id, fecha_entrada)
                                     VALUES (@jugador_id, @fecha_entrada)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@jugador_id", SqlDbType.Int).Value = jugadorId;
                        cmd.Parameters.Add("@fecha_entrada", SqlDbType.DateTime).Value = fechaEntrada;

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la entrada: " + ex.Message);
                return false;
            }
        }

        private void LimpiarCampos()
        {
            cmbJugador.SelectedIndex = -1;
            dtpFechaEntrada.Value = DateTime.Now;
        }

        private void btnAgregarEntrada_Click(object sender, EventArgs e)
        {
            // Validar selección de jugador
            if (cmbJugador.SelectedValue == null || !int.TryParse(cmbJugador.SelectedValue.ToString(), out int jugadorId))
            {
                MessageBox.Show("Por favor, selecciona un jugador válido.");
                return;
            }

            // Obtener la fecha de entrada
            DateTime fechaEntrada = dtpFechaEntrada.Value;

            // Insertar la nueva entrada en la base de datos
            if (AgregarEntrada(jugadorId, fechaEntrada))
            {
                MessageBox.Show("Entrada agregada con éxito.");
                CargarEntradas(); // Actualizar el DataGridView
                LimpiarCampos();  // Opcional: limpiar campos de entrada
            }
            else
            {
                MessageBox.Show("Hubo un error al agregar la entrada.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
