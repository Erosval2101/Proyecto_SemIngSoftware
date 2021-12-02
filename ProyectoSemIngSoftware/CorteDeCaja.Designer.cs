namespace ProyectoSemIngSoftware
{
    partial class CorteDeCaja
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorteDeCaja));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVoucher = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreCajero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIDCajero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtgvComanda = new System.Windows.Forms.DataGridView();
            this.fechaHora = new System.Windows.Forms.Timer(this.components);
            this.dtgvDetalle = new System.Windows.Forms.DataGridView();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvComanda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.btnRestaurar);
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnMaximizar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 30);
            this.panel1.TabIndex = 4;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.BackColor = System.Drawing.Color.Transparent;
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("btnRestaurar.Image")));
            this.btnRestaurar.Location = new System.Drawing.Point(822, 3);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(24, 24);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnRestaurar.TabIndex = 16;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Visible = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(801, 3);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(24, 24);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnMinimizar.TabIndex = 17;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(843, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(24, 24);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnCerrar.TabIndex = 14;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(822, 3);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(24, 24);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnMaximizar.TabIndex = 15;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(43, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Coolvetica Rg", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(326, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 45);
            this.label1.TabIndex = 23;
            this.label1.Text = "Corte de Caja";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblVoucher
            // 
            this.lblVoucher.AutoSize = true;
            this.lblVoucher.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucher.Location = new System.Drawing.Point(597, 566);
            this.lblVoucher.Name = "lblVoucher";
            this.lblVoucher.Size = new System.Drawing.Size(13, 19);
            this.lblVoucher.TabIndex = 64;
            this.lblVoucher.Text = " ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(467, 566);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 19);
            this.label8.TabIndex = 63;
            this.label8.Text = "Total de Voucher:";
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfectivo.Location = new System.Drawing.Point(272, 566);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(13, 19);
            this.lblEfectivo.TabIndex = 62;
            this.lblEfectivo.Text = " ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(141, 566);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 19);
            this.label2.TabIndex = 61;
            this.label2.Text = "Total de Efectivo:";
            // 
            // txtNombreCajero
            // 
            this.txtNombreCajero.BackColor = System.Drawing.SystemColors.Control;
            this.txtNombreCajero.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreCajero.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCajero.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtNombreCajero.Location = new System.Drawing.Point(169, 171);
            this.txtNombreCajero.Name = "txtNombreCajero";
            this.txtNombreCajero.ReadOnly = true;
            this.txtNombreCajero.Size = new System.Drawing.Size(677, 20);
            this.txtNombreCajero.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 19);
            this.label4.TabIndex = 60;
            this.label4.Text = "Nombre del Cajero:";
            // 
            // txtIDCajero
            // 
            this.txtIDCajero.BackColor = System.Drawing.SystemColors.Control;
            this.txtIDCajero.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIDCajero.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDCajero.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtIDCajero.Location = new System.Drawing.Point(145, 134);
            this.txtIDCajero.Name = "txtIDCajero";
            this.txtIDCajero.ReadOnly = true;
            this.txtIDCajero.Size = new System.Drawing.Size(268, 20);
            this.txtIDCajero.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 19);
            this.label3.TabIndex = 58;
            this.label3.Text = "RFC del Cajero:";
            // 
            // txtFecha
            // 
            this.txtFecha.BackColor = System.Drawing.SystemColors.Control;
            this.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFecha.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtFecha.Location = new System.Drawing.Point(524, 134);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(332, 20);
            this.txtFecha.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(467, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 19);
            this.label9.TabIndex = 56;
            this.label9.Text = "Fecha:";
            // 
            // dtgvComanda
            // 
            this.dtgvComanda.AllowUserToAddRows = false;
            this.dtgvComanda.AllowUserToDeleteRows = false;
            this.dtgvComanda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvComanda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvComanda.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgvComanda.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvComanda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvComanda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6});
            this.dtgvComanda.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dtgvComanda.Location = new System.Drawing.Point(14, 208);
            this.dtgvComanda.Name = "dtgvComanda";
            this.dtgvComanda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvComanda.Size = new System.Drawing.Size(840, 135);
            this.dtgvComanda.TabIndex = 53;
            this.dtgvComanda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvComanda_CellClick);
            // 
            // fechaHora
            // 
            this.fechaHora.Enabled = true;
            this.fechaHora.Tick += new System.EventHandler(this.fechaHora_Tick);
            // 
            // dtgvDetalle
            // 
            this.dtgvDetalle.AllowUserToAddRows = false;
            this.dtgvDetalle.AllowUserToDeleteRows = false;
            this.dtgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvDetalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgvDetalle.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19});
            this.dtgvDetalle.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dtgvDetalle.Location = new System.Drawing.Point(14, 372);
            this.dtgvDetalle.Name = "dtgvDetalle";
            this.dtgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvDetalle.Size = new System.Drawing.Size(833, 172);
            this.dtgvDetalle.TabIndex = 65;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "ID Comanda";
            this.Column15.Name = "Column15";
            // 
            // Column16
            // 
            this.Column16.HeaderText = "ID del Platillo";
            this.Column16.Name = "Column16";
            // 
            // Column17
            // 
            this.Column17.HeaderText = "Descripción";
            this.Column17.Name = "Column17";
            // 
            // Column18
            // 
            this.Column18.HeaderText = "Cantidad";
            this.Column18.Name = "Column18";
            // 
            // Column19
            // 
            this.Column19.HeaderText = "Precio";
            this.Column19.Name = "Column19";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID Comanda";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ID Cajero";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Nombre Cajero";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Tipo de Pago";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Monto";
            this.Column6.Name = "Column6";
            // 
            // CorteDeCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 610);
            this.Controls.Add(this.dtgvDetalle);
            this.Controls.Add(this.lblVoucher);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblEfectivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreCajero);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIDCajero);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtgvComanda);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CorteDeCaja";
            this.Text = "CorteDeCaja";
            this.Load += new System.EventHandler(this.CorteDeCaja_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvComanda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVoucher;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreCajero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIDCajero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dtgvComanda;
        private System.Windows.Forms.Timer fechaHora;
        private System.Windows.Forms.DataGridView dtgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}