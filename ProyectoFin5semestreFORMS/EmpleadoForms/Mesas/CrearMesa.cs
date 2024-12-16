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
    public partial class CrearMesa : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public CrearMesa()
        {
            InitializeComponent();
            CargarMesasDeJuego();  // Cargar las mesas de juego al iniciar el formulario
                                   // Agregar tipos de juego al ComboBox
            cmbTipoDeJuego.Items.Add("Póker");
            cmbTipoDeJuego.Items.Add("Ruleta");
            cmbTipoDeJuego.Items.Add("Blackjack");
            cmbTipoDeJuego.Items.Add("Baccarat");
            cmbTipoDeJuego.Items.Add("Dados");
            cmbTipoDeJuego.Items.Add("Tragaperras");
            // Agrega más tipos según sea necesario

            // Seleccionar el primer elemento por defecto
            if (cmbTipoDeJuego.Items.Count > 0)
            {
                cmbTipoDeJuego.SelectedIndex = 0;
            }

            // Agregar estados al ComboBox
            cmbEstado.Items.Add("Abierta");
            cmbEstado.Items.Add("Cerrada");
            // Agrega más estados si es necesario

            // Seleccionar el primer elemento por defecto
            if (cmbEstado.Items.Count > 0)
            {
                cmbEstado.SelectedIndex = 0;
            }
        }
      
        private bool CrearMesaDeJuego(string tipoDeJuego, int capacidad, string estado)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO mesa_de_juego (tipo_de_juego, capacidad, estado) " +
                                   "VALUES (@tipoDeJuego, @capacidad, @estado)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tipoDeJuego", tipoDeJuego);
                        cmd.Parameters.AddWithValue("@capacidad", capacidad);
                        cmd.Parameters.AddWithValue("@estado", estado);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;  // Si se insertaron filas, la mesa fue creada correctamente.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la mesa de juego: " + ex.Message);
                return false;
            }
        }
        private void CargarMesasDeJuego()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, tipo_de_juego, capacidad, estado FROM mesa_de_juego";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las mesas de juego: " + ex.Message);
            }
        }

        private void btnCrearMesa_Click(object sender, EventArgs e)
        {
            string tipoDeJuego = cmbTipoDeJuego.Text;  // Asumimos que estos son campos de entrada en el formulario.
            int capacidad = Convert.ToInt32(txtCapacidad.Text);
            string estado = cmbEstado.SelectedItem.ToString();  // Supongamos que hay un combo con "Abierta", "Cerrada", etc.

            if (CrearMesaDeJuego(tipoDeJuego, capacidad, estado))
            {
                MessageBox.Show("Mesa de juego creada con éxito.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubo un error al crear la mesa de juego.");
            }
        }

        private void CrearMesa_Load(object sender, EventArgs e)
        {

        }
    }
}
