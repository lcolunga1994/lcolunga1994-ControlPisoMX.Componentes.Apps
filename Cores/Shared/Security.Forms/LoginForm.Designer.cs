namespace ProlecGE.ControlPisoMX.Security.Forms
{
    partial class LoginForm
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
            this.picBoxPass = new System.Windows.Forms.PictureBox();
            this.picBoxUser = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picBoxEnterpriseLogo = new System.Windows.Forms.PictureBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblForgotPass = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxPass
            // 
            this.picBoxPass.Location = new System.Drawing.Point(57, 141);
            this.picBoxPass.Name = "picBoxPass";
            this.picBoxPass.Size = new System.Drawing.Size(27, 27);
            this.picBoxPass.TabIndex = 18;
            this.picBoxPass.TabStop = false;
            // 
            // picBoxUser
            // 
            this.picBoxUser.Location = new System.Drawing.Point(57, 109);
            this.picBoxUser.Name = "picBoxUser";
            this.picBoxUser.Size = new System.Drawing.Size(27, 27);
            this.picBoxUser.TabIndex = 17;
            this.picBoxUser.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(102, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Bienvenido";
            // 
            // picBoxEnterpriseLogo
            // 
            this.picBoxEnterpriseLogo.Image = global::ProlecGE.ControlPisoMX.Security.Forms.Properties.Resources.prolec_logo_light;
            this.picBoxEnterpriseLogo.Location = new System.Drawing.Point(72, 21);
            this.picBoxEnterpriseLogo.Name = "picBoxEnterpriseLogo";
            this.picBoxEnterpriseLogo.Size = new System.Drawing.Size(140, 50);
            this.picBoxEnterpriseLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxEnterpriseLogo.TabIndex = 15;
            this.picBoxEnterpriseLogo.TabStop = false;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(57, 180);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(170, 31);
            this.btnEnter.TabIndex = 13;
            this.btnEnter.Text = "Entrar";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassword.Location = new System.Drawing.Point(87, 144);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPassword.MaxLength = 15;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(140, 21);
            this.txtPassword.TabIndex = 12;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPassword_KeyPress);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(87, 112);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUserName.MaxLength = 15;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(140, 21);
            this.txtUserName.TabIndex = 11;
            // 
            // lblForgotPass
            // 
            this.lblForgotPass.AutoSize = true;
            this.lblForgotPass.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblForgotPass.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblForgotPass.Location = new System.Drawing.Point(79, 224);
            this.lblForgotPass.Name = "lblForgotPass";
            this.lblForgotPass.Size = new System.Drawing.Size(127, 15);
            this.lblForgotPass.TabIndex = 19;
            this.lblForgotPass.TabStop = true;
            this.lblForgotPass.Text = "Olvidé mi contraseña";
            this.lblForgotPass.Click += new System.EventHandler(this.BtnChangePassword_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblForgotPass);
            this.Controls.Add(this.picBoxPass);
            this.Controls.Add(this.picBoxUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBoxEnterpriseLogo);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Iniciar sesión";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnterpriseLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picBoxPass;
        private PictureBox picBoxUser;
        public Label label1;
        private PictureBox picBoxEnterpriseLogo;
        private Button btnEnter;
        public TextBox txtPassword;
        public TextBox txtUserName;
        private LinkLabel lblForgotPass;
    }
}