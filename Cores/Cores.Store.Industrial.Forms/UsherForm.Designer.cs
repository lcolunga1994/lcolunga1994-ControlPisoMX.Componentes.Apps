namespace ProlecGE.ControlPisoMX.Cores.Storing.Industrial.Forms
{
    partial class UsherForm
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
            this.lblCodeFieldSize = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtTestCode = new System.Windows.Forms.TextBox();
            this.pbFindCore = new System.Windows.Forms.ProgressBar();
            this.btnExit = new System.Windows.Forms.Button();
            this.gbFind = new System.Windows.Forms.GroupBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.gbLocation = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblRackLocation = new System.Windows.Forms.Label();
            this.txtRackLocation = new System.Windows.Forms.TextBox();
            this.lblRackLocationSize = new System.Windows.Forms.Label();
            this.lblConfirmationCode = new System.Windows.Forms.Label();
            this.txtConfirmationTestCode = new System.Windows.Forms.TextBox();
            this.lblConfirmationCodeFieldSize = new System.Windows.Forms.Label();
            this.gbSuggestedCode = new System.Windows.Forms.GroupBox();
            this.lblSuggestedTestCode = new System.Windows.Forms.Label();
            this.lblLocationValue = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblSuggestedTestCodeValue = new System.Windows.Forms.Label();
            this.gbCore = new System.Windows.Forms.GroupBox();
            this.lblCorrectedWatts = new System.Windows.Forms.Label();
            this.lblCurrentValue2 = new System.Windows.Forms.Label();
            this.lblCurrentPercentage = new System.Windows.Forms.Label();
            this.lblCurrent2 = new System.Windows.Forms.Label();
            this.lblWattsNewValue = new System.Windows.Forms.Label();
            this.lblColorValue = new System.Windows.Forms.Label();
            this.lblCoreTemp = new System.Windows.Forms.Label();
            this.lblCorrectedWattsValue = new System.Windows.Forms.Label();
            this.lblCoreTempValue = new System.Windows.Forms.Label();
            this.lblResultValue = new System.Windows.Forms.Label();
            this.lblWattsNew = new System.Windows.Forms.Label();
            this.lblCurrentPercentageValue = new System.Windows.Forms.Label();
            this.lblOrderValue = new System.Windows.Forms.Label();
            this.lblCoreSizeValue = new System.Windows.Forms.Label();
            this.lblCoreSize = new System.Windows.Forms.Label();
            this.lblPieceNumberValue = new System.Windows.Forms.Label();
            this.lblPieceNumber = new System.Windows.Forms.Label();
            this.epForm = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFind.SuspendLayout();
            this.gbLocation.SuspendLayout();
            this.gbSuggestedCode.SuspendLayout();
            this.gbCore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epForm)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodeFieldSize
            // 
            this.lblCodeFieldSize.AutoSize = true;
            this.lblCodeFieldSize.Location = new System.Drawing.Point(199, 68);
            this.lblCodeFieldSize.Name = "lblCodeFieldSize";
            this.lblCodeFieldSize.Size = new System.Drawing.Size(24, 15);
            this.lblCodeFieldSize.TabIndex = 59;
            this.lblCodeFieldSize.Text = "0/8";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.lblCodigo.Location = new System.Drawing.Point(10, 25);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(49, 15);
            this.lblCodigo.TabIndex = 10;
            this.lblCodigo.Text = "Código:";
            // 
            // txtTestCode
            // 
            this.txtTestCode.Enabled = false;
            this.txtTestCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.epForm.SetIconPadding(this.txtTestCode, -20);
            this.txtTestCode.Location = new System.Drawing.Point(10, 43);
            this.txtTestCode.Name = "txtTestCode";
            this.txtTestCode.Size = new System.Drawing.Size(215, 23);
            this.txtTestCode.TabIndex = 2;
            this.txtTestCode.TextChanged += new System.EventHandler(this.TxtTestCode_TextChanged);
            this.txtTestCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTestCode_KeyPress);
            this.txtTestCode.Validating += new System.ComponentModel.CancelEventHandler(this.TxtTestCode_Validating);
            this.txtTestCode.Validated += new System.EventHandler(this.TxtTestCode_Validated);
            // 
            // pbFindCore
            // 
            this.pbFindCore.Enabled = false;
            this.pbFindCore.Location = new System.Drawing.Point(0, 0);
            this.pbFindCore.Name = "pbFindCore";
            this.pbFindCore.Size = new System.Drawing.Size(530, 10);
            this.pbFindCore.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbFindCore.TabIndex = 59;
            this.pbFindCore.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.btnExit.Location = new System.Drawing.Point(407, 580);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(78, 28);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // gbFind
            // 
            this.gbFind.Controls.Add(this.btnFind);
            this.gbFind.Controls.Add(this.lblCodeFieldSize);
            this.gbFind.Controls.Add(this.lblCodigo);
            this.gbFind.Controls.Add(this.txtTestCode);
            this.gbFind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.gbFind.Location = new System.Drawing.Point(10, 10);
            this.gbFind.Name = "gbFind";
            this.gbFind.Size = new System.Drawing.Size(235, 148);
            this.gbFind.TabIndex = 1;
            this.gbFind.TabStop = false;
            this.gbFind.Text = "Busqueda";
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.White;
            this.btnFind.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.btnFind.Location = new System.Drawing.Point(78, 94);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(78, 26);
            this.btnFind.TabIndex = 73;
            this.btnFind.Text = "Buscar";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // gbLocation
            // 
            this.gbLocation.Controls.Add(this.btnSave);
            this.gbLocation.Controls.Add(this.lblRackLocation);
            this.gbLocation.Controls.Add(this.txtRackLocation);
            this.gbLocation.Controls.Add(this.lblRackLocationSize);
            this.gbLocation.Controls.Add(this.lblConfirmationCode);
            this.gbLocation.Controls.Add(this.txtConfirmationTestCode);
            this.gbLocation.Controls.Add(this.lblConfirmationCodeFieldSize);
            this.gbLocation.Location = new System.Drawing.Point(250, 159);
            this.gbLocation.Name = "gbLocation";
            this.gbLocation.Size = new System.Drawing.Size(235, 200);
            this.gbLocation.TabIndex = 4;
            this.gbLocation.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(78, 158);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 28);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblRackLocation
            // 
            this.lblRackLocation.AutoSize = true;
            this.lblRackLocation.Location = new System.Drawing.Point(10, 89);
            this.lblRackLocation.Name = "lblRackLocation";
            this.lblRackLocation.Size = new System.Drawing.Size(88, 15);
            this.lblRackLocation.TabIndex = 69;
            this.lblRackLocation.Text = "Ubicación Rack";
            // 
            // txtRackLocation
            // 
            this.txtRackLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRackLocation.Enabled = false;
            this.txtRackLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.epForm.SetIconPadding(this.txtRackLocation, -20);
            this.txtRackLocation.Location = new System.Drawing.Point(10, 109);
            this.txtRackLocation.Name = "txtRackLocation";
            this.txtRackLocation.Size = new System.Drawing.Size(215, 23);
            this.txtRackLocation.TabIndex = 2;
            this.txtRackLocation.TextChanged += new System.EventHandler(this.TxtRackLocation_TextChanged);
            this.txtRackLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtRackLocation_KeyPress);
            this.txtRackLocation.Validating += new System.ComponentModel.CancelEventHandler(this.TxtRackLocation_Validating);
            this.txtRackLocation.Validated += new System.EventHandler(this.TxtRackLocation_Validated);
            // 
            // lblRackLocationSize
            // 
            this.lblRackLocationSize.AutoSize = true;
            this.lblRackLocationSize.Location = new System.Drawing.Point(201, 135);
            this.lblRackLocationSize.Name = "lblRackLocationSize";
            this.lblRackLocationSize.Size = new System.Drawing.Size(24, 15);
            this.lblRackLocationSize.TabIndex = 75;
            this.lblRackLocationSize.Text = "0/8";
            // 
            // lblConfirmationCode
            // 
            this.lblConfirmationCode.AutoSize = true;
            this.lblConfirmationCode.Location = new System.Drawing.Point(10, 25);
            this.lblConfirmationCode.Name = "lblConfirmationCode";
            this.lblConfirmationCode.Size = new System.Drawing.Size(120, 15);
            this.lblConfirmationCode.TabIndex = 1;
            this.lblConfirmationCode.Text = "Código confirmación";
            // 
            // txtConfirmationTestCode
            // 
            this.txtConfirmationTestCode.Enabled = false;
            this.txtConfirmationTestCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.epForm.SetIconPadding(this.txtConfirmationTestCode, -20);
            this.txtConfirmationTestCode.Location = new System.Drawing.Point(10, 43);
            this.txtConfirmationTestCode.Name = "txtConfirmationTestCode";
            this.txtConfirmationTestCode.Size = new System.Drawing.Size(215, 23);
            this.txtConfirmationTestCode.TabIndex = 1;
            this.txtConfirmationTestCode.TextChanged += new System.EventHandler(this.TxtConfirmationTestCode_TextChanged);
            this.txtConfirmationTestCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtConfirmationTestCode_KeyPress);
            this.txtConfirmationTestCode.Validating += new System.ComponentModel.CancelEventHandler(this.TxtConfirmationTestCode_Validating);
            this.txtConfirmationTestCode.Validated += new System.EventHandler(this.TxtConfirmationTestCode_Validated);
            // 
            // lblConfirmationCodeFieldSize
            // 
            this.lblConfirmationCodeFieldSize.AutoSize = true;
            this.lblConfirmationCodeFieldSize.Location = new System.Drawing.Point(201, 68);
            this.lblConfirmationCodeFieldSize.Name = "lblConfirmationCodeFieldSize";
            this.lblConfirmationCodeFieldSize.Size = new System.Drawing.Size(24, 15);
            this.lblConfirmationCodeFieldSize.TabIndex = 66;
            this.lblConfirmationCodeFieldSize.Text = "0/8";
            // 
            // gbSuggestedCode
            // 
            this.gbSuggestedCode.Controls.Add(this.lblSuggestedTestCode);
            this.gbSuggestedCode.Controls.Add(this.lblLocationValue);
            this.gbSuggestedCode.Controls.Add(this.lblLocation);
            this.gbSuggestedCode.Controls.Add(this.lblSuggestedTestCodeValue);
            this.gbSuggestedCode.Location = new System.Drawing.Point(250, 10);
            this.gbSuggestedCode.Name = "gbSuggestedCode";
            this.gbSuggestedCode.Size = new System.Drawing.Size(235, 148);
            this.gbSuggestedCode.TabIndex = 3;
            this.gbSuggestedCode.TabStop = false;
            // 
            // lblSuggestedTestCode
            // 
            this.lblSuggestedTestCode.AutoSize = true;
            this.lblSuggestedTestCode.Location = new System.Drawing.Point(10, 37);
            this.lblSuggestedTestCode.Name = "lblSuggestedTestCode";
            this.lblSuggestedTestCode.Size = new System.Drawing.Size(98, 15);
            this.lblSuggestedTestCode.TabIndex = 43;
            this.lblSuggestedTestCode.Text = "Código sugerido:";
            // 
            // lblLocationValue
            // 
            this.lblLocationValue.AutoSize = true;
            this.lblLocationValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLocationValue.Location = new System.Drawing.Point(122, 106);
            this.lblLocationValue.Name = "lblLocationValue";
            this.lblLocationValue.Size = new System.Drawing.Size(38, 15);
            this.lblLocationValue.TabIndex = 52;
            this.lblLocationValue.Text = "RACK";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(10, 106);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(63, 15);
            this.lblLocation.TabIndex = 44;
            this.lblLocation.Text = "Ubicación:";
            // 
            // lblSuggestedTestCodeValue
            // 
            this.lblSuggestedTestCodeValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSuggestedTestCodeValue.Location = new System.Drawing.Point(122, 37);
            this.lblSuggestedTestCodeValue.Name = "lblSuggestedTestCodeValue";
            this.lblSuggestedTestCodeValue.Size = new System.Drawing.Size(103, 15);
            this.lblSuggestedTestCodeValue.TabIndex = 49;
            this.lblSuggestedTestCodeValue.Text = "AFT559-02-01";
            // 
            // gbCore
            // 
            this.gbCore.Controls.Add(this.lblCorrectedWatts);
            this.gbCore.Controls.Add(this.lblCurrentValue2);
            this.gbCore.Controls.Add(this.lblCurrentPercentage);
            this.gbCore.Controls.Add(this.lblCurrent2);
            this.gbCore.Controls.Add(this.lblWattsNewValue);
            this.gbCore.Controls.Add(this.lblColorValue);
            this.gbCore.Controls.Add(this.lblCoreTemp);
            this.gbCore.Controls.Add(this.lblCorrectedWattsValue);
            this.gbCore.Controls.Add(this.lblCoreTempValue);
            this.gbCore.Controls.Add(this.lblResultValue);
            this.gbCore.Controls.Add(this.lblWattsNew);
            this.gbCore.Controls.Add(this.lblCurrentPercentageValue);
            this.gbCore.Controls.Add(this.lblOrderValue);
            this.gbCore.Controls.Add(this.lblCoreSizeValue);
            this.gbCore.Controls.Add(this.lblCoreSize);
            this.gbCore.Controls.Add(this.lblPieceNumberValue);
            this.gbCore.Controls.Add(this.lblPieceNumber);
            this.gbCore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.gbCore.Location = new System.Drawing.Point(10, 159);
            this.gbCore.Name = "gbCore";
            this.gbCore.Size = new System.Drawing.Size(235, 410);
            this.gbCore.TabIndex = 2;
            this.gbCore.TabStop = false;
            this.gbCore.Text = "Núcleo";
            // 
            // lblCorrectedWatts
            // 
            this.lblCorrectedWatts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCorrectedWatts.Location = new System.Drawing.Point(10, 133);
            this.lblCorrectedWatts.Name = "lblCorrectedWatts";
            this.lblCorrectedWatts.Size = new System.Drawing.Size(114, 48);
            this.lblCorrectedWatts.TabIndex = 80;
            this.lblCorrectedWatts.Text = "WATTS CORREGIDOS A 20°C";
            this.lblCorrectedWatts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrentValue2
            // 
            this.lblCurrentValue2.BackColor = System.Drawing.Color.White;
            this.lblCurrentValue2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentValue2.Location = new System.Drawing.Point(153, 188);
            this.lblCurrentValue2.Name = "lblCurrentValue2";
            this.lblCurrentValue2.Size = new System.Drawing.Size(70, 22);
            this.lblCurrentValue2.TabIndex = 83;
            this.lblCurrentValue2.Text = "100%";
            this.lblCurrentValue2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentPercentage
            // 
            this.lblCurrentPercentage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentPercentage.Location = new System.Drawing.Point(10, 218);
            this.lblCurrentPercentage.Name = "lblCurrentPercentage";
            this.lblCurrentPercentage.Size = new System.Drawing.Size(114, 34);
            this.lblCurrentPercentage.TabIndex = 78;
            this.lblCurrentPercentage.Text = "PORCENTAJE DE CORRIENTE";
            this.lblCurrentPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrent2
            // 
            this.lblCurrent2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrent2.Location = new System.Drawing.Point(10, 189);
            this.lblCurrent2.Name = "lblCurrent2";
            this.lblCurrent2.Size = new System.Drawing.Size(114, 21);
            this.lblCurrent2.TabIndex = 81;
            this.lblCurrent2.Text = "CORRIENTE";
            this.lblCurrent2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWattsNewValue
            // 
            this.lblWattsNewValue.BackColor = System.Drawing.Color.White;
            this.lblWattsNewValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWattsNewValue.Location = new System.Drawing.Point(153, 260);
            this.lblWattsNewValue.Name = "lblWattsNewValue";
            this.lblWattsNewValue.Size = new System.Drawing.Size(70, 22);
            this.lblWattsNewValue.TabIndex = 76;
            this.lblWattsNewValue.Text = "10000";
            this.lblWattsNewValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWattsNewValue.Visible = false;
            // 
            // lblColorValue
            // 
            this.lblColorValue.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblColorValue.Location = new System.Drawing.Point(93, 350);
            this.lblColorValue.Name = "lblColorValue";
            this.lblColorValue.Size = new System.Drawing.Size(48, 48);
            this.lblColorValue.TabIndex = 71;
            // 
            // lblCoreTemp
            // 
            this.lblCoreTemp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCoreTemp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.lblCoreTemp.Location = new System.Drawing.Point(10, 290);
            this.lblCoreTemp.Name = "lblCoreTemp";
            this.lblCoreTemp.Size = new System.Drawing.Size(114, 22);
            this.lblCoreTemp.TabIndex = 75;
            this.lblCoreTemp.Text = "TEMP IR";
            this.lblCoreTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCoreTemp.Visible = false;
            // 
            // lblCorrectedWattsValue
            // 
            this.lblCorrectedWattsValue.BackColor = System.Drawing.Color.White;
            this.lblCorrectedWattsValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCorrectedWattsValue.Location = new System.Drawing.Point(153, 146);
            this.lblCorrectedWattsValue.Name = "lblCorrectedWattsValue";
            this.lblCorrectedWattsValue.Size = new System.Drawing.Size(70, 22);
            this.lblCorrectedWattsValue.TabIndex = 82;
            this.lblCorrectedWattsValue.Text = "1000";
            this.lblCorrectedWattsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCoreTempValue
            // 
            this.lblCoreTempValue.BackColor = System.Drawing.Color.White;
            this.lblCoreTempValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCoreTempValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.lblCoreTempValue.Location = new System.Drawing.Point(153, 290);
            this.lblCoreTempValue.Name = "lblCoreTempValue";
            this.lblCoreTempValue.Size = new System.Drawing.Size(70, 22);
            this.lblCoreTempValue.TabIndex = 77;
            this.lblCoreTempValue.Text = "100°";
            this.lblCoreTempValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCoreTempValue.Visible = false;
            // 
            // lblResultValue
            // 
            this.lblResultValue.BackColor = System.Drawing.Color.White;
            this.lblResultValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResultValue.ForeColor = System.Drawing.Color.Red;
            this.lblResultValue.Location = new System.Drawing.Point(10, 321);
            this.lblResultValue.Name = "lblResultValue";
            this.lblResultValue.Size = new System.Drawing.Size(213, 20);
            this.lblResultValue.TabIndex = 72;
            this.lblResultValue.Text = "RECHAZADO";
            this.lblResultValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWattsNew
            // 
            this.lblWattsNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWattsNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.lblWattsNew.Location = new System.Drawing.Point(10, 260);
            this.lblWattsNew.Name = "lblWattsNew";
            this.lblWattsNew.Size = new System.Drawing.Size(114, 22);
            this.lblWattsNew.TabIndex = 74;
            this.lblWattsNew.Text = "WATTS NEW";
            this.lblWattsNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWattsNew.Visible = false;
            // 
            // lblCurrentPercentageValue
            // 
            this.lblCurrentPercentageValue.BackColor = System.Drawing.Color.White;
            this.lblCurrentPercentageValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentPercentageValue.Location = new System.Drawing.Point(153, 224);
            this.lblCurrentPercentageValue.Name = "lblCurrentPercentageValue";
            this.lblCurrentPercentageValue.Size = new System.Drawing.Size(70, 22);
            this.lblCurrentPercentageValue.TabIndex = 79;
            this.lblCurrentPercentageValue.Text = "100%";
            this.lblCurrentPercentageValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrderValue
            // 
            this.lblOrderValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOrderValue.Location = new System.Drawing.Point(10, 25);
            this.lblOrderValue.Name = "lblOrderValue";
            this.lblOrderValue.Size = new System.Drawing.Size(215, 20);
            this.lblOrderValue.TabIndex = 70;
            this.lblOrderValue.Text = "AFT559-002-001";
            this.lblOrderValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCoreSizeValue
            // 
            this.lblCoreSizeValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCoreSizeValue.Location = new System.Drawing.Point(153, 66);
            this.lblCoreSizeValue.Name = "lblCoreSizeValue";
            this.lblCoreSizeValue.Size = new System.Drawing.Size(70, 15);
            this.lblCoreSizeValue.TabIndex = 52;
            this.lblCoreSizeValue.Text = "GRANDE";
            this.lblCoreSizeValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCoreSize
            // 
            this.lblCoreSize.Location = new System.Drawing.Point(10, 66);
            this.lblCoreSize.Name = "lblCoreSize";
            this.lblCoreSize.Size = new System.Drawing.Size(110, 15);
            this.lblCoreSize.TabIndex = 44;
            this.lblCoreSize.Text = "Tamaño de dona:";
            // 
            // lblPieceNumberValue
            // 
            this.lblPieceNumberValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPieceNumberValue.Location = new System.Drawing.Point(153, 98);
            this.lblPieceNumberValue.Name = "lblPieceNumberValue";
            this.lblPieceNumberValue.Size = new System.Drawing.Size(70, 15);
            this.lblPieceNumberValue.TabIndex = 55;
            this.lblPieceNumberValue.Text = "0/0";
            this.lblPieceNumberValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPieceNumber
            // 
            this.lblPieceNumber.Location = new System.Drawing.Point(10, 98);
            this.lblPieceNumber.Name = "lblPieceNumber";
            this.lblPieceNumber.Size = new System.Drawing.Size(110, 15);
            this.lblPieceNumber.TabIndex = 54;
            this.lblPieceNumber.Text = "Piezas aprobadas";
            // 
            // epForm
            // 
            this.epForm.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.epForm.ContainerControl = this;
            // 
            // UsherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(494, 616);
            this.Controls.Add(this.gbLocation);
            this.Controls.Add(this.gbSuggestedCode);
            this.Controls.Add(this.gbCore);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pbFindCore);
            this.Controls.Add(this.gbFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acomodador Industrial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.gbFind.ResumeLayout(false);
            this.gbFind.PerformLayout();
            this.gbLocation.ResumeLayout(false);
            this.gbLocation.PerformLayout();
            this.gbSuggestedCode.ResumeLayout(false);
            this.gbSuggestedCode.PerformLayout();
            this.gbCore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbFind;
        private System.Windows.Forms.Label lblCodeFieldSize;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtTestCode;
        private System.Windows.Forms.ProgressBar pbFindCore;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.GroupBox gbLocation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblRackLocation;
        private System.Windows.Forms.TextBox txtRackLocation;
        private System.Windows.Forms.Label lblRackLocationSize;
        private System.Windows.Forms.Label lblConfirmationCode;
        private System.Windows.Forms.TextBox txtConfirmationTestCode;
        private System.Windows.Forms.Label lblConfirmationCodeFieldSize;
        private System.Windows.Forms.GroupBox gbSuggestedCode;
        private System.Windows.Forms.Label lblSuggestedTestCode;
        private System.Windows.Forms.Label lblLocationValue;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblSuggestedTestCodeValue;
        private System.Windows.Forms.GroupBox gbCore;
        private System.Windows.Forms.Label lblCorrectedWatts;
        private System.Windows.Forms.Label lblCurrentValue2;
        private System.Windows.Forms.Label lblCurrentPercentage;
        private System.Windows.Forms.Label lblCurrent2;
        private System.Windows.Forms.Label lblWattsNewValue;
        private System.Windows.Forms.Label lblColorValue;
        private System.Windows.Forms.Label lblCoreTemp;
        private System.Windows.Forms.Label lblCorrectedWattsValue;
        private System.Windows.Forms.Label lblCoreTempValue;
        private System.Windows.Forms.Label lblResultValue;
        private System.Windows.Forms.Label lblWattsNew;
        private System.Windows.Forms.Label lblCurrentPercentageValue;
        private System.Windows.Forms.Label lblOrderValue;
        private System.Windows.Forms.Label lblCoreSizeValue;
        private System.Windows.Forms.Label lblCoreSize;
        private System.Windows.Forms.Label lblPieceNumberValue;
        private System.Windows.Forms.Label lblPieceNumber;
        private System.Windows.Forms.ErrorProvider epForm;
    }
}
