namespace ProlecGE.ControlPisoMX.Clamps.Forms
{
    partial class ClampsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClampsForm));
            this.grItems = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Herraje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.K = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dibujo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Maquina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imprimir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClearSelection = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.picBoxUserImage = new System.Windows.Forms.PictureBox();
            this.picBoxSubTitleLine = new System.Windows.Forms.PictureBox();
            this.picBoxEnterpriseLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblFilters = new System.Windows.Forms.Label();
            this.cmbProductLine = new System.Windows.Forms.ComboBox();
            this.chkNational = new System.Windows.Forms.CheckBox();
            this.chkExportation = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSubTitleLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // grItems
            // 
            this.grItems.AllowDrop = true;
            this.grItems.AllowUserToAddRows = false;
            this.grItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grItems.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.grItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Lote,
            this.Serie,
            this.Herraje,
            this.A,
            this.C,
            this.E,
            this.K,
            this.L,
            this.G,
            this.H,
            this.Dibujo,
            this.Maquina,
            this.Nota,
            this.Imprimir,
            this.Tipo});
            this.grItems.GridColor = System.Drawing.SystemColors.Control;
            this.grItems.Location = new System.Drawing.Point(20, 129);
            this.grItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grItems.Name = "grItems";
            this.grItems.RowHeadersVisible = false;
            this.grItems.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.grItems.RowTemplate.Height = 26;
            this.grItems.Size = new System.Drawing.Size(970, 386);
            this.grItems.TabIndex = 1;
            this.grItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrItems_CellContentClick);
            this.grItems.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.GrItems_CellPainting);
            // 
            // Producto
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Producto.DefaultCellStyle = dataGridViewCellStyle1;
            this.Producto.Frozen = true;
            this.Producto.HeaderText = "PRODUCTO";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Producto.Width = 90;
            // 
            // Lote
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Lote.DefaultCellStyle = dataGridViewCellStyle2;
            this.Lote.Frozen = true;
            this.Lote.HeaderText = "LOTE";
            this.Lote.Name = "Lote";
            this.Lote.ReadOnly = true;
            this.Lote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Lote.Width = 46;
            // 
            // Serie
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Serie.DefaultCellStyle = dataGridViewCellStyle3;
            this.Serie.Frozen = true;
            this.Serie.HeaderText = "SERIE";
            this.Serie.Name = "Serie";
            this.Serie.ReadOnly = true;
            this.Serie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Serie.Width = 59;
            // 
            // Herraje
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Herraje.DefaultCellStyle = dataGridViewCellStyle4;
            this.Herraje.Frozen = true;
            this.Herraje.HeaderText = "HERRAJE";
            this.Herraje.Name = "Herraje";
            this.Herraje.ReadOnly = true;
            this.Herraje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Herraje.Width = 90;
            // 
            // A
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.A.DefaultCellStyle = dataGridViewCellStyle5;
            this.A.HeaderText = "A";
            this.A.Name = "A";
            this.A.ReadOnly = true;
            this.A.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.A.Width = 40;
            // 
            // C
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.C.DefaultCellStyle = dataGridViewCellStyle6;
            this.C.HeaderText = "C";
            this.C.Name = "C";
            this.C.ReadOnly = true;
            this.C.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.C.Width = 40;
            // 
            // E
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.E.DefaultCellStyle = dataGridViewCellStyle7;
            this.E.HeaderText = "E";
            this.E.Name = "E";
            this.E.ReadOnly = true;
            this.E.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.E.Width = 40;
            // 
            // K
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.K.DefaultCellStyle = dataGridViewCellStyle8;
            this.K.HeaderText = "K";
            this.K.Name = "K";
            this.K.ReadOnly = true;
            this.K.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.K.Width = 40;
            // 
            // L
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.L.DefaultCellStyle = dataGridViewCellStyle9;
            this.L.HeaderText = "L";
            this.L.Name = "L";
            this.L.ReadOnly = true;
            this.L.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.L.Width = 40;
            // 
            // G
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.G.DefaultCellStyle = dataGridViewCellStyle10;
            this.G.HeaderText = "G";
            this.G.Name = "G";
            this.G.ReadOnly = true;
            this.G.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.G.Width = 40;
            // 
            // H
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.H.DefaultCellStyle = dataGridViewCellStyle11;
            this.H.HeaderText = "H";
            this.H.Name = "H";
            this.H.ReadOnly = true;
            this.H.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.H.Width = 40;
            // 
            // Dibujo
            // 
            this.Dibujo.HeaderText = "DIBUJO";
            this.Dibujo.Name = "Dibujo";
            this.Dibujo.ReadOnly = true;
            this.Dibujo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Dibujo.Width = 87;
            // 
            // Maquina
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Maquina.DefaultCellStyle = dataGridViewCellStyle12;
            this.Maquina.HeaderText = "NO. MÁQUINA";
            this.Maquina.Name = "Maquina";
            this.Maquina.ReadOnly = true;
            this.Maquina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Maquina.Width = 70;
            // 
            // Nota
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Nota.DefaultCellStyle = dataGridViewCellStyle13;
            this.Nota.HeaderText = "NOTA";
            this.Nota.Name = "Nota";
            this.Nota.ReadOnly = true;
            this.Nota.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Nota.Width = 73;
            // 
            // Imprimir
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Imprimir.DefaultCellStyle = dataGridViewCellStyle14;
            this.Imprimir.HeaderText = "";
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Width = 29;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "TIPO";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tipo.Width = 128;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(668, 524);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 31);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Borrar orden";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearSelection.Location = new System.Drawing.Point(776, 524);
            this.btnClearSelection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(130, 31);
            this.btnClearSelection.TabIndex = 3;
            this.btnClearSelection.Text = "Limpiar selección";
            this.btnClearSelection.UseVisualStyleBackColor = false;
            this.btnClearSelection.Click += new System.EventHandler(this.BtnClearSelection_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(914, 524);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 31);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Location = new System.Drawing.Point(783, 9);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(152, 43);
            this.lblUserName.TabIndex = 49;
            this.lblUserName.Text = "Daniela Pérez Gavilan García del campo";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picBoxUserImage
            // 
            this.picBoxUserImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxUserImage.Image = global::ProlecGE.ControlPisoMX.Clamps.Forms.Properties.Resources.user;
            this.picBoxUserImage.Location = new System.Drawing.Point(950, 9);
            this.picBoxUserImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picBoxUserImage.Name = "picBoxUserImage";
            this.picBoxUserImage.Size = new System.Drawing.Size(40, 40);
            this.picBoxUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxUserImage.TabIndex = 48;
            this.picBoxUserImage.TabStop = false;
            // 
            // picBoxSubTitleLine
            // 
            this.picBoxSubTitleLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxSubTitleLine.Image = ((System.Drawing.Image)(resources.GetObject("picBoxSubTitleLine.Image")));
            this.picBoxSubTitleLine.Location = new System.Drawing.Point(20, 54);
            this.picBoxSubTitleLine.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picBoxSubTitleLine.Name = "picBoxSubTitleLine";
            this.picBoxSubTitleLine.Size = new System.Drawing.Size(970, 5);
            this.picBoxSubTitleLine.TabIndex = 47;
            this.picBoxSubTitleLine.TabStop = false;
            // 
            // picBoxEnterpriseLogo
            // 
            this.picBoxEnterpriseLogo.Image = global::ProlecGE.ControlPisoMX.Clamps.Forms.Properties.Resources.prolecge_white;
            this.picBoxEnterpriseLogo.Location = new System.Drawing.Point(20, 9);
            this.picBoxEnterpriseLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picBoxEnterpriseLogo.Name = "picBoxEnterpriseLogo";
            this.picBoxEnterpriseLogo.Size = new System.Drawing.Size(40, 40);
            this.picBoxEnterpriseLogo.TabIndex = 46;
            this.picBoxEnterpriseLogo.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(72, 13);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(124, 32);
            this.lblTitle.TabIndex = 45;
            this.lblTitle.Text = "Herrajes";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(668, 70);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 31);
            this.btnRefresh.TabIndex = 50;
            this.btnRefresh.Text = "Buscar";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // lblFilters
            // 
            this.lblFilters.AutoSize = true;
            this.lblFilters.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFilters.Location = new System.Drawing.Point(20, 78);
            this.lblFilters.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFilters.Name = "lblFilters";
            this.lblFilters.Size = new System.Drawing.Size(278, 24);
            this.lblFilters.TabIndex = 51;
            this.lblFilters.Text = "Obtener la información de:";
            this.lblFilters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbProductLine
            // 
            this.cmbProductLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductLine.FormattingEnabled = true;
            this.cmbProductLine.Items.AddRange(new object[] {
            "Todo",
            "Poste",
            "Pedestal"});
            this.cmbProductLine.Location = new System.Drawing.Point(306, 78);
            this.cmbProductLine.Name = "cmbProductLine";
            this.cmbProductLine.Size = new System.Drawing.Size(121, 23);
            this.cmbProductLine.TabIndex = 52;
            // 
            // chkNational
            // 
            this.chkNational.AutoSize = true;
            this.chkNational.Checked = true;
            this.chkNational.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNational.Location = new System.Drawing.Point(464, 80);
            this.chkNational.Name = "chkNational";
            this.chkNational.Size = new System.Drawing.Size(75, 19);
            this.chkNational.TabIndex = 53;
            this.chkNational.Text = "Nacional";
            this.chkNational.UseVisualStyleBackColor = true;
            // 
            // chkExportation
            // 
            this.chkExportation.AutoSize = true;
            this.chkExportation.Checked = true;
            this.chkExportation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExportation.Location = new System.Drawing.Point(545, 80);
            this.chkExportation.Name = "chkExportation";
            this.chkExportation.Size = new System.Drawing.Size(90, 19);
            this.chkExportation.TabIndex = 54;
            this.chkExportation.Text = "Exportación";
            this.chkExportation.UseVisualStyleBackColor = true;
            // 
            // ClampsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 565);
            this.Controls.Add(this.chkExportation);
            this.Controls.Add(this.chkNational);
            this.Controls.Add(this.cmbProductLine);
            this.Controls.Add(this.lblFilters);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picBoxUserImage);
            this.Controls.Add(this.picBoxSubTitleLine);
            this.Controls.Add(this.picBoxEnterpriseLogo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClearSelection);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.grItems);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "ClampsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Herrajes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnForm_FormClosing);
            this.Load += new System.EventHandler(this.OnForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSubTitleLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView grItems;
        private Button btnDelete;
        private Button btnClearSelection;
        private Button btnExit;
        private Label lblUserName;
        private PictureBox picBoxUserImage;
        private PictureBox picBoxSubTitleLine;
        private PictureBox picBoxEnterpriseLogo;
        private Label lblTitle;
        private Button btnRefresh;
        private Label lblFilters;
        private ComboBox cmbProductLine;
        private CheckBox chkNational;
        private CheckBox chkExportation;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Lote;
        private DataGridViewTextBoxColumn Serie;
        private DataGridViewTextBoxColumn Herraje;
        private DataGridViewTextBoxColumn A;
        private DataGridViewTextBoxColumn C;
        private DataGridViewTextBoxColumn E;
        private DataGridViewTextBoxColumn K;
        private DataGridViewTextBoxColumn L;
        private DataGridViewTextBoxColumn G;
        private DataGridViewTextBoxColumn H;
        private DataGridViewTextBoxColumn Dibujo;
        private DataGridViewTextBoxColumn Maquina;
        private DataGridViewTextBoxColumn Nota;
        private DataGridViewButtonColumn Imprimir;
        private DataGridViewTextBoxColumn Tipo;
    }
}