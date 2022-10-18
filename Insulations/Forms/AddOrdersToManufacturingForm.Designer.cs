namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    partial class AddOrdersToManufacturingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrdersToManufacturingForm));
            this.lblTitleSupplies = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblRecordTo = new System.Windows.Forms.Label();
            this.lblMachine = new System.Windows.Forms.Label();
            this.cmbMachines = new System.Windows.Forms.ComboBox();
            this.datePickerSupplies = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSetRecords = new System.Windows.Forms.TextBox();
            this.grOrders = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.picBoxSubTitleLine = new System.Windows.Forms.PictureBox();
            this.picBoxEnterpriseLogo = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.picBoxUserImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSubTitleLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitleSupplies
            // 
            this.lblTitleSupplies.AutoSize = true;
            this.lblTitleSupplies.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitleSupplies.Location = new System.Drawing.Point(66, 14);
            this.lblTitleSupplies.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleSupplies.Name = "lblTitleSupplies";
            this.lblTitleSupplies.Size = new System.Drawing.Size(328, 29);
            this.lblTitleSupplies.TabIndex = 0;
            this.lblTitleSupplies.Text = "Suministro de CMS modelo";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 72);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(44, 15);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Fecha:";
            // 
            // lblRecordTo
            // 
            this.lblRecordTo.AutoSize = true;
            this.lblRecordTo.Location = new System.Drawing.Point(412, 72);
            this.lblRecordTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecordTo.Name = "lblRecordTo";
            this.lblRecordTo.Size = new System.Drawing.Size(116, 15);
            this.lblRecordTo.TabIndex = 2;
            this.lblRecordTo.Text = "Registros a marcar:";
            // 
            // lblMachine
            // 
            this.lblMachine.AutoSize = true;
            this.lblMachine.Location = new System.Drawing.Point(20, 112);
            this.lblMachine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(57, 15);
            this.lblMachine.TabIndex = 3;
            this.lblMachine.Text = "Máquina:";
            // 
            // cmbMachines
            // 
            this.cmbMachines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachines.FormattingEnabled = true;
            this.cmbMachines.Location = new System.Drawing.Point(85, 108);
            this.cmbMachines.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbMachines.MaxDropDownItems = 5;
            this.cmbMachines.Name = "cmbMachines";
            this.cmbMachines.Size = new System.Drawing.Size(107, 23);
            this.cmbMachines.TabIndex = 2;
            this.cmbMachines.SelectedIndexChanged += new System.EventHandler(this.CmbMachines_SelectedIndexChanged);
            // 
            // datePickerSupplies
            // 
            this.datePickerSupplies.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerSupplies.Location = new System.Drawing.Point(85, 69);
            this.datePickerSupplies.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.datePickerSupplies.Name = "datePickerSupplies";
            this.datePickerSupplies.Size = new System.Drawing.Size(107, 21);
            this.datePickerSupplies.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(515, 106);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtSetRecords
            // 
            this.txtSetRecords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSetRecords.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSetRecords.Location = new System.Drawing.Point(536, 69);
            this.txtSetRecords.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSetRecords.Name = "txtSetRecords";
            this.txtSetRecords.Size = new System.Drawing.Size(54, 21);
            this.txtSetRecords.TabIndex = 1;
            this.txtSetRecords.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSetRecords_KeyPress);
            this.txtSetRecords.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtSetRecords_KeyUp);
            // 
            // grOrders
            // 
            this.grOrders.AllowUserToAddRows = false;
            this.grOrders.AllowUserToDeleteRows = false;
            this.grOrders.AllowUserToOrderColumns = true;
            this.grOrders.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grOrders.DefaultCellStyle = dataGridViewCellStyle4;
            this.grOrders.Location = new System.Drawing.Point(20, 148);
            this.grOrders.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grOrders.Name = "grOrders";
            this.grOrders.RowHeadersVisible = false;
            this.grOrders.RowHeadersWidth = 51;
            this.grOrders.RowTemplate.Height = 29;
            this.grOrders.Size = new System.Drawing.Size(570, 462);
            this.grOrders.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(515, 621);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 26);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Aceptar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(20, 621);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Salir";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // picBoxSubTitleLine
            // 
            this.picBoxSubTitleLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxSubTitleLine.Image = ((System.Drawing.Image)(resources.GetObject("picBoxSubTitleLine.Image")));
            this.picBoxSubTitleLine.Location = new System.Drawing.Point(20, 52);
            this.picBoxSubTitleLine.Name = "picBoxSubTitleLine";
            this.picBoxSubTitleLine.Size = new System.Drawing.Size(570, 5);
            this.picBoxSubTitleLine.TabIndex = 11;
            this.picBoxSubTitleLine.TabStop = false;
            // 
            // picBoxEnterpriseLogo
            // 
            this.picBoxEnterpriseLogo.Image = ((System.Drawing.Image)(resources.GetObject("picBoxEnterpriseLogo.Image")));
            this.picBoxEnterpriseLogo.Location = new System.Drawing.Point(20, 8);
            this.picBoxEnterpriseLogo.Name = "picBoxEnterpriseLogo";
            this.picBoxEnterpriseLogo.Size = new System.Drawing.Size(40, 40);
            this.picBoxEnterpriseLogo.TabIndex = 12;
            this.picBoxEnterpriseLogo.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Location = new System.Drawing.Point(414, 8);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 40);
            this.lblUserName.TabIndex = 44;
            this.lblUserName.Text = "Daniela Pérez Gavilan García del campo";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picBoxUserImage
            // 
            this.picBoxUserImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxUserImage.Image = global::ProlecGE.ControlPisoMX.Insulations.Forms.Properties.Resources.user;
            this.picBoxUserImage.Location = new System.Drawing.Point(550, 8);
            this.picBoxUserImage.Name = "picBoxUserImage";
            this.picBoxUserImage.Size = new System.Drawing.Size(40, 40);
            this.picBoxUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxUserImage.TabIndex = 43;
            this.picBoxUserImage.TabStop = false;
            // 
            // ManufacturingPlanSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 661);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picBoxUserImage);
            this.Controls.Add(this.picBoxEnterpriseLogo);
            this.Controls.Add(this.picBoxSubTitleLine);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grOrders);
            this.Controls.Add(this.txtSetRecords);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.datePickerSupplies);
            this.Controls.Add(this.cmbMachines);
            this.Controls.Add(this.lblMachine);
            this.Controls.Add(this.lblRecordTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTitleSupplies);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "ManufacturingPlanSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suministro de CMS modelo";
            this.Load += new System.EventHandler(this.AddOrdersToManufacturingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSubTitleLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblTitleSupplies;
        private Label lblDate;
        private Label lblRecordTo;
        private Label lblMachine;
        private ComboBox cmbMachines;
        private DateTimePicker datePickerSupplies;
        private Button btnSearch;
        private DataGridView grOrders;
        private TextBox txtSetRecords;
        private Button btnAdd;
        private Button btnClose;
        private PictureBox picBoxSubTitleLine;
        private PictureBox picBoxEnterpriseLogo;
        private Label lblUserName;
        private PictureBox picBoxUserImage;
    }
}