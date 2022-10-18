namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    partial class ManualCartonShears
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualCartonShears));
            this.grItems = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblConnectionMessage = new System.Windows.Forms.Label();
            this.lblLodingItems = new System.Windows.Forms.Label();
            this.lblNoOrder = new System.Windows.Forms.Label();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.lblQuantityValue = new System.Windows.Forms.Label();
            this.lblItemValue = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.picBoxEnterpriseLogo = new System.Windows.Forms.PictureBox();
            this.picBoxSubTitleLine = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.picBoxUserImage = new System.Windows.Forms.PictureBox();
            this.grcItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcDimensions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcCuna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grItems)).BeginInit();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSubTitleLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).BeginInit();
            this.SuspendLayout();
            // 
            // grItems
            // 
            this.grItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcItem,
            this.grcDescription,
            this.grcQuantity,
            this.grcDimensions,
            this.grcCuna});
            this.grItems.Location = new System.Drawing.Point(20, 129);
            this.grItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grItems.MinimumSize = new System.Drawing.Size(0, 92);
            this.grItems.Name = "grItems";
            this.grItems.ReadOnly = true;
            this.grItems.Size = new System.Drawing.Size(1300, 510);
            this.grItems.TabIndex = 0;
            this.grItems.Resize += new System.EventHandler(this.GrItems_Resize);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(70, 12);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(438, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "AISLAMIENTOS - Cizalla manual";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConnectionMessage
            // 
            this.lblConnectionMessage.AutoSize = true;
            this.lblConnectionMessage.Location = new System.Drawing.Point(745, 642);
            this.lblConnectionMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnectionMessage.Name = "lblConnectionMessage";
            this.lblConnectionMessage.Size = new System.Drawing.Size(165, 15);
            this.lblConnectionMessage.TabIndex = 8;
            this.lblConnectionMessage.Text = "Conectando con el servidor...";
            this.lblConnectionMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLodingItems
            // 
            this.lblLodingItems.AutoSize = true;
            this.lblLodingItems.Location = new System.Drawing.Point(565, 642);
            this.lblLodingItems.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLodingItems.Name = "lblLodingItems";
            this.lblLodingItems.Size = new System.Drawing.Size(155, 15);
            this.lblLodingItems.TabIndex = 9;
            this.lblLodingItems.Text = "Consultando información...";
            this.lblLodingItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLodingItems.Visible = false;
            // 
            // lblNoOrder
            // 
            this.lblNoOrder.AutoSize = true;
            this.lblNoOrder.Location = new System.Drawing.Point(361, 642);
            this.lblNoOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoOrder.Name = "lblNoOrder";
            this.lblNoOrder.Size = new System.Drawing.Size(175, 15);
            this.lblNoOrder.TabIndex = 10;
            this.lblNoOrder.Text = "No hay unidades por procesar.";
            this.lblNoOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlOrder
            // 
            this.pnlOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOrder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlOrder.Controls.Add(this.lblQuantityValue);
            this.pnlOrder.Controls.Add(this.lblItemValue);
            this.pnlOrder.Controls.Add(this.lblOrder);
            this.pnlOrder.Controls.Add(this.lblQuantity);
            this.pnlOrder.Location = new System.Drawing.Point(20, 69);
            this.pnlOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(1300, 48);
            this.pnlOrder.TabIndex = 21;
            // 
            // lblQuantityValue
            // 
            this.lblQuantityValue.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblQuantityValue.Location = new System.Drawing.Point(452, 6);
            this.lblQuantityValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantityValue.MinimumSize = new System.Drawing.Size(52, 32);
            this.lblQuantityValue.Name = "lblQuantityValue";
            this.lblQuantityValue.Size = new System.Drawing.Size(52, 37);
            this.lblQuantityValue.TabIndex = 24;
            this.lblQuantityValue.Text = "2";
            this.lblQuantityValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemValue
            // 
            this.lblItemValue.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblItemValue.Location = new System.Drawing.Point(99, 6);
            this.lblItemValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemValue.Name = "lblItemValue";
            this.lblItemValue.Size = new System.Drawing.Size(210, 37);
            this.lblItemValue.TabIndex = 23;
            this.lblItemValue.Text = "DCN604-446";
            this.lblItemValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrder
            // 
            this.lblOrder.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOrder.Location = new System.Drawing.Point(4, 6);
            this.lblOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(87, 37);
            this.lblOrder.TabIndex = 21;
            this.lblOrder.Text = "Orden:";
            this.lblOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblQuantity.Location = new System.Drawing.Point(328, 6);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(116, 37);
            this.lblQuantity.TabIndex = 22;
            this.lblQuantity.Text = "Cantidad:";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picBoxEnterpriseLogo
            // 
            this.picBoxEnterpriseLogo.Image = ((System.Drawing.Image)(resources.GetObject("picBoxEnterpriseLogo.Image")));
            this.picBoxEnterpriseLogo.Location = new System.Drawing.Point(20, 8);
            this.picBoxEnterpriseLogo.Name = "picBoxEnterpriseLogo";
            this.picBoxEnterpriseLogo.Size = new System.Drawing.Size(40, 40);
            this.picBoxEnterpriseLogo.TabIndex = 22;
            this.picBoxEnterpriseLogo.TabStop = false;
            // 
            // picBoxSubTitleLine
            // 
            this.picBoxSubTitleLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxSubTitleLine.Image = ((System.Drawing.Image)(resources.GetObject("picBoxSubTitleLine.Image")));
            this.picBoxSubTitleLine.Location = new System.Drawing.Point(20, 54);
            this.picBoxSubTitleLine.Name = "picBoxSubTitleLine";
            this.picBoxSubTitleLine.Size = new System.Drawing.Size(1300, 5);
            this.picBoxSubTitleLine.TabIndex = 23;
            this.picBoxSubTitleLine.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Location = new System.Drawing.Point(1144, 8);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 40);
            this.lblUserName.TabIndex = 40;
            this.lblUserName.Text = "Daniela Pérez Gavilan García del campo";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picBoxUserImage
            // 
            this.picBoxUserImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxUserImage.Image = global::ProlecGE.ControlPisoMX.Insulations.Forms.Properties.Resources.user_dark;
            this.picBoxUserImage.Location = new System.Drawing.Point(1280, 8);
            this.picBoxUserImage.Name = "picBoxUserImage";
            this.picBoxUserImage.Size = new System.Drawing.Size(40, 40);
            this.picBoxUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxUserImage.TabIndex = 39;
            this.picBoxUserImage.TabStop = false;
            // 
            // grcItem
            // 
            this.grcItem.HeaderText = "ARTÍCULO";
            this.grcItem.Name = "grcItem";
            this.grcItem.ReadOnly = true;
            this.grcItem.Width = 200;
            // 
            // grcDescription
            // 
            this.grcDescription.HeaderText = "DESCRIPCIÓN";
            this.grcDescription.MinimumWidth = 500;
            this.grcDescription.Name = "grcDescription";
            this.grcDescription.ReadOnly = true;
            this.grcDescription.Width = 500;
            // 
            // grcQuantity
            // 
            this.grcQuantity.HeaderText = "CANTIDAD";
            this.grcQuantity.Name = "grcQuantity";
            this.grcQuantity.ReadOnly = true;
            // 
            // grcDimensions
            // 
            this.grcDimensions.HeaderText = "DIMENSIONES";
            this.grcDimensions.MinimumWidth = 300;
            this.grcDimensions.Name = "grcDimensions";
            this.grcDimensions.ReadOnly = true;
            this.grcDimensions.Width = 300;
            // 
            // grcCuna
            // 
            this.grcCuna.HeaderText = "";
            this.grcCuna.Name = "grcCuna";
            this.grcCuna.ReadOnly = true;
            this.grcCuna.Width = 150;
            // 
            // ManualCartonShears
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 661);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picBoxUserImage);
            this.Controls.Add(this.picBoxSubTitleLine);
            this.Controls.Add(this.picBoxEnterpriseLogo);
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.lblNoOrder);
            this.Controls.Add(this.lblLodingItems);
            this.Controls.Add(this.lblConnectionMessage);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grItems);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ManualCartonShears";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aislamientos - Cizalla Manual";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ManualCartonShears_Load);
            this.Resize += new System.EventHandler(this.ManualCartonShears_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grItems)).EndInit();
            this.pnlOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSubTitleLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grItems;
        private System.Windows.Forms.Label lblTitle;
        private Label lblConnectionMessage;
        private Label lblLodingItems;
        private Label lblNoOrder;
        private Panel pnlOrder;
        private Label lblQuantityValue;
        private Label lblItemValue;
        private Label lblOrder;
        private Label lblQuantity;
        private PictureBox picBoxEnterpriseLogo;
        private PictureBox picBoxSubTitleLine;
        private Label lblUserName;
        private PictureBox picBoxUserImage;
        private DataGridViewTextBoxColumn grcItem;
        private DataGridViewTextBoxColumn grcDescription;
        private DataGridViewTextBoxColumn grcQuantity;
        private DataGridViewTextBoxColumn grcDimensions;
        private DataGridViewTextBoxColumn grcCuna;
    }
}