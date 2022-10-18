namespace ProlecGE.ControlPisoMX.CoreSupply.Forms
{
    partial class PrintSupplyTagForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintSupplyTagForm));
            this.lblUserName = new System.Windows.Forms.Label();
            this.picBoxUserImage = new System.Windows.Forms.PictureBox();
            this.picBoxEnterpriseLogo = new System.Windows.Forms.PictureBox();
            this.picBoxTitleLine = new System.Windows.Forms.PictureBox();
            this.grOrders = new System.Windows.Forms.DataGridView();
            this.btnAuthorize = new System.Windows.Forms.Button();
            this.lblTitleSupplies = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.lblBatch = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReprintInsulations = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnReprint = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTitleLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Location = new System.Drawing.Point(644, 11);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 40);
            this.lblUserName.TabIndex = 70;
            this.lblUserName.Text = "Daniela Pérez Gavilan García del campo";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picBoxUserImage
            // 
            this.picBoxUserImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxUserImage.Location = new System.Drawing.Point(780, 11);
            this.picBoxUserImage.Name = "picBoxUserImage";
            this.picBoxUserImage.Size = new System.Drawing.Size(40, 40);
            this.picBoxUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxUserImage.TabIndex = 69;
            this.picBoxUserImage.TabStop = false;
            // 
            // picBoxEnterpriseLogo
            // 
            this.picBoxEnterpriseLogo.Image = ((System.Drawing.Image)(resources.GetObject("picBoxEnterpriseLogo.Image")));
            this.picBoxEnterpriseLogo.Location = new System.Drawing.Point(20, 11);
            this.picBoxEnterpriseLogo.Name = "picBoxEnterpriseLogo";
            this.picBoxEnterpriseLogo.Size = new System.Drawing.Size(40, 40);
            this.picBoxEnterpriseLogo.TabIndex = 68;
            this.picBoxEnterpriseLogo.TabStop = false;
            // 
            // picBoxTitleLine
            // 
            this.picBoxTitleLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxTitleLine.Image = ((System.Drawing.Image)(resources.GetObject("picBoxTitleLine.Image")));
            this.picBoxTitleLine.Location = new System.Drawing.Point(20, 55);
            this.picBoxTitleLine.Name = "picBoxTitleLine";
            this.picBoxTitleLine.Size = new System.Drawing.Size(800, 5);
            this.picBoxTitleLine.TabIndex = 67;
            this.picBoxTitleLine.TabStop = false;
            // 
            // grOrders
            // 
            this.grOrders.AllowUserToAddRows = false;
            this.grOrders.AllowUserToDeleteRows = false;
            this.grOrders.AllowUserToOrderColumns = true;
            this.grOrders.AllowUserToResizeRows = false;
            this.grOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grOrders.Location = new System.Drawing.Point(19, 138);
            this.grOrders.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grOrders.Name = "grOrders";
            this.grOrders.RowHeadersVisible = false;
            this.grOrders.RowHeadersWidth = 51;
            this.grOrders.RowTemplate.Height = 29;
            this.grOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grOrders.Size = new System.Drawing.Size(800, 492);
            this.grOrders.TabIndex = 6;
            this.grOrders.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrOrders_CellValueChanged);
            this.grOrders.CurrentCellDirtyStateChanged += new System.EventHandler(this.GrOrders_CurrentCellDirtyStateChanged);
            // 
            // btnAuthorize
            // 
            this.btnAuthorize.Location = new System.Drawing.Point(553, 641);
            this.btnAuthorize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAuthorize.Name = "btnAuthorize";
            this.btnAuthorize.Size = new System.Drawing.Size(75, 26);
            this.btnAuthorize.TabIndex = 9;
            this.btnAuthorize.Text = "Autorizar";
            this.btnAuthorize.UseVisualStyleBackColor = true;
            this.btnAuthorize.Click += new System.EventHandler(this.BtnAuthorize_Click);
            // 
            // lblTitleSupplies
            // 
            this.lblTitleSupplies.AutoSize = true;
            this.lblTitleSupplies.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitleSupplies.Location = new System.Drawing.Point(64, 17);
            this.lblTitleSupplies.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleSupplies.Name = "lblTitleSupplies";
            this.lblTitleSupplies.Size = new System.Drawing.Size(275, 29);
            this.lblTitleSupplies.TabIndex = 61;
            this.lblTitleSupplies.Text = "Impresión de etiquetas";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(19, 641);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Salir";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPrint.Location = new System.Drawing.Point(734, 641);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(85, 26);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(384, 77);
            this.txtQuantity.MaxLength = 0;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 21);
            this.txtQuantity.TabIndex = 2;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtQuantity_KeyPress);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(323, 80);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(57, 15);
            this.lblQuantity.TabIndex = 77;
            this.lblQuantity.Text = "Cantidad";
            // 
            // txtBatch
            // 
            this.txtBatch.Location = new System.Drawing.Point(217, 77);
            this.txtBatch.MaxLength = 3;
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(100, 21);
            this.txtBatch.TabIndex = 1;
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.Location = new System.Drawing.Point(181, 80);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(31, 15);
            this.lblBatch.TabIndex = 75;
            this.lblBatch.Text = "Lote";
            // 
            // txtItem
            // 
            this.txtItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtItem.Location = new System.Drawing.Point(75, 77);
            this.txtItem.MaxLength = 47;
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(100, 21);
            this.txtItem.TabIndex = 0;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItem.Location = new System.Drawing.Point(20, 80);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(47, 15);
            this.lblItem.TabIndex = 73;
            this.lblItem.Text = "Artículo";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(744, 74);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(658, 74);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 26);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Limpiar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnReprintInsulations
            // 
            this.btnReprintInsulations.Location = new System.Drawing.Point(325, 641);
            this.btnReprintInsulations.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReprintInsulations.Name = "btnReprintInsulations";
            this.btnReprintInsulations.Size = new System.Drawing.Size(180, 26);
            this.btnReprintInsulations.TabIndex = 10;
            this.btnReprintInsulations.Text = "Reimpresión aislamientos";
            this.btnReprintInsulations.UseVisualStyleBackColor = true;
            this.btnReprintInsulations.Click += new System.EventHandler(this.BtnReprintInsulation_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Location = new System.Drawing.Point(201, 641);
            this.btnOrders.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(116, 26);
            this.btnOrders.TabIndex = 11;
            this.btnOrders.Text = "Ordenes pedidas";
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.BtnOrders_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(636, 641);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(90, 26);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "Comprobar";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // btnReprint
            // 
            this.btnReprint.Location = new System.Drawing.Point(102, 641);
            this.btnReprint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(91, 26);
            this.btnReprint.TabIndex = 12;
            this.btnReprint.Text = "Reimpresión";
            this.btnReprint.UseVisualStyleBackColor = true;
            this.btnReprint.Click += new System.EventHandler(this.BtnReprint_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(694, 113);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(125, 19);
            this.chkSelectAll.TabIndex = 5;
            this.chkSelectAll.Text = "Seleccionar todos";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.ChkSelectAll_CheckedChanged);
            // 
            // PrintSupplyTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 681);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtBatch);
            this.Controls.Add(this.lblBatch);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picBoxUserImage);
            this.Controls.Add(this.picBoxEnterpriseLogo);
            this.Controls.Add(this.picBoxTitleLine);
            this.Controls.Add(this.grOrders);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnReprintInsulations);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnReprint);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnAuthorize);
            this.Controls.Add(this.lblTitleSupplies);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PrintSupplyTagForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impresión de etiquetas";
            this.Load += new System.EventHandler(this.PrintSupplyTagForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTitleLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblUserName;
        private PictureBox picBoxUserImage;
        private PictureBox picBoxEnterpriseLogo;
        private PictureBox picBoxTitleLine;
        private DataGridView grOrders;
        private Button btnAuthorize;
        private Label lblTitleSupplies;
        private Button btnClose;
        private Button btnPrint;
        private TextBox txtQuantity;
        private Label lblQuantity;
        private TextBox txtBatch;
        private Label lblBatch;
        private TextBox txtItem;
        private Label lblItem;
        private Button btnSearch;
        private Button btnClear;
        private Button btnReprintInsulations;
        private Button btnOrders;
        private Button btnConfirm;
        private Button btnReprint;
        private CheckBox chkSelectAll;
    }
}