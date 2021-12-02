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

namespace ProyectoSemIngSoftware
{
    public partial class MostrarComandasPrep : Form
    {
        String id_mesero;
        public MostrarComandasPrep(String id)
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
            this.Close();
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

        private void MostrarComandasPrep_Load(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            MySqlCommand buscar = new MySqlCommand();
            buscar.Connection = conectar;

            buscar.CommandText = ("select IDComanda, ID_Cocinero from comanda where ID_Mesero = '" + id_mesero + "' and Estatus = 'Preparada'");

            MySqlDataReader leerConsulta = buscar.ExecuteReader();
            if (leerConsulta.Read())
            {
                String nombre_cocinero;
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dtgvComanda);
                fila.Cells[0].Value = leerConsulta.GetString(0); //ID Comanda
                fila.Cells[1].Value = leerConsulta.GetString(1); // ID Mesero
                nombre_cocinero = buscarNombreCocinero(leerConsulta.GetString(1));
                fila.Cells[2].Value = nombre_cocinero; // Nombre Mesero

                dtgvComanda.Rows.Add(fila);
            }
            else
            {
                MessageBox.Show("No hay comandas asignadas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnCerrar_Click(null, e);
            }
            conectar.Close();
        }

        public static String buscarNombreCocinero(String id)
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            MySqlCommand buscar = new MySqlCommand();
            buscar.Connection = conectar;

            buscar.CommandText = ("select NombreEmpleado, Ap_PaternoEmpleado from empleado where IDEmpleado = '" + id + "'");

            MySqlDataReader leerConsulta = buscar.ExecuteReader();
            if (leerConsulta.Read())
            {
                string nombre = leerConsulta.GetString(0) + " " + leerConsulta.GetString(1);
                conectar.Close();
                return nombre;
            }
            else
            {
                string nombre = "";
                conectar.Close();
                return nombre;
            }
        }
    }
}
