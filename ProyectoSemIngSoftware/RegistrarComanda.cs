using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.IO;
using System;
using System.Collections;

namespace ProyectoSemIngSoftware
{
    public partial class RegistrarComanda : Form
    {
        DataTable dbdataset = new DataTable();
        String id_mesero;

        decimal subtotal = 0;
        decimal iva = 0;
        decimal total = 0;

        double porcentaje_iva = 0.16;
        public RegistrarComanda(String id)
        {
            InitializeComponent();
            id_mesero = id;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            MenuMesero regresar = new MenuMesero(id_mesero);
            regresar.Show();
            this.Hide();
        }

        int lx, ly;
        int sw, sh;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;

            btnRestaurar.Visible = true;
            btnMaximizar.Visible = false;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;

            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void RegistrarComanda_Load(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            String query = "select count(*) from comanda";
            MySqlCommand consultar = new MySqlCommand(query, conectar);
            int contID = Convert.ToInt32(consultar.ExecuteScalar()) + 1;
            txtIDComanda.Text = contID.ToString();

            MySqlCommand consultar_empleado = new MySqlCommand();
            MySqlConnection conectarnos = new MySqlConnection();
            consultar_empleado.Connection = conectar;

            consultar_empleado.CommandText = ("select NombreEmpleado, Ap_PaternoEmpleado, Ap_MaternoEmpleado from empleado where IDEmpleado = '" + id_mesero + "'");

            MySqlDataReader leerConsulta = consultar_empleado.ExecuteReader();
            String nombre_empleado;
            if (leerConsulta.Read())
            {
                nombre_empleado = leerConsulta.GetString(0) + " " + leerConsulta.GetString(1) + " " + leerConsulta.GetString(2);
                txtNombreMesero.Text = nombre_empleado;
            }
            txtIDMesero.Text = id_mesero;

        }

        private void txtNombreCliente_Enter(object sender, EventArgs e)
        {
            if (txtNombreCliente.Text == "Nombre del Cliente")
            {
                txtNombreCliente.Text = "";
            }
        }

        private void txtNombreCliente_Leave(object sender, EventArgs e)
        {
            if (txtNombreCliente.Text == "")
            {
                txtNombreCliente.Text = "Nombre del Cliente";
            }
        }

        private void txtObservaciones_Enter(object sender, EventArgs e)
        {
            if (txtObservaciones.Text == "Observaciones")
            {
                txtObservaciones.Text = "";
            }
        }

        private void txtObservaciones_Leave(object sender, EventArgs e)
        {
            if (txtObservaciones.Text == "")
            {
                txtObservaciones.Text = "Observaciones";
            }
        }

