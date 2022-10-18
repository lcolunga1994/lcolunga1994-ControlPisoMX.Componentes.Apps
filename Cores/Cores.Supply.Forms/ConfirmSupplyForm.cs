namespace ProlecGE.ControlPisoMX.CoreSupply.Forms
{
    using System;
    using System.Windows.Forms;

    using MediatR;

    public partial class ConfirmSupplyForm : ThemedForm
    {
        #region Fields

        private readonly IMediator mediator;

        private bool IsConfirming;

        #endregion

        #region Constructor

        public ConfirmSupplyForm(IMediator mediator)
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
            ApplySecondaryButtonTheme(btnClose);
            ApplySecondaryButtonTheme(btnClear);

            lblUserName.Text = Program.User.Name;
        }

        #endregion

        #region Events

        private void TxtCodeBar_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCodeBar.Text) && !IsConfirming && txtCodeBar.Enabled)
            {
                ConfirmOrder();
            }
        }

        private void TxtCodeBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is ((char)Keys.Space) or ((char)Keys.Enter))
            {
                e.Handled = true;
                ConfirmOrder();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e) => Close();

        private void BtnClear_Click(object sender, EventArgs e) => Reset();

        private void BtnAccept_Click(object sender, EventArgs e) => ConfirmOrder();

        #endregion

        #region Commands

        private async void ConfirmOrder()
        {
            string[] order = txtCodeBar.Text.Split("'", StringSplitOptions.RemoveEmptyEntries);

            if (order.Length != 3)
            {
                MessageBox.Show("Escriba el artículo, lote y serie separados por una comilla simple.\rPor ejemplo: ANL471'252'1.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                OperationProgress<bool> operation = new(UpdateUI);

                try
                {
                    operation.Start();

                    if (int.TryParse(string.IsNullOrWhiteSpace(order[2]) ? "0" : order[2], out int serie))
                    {
                        await mediator
                            .Send(new Commands.ConfirmSupplyCommand(order[0], order[1], serie))
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
                    operation.Error("Ocurrió un problema al confirmar la etiqueta.", ex);
                }
                finally
                {
                    operation.Finish();
                }
            }

            void UpdateUI(OperationProgressReport<bool> progress)
            {
                if (progress.State == OperationState.Started)
                {
                    IsConfirming = true;
                    btnClose.Enabled = false;
                    btnClear.Enabled = false;
                    btnAccept.Enabled = false;
                    txtCodeBar.Enabled = false;
                }
                else if (progress.State == OperationState.Running && progress.Value)
                {
                    MessageBox.Show("Codigo de barras correcto.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else if (progress.State == OperationState.Error)
                {
                    string errorMessage = progress.ErrorMessage ?? "";
                    Exception? customException = progress.Exception;
                    if (progress.Exception is UserException userException)
                    {
                        if (userException.ErrorCode == $"{(int)BFWeb.Components.Cores.OrderSupplyErrorCode.NotFound}")
                        {
                            errorMessage = "Codigo de barras no encontrado.";
                            customException = null;
                        }
                        else if (userException.ErrorCode == $"{(int)BFWeb.Components.Cores.OrderSupplyErrorCode.NotSupplied}")
                        {
                            errorMessage = "La etiqueta no ha sido impresa.";
                            customException = null;
                        }
                    }

                    this.ShowErrorMessage(errorMessage, Text, customException);
                }
                else if (progress.State == OperationState.Finished)
                {
                    btnClose.Enabled = true;
                    btnClear.Enabled = true;
                    btnAccept.Enabled = true;
                    IsConfirming = false;
                }
            }
        }

        private void Reset()
        {
            txtCodeBar.Enabled = true;
            txtCodeBar.Text = "";
            txtCodeBar.Focus();
        }

        #endregion
    }
}