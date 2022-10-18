
namespace ProlecGE.ControlPisoMX.Cores.Testing.Industrial.Forms
{
    partial class IndustrialCoreTesterForm
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
            this.components = new System.ComponentModel.Container();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbInformation = new System.Windows.Forms.GroupBox();
            this.txtBatch = new System.Windows.Forms.MaskedTextBox();
            this.txtSerie = new System.Windows.Forms.MaskedTextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.lblOrder = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.lblBatch = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblDonutSize = new System.Windows.Forms.Label();
            this.cmbDonutSize = new System.Windows.Forms.ComboBox();
            this.lblFoilWidth = new System.Windows.Forms.Label();
            this.cmbFoilWidth = new System.Windows.Forms.ComboBox();
            this.lblPieceNumber = new System.Windows.Forms.Label();
            this.lblPieceNumberValue = new System.Windows.Forms.Label();
            this.pbFindCore = new System.Windows.Forms.ProgressBar();
            this.gbCode = new System.Windows.Forms.GroupBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblCodeFieldSize = new System.Windows.Forms.Label();
            this.txtTestCode = new System.Windows.Forms.TextBox();
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.lblCorrectedWatts = new System.Windows.Forms.Label();
            this.lblCurrentValue2 = new System.Windows.Forms.Label();
            this.lblCorrectedWattsValue = new System.Windows.Forms.Label();
            this.lblCurrent2 = new System.Windows.Forms.Label();
            this.lblTestNumber = new System.Windows.Forms.Label();
            this.lblCurrentPercentageValue = new System.Windows.Forms.Label();
            this.lblResultValue = new System.Windows.Forms.Label();
            this.lblCurrentPercentage = new System.Windows.Forms.Label();
            this.lblTestNumberValue = new System.Windows.Forms.Label();
            this.lblCoreTemp = new System.Windows.Forms.Label();
            this.lblCoreTempValue = new System.Windows.Forms.Label();
            this.gbItemDesign = new System.Windows.Forms.GroupBox();
            this.lblTestVoltageValue = new System.Windows.Forms.Label();
            this.lblTestVoltage = new System.Windows.Forms.Label();
            this.lblSecondaryVoltageValue = new System.Windows.Forms.Label();
            this.lblSecondaryVoltage = new System.Windows.Forms.Label();
            this.lblPrimaryVoltageValue = new System.Windows.Forms.Label();
            this.lblPrimaryVoltage = new System.Windows.Forms.Label();
            this.lblKVAValue = new System.Windows.Forms.Label();
            this.lblKVA = new System.Windows.Forms.Label();
            this.lblLaboratory = new System.Windows.Forms.Label();
            this.gbWattsLimits = new System.Windows.Forms.GroupBox();
            this.lblColorRangeTitle = new System.Windows.Forms.Label();
            this.lblMaxRangeTitle = new System.Windows.Forms.Label();
            this.lblAzulMax = new System.Windows.Forms.Label();
            this.lblMinRangeTitle = new System.Windows.Forms.Label();
            this.lblAzulMin = new System.Windows.Forms.Label();
            this.gbItemVoltages = new System.Windows.Forms.GroupBox();
            this.lblWatsValue = new System.Windows.Forms.Label();
            this.lblTemperatureValue = new System.Windows.Forms.Label();
            this.lblCurrentValue = new System.Windows.Forms.Label();
            this.lblRMSVoltageValue = new System.Windows.Forms.Label();
            this.lblAverageVoltageValue = new System.Windows.Forms.Label();
            this.lblWatts = new System.Windows.Forms.Label();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblRMSVoltage = new System.Windows.Forms.Label();
            this.lblAverageVoltage = new System.Windows.Forms.Label();
            this.epForm = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbInformation.SuspendLayout();
            this.gbCode.SuspendLayout();
            this.gbResults.SuspendLayout();
            this.gbItemDesign.SuspendLayout();
            this.gbWattsLimits.SuspendLayout();
            this.gbItemVoltages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epForm)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(409, 592);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 26);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // gbInformation
            // 
            this.gbInformation.Controls.Add(this.txtBatch);
            this.gbInformation.Controls.Add(this.txtSerie);
            this.gbInformation.Controls.Add(this.btnFind);
            this.gbInformation.Controls.Add(this.lblOrder);
            this.gbInformation.Controls.Add(this.txtOrder);
            this.gbInformation.Controls.Add(this.lblBatch);
            this.gbInformation.Controls.Add(this.lblSerie);
            this.gbInformation.Controls.Add(this.lblDonutSize);
            this.gbInformation.Controls.Add(this.cmbDonutSize);
            this.gbInformation.Controls.Add(this.lblFoilWidth);
            this.gbInformation.Controls.Add(this.cmbFoilWidth);
            this.gbInformation.Controls.Add(this.lblPieceNumber);
            this.gbInformation.Controls.Add(this.lblPieceNumberValue);
            this.gbInformation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.gbInformation.Location = new System.Drawing.Point(10, 10);
            this.gbInformation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbInformation.Size = new System.Drawing.Size(235, 270);
            this.gbInformation.TabIndex = 1;
            this.gbInformation.TabStop = false;
            this.gbInformation.Text = "Información del Núcleo";
            // 
            // txtBatch
            // 
            this.txtBatch.HidePromptOnLeave = true;
            this.txtBatch.Location = new System.Drawing.Point(119, 39);
            this.txtBatch.Mask = "000";
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(50, 23);
            this.txtBatch.TabIndex = 2;
            this.txtBatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBatch_KeyPress);
            this.txtBatch.Leave += new System.EventHandler(this.TxtBatch_Leave);
            // 
            // txtSerie
            // 
            this.txtSerie.HidePromptOnLeave = true;
            this.txtSerie.Location = new System.Drawing.Point(175, 40);
            this.txtSerie.Mask = "99999";
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(50, 23);
            this.txtSerie.TabIndex = 3;
            this.txtSerie.ValidatingType = typeof(int);
            this.txtSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSerie_KeyPress);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.White;
            this.btnFind.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.btnFind.Location = new System.Drawing.Point(78, 135);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(78, 26);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "Buscar";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(10, 20);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(40, 15);
            this.lblOrder.TabIndex = 0;
            this.lblOrder.Text = "Orden";
            // 
            // txtOrder
            // 
            this.txtOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.epForm.SetIconPadding(this.txtOrder, -20);
            this.txtOrder.Location = new System.Drawing.Point(10, 38);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(103, 23);
            this.txtOrder.TabIndex = 1;
            this.txtOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtOrder_KeyPress);
            this.txtOrder.Leave += new System.EventHandler(this.TxtOrder_Leave);
            this.txtOrder.Validating += new System.ComponentModel.CancelEventHandler(this.TxtOrder_Validating);
            this.txtOrder.Validated += new System.EventHandler(this.TxtOrder_Validated);
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.Location = new System.Drawing.Point(119, 20);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(30, 15);
            this.lblBatch.TabIndex = 2;
            this.lblBatch.Text = "Lote";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(175, 20);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(32, 15);
            this.lblSerie.TabIndex = 4;
            this.lblSerie.Text = "Serie";
            // 
            // lblDonutSize
            // 
            this.lblDonutSize.AutoSize = true;
            this.lblDonutSize.Location = new System.Drawing.Point(10, 80);
            this.lblDonutSize.Name = "lblDonutSize";
            this.lblDonutSize.Size = new System.Drawing.Size(95, 15);
            this.lblDonutSize.TabIndex = 6;
            this.lblDonutSize.Text = "Tamaño de dona";
            // 
            // cmbDonutSize
            // 
            this.cmbDonutSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDonutSize.Enabled = false;
            this.cmbDonutSize.FormattingEnabled = true;
            this.cmbDonutSize.Items.AddRange(new object[] {
            "CHICA",
            "GRANDE"});
            this.cmbDonutSize.Location = new System.Drawing.Point(10, 98);
            this.cmbDonutSize.Name = "cmbDonutSize";
            this.cmbDonutSize.Size = new System.Drawing.Size(103, 23);
            this.cmbDonutSize.TabIndex = 4;
            this.cmbDonutSize.SelectedIndexChanged += new System.EventHandler(this.CmbDonutSize_SelectedIndexChanged);
            // 
            // lblFoilWidth
            // 
            this.lblFoilWidth.AutoSize = true;
            this.lblFoilWidth.Location = new System.Drawing.Point(119, 80);
            this.lblFoilWidth.Name = "lblFoilWidth";
            this.lblFoilWidth.Size = new System.Drawing.Size(97, 15);
            this.lblFoilWidth.TabIndex = 8;
            this.lblFoilWidth.Text = "Ancho de lámina";
            // 
            // cmbFoilWidth
            // 
            this.cmbFoilWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFoilWidth.Enabled = false;
            this.cmbFoilWidth.FormattingEnabled = true;
            this.cmbFoilWidth.Location = new System.Drawing.Point(119, 98);
            this.cmbFoilWidth.Name = "cmbFoilWidth";
            this.cmbFoilWidth.Size = new System.Drawing.Size(106, 23);
            this.cmbFoilWidth.TabIndex = 5;
            // 
            // lblPieceNumber
            // 
            this.lblPieceNumber.AutoSize = true;
            this.lblPieceNumber.Location = new System.Drawing.Point(10, 178);
            this.lblPieceNumber.Name = "lblPieceNumber";
            this.lblPieceNumber.Size = new System.Drawing.Size(97, 15);
            this.lblPieceNumber.TabIndex = 10;
            this.lblPieceNumber.Text = "Piezas aprobadas";
            // 
            // lblPieceNumberValue
            // 
            this.lblPieceNumberValue.AutoSize = true;
            this.lblPieceNumberValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPieceNumberValue.Location = new System.Drawing.Point(199, 178);
            this.lblPieceNumberValue.Name = "lblPieceNumberValue";
            this.lblPieceNumberValue.Size = new System.Drawing.Size(26, 15);
            this.lblPieceNumberValue.TabIndex = 11;
            this.lblPieceNumberValue.Text = "0/0";
            // 
            // pbFindCore
            // 
            this.pbFindCore.Enabled = false;
            this.pbFindCore.Location = new System.Drawing.Point(0, 0);
            this.pbFindCore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbFindCore.Name = "pbFindCore";
            this.pbFindCore.Size = new System.Drawing.Size(758, 10);
            this.pbFindCore.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbFindCore.TabIndex = 0;
            this.pbFindCore.Visible = false;
            // 
            // gbCode
            // 
            this.gbCode.Controls.Add(this.lblCodigo);
            this.gbCode.Controls.Add(this.lblCodeFieldSize);
            this.gbCode.Controls.Add(this.txtTestCode);
            this.gbCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.gbCode.Location = new System.Drawing.Point(251, 10);
            this.gbCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbCode.Name = "gbCode";
            this.gbCode.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbCode.Size = new System.Drawing.Size(235, 77);
            this.gbCode.TabIndex = 2;
            this.gbCode.TabStop = false;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.lblCodigo.Location = new System.Drawing.Point(9, 18);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(49, 15);
            this.lblCodigo.TabIndex = 10;
            this.lblCodigo.Text = "Código:";
            // 
            // lblCodeFieldSize
            // 
            this.lblCodeFieldSize.AutoSize = true;
            this.lblCodeFieldSize.Location = new System.Drawing.Point(203, 41);
            this.lblCodeFieldSize.Name = "lblCodeFieldSize";
            this.lblCodeFieldSize.Size = new System.Drawing.Size(24, 15);
            this.lblCodeFieldSize.TabIndex = 59;
            this.lblCodeFieldSize.Text = "0/8";
            // 
            // txtTestCode
            // 
            this.txtTestCode.Enabled = false;
            this.txtTestCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.epForm.SetIconPadding(this.txtTestCode, -20);
            this.txtTestCode.Location = new System.Drawing.Point(9, 39);
            this.txtTestCode.Name = "txtTestCode";
            this.txtTestCode.Size = new System.Drawing.Size(186, 23);
            this.txtTestCode.TabIndex = 7;
            this.txtTestCode.TextChanged += new System.EventHandler(this.TxtTestCode_TextChanged);
            this.txtTestCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTestCode_KeyPress);
            this.txtTestCode.Validating += new System.ComponentModel.CancelEventHandler(this.TxtTestCode_Validating);
            this.txtTestCode.Validated += new System.EventHandler(this.TxtTestCode_Validated);
            // 
            // gbResults
            // 
            this.gbResults.Controls.Add(this.lblCorrectedWatts);
            this.gbResults.Controls.Add(this.lblCurrentValue2);
            this.gbResults.Controls.Add(this.lblCorrectedWattsValue);
            this.gbResults.Controls.Add(this.lblCurrent2);
            this.gbResults.Controls.Add(this.lblTestNumber);
            this.gbResults.Controls.Add(this.lblCurrentPercentageValue);
            this.gbResults.Controls.Add(this.lblResultValue);
            this.gbResults.Controls.Add(this.lblCurrentPercentage);
            this.gbResults.Controls.Add(this.lblTestNumberValue);
            this.gbResults.Controls.Add(this.lblCoreTemp);
            this.gbResults.Controls.Add(this.lblCoreTempValue);
            this.gbResults.Location = new System.Drawing.Point(252, 285);
            this.gbResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbResults.Name = "gbResults";
            this.gbResults.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbResults.Size = new System.Drawing.Size(235, 300);
            this.gbResults.TabIndex = 69;
            this.gbResults.TabStop = false;
            this.gbResults.Text = "Resultados";
            // 
            // lblCorrectedWatts
            // 
            this.lblCorrectedWatts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCorrectedWatts.Location = new System.Drawing.Point(10, 22);
            this.lblCorrectedWatts.Name = "lblCorrectedWatts";
            this.lblCorrectedWatts.Size = new System.Drawing.Size(114, 48);
            this.lblCorrectedWatts.TabIndex = 66;
            this.lblCorrectedWatts.Text = "WATTS CORREGIDOS A 20°C";
            this.lblCorrectedWatts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrentValue2
            // 
            this.lblCurrentValue2.BackColor = System.Drawing.Color.White;
            this.lblCurrentValue2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentValue2.Location = new System.Drawing.Point(153, 87);
            this.lblCurrentValue2.Name = "lblCurrentValue2";
            this.lblCurrentValue2.Size = new System.Drawing.Size(70, 22);
            this.lblCurrentValue2.TabIndex = 69;
            this.lblCurrentValue2.Text = "50";
            this.lblCurrentValue2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCorrectedWattsValue
            // 
            this.lblCorrectedWattsValue.BackColor = System.Drawing.Color.White;
            this.lblCorrectedWattsValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCorrectedWattsValue.Location = new System.Drawing.Point(153, 35);
            this.lblCorrectedWattsValue.Name = "lblCorrectedWattsValue";
            this.lblCorrectedWattsValue.Size = new System.Drawing.Size(70, 22);
            this.lblCorrectedWattsValue.TabIndex = 68;
            this.lblCorrectedWattsValue.Text = "1000";
            this.lblCorrectedWattsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrent2
            // 
            this.lblCurrent2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrent2.Location = new System.Drawing.Point(10, 88);
            this.lblCurrent2.Name = "lblCurrent2";
            this.lblCurrent2.Size = new System.Drawing.Size(114, 21);
            this.lblCurrent2.TabIndex = 67;
            this.lblCurrent2.Text = "CORRIENTE";
            this.lblCurrent2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTestNumber
            // 
            this.lblTestNumber.AutoSize = true;
            this.lblTestNumber.Location = new System.Drawing.Point(87, 271);
            this.lblTestNumber.Name = "lblTestNumber";
            this.lblTestNumber.Size = new System.Drawing.Size(61, 15);
            this.lblTestNumber.TabIndex = 4;
            this.lblTestNumber.Text = "N° prueba";
            // 
            // lblCurrentPercentageValue
            // 
            this.lblCurrentPercentageValue.BackColor = System.Drawing.Color.White;
            this.lblCurrentPercentageValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentPercentageValue.Location = new System.Drawing.Point(153, 133);
            this.lblCurrentPercentageValue.Name = "lblCurrentPercentageValue";
            this.lblCurrentPercentageValue.Size = new System.Drawing.Size(70, 22);
            this.lblCurrentPercentageValue.TabIndex = 65;
            this.lblCurrentPercentageValue.Text = "100%";
            this.lblCurrentPercentageValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResultValue
            // 
            this.lblResultValue.BackColor = System.Drawing.Color.White;
            this.lblResultValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResultValue.ForeColor = System.Drawing.Color.Red;
            this.lblResultValue.Location = new System.Drawing.Point(10, 210);
            this.lblResultValue.Name = "lblResultValue";
            this.lblResultValue.Size = new System.Drawing.Size(215, 20);
            this.lblResultValue.TabIndex = 5;
            this.lblResultValue.Text = "RECHAZADO";
            this.lblResultValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentPercentage
            // 
            this.lblCurrentPercentage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentPercentage.Location = new System.Drawing.Point(10, 127);
            this.lblCurrentPercentage.Name = "lblCurrentPercentage";
            this.lblCurrentPercentage.Size = new System.Drawing.Size(114, 34);
            this.lblCurrentPercentage.TabIndex = 64;
            this.lblCurrentPercentage.Text = "PORCENTAJE DE CORRIENTE";
            this.lblCurrentPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTestNumberValue
            // 
            this.lblTestNumberValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTestNumberValue.Location = new System.Drawing.Point(93, 241);
            this.lblTestNumberValue.Name = "lblTestNumberValue";
            this.lblTestNumberValue.Size = new System.Drawing.Size(48, 20);
            this.lblTestNumberValue.TabIndex = 7;
            this.lblTestNumberValue.Text = "0";
            this.lblTestNumberValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCoreTemp
            // 
            this.lblCoreTemp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCoreTemp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.lblCoreTemp.Location = new System.Drawing.Point(10, 179);
            this.lblCoreTemp.Name = "lblCoreTemp";
            this.lblCoreTemp.Size = new System.Drawing.Size(114, 22);
            this.lblCoreTemp.TabIndex = 31;
            this.lblCoreTemp.Text = "TEMP IR";
            this.lblCoreTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCoreTempValue
            // 
            this.lblCoreTempValue.BackColor = System.Drawing.Color.White;
            this.lblCoreTempValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCoreTempValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.lblCoreTempValue.Location = new System.Drawing.Point(153, 179);
            this.lblCoreTempValue.Name = "lblCoreTempValue";
            this.lblCoreTempValue.Size = new System.Drawing.Size(70, 22);
            this.lblCoreTempValue.TabIndex = 63;
            this.lblCoreTempValue.Text = "100°";
            this.lblCoreTempValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbItemDesign
            // 
            this.gbItemDesign.Controls.Add(this.lblTestVoltageValue);
            this.gbItemDesign.Controls.Add(this.lblTestVoltage);
            this.gbItemDesign.Controls.Add(this.lblSecondaryVoltageValue);
            this.gbItemDesign.Controls.Add(this.lblSecondaryVoltage);
            this.gbItemDesign.Controls.Add(this.lblPrimaryVoltageValue);
            this.gbItemDesign.Controls.Add(this.lblPrimaryVoltage);
            this.gbItemDesign.Controls.Add(this.lblKVAValue);
            this.gbItemDesign.Controls.Add(this.lblKVA);
            this.gbItemDesign.Controls.Add(this.lblLaboratory);
            this.gbItemDesign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.gbItemDesign.Location = new System.Drawing.Point(11, 285);
            this.gbItemDesign.Name = "gbItemDesign";
            this.gbItemDesign.Size = new System.Drawing.Size(235, 168);
            this.gbItemDesign.TabIndex = 67;
            this.gbItemDesign.TabStop = false;
            this.gbItemDesign.Text = "Valores de diseño";
            // 
            // lblTestVoltageValue
            // 
            this.lblTestVoltageValue.BackColor = System.Drawing.Color.White;
            this.lblTestVoltageValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTestVoltageValue.Location = new System.Drawing.Point(174, 136);
            this.lblTestVoltageValue.MaximumSize = new System.Drawing.Size(50, 15);
            this.lblTestVoltageValue.Name = "lblTestVoltageValue";
            this.lblTestVoltageValue.Size = new System.Drawing.Size(50, 15);
            this.lblTestVoltageValue.TabIndex = 0;
            this.lblTestVoltageValue.Text = "0";
            this.lblTestVoltageValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTestVoltage
            // 
            this.lblTestVoltage.AutoSize = true;
            this.lblTestVoltage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTestVoltage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.lblTestVoltage.Location = new System.Drawing.Point(10, 136);
            this.lblTestVoltage.Name = "lblTestVoltage";
            this.lblTestVoltage.Size = new System.Drawing.Size(72, 15);
            this.lblTestVoltage.TabIndex = 1;
            this.lblTestVoltage.Text = "Ten. Prueba";
            // 
            // lblSecondaryVoltageValue
            // 
            this.lblSecondaryVoltageValue.BackColor = System.Drawing.Color.White;
            this.lblSecondaryVoltageValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSecondaryVoltageValue.Location = new System.Drawing.Point(174, 104);
            this.lblSecondaryVoltageValue.MaximumSize = new System.Drawing.Size(50, 15);
            this.lblSecondaryVoltageValue.Name = "lblSecondaryVoltageValue";
            this.lblSecondaryVoltageValue.Size = new System.Drawing.Size(50, 15);
            this.lblSecondaryVoltageValue.TabIndex = 2;
            this.lblSecondaryVoltageValue.Text = "0";
            this.lblSecondaryVoltageValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecondaryVoltage
            // 
            this.lblSecondaryVoltage.AutoSize = true;
            this.lblSecondaryVoltage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSecondaryVoltage.Location = new System.Drawing.Point(10, 104);
            this.lblSecondaryVoltage.Name = "lblSecondaryVoltage";
            this.lblSecondaryVoltage.Size = new System.Drawing.Size(94, 15);
            this.lblSecondaryVoltage.TabIndex = 3;
            this.lblSecondaryVoltage.Text = "Ten. Secundaria";
            // 
            // lblPrimaryVoltageValue
            // 
            this.lblPrimaryVoltageValue.BackColor = System.Drawing.Color.White;
            this.lblPrimaryVoltageValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrimaryVoltageValue.Location = new System.Drawing.Point(174, 72);
            this.lblPrimaryVoltageValue.MaximumSize = new System.Drawing.Size(50, 15);
            this.lblPrimaryVoltageValue.Name = "lblPrimaryVoltageValue";
            this.lblPrimaryVoltageValue.Size = new System.Drawing.Size(50, 15);
            this.lblPrimaryVoltageValue.TabIndex = 4;
            this.lblPrimaryVoltageValue.Text = "0";
            this.lblPrimaryVoltageValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrimaryVoltage
            // 
            this.lblPrimaryVoltage.AutoSize = true;
            this.lblPrimaryVoltage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPrimaryVoltage.Location = new System.Drawing.Point(10, 72);
            this.lblPrimaryVoltage.Name = "lblPrimaryVoltage";
            this.lblPrimaryVoltage.Size = new System.Drawing.Size(79, 15);
            this.lblPrimaryVoltage.TabIndex = 5;
            this.lblPrimaryVoltage.Text = "Ten. Primaria";
            // 
            // lblKVAValue
            // 
            this.lblKVAValue.BackColor = System.Drawing.Color.White;
            this.lblKVAValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKVAValue.Location = new System.Drawing.Point(174, 42);
            this.lblKVAValue.MaximumSize = new System.Drawing.Size(50, 15);
            this.lblKVAValue.Name = "lblKVAValue";
            this.lblKVAValue.Size = new System.Drawing.Size(50, 15);
            this.lblKVAValue.TabIndex = 6;
            this.lblKVAValue.Text = "0";
            this.lblKVAValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKVA
            // 
            this.lblKVA.AutoSize = true;
            this.lblKVA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKVA.Location = new System.Drawing.Point(10, 40);
            this.lblKVA.Name = "lblKVA";
            this.lblKVA.Size = new System.Drawing.Size(30, 15);
            this.lblKVA.TabIndex = 7;
            this.lblKVA.Text = "KVA";
            // 
            // lblLaboratory
            // 
            this.lblLaboratory.AutoSize = true;
            this.lblLaboratory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLaboratory.Location = new System.Drawing.Point(69, 20);
            this.lblLaboratory.Name = "lblLaboratory";
            this.lblLaboratory.Size = new System.Drawing.Size(90, 15);
            this.lblLaboratory.TabIndex = 8;
            this.lblLaboratory.Text = "LABORATORIO";
            this.lblLaboratory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbWattsLimits
            // 
            this.gbWattsLimits.Controls.Add(this.lblColorRangeTitle);
            this.gbWattsLimits.Controls.Add(this.lblMaxRangeTitle);
            this.gbWattsLimits.Controls.Add(this.lblAzulMax);
            this.gbWattsLimits.Controls.Add(this.lblMinRangeTitle);
            this.gbWattsLimits.Controls.Add(this.lblAzulMin);
            this.gbWattsLimits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.gbWattsLimits.Location = new System.Drawing.Point(11, 460);
            this.gbWattsLimits.Name = "gbWattsLimits";
            this.gbWattsLimits.Size = new System.Drawing.Size(235, 125);
            this.gbWattsLimits.TabIndex = 66;
            this.gbWattsLimits.TabStop = false;
            this.gbWattsLimits.Text = "Limites de watts";
            // 
            // lblColorRangeTitle
            // 
            this.lblColorRangeTitle.AutoSize = true;
            this.lblColorRangeTitle.Location = new System.Drawing.Point(10, 30);
            this.lblColorRangeTitle.Name = "lblColorRangeTitle";
            this.lblColorRangeTitle.Size = new System.Drawing.Size(37, 15);
            this.lblColorRangeTitle.TabIndex = 31;
            this.lblColorRangeTitle.Text = "Watts";
            // 
            // lblMaxRangeTitle
            // 
            this.lblMaxRangeTitle.AutoSize = true;
            this.lblMaxRangeTitle.Location = new System.Drawing.Point(184, 30);
            this.lblMaxRangeTitle.Name = "lblMaxRangeTitle";
            this.lblMaxRangeTitle.Size = new System.Drawing.Size(30, 15);
            this.lblMaxRangeTitle.TabIndex = 30;
            this.lblMaxRangeTitle.Text = "Max";
            // 
            // lblAzulMax
            // 
            this.lblAzulMax.BackColor = System.Drawing.Color.White;
            this.lblAzulMax.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAzulMax.Location = new System.Drawing.Point(174, 57);
            this.lblAzulMax.MaximumSize = new System.Drawing.Size(50, 15);
            this.lblAzulMax.Name = "lblAzulMax";
            this.lblAzulMax.Size = new System.Drawing.Size(50, 15);
            this.lblAzulMax.TabIndex = 10;
            this.lblAzulMax.Text = "0";
            this.lblAzulMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinRangeTitle
            // 
            this.lblMinRangeTitle.AutoSize = true;
            this.lblMinRangeTitle.Location = new System.Drawing.Point(111, 30);
            this.lblMinRangeTitle.Name = "lblMinRangeTitle";
            this.lblMinRangeTitle.Size = new System.Drawing.Size(28, 15);
            this.lblMinRangeTitle.TabIndex = 29;
            this.lblMinRangeTitle.Text = "Min";
            // 
            // lblAzulMin
            // 
            this.lblAzulMin.BackColor = System.Drawing.Color.White;
            this.lblAzulMin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAzulMin.Location = new System.Drawing.Point(100, 57);
            this.lblAzulMin.Name = "lblAzulMin";
            this.lblAzulMin.Size = new System.Drawing.Size(50, 15);
            this.lblAzulMin.TabIndex = 9;
            this.lblAzulMin.Text = "00.0";
            this.lblAzulMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbItemVoltages
            // 
            this.gbItemVoltages.Controls.Add(this.lblWatsValue);
            this.gbItemVoltages.Controls.Add(this.lblTemperatureValue);
            this.gbItemVoltages.Controls.Add(this.lblCurrentValue);
            this.gbItemVoltages.Controls.Add(this.lblRMSVoltageValue);
            this.gbItemVoltages.Controls.Add(this.lblAverageVoltageValue);
            this.gbItemVoltages.Controls.Add(this.lblWatts);
            this.gbItemVoltages.Controls.Add(this.lblTemperature);
            this.gbItemVoltages.Controls.Add(this.lblCurrent);
            this.gbItemVoltages.Controls.Add(this.lblRMSVoltage);
            this.gbItemVoltages.Controls.Add(this.lblAverageVoltage);
            this.gbItemVoltages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.gbItemVoltages.Location = new System.Drawing.Point(251, 90);
            this.gbItemVoltages.Name = "gbItemVoltages";
            this.gbItemVoltages.Size = new System.Drawing.Size(235, 190);
            this.gbItemVoltages.TabIndex = 70;
            this.gbItemVoltages.TabStop = false;
            this.gbItemVoltages.Text = "Valores medidos";
            // 
            // lblWatsValue
            // 
            this.lblWatsValue.BackColor = System.Drawing.Color.White;
            this.lblWatsValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWatsValue.Location = new System.Drawing.Point(173, 158);
            this.lblWatsValue.MaximumSize = new System.Drawing.Size(50, 15);
            this.lblWatsValue.Name = "lblWatsValue";
            this.lblWatsValue.Size = new System.Drawing.Size(50, 15);
            this.lblWatsValue.TabIndex = 0;
            this.lblWatsValue.Text = "0";
            this.lblWatsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTemperatureValue
            // 
            this.lblTemperatureValue.BackColor = System.Drawing.Color.White;
            this.lblTemperatureValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTemperatureValue.Location = new System.Drawing.Point(173, 126);
            this.lblTemperatureValue.MaximumSize = new System.Drawing.Size(50, 15);
            this.lblTemperatureValue.Name = "lblTemperatureValue";
            this.lblTemperatureValue.Size = new System.Drawing.Size(50, 15);
            this.lblTemperatureValue.TabIndex = 1;
            this.lblTemperatureValue.Text = "0";
            this.lblTemperatureValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentValue
            // 
            this.lblCurrentValue.BackColor = System.Drawing.Color.White;
            this.lblCurrentValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentValue.Location = new System.Drawing.Point(173, 94);
            this.lblCurrentValue.MaximumSize = new System.Drawing.Size(50, 15);
            this.lblCurrentValue.Name = "lblCurrentValue";
            this.lblCurrentValue.Size = new System.Drawing.Size(50, 15);
            this.lblCurrentValue.TabIndex = 2;
            this.lblCurrentValue.Text = "0";
            this.lblCurrentValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRMSVoltageValue
            // 
            this.lblRMSVoltageValue.BackColor = System.Drawing.Color.White;
            this.lblRMSVoltageValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRMSVoltageValue.Location = new System.Drawing.Point(173, 62);
            this.lblRMSVoltageValue.MaximumSize = new System.Drawing.Size(50, 15);
            this.lblRMSVoltageValue.Name = "lblRMSVoltageValue";
            this.lblRMSVoltageValue.Size = new System.Drawing.Size(50, 15);
            this.lblRMSVoltageValue.TabIndex = 3;
            this.lblRMSVoltageValue.Text = "0";
            this.lblRMSVoltageValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAverageVoltageValue
            // 
            this.lblAverageVoltageValue.BackColor = System.Drawing.Color.White;
            this.lblAverageVoltageValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAverageVoltageValue.Location = new System.Drawing.Point(173, 30);
            this.lblAverageVoltageValue.MaximumSize = new System.Drawing.Size(50, 15);
            this.lblAverageVoltageValue.Name = "lblAverageVoltageValue";
            this.lblAverageVoltageValue.Size = new System.Drawing.Size(50, 15);
            this.lblAverageVoltageValue.TabIndex = 4;
            this.lblAverageVoltageValue.Text = "0";
            this.lblAverageVoltageValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWatts
            // 
            this.lblWatts.AutoSize = true;
            this.lblWatts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWatts.Location = new System.Drawing.Point(10, 158);
            this.lblWatts.Name = "lblWatts";
            this.lblWatts.Size = new System.Drawing.Size(47, 15);
            this.lblWatts.TabIndex = 5;
            this.lblWatts.Text = "WATTS";
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTemperature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.lblTemperature.Location = new System.Drawing.Point(10, 126);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(91, 15);
            this.lblTemperature.TabIndex = 6;
            this.lblTemperature.Text = "TEMPERATURA";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrent.Location = new System.Drawing.Point(10, 94);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(71, 15);
            this.lblCurrent.TabIndex = 7;
            this.lblCurrent.Text = "CORRIENTE";
            // 
            // lblRMSVoltage
            // 
            this.lblRMSVoltage.AutoSize = true;
            this.lblRMSVoltage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRMSVoltage.Location = new System.Drawing.Point(10, 62);
            this.lblRMSVoltage.Name = "lblRMSVoltage";
            this.lblRMSVoltage.Size = new System.Drawing.Size(136, 15);
            this.lblRMSVoltage.TabIndex = 8;
            this.lblRMSVoltage.Text = "(RMS) TENSION EFICAZ";
            // 
            // lblAverageVoltage
            // 
            this.lblAverageVoltage.AutoSize = true;
            this.lblAverageVoltage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAverageVoltage.Location = new System.Drawing.Point(10, 30);
            this.lblAverageVoltage.Name = "lblAverageVoltage";
            this.lblAverageVoltage.Size = new System.Drawing.Size(134, 15);
            this.lblAverageVoltage.TabIndex = 9;
            this.lblAverageVoltage.Text = "(AVG) TENSION MEDIA";
            // 
            // epForm
            // 
            this.epForm.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.epForm.ContainerControl = this;
            // 
            // IndustrialCoreTesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(494, 626);
            this.Controls.Add(this.gbItemVoltages);
            this.Controls.Add(this.gbResults);
            this.Controls.Add(this.gbItemDesign);
            this.Controls.Add(this.gbWattsLimits);
            this.Controls.Add(this.pbFindCore);
            this.Controls.Add(this.gbInformation);
            this.Controls.Add(this.gbCode);
            this.Controls.Add(this.btnClose);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IndustrialCoreTesterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Probador TIR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.gbInformation.ResumeLayout(false);
            this.gbInformation.PerformLayout();
            this.gbCode.ResumeLayout(false);
            this.gbCode.PerformLayout();
            this.gbResults.ResumeLayout(false);
            this.gbResults.PerformLayout();
            this.gbItemDesign.ResumeLayout(false);
            this.gbItemDesign.PerformLayout();
            this.gbWattsLimits.ResumeLayout(false);
            this.gbWattsLimits.PerformLayout();
            this.gbItemVoltages.ResumeLayout(false);
            this.gbItemVoltages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbInformation;
        private System.Windows.Forms.Label lblPieceNumberValue;
        private System.Windows.Forms.Label lblPieceNumber;
        private System.Windows.Forms.ProgressBar pbFindCore;
        private System.Windows.Forms.Label lblFoilWidth;
        private System.Windows.Forms.Label lblDonutSize;
        private System.Windows.Forms.ComboBox cmbFoilWidth;
        private System.Windows.Forms.ComboBox cmbDonutSize;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Label lblBatch;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.GroupBox gbCode;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblCodeFieldSize;
        private System.Windows.Forms.TextBox txtTestCode;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.GroupBox gbResults;
        private System.Windows.Forms.Label lblCorrectedWatts;
        private System.Windows.Forms.Label lblCurrentValue2;
        private System.Windows.Forms.Label lblCorrectedWattsValue;
        private System.Windows.Forms.Label lblCurrent2;
        private System.Windows.Forms.Label lblTestNumber;
        private System.Windows.Forms.Label lblCurrentPercentageValue;
        private System.Windows.Forms.Label lblResultValue;
        private System.Windows.Forms.Label lblCurrentPercentage;
        private System.Windows.Forms.Label lblTestNumberValue;
        private System.Windows.Forms.Label lblCoreTemp;
        private System.Windows.Forms.Label lblCoreTempValue;
        private System.Windows.Forms.GroupBox gbItemDesign;
        private System.Windows.Forms.Label lblTestVoltageValue;
        private System.Windows.Forms.Label lblTestVoltage;
        private System.Windows.Forms.Label lblSecondaryVoltageValue;
        private System.Windows.Forms.Label lblSecondaryVoltage;
        private System.Windows.Forms.Label lblPrimaryVoltageValue;
        private System.Windows.Forms.Label lblPrimaryVoltage;
        private System.Windows.Forms.Label lblKVAValue;
        private System.Windows.Forms.Label lblKVA;
        private System.Windows.Forms.Label lblLaboratory;
        private System.Windows.Forms.GroupBox gbWattsLimits;
        private System.Windows.Forms.Label lblColorRangeTitle;
        private System.Windows.Forms.Label lblMaxRangeTitle;
        private System.Windows.Forms.Label lblAzulMax;
        private System.Windows.Forms.Label lblMinRangeTitle;
        private System.Windows.Forms.Label lblAzulMin;
        private System.Windows.Forms.GroupBox gbItemVoltages;
        private System.Windows.Forms.Label lblWatsValue;
        private System.Windows.Forms.Label lblTemperatureValue;
        private System.Windows.Forms.Label lblCurrentValue;
        private System.Windows.Forms.Label lblRMSVoltageValue;
        private System.Windows.Forms.Label lblAverageVoltageValue;
        private System.Windows.Forms.Label lblWatts;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblRMSVoltage;
        private System.Windows.Forms.Label lblAverageVoltage;
        private System.Windows.Forms.MaskedTextBox txtSerie;
        private System.Windows.Forms.MaskedTextBox txtBatch;
        private System.Windows.Forms.ErrorProvider epForm;
    }
}