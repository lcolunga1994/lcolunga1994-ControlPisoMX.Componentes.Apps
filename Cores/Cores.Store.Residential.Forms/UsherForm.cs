namespace ProlecGE.ControlPisoMX.Cores.Storing.Residential.Forms
{
    using System;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows.Forms;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;
    using ProlecGE.ControlPisoMX.Cores.Commands;
    using ProlecGE.ControlPisoMX.Cores.Residential.Queries;
    using ProlecGE.ControlPisoMX.Cores.Storing.Residential.Commands;
    using ProlecGE.ControlPisoMX.Cores.Storing.Residential.Forms.Utils;
    using ProlecGE.ControlPisoMX.Cores.Storing.Residential.Queries;

    public partial class UsherForm : Form
    {
        #region Fields

        private const string FindCoreMessageTitle = "Buscar núcleo residencial.";
        private const string TestCoreMessageTitle = "Acomodar núcleo residencial.";

        public static readonly Color ThemePrimaryColor = Color.FromArgb(0, 0, 40);
        private readonly Regex rgx = new("^[A-Z0-9]*$");

        private readonly IProgress<(
                MessageBoxIcon MessageBoxIcon,
                string ErrorMessage,
                string MessageTitle,
                Exception? Exception)> messageBoxProgress;
        private readonly IMediator mediator;

        private bool forceAssignation;
        private bool flagProcess;
        private bool flagCancel;

        #endregion

        #region Constructor

        public UsherForm(IMediator mediator)
        {
            InitializeComponent();
            messageBoxProgress = new Progress<(
                MessageBoxIcon MessageBoxIcon,
                string ErrorMessage,
                string MessageTitle,
                Exception? Exception)>(ShowMessage);
            this.mediator = mediator;
        }

        #endregion

        #region Properties

        private ResidentialCoreTestModel? TestResult { get; set; }

        private ResidentialCoreSuggestedCodeResultModel? SuggestedCodeResult { get; set; }

        private ResidentialCoreLocationResultModel? LocationResult { get; set; }

        #endregion

        #region Events

        private void OnFormLoad(object sender, EventArgs e)
        {
            ResetCore();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && MessageBox.Show(
                "¿Desea salir de la aplicación?",
                "Acomodador de Núcleos",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void TxtTestCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            int keyValue = Convert.ToInt32(e.KeyChar);

            if (keyValue is ((int)Keys.Space) or ((int)Keys.Enter))
            {
                e.Handled = true;

                if (Validate())
                {
                    FindCore(((TextBox)sender).Text);
                }
            }
        }

        private void TxtTestCode_TextChanged(object sender, EventArgs e)
        {
            string controlText = ((Control)sender).Text ?? "";
            int maxLength = 8;
            int textLength = controlText.Trim().Length;
            UpdateLabelTextSize(lblCodeFieldSize, maxLength, textLength);
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                FindCore(txtTestCode.Text);
            }
        }

        private void TxtConfirmationTestCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            int keyValue = Convert.ToInt32(e.KeyChar);

            if (keyValue is ((int)Keys.Space) or ((int)Keys.Enter))
            {
                e.Handled = true;
                txtRackLocation.Focus();
            }
        }

        private void TxtConfirmationTestCode_TextChanged(object sender, EventArgs e)
        {
            string controlText = ((Control)sender).Text ?? "";
            int maxLength = 8;
            int textLength = controlText.Trim().Length;
            UpdateLabelTextSize(lblConfirmationCodeFieldSize, maxLength, textLength);
        }

        private void TxtRackLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            int keyValue = Convert.ToInt32(e.KeyChar);

            if (keyValue is ((int)Keys.Space) or ((int)Keys.Enter))
            {
                e.Handled = true;
                if (Validate())
                {
                    StoreCore(((TextBox)sender).Text);
                }
            }
        }

        private void TxtRackLocation_TextChanged(object sender, EventArgs e)
        {
            string controlText = ((Control)sender).Text ?? "";
            int maxLength = 7;
            int textLength = controlText.Trim().Length;
            UpdateLabelTextRackSize(lblRackLocationSize, maxLength, textLength);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                StoreCore(txtRackLocation.Text);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e) => CloseForm();

        #region Validations

        private void TxtTestCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string text = ((Control)sender).Text;
            if (!string.IsNullOrWhiteSpace(text) && !rgx.IsMatch(text))
            {
                e.Cancel = true;
                epForm.SetError((Control)sender, "Solo se admiten letras y números.");
            }
        }

        private void TxtConfirmationTestCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string text = ((Control)sender).Text;
            if (!string.IsNullOrWhiteSpace(text) && !rgx.IsMatch(text))
            {
                e.Cancel = true;
                epForm.SetError((Control)sender, "Solo se admiten letras y números.");
            }
        }

        private void TxtRackLocation_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string text = ((Control)sender).Text;
            if (!string.IsNullOrWhiteSpace(text) && !rgx.IsMatch(text))
            {
                e.Cancel = true;
                epForm.SetError((Control)sender, "Solo se admiten letras y números.");
            }
        }

        private void TxtTestCode_Validated(object sender, EventArgs e)
             => epForm.SetError((Control)sender, "");

        private void TxtConfirmationTestCode_Validated(object sender, EventArgs e)
             => epForm.SetError((Control)sender, "");

        private void TxtRackLocation_Validated(object sender, EventArgs e)
             => epForm.SetError((Control)sender, "");

        #endregion

        #endregion

        #region Queries

        private async void FindCore(string testCode)
        {
            OperationReporter<bool> operation = new(OnProgressChanged);

            try
            {
                if (!await mediator.Send(new TestCodeLengthValidatorCommand(testCode), CancellationToken.None) ||
                    !await mediator.Send(new TestCodeTextValidatorCommand(testCode), CancellationToken.None))
                {
                    operation.Cancel();
                    ShowWarningMessage("El código debe de ser de 8 caracteres y contener solo números y letras.", TestCoreMessageTitle);
                }
                else
                {
                    operation.Start();

                    ResetTest();

                    TestResult = await mediator
                        .Send(new ResidentialCoreTestQuery(testCode), CancellationToken.None)
                        .ConfigureAwait(false);

                    operation.Report(true);

                    if (TestResult != null)
                    {
                        if (TestResult.Status == CoreTestResult.Passed)
                        {
                            LocationResult = await mediator
                                       .Send(new ResidentialCoreLocationResultQuery(TestResult.TestCode), CancellationToken.None)
                                       .ConfigureAwait(false);

                            if (string.IsNullOrWhiteSpace(TestResult?.AssociatedCore))
                            {
                                SuggestedCodeResult = await mediator
                                    .Send(new ResidentialCoreSuggestedCodeResultQuery(testCode), CancellationToken.None)
                                    .ConfigureAwait(false);

                                if (SuggestedCodeResult == null)
                                {
                                    ShowWarningMessage("No hay codigo con quien asociar este núcleo.", TestCoreMessageTitle);
                                }

                                operation.Finish();
                            }
                            else
                            {
                                ResidentialCoreTestModel? suggestedCode = await mediator
                                    .Send(new ResidentialCoreTestQuery(TestResult.AssociatedCore), CancellationToken.None)
                                    .ConfigureAwait(false);

                                SuggestedCodeResult = new ResidentialCoreSuggestedCodeResultModel(
                                    suggestedCode?.TestCode,
                                    suggestedCode?.Location,
                                    suggestedCode?.Color);

                                operation.Finish();
                            }
                        }
                        else
                        {
                            operation.Cancel();
                            ShowWarningMessage("Este núcleo está rechazado.", TestCoreMessageTitle);
                        }
                    }
                    else
                    {
                        operation.Cancel();
                        ShowWarningMessage("Este núcleo no ha pasado por pruebas.", TestCoreMessageTitle);
                    }

                }
            }
            catch (Exception ex)
            {
                operation.Cancel();
                ShowErrorMessage("Ocurrió un error al obtener los datos del núcleo.", TestCoreMessageTitle, ex);
            }

            void OnProgressChanged(OperationProgress<bool> operation)
            {
                if (operation.State == OperationState.Started)
                {
                    SetBusy(true);
                    SetLocationControlBusy(true);
                }
                else if (operation.State == OperationState.Canceled)
                {
                    SetBusy(false);
                    SetLocationControlBusy(true);
                    txtTestCode.Focus();
                }
                else if (operation.State == OperationState.Finished)
                {
                    SetBusy(false);
                    DisplayItem();
                    DisplayTestResult();
                    DisplayLocation();
                    SetLocationControlBusy(!CanAcceptLocation());

                    if (txtConfirmationTestCode.CanFocus)
                    {
                        txtConfirmationTestCode.Focus();
                    }
                }
            }
        }

        #endregion

        #region Commands

        private void ResetTest()
        {
            ResetCore();
        }

        private void ResetCore()
        {
            TestResult = null;
            SuggestedCodeResult = null;
            LocationResult = null;

            DisplayItem();
            ResetResults();
            ResetLocationResult();
        }

        private void ResetResults()
        {
            TestResult = null;
            SuggestedCodeResult = null;
            LocationResult = null;

            DisplayTestResult();
        }

        private void ResetLocationResult()
        {
            TestResult = null;
            SuggestedCodeResult = null;
            LocationResult = null;

            DisplayLocation();
        }

        private void CloseForm() => Close();

        private async void StoreCore(string? rackLocation)
        {
            OperationReporter<bool> operation = new(OnProgressChanged);

            try
            {
                if (!await mediator.Send(new RackLocationLengthValidatorCommand(rackLocation), CancellationToken.None) || string.IsNullOrWhiteSpace(rackLocation))
                {
                    ShowWarningMessage("El rack de ubicación no debe de ser mayor a 7 caracteres y contener solo números y/o letras.", TestCoreMessageTitle);
                }
                else
                {
                    operation.Start();

                    if (TestResult != null)
                    {
                        if (!string.IsNullOrWhiteSpace(TestResult.AssociatedCore) &&
                            !string.IsNullOrWhiteSpace(txtConfirmationTestCode.Text) &&
                            (TestResult.AssociatedCore != txtConfirmationTestCode.Text))
                        {
                            forceAssignation = MessageBox.Show(
                                        $"Este nucleo ya esta asociado al código {SuggestedCodeResult?.SuggestedCode}. ¿Deseas reasignarlo?.",
                                        TestCoreMessageTitle,
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.Yes;

                            if (forceAssignation)
                            {
                                ResidentialCoreTestModel? suggestedCore = await mediator
                                                .Send(new ResidentialCoreTestQuery(txtConfirmationTestCode.Text),
                                                CancellationToken.None)
                                                .ConfigureAwait(false);

                                SuggestedCodeResult = new ResidentialCoreSuggestedCodeResultModel(
                                            suggestedCore?.TestCode,
                                            suggestedCore?.Location,
                                            suggestedCore?.Color);

                                flagProcess = true;
                            }
                            else
                            {
                                flagProcess = false;
                                operation.Cancel();
                            }
                        }
                        else
                        {
                            flagProcess = true;
                        }

                        if (flagProcess)
                        {
                            await mediator
                                   .Send(new StoreResidentialCoreCommand(TestResult.Id, rackLocation, txtConfirmationTestCode.Text, forceAssignation),
                                   CancellationToken.None)
                                   .ConfigureAwait(false);
                            operation.Report(true);
                        }
                    }
                    else
                    {
                        flagProcess = false;
                        operation.Cancel();
                    }

                    if (flagProcess)
                    {
                        operation.Finish();
                    }
                }
            }
            catch (Exception ex)
            {
                operation.Cancel();
                ShowErrorMessage("Ocurrió un error al acomodar el núcleo.", TestCoreMessageTitle, ex);
            }

            void OnProgressChanged(OperationProgress<bool> operation)
            {
                if (operation.State == OperationState.Started)
                {
                    SetBusy(true);
                }
                else if (operation.State == OperationState.Running)
                {
                    if (operation.Value)
                    {
                        MessageBox.Show("Se ha guardado la información.",
                            TestCoreMessageTitle,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                else if (operation.State == OperationState.Canceled)
                {
                    SetBusy(false);
                    txtTestCode.Focus();
                }
                else if (operation.State == OperationState.Finished)
                {
                    SetBusy(false);
                    ResetCore();
                    SetLocationControlBusy(true);
                    txtTestCode.Text = string.Empty;
                    txtTestCode.Focus();
                }
            }
        }

        #endregion

        #region Functionality

        private async void ValidateConfirmationTestCode(string confirmationTestCode)
        {
            OperationReporter<bool> operation = new(OnProgressChanged);

            try
            {
                operation.Start();

                if (!string.IsNullOrWhiteSpace(TestResult?.AssociatedCore) &&
                !string.IsNullOrWhiteSpace(confirmationTestCode) &&
                (TestResult?.AssociatedCore != confirmationTestCode))
                {
                    forceAssignation = MessageBox.Show(
                                $"Este nucleo ya esta asociado al código {SuggestedCodeResult?.SuggestedCode}. ¿Deseas reasignarlo?.",
                                TestCoreMessageTitle,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes;

                    if (forceAssignation)
                    {
                        ResidentialCoreTestModel? suggestedCore = await mediator
                                        .Send(new ResidentialCoreTestQuery(confirmationTestCode),
                                        CancellationToken.None)
                                        .ConfigureAwait(false);

                        if (suggestedCore?.Status == CoreTestResult.Failed)
                        {
                            ShowWarningMessage("Este núcleo sugerido está rechazado.", TestCoreMessageTitle);
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(suggestedCore?.AssociatedCore))
                            {
                                if (MessageBox.Show(
                                    $"Este nucleo ya esta asociado al código {suggestedCore?.AssociatedCore}. ¿Deseas utilizarlo?.",
                                    TestCoreMessageTitle,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    SuggestedCodeResult = new ResidentialCoreSuggestedCodeResultModel(
                                        suggestedCore?.TestCode,
                                        suggestedCore?.Location,
                                        suggestedCore?.Color);
                                    flagCancel = true;
                                }
                            }
                            else
                            {
                                flagCancel = false;
                                operation.Cancel();
                            }
                        }
                    }
                    else
                    {
                        flagCancel = false;
                        operation.Cancel();
                    }
                }
                else
                {
                    ResidentialCoreTestModel? suggestedCore = await mediator
                                        .Send(new ResidentialCoreTestQuery(confirmationTestCode),
                                        CancellationToken.None)
                                        .ConfigureAwait(false);

                    if (suggestedCore?.Status == CoreTestResult.Failed)
                    {
                        ShowWarningMessage("Este núcleo sugerido está rechazado.", TestCoreMessageTitle);
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(suggestedCore?.AssociatedCore))
                        {
                            forceAssignation = MessageBox.Show(
                                $"Este nucleo ya esta asociado al código {suggestedCore?.AssociatedCore}. ¿Deseas utilizarlo?.",
                                TestCoreMessageTitle,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes;

                            if (forceAssignation)
                            {
                                SuggestedCodeResult = new ResidentialCoreSuggestedCodeResultModel(
                                    suggestedCore?.TestCode,
                                    suggestedCore?.Location,
                                    suggestedCore?.Color);
                                flagCancel = true;
                            }
                            else
                            {
                                flagCancel = false;
                                operation.Cancel();
                            }
                        }
                    }
                }
                if (flagCancel)
                {
                    operation.Finish();
                }
            }
            catch (Exception ex)
            {
                operation.Cancel();
                ShowErrorMessage("Ocurrió un error al obtener los datos del núcleo.", TestCoreMessageTitle, ex);
            }

            void OnProgressChanged(OperationProgress<bool> operation)
            {
                if (operation.State == OperationState.Started)
                {
                    SetLocationControlBusy(true);
                }
                else if (operation.State == OperationState.Canceled)
                {
                    SetLocationControlBusy(true);
                    txtConfirmationTestCode.Focus();
                }
                else if (operation.State == OperationState.Finished)
                {
                    SetLocationControlBusy(!CanAcceptLocation());
                    DisplayLocation();
                }
            }
        }

        private bool CanAcceptLocation()
        {
            return TestResult?.Status == CoreTestResult.Passed;
        }

        private void SetBusy(bool formIsBusy)
        {
            pbFindCore.Visible = formIsBusy;
            pbFindCore.Enabled = formIsBusy;
            txtTestCode.Enabled = !formIsBusy;
            btnFind.Enabled = txtTestCode.Enabled;
            btnExit.Enabled = !formIsBusy;
        }

        private void SetLocationControlBusy(bool isBusy)
        {
            txtConfirmationTestCode.Enabled = !isBusy;
            txtRackLocation.Enabled = !isBusy;
            btnSave.Enabled = txtRackLocation.Enabled;
        }

        private void DisplayItem()
        {
            try
            {
                gbFind.ForeColor = ThemePrimaryColor;
                lblOrderValue.ForeColor = ThemePrimaryColor;
                lblOrderValue.Text = $"{TestResult?.ItemId}-{TestResult?.Batch}-{TestResult?.Serie}";

                lblCoreSizeValue.Text = TestResult?.CoreSizes switch
                {
                    CoreSizes.Small => "CHICA",
                    CoreSizes.Big => "GRANDE",
                    _ => TestResult == null ? "-" : "Desconocido",
                };

                lblPieceNumberValue.Text = $"{TestResult?.TestedCores ?? 0}/{TestResult?.TotalCores ?? 0}";
            }
            catch (Exception ex)
            {
                ShowErrorMessage(
                    "Ocurrió un error al mostrar la información del núcleo.",
                    FindCoreMessageTitle,
                    ex);
            }
        }

        private void DisplayTestResult()
        {
            try
            {
                lblResultValue.Text = "";
                lblResultValue.BackColor = BackColor;
                lblResultValue.ForeColor = BackColor;

                if (TestResult?.Status == CoreTestResult.Passed)
                {
                    lblResultValue.Text = "APROBADO";
                    //lblResultValue.BackColor = Color.Black;
                    lblResultValue.ForeColor = Color.Green;
                }
                else if (TestResult?.Status == CoreTestResult.Failed)
                {
                    lblResultValue.Text = "RECHAZADO";
                    //lblResultValue.BackColor = Color.Black;
                    lblResultValue.ForeColor = Color.Red;
                }

                lblCorrectedWattsValue.Text = (TestResult?.CorrectedWatts.ToString()) ?? "-";
                lblWattsNewValue.Text = (TestResult?.NewWatts.ToString()) ?? "-";
                lblCurrentValue2.Text = (TestResult?.Current.ToString()) ?? "-";
                lblCurrentPercentageValue.Text = (TestResult?.CurrentPercentage.ToString()) ?? "-";
                lblColorValue.BackColor = TestResult?.Color switch
                {
                    CoreLimitColor.Blue => Color.Blue,
                    CoreLimitColor.Green => Color.Green,
                    CoreLimitColor.Yellow => Color.Yellow,
                    CoreLimitColor.Red => Color.Red,
                    _ => BackColor,
                };

                if (TestResult != null)
                {
                    int totalCores = TestResult.TotalCores;
                    int testedCores = TestResult.TestedCores;
                    int totalTests = TestResult.TotalTests;

                    lblPieceNumberValue.Text = $"{testedCores}/{totalCores}";

                    if (TestResult != null)
                    {
                        TestResult.TotalCores = totalCores;
                        TestResult.TestedCores = testedCores;
                        TestResult.TotalTests = totalTests;
                    }

                    lblLocationValue.Text = TestResult?.Location ?? "-";
                }
                else
                {
                    lblPieceNumberValue.Text = $"{TestResult?.TestedCores ?? 0}/{TestResult?.TotalCores ?? 0}";
                }
            }
            catch
            {
                ShowErrorMessage("Ocurrió un error al mostrar el resultado de la prueba.", TestCoreMessageTitle);
            }
        }

        private void DisplayLocation()
        {
            try
            {
                lblSuggestedTestCodeValue.Text = SuggestedCodeResult?.SuggestedCode ?? "-";
                lblLocationValue.Text = SuggestedCodeResult?.Location ?? "-";
                lblSuggestedColorName.Text = SuggestedCodeResult?.Color switch
                {
                    CoreLimitColor.Blue => "AZUL",
                    CoreLimitColor.Green => "VERDE",
                    CoreLimitColor.Yellow => "AMARILLO",
                    CoreLimitColor.Red => "ROJO",
                    _ => "",
                };
                lblSuggestedColorValue.BackColor = SuggestedCodeResult?.Color switch
                {
                    CoreLimitColor.Blue => Color.Blue,
                    CoreLimitColor.Green => Color.Green,
                    CoreLimitColor.Yellow => Color.Yellow,
                    CoreLimitColor.Red => Color.Red,
                    _ => BackColor,
                };

                txtConfirmationTestCode.Text = SuggestedCodeResult?.SuggestedCode ?? string.Empty;
                lblCmsMachineValue.Text = LocationResult?.CmsMachine ?? "-";
                txtRackLocation.Text = TestResult?.Location != "BANDA"
                    ? TestResult?.Location
                    : (SuggestedCodeResult?.Location ?? TestResult?.Location) ?? string.Empty;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(
                    "Ocurrió un error al mostrar la información de la ubicación.",
                    FindCoreMessageTitle,
                    ex);
            }
        }

        private static void UpdateLabelTextSize(Label labelControl, int maxLength, int textLength)
        {
            labelControl.Text = $"{textLength}/{maxLength}";
            labelControl.ForeColor = textLength != maxLength ? Color.Red : ThemePrimaryColor;
        }

        private static void UpdateLabelTextRackSize(Label labelControl, int maxLength, int textLength)
        {
            labelControl.Text = $"{textLength}/{maxLength}";
            labelControl.ForeColor = textLength > maxLength ? Color.Red : ThemePrimaryColor;
        }

        private void ShowErrorMessage(
            string errorMessage,
            string messageTitle,
            Exception? ex = null)
        {
            if (ex is AggregateException aggregateException)
            {
                if (aggregateException.InnerException != null)
                {
                    ex = aggregateException.InnerException;
                }
            }

            messageBoxProgress.Report(
                (MessageBoxIcon.Error,
                errorMessage,
                messageTitle,
                ex));
        }

        private void ShowWarningMessage(
            string errorMessage,
            string messageTitle,
            Exception? ex = null)
        {
            if (ex is AggregateException aggregateException)
            {
                if (aggregateException.InnerException != null)
                {
                    ex = aggregateException.InnerException;
                }
            }

            messageBoxProgress.Report(
                (MessageBoxIcon.Warning,
                errorMessage,
                messageTitle,
                ex));
        }

        private async void ShowMessage((
                MessageBoxIcon MessageBoxIcon,
                string ErrorMessage,
                string MessageTitle,
                Exception? Exception) messageParameters)
        {
            if (messageParameters.Exception != null)
            {
                System.Diagnostics.Debug.WriteLine(messageParameters.Exception);
            }

            string userMessage = messageParameters.ErrorMessage;

            if (messageParameters.Exception != null)
            {
                if (messageParameters.Exception is UserException userException)
                {
                    string? customMessage = userException.SystemErrorCode switch
                    {
                        (int)SystemErrorCode.InternalServerError => await mediator.Send(new InternalErrorContactQuery(), CancellationToken.None),
                        (int)SystemErrorCode.GeneralError => null,
                        _ => null,
                    };

                    System.Text.StringBuilder stringBuilder = new();
                    stringBuilder.AppendLine(userException.Message);

                    if (!string.IsNullOrEmpty(customMessage))
                    {
                        stringBuilder.Append(customMessage);

                        if (userException.SystemErrorCode is (int)SystemErrorCode.InternalServerError)
                        {
                            stringBuilder.Append($" ({userException.ErrorCode})");
                        }
                    }

                    userMessage = stringBuilder.ToString();
                }
                else
                {
                    System.Text.StringBuilder stringBuilder = new();
                    stringBuilder.AppendLine(userMessage);
                    stringBuilder.AppendLine("Contactar al administrador del sistema.");
                    userMessage = stringBuilder.ToString();
                }
            }

            if (messageParameters.MessageBoxIcon == MessageBoxIcon.Warning)
            {
                MessageBox.Show(
                    this,
                    userMessage,
                    messageParameters.MessageTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (messageParameters.MessageBoxIcon == MessageBoxIcon.Error)
            {
                MessageBox.Show(
                    this,
                    userMessage,
                    messageParameters.MessageTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(
                    this,
                    userMessage,
                    messageParameters.MessageTitle,
                    MessageBoxButtons.OK);
            }
        }

        #endregion        
    }
}