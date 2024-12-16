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
    public partial class ActualizaApuestaForm : Form
    {
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        public ActualizaApuestaForm()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
               
            // Validar selección de jugador, mesa, recurso
            if (cmbJugador.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona un jugador.");
                return;
            }

            if (cmbMesa.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona una mesa.");
                return;
            }

            if (cmbRecurso.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona un recurso.");
                return;
            }

            // Obtener valores
            int jugadorId = Convert.ToInt32(cmbJugador.SelectedValue);
            int mesaId = Convert.ToInt32(cmbMesa.SelectedValue);
            decimal monto = nudMonto.Value;
            DateTime fecha = dtpFecha.Value;
            int? descuentoId = cmbDescuento.SelectedValue != null ? (int?)Convert.ToInt32(cmbDescuento.SelectedValue) : null;
            int recursoId = Convert.ToInt32(cmbRecurso.SelectedValue);
            int apuestaId = Convert.ToInt32(cmbApuesta.SelectedValue);

            // Validar monto
            if (monto <= 0)
            {
                MessageBox.Show("El monto debe ser mayor que cero.");
                return;
            }

            // Actualizar la apuesta
            if (ActualizarApuesta(apuestaId, jugadorId, mesaId, monto, fecha, descuentoId, recursoId))
            {
                MessageBox.Show("Apuesta actualizada con éxito.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubo un error al actualizar la apuesta.");
            }
        }
        private bool ActualizarApuesta(int id, int jugadorId, int mesaId, decimal monto, DateTime fecha, int? descuentoId, int recursoId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Obtener el recurso actual de la apuesta
                        int recursoAnteriorId = -1;
                        string obtenerRecursoQuery = @"SELECT recurso_id FROM apuesta WHERE id = @id";

                        using (SqlCommand cmdObtenerRecurso = new SqlCommand(obtenerRecursoQuery, conn, transaction))
                        {
                            cmdObtenerRecurso.Parameters.Add("@id", SqlDbType.Int).Value = id;
                            object result = cmdObtenerRecurso.ExecuteScalar();
                            recursoAnteriorId = result != null ? Convert.ToInt32(result) : -1;
                        }

                        // Validar disponibilidad del nuevo recurso
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

                        // Actualizar la apuesta
                        string updateApuestaQuery = @"UPDATE apuesta
                                             SET jugador_id = @jugador_id,
                                                 mesa_id = @mesa_id,
                                                 monto = @monto,
                                                 fecha = @fecha,
                                                 descuento_id = @descuento_id,
                                                 recurso_id = @recurso_id
                                             WHERE id = @id";

                        using (SqlCommand cmdUpdateApuesta = new SqlCommand(updateApuestaQuery, conn, transaction))
                        {
                            cmdUpdateApuesta.Parameters.Add("@jugador_id", SqlDbType.Int).Value = jugadorId;
                            cmdUpdateApuesta.Parameters.Add("@mesa_id", SqlDbType.Int).Value = mesaId;
                            cmdUpdateApuesta.Parameters.Add("@monto", SqlDbType.Decimal).Value = monto;
                            cmdUpdateApuesta.Parameters["@monto"].Precision = 18;
                            cmdUpdateApuesta.Parameters["@monto"].Scale = 2;
                            cmdUpdateApuesta.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;

                            if (descuentoId.HasValue)
                                cmdUpdateApuesta.Parameters.Add("@descuento_id", SqlDbType.Int).Value = descuentoId.Value;
                            else
                                cmdUpdateApuesta.Parameters.Add("@descuento_id", SqlDbType.Int).Value = DBNull.Value;

                            cmdUpdateApuesta.Parameters.Add("@recurso_id", SqlDbType.Int).Value = recursoId;
                            cmdUpdateApuesta.Parameters.Add("@id", SqlDbType.Int).Value = id;

                            cmdUpdateApuesta.ExecuteNonQuery();
                        }

                        // Actualizar la cantidad disponible del nuevo recurso
                        string updateRecursoNuevoQuery = @"UPDATE recurso SET cantidad_disponible = cantidad_disponible - 1
                                                  WHERE id = @recurso_id";

                        using (SqlCommand cmdUpdateRecursoNuevo = new SqlCommand(updateRecursoNuevoQuery, conn, transaction))
                        {
                            cmdUpdateRecursoNuevo.Parameters.Add("@recurso_id", SqlDbType.Int).Value = recursoId;
                            cmdUpdateRecursoNuevo.ExecuteNonQuery();
                        }

                        // Actualizar la cantidad disponible del recurso anterior
                        if (recursoAnteriorId != -1 && recursoAnteriorId != recursoId)
                        {
                            string updateRecursoAnteriorQuery = @"UPDATE recurso SET cantidad_disponible = cantidad_disponible + 1
                                                         WHERE id = @recurso_id";

                            using (SqlCommand cmdUpdateRecursoAnterior = new SqlCommand(updateRecursoAnteriorQuery, conn, transaction))
                            {
                                cmdUpdateRecursoAnterior.Parameters.Add("@recurso_id", SqlDbType.Int).Value = recursoAnteriorId;
                                cmdUpdateRecursoAnterior.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error al actualizar la apuesta: " + ex.Message);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la apuesta: " + ex.Message);
                return false;
            }
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
        private void CargaComboBoxApuesta()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, monto FROM apuesta WHERE estado = 'Activo';"; // Solo recursos activos

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbApuesta.DisplayMember = "monto";
                        cmbApuesta.ValueMember = "id";
                        cmbApuesta.DataSource = dt;
                    }
                }

                if (cmbApuesta.Items.Count > 0)
                    cmbRecurso.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar recursos: " + ex.Message);
            }
        }
        private void ActualizaApuestaForm_Load(object sender, EventArgs e)
        {
            CargaComboBoxJugadores();
            CargaComboBoxMesas();
            CargaComboBoxDescuentos();
            CargaComboBoxRecursos();
            CargaComboBoxApuesta();
            // Configurar DateTimePicker
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFecha.Value = DateTime.Now; // Establecer la fecha y hora actuales por defecto
            
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
            // Seleccionar el primer elemento por defecto
            if (cmbEstado.Items.Count > 0)
            {
                cmbEstado.SelectedIndex = 0;
            }
        }
    }
}
