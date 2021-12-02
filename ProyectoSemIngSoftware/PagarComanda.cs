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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ProyectoSemIngSoftware
{
    public partial class PagarComanda : Form
    {
        String id_cajero, id_comanda;
        double porcentaje_iva = 0.16;

        public PagarComanda(String id)
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void PagarComanda_Load(object sender, EventArgs e)
        {
            String nombre_cajero = buscar_NombreCajero(id_cajero);

            txtIDCajero.Text = id_cajero;
            txtNombreCajero.Text = nombre_cajero;


            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            MySqlCommand buscar = new MySqlCommand();
            buscar.Connection = conectar;

            buscar.CommandText = ("select * from comanda where Estatus = 'Cerrada'");

            MySqlDataReader leerConsulta = buscar.ExecuteReader();
            if (leerConsulta.Read())
            {
                dtgvComanda.Rows.Clear();
                String nombre_mesero, nombre_cocinero;
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dtgvComanda);
                fila.Cells[0].Value = leerConsulta.GetString(0); //ID Comanda
                fila.Cells[1].Value = leerConsulta.GetString(1); // ID Mesero
                nombre_mesero = buscar_NombreMesero(leerConsulta.GetString(1));
                fila.Cells[2].Value = nombre_mesero; // Nombre Mesero
                fila.Cells[3].Value = leerConsulta.GetString(2); //ID Cocinero
                nombre_cocinero = buscar_NombreCocinero(leerConsulta.GetString(2));
                fila.Cells[4].Value = nombre_cocinero; //Nombre Cocinero
                fila.Cells[5].Value = leerConsulta.GetString(4); //Nombre Cliente
                fila.Cells[6].Value = leerConsulta.GetString(5); //Fecha Inicio
                fila.Cells[7].Value = leerConsulta.GetString(6); //Estatus
                fila.Cells[8].Value = leerConsulta.GetString(7); //No. Personas
                fila.Cells[9].Value = leerConsulta.GetString(8); //Mesa
                fila.Cells[10].Value = leerConsulta.GetString(10); //Observaciones

                dtgvComanda.Rows.Add(fila);

                buscar_Detalle(leerConsulta.GetString(0));
            }
            else
            {
                MessageBox.Show("No hay comandas por cobrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgvComanda.Rows.Clear();
                dtgvDetalle.Rows.Clear();
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
                conectar.Close();
                return nombre_mesero;
            }
            else
            {
                conectar.Close();
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
            lblSubtotal.Text = _importe.ToString();
            decimal _iva = _importe * Convert.ToDecimal(porcentaje_iva);
            lblIVA.Text = _iva.ToString();
            lblTotal.Text = Convert.ToString(_iva + _importe);

            conectar.Close();
        }

        private void dtgvComanda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String id_com = this.dtgvComanda.CurrentRow.Cells[0].Value.ToString();
                buscar_Detalle(id_com);
            }
            catch(Exception)
            {
                MessageBox.Show("No hay comandas por cobrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                id_comanda = this.dtgvComanda.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("No hay comandas por cobrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            MySqlConnection conectar = new MySqlConnection("server=localhost; database=sistema_memin; Uid=root; Pwd=; port=3306");
            conectar.Open();

            String query = "update comanda set ID_Cajero=@idcajero, FechaCierre=@f_cierre, Estatus = 'Finalizada' where IDComanda = '" + id_comanda + "'";

            MySqlCommand registrar = new MySqlCommand(query, conectar);

            registrar.Parameters.Add("@idcajero", MySqlDbType.VarChar, 13);
            registrar.Parameters.Add("@f_cierre", MySqlDbType.DateTime);

            registrar.Parameters["@idcajero"].Value = id_cajero;
            registrar.Parameters["@f_cierre"].Value = Convert.ToDateTime(txtFecha.Text);

            if (registrar.ExecuteNonQuery() == 1)
            {
                String query_detalle = "insert into pagar_comanda(ID_Comanda, TipoPago, MontoPago) values (@idcomanda, @tipopago, @monto)";

                MySqlCommand registrar_detalle = new MySqlCommand(query_detalle, conectar);

                registrar_detalle.Parameters.Clear();
                registrar_detalle.Parameters.Add("@idcomanda", MySqlDbType.Int32, 11);
                registrar_detalle.Parameters.Add("@tipopago", MySqlDbType.Enum);
                registrar_detalle.Parameters.Add("@monto", MySqlDbType.Float);

                registrar_detalle.Parameters["@idcomanda"].Value = id_comanda;
                registrar_detalle.Parameters["@tipopago"].Value = cmbTipo.SelectedItem.ToString();
                registrar_detalle.Parameters["@monto"].Value = lblTotal.Text;

                registrar_detalle.ExecuteNonQuery();
                MessageBox.Show("Comanda cobrada exitosamente");
                generarPDF();
                PagarComanda_Load(null, e);
                conectar.Close();
            }
            else
            {
                MessageBox.Show("Error al momento de cobrar la comanda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conectar.Close();
            }
        }

        private void generarPDF()
        {
            Document doc = new Document(PageSize.LETTER);
            PdfWriter.GetInstance(doc, new FileStream("cuenta" + id_comanda + ".pdf", FileMode.Create));

            doc.Open();

            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            doc.Add(new Paragraph("                                                                           Restaurante el Memín"));
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph("Cuenta"));
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph("ID de Comanda: " + id_comanda + "                                              RFC Cajero: " + txtIDCajero.Text));
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph("Nombre Cajero: " + txtNombreCajero.Text + "                                      Nombre Cliente: " + this.dtgvComanda.CurrentRow.Cells[5].Value.ToString()));
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph("RFC Mesero: " + this.dtgvComanda.CurrentRow.Cells[1].Value.ToString() + "                                         Nombre Mesero: " + this.dtgvComanda.CurrentRow.Cells[2].Value.ToString()));
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph("RFC Cocinero: " + this.dtgvComanda.CurrentRow.Cells[3].Value.ToString() + "                                       Nombre Cocinero: " + this.dtgvComanda.CurrentRow.Cells[4].Value.ToString()));
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph("Fecha Inicio: " + this.dtgvComanda.CurrentRow.Cells[6].Value.ToString() + "                                    Fecha Cierre: " + txtFecha.Text));
            doc.Add(Chunk.NEWLINE);

            PdfPTable tblCuenta = new PdfPTable(5);
            tblCuenta.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clIDComanda = new PdfPCell(new Phrase("ID de Comanda", _standardFont));
            clIDComanda.BorderWidth = 0;
            clIDComanda.BorderWidthBottom = 0.70f;

            PdfPCell clIDPlatillo = new PdfPCell(new Phrase("ID de Platillo", _standardFont));
            clIDPlatillo.BorderWidth = 0;
            clIDPlatillo.BorderWidthBottom = 0.70f;

            PdfPCell clDescp = new PdfPCell(new Phrase("Descripción", _standardFont));
            clDescp.BorderWidth = 0;
            clDescp.BorderWidthBottom = 0.70f;

            PdfPCell clCantidad= new PdfPCell(new Phrase("Cantidad", _standardFont));
            clCantidad.BorderWidth = 0;
            clCantidad.BorderWidthBottom = 0.70f;

            PdfPCell clPrecio = new PdfPCell(new Phrase("Precio", _standardFont));
            clPrecio.BorderWidth = 0;
            clPrecio.BorderWidthBottom = 0.70f;

            // Añadimos las celdas a la tabla
            tblCuenta.AddCell(clIDComanda);
            tblCuenta.AddCell(clIDPlatillo);
            tblCuenta.AddCell(clDescp);
            tblCuenta.AddCell(clCantidad);
            tblCuenta.AddCell(clPrecio);


            foreach (DataGridViewRow r in dtgvDetalle.Rows)
            {
                clIDComanda = new PdfPCell(new Phrase(r.Cells[0].Value.ToString(), _standardFont));
                clIDComanda.BorderWidth = 0;

                clIDPlatillo = new PdfPCell(new Phrase(r.Cells[1].Value.ToString(), _standardFont));
                clIDPlatillo.BorderWidth = 0;

                clDescp = new PdfPCell(new Phrase(r.Cells[2].Value.ToString(), _standardFont));
                clDescp.BorderWidth = 0;

                clCantidad = new PdfPCell(new Phrase(r.Cells[3].Value.ToString(), _standardFont));
                clCantidad.BorderWidth = 0;

                clPrecio = new PdfPCell(new Phrase(r.Cells[4].Value.ToString(), _standardFont));
                clPrecio.BorderWidth = 0;

                tblCuenta.AddCell(clIDComanda);
                tblCuenta.AddCell(clIDPlatillo);
                tblCuenta.AddCell(clDescp);
                tblCuenta.AddCell(clCantidad);
                tblCuenta.AddCell(clPrecio);
            }

            doc.Add(tblCuenta);

            doc.Add(new Paragraph("Subtotal: " + lblSubtotal.Text + "                IVA: " + lblIVA.Text + "                       Total: " + lblTotal.Text));
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph("Restaurante el Memín le agradece por su compra, ¡Qué tenga un buen día!"));
            doc.Add(Chunk.NEWLINE);

            doc.Close();
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
