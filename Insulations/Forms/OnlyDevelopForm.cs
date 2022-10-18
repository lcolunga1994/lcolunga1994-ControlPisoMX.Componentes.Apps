namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    using System;
    using System.Windows.Forms;

    using Microsoft.Extensions.DependencyInjection;

    public partial class OnlyDevelopForm : Form
    {
        #region Fields

        private readonly IServiceProvider serviceProvider;

        #endregion

        #region Constructor

        public OnlyDevelopForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
        }

        #endregion

        #region Control events

        private void BtnCizalla_Click(object sender, EventArgs e)
        {
            IServiceScope scope = serviceProvider.CreateScope();
            Form mainform = scope.ServiceProvider.GetRequiredService<ManualCartonShears>();
            mainform.Show();
        }

        private void BtnGuillotina_Click(object sender, EventArgs e)
        {
            IServiceScope scope = serviceProvider.CreateScope();
            Form mainform = scope.ServiceProvider.GetRequiredService<CartonGuillotineShears>();
            mainform.Show();
        }

        private void BtnSoldadura_Click(object sender, EventArgs e)
        {
            IServiceScope scope = serviceProvider.CreateScope();
            Form mainform = scope.ServiceProvider.GetRequiredService<LVTaps>();
            mainform.Show();
        }

        private void BtnCorte_Click(object sender, EventArgs e)
        {
            IServiceScope scope = serviceProvider.CreateScope();
            Form mainform = scope.ServiceProvider.GetRequiredService<LVTaps2>();
            mainform.Show();
        }

        private void BtnFabricacion_Click(object sender, EventArgs e)
        {
            IServiceScope scope = serviceProvider.CreateScope();
            Form mainform = scope.ServiceProvider.GetRequiredService<InsOrderFabrication>();
            mainform.Show();
        }

        private void BtnMantenimiento_Click(object sender, EventArgs e)
        {
            IServiceScope scope = serviceProvider.CreateScope();
            Form mainform = scope.ServiceProvider.GetRequiredService<frmLogin>();
            if (mainform.ShowDialog() == DialogResult.OK)
            {
                mainform = scope.ServiceProvider.GetRequiredService<InsOrderMaintenance>();
                mainform.Show();
            }            
        }

        private void BtnNucleos_Click(object sender, EventArgs e)
        {
            //IServiceScope scope = serviceProvider.CreateScope();
            //Form mainform = scope.ServiceProvider.GetRequiredService<SupplyForm>();
            //mainform.Show();
        }

        #endregion

    }
}