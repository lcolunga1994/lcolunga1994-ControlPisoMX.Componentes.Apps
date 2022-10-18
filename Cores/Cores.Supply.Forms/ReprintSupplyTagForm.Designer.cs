namespace ProlecGE.ControlPisoMX.CoreSupply.Forms
{
    partial class ReprintSupplyTagForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReprintSupplyTagForm));
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.picBoxUserImage = new System.Windows.Forms.PictureBox();
            this.picBoxEnterpriseLogo = new System.Windows.Forms.PictureBox();
            this.picBoxTitleLine = new System.Windows.Forms.PictureBox();
            this.grItems = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitleSupplies = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTitleLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grItems)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(695, 75);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(125, 19);
            this.chkSelectAll.TabIndex = 5;
            this.chkSelectAll.Text = "Seleccionar todos";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.ChkSelectAll_CheckedChanged);
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Location = new System.Drawing.Point(644, 11);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 40);
            this.lblUserName.TabIndex = 87;
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
            this.picBoxUserImage.TabIndex = 86;
            this.picBoxUserImage.TabStop = false;
            // 
            // picBoxEnterpriseLogo
            // 
            this.picBoxEnterpriseLogo.Image = ((System.Drawing.Image)(resources.GetObject("picBoxEnterpriseLogo.Image")));
            this.picBoxEnterpriseLogo.Location = new System.Drawing.Point(20, 11);
            this.picBoxEnterpriseLogo.Name = "picBoxEnterpriseLogo";
            this.picBoxEnterpriseLogo.Size = new System.Drawing.Size(40, 40);
            this.picBoxEnterpriseLogo.TabIndex = 85;
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
            this.picBoxTitleLine.TabIndex = 84;
            this.picBoxTitleLine.TabStop = false;
            // 
            // grItems
            // 
            this.grItems.AllowUserToAddRows = false;
            this.grItems.AllowUserToDeleteRows = false;
            this.grItems.AllowUserToOrderColumns = true;
            this.grItems.AllowUserToResizeRows = false;
            this.grItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grItems.Location = new System.Drawing.Point(20, 100);
            this.grItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grItems.Name = "grItems";
            this.grItems.RowHeadersVisible = false;
            this.grItems.RowHeadersWidth = 51;
            this.grItems.RowTemplate.Height = 29;
            this.grItems.Size = new System.Drawing.Size(800, 526);
            this.grItems.TabIndex = 6;
            this.grItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrItems_CellValueChanged);
            this.grItems.CurrentCellDirtyStateChanged += new System.EventHandler(this.GrItems_CurrentCellDirtyStateChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(103, 633);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 26);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refrescar";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // lblTitleSupplies
            // 
            this.lblTitleSupplies.AutoSize = true;
            this.lblTitleSupplies.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitleSupplies.Location = new System.Drawing.Point(64, 17);
            this.lblTitleSupplies.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleSupplies.Name = "lblTitleSupplies";
            this.lblTitleSupplies.Size = new System.Drawing.Size(305, 29);
            this.lblTitleSupplies.TabIndex = 81;
            this.lblTitleSupplies.Text = "Reimpresión de etiquetas";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(20, 633);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Salir";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(186, 633);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(83, 26);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // ReprintSupplyTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 671);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picBoxUserImage);
            this.Controls.Add(this.picBoxEnterpriseLogo);
            this.Controls.Add(this.picBoxTitleLine);
            this.Controls.Add(this.grItems);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblTitleSupplies);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ReprintSupplyTagForm";
            this.Text = "Reimpresión Etiquetas";
            this.Load += new System.EventHandler(this.ReprintSupplyTagForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTitleLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox chkSelectAll;
        private Label lblUserName;
        private PictureBox picBoxUserImage;
        private PictureBox picBoxEnterpriseLogo;
        private PictureBox picBoxTitleLine;
        private DataGridView grItems;
        private Button btnRefresh;
        private Label lblTitleSupplies;
        private Button btnClose;
        private Button btnPrint;
    }
}