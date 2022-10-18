namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    partial class LVTaps2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LVTaps2));
            this.lblTitle = new System.Windows.Forms.Label();
            this.grNextMaterial = new System.Windows.Forms.DataGridView();
            this.grcNextItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcNextDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcNextCuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcNextDimensions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNextQuantityValue = new System.Windows.Forms.Label();
            this.lblNextItemValue = new System.Windows.Forms.Label();
            this.lblNextQuantity = new System.Windows.Forms.Label();
            this.lblNextOrder = new System.Windows.Forms.Label();
            this.lblNoOrder = new System.Windows.Forms.Label();
            this.lblLodingItems = new System.Windows.Forms.Label();
            this.lblConnectionMessage = new System.Windows.Forms.Label();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.lblQuantityValue = new System.Windows.Forms.Label();
            this.lblItemValue = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.tbLayoutGrpGrd = new System.Windows.Forms.TableLayoutPanel();
            this.grMaterial = new System.Windows.Forms.DataGridView();
            this.grcItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcDimensions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlNext = new System.Windows.Forms.Panel();
            this.pnlNextOrder = new System.Windows.Forms.Panel();
            this.lblNoNextOrder = new System.Windows.Forms.Label();
            this.picBoxEnterpriseLogo = new System.Windows.Forms.PictureBox();
            this.picBoxSubTitleLine = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.picBoxUserImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grNextMaterial)).BeginInit();
            this.pnlOrder.SuspendLayout();
            this.tbLayoutGrpGrd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMaterial)).BeginInit();
            this.pnlNext.SuspendLayout();
            this.pnlNextOrder.SuspendLayout();
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
            this.lblTitle.Size = new System.Drawing.Size(618, 32);
            this.lblTitle.TabIndex = 21;
            this.lblTitle.Text = "AISLAMIENTOS - Corte de puntas de aluminio";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grNextMaterial
            // 
            this.grNextMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grNextMaterial.ColumnHeadersHeight = 29;
            this.grNextMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcNextItem,
            this.grcNextDescription,
            this.grcNextCuantity,
            this.grcNextDimensions});
            this.grNextMaterial.Location = new System.Drawing.Point(0, 64);
            this.grNextMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grNextMaterial.Name = "grNextMaterial";
            this.grNextMaterial.ReadOnly = true;
            this.grNextMaterial.RowHeadersWidth = 51;
            this.grNextMaterial.Size = new System.Drawing.Size(1295, 210);
            this.grNextMaterial.TabIndex = 26;
            // 
            // grcNextItem
            // 
            this.grcNextItem.HeaderText = "ARTÍCULO";
            this.grcNextItem.MinimumWidth = 100;
            this.grcNextItem.Name = "grcNextItem";
            this.grcNextItem.ReadOnly = true;
            this.grcNextItem.Width = 125;
            // 
            // grcNextDescription
            // 
            this.grcNextDescription.DataPropertyName = "Description";
            this.grcNextDescription.HeaderText = "DESCRIPCIÓN";
            this.grcNextDescription.MinimumWidth = 350;
            this.grcNextDescription.Name = "grcNextDescription";
            this.grcNextDescription.ReadOnly = true;
            this.grcNextDescription.Width = 350;
            // 
            // grcNextCuantity
            // 
            this.grcNextCuantity.HeaderText = "CANTIDAD";
            this.grcNextCuantity.MinimumWidth = 150;
            this.grcNextCuantity.Name = "grcNextCuantity";
            this.grcNextCuantity.ReadOnly = true;
            this.grcNextCuantity.Width = 150;
            // 
            // grcNextDimensions
            // 
            this.grcNextDimensions.HeaderText = "DIMENSIONES";
            this.grcNextDimensions.MinimumWidth = 350;
            this.grcNextDimensions.Name = "grcNextDimensions";
            this.grcNextDimensions.ReadOnly = true;
            this.grcNextDimensions.Width = 350;
            // 
            // lblNextQuantityValue
            // 
            this.lblNextQuantityValue.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNextQuantityValue.Location = new System.Drawing.Point(596, 7);
            this.lblNextQuantityValue.MinimumSize = new System.Drawing.Size(36, 19);
            this.lblNextQuantityValue.Name = "lblNextQuantityValue";
            this.lblNextQuantityValue.Size = new System.Drawing.Size(52, 45);
            this.lblNextQuantityValue.TabIndex = 30;
            this.lblNextQuantityValue.Text = "--";
            this.lblNextQuantityValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNextItemValue
            // 
            this.lblNextItemValue.AutoSize = true;
            this.lblNextItemValue.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNextItemValue.Location = new System.Drawing.Point(209, 11);
            this.lblNextItemValue.Name = "lblNextItemValue";
            this.lblNextItemValue.Size = new System.Drawing.Size(39, 37);
            this.lblNextItemValue.TabIndex = 29;
            this.lblNextItemValue.Text = "--";
            this.lblNextItemValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNextQuantity
            // 
            this.lblNextQuantity.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNextQuantity.Location = new System.Drawing.Point(467, 7);
            this.lblNextQuantity.Name = "lblNextQuantity";
            this.lblNextQuantity.Size = new System.Drawing.Size(123, 45);
            this.lblNextQuantity.TabIndex = 28;
            this.lblNextQuantity.Text = "Cantidad:";
            this.lblNextQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNextOrder
            // 
            this.lblNextOrder.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNextOrder.Location = new System.Drawing.Point(0, 7);
            this.lblNextOrder.Name = "lblNextOrder";
            this.lblNextOrder.Size = new System.Drawing.Size(190, 45);
            this.lblNextOrder.TabIndex = 27;
            this.lblNextOrder.Text = "Siguiente orden:";
            this.lblNextOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoOrder
            // 
            this.lblNoOrder.AutoSize = true;
            this.lblNoOrder.Location = new System.Drawing.Point(701, 25);
            this.lblNoOrder.Name = "lblNoOrder";
            this.lblNoOrder.Size = new System.Drawing.Size(175, 15);
            this.lblNoOrder.TabIndex = 33;
            this.lblNoOrder.Text = "No hay unidades por procesar.";
            this.lblNoOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLodingItems
            // 
            this.lblLodingItems.AutoSize = true;
            this.lblLodingItems.Location = new System.Drawing.Point(701, 25);
            this.lblLodingItems.Name = "lblLodingItems";
            this.lblLodingItems.Size = new System.Drawing.Size(155, 15);
            this.lblLodingItems.TabIndex = 32;
            this.lblLodingItems.Text = "Consultando información...";
            this.lblLodingItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLodingItems.Visible = false;
            // 
            // lblConnectionMessage
            // 
            this.lblConnectionMessage.AutoSize = true;
            this.lblConnectionMessage.Location = new System.Drawing.Point(701, 25);
            this.lblConnectionMessage.Name = "lblConnectionMessage";
            this.lblConnectionMessage.Size = new System.Drawing.Size(165, 15);
            this.lblConnectionMessage.TabIndex = 31;
            this.lblConnectionMessage.Text = "Conectando con el servidor...";
            this.lblConnectionMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.pnlOrder.Location = new System.Drawing.Point(20, 68);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(1300, 44);
            this.pnlOrder.TabIndex = 34;
            // 
            // lblQuantityValue
            // 
            this.lblQuantityValue.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblQuantityValue.Location = new System.Drawing.Point(608, 4);
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
            this.lblItemValue.AutoSize = true;
            this.lblItemValue.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblItemValue.Location = new System.Drawing.Point(227, 4);
            this.lblItemValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemValue.Name = "lblItemValue";
            this.lblItemValue.Size = new System.Drawing.Size(204, 37);
            this.lblItemValue.TabIndex = 23;
            this.lblItemValue.Text = "DCN604-446";
            this.lblItemValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrder
            // 
            this.lblOrder.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOrder.Location = new System.Drawing.Point(3, 4);
            this.lblOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(216, 37);
            this.lblOrder.TabIndex = 21;
            this.lblOrder.Text = "Orden en proceso:";
            this.lblOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblQuantity.Location = new System.Drawing.Point(476, 4);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(124, 37);
            this.lblQuantity.TabIndex = 22;
            this.lblQuantity.Text = "Cantidad:";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbLayoutGrpGrd
            // 
            this.tbLayoutGrpGrd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLayoutGrpGrd.ColumnCount = 1;
            this.tbLayoutGrpGrd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutGrpGrd.Controls.Add(this.grMaterial, 0, 0);
            this.tbLayoutGrpGrd.Controls.Add(this.pnlNext, 0, 1);
            this.tbLayoutGrpGrd.Location = new System.Drawing.Point(20, 117);
            this.tbLayoutGrpGrd.Margin = new System.Windows.Forms.Padding(1);
            this.tbLayoutGrpGrd.Name = "tbLayoutGrpGrd";
            this.tbLayoutGrpGrd.RowCount = 2;
            this.tbLayoutGrpGrd.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbLayoutGrpGrd.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbLayoutGrpGrd.Size = new System.Drawing.Size(1300, 534);
            this.tbLayoutGrpGrd.TabIndex = 35;
            // 
            // grMaterial
            // 
            this.grMaterial.ColumnHeadersHeight = 29;
            this.grMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcItem,
            this.grcDescription,
            this.grcQuantity,
            this.grcDimensions});
            this.grMaterial.Location = new System.Drawing.Point(3, 2);
            this.grMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grMaterial.Name = "grMaterial";
            this.grMaterial.ReadOnly = true;
            this.grMaterial.RowHeadersWidth = 51;
            this.grMaterial.Size = new System.Drawing.Size(1294, 250);
            this.grMaterial.TabIndex = 20;
            // 
            // grcItem
            // 
            this.grcItem.HeaderText = "ARTÍCULO";
            this.grcItem.MinimumWidth = 100;
            this.grcItem.Name = "grcItem";
            this.grcItem.ReadOnly = true;
            this.grcItem.Width = 125;
            // 
            // grcDescription
            // 
            this.grcDescription.DataPropertyName = "Description";
            this.grcDescription.HeaderText = "DESCRIPCIÓN";
            this.grcDescription.MinimumWidth = 350;
            this.grcDescription.Name = "grcDescription";
            this.grcDescription.ReadOnly = true;
            this.grcDescription.Width = 350;
            // 
            // grcQuantity
            // 
            this.grcQuantity.HeaderText = "CANTIDAD";
            this.grcQuantity.MinimumWidth = 150;
            this.grcQuantity.Name = "grcQuantity";
            this.grcQuantity.ReadOnly = true;
            this.grcQuantity.Width = 150;
            // 
            // grcDimensions
            // 
            this.grcDimensions.HeaderText = "DIMENSIONES";
            this.grcDimensions.MinimumWidth = 350;
            this.grcDimensions.Name = "grcDimensions";
            this.grcDimensions.ReadOnly = true;
            this.grcDimensions.Width = 350;
            // 
            // pnlNext
            // 
            this.pnlNext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNext.Controls.Add(this.pnlNextOrder);
            this.pnlNext.Controls.Add(this.lblNoNextOrder);
            this.pnlNext.Controls.Add(this.grNextMaterial);
            this.pnlNext.Location = new System.Drawing.Point(2, 256);
            this.pnlNext.Margin = new System.Windows.Forms.Padding(2);
            this.pnlNext.Name = "pnlNext";
            this.pnlNext.Size = new System.Drawing.Size(1296, 276);
            this.pnlNext.TabIndex = 21;
            // 
            // pnlNextOrder
            // 
            this.pnlNextOrder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlNextOrder.Controls.Add(this.lblNextOrder);
            this.pnlNextOrder.Controls.Add(this.lblNextQuantityValue);
            this.pnlNextOrder.Controls.Add(this.lblNextItemValue);
            this.pnlNextOrder.Controls.Add(this.lblNextQuantity);
            this.pnlNextOrder.Location = new System.Drawing.Point(-2, 0);
            this.pnlNextOrder.Margin = new System.Windows.Forms.Padding(2);
            this.pnlNextOrder.Name = "pnlNextOrder";
            this.pnlNextOrder.Size = new System.Drawing.Size(1295, 60);
            this.pnlNextOrder.TabIndex = 32;
            // 
            // lblNoNextOrder
            // 
            this.lblNoNextOrder.Location = new System.Drawing.Point(531, 182);
            this.lblNoNextOrder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoNextOrder.Name = "lblNoNextOrder";
            this.lblNoNextOrder.Size = new System.Drawing.Size(224, 15);
            this.lblNoNextOrder.TabIndex = 31;
            this.lblNoNextOrder.Text = "No hay siguientes unidades por procesar.";
            // 
            // picBoxEnterpriseLogo
            // 
            this.picBoxEnterpriseLogo.Image = ((System.Drawing.Image)(resources.GetObject("picBoxEnterpriseLogo.Image")));
            this.picBoxEnterpriseLogo.Location = new System.Drawing.Point(20, 8);
            this.picBoxEnterpriseLogo.Name = "picBoxEnterpriseLogo";
            this.picBoxEnterpriseLogo.Size = new System.Drawing.Size(40, 40);
            this.picBoxEnterpriseLogo.TabIndex = 36;
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
            this.picBoxSubTitleLine.TabIndex = 37;
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
            // LVTaps2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 661);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picBoxUserImage);
            this.Controls.Add(this.picBoxSubTitleLine);
            this.Controls.Add(this.picBoxEnterpriseLogo);
            this.Controls.Add(this.lblNoOrder);
            this.Controls.Add(this.tbLayoutGrpGrd);
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.lblLodingItems);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblConnectionMessage);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "LVTaps2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AISLAMIENTOS - Corte de puntas de aluminio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LVTaps2_Load);
            this.SizeChanged += new System.EventHandler(this.LVTaps2_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.grNextMaterial)).EndInit();
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            this.tbLayoutGrpGrd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grMaterial)).EndInit();
            this.pnlNext.ResumeLayout(false);
            this.pnlNextOrder.ResumeLayout(false);
            this.pnlNextOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSubTitleLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView grNextMaterial;
        private System.Windows.Forms.Label lblNextQuantityValue;
        private System.Windows.Forms.Label lblNextItemValue;
        private System.Windows.Forms.Label lblNextQuantity;
        private System.Windows.Forms.Label lblNextOrder;
        private Label lblNoOrder;
        private Label lblLodingItems;
        private Label lblConnectionMessage;
        private Panel pnlOrder;
        private Label lblQuantityValue;
        private Label lblItemValue;
        private Label lblOrder;
        private Label lblQuantity;
        private Panel pnlNext;
        private TableLayoutPanel tbLayoutGrpGrd;
        private Label lblNoNextOrder;
        private Panel pnlNextOrder;
        private DataGridView grMaterial;
        private PictureBox picBoxEnterpriseLogo;
        private PictureBox picBoxSubTitleLine;
        private DataGridViewTextBoxColumn grcNextItem;
        private DataGridViewTextBoxColumn grcNextDescription;
        private DataGridViewTextBoxColumn grcNextCuantity;
        private DataGridViewTextBoxColumn grcNextDimensions;
        private DataGridViewTextBoxColumn grcItem;
        private DataGridViewTextBoxColumn grcDescription;
        private DataGridViewTextBoxColumn grcQuantity;
        private DataGridViewTextBoxColumn grcDimensions;
        private Label lblUserName;
        private PictureBox picBoxUserImage;
    }
}