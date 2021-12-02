namespace ProyectoSemIngSoftware
{
    partial class ModificarComanda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarComanda));
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.txtDescp = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dtgvProducto = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nupCantidad = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.nupMesa = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.nudPersonas = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lineShape6 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.nudID = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.fechaHora = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersonas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudID)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(879, 3);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(24, 24);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnMinimizar.TabIndex = 17;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
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
            this.panel1.Size = new System.Drawing.Size(948, 30);
            this.panel1.TabIndex = 4;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.BackColor = System.Drawing.Color.Transparent;
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("btnRestaurar.Image")));
            this.btnRestaurar.Location = new System.Drawing.Point(900, 3);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(24, 24);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnRestaurar.TabIndex = 16;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Visible = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(921, 3);
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
            this.btnMaximizar.Location = new System.Drawing.Point(900, 3);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(24, 24);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnMaximizar.TabIndex = 15;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // txtDescp
            // 
            this.txtDescp.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescp.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtDescp.Location = new System.Drawing.Point(270, 309);
            this.txtDescp.Name = "txtDescp";
            this.txtDescp.Size = new System.Drawing.Size(370, 20);
            this.txtDescp.TabIndex = 53;
            this.txtDescp.Text = "Descripción";
            this.txtDescp.Enter += new System.EventHandler(this.txtDescp_Enter);
            this.txtDescp.Leave += new System.EventHandler(this.txtDescp_Leave);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnModificar.Location = new System.Drawing.Point(745, 515);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(157, 49);
            this.btnModificar.TabIndex = 66;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLimpiar.Location = new System.Drawing.Point(745, 456);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(157, 32);
            this.btnLimpiar.TabIndex = 65;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEliminar.Location = new System.Drawing.Point(745, 404);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(157, 33);
            this.btnEliminar.TabIndex = 64;
            this.btnEliminar.Text = "Eliminar Platillo";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAgregar.Location = new System.Drawing.Point(745, 359);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(157, 30);
            this.btnAgregar.TabIndex = 63;
            this.btnAgregar.Text = "Agregar Platillo";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dtgvProducto
            // 
            this.dtgvProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvProducto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgvProducto.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dtgvProducto.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dtgvProducto.Location = new System.Drawing.Point(39, 359);
            this.dtgvProducto.Name = "dtgvProducto";
            this.dtgvProducto.Size = new System.Drawing.Size(661, 146);
            this.dtgvProducto.TabIndex = 62;
            this.dtgvProducto.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvProducto_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Descripción";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Precio";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Cantidad";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Importe";
            this.Column5.Name = "Column5";
            // 
            // nupCantidad
            // 
            this.nupCantidad.Font = new System.Drawing.Font("Coolvetica Rg", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupCantidad.Location = new System.Drawing.Point(724, 307);
            this.nupCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupCantidad.Name = "nupCantidad";
            this.nupCantidad.Size = new System.Drawing.Size(152, 22);
            this.nupCantidad.TabIndex = 54;
            this.nupCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(646, 308);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 19);
            this.label13.TabIndex = 61;
            this.label13.Text = "Cantidad:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.SystemColors.Control;
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservaciones.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtObservaciones.Location = new System.Drawing.Point(486, 144);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(416, 116);
            this.txtObservaciones.TabIndex = 51;
            this.txtObservaciones.Text = "Observaciones";
            this.txtObservaciones.Enter += new System.EventHandler(this.txtObservaciones_Enter);
            this.txtObservaciones.Leave += new System.EventHandler(this.txtObservaciones_Leave);
            // 
            // nupMesa
            // 
            this.nupMesa.Font = new System.Drawing.Font("Coolvetica Rg", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupMesa.Location = new System.Drawing.Point(91, 262);
            this.nupMesa.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nupMesa.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupMesa.Name = "nupMesa";
            this.nupMesa.Size = new System.Drawing.Size(236, 22);
            this.nupMesa.TabIndex = 59;
            this.nupMesa.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(38, 263);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 19);
            this.label11.TabIndex = 58;
            this.label11.Text = "Mesa:";
            // 
            // nudPersonas
            // 
            this.nudPersonas.Font = new System.Drawing.Font("Coolvetica Rg", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPersonas.Location = new System.Drawing.Point(194, 220);
            this.nudPersonas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPersonas.Name = "nudPersonas";
            this.nudPersonas.Size = new System.Drawing.Size(197, 22);
            this.nudPersonas.TabIndex = 50;
            this.nudPersonas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(38, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 19);
            this.label8.TabIndex = 57;
            this.label8.Text = "Número de Personas:";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.BackColor = System.Drawing.SystemColors.Control;
            this.txtNombreCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreCliente.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtNombreCliente.Location = new System.Drawing.Point(41, 131);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(416, 20);
            this.txtNombreCliente.TabIndex = 47;
            this.txtNombreCliente.Text = "Nombre del Cliente";
            this.txtNombreCliente.Enter += new System.EventHandler(this.txtNombreCliente_Enter);
            this.txtNombreCliente.Leave += new System.EventHandler(this.txtNombreCliente_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Coolvetica Rg", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(312, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 45);
            this.label1.TabIndex = 46;
            this.label1.Text = "Modificar comanda";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lineShape6
            // 
            this.lineShape6.Name = "lineShape6";
            this.lineShape6.X1 = 38;
            this.lineShape6.X2 = 456;
            this.lineShape6.Y1 = 156;
            this.lineShape6.Y2 = 156;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1,
            this.lineShape6});
            this.shapeContainer1.Size = new System.Drawing.Size(948, 601);
            this.shapeContainer1.TabIndex = 67;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 269;
            this.lineShape1.X2 = 638;
            this.lineShape1.Y1 = 332;
            this.lineShape1.Y2 = 332;
            // 
            // txtFecha
            // 
            this.txtFecha.BackColor = System.Drawing.SystemColors.Control;
            this.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFecha.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtFecha.Location = new System.Drawing.Point(95, 179);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(362, 20);
            this.txtFecha.TabIndex = 68;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(38, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 19);
            this.label9.TabIndex = 69;
            this.label9.Text = "Fecha:";
            // 
            // nudID
            // 
            this.nudID.Font = new System.Drawing.Font("Coolvetica Rg", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudID.Location = new System.Drawing.Point(110, 313);
            this.nudID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudID.Name = "nudID";
            this.nudID.Size = new System.Drawing.Size(152, 22);
            this.nudID.TabIndex = 70;
            this.nudID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudID_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(34, 314);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 19);
            this.label12.TabIndex = 71;
            this.label12.Text = "ID Platillo:";
            // 
            // fechaHora
            // 
            this.fechaHora.Enabled = true;
            this.fechaHora.Tick += new System.EventHandler(this.fechaHora_Tick);
            // 
            // ModificarComanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 601);
            this.Controls.Add(this.nudID);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDescp);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dtgvProducto);
            this.Controls.Add(this.nupCantidad);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.nupMesa);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.nudPersonas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ModificarComanda";
            this.Text = "ModificarComanda";
            this.Load += new System.EventHandler(this.ModificarComanda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersonas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.TextBox txtDescp;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dtgvProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.NumericUpDown nupCantidad;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.NumericUpDown nupMesa;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudPersonas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label label1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape6;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Timer fechaHora;
    }
}