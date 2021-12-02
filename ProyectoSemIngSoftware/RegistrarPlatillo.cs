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
    public partial class RegistrarPlatillo : Form
    {
        public RegistrarPlatillo()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            MenuPlatillos regresar = new MenuPlatillos();
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MenuPlatillos regresar = new MenuPlatillos();
            regresar.Show();
            this.Hide();
        }

        private void dateTimePicker1_MouseDown(object sender, MouseEventArgs e)
        {
            dateTimePicker1.CustomFormat = "HH:mm:ss";
        }

        private void txtPrecio_Enter(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "Precio")
            {
                txtPrecio.Text = "";
            }
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "")
            {
                txtPrecio.Text = "Precio";
            }
        }

        private void txtDescripcion_Enter(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "Descripción")
            {
                txtDescripcion.Text = "";
            }
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if(txtDescripcion.Text == "")
            {
                txtDescripcion.Text = "Descripción";
            }
        }

        public OpenFileDialog examinar = new OpenFileDialog();
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            examinar.Filter = "Archivos de Imagen |*.jpg; *.png;";
            DialogResult r = examinar.ShowDialog();
            if (r == DialogResult.Abort)
            {
                return;
            }
            if (r == DialogResult.Cancel)
            {
                return;
            }
            ptbImagen.Image = Image.FromFile(examinar.FileName);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = -1;
            txtDescripcion.Text = "Descripción";
            txtPrecio.Text = "Precio";
            cmbDisp.SelectedIndex = -1;
            dateTimePicker1.Text = "";
            if (ptbImagen.Image != null)
            {
                ptbImagen.Image.Dispose();
                ptbImagen.Image = null;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text != "Descripción")
            {
                if (txtPrecio.Text != "Precio")
                {
                    MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
                    conectar.Open();
                    MemoryStream ms = new MemoryStream();
                    ptbImagen.Image.Save(ms, ptbImagen.Image.RawFormat);
                    byte[] img = ms.ToArray();

                    String query = "insert into producto(Tipo, Descripcion, Precio, Disponible, TiempoPreparacion, ImagenProducto) values (@tipo, @descp, @precio, @disp, @tiempo, @img)";

                    MySqlCommand registrar = new MySqlCommand(query, conectar);

                    registrar.Parameters.Add("@tipo", MySqlDbType.Enum);
                    registrar.Parameters.Add("@descp", MySqlDbType.Text);
                    registrar.Parameters.Add("@precio", MySqlDbType.Float);
                    registrar.Parameters.Add("@disp", MySqlDbType.Enum);
                    registrar.Parameters.Add("@tiempo", MySqlDbType.Time);
                    registrar.Parameters.Add("@img", MySqlDbType.LongBlob);

                    registrar.Parameters["@tipo"].Value = cmbTipo.SelectedItem.ToString();
                    registrar.Parameters["@descp"].Value = txtDescripcion.Text;
                    registrar.Parameters["@precio"].Value = txtPrecio.Text;
                    registrar.Parameters["@disp"].Value = cmbDisp.SelectedItem.ToString();
                    registrar.Parameters["@tiempo"].Value = TimeSpan.Parse(dateTimePicker1.Text);
                    registrar.Parameters["@img"].Value = img;

                    if (registrar.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Platillo agregado exitosamente");
                        int contID = Convert.ToInt32(txtID.Text) + 1;
                        txtID.Text = contID.ToString();
                        btnLimpiar_Click(null, e);
                    }
                    else
                    {
                        MessageBox.Show("Llene adecuadamente los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conectar.Close();
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

        private void RegistrarPlatillo_Load(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            String query = "select count(*) from producto";
            MySqlCommand consultar = new MySqlCommand(query, conectar);
            int contID = Convert.ToInt32(consultar.ExecuteScalar()) + 1;
            txtID.Text = contID.ToString();
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
