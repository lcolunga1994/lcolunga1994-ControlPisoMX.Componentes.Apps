namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    partial class OnlyDevelopForm
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
            this.btnCizalla = new System.Windows.Forms.Button();
            this.btnGuillotina = new System.Windows.Forms.Button();
            this.btnSoldadura = new System.Windows.Forms.Button();
            this.btnCorte = new System.Windows.Forms.Button();
            this.btnMantenimiento = new System.Windows.Forms.Button();
            this.btnFabricacion = new System.Windows.Forms.Button();
            this.BtnNucleos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCizalla
            // 
            this.btnCizalla.Location = new System.Drawing.Point(12, 12);
            this.btnCizalla.Name = "btnCizalla";
            this.btnCizalla.Size = new System.Drawing.Size(185, 45);
            this.btnCizalla.TabIndex = 0;
            this.btnCizalla.Text = "Cizalla Manual";
            this.btnCizalla.UseVisualStyleBackColor = true;
            this.btnCizalla.Click += new System.EventHandler(this.BtnCizalla_Click);
            // 
            // btnGuillotina
            // 
            this.btnGuillotina.Location = new System.Drawing.Point(208, 12);
            this.btnGuillotina.Name = "btnGuillotina";
            this.btnGuillotina.Size = new System.Drawing.Size(185, 45);
            this.btnGuillotina.TabIndex = 1;
            this.btnGuillotina.Text = " Guillotina de cartón #1";
            this.btnGuillotina.UseVisualStyleBackColor = true;
            this.btnGuillotina.Click += new System.EventHandler(this.BtnGuillotina_Click);
            // 
            // btnSoldadura
            // 
            this.btnSoldadura.Location = new System.Drawing.Point(13, 63);
            this.btnSoldadura.Name = "btnSoldadura";
            this.btnSoldadura.Size = new System.Drawing.Size(185, 45);
            this.btnSoldadura.TabIndex = 2;
            this.btnSoldadura.Text = "Soldadura de puntas de aluminio";
            this.btnSoldadura.UseVisualStyleBackColor = true;
            this.btnSoldadura.Click += new System.EventHandler(this.BtnSoldadura_Click);
            // 
            // btnCorte
            // 
            this.btnCorte.Location = new System.Drawing.Point(209, 63);
            this.btnCorte.Name = "btnCorte";
            this.btnCorte.Size = new System.Drawing.Size(185, 45);
            this.btnCorte.TabIndex = 3;
            this.btnCorte.Text = "Corte de puntas de aluminio";
            this.btnCorte.UseVisualStyleBackColor = true;
            this.btnCorte.Click += new System.EventHandler(this.BtnCorte_Click);
            // 
            // btnMantenimiento
            // 
            this.btnMantenimiento.Location = new System.Drawing.Point(208, 114);
            this.btnMantenimiento.Name = "btnMantenimiento";
            this.btnMantenimiento.Size = new System.Drawing.Size(185, 45);
            this.btnMantenimiento.TabIndex = 4;
            this.btnMantenimiento.Text = "Mantenimiento de ordenes";
            this.btnMantenimiento.UseVisualStyleBackColor = true;
            this.btnMantenimiento.Click += new System.EventHandler(this.BtnMantenimiento_Click);
            // 
            // btnFabricacion
            // 
            this.btnFabricacion.Location = new System.Drawing.Point(13, 114);
            this.btnFabricacion.Name = "btnFabricacion";
            this.btnFabricacion.Size = new System.Drawing.Size(185, 45);
            this.btnFabricacion.TabIndex = 5;
            this.btnFabricacion.Text = "Requerimiento Fabricación";
            this.btnFabricacion.UseVisualStyleBackColor = true;
            this.btnFabricacion.Click += new System.EventHandler(this.BtnFabricacion_Click);
            // 
            // BtnNucleos
            // 
            this.BtnNucleos.Location = new System.Drawing.Point(13, 165);
            this.BtnNucleos.Name = "BtnNucleos";
            this.BtnNucleos.Size = new System.Drawing.Size(185, 45);
            this.BtnNucleos.TabIndex = 6;
            this.BtnNucleos.Text = "Suministro de Núcleos";
            this.BtnNucleos.UseVisualStyleBackColor = true;
            this.BtnNucleos.Click += new System.EventHandler(this.BtnNucleos_Click);
            // 
            // OnlyDevelopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 223);
            this.Controls.Add(this.BtnNucleos);
            this.Controls.Add(this.btnFabricacion);
            this.Controls.Add(this.btnMantenimiento);
            this.Controls.Add(this.btnCorte);
            this.Controls.Add(this.btnSoldadura);
            this.Controls.Add(this.btnGuillotina);
            this.Controls.Add(this.btnCizalla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OnlyDevelopForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OnlyDevelopForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnCizalla;
        private Button btnGuillotina;
        private Button btnSoldadura;
        private Button btnCorte;
        private Button btnMantenimiento;
        private Button btnFabricacion;
        private Button BtnNucleos;
    }
}