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
    public partial class ReporteVentas : Form
    {
        String id_cajero;
        public ReporteVentas(String id)
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
            MenuCajero ver = new MenuCajero(id_cajero);
            ver.Show();
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            MySqlCommand buscar = new MySqlCommand();
            buscar.Connection = conectar;

            buscar.CommandText = ("select * from comanda where Estatus != 'Finalizada'");

            MySqlDataReader leerConsulta = buscar.ExecuteReader();
            while (leerConsulta.Read())
            {
                String nombre_mesero, nombre_cocinero, nombre_cajero;
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dtgvComanda);
                fila.Cells[0].Value = leerConsulta.GetString(0); //ID Comanda
                fila.Cells[1].Value = leerConsulta.GetString(1); // ID Mesero
                nombre_mesero = buscar_NombreMesero(leerConsulta.GetString(1));
                fila.Cells[2].Value = nombre_mesero; // Nombre Mesero
                fila.Cells[3].Value = leerConsulta.GetString(2); //ID Cocinero
                nombre_cocinero = buscar_NombreCocinero(leerConsulta.GetString(2));
                fila.Cells[4].Value = nombre_cocinero; //Nombre Cocinero
                fila.Cells[5].Value = leerConsulta.GetString(3); //ID Cajero
                nombre_cajero = buscar_NombreCajero(leerConsulta.GetString(3));
                fila.Cells[6].Value = nombre_cajero; //Nombre Cajero
                fila.Cells[7].Value = leerConsulta.GetString(4); //Nombre Cliente
                fila.Cells[8].Value = leerConsulta.GetString(5); //Fecha Inicio
                fila.Cells[9].Value = leerConsulta.GetString(6); //Estatus
                fila.Cells[10].Value = leerConsulta.GetString(7); //No. Personas
                fila.Cells[11].Value = leerConsulta.GetString(8); //Mesa
                if (leerConsulta.GetString(6) != "Finalizada")
                {
                    fila.Cells[12].Value = "";
                }
                else
                {
                    fila.Cells[12].Value = leerConsulta.GetString(9); //Fecha Cierre
                }
                fila.Cells[13].Value = leerConsulta.GetString(10); //Observaciones

                dtgvComanda.Rows.Add(fila);
            }
            conectar.Close();
        }

        public static String buscar_NombreMesero(String id)
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            MySqlCommand buscar = new MySqlCommand();
            buscar.Connection = conectar;

            buscar.CommandText = ("select NombreEmpleado, Ap_PaternoEmpleado from empleado where IDEmpleado = '" + id + "'");

            MySqlDataReader leerConsulta = buscar.ExecuteReader();
            if (leerConsulta.Read())
            {
                String nombre_mesero;
                nombre_mesero = leerConsulta.GetString(0) + " " + leerConsulta.GetString(1);
                return nombre_mesero;
            }
            else
            {
                String nombre_mesero = "";
                return nombre_mesero;
            }
        }

        public static String buscar_NombreCocinero(String id)
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            MySqlCommand buscar = new MySqlCommand();
            buscar.Connection = conectar;

            buscar.CommandText = ("select NombreEmpleado, Ap_PaternoEmpleado from empleado where IDEmpleado = '" + id + "'");

            MySqlDataReader leerConsulta = buscar.ExecuteReader();
            if (leerConsulta.Read())
            {
                String nombre_cocinero;
                nombre_cocinero = leerConsulta.GetString(0) + " " + leerConsulta.GetString(1);
                conectar.Close();
                return nombre_cocinero;
            }
            else
            {
                conectar.Close();
                String nombre_cocinero = "";
                return nombre_cocinero;
            }
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

        private void dtgvComanda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String id_comanda = dtgvComanda.CurrentRow.Cells[0].Value.ToString();
            buscar_Detalle(id_comanda);
        }

        private void buscar_Detalle(String id)
        {
            dtgvDetalle.Rows.Clear();
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            MySqlCommand buscar = new MySqlCommand();
            buscar.Connection = conectar;

            buscar.CommandText = ("select * from comanda_detalle where ID_Comanda = '" + id + "'");

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

                dtgvDetalle.Rows.Add(fila);
            }
            conectar.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MenuCajero ver = new MenuCajero(id_cajero);
            ver.Show();
            this.Hide();
        }
    }
}
