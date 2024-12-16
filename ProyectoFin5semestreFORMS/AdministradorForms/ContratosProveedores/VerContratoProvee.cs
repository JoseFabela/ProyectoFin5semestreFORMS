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

namespace ProyectoFin5semestreFORMS.AdministradorForms.ContratosProveedores
{
    public partial class VerContratoProvee : Form
    {
        public VerContratoProvee()
        {
            InitializeComponent();
        }
        static string connectionString = "Server=localhost;Database=ProyectoF5Sem;Integrated Security=True;";

        private void VerContratoProvee_Load(object sender, EventArgs e)
        {
            CargarContratos();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarContratos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    cp.id, 
                    p.nombre AS Proveedor, 
                    cp.fecha_inicio, 
                    cp.fecha_fin, 
                    cp.condiciones, 
                    cp.estado
                FROM contrato_proveedor cp
                INNER JOIN proveedor p ON cp.proveedor_id = p.id
            ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridViewContratos.DataSource = dt;

                        // Configurar las columnas del DataGridView
                        if (dataGridViewContratos.Columns.Contains("id"))
                        {
                            dataGridViewContratos.Columns["id"].Visible = false; // Ocultar columna 'id'
                        }

                        // Opcional: Renombrar encabezados de columnas para mayor claridad
                        if (dataGridViewContratos.Columns.Contains("Proveedor"))
                        {
                            dataGridViewContratos.Columns["Proveedor"].HeaderText = "Nombre del Proveedor";
                        }

                        if (dataGridViewContratos.Columns.Contains("fecha_inicio"))
                        {
                            dataGridViewContratos.Columns["fecha_inicio"].HeaderText = "Fecha de Inicio";
                            dataGridViewContratos.Columns["fecha_inicio"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        }

                        if (dataGridViewContratos.Columns.Contains("fecha_fin"))
                        {
                            dataGridViewContratos.Columns["fecha_fin"].HeaderText = "Fecha de Fin";
                            dataGridViewContratos.Columns["fecha_fin"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        }

                        if (dataGridViewContratos.Columns.Contains("condiciones"))
                        {
                            dataGridViewContratos.Columns["condiciones"].HeaderText = "Condiciones";
                        }

                        if (dataGridViewContratos.Columns.Contains("estado"))
                        {
                            dataGridViewContratos.Columns["estado"].HeaderText = "Estado";
                        }

                        // Ajustar el modo de autoajuste de columnas
                        dataGridViewContratos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los contratos: " + ex.Message);
            }
        }

    }
} 
