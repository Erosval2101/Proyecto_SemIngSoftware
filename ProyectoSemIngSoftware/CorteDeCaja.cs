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

namespace ProyectoSemIngSoftware
{
    public partial class CorteDeCaja : Form
    {
        String id_cajero;
        decimal totalEfectivo = 0;
        decimal totalVoucher = 0;
        public CorteDeCaja(String id)
        {
            InitializeComponent();
            id_cajero = id;
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            MenuCajero regresar = new MenuCajero(id_cajero);
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

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void fechaHora_Tick(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void CorteDeCaja_Load(object sender, EventArgs e)
        {
            String nombre_cajero = buscar_NombreCajero(id_cajero);

            txtIDCajero.Text = id_cajero;
            txtNombreCajero.Text = nombre_cajero;

            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            MySqlCommand buscar = new MySqlCommand();
            buscar.Connection = conectar;

            buscar.CommandText = ("select IDComanda from comanda where ID_Cajero = '" + id_cajero + "'");

            MySqlDataReader leerConsulta = buscar.ExecuteReader();
            while (leerConsulta.Read())
            {
                detalle_Comanda(leerConsulta.GetString(0));

            }

        }


        private void detalle_Comanda(String id)
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            MySqlCommand buscar = new MySqlCommand();
            buscar.Connection = conectar;

            buscar.CommandText = ("select * from pagar_comanda where ID_Comanda = '" + id + "'");

            MySqlDataReader leerConsulta = buscar.ExecuteReader();
            while (leerConsulta.Read())
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dtgvComanda);
                fila.Cells[0].Value = leerConsulta.GetString(0); //ID Comanda
                fila.Cells[1].Value = id_cajero;
                fila.Cells[2].Value = txtNombreCajero.Text;
                fila.Cells[3].Value = leerConsulta.GetString(1); // Tipo de Pago
                fila.Cells[4].Value = leerConsulta.GetString(2); //Monto

                if (leerConsulta.GetString(1) == "Efectivo")
                {
                    totalEfectivo = totalEfectivo + Convert.ToDecimal(leerConsulta.GetString(2));
                }
                else
                {
                    totalVoucher = totalVoucher + Convert.ToDecimal(leerConsulta.GetString(2));
                }

                dtgvComanda.Rows.Add(fila);

            }

            lblEfectivo.Text = totalEfectivo.ToString();
            lblVoucher.Text = totalVoucher.ToString();
            conectar.Close();
        }


        public static String buscar_NombreCajero(String id)
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            MySqlCommand buscar = new MySqlCommand();
            buscar.Connection = conectar;

            buscar.CommandText = ("select NombreEmpleado, Ap_PaternoEmpleado from empleado where IDEmpleado = '" + id + "'");

            MySqlDataReader leerConsulta = buscar.ExecuteReader();
            if (leerConsulta.Read())
            {
                String nombre_cajero;
                nombre_cajero = leerConsulta.GetString(0) + " " + leerConsulta.GetString(1);
                conectar.Close();
                return nombre_cajero;
            }
            else
            {
                conectar.Close();
                String nombre_cajero = "";
                return nombre_cajero;
            }
        }

        private void dtgvComanda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String id_com = this.dtgvComanda.CurrentRow.Cells[0].Value.ToString();
                buscar_Detalle(id_com);
            }
            catch (Exception)
            {
                MessageBox.Show("No hay comandas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buscar_Detalle(String id)
        {
            dtgvDetalle.Rows.Clear();
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            MySqlCommand buscar = new MySqlCommand();
            buscar.Connection = conectar;

            buscar.CommandText = ("select * from comanda_detalle where ID_Comanda = '" + id + "'");

            decimal _importe = 0;

            MySqlDataReader leerConsulta = buscar.ExecuteReader();
            while (leerConsulta.Read())
            {
                String descripcion;
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dtgvDetalle);
                fila.Cells[0].Value = leerConsulta.GetString(0);
                fila.Cells[1].Value = leerConsulta.GetString(1);
                descripcion = buscar_DescripcionPlatillo(leerConsulta.GetString(1));
                fila.Cells[2].Value = descripcion;
                fila.Cells[3].Value = leerConsulta.GetString(2);
                fila.Cells[4].Value = leerConsulta.GetString(3);

                _importe = _importe + (Convert.ToDecimal(leerConsulta.GetString(2)) * Convert.ToDecimal(leerConsulta.GetString(3)));

                dtgvDetalle.Rows.Add(fila);
            }

            conectar.Close();
        }

        public static String buscar_DescripcionPlatillo(String id)
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            MySqlCommand buscar = new MySqlCommand();
            buscar.Connection = conectar;

            buscar.CommandText = ("select Descripcion from producto where IDProducto = '" + id + "'");

            MySqlDataReader leerConsulta = buscar.ExecuteReader();
            if (leerConsulta.Read())
            {
                String descp;
                descp = leerConsulta.GetString(0);
                conectar.Close();
                return descp;
            }
            else
            {
                conectar.Close();
                String descp = "";
                return descp;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MenuCajero regresar = new MenuCajero(id_cajero);
            regresar.Show();
            this.Hide();
        }
    }
}
