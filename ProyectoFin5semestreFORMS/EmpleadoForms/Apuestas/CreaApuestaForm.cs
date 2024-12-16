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
    public partial class CreaApuestaForm : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public CreaApuestaForm()
        {
            InitializeComponent();
        }

        private void CreaApuestaForm_Load(object sender, EventArgs e)
        {
            CargaComboBoxJugadores();
            CargaComboBoxMesas();
            CargaComboBoxDescuentos();
            CargaComboBoxRecursos();

            // Configurar DateTimePicker
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFecha.Value = DateTime.Now; // Establecer la fecha y hora actuales por defecto
        }
        private void CargaComboBoxJugadores()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, nombre FROM jugador WHERE estado = 'Activo';"; // Asegúrate de que la columna 'estado' exista

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

        private void CargaComboBoxMesas()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, tipo_de_juego FROM mesa_de_juego;"; // Asegúrate de que la tabla 'mesa' exista

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbMesa.DisplayMember = "tipo_de_juego";
                        cmbMesa.ValueMember = "id";
                        cmbMesa.DataSource = dt;
                    }
                }

                if (cmbMesa.Items.Count > 0)
                    cmbMesa.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar mesas: " + ex.Message);
            }
        }

        private void CargaComboBoxDescuentos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, descripcion FROM descuento;"; // Asegúrate de que la tabla 'descuento' exista

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbDescuento.DisplayMember = "descripcion";
                        cmbDescuento.ValueMember = "id";
                        cmbDescuento.DataSource = dt;
                    }
                }

                // Permitir una opción "Sin Descuento"
                DataRow dr = ((DataTable)cmbDescuento.DataSource).NewRow();
                dr["id"] = DBNull.Value;
                dr["descripcion"] = "Sin Descuento";
                ((DataTable)cmbDescuento.DataSource).Rows.InsertAt(dr, 0);
                cmbDescuento.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar descuentos: " + ex.Message);
            }
        }

        private void CargaComboBoxRecursos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, descripcion FROM recurso WHERE estado = 'Activo';"; // Solo recursos activos

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbRecurso.DisplayMember = "descripcion";
                        cmbRecurso.ValueMember = "id";
                        cmbRecurso.DataSource = dt;
                    }
                }

                if (cmbRecurso.Items.Count > 0)
                    cmbRecurso.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar recursos: " + ex.Message);
            }
        }

        private void btnCrea_Click(object sender, EventArgs e)
        {
            // Validar selección de jugador
            if (cmbJugador.SelectedValue == null || !int.TryParse(cmbJugador.SelectedValue.ToString(), out int jugadorId))
            {
                MessageBox.Show("Por favor, selecciona un jugador válido.");
                return;
            }

            // Validar selección de mesa
            if (cmbMesa.SelectedValue == null || !int.TryParse(cmbMesa.SelectedValue.ToString(), out int mesaId))
            {
                MessageBox.Show("Por favor, selecciona una mesa válida.");
                return;
            }

            // Validar selección de recurso
            if (cmbRecurso.SelectedValue == null || !int.TryParse(cmbRecurso.SelectedValue.ToString(), out int recursoId))
            {
                MessageBox.Show("Por favor, selecciona un recurso válido.");
                return;
            }

            // Obtener valores
            decimal monto = nudMonto.Value;
            DateTime fecha = dtpFecha.Value;
            int? descuentoId = cmbDescuento.SelectedValue != null && cmbDescuento.SelectedValue != DBNull.Value ? (int?)Convert.ToInt32(cmbDescuento.SelectedValue) : null;

            // Validar monto
            if (monto <= 0)
            {
                MessageBox.Show("El monto debe ser mayor que cero.");
                return;
            }

            // Insertar la apuesta
            if (AgregarApuesta(jugadorId, mesaId, monto, fecha, descuentoId, recursoId))
            {
                MessageBox.Show("Apuesta agregada con éxito.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubo un error al agregar la apuesta.");
            }
        }


        private bool AgregarApuesta(int jugadorId, int mesaId, decimal monto, DateTime fecha, int? descuentoId, int recursoId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Validar disponibilidad del recurso
                        string validarQuery = @"SELECT cantidad_disponible, estado FROM recurso WHERE id = @recurso_id";

                        using (SqlCommand cmdValidar = new SqlCommand(validarQuery, conn, transaction))
                        {
                            cmdValidar.Parameters.Add("@recurso_id", SqlDbType.Int).Value = recursoId;
                            using (SqlDataReader reader = cmdValidar.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int cantidadDisponible = Convert.ToInt32(reader["cantidad_disponible"]);
                                    string estado = reader["estado"].ToString();

                                    if (cantidadDisponible <= 0 || !estado.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                                    {
                                        MessageBox.Show("El recurso seleccionado no está disponible o no está activo.");
                                        reader.Close();
                                        transaction.Rollback();
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Recurso no encontrado.");
                                    reader.Close();
                                    transaction.Rollback();
                                    return false;
                                }
                            }
                        }

                        // Insertar la apuesta
                        string insertApuestaQuery = @"INSERT INTO apuesta (jugador_id, mesa_id, monto, fecha, descuento_id, recurso_id, estado)
                                                     VALUES (@jugador_id, @mesa_id, @monto, @fecha, @descuento_id, @recurso_id, 'activo')";

                        using (SqlCommand cmdInsert = new SqlCommand(insertApuestaQuery, conn, transaction))
                        {
                            cmdInsert.Parameters.Add("@jugador_id", SqlDbType.Int).Value = jugadorId;
                            cmdInsert.Parameters.Add("@mesa_id", SqlDbType.Int).Value = mesaId;
                            cmdInsert.Parameters.Add("@monto", SqlDbType.Decimal).Value = monto;
                            cmdInsert.Parameters["@monto"].Precision = 18;
                            cmdInsert.Parameters["@monto"].Scale = 2;
                            cmdInsert.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;

                            if (descuentoId.HasValue)
                                cmdInsert.Parameters.Add("@descuento_id", SqlDbType.Int).Value = descuentoId.Value;
                            else
                                cmdInsert.Parameters.Add("@descuento_id", SqlDbType.Int).Value = DBNull.Value;

                            cmdInsert.Parameters.Add("@recurso_id", SqlDbType.Int).Value = recursoId;

                            cmdInsert.ExecuteNonQuery();
                        }

                        // Actualizar la cantidad disponible del recurso
                        string updateRecursoQuery = @"UPDATE recurso SET cantidad_disponible = cantidad_disponible - 1
                                                      WHERE id = @recurso_id";

                        using (SqlCommand cmdUpdateRecurso = new SqlCommand(updateRecursoQuery, conn, transaction))
                        {
                            cmdUpdateRecurso.Parameters.Add("@recurso_id", SqlDbType.Int).Value = recursoId;
                            cmdUpdateRecurso.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error al agregar la apuesta: " + ex.Message);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la apuesta: " + ex.Message);
                return false;
            }
        }


       

    }
}
