
namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    partial class LVTaps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LVTaps));
            this.lblTitle = new System.Windows.Forms.Label();
            this.grItems = new System.Windows.Forms.DataGridView();
            this.grcItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcDimensions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdPuntoInicialBTI = new System.Windows.Forms.DataGridView();
            this.grcInitBTI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdPuntaFinBTI = new System.Windows.Forms.DataGridView();
            this.grcEndBTI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdPuntaFinBTE = new System.Windows.Forms.DataGridView();
            this.grcEndBTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdPuntaInicioBTE = new System.Windows.Forms.DataGridView();
            this.grcInitBTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPuntaInicio = new System.Windows.Forms.Label();
            this.lblniBti = new System.Windows.Forms.Label();
            this.lblIniBte = new System.Windows.Forms.Label();
            this.lblFinBti = new System.Windows.Forms.Label();
            this.lblPuntaFin = new System.Windows.Forms.Label();
            this.lblFinBte = new System.Windows.Forms.Label();
            this.lblLodingItems = new System.Windows.Forms.Label();
            this.lblConnectionMessage = new System.Windows.Forms.Label();
            this.lblNoOrder = new System.Windows.Forms.Label();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.lblQuantityValue = new System.Windows.Forms.Label();
            this.lblItemValue = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.tbLayoutGrpGrd = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picBoxEnterpriseLogo = new System.Windows.Forms.PictureBox();
            this.picBoxSubTitleLine = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.picBoxUserImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPuntoInicialBTI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPuntaFinBTI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPuntaFinBTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPuntaInicioBTE)).BeginInit();
            this.pnlOrder.SuspendLayout();
            this.tbLayoutGrpGrd.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSubTitleLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(66, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(681, 32);
            this.lblTitle.TabIndex = 15;
            this.lblTitle.Text = "AISLAMIENTOS - Soldadura de puntas de aluminio";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grItems
            // 
            this.grItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcItem,
            this.grcDescription,
            this.grcQuantity,
            this.grcDimensions});
            this.grItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grItems.Location = new System.Drawing.Point(3, 3);
            this.grItems.Name = "grItems";
            this.grItems.ReadOnly = true;
            this.grItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grItems.Size = new System.Drawing.Size(1294, 260);
            this.grItems.TabIndex = 14;
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
            this.grcDescription.MinimumWidth = 350;
            this.grcDescription.Name = "grcDescription";
            this.grcDescription.ReadOnly = true;
            this.grcDescription.Width = 350;
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
            this.grcDimensions.MinimumWidth = 350;
            this.grcDimensions.Name = "grcDimensions";
            this.grcDimensions.ReadOnly = true;
            this.grcDimensions.Width = 350;
            // 
            // grdPuntoInicialBTI
            // 
            this.grdPuntoInicialBTI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcInitBTI});
            this.grdPuntoInicialBTI.Location = new System.Drawing.Point(3, 54);
            this.grdPuntoInicialBTI.Name = "grdPuntoInicialBTI";
            this.grdPuntoInicialBTI.Size = new System.Drawing.Size(621, 86);
            this.grdPuntoInicialBTI.TabIndex = 20;
            // 
            // grcInitBTI
            // 
            this.grcInitBTI.HeaderText = "";
            this.grcInitBTI.Name = "grcInitBTI";
            // 
            // grdPuntaFinBTI
            // 
            this.grdPuntaFinBTI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcEndBTI});
            this.grdPuntaFinBTI.Location = new System.Drawing.Point(665, 54);
            this.grdPuntaFinBTI.Name = "grdPuntaFinBTI";
            this.grdPuntaFinBTI.Size = new System.Drawing.Size(621, 86);
            this.grdPuntaFinBTI.TabIndex = 21;
            // 
            // grcEndBTI
            // 
            this.grcEndBTI.HeaderText = "";
            this.grcEndBTI.Name = "grcEndBTI";
            // 
            // grdPuntaFinBTE
            // 
            this.grdPuntaFinBTE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcEndBTE});
            this.grdPuntaFinBTE.Location = new System.Drawing.Point(665, 169);
            this.grdPuntaFinBTE.Name = "grdPuntaFinBTE";
            this.grdPuntaFinBTE.Size = new System.Drawing.Size(621, 86);
            this.grdPuntaFinBTE.TabIndex = 23;
            // 
            // grcEndBTE
            // 
            this.grcEndBTE.HeaderText = "";
            this.grcEndBTE.Name = "grcEndBTE";
            // 
            // grdPuntaInicioBTE
            // 
            this.grdPuntaInicioBTE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcInitBTE});
            this.grdPuntaInicioBTE.Location = new System.Drawing.Point(3, 169);
            this.grdPuntaInicioBTE.Name = "grdPuntaInicioBTE";
            this.grdPuntaInicioBTE.Size = new System.Drawing.Size(621, 86);
            this.grdPuntaInicioBTE.TabIndex = 22;
            // 
            // grcInitBTE
            // 
            this.grcInitBTE.HeaderText = "";
            this.grcInitBTE.Name = "grcInitBTE";
            // 
            // lblPuntaInicio
            // 
            this.lblPuntaInicio.AutoSize = true;
            this.lblPuntaInicio.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPuntaInicio.Location = new System.Drawing.Point(3, 19);
            this.lblPuntaInicio.Name = "lblPuntaInicio";
            this.lblPuntaInicio.Size = new System.Drawing.Size(199, 32);
            this.lblPuntaInicio.TabIndex = 24;
            this.lblPuntaInicio.Text = "PUNTA INICIO";
            // 
            // lblniBti
            // 
            this.lblniBti.AutoSize = true;
            this.lblniBti.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblniBti.Location = new System.Drawing.Point(555, 28);
            this.lblniBti.Name = "lblniBti";
            this.lblniBti.Size = new System.Drawing.Size(69, 23);
            this.lblniBti.TabIndex = 25;
            this.lblniBti.Text = "--BTI--";
            // 
            // lblIniBte
            // 
            this.lblIniBte.AutoSize = true;
            this.lblIniBte.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIniBte.Location = new System.Drawing.Point(548, 143);
            this.lblIniBte.Name = "lblIniBte";
            this.lblIniBte.Size = new System.Drawing.Size(76, 23);
            this.lblIniBte.TabIndex = 26;
            this.lblIniBte.Text = "--BTE--";
            // 
            // lblFinBti
            // 
            this.lblFinBti.AutoSize = true;
            this.lblFinBti.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFinBti.Location = new System.Drawing.Point(1217, 28);
            this.lblFinBti.Name = "lblFinBti";
            this.lblFinBti.Size = new System.Drawing.Size(69, 23);
            this.lblFinBti.TabIndex = 28;
            this.lblFinBti.Text = "--BTI--";
            // 
            // lblPuntaFin
            // 
            this.lblPuntaFin.AutoSize = true;
            this.lblPuntaFin.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPuntaFin.Location = new System.Drawing.Point(665, 19);
            this.lblPuntaFin.Name = "lblPuntaFin";
            this.lblPuntaFin.Size = new System.Drawing.Size(195, 32);
            this.lblPuntaFin.TabIndex = 27;
            this.lblPuntaFin.Text = "PUNTA FINAL";
            // 
            // lblFinBte
            // 
            this.lblFinBte.AutoSize = true;
            this.lblFinBte.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFinBte.Location = new System.Drawing.Point(1210, 143);
            this.lblFinBte.Name = "lblFinBte";
            this.lblFinBte.Size = new System.Drawing.Size(76, 23);
            this.lblFinBte.TabIndex = 29;
            this.lblFinBte.Text = "--BTE--";
            // 
            // lblLodingItems
            // 
            this.lblLodingItems.AutoSize = true;
            this.lblLodingItems.Location = new System.Drawing.Point(756, 26);
            this.lblLodingItems.Name = "lblLodingItems";
            this.lblLodingItems.Size = new System.Drawing.Size(155, 15);
            this.lblLodingItems.TabIndex = 31;
            this.lblLodingItems.Text = "Consultando información...";
            this.lblLodingItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLodingItems.Visible = false;
            // 
            // lblConnectionMessage
            // 
            this.lblConnectionMessage.AutoSize = true;
            this.lblConnectionMessage.Location = new System.Drawing.Point(781, 7);
            this.lblConnectionMessage.Name = "lblConnectionMessage";
            this.lblConnectionMessage.Size = new System.Drawing.Size(165, 15);
            this.lblConnectionMessage.TabIndex = 30;
            this.lblConnectionMessage.Text = "Conectando con el servidor...";
            this.lblConnectionMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoOrder
            // 
            this.lblNoOrder.AutoSize = true;
            this.lblNoOrder.Location = new System.Drawing.Point(931, 22);
            this.lblNoOrder.Name = "lblNoOrder";
            this.lblNoOrder.Size = new System.Drawing.Size(175, 15);
            this.lblNoOrder.TabIndex = 32;
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
            this.pnlOrder.Location = new System.Drawing.Point(20, 65);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(1300, 48);
            this.pnlOrder.TabIndex = 33;
            // 
            // lblQuantityValue
            // 
            this.lblQuantityValue.AutoSize = true;
            this.lblQuantityValue.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblQuantityValue.Location = new System.Drawing.Point(474, 6);
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
            this.lblItemValue.Name = "lblItemValue";
            this.lblItemValue.Size = new System.Drawing.Size(245, 37);
            this.lblItemValue.TabIndex = 23;
            this.lblItemValue.Text = "DCN604-446";
            this.lblItemValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrder
            // 
            this.lblOrder.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOrder.Location = new System.Drawing.Point(3, 6);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(90, 37);
            this.lblOrder.TabIndex = 21;
            this.lblOrder.Text = "Orden:";
            this.lblOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblQuantity.Location = new System.Drawing.Point(350, 6);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(118, 37);
            this.lblQuantity.TabIndex = 22;
            this.lblQuantity.Text = "Cantidad:";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbLayoutGrpGrd
            // 
            this.tbLayoutGrpGrd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbLayoutGrpGrd.ColumnCount = 1;
            this.tbLayoutGrpGrd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutGrpGrd.Controls.Add(this.grItems, 0, 0);
            this.tbLayoutGrpGrd.Controls.Add(this.panel1, 0, 1);
            this.tbLayoutGrpGrd.Location = new System.Drawing.Point(20, 118);
            this.tbLayoutGrpGrd.Name = "tbLayoutGrpGrd";
            this.tbLayoutGrpGrd.RowCount = 2;
            this.tbLayoutGrpGrd.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbLayoutGrpGrd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutGrpGrd.Size = new System.Drawing.Size(1300, 530);
            this.tbLayoutGrpGrd.TabIndex = 34;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblFinBte);
            this.panel1.Controls.Add(this.lblFinBti);
            this.panel1.Controls.Add(this.lblPuntaInicio);
            this.panel1.Controls.Add(this.lblPuntaFin);
            this.panel1.Controls.Add(this.lblIniBte);
            this.panel1.Controls.Add(this.grdPuntoInicialBTI);
            this.panel1.Controls.Add(this.grdPuntaInicioBTE);
            this.panel1.Controls.Add(this.grdPuntaFinBTE);
            this.panel1.Controls.Add(this.grdPuntaFinBTI);
            this.panel1.Controls.Add(this.lblniBti);
            this.panel1.Location = new System.Drawing.Point(3, 269);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1294, 255);
            this.panel1.TabIndex = 35;
            // 
            // picBoxEnterpriseLogo
            // 
            this.picBoxEnterpriseLogo.Image = ((System.Drawing.Image)(resources.GetObject("picBoxEnterpriseLogo.Image")));
            this.picBoxEnterpriseLogo.Location = new System.Drawing.Point(20, 8);
            this.picBoxEnterpriseLogo.Name = "picBoxEnterpriseLogo";
            this.picBoxEnterpriseLogo.Size = new System.Drawing.Size(40, 40);
            this.picBoxEnterpriseLogo.TabIndex = 35;
            this.picBoxEnterpriseLogo.TabStop = false;
            // 
            // picBoxSubTitleLine
            // 
            this.picBoxSubTitleLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxSubTitleLine.Image = ((System.Drawing.Image)(resources.GetObject("picBoxSubTitleLine.Image")));
            this.picBoxSubTitleLine.Location = new System.Drawing.Point(20, 55);
            this.picBoxSubTitleLine.Name = "picBoxSubTitleLine";
            this.picBoxSubTitleLine.Size = new System.Drawing.Size(1300, 5);
            this.picBoxSubTitleLine.TabIndex = 36;
            this.picBoxSubTitleLine.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Location = new System.Drawing.Point(1144, 8);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 40);
            this.lblUserName.TabIndex = 38;
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
            this.picBoxUserImage.TabIndex = 37;
            this.picBoxUserImage.TabStop = false;
            // 
            // LVTaps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 661);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picBoxUserImage);
            this.Controls.Add(this.picBoxSubTitleLine);
            this.Controls.Add(this.picBoxEnterpriseLogo);
            this.Controls.Add(this.tbLayoutGrpGrd);
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.lblNoOrder);
            this.Controls.Add(this.lblLodingItems);
            this.Controls.Add(this.lblConnectionMessage);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "LVTaps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AISLAMIENTOS - Soldadura de puntas de aluminio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LVTaps_Load);
            this.Resize += new System.EventHandler(this.LVTaps_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPuntoInicialBTI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPuntaFinBTI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPuntaFinBTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPuntaInicioBTE)).EndInit();
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            this.tbLayoutGrpGrd.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSubTitleLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView grItems;
        private System.Windows.Forms.DataGridView grdPuntoInicialBTI;
        private System.Windows.Forms.DataGridView grdPuntaFinBTI;
        private System.Windows.Forms.DataGridView grdPuntaFinBTE;
        private System.Windows.Forms.DataGridView grdPuntaInicioBTE;
        private Label lblLodingItems;
        private Label lblConnectionMessage;
        private Label lblNoOrder;
        private Panel pnlOrder;
        private Label lblQuantityValue;
        private Label lblItemValue;
        private Label lblOrder;
        private Label lblQuantity;
        private TableLayoutPanel tbLayoutGrpGrd;
        private Label lblPuntaInicio;
        private Label lblniBti;
        private Label lblIniBte;
        private Label lblFinBti;
        private Label lblPuntaFin;
        private Label lblFinBte;
        private DataGridViewTextBoxColumn grcInitBTI;
        private DataGridViewTextBoxColumn grcEndBTI;
        private DataGridViewTextBoxColumn grcInitBTE;
        private DataGridViewTextBoxColumn grcEndBTE;
        private Panel panel1;
        private PictureBox picBoxEnterpriseLogo;
        private PictureBox picBoxSubTitleLine;
        private DataGridViewTextBoxColumn grcItem;
        private DataGridViewTextBoxColumn grcDescription;
        private DataGridViewTextBoxColumn grcQuantity;
        private DataGridViewTextBoxColumn grcDimensions;
        private Label lblUserName;
        private PictureBox picBoxUserImage;
    }
}