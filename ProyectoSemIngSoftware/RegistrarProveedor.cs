using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.IO;

namespace ProyectoSemIngSoftware
{
    public partial class RegistrarProveedor : Form
    {
        public RegistrarProveedor()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtNombreProv_Enter(object sender, EventArgs e)
        {
            if (txtNombreProv.Text == "Nombre")
            {
                txtNombreProv.Text = "";
            }
        }

        private void txtNombreProv_Leave(object sender, EventArgs e)
        {
            if (txtNombreProv.Text == "")
            {
                txtNombreProv.Text = "Nombre";
            }
        }

        private void txtDireccion_Enter(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "Dirección")
            {
                txtDireccion.Text = "";
            }
        }

        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "")
            {
                txtDireccion.Text = "Dirección";
            }
        }

        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "Número Telefónico")
            {
                txtTelefono.Text = "";
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "")
            {
                txtTelefono.Text = "Número Telefónico";
            }
        }

        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "Correo electrónico")
            {
                txtCorreo.Text = "";
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "Correo electrónico";
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
            txtNombreProv.Text = "Nombre";
            txtDireccion.Text = "Dirección";
            txtTelefono.Text = "Número Telefónico";
            txtCorreo.Text = "Correo electrónico";
            if(ptbImagen.Image != null)
            {
                ptbImagen.Image.Dispose();
                ptbImagen.Image = null;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtNombreProv.Text != "Nombre")
            {
                if (txtDireccion.Text != "Dirección")
                {
                    if (txtTelefono.Text != "Número Telefónico")
                    {
                        if (txtCorreo.Text != "Correo electrónico")
                        {
                            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
                            conectar.Open();

                            MemoryStream ms = new MemoryStream();
                            ptbImagen.Image.Save(ms, ptbImagen.Image.RawFormat);
                            byte[] img = ms.ToArray();

                            String query = "insert into proveedor(Nombre_Prov, DireccionProv, Numero_Telefono, CorreoElectronico, ImagenProveedor) values (@nombre, @direccion, @num_tel, @correo, @img)";

                            MySqlCommand registrar = new MySqlCommand(query, conectar);

                            registrar.Parameters.Add("@nombre", MySqlDbType.VarChar, 50);
                            registrar.Parameters.Add("@direccion", MySqlDbType.Text);
                            registrar.Parameters.Add("@num_tel", MySqlDbType.VarChar, 10);
                            registrar.Parameters.Add("@correo", MySqlDbType.Text);
                            registrar.Parameters.Add("@img", MySqlDbType.Blob);

                            registrar.Parameters["@nombre"].Value = txtNombreProv.Text;
                            registrar.Parameters["@direccion"].Value = txtDireccion.Text;
                            registrar.Parameters["@num_tel"].Value = txtTelefono.Text;
                            registrar.Parameters["@correo"].Value = txtCorreo.Text;
                            registrar.Parameters["@img"].Value = img;


                            if (registrar.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Proveedor agregado exitosamente");
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

        private void RegistrarProveedor_Load(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            String query = "select count(*) from proveedor";
            MySqlCommand consultar = new MySqlCommand(query, conectar);
            int contID = Convert.ToInt32(consultar.ExecuteScalar()) + 1;
            txtID.Text = contID.ToString();
            conectar.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            MenuProveedor regresar = new MenuProveedor();
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
            MenuProveedor regresar = new MenuProveedor();
            regresar.Show();
            this.Hide();
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
