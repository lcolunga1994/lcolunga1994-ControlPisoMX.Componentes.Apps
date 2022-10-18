namespace ProlecGE.ControlPisoMX.CoreSupply.Forms
{
    partial class ManufacturingStatusForm
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.picBoxUserImage = new System.Windows.Forms.PictureBox();
            this.picBoxEnterpriseLogo = new System.Windows.Forms.PictureBox();
            this.picBoxTitleLine = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grOrders = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbMachines = new System.Windows.Forms.ComboBox();
            this.lblMachine = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitleSupplies = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTitleLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Location = new System.Drawing.Point(588, 11);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 40);
            this.lblUserName.TabIndex = 59;
            this.lblUserName.Text = "Daniela Pérez Gavilan García del campo";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picBoxUserImage
            // 
            this.picBoxUserImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxUserImage.Location = new System.Drawing.Point(724, 11);
            this.picBoxUserImage.Name = "picBoxUserImage";
            this.picBoxUserImage.Size = new System.Drawing.Size(40, 40);
            this.picBoxUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxUserImage.TabIndex = 58;
            this.picBoxUserImage.TabStop = false;
            // 
            // picBoxEnterpriseLogo
            // 
            this.picBoxEnterpriseLogo.Location = new System.Drawing.Point(20, 11);
            this.picBoxEnterpriseLogo.Name = "picBoxEnterpriseLogo";
            this.picBoxEnterpriseLogo.Size = new System.Drawing.Size(40, 40);
            this.picBoxEnterpriseLogo.TabIndex = 57;
            this.picBoxEnterpriseLogo.TabStop = false;
            // 
            // picBoxTitleLine
            // 
            this.picBoxTitleLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxTitleLine.Location = new System.Drawing.Point(20, 55);
            this.picBoxTitleLine.Name = "picBoxTitleLine";
            this.picBoxTitleLine.Size = new System.Drawing.Size(744, 5);
            this.picBoxTitleLine.TabIndex = 56;
            this.picBoxTitleLine.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(20, 594);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Salir";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.Location = new System.Drawing.Point(103, 594);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 26);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Suministrar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // grOrders
            // 
            this.grOrders.AllowUserToAddRows = false;
            this.grOrders.AllowUserToDeleteRows = false;
            this.grOrders.AllowUserToOrderColumns = true;
            this.grOrders.AllowUserToResizeRows = false;
            this.grOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grOrders.Location = new System.Drawing.Point(20, 116);
            this.grOrders.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grOrders.Name = "grOrders";
            this.grOrders.RowHeadersVisible = false;
            this.grOrders.RowHeadersWidth = 51;
            this.grOrders.RowTemplate.Height = 29;
            this.grOrders.Size = new System.Drawing.Size(744, 462);
            this.grOrders.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(689, 75);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // dpDate
            // 
            this.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDate.Location = new System.Drawing.Point(69, 77);
            this.dpDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dpDate.Name = "dpDate";
            this.dpDate.Size = new System.Drawing.Size(107, 21);
            this.dpDate.TabIndex = 0;
            // 
            // cmbMachines
            // 
            this.cmbMachines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachines.FormattingEnabled = true;
            this.cmbMachines.Location = new System.Drawing.Point(323, 77);
            this.cmbMachines.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbMachines.MaxDropDownItems = 5;
            this.cmbMachines.Name = "cmbMachines";
            this.cmbMachines.Size = new System.Drawing.Size(107, 23);
            this.cmbMachines.TabIndex = 1;
            this.cmbMachines.SelectedIndexChanged += new System.EventHandler(this.CmbMachines_SelectedIndexChanged);
            // 
            // lblMachine
            // 
            this.lblMachine.AutoSize = true;
            this.lblMachine.Location = new System.Drawing.Point(258, 81);
            this.lblMachine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(57, 15);
            this.lblMachine.TabIndex = 52;
            this.lblMachine.Text = "Máquina:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 81);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(44, 15);
            this.lblDate.TabIndex = 48;
            this.lblDate.Text = "Fecha:";
            // 
            // lblTitleSupplies
            // 
            this.lblTitleSupplies.AutoSize = true;
            this.lblTitleSupplies.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitleSupplies.Location = new System.Drawing.Point(66, 17);
            this.lblTitleSupplies.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleSupplies.Name = "lblTitleSupplies";
            this.lblTitleSupplies.Size = new System.Drawing.Size(272, 29);
            this.lblTitleSupplies.TabIndex = 46;
            this.lblTitleSupplies.Text = "Suministro de núcleos";
            // 
            // ManufacturingStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 641);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picBoxUserImage);
            this.Controls.Add(this.picBoxEnterpriseLogo);
            this.Controls.Add(this.picBoxTitleLine);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grOrders);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dpDate);
            this.Controls.Add(this.cmbMachines);
            this.Controls.Add(this.lblMachine);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTitleSupplies);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ManufacturingStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suministro de núcleos";
            this.Load += new System.EventHandler(this.OnSupplyForm_Load);
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
        private Button btnClose;
        private Button btnAdd;
        private DataGridView grOrders;
        private Button btnSearch;
        private DateTimePicker dpDate;
        private ComboBox cmbMachines;
        private Label lblMachine;
        private Label lblDate;
        private Label lblTitleSupplies;
    }
}