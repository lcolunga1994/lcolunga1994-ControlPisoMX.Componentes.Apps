namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    partial class InsOrderFabrication
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsOrderFabrication));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblMachine = new System.Windows.Forms.Label();
            this.gbLapsedTime = new System.Windows.Forms.GroupBox();
            this.lblTimeLapse = new System.Windows.Forms.Label();
            this.lblItemValue = new System.Windows.Forms.Label();
            this.lblQuantityValue = new System.Windows.Forms.Label();
            this.lblMachineValue = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnFinishWork = new System.Windows.Forms.Button();
            this.lblNoOrder = new System.Windows.Forms.Label();
            this.lblLodingItems = new System.Windows.Forms.Label();
            this.lblConnectionMessage = new System.Windows.Forms.Label();
            this.picBoxSubTitleLine = new System.Windows.Forms.PictureBox();
            this.picBoxEnterpriseLogo = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.picBoxUserImage = new System.Windows.Forms.PictureBox();
            this.gbLapsedTime.SuspendLayout();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSubTitleLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(67, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(642, 32);
            this.lblTitle.TabIndex = 16;
            this.lblTitle.Text = "AISLAMIENTOS -  Requerimiento de fabricación";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblQuantity.Location = new System.Drawing.Point(38, 154);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(182, 43);
            this.lblQuantity.TabIndex = 18;
            this.lblQuantity.Text = "Cantidad:";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblItem.Location = new System.Drawing.Point(38, 39);
            this.lblItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(135, 43);
            this.lblItem.TabIndex = 17;
            this.lblItem.Text = "Orden:";
            // 
            // lblMachine
            // 
            this.lblMachine.AutoSize = true;
            this.lblMachine.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMachine.Location = new System.Drawing.Point(38, 272);
            this.lblMachine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(175, 43);
            this.lblMachine.TabIndex = 19;
            this.lblMachine.Text = "Máquina:";
            // 
            // gbLapsedTime
            // 
            this.gbLapsedTime.Controls.Add(this.lblTimeLapse);
            this.gbLapsedTime.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbLapsedTime.Location = new System.Drawing.Point(243, 370);
            this.gbLapsedTime.Name = "gbLapsedTime";
            this.gbLapsedTime.Size = new System.Drawing.Size(474, 153);
            this.gbLapsedTime.TabIndex = 20;
            this.gbLapsedTime.TabStop = false;
            this.gbLapsedTime.Text = "Tiempo de ejecución";
            // 
            // lblTimeLapse
            // 
            this.lblTimeLapse.AutoSize = true;
            this.lblTimeLapse.Font = new System.Drawing.Font("Arial", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTimeLapse.Location = new System.Drawing.Point(17, 35);
            this.lblTimeLapse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeLapse.Name = "lblTimeLapse";
            this.lblTimeLapse.Size = new System.Drawing.Size(417, 107);
            this.lblTimeLapse.TabIndex = 21;
            this.lblTimeLapse.Text = "00:00:00";
            // 
            // lblItemValue
            // 
            this.lblItemValue.Font = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblItemValue.Location = new System.Drawing.Point(243, 20);
            this.lblItemValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemValue.Name = "lblItemValue";
            this.lblItemValue.Size = new System.Drawing.Size(474, 80);
            this.lblItemValue.TabIndex = 21;
            this.lblItemValue.Text = "orden";
            // 
            // lblQuantityValue
            // 
            this.lblQuantityValue.Font = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblQuantityValue.Location = new System.Drawing.Point(243, 135);
            this.lblQuantityValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantityValue.Name = "lblQuantityValue";
            this.lblQuantityValue.Size = new System.Drawing.Size(474, 81);
            this.lblQuantityValue.TabIndex = 22;
            this.lblQuantityValue.Text = "monto";
            // 
            // lblMachineValue
            // 
            this.lblMachineValue.Font = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMachineValue.Location = new System.Drawing.Point(243, 251);
            this.lblMachineValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMachineValue.Name = "lblMachineValue";
            this.lblMachineValue.Size = new System.Drawing.Size(474, 84);
            this.lblMachineValue.TabIndex = 23;
            this.lblMachineValue.Text = "maquina";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // pnlControls
            // 
            this.pnlControls.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlControls.Controls.Add(this.gbLapsedTime);
            this.pnlControls.Controls.Add(this.lblMachineValue);
            this.pnlControls.Controls.Add(this.lblItem);
            this.pnlControls.Controls.Add(this.lblItemValue);
            this.pnlControls.Controls.Add(this.btnFinishWork);
            this.pnlControls.Controls.Add(this.lblQuantityValue);
            this.pnlControls.Controls.Add(this.lblQuantity);
            this.pnlControls.Controls.Add(this.lblMachine);
            this.pnlControls.Location = new System.Drawing.Point(81, 61);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(760, 538);
            this.pnlControls.TabIndex = 25;
            // 
            // btnFinishWork
            // 
            this.btnFinishWork.Enabled = false;
            this.btnFinishWork.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFinishWork.Location = new System.Drawing.Point(38, 389);
            this.btnFinishWork.Name = "btnFinishWork";
            this.btnFinishWork.Size = new System.Drawing.Size(150, 115);
            this.btnFinishWork.TabIndex = 24;
            this.btnFinishWork.Text = "Terminar trabajo";
            this.btnFinishWork.UseVisualStyleBackColor = false;
            this.btnFinishWork.Click += new System.EventHandler(this.BtnFinishWork_Click);
            // 
            // lblNoOrder
            // 
            this.lblNoOrder.AutoSize = true;
            this.lblNoOrder.Location = new System.Drawing.Point(1105, 116);
            this.lblNoOrder.Name = "lblNoOrder";
            this.lblNoOrder.Size = new System.Drawing.Size(175, 15);
            this.lblNoOrder.TabIndex = 28;
            this.lblNoOrder.Text = "No hay unidades por procesar.";
            this.lblNoOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoOrder.Visible = false;
            // 
            // lblLodingItems
            // 
            this.lblLodingItems.AutoSize = true;
            this.lblLodingItems.Location = new System.Drawing.Point(1125, 209);
            this.lblLodingItems.Name = "lblLodingItems";
            this.lblLodingItems.Size = new System.Drawing.Size(155, 15);
            this.lblLodingItems.TabIndex = 27;
            this.lblLodingItems.Text = "Consultando información...";
            this.lblLodingItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLodingItems.Visible = false;
            // 
            // lblConnectionMessage
            // 
            this.lblConnectionMessage.AutoSize = true;
            this.lblConnectionMessage.Location = new System.Drawing.Point(1115, 170);
            this.lblConnectionMessage.Name = "lblConnectionMessage";
            this.lblConnectionMessage.Size = new System.Drawing.Size(165, 15);
            this.lblConnectionMessage.TabIndex = 26;
            this.lblConnectionMessage.Text = "Conectando con el servidor...";
            this.lblConnectionMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConnectionMessage.Visible = false;
            // 
            // picBoxSubTitleLine
            // 
            this.picBoxSubTitleLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxSubTitleLine.Image = ((System.Drawing.Image)(resources.GetObject("picBoxSubTitleLine.Image")));
            this.picBoxSubTitleLine.Location = new System.Drawing.Point(20, 50);
            this.picBoxSubTitleLine.Name = "picBoxSubTitleLine";
            this.picBoxSubTitleLine.Size = new System.Drawing.Size(878, 5);
            this.picBoxSubTitleLine.TabIndex = 39;
            this.picBoxSubTitleLine.TabStop = false;
            // 
            // picBoxEnterpriseLogo
            // 
            this.picBoxEnterpriseLogo.Image = ((System.Drawing.Image)(resources.GetObject("picBoxEnterpriseLogo.Image")));
            this.picBoxEnterpriseLogo.Location = new System.Drawing.Point(20, 5);
            this.picBoxEnterpriseLogo.Name = "picBoxEnterpriseLogo";
            this.picBoxEnterpriseLogo.Size = new System.Drawing.Size(40, 40);
            this.picBoxEnterpriseLogo.TabIndex = 38;
            this.picBoxEnterpriseLogo.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Location = new System.Drawing.Point(722, 5);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 40);
            this.lblUserName.TabIndex = 46;
            this.lblUserName.Text = "Daniela Pérez Gavilan García del campo";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picBoxUserImage
            // 
            this.picBoxUserImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxUserImage.Image = global::ProlecGE.ControlPisoMX.Insulations.Forms.Properties.Resources.user_dark;
            this.picBoxUserImage.Location = new System.Drawing.Point(858, 5);
            this.picBoxUserImage.Name = "picBoxUserImage";
            this.picBoxUserImage.Size = new System.Drawing.Size(40, 40);
            this.picBoxUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBoxUserImage.TabIndex = 45;
            this.picBoxUserImage.TabStop = false;
            // 
            // InsOrderFabrication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 661);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picBoxUserImage);
            this.Controls.Add(this.picBoxSubTitleLine);
            this.Controls.Add(this.picBoxEnterpriseLogo);
            this.Controls.Add(this.lblNoOrder);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.lblLodingItems);
            this.Controls.Add(this.lblConnectionMessage);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "InsOrderFabrication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Requerimiento de fabricación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InsOrderFabrication_Load);
            this.Resize += new System.EventHandler(this.InsOrderFabrication_Resize);
            this.gbLapsedTime.ResumeLayout(false);
            this.gbLapsedTime.PerformLayout();
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSubTitleLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.GroupBox gbLapsedTime;
        private System.Windows.Forms.Label lblTimeLapse;
        private System.Windows.Forms.Label lblItemValue;
        private System.Windows.Forms.Label lblQuantityValue;
        private System.Windows.Forms.Label lblMachineValue;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel pnlControls;
        private Label lblNoOrder;
        private Label lblLodingItems;
        private Label lblConnectionMessage;
        private Button btnFinishWork;
        private PictureBox picBoxSubTitleLine;
        private PictureBox picBoxEnterpriseLogo;
        private Label lblUserName;
        private PictureBox picBoxUserImage;
    }
}