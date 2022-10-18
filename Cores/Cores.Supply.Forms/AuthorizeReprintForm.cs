namespace ProlecGE.ControlPisoMX.CoreSupply.Forms
{
    using System;
    using System.Windows.Forms;

    using MediatR;

    public partial class AuthorizeReprintForm : ThemedForm
    {
        #region Fields

        private readonly IMediator mediator;

        #endregion

        #region Constructor

        public AuthorizeReprintForm(IMediator mediator)
        {
            this.mediator = mediator;
            InitializeComponent();
            CenterToParent();
            CustomInitializeComponent();
        }

        #endregion

        #region Controls initialization

        private void CustomInitializeComponent()
        {
            UseLightTheme();
            ApplyStandarImages(picBoxEnterpriseLogo, picBoxTitleLine);
            ApplyUserImage(picBoxUserImage);
            lblUserName.Text = Program.User.Name;
            StartPosition = FormStartPosition.CenterParent;

            ApplySecondaryButtonTheme(btnClose);

            txtItem.InitializeItemTextboxBehavior();
            txtBatch.InitializeBatchTextboxBehavior();
            txtSerie.InitializeSerieTextboxBehavior();
        }

        #endregion

        #region Events

        private void BtnAuthorize_Click(object sender, EventArgs e) => AuthorizeOrder();

        private void BtnClose_Click(object sender, EventArgs e) => Close();

        #endregion

        #region Commands

        private async void AuthorizeOrder()
        {
            OperationProgress<bool> operation = new(UpdateUI);

            try
            {
                operation.Start();

                if (int.TryParse(string.IsNullOrWhiteSpace(txtSerie.Text) ? "0" : txtSerie.Text, out int serie))
                {
                    await mediator
                        .Send(new Commands.AuthorizeReprintCommand(txtItem.Text, txtBatch.Text, serie))
                        .ConfigureAwait(false);

                    operation.Report(true);
                }
                else
                {
                    throw new UserException("La serie debe numérica.");
                }
            }
            catch (Exception ex)
            {
                operation.Error("Ocurrió un problema al autorizar la reimpresión de la orden.", ex);
            }
            finally
            {
                operation.Finish();
            }

            void UpdateUI(OperationProgressReport<bool> progress)
            {
                if (progress.State == OperationState.Started)
                {
                    btnClose.Enabled = false;
                    btnAuthorize.Enabled = false;
                    txtItem.Enabled = false;
                    txtBatch.Enabled = false;
                    txtSerie.Enabled = false;
                }
                else if (progress.State == OperationState.Running && progress.Value)
                {
                    MessageBox.Show($"Se ha autorizado la reimpresión de la orden {txtItem.Text}-{txtBatch.Text}-{txtSerie.Text}.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtItem.Text = "";
                    txtBatch.Text = "";
                    txtSerie.Text = "";
                    txtItem.Focus();
                }
                else if (progress.State == OperationState.Error)
                {
                    this.ShowErrorMessage(progress.ErrorMessage ?? "", Text, progress.Exception);
                }
                else if (progress.State == OperationState.Finished)
                {
                    btnClose.Enabled = true;
                    btnAuthorize.Enabled = true;
                    txtItem.Enabled = true;
                    txtBatch.Enabled = true;
                    txtSerie.Enabled = true;
                }
            }
        }

        #endregion
    }
}