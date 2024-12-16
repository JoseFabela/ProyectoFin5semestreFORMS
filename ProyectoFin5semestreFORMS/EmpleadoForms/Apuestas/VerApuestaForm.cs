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

namespace ProyectoFin5semestreFORMS.EmpleadoForms.Apuestas
{
    public partial class VerApuestaForm : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public VerApuestaForm()
        {
            InitializeComponent();
        }

        private void VerApuestaForm_Load(object sender, EventArgs e)
        {
            CargarApuestas();
        }
        private void CargarApuestas()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    a.id,
                    j.nombre AS Jugador,
                    m.tipo_de_juego AS Mesa,
                    a.monto,
                    a.fecha,
                    d.descripcion AS Descuento,
                    r.descripcion AS Recurso
                FROM apuesta a
                INNER JOIN jugador j ON a.jugador_id = j.id
                INNER JOIN mesa_de_juego m ON a.mesa_id = m.id
                LEFT JOIN descuento d ON a.descuento_id = d.id
                LEFT JOIN recurso r ON a.recurso_id = r.id
                ORDER BY a.fecha DESC;
            ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridViewApuestas.DataSource = dt;

                        // Configurar columnas
                        if (dataGridViewApuestas.Columns.Contains("id"))
                        {
                            dataGridViewApuestas.Columns["id"].Visible = false; // Ocultar columna 'id'
                        }

                        if (dataGridViewApuestas.Columns.Contains("Jugador"))
                        {
                            dataGridViewApuestas.Columns["Jugador"].HeaderText = "Jugador";
                        }

                        if (dataGridViewApuestas.Columns.Contains("Mesa"))
                        {
                            dataGridViewApuestas.Columns["Mesa"].HeaderText = "Mesa";
                        }

                        if (dataGridViewApuestas.Columns.Contains("monto"))
                        {
                            dataGridViewApuestas.Columns["monto"].HeaderText = "Monto";
                            dataGridViewApuestas.Columns["monto"].DefaultCellStyle.Format = "C2"; // Formato de moneda
                        }

                        if (dataGridViewApuestas.Columns.Contains("fecha"))
                        {
                            dataGridViewApuestas.Columns["fecha"].HeaderText = "Fecha de Apuesta";
                            dataGridViewApuestas.Columns["fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                        }

                        if (dataGridViewApuestas.Columns.Contains("Descuento"))
                        {
                            dataGridViewApuestas.Columns["Descuento"].HeaderText = "Descuento";
                        }

                        if (dataGridViewApuestas.Columns.Contains("Recurso"))
                        {
                            dataGridViewApuestas.Columns["Recurso"].HeaderText = "Recurso";
                        }

                        // Ajustar el modo de autoajuste de columnas
                        dataGridViewApuestas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar apuestas: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
