namespace ProlecGE.ControlPisoMX.CoreSupply.Forms
{
    partial class PrintInsulationTagForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintInsulationTagForm));
            this.lblUserName = new System.Windows.Forms.Label();
            this.picBoxUserImage = new System.Windows.Forms.PictureBox();
            this.picBoxEnterpriseLogo = new System.Windows.Forms.PictureBox();
            this.lblTitleSupplies = new System.Windows.Forms.Label();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.lblBatch = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.lblOrder = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.lblSerie = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.picBoxTitleLine = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTitleLine)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Location = new System.Drawing.Point(425, 10);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 40);
            this.lblUserName.TabIndex = 49;
            this.lblUserName.Text = "Daniela Pérez Gavilan García del campo";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picBoxUserImage
            // 
            this.picBoxUserImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxUserImage.Location = new System.Drawing.Point(561, 10);
            this.picBoxUserImage.Name = "picBoxUserImage";
            this.picBoxUserImage.Size = new System.Drawing.Size(40, 40);
            this.picBoxUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxUserImage.TabIndex = 48;
            this.picBoxUserImage.TabStop = false;
            // 
            // picBoxEnterpriseLogo
            // 
            this.picBoxEnterpriseLogo.Location = new System.Drawing.Point(20, 10);
            this.picBoxEnterpriseLogo.Name = "picBoxEnterpriseLogo";
            this.picBoxEnterpriseLogo.Size = new System.Drawing.Size(40, 40);
            this.picBoxEnterpriseLogo.TabIndex = 47;
            this.picBoxEnterpriseLogo.TabStop = false;
            // 
            // lblTitleSupplies
            // 
            this.lblTitleSupplies.AutoSize = true;
            this.lblTitleSupplies.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitleSupplies.Location = new System.Drawing.Point(66, 16);
            this.lblTitleSupplies.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleSupplies.Name = "lblTitleSupplies";
            this.lblTitleSupplies.Size = new System.Drawing.Size(345, 29);
            this.lblTitleSupplies.TabIndex = 45;
            this.lblTitleSupplies.Text = "Reimpresión de aislamientos";
            // 
            // txtBatch
            // 
            this.txtBatch.Location = new System.Drawing.Point(301, 69);
            this.txtBatch.MaxLength = 3;
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(100, 21);
            this.txtBatch.TabIndex = 1;
            this.txtBatch.Leave += new System.EventHandler(this.TxtBatch_Leave);
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.Location = new System.Drawing.Point(243, 73);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(31, 15);
            this.lblBatch.TabIndex = 52;
            this.lblBatch.Text = "Lote";
            // 
            // txtOrder
            // 
            this.txtOrder.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrder.Location = new System.Drawing.Point(98, 69);
            this.txtOrder.MaxLength = 47;
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(100, 21);
            this.txtOrder.TabIndex = 0;
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOrder.Location = new System.Drawing.Point(21, 73);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(47, 15);
            this.lblOrder.TabIndex = 50;
            this.lblOrder.Text = "Artículo";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(501, 69);
            this.txtSerie.MaxLength = 0;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(100, 21);
            this.txtSerie.TabIndex = 2;
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(441, 73);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(36, 15);
            this.lblSerie.TabIndex = 54;
            this.lblSerie.Text = "Serie";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(301, 104);
            this.txtPassword.MaxLength = 100;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 21);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.Location = new System.Drawing.Point(206, 107);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 15);
            this.lblPassword.TabIndex = 56;
            this.lblPassword.Text = "Contraseña";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(101, 139);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 26);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Imprimir";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // picBoxTitleLine
            // 
            this.picBoxTitleLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxTitleLine.Image = ((System.Drawing.Image)(resources.GetObject("picBoxTitleLine.Image")));
            this.picBoxTitleLine.Location = new System.Drawing.Point(20, 55);
            this.picBoxTitleLine.Name = "picBoxTitleLine";
            this.picBoxTitleLine.Size = new System.Drawing.Size(581, 5);
            this.picBoxTitleLine.TabIndex = 46;
            this.picBoxTitleLine.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(20, 139);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Salir";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // PrintInsulationTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 177);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.lblSerie);
            this.Controls.Add(this.txtBatch);
            this.Controls.Add(this.lblBatch);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.lblOrder);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picBoxUserImage);
            this.Controls.Add(this.picBoxEnterpriseLogo);
            this.Controls.Add(this.picBoxTitleLine);
            this.Controls.Add(this.lblTitleSupplies);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PrintInsulationTagForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reimpresión de aislamientos";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTitleLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblUserName;
        private PictureBox picBoxUserImage;
        private PictureBox picBoxEnterpriseLogo;
        private Label lblTitleSupplies;
        private TextBox txtBatch;
        private Label lblBatch;
        private TextBox txtOrder;
        private Label lblOrder;
        private TextBox txtSerie;
        private Label lblSerie;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnAccept;
        private PictureBox picBoxTitleLine;
        private Button btnClose;
    }
}