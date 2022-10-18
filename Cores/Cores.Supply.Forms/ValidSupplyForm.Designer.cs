namespace ProlecGE.ControlPisoMX.CoreSupply.Forms
{
    partial class ValidSupplyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidSupplyForm));
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.lblSerie = new System.Windows.Forms.Label();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.lblBatch = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.lblOrder = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.picBoxUserImage = new System.Windows.Forms.PictureBox();
            this.picBoxEnterpriseLogo = new System.Windows.Forms.PictureBox();
            this.picBoxTitleLine = new System.Windows.Forms.PictureBox();
            this.lblTitleSupplies = new System.Windows.Forms.Label();
            this.lblAddCore = new System.Windows.Forms.Label();
            this.txtAddCore = new System.Windows.Forms.TextBox();
            this.grItems = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.BtnAcept = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTitleLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grItems)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(540, 67);
            this.txtSerie.MaxLength = 0;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(100, 21);
            this.txtSerie.TabIndex = 2;
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(455, 70);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(36, 15);
            this.lblSerie.TabIndex = 65;
            this.lblSerie.Text = "Serie";
            // 
            // txtBatch
            // 
            this.txtBatch.Location = new System.Drawing.Point(315, 67);
            this.txtBatch.MaxLength = 3;
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(100, 21);
            this.txtBatch.TabIndex = 1;
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.Location = new System.Drawing.Point(257, 71);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(31, 15);
            this.lblBatch.TabIndex = 64;
            this.lblBatch.Text = "Lote";
            // 
            // txtOrder
            // 
            this.txtOrder.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrder.Location = new System.Drawing.Point(114, 66);
            this.txtOrder.MaxLength = 47;
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(100, 21);
            this.txtOrder.TabIndex = 0;
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOrder.Location = new System.Drawing.Point(20, 69);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(47, 15);
            this.lblOrder.TabIndex = 63;
            this.lblOrder.Text = "Artículo";
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Location = new System.Drawing.Point(464, 7);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 40);
            this.lblUserName.TabIndex = 62;
            this.lblUserName.Text = "Daniela Pérez Gavilan García del campo";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picBoxUserImage
            // 
            this.picBoxUserImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxUserImage.Location = new System.Drawing.Point(600, 7);
            this.picBoxUserImage.Name = "picBoxUserImage";
            this.picBoxUserImage.Size = new System.Drawing.Size(40, 40);
            this.picBoxUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxUserImage.TabIndex = 61;
            this.picBoxUserImage.TabStop = false;
            // 
            // picBoxEnterpriseLogo
            // 
            this.picBoxEnterpriseLogo.Location = new System.Drawing.Point(20, 7);
            this.picBoxEnterpriseLogo.Name = "picBoxEnterpriseLogo";
            this.picBoxEnterpriseLogo.Size = new System.Drawing.Size(40, 40);
            this.picBoxEnterpriseLogo.TabIndex = 60;
            this.picBoxEnterpriseLogo.TabStop = false;
            // 
            // picBoxTitleLine
            // 
            this.picBoxTitleLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxTitleLine.Image = ((System.Drawing.Image)(resources.GetObject("picBoxTitleLine.Image")));
            this.picBoxTitleLine.Location = new System.Drawing.Point(20, 52);
            this.picBoxTitleLine.Name = "picBoxTitleLine";
            this.picBoxTitleLine.Size = new System.Drawing.Size(621, 5);
            this.picBoxTitleLine.TabIndex = 59;
            this.picBoxTitleLine.TabStop = false;
            // 
            // lblTitleSupplies
            // 
            this.lblTitleSupplies.AutoSize = true;
            this.lblTitleSupplies.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitleSupplies.Location = new System.Drawing.Point(65, 13);
            this.lblTitleSupplies.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleSupplies.Name = "lblTitleSupplies";
            this.lblTitleSupplies.Size = new System.Drawing.Size(263, 29);
            this.lblTitleSupplies.TabIndex = 58;
            this.lblTitleSupplies.Text = "Validación suministro";
            // 
            // lblAddCore
            // 
            this.lblAddCore.AutoSize = true;
            this.lblAddCore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAddCore.Location = new System.Drawing.Point(20, 104);
            this.lblAddCore.Name = "lblAddCore";
            this.lblAddCore.Size = new System.Drawing.Size(82, 15);
            this.lblAddCore.TabIndex = 63;
            this.lblAddCore.Text = "Añadir núcleo";
            // 
            // txtAddCore
            // 
            this.txtAddCore.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddCore.Location = new System.Drawing.Point(115, 101);
            this.txtAddCore.MaxLength = 8;
            this.txtAddCore.Name = "txtAddCore";
            this.txtAddCore.Size = new System.Drawing.Size(300, 21);
            this.txtAddCore.TabIndex = 3;
            this.txtAddCore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtAddCore_KeyDown);
            // 
            // grItems
            // 
            this.grItems.AllowUserToAddRows = false;
            this.grItems.AllowUserToDeleteRows = false;
            this.grItems.AllowUserToOrderColumns = true;
            this.grItems.AllowUserToResizeRows = false;
            this.grItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grItems.Location = new System.Drawing.Point(20, 138);
            this.grItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grItems.Name = "grItems";
            this.grItems.RowHeadersVisible = false;
            this.grItems.RowHeadersWidth = 51;
            this.grItems.RowTemplate.Height = 29;
            this.grItems.Size = new System.Drawing.Size(620, 272);
            this.grItems.TabIndex = 4;
            this.grItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrItems_CellDoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(20, 416);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Salir";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(101, 416);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(106, 26);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Borrar todos";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnAcept
            // 
            this.BtnAcept.Location = new System.Drawing.Point(213, 416);
            this.BtnAcept.Name = "BtnAcept";
            this.BtnAcept.Size = new System.Drawing.Size(75, 26);
            this.BtnAcept.TabIndex = 6;
            this.BtnAcept.Text = "Aceptar";
            this.BtnAcept.UseVisualStyleBackColor = true;
            this.BtnAcept.Click += new System.EventHandler(this.BtnAcept_Click);
            // 
            // ValidSupplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 456);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.BtnAcept);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.grItems);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.lblSerie);
            this.Controls.Add(this.txtBatch);
            this.Controls.Add(this.lblBatch);
            this.Controls.Add(this.txtAddCore);
            this.Controls.Add(this.lblAddCore);
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
            this.Name = "ValidSupplyForm";
            this.Text = "Validación suministro";
            this.Load += new System.EventHandler(this.ValidSupplyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTitleLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtSerie;
        private Label lblSerie;
        private TextBox txtBatch;
        private Label lblBatch;
        private TextBox txtOrder;
        private Label lblOrder;
        private Label lblUserName;
        private PictureBox picBoxUserImage;
        private PictureBox picBoxEnterpriseLogo;
        private PictureBox picBoxTitleLine;
        private Label lblTitleSupplies;
        private Label lblAddCore;
        private TextBox txtAddCore;
        private DataGridView grItems;
        private Button btnClose;
        private Button btnClear;
        private Button BtnAcept;
    }
}