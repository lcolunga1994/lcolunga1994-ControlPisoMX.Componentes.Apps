namespace ProlecGE.ControlPisoMX.CoreSupply.Forms
{
    partial class OrderForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForms));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.lblBatch = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.lblOrder = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.picBoxUserImage = new System.Windows.Forms.PictureBox();
            this.picBoxEnterpriseLogo = new System.Windows.Forms.PictureBox();
            this.picBoxTitleLine = new System.Windows.Forms.PictureBox();
            this.lblTitleSupplies = new System.Windows.Forms.Label();
            this.grItems = new System.Windows.Forms.DataGridView();
            this.lblTotalOrder = new System.Windows.Forms.Label();
            this.lblTotalSupplied = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTitleLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grItems)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(20, 643);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Salir";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(549, 73);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 26);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Buscar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtBatch
            // 
            this.txtBatch.Location = new System.Drawing.Point(219, 76);
            this.txtBatch.MaxLength = 3;
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(100, 21);
            this.txtBatch.TabIndex = 3;
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.Location = new System.Drawing.Point(182, 79);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(31, 15);
            this.lblBatch.TabIndex = 2;
            this.lblBatch.Text = "Lote";
            // 
            // txtOrder
            // 
            this.txtOrder.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrder.Location = new System.Drawing.Point(76, 76);
            this.txtOrder.MaxLength = 47;
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(100, 21);
            this.txtOrder.TabIndex = 1;
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOrder.Location = new System.Drawing.Point(20, 79);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(47, 15);
            this.lblOrder.TabIndex = 0;
            this.lblOrder.Text = "Artículo";
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Location = new System.Drawing.Point(448, 11);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 40);
            this.lblUserName.TabIndex = 67;
            this.lblUserName.Text = "Daniela Pérez Gavilan García del campo";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picBoxUserImage
            // 
            this.picBoxUserImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxUserImage.Location = new System.Drawing.Point(584, 11);
            this.picBoxUserImage.Name = "picBoxUserImage";
            this.picBoxUserImage.Size = new System.Drawing.Size(40, 40);
            this.picBoxUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxUserImage.TabIndex = 66;
            this.picBoxUserImage.TabStop = false;
            // 
            // picBoxEnterpriseLogo
            // 
            this.picBoxEnterpriseLogo.Location = new System.Drawing.Point(20, 11);
            this.picBoxEnterpriseLogo.Name = "picBoxEnterpriseLogo";
            this.picBoxEnterpriseLogo.Size = new System.Drawing.Size(40, 40);
            this.picBoxEnterpriseLogo.TabIndex = 65;
            this.picBoxEnterpriseLogo.TabStop = false;
            // 
            // picBoxTitleLine
            // 
            this.picBoxTitleLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxTitleLine.Image = ((System.Drawing.Image)(resources.GetObject("picBoxTitleLine.Image")));
            this.picBoxTitleLine.Location = new System.Drawing.Point(20, 55);
            this.picBoxTitleLine.Name = "picBoxTitleLine";
            this.picBoxTitleLine.Size = new System.Drawing.Size(604, 5);
            this.picBoxTitleLine.TabIndex = 64;
            this.picBoxTitleLine.TabStop = false;
            // 
            // lblTitleSupplies
            // 
            this.lblTitleSupplies.AutoSize = true;
            this.lblTitleSupplies.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitleSupplies.Location = new System.Drawing.Point(69, 17);
            this.lblTitleSupplies.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleSupplies.Name = "lblTitleSupplies";
            this.lblTitleSupplies.Size = new System.Drawing.Size(207, 29);
            this.lblTitleSupplies.TabIndex = 63;
            this.lblTitleSupplies.Text = "Órdenes pedidas";
            // 
            // grItems
            // 
            this.grItems.AllowUserToAddRows = false;
            this.grItems.AllowUserToDeleteRows = false;
            this.grItems.AllowUserToOrderColumns = true;
            this.grItems.AllowUserToResizeRows = false;
            this.grItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grItems.Location = new System.Drawing.Point(20, 115);
            this.grItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grItems.Name = "grItems";
            this.grItems.RowHeadersVisible = false;
            this.grItems.RowHeadersWidth = 51;
            this.grItems.RowTemplate.Height = 29;
            this.grItems.Size = new System.Drawing.Size(476, 513);
            this.grItems.TabIndex = 5;
            // 
            // lblTotalOrder
            // 
            this.lblTotalOrder.Location = new System.Drawing.Point(503, 115);
            this.lblTotalOrder.Name = "lblTotalOrder";
            this.lblTotalOrder.Size = new System.Drawing.Size(121, 15);
            this.lblTotalOrder.TabIndex = 69;
            this.lblTotalOrder.Text = "Total Orden: 1000";
            // 
            // lblTotalSupplied
            // 
            this.lblTotalSupplied.Location = new System.Drawing.Point(503, 139);
            this.lblTotalSupplied.Name = "lblTotalSupplied";
            this.lblTotalSupplied.Size = new System.Drawing.Size(121, 15);
            this.lblTotalSupplied.TabIndex = 69;
            this.lblTotalSupplied.Text = "Total pedido: 1000";
            // 
            // lblPending
            // 
            this.lblPending.Location = new System.Drawing.Point(503, 163);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(121, 15);
            this.lblPending.TabIndex = 69;
            this.lblPending.Text = "Pendiente: 1000";
            // 
            // OrderForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 681);
            this.Controls.Add(this.grItems);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtBatch);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.lblTotalSupplied);
            this.Controls.Add(this.lblTotalOrder);
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
            this.Name = "OrderForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Órdenes pedidas";
            this.Load += new System.EventHandler(this.OrderForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTitleLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnClose;
        private Button btnAccept;
        private TextBox txtBatch;
        private Label lblBatch;
        private TextBox txtOrder;
        private Label lblOrder;
        private Label lblUserName;
        private PictureBox picBoxUserImage;
        private PictureBox picBoxEnterpriseLogo;
        private PictureBox picBoxTitleLine;
        private Label lblTitleSupplies;
        private DataGridView grItems;
        private Label lblTotalOrder;
        private Label lblTotalSupplied;
        private Label lblPending;
    }
}