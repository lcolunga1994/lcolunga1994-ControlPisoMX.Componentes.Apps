namespace ProlecGE.ControlPisoMX.AMO.Testing.Residential.Forms
{

    partial class DefectForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbDefects = new System.Windows.Forms.ComboBox();
            this.lblDefect = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCodeFieldSize = new System.Windows.Forms.Label();
            this.epForm = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epForm)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(93, 56);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 27);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // cmbDefects
            // 
            this.cmbDefects.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDefects.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDefects.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.cmbDefects.FormattingEnabled = true;
            this.cmbDefects.Location = new System.Drawing.Point(12, 27);
            this.cmbDefects.Name = "cmbDefects";
            this.cmbDefects.Size = new System.Drawing.Size(324, 23);
            this.cmbDefects.TabIndex = 1;
            this.cmbDefects.TextChanged += new System.EventHandler(this.CmbDefects_TextChanged);
            this.cmbDefects.Validating += new System.ComponentModel.CancelEventHandler(this.CmbDefects_Validating);
            this.cmbDefects.Validated += new System.EventHandler(this.CmbDefects_Validated);
            // 
            // lblDefect
            // 
            this.lblDefect.AutoSize = true;
            this.lblDefect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDefect.Location = new System.Drawing.Point(12, 9);
            this.lblDefect.Name = "lblDefect";
            this.lblDefect.Size = new System.Drawing.Size(172, 15);
            this.lblDefect.TabIndex = 0;
            this.lblDefect.Text = "Escriba o seleccione un defecto";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.btnCancel.Location = new System.Drawing.Point(177, 56);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblCodeFieldSize
            // 
            this.lblCodeFieldSize.AutoSize = true;
            this.lblCodeFieldSize.Location = new System.Drawing.Point(306, 53);
            this.lblCodeFieldSize.Name = "lblCodeFieldSize";
            this.lblCodeFieldSize.Size = new System.Drawing.Size(30, 15);
            this.lblCodeFieldSize.TabIndex = 60;
            this.lblCodeFieldSize.Text = "0/30";
            // 
            // epForm
            // 
            this.epForm.ContainerControl = this;
            // 
            // DefectForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(351, 91);
            this.Controls.Add(this.lblCodeFieldSize);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDefect);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbDefects);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DefectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar defecto (Orden: AFT559-02-01 Secuencia: 32)";
            this.Load += new System.EventHandler(this.OnFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.epForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbDefects;
        private System.Windows.Forms.Label lblDefect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCodeFieldSize;
        private System.Windows.Forms.ErrorProvider epForm;
    }
}