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
    public partial class MenuMesero : Form
    {
        String id_mesero;
        public MenuMesero(String id)
        {
            id_mesero = id;
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 regresar = new Form1();
                regresar.Show();
                this.Hide();
            }
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

        private void MenuMesero_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 regresar = new Form1();
                regresar.Show();
                this.Hide();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 regresar = new Form1();
                regresar.Show();
                this.Hide();
            }
        }

        private void MenuMesero_Load(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            String query = "select NombreEmpleado,Ap_PaternoEmpleado,Ap_MaternoEmpleado,ImagenEmpleado from empleado where IDEmpleado = '" + id_mesero + "'";
            MySqlCommand comando = new MySqlCommand(query, conectar);
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            lblNombre.Text = tabla.Rows[0][0].ToString() + " " + tabla.Rows[0][1].ToString() + " " + tabla.Rows[0][2].ToString(); ;

            byte[] img = (byte[])tabla.Rows[0][3];

            MemoryStream ms = new MemoryStream(img);

            ptbImagen.Image = Image.FromStream(ms);

            da.Dispose();

            contarComandasAsignadas();
            contarComandasPreparadas();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarComanda ver = new RegistrarComanda(id_mesero);
            ver.Show();
            this.Hide();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            BuscarComanda ver = new BuscarComanda(id_mesero);
            ver.Show();
            this.Hide();
        }

        private void lblCmdasAsig_Click(object sender, EventArgs e)
        {
            MostrarComandasAsignadas ver = new MostrarComandasAsignadas(id_mesero);
            ver.Show();
        }

        private void lblAsignadas_Click(object sender, EventArgs e)
        {
            MostrarComandasAsignadas ver = new MostrarComandasAsignadas(id_mesero);
            ver.Show();
        }

        private void lblCmdasPrep_Click(object sender, EventArgs e)
        {
            MostrarComandasPrep ver = new MostrarComandasPrep(id_mesero);
            ver.Show();
        }

        private void lblPreparadas_Click(object sender, EventArgs e)
        {
            MostrarComandasPrep ver = new MostrarComandasPrep(id_mesero);
            ver.Show();
        }


        private void contarComandasAsignadas()
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            String query = "select count(*) from comanda where Estatus = 'Asignada'";
            MySqlCommand consultar = new MySqlCommand(query, conectar);
            int cont_comandas = Convert.ToInt32(consultar.ExecuteScalar());
            lblAsignadas.Text = cont_comandas.ToString();

            conectar.Close();
        }

        private void contarComandasPreparadas()
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            String query = "select count(*) from comanda where Estatus = 'Preparada'";
            MySqlCommand consultar = new MySqlCommand(query, conectar);
            int cont_comandas = Convert.ToInt32(consultar.ExecuteScalar());
            lblPreparadas.Text = cont_comandas.ToString();

            conectar.Close();
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
    }
}
