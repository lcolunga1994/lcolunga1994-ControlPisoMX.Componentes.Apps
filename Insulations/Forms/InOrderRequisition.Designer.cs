namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    partial class InOrderRequisition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InOrderRequisition));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.lblSlash = new System.Windows.Forms.Label();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblBatch = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQantity = new System.Windows.Forms.Label();
            this.lblMachine = new System.Windows.Forms.Label();
            this.cmbMachine = new System.Windows.Forms.ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.picBoxEnterpriseLogo = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.picBoxUserImage = new System.Windows.Forms.PictureBox();
            this.picBoxSubTitleLine = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSubTitleLine)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(58, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(368, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Requerimiento de aislamientos";
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOrder.Location = new System.Drawing.Point(20, 96);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(40, 15);
            this.lblOrder.TabIndex = 1;
            this.lblOrder.Text = "Orden";
            // 
            // txtOrder
            // 
            this.txtOrder.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrder.Location = new System.Drawing.Point(102, 93);
            this.txtOrder.MaxLength = 47;
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(100, 23);
            this.txtOrder.TabIndex = 2;
            // 
            // lblSlash
            // 
            this.lblSlash.AutoSize = true;
            this.lblSlash.Location = new System.Drawing.Point(218, 97);
            this.lblSlash.Name = "lblSlash";
            this.lblSlash.Size = new System.Drawing.Size(12, 15);
            this.lblSlash.TabIndex = 3;
            this.lblSlash.Text = "-";
            // 
            // txtBatch
            // 
            this.txtBatch.Location = new System.Drawing.Point(250, 93);
            this.txtBatch.MaxLength = 3;
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(100, 23);
            this.txtBatch.TabIndex = 4;
            this.txtBatch.Leave += new System.EventHandler(this.TxtBatch_Leave);
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItem.Location = new System.Drawing.Point(128, 75);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(49, 15);
            this.lblItem.TabIndex = 5;
            this.lblItem.Text = "Artículo";
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBatch.Location = new System.Drawing.Point(262, 73);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(73, 15);
            this.lblBatch.TabIndex = 6;
            this.lblBatch.Text = "Consecutivo";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(102, 134);
            this.txtQuantity.MaxLength = 1;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 23);
            this.txtQuantity.TabIndex = 8;
            // 
            // lblQantity
            // 
            this.lblQantity.AutoSize = true;
            this.lblQantity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblQantity.Location = new System.Drawing.Point(20, 139);
            this.lblQantity.Name = "lblQantity";
            this.lblQantity.Size = new System.Drawing.Size(55, 15);
            this.lblQantity.TabIndex = 7;
            this.lblQantity.Text = "Cantidad";
            // 
            // lblMachine
            // 
            this.lblMachine.AutoSize = true;
            this.lblMachine.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMachine.Location = new System.Drawing.Point(20, 182);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(54, 15);
            this.lblMachine.TabIndex = 9;
            this.lblMachine.Text = "Máquina";
            // 
            // cmbMachine
            // 
            this.cmbMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachine.Enabled = false;
            this.cmbMachine.FormattingEnabled = true;
            this.cmbMachine.Items.AddRange(new object[] {
            "REP"});
            this.cmbMachine.Location = new System.Drawing.Point(102, 178);
            this.cmbMachine.Name = "cmbMachine";
            this.cmbMachine.Size = new System.Drawing.Size(100, 23);
            this.cmbMachine.TabIndex = 10;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPriority.Location = new System.Drawing.Point(20, 225);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(55, 15);
            this.lblPriority.TabIndex = 11;
            this.lblPriority.Text = "Prioridad";
            // 
            // txtPriority
            // 
            this.txtPriority.Location = new System.Drawing.Point(102, 221);
            this.txtPriority.MaxLength = 3;
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(100, 23);
            this.txtPriority.TabIndex = 12;
            this.txtPriority.Text = "999";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(20, 260);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 35);
            this.btnAccept.TabIndex = 13;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(102, 260);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 35);
            this.btnClean.TabIndex = 14;
            this.btnClean.Text = "Limpiar";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.BtnClean_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(523, 260);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 35);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Salir";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // picBoxEnterpriseLogo
            // 
            this.picBoxEnterpriseLogo.Image = ((System.Drawing.Image)(resources.GetObject("picBoxEnterpriseLogo.Image")));
            this.picBoxEnterpriseLogo.Location = new System.Drawing.Point(20, 8);
            this.picBoxEnterpriseLogo.Name = "picBoxEnterpriseLogo";
            this.picBoxEnterpriseLogo.Size = new System.Drawing.Size(40, 40);
            this.picBoxEnterpriseLogo.TabIndex = 39;
            this.picBoxEnterpriseLogo.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Location = new System.Drawing.Point(422, 8);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 40);
            this.lblUserName.TabIndex = 42;
            this.lblUserName.Text = "Daniela Pérez Gavilan García del campo";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picBoxUserImage
            // 
            this.picBoxUserImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxUserImage.Image = global::ProlecGE.ControlPisoMX.Insulations.Forms.Properties.Resources.user;
            this.picBoxUserImage.Location = new System.Drawing.Point(558, 8);
            this.picBoxUserImage.Name = "picBoxUserImage";
            this.picBoxUserImage.Size = new System.Drawing.Size(40, 40);
            this.picBoxUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxUserImage.TabIndex = 41;
            this.picBoxUserImage.TabStop = false;
            // 
            // picBoxSubTitleLine
            // 
            this.picBoxSubTitleLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxSubTitleLine.Image = global::ProlecGE.ControlPisoMX.Insulations.Forms.Properties.Resources.title_line_white;
            this.picBoxSubTitleLine.Location = new System.Drawing.Point(20, 54);
            this.picBoxSubTitleLine.Name = "picBoxSubTitleLine";
            this.picBoxSubTitleLine.Size = new System.Drawing.Size(580, 5);
            this.picBoxSubTitleLine.TabIndex = 43;
            this.picBoxSubTitleLine.TabStop = false;
            // 
            // InOrderRequisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 304);
            this.Controls.Add(this.picBoxSubTitleLine);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picBoxUserImage);
            this.Controls.Add(this.picBoxEnterpriseLogo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtPriority);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.cmbMachine);
            this.Controls.Add(this.lblMachine);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblQantity);
            this.Controls.Add(this.lblBatch);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.txtBatch);
            this.Controls.Add(this.lblSlash);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.lblOrder);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "InOrderRequisition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Requerimiento de aislamientos";
            this.Load += new System.EventHandler(this.InOrderRequisition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSubTitleLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblTitle;
        private Label lblOrder;
        private TextBox txtOrder;
        private Label lblSlash;
        private TextBox txtBatch;
        private Label lblItem;
        private Label lblBatch;
        private TextBox txtQuantity;
        private Label lblQantity;
        private Label lblMachine;
        private ComboBox cmbMachine;
        private Label lblPriority;
        private TextBox txtPriority;
        private Button btnAccept;
        private Button btnClean;
        private Button btnClose;
        private PictureBox picBoxEnterpriseLogo;
        private Label lblUserName;
        private PictureBox picBoxUserImage;
        private PictureBox picBoxSubTitleLine;
    }
}