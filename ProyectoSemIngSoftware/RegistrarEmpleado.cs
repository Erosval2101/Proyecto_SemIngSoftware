﻿using System;
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
    public partial class RegistrarEmpleado : Form
    {
        public RegistrarEmpleado()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void dateTimePicker1_MouseDown(object sender, MouseEventArgs e)
        {
            dateTimePicker1.CustomFormat = "HH:mm:ss";
        }

        public OpenFileDialog examinar = new OpenFileDialog();
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            examinar.Filter = "Archivos de Imagen |*.jpg; *.png;";
            DialogResult r = examinar.ShowDialog();
            if(r == DialogResult.Abort)
            {
                return;
            }
            if(r == DialogResult.Cancel)
            {
                return;
            }
            ptbImagen.Image = Image.FromFile(examinar.FileName);
        }

        private void dateTimePicker2_MouseDown(object sender, MouseEventArgs e)
        {
            dateTimePicker2.CustomFormat = "HH:mm:ss";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MenuEmpleado regresar = new MenuEmpleado();
            regresar.Show();
            this.Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtID.Text = "RFC de Empleado";
            txtNombre.Text = "Nombre";
            txtApPat.Text = "Apellido Paterno";
            txtApMat.Text = "Apellido Materno";
            txtPuesto.Text = "Puesto";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            txtTelefono.Text = "Número Telefónico";
            txtCorreo.Text = "Correo Electrónico";
            if (ptbImagen.Image != null)
            {
                ptbImagen.Image.Dispose();
                ptbImagen.Image = null;
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre")
            {
                txtNombre.Text = "";
            }
        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            if (txtID.Text == "RFC del Empleado")
            {
                txtID.Text = "";
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre";
            }
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                txtID.Text = "RFC del Empleado";
            }
        }

        private void txtApPat_Enter(object sender, EventArgs e)
        {
            if (txtApPat.Text == "Apellido Paterno")
            {
                txtApPat.Text = "";
            }
        }

        private void txtApPat_Leave(object sender, EventArgs e)
        {
            if (txtApPat.Text == "")
            {
                txtApPat.Text = "Apellido Paterno";
            }
        }

        private void txtApMat_Enter(object sender, EventArgs e)
        {
            if (txtApMat.Text == "Apellido Materno")
            {
                txtApMat.Text = "";
            }
        }

        private void txtApMat_Leave(object sender, EventArgs e)
        {
            if (txtApMat.Text == "")
            {
                txtApMat.Text = "Apellido Materno";
            }
        }

        private void txtPuesto_Enter(object sender, EventArgs e)
        {
            if (txtPuesto.Text == "Puesto")
            {
                txtPuesto.Text = "";
            }
        }

        private void txtPuesto_Leave(object sender, EventArgs e)
        {
            if (txtPuesto.Text == "")
            {
                txtPuesto.Text = "Puesto";
            }
        }

        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "Número telefónico")
            {
                txtTelefono.Text = "";
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "")
            {
                txtTelefono.Text = "Número telefónico";
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

        private void btnCrear_Click(object sender, EventArgs e)
        {

            if(txtID.Text != "RFC del Empleado" && txtID.Text.Length == 13)
            {
                if (txtNombre.Text != "Nombre")
                {
                    if (txtApPat.Text != "Apellido Paterno")
                    {
                        if (txtApMat.Text != "Apellido Materno")
                        {
                            if (txtPuesto.Text != "Puesto")
                            {
                                if (txtTelefono.Text != "Número telefónico")
                                {
                                    if (txtCorreo.Text != "Correo electrónico")
                                    {
                                        if(txtContrasena.Text != "Contraseña")
                                        {
                                            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
                                            conectar.Open();

                                            MemoryStream ms = new MemoryStream();
                                            ptbImagen.Image.Save(ms, ptbImagen.Image.RawFormat);
                                            byte[] img = ms.ToArray();

                                            String query = "insert into empleado(IDEmpleado, NombreEmpleado, Ap_PaternoEmpleado, Ap_MaternoEmpleado, Puesto, H_Entrada, H_Salida, Numero_Telefono, CorreoElectronico, Contrasena, ImagenEmpleado) values (@id, @nombre, @ap_pat, @ap_mat, @puesto, @h_ent, @h_sal, @num_tel, @correo, @contrasena, @img)";

                                            MySqlCommand registrar = new MySqlCommand(query, conectar);

                                            registrar.Parameters.Add("@id", MySqlDbType.VarChar, 13);
                                            registrar.Parameters.Add("@nombre", MySqlDbType.VarChar, 40);
                                            registrar.Parameters.Add("@ap_pat", MySqlDbType.VarChar, 30);
                                            registrar.Parameters.Add("@ap_mat", MySqlDbType.VarChar, 30);
                                            registrar.Parameters.Add("@puesto", MySqlDbType.VarChar, 40);
                                            registrar.Parameters.Add("@h_ent", MySqlDbType.Time);
                                            registrar.Parameters.Add("@h_sal", MySqlDbType.Time);
                                            registrar.Parameters.Add("@num_tel", MySqlDbType.VarChar, 10);
                                            registrar.Parameters.Add("@correo", MySqlDbType.Text);
                                            registrar.Parameters.Add("@contrasena", MySqlDbType.VarChar, 15);
                                            registrar.Parameters.Add("@img", MySqlDbType.LongBlob);

                                            registrar.Parameters["@id"].Value = txtID.Text;
                                            registrar.Parameters["@nombre"].Value = txtNombre.Text;
                                            registrar.Parameters["@ap_pat"].Value = txtApPat.Text;
                                            registrar.Parameters["@ap_mat"].Value = txtApMat.Text;
                                            registrar.Parameters["@puesto"].Value = txtPuesto.Text;
                                            registrar.Parameters["@h_ent"].Value = TimeSpan.Parse(dateTimePicker1.Text);
                                            registrar.Parameters["@h_sal"].Value = TimeSpan.Parse(dateTimePicker2.Text);
                                            registrar.Parameters["@num_tel"].Value = txtTelefono.Text;
                                            registrar.Parameters["@correo"].Value = txtCorreo.Text;
                                            registrar.Parameters["@contrasena"].Value = txtContrasena.Text;
                                            registrar.Parameters["@img"].Value = img;


                                            if (registrar.ExecuteNonQuery() == 1)
                                            {
                                                MessageBox.Show("Empleado agregado exitosamente");
                                                btnLimpiar_Click(null, e);
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

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "Contraseña")
            {
                txtCorreo.Text = "";
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "Contraseña";
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;

            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            MenuEmpleado regresar = new MenuEmpleado();
            regresar.Show();
            this.Hide();
        }
    }
}
