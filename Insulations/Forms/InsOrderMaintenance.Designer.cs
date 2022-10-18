namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    partial class InsOrderMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsOrderMaintenance));
            this.grdManufacturePlan = new System.Windows.Forms.DataGridView();
            this.RegNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCallCMSSupplie = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblConnectionState = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.picBoxSubTitleLine = new System.Windows.Forms.PictureBox();
            this.picBoxEnterpriseLogo = new System.Windows.Forms.PictureBox();
            this.picBoxUserImage = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.grdMachines = new System.Windows.Forms.DataGridView();
            this.lblNormalColor = new System.Windows.Forms.Label();
            this.lblNormal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLockedColor = new System.Windows.Forms.Label();
            this.lblLocked = new System.Windows.Forms.Label();
            this.lblCriticalColor = new System.Windows.Forms.Label();
            this.lblCritical = new System.Windows.Forms.Label();
            this.lblWarningColor = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.btnOrderInsert = new System.Windows.Forms.Button();
            this.btnSuspend = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdManufacturePlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSubTitleLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMachines)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdManufacturePlan
            // 
            this.grdManufacturePlan.AllowUserToAddRows = false;
            this.grdManufacturePlan.AllowUserToDeleteRows = false;
            this.grdManufacturePlan.AllowUserToOrderColumns = true;
            this.grdManufacturePlan.AllowUserToResizeRows = false;
            this.grdManufacturePlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdManufacturePlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdManufacturePlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RegNumber});
            this.grdManufacturePlan.Location = new System.Drawing.Point(20, 67);
            this.grdManufacturePlan.Name = "grdManufacturePlan";
            this.grdManufacturePlan.RowTemplate.Height = 25;
            this.grdManufacturePlan.Size = new System.Drawing.Size(1029, 492);
            this.grdManufacturePlan.TabIndex = 0;
            this.grdManufacturePlan.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.GrdManufacturePlan_CellBeginEdit);
            this.grdManufacturePlan.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.GrdManufacturePlan_CellPainting);
            this.grdManufacturePlan.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.GrdManufacturePlan_CellValidating);
            // 
            // RegNumber
            // 
            this.RegNumber.HeaderText = "Registro";
            this.RegNumber.Name = "RegNumber";
            // 
            // btnCallCMSSupplie
            // 
            this.btnCallCMSSupplie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCallCMSSupplie.Location = new System.Drawing.Point(907, 584);
            this.btnCallCMSSupplie.Name = "btnCallCMSSupplie";
            this.btnCallCMSSupplie.Size = new System.Drawing.Size(142, 35);
            this.btnCallCMSSupplie.TabIndex = 1;
            this.btnCallCMSSupplie.Text = "Suministro CMS";
            this.btnCallCMSSupplie.UseVisualStyleBackColor = true;
            this.btnCallCMSSupplie.Click += new System.EventHandler(this.BtnCallCMSSupplie_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.Location = new System.Drawing.Point(316, 584);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(142, 35);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refrescar";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(65, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(543, 32);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Aislamientos - Mantenimiento a órdenes";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConnectionState
            // 
            this.lblConnectionState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConnectionState.AutoSize = true;
            this.lblConnectionState.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConnectionState.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblConnectionState.Location = new System.Drawing.Point(955, 566);
            this.lblConnectionState.MinimumSize = new System.Drawing.Size(87, 15);
            this.lblConnectionState.Name = "lblConnectionState";
            this.lblConnectionState.Size = new System.Drawing.Size(87, 15);
            this.lblConnectionState.TabIndex = 4;
            this.lblConnectionState.Text = "Conectado";
            this.lblConnectionState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAccept.Location = new System.Drawing.Point(759, 584);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(142, 35);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // picBoxSubTitleLine
            // 
            this.picBoxSubTitleLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxSubTitleLine.Image = ((System.Drawing.Image)(resources.GetObject("picBoxSubTitleLine.Image")));
            this.picBoxSubTitleLine.Location = new System.Drawing.Point(20, 54);
            this.picBoxSubTitleLine.Name = "picBoxSubTitleLine";
            this.picBoxSubTitleLine.Size = new System.Drawing.Size(1298, 5);
            this.picBoxSubTitleLine.TabIndex = 6;
            this.picBoxSubTitleLine.TabStop = false;
            // 
            // picBoxEnterpriseLogo
            // 
            this.picBoxEnterpriseLogo.Image = ((System.Drawing.Image)(resources.GetObject("picBoxEnterpriseLogo.Image")));
            this.picBoxEnterpriseLogo.Location = new System.Drawing.Point(20, 8);
            this.picBoxEnterpriseLogo.Name = "picBoxEnterpriseLogo";
            this.picBoxEnterpriseLogo.Size = new System.Drawing.Size(40, 40);
            this.picBoxEnterpriseLogo.TabIndex = 7;
            this.picBoxEnterpriseLogo.TabStop = false;
            // 
            // picBoxUserImage
            // 
            this.picBoxUserImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxUserImage.Image = global::ProlecGE.ControlPisoMX.Insulations.Forms.Properties.Resources.user_dark;
            this.picBoxUserImage.Location = new System.Drawing.Point(1278, 8);
            this.picBoxUserImage.Name = "picBoxUserImage";
            this.picBoxUserImage.Size = new System.Drawing.Size(40, 40);
            this.picBoxUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxUserImage.TabIndex = 8;
            this.picBoxUserImage.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Location = new System.Drawing.Point(1142, 8);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 40);
            this.lblUserName.TabIndex = 9;
            this.lblUserName.Text = "Daniela Pérez Gavilan García del campo";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grdMachines
            // 
            this.grdMachines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMachines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMachines.Location = new System.Drawing.Point(1055, 67);
            this.grdMachines.MultiSelect = false;
            this.grdMachines.Name = "grdMachines";
            this.grdMachines.RowTemplate.Height = 25;
            this.grdMachines.Size = new System.Drawing.Size(263, 492);
            this.grdMachines.TabIndex = 10;
            this.grdMachines.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.GrdMachines_CellPainting);
            this.grdMachines.SelectionChanged += new System.EventHandler(this.GrdMachines_SelectionChanged);
            // 
            // lblNormalColor
            // 
            this.lblNormalColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(194)))), ((int)(((byte)(42)))));
            this.lblNormalColor.Location = new System.Drawing.Point(3, 10);
            this.lblNormalColor.Name = "lblNormalColor";
            this.lblNormalColor.Size = new System.Drawing.Size(38, 15);
            this.lblNormalColor.TabIndex = 11;
            // 
            // lblNormal
            // 
            this.lblNormal.AutoSize = true;
            this.lblNormal.Location = new System.Drawing.Point(57, 10);
            this.lblNormal.Name = "lblNormal";
            this.lblNormal.Size = new System.Drawing.Size(48, 15);
            this.lblNormal.TabIndex = 12;
            this.lblNormal.Text = "Normal";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.lblLockedColor);
            this.panel1.Controls.Add(this.lblLocked);
            this.panel1.Controls.Add(this.lblCriticalColor);
            this.panel1.Controls.Add(this.lblCritical);
            this.panel1.Controls.Add(this.lblWarningColor);
            this.panel1.Controls.Add(this.lblWarning);
            this.panel1.Controls.Add(this.lblNormalColor);
            this.panel1.Controls.Add(this.lblNormal);
            this.panel1.Location = new System.Drawing.Point(1055, 566);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 79);
            this.panel1.TabIndex = 13;
            // 
            // lblLockedColor
            // 
            this.lblLockedColor.BackColor = System.Drawing.Color.Gray;
            this.lblLockedColor.Location = new System.Drawing.Point(128, 49);
            this.lblLockedColor.Name = "lblLockedColor";
            this.lblLockedColor.Size = new System.Drawing.Size(38, 15);
            this.lblLockedColor.TabIndex = 17;
            // 
            // lblLocked
            // 
            this.lblLocked.AutoSize = true;
            this.lblLocked.Location = new System.Drawing.Point(182, 49);
            this.lblLocked.Name = "lblLocked";
            this.lblLocked.Size = new System.Drawing.Size(67, 15);
            this.lblLocked.TabIndex = 18;
            this.lblLocked.Text = "Bloqueado";
            // 
            // lblCriticalColor
            // 
            this.lblCriticalColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.lblCriticalColor.Location = new System.Drawing.Point(3, 49);
            this.lblCriticalColor.Name = "lblCriticalColor";
            this.lblCriticalColor.Size = new System.Drawing.Size(38, 15);
            this.lblCriticalColor.TabIndex = 15;
            // 
            // lblCritical
            // 
            this.lblCritical.AutoSize = true;
            this.lblCritical.Location = new System.Drawing.Point(57, 49);
            this.lblCritical.Name = "lblCritical";
            this.lblCritical.Size = new System.Drawing.Size(42, 15);
            this.lblCritical.TabIndex = 16;
            this.lblCritical.Text = "Critico";
            // 
            // lblWarningColor
            // 
            this.lblWarningColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(33)))));
            this.lblWarningColor.Location = new System.Drawing.Point(128, 10);
            this.lblWarningColor.Name = "lblWarningColor";
            this.lblWarningColor.Size = new System.Drawing.Size(38, 15);
            this.lblWarningColor.TabIndex = 13;
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Location = new System.Drawing.Point(182, 10);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(70, 15);
            this.lblWarning.TabIndex = 14;
            this.lblWarning.Text = "Advertencia";
            // 
            // btnOrderInsert
            // 
            this.btnOrderInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOrderInsert.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOrderInsert.Location = new System.Drawing.Point(611, 584);
            this.btnOrderInsert.Name = "btnOrderInsert";
            this.btnOrderInsert.Size = new System.Drawing.Size(142, 35);
            this.btnOrderInsert.TabIndex = 14;
            this.btnOrderInsert.Text = "Insertar orden";
            this.btnOrderInsert.UseVisualStyleBackColor = true;
            this.btnOrderInsert.Click += new System.EventHandler(this.BtnOrderInsert_Click);
            // 
            // btnSuspend
            // 
            this.btnSuspend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSuspend.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSuspend.Location = new System.Drawing.Point(168, 584);
            this.btnSuspend.Name = "btnSuspend";
            this.btnSuspend.Size = new System.Drawing.Size(142, 35);
            this.btnSuspend.TabIndex = 15;
            this.btnSuspend.Text = "Suspender labores";
            this.btnSuspend.UseVisualStyleBackColor = true;
            this.btnSuspend.Click += new System.EventHandler(this.BtnSuspend_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExit.Location = new System.Drawing.Point(20, 584);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(142, 35);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // InsOrderMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 661);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSuspend);
            this.Controls.Add(this.btnOrderInsert);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdMachines);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picBoxUserImage);
            this.Controls.Add(this.picBoxEnterpriseLogo);
            this.Controls.Add(this.picBoxSubTitleLine);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblConnectionState);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCallCMSSupplie);
            this.Controls.Add(this.grdManufacturePlan);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "InsOrderMaintenance";
            this.Text = "Mantenimiento de órdenes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InsOrderMaintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdManufacturePlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSubTitleLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMachines)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView grdManufacturePlan;
        private Button btnCallCMSSupplie;
        private Button btnRefresh;
        private Label lblTitle;
        private DataGridViewTextBoxColumn RegNumber;
        private Label lblConnectionState;
        private Button btnAccept;
        private PictureBox picBoxSubTitleLine;
        private PictureBox picBoxEnterpriseLogo;
        private PictureBox picBoxUserImage;
        private Label lblUserName;
        private DataGridView grdMachines;
        private Label lblNormalColor;
        private Label lblNormal;
        private Panel panel1;
        private Label lblLockedColor;
        private Label lblLocked;
        private Label lblCriticalColor;
        private Label lblCritical;
        private Label lblWarningColor;
        private Label lblWarning;
        private Button btnOrderInsert;
        private Button btnSuspend;
        private Button btnExit;
    }
}