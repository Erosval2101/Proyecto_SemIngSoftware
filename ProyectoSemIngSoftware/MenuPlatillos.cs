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

namespace ProyectoSemIngSoftware
{
    public partial class MenuPlatillos : Form
    {
        public MenuPlatillos()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            MenuGerente regresar = new MenuGerente();
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

        private void MenuPlatillos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarPlatillo ver = new RegistrarPlatillo();
            ver.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarPlatillo ver = new BuscarPlatillo();
            ver.Show();
            this.Hide();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarPlatillo ver = new ModificarPlatillo();
            ver.Show();
            this.Hide();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            ReportePlatillos ver = new ReportePlatillos();
            ver.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MenuGerente regresar = new MenuGerente();
            regresar.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MenuGerente regresar = new MenuGerente();
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