        private void fechaHora_Tick(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void txtDescp_Enter(object sender, EventArgs e)
        {
            if (txtDescp.Text == "Descripción")
            {
                txtDescp.Text = "";
            }
        }

        private void txtDescp_Leave(object sender, EventArgs e)
        {
            if (txtDescp.Text == "")
            {
                txtDescp.Text = "Descripción";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            MySqlCommand buscar = new MySqlCommand();
            buscar.Connection = conectar;

            buscar.CommandText = ("select IDProducto, Descripcion, Precio from producto where IDProducto = '" + nudID.Value.ToString() + "' and Descripcion = '" + txtDescp.Text + "' and Disponible = 'Si'");

            MySqlDataReader leerConsulta = buscar.ExecuteReader();
            if (leerConsulta.Read())
            {
                Boolean flag = false;
                foreach (DataGridViewRow r in dtgvProducto.Rows)
                {
                    String id_producto = Convert.ToString(r.Cells[0].Value);
                    if (leerConsulta.GetString(0) == id_producto)
                    {
                        int suma_cantidad = Convert.ToInt32(r.Cells[3].Value) + Convert.ToInt32(nupCantidad.Value);
                        r.Cells[3].Value = Convert.ToString(suma_cantidad);
                        decimal _importe = Convert.ToDecimal(suma_cantidad) * Convert.ToDecimal(leerConsulta.GetString(2));
                        r.Cells[4].Value = _importe.ToString();
                        flag = true;
                    }
                }
                if(flag == false)
                {
                    DataGridViewRow fila = new DataGridViewRow();
                    fila.CreateCells(dtgvProducto);
                    fila.Cells[0].Value = leerConsulta.GetString(0);
                    fila.Cells[1].Value = leerConsulta.GetString(1);
                    fila.Cells[2].Value = leerConsulta.GetString(2);
                    fila.Cells[3].Value = nupCantidad.Value.ToString();
                    decimal importe = nupCantidad.Value * Convert.ToDecimal(leerConsulta.GetString(2));
                    fila.Cells[4].Value = importe.ToString();

                    dtgvProducto.Rows.Add(fila);

                    decimal _importe = 0;
                    foreach (DataGridViewRow r in dtgvProducto.Rows)
                    {
                        _importe = _importe + Convert.ToDecimal(r.Cells[4].Value);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontró el platillo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            conectar.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            dtgvProducto.Rows.Remove(dtgvProducto.CurrentRow);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtgvProducto.Rows.Clear();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtNombreCliente.Text != "Nombre del Cliente")
            {
                if (txtObservaciones.Text != "Observaciones")
                {
                    if (txtDescp.Text != "Descripción")
                    {
                        MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
                        conectar.Open();

                        MySqlCommand buscar = new MySqlCommand();
                        buscar.Connection = conectar;

                        buscar.CommandText = ("select * from comanda where Mesa = '" + nupMesa.Value.ToString() + "' and Estatus = 'Pedida'");

                        MySqlDataReader leerConsulta = buscar.ExecuteReader();
                        if (leerConsulta.Read())
                        {
                            MessageBox.Show("Mesa ocupada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            leerConsulta.Close();
                            String query = "insert into comanda(ID_Mesero, ID_Cocinero, ID_Cajero, Nombre_Cliente, FechaInicio, Estatus, No_Personas, Mesa, FechaCierre, Observaciones) values (@idmesero, @idcocinero, @idcajero, @nombre, @f_inicio, @estatus, @no_per, @mesa, @f_cierre, @obs)";

                            MySqlCommand registrar = new MySqlCommand(query, conectar);

                            registrar.Parameters.Add("@idmesero", MySqlDbType.VarChar, 13);
                            registrar.Parameters.Add("@idcocinero", MySqlDbType.VarChar, 13);
                            registrar.Parameters.Add("@idcajero", MySqlDbType.VarChar, 13);
                            registrar.Parameters.Add("@nombre", MySqlDbType.VarChar, 50);
                            registrar.Parameters.Add("@f_inicio", MySqlDbType.DateTime);
                            registrar.Parameters.Add("@estatus", MySqlDbType.Enum);
                            registrar.Parameters.Add("@no_per", MySqlDbType.Int32, 11);
                            registrar.Parameters.Add("@mesa", MySqlDbType.Int32, 11);
                            registrar.Parameters.Add("@f_cierre", MySqlDbType.DateTime);
                            registrar.Parameters.Add("@obs", MySqlDbType.Text);

                            registrar.Parameters["@idmesero"].Value = id_mesero.ToString();
                            registrar.Parameters["@idcocinero"].Value = "";
                            registrar.Parameters["@idcajero"].Value = "";
                            registrar.Parameters["@nombre"].Value = txtNombreCliente.Text;
                            registrar.Parameters["@f_inicio"].Value = Convert.ToDateTime(txtFecha.Text);
                            registrar.Parameters["@estatus"].Value = cmbEstatus.SelectedItem.ToString();
                            registrar.Parameters["@no_per"].Value = nudPersonas.Value.ToString();
                            registrar.Parameters["@mesa"].Value = nupMesa.Value.ToString();
                            registrar.Parameters["@f_cierre"].Value = Convert.ToDateTime(txtFecha.Text);
                            registrar.Parameters["@obs"].Value = txtObservaciones.Text;

                            if (registrar.ExecuteNonQuery() == 1)
                            {
                                String query_detalle = "insert into comanda_detalle(ID_Comanda, ID_Producto, CantidadProductos, Precio) values (@idcomanda, @idprod, @cantidad, @precio)";

                                MySqlCommand registrar_detalle = new MySqlCommand(query_detalle, conectar);

                                try
                                {
                                    foreach (DataGridViewRow r in dtgvProducto.Rows)
                                    {
                                        registrar_detalle.Parameters.Clear();
                                        registrar_detalle.Parameters.Add("@idcomanda", MySqlDbType.Int32, 11);
                                        registrar_detalle.Parameters.Add("@idprod", MySqlDbType.Int32, 11);
                                        registrar_detalle.Parameters.Add("@cantidad", MySqlDbType.Int32, 11);
                                        registrar_detalle.Parameters.Add("@precio", MySqlDbType.Float);

                                        registrar_detalle.Parameters["@idcomanda"].Value = txtIDComanda.Text;
                                        registrar_detalle.Parameters["@idprod"].Value = r.Cells[0].Value;
                                        registrar_detalle.Parameters["@cantidad"].Value = r.Cells[3].Value;
                                        registrar_detalle.Parameters["@precio"].Value = r.Cells[2].Value;

                                        registrar_detalle.ExecuteNonQuery();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Comanda generada exitosamente");
                                    int contID = Convert.ToInt32(txtIDComanda.Text) + 1;
                                    txtIDComanda.Text = contID.ToString();
                                    Limpiar();
                                    btnLimpiar_Click(null, e);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Llene adecuadamente los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            conectar.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Llene adecuadamente los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Llene adecuadamente los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Llene adecuadamente los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            txtNombreCliente.Text = "Nombre del Cliente";
            txtObservaciones.Text = "Observaciones";
            txtDescp.Text = "Descripción";
            nupCantidad.Value = 1;
            nudPersonas.Value = 1;
            nupMesa.Value = 1;
        }


        private void buscarPlatillo(String id)
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            MySqlCommand buscar = new MySqlCommand();
            buscar.Connection = conectar;

            buscar.CommandText = ("select Descripcion from producto where IDProducto = '" + id + "'");

            MySqlDataReader leerConsulta = buscar.ExecuteReader();
            if (leerConsulta.Read())
            {
                string descp = leerConsulta.GetString(0);
                txtDescp.Text = descp;
            }
            else
            {
                MessageBox.Show("No se encontró el platillo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            conectar.Close();
        }

        private void nudID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                buscarPlatillo(nudID.Value.ToString());
            }
        }

        private void dtgvProducto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgvProducto.Columns[e.ColumnIndex].Index == 3)
                {
                    decimal _importe = Convert.ToDecimal(dtgvProducto.Rows[e.RowIndex].Cells[3].Value) * Convert.ToDecimal(dtgvProducto.Rows[e.RowIndex].Cells[2].Value);
                    dtgvProducto.Rows[e.RowIndex].Cells[4].Value = _importe.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese cantidad correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
