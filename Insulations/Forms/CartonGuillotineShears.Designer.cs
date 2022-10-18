
namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    partial class CartonGuillotineShears
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartonGuillotineShears));
            this.lblTitle = new System.Windows.Forms.Label();
            this.grGuillotine = new System.Windows.Forms.DataGridView();
            this.grcItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcDimensions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcDoblez = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLodingItems = new System.Windows.Forms.Label();
            this.lblConnectionMessage = new System.Windows.Forms.Label();
            this.lblNoOrder = new System.Windows.Forms.Label();
            this.tlpItems = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSierra = new System.Windows.Forms.Panel();
            this.pnlSubtitle = new System.Windows.Forms.Panel();
            this.lblSierra = new System.Windows.Forms.Label();
            this.grSierra = new System.Windows.Forms.DataGridView();
            this.grcSierraItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grSierraDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcSierraQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcSierraDimensions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grSierraDoblez = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.lblQuantityValue = new System.Windows.Forms.Label();
            this.lblItemValue = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.picBoxEnterpriseLogo = new System.Windows.Forms.PictureBox();
            this.picBoxSubTitleLine = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.picBoxUserImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grGuillotine)).BeginInit();
            this.tlpItems.SuspendLayout();
            this.pnlSierra.SuspendLayout();
            this.pnlSubtitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grSierra)).BeginInit();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSubTitleLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(67, 12);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(516, 32);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "AISLAMIENTOS - Guillotina #1 y sierra";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grGuillotine
            // 
            this.grGuillotine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grGuillotine.ColumnHeadersHeight = 29;
            this.grGuillotine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcItem,
            this.grcDescription,
            this.grcQuantity,
            this.grcDimensions,
            this.grcDoblez});
            this.grGuillotine.EnableHeadersVisualStyles = false;
            this.grGuillotine.Location = new System.Drawing.Point(4, 3);
            this.grGuillotine.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grGuillotine.MaximumSize = new System.Drawing.Size(0, 244);
            this.grGuillotine.MinimumSize = new System.Drawing.Size(0, 92);
            this.grGuillotine.Name = "grGuillotine";
            this.grGuillotine.ReadOnly = true;
            this.grGuillotine.RowHeadersWidth = 51;
            this.grGuillotine.Size = new System.Drawing.Size(1292, 180);
            this.grGuillotine.TabIndex = 8;
            // 
            // grcItem
            // 
            this.grcItem.HeaderText = "ARTÍCULO";
            this.grcItem.Name = "grcItem";
            this.grcItem.ReadOnly = true;
            // 
            // grcDescription
            // 
            this.grcDescription.HeaderText = "DESCRIPCIÓN";
            this.grcDescription.MinimumWidth = 400;
            this.grcDescription.Name = "grcDescription";
            this.grcDescription.ReadOnly = true;
            this.grcDescription.Width = 400;
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
            this.grcDimensions.MinimumWidth = 250;
            this.grcDimensions.Name = "grcDimensions";
            this.grcDimensions.ReadOnly = true;
            this.grcDimensions.Width = 300;
            // 
            // grcDoblez
            // 
            this.grcDoblez.HeaderText = "DOBLEZ";
            this.grcDoblez.Name = "grcDoblez";
            this.grcDoblez.ReadOnly = true;
            // 
            // lblLodingItems
            // 
            this.lblLodingItems.AutoSize = true;
            this.lblLodingItems.Location = new System.Drawing.Point(359, 643);
            this.lblLodingItems.Name = "lblLodingItems";
            this.lblLodingItems.Size = new System.Drawing.Size(285, 15);
            this.lblLodingItems.TabIndex = 17;
            this.lblLodingItems.Text = "lblLoadingItems. Se ajusta en tiempo de ejecución";
            this.lblLodingItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLodingItems.Visible = false;
            // 
            // lblConnectionMessage
            // 
            this.lblConnectionMessage.AutoSize = true;
            this.lblConnectionMessage.Location = new System.Drawing.Point(30, 643);
            this.lblConnectionMessage.Name = "lblConnectionMessage";
            this.lblConnectionMessage.Size = new System.Drawing.Size(323, 15);
            this.lblConnectionMessage.TabIndex = 16;
            this.lblConnectionMessage.Text = "lblConnectionMessage. Se ajusta en tiempo de ejecución";
            this.lblConnectionMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoOrder
            // 
            this.lblNoOrder.AutoSize = true;
            this.lblNoOrder.Location = new System.Drawing.Point(666, 643);
            this.lblNoOrder.Name = "lblNoOrder";
            this.lblNoOrder.Size = new System.Drawing.Size(255, 15);
            this.lblNoOrder.TabIndex = 18;
            this.lblNoOrder.Text = "lblNoOrder. Se ajusta en tiempo de ejecución";
            // 
            // tlpItems
            // 
            this.tlpItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tlpItems.ColumnCount = 1;
            this.tlpItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpItems.Controls.Add(this.grGuillotine, 0, 0);
            this.tlpItems.Controls.Add(this.pnlSierra, 0, 1);
            this.tlpItems.Location = new System.Drawing.Point(20, 115);
            this.tlpItems.Name = "tlpItems";
            this.tlpItems.RowCount = 2;
            this.tlpItems.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpItems.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpItems.Size = new System.Drawing.Size(1300, 525);
            this.tlpItems.TabIndex = 19;
            this.tlpItems.Resize += new System.EventHandler(this.TlpItems_Resize);
            // 
            // pnlSierra
            // 
            this.pnlSierra.AutoSize = true;
            this.pnlSierra.Controls.Add(this.pnlSubtitle);
            this.pnlSierra.Controls.Add(this.grSierra);
            this.pnlSierra.Location = new System.Drawing.Point(3, 189);
            this.pnlSierra.Name = "pnlSierra";
            this.pnlSierra.Size = new System.Drawing.Size(1294, 356);
            this.pnlSierra.TabIndex = 10;
            // 
            // pnlSubtitle
            // 
            this.pnlSubtitle.Controls.Add(this.lblSierra);
            this.pnlSubtitle.Location = new System.Drawing.Point(0, 0);
            this.pnlSubtitle.Name = "pnlSubtitle";
            this.pnlSubtitle.Size = new System.Drawing.Size(1292, 37);
            this.pnlSubtitle.TabIndex = 11;
            // 
            // lblSierra
            // 
            this.lblSierra.AutoSize = true;
            this.lblSierra.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSierra.Location = new System.Drawing.Point(467, 2);
            this.lblSierra.Name = "lblSierra";
            this.lblSierra.Size = new System.Drawing.Size(354, 32);
            this.lblSierra.TabIndex = 10;
            this.lblSierra.Text = "Información para la sierra";
            this.lblSierra.Visible = false;
            // 
            // grSierra
            // 
            this.grSierra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grSierra.ColumnHeadersHeight = 29;
            this.grSierra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grSierra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcSierraItem,
            this.grSierraDescription,
            this.grcSierraQuantity,
            this.grcSierraDimensions,
            this.grSierraDoblez});
            this.grSierra.Location = new System.Drawing.Point(0, 37);
            this.grSierra.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grSierra.MinimumSize = new System.Drawing.Size(0, 92);
            this.grSierra.Name = "grSierra";
            this.grSierra.ReadOnly = true;
            this.grSierra.Size = new System.Drawing.Size(1294, 293);
            this.grSierra.TabIndex = 9;
            // 
            // grcSierraItem
            // 
            this.grcSierraItem.HeaderText = "ARTÍCULO";
            this.grcSierraItem.Name = "grcSierraItem";
            this.grcSierraItem.ReadOnly = true;
            // 
            // grSierraDescription
            // 
            this.grSierraDescription.HeaderText = "DESCRIPCIÓN";
            this.grSierraDescription.MinimumWidth = 400;
            this.grSierraDescription.Name = "grSierraDescription";
            this.grSierraDescription.ReadOnly = true;
            this.grSierraDescription.Width = 400;
            // 
            // grcSierraQuantity
            // 
            this.grcSierraQuantity.HeaderText = "CANTIDAD";
            this.grcSierraQuantity.Name = "grcSierraQuantity";
            this.grcSierraQuantity.ReadOnly = true;
            // 
            // grcSierraDimensions
            // 
            this.grcSierraDimensions.HeaderText = "DIMENSIONES";
            this.grcSierraDimensions.MinimumWidth = 250;
            this.grcSierraDimensions.Name = "grcSierraDimensions";
            this.grcSierraDimensions.ReadOnly = true;
            this.grcSierraDimensions.Width = 300;
            // 
            // grSierraDoblez
            // 
            this.grSierraDoblez.HeaderText = "DOBLEZ";
            this.grSierraDoblez.Name = "grSierraDoblez";
            this.grSierraDoblez.ReadOnly = true;
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
            this.pnlOrder.Location = new System.Drawing.Point(20, 64);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(1300, 48);
            this.pnlOrder.TabIndex = 20;
            // 
            // lblQuantityValue
            // 
            this.lblQuantityValue.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblQuantityValue.Location = new System.Drawing.Point(450, 7);
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
            this.lblItemValue.Location = new System.Drawing.Point(98, 7);
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
            this.lblOrder.Location = new System.Drawing.Point(4, 7);
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
            this.lblQuantity.Location = new System.Drawing.Point(328, 7);
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
            this.picBoxEnterpriseLogo.TabIndex = 21;
            this.picBoxEnterpriseLogo.TabStop = false;
            // 
            // picBoxSubTitleLine
            // 
            this.picBoxSubTitleLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxSubTitleLine.Image = ((System.Drawing.Image)(resources.GetObject("picBoxSubTitleLine.Image")));
            this.picBoxSubTitleLine.Location = new System.Drawing.Point(20, 53);
            this.picBoxSubTitleLine.Name = "picBoxSubTitleLine";
            this.picBoxSubTitleLine.Size = new System.Drawing.Size(1300, 5);
            this.picBoxSubTitleLine.TabIndex = 22;
            this.picBoxSubTitleLine.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Location = new System.Drawing.Point(1144, 8);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 40);
            this.lblUserName.TabIndex = 44;
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
            this.picBoxUserImage.TabIndex = 43;
            this.picBoxUserImage.TabStop = false;
            // 
            // CartonGuillotineShears
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 661);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picBoxUserImage);
            this.Controls.Add(this.picBoxSubTitleLine);
            this.Controls.Add(this.picBoxEnterpriseLogo);
            this.Controls.Add(this.lblNoOrder);
            this.Controls.Add(this.lblConnectionMessage);
            this.Controls.Add(this.lblLodingItems);
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.tlpItems);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "CartonGuillotineShears";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guillotina #1 y sierra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CartonGuillotineShears_Load);
            this.Resize += new System.EventHandler(this.ManualCartonShears_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grGuillotine)).EndInit();
            this.tlpItems.ResumeLayout(false);
            this.tlpItems.PerformLayout();
            this.pnlSierra.ResumeLayout(false);
            this.pnlSubtitle.ResumeLayout(false);
            this.pnlSubtitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grSierra)).EndInit();
            this.pnlOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSubTitleLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView grGuillotine;
        private Label lblLodingItems;
        private Label lblConnectionMessage;
        private Label lblNoOrder;
        private TableLayoutPanel tlpItems;
        private Panel pnlSierra;
        private Label lblSierra;
        private DataGridView grSierra;
        private Panel pnlOrder;
        private Label lblQuantityValue;
        private Label lblItemValue;
        private Label lblOrder;
        private Label lblQuantity;
        private Panel pnlSubtitle;
        private PictureBox picBoxEnterpriseLogo;
        private PictureBox picBoxSubTitleLine;
        private DataGridViewTextBoxColumn grcItem;
        private DataGridViewTextBoxColumn grcDescription;
        private DataGridViewTextBoxColumn grcQuantity;
        private DataGridViewTextBoxColumn grcDimensions;
        private DataGridViewTextBoxColumn grcDoblez;
        private DataGridViewTextBoxColumn grcSierraItem;
        private DataGridViewTextBoxColumn grSierraDescription;
        private DataGridViewTextBoxColumn grcSierraQuantity;
        private DataGridViewTextBoxColumn grcSierraDimensions;
        private DataGridViewTextBoxColumn grSierraDoblez;
        private Label lblUserName;
        private PictureBox picBoxUserImage;
    }
}