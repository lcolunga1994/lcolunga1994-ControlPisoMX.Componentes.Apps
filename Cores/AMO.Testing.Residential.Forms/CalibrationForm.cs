namespace ProlecGE.ControlPisoMX.AMO.Testing.Residential.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows.Forms;

    using MediatR;

    using Microsoft.Extensions.Configuration;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;
    using ProlecGE.ControlPisoMX.Cores.Commands;
    using ProlecGE.ControlPisoMX.Cores.Queries;
    using ProlecGE.ControlPisoMX.Cores.Residential.Queries;
    using ProlecGE.ControlPisoMX.AMO.Testing.Residential.Commands;
    using ProlecGE.ControlPisoMX.AMO.Testing.Residential.Queries;
    
    using ProlecGE.ControlPisoMX.Cores;

    using Utils;

    public partial class CalibrationForm : Form
    {
        #region Fields

        private const string FindCoreMessageTitle = "Buscar núcleo patrón residencial.";
        private const string TestCoreMessageTitle = "Probar núcleo patrón residencial.";

        public static readonly Color ThemePrimaryColor = Color.FromArgb(0, 0, 40);
        private readonly Regex rgx = new("^[A-Z0-9]*$");

        private readonly IProgress<(
                MessageBoxIcon MessageBoxIcon,
                string ErrorMessage,
                string MessageTitle,
                Exception? Exception)> messageBoxProgress;
        private readonly IMediator mediator;

        #endregion

        #region Constructor

        public CalibrationForm(IMediator mediator, IConfiguration configuration)
        {
            InitializeComponent();

            this.mediator = mediator;

            if (!configuration.GetValue<bool>("DeviceIR:UseSerialPort"))
            {
                lblCoreTemp.Visible = false;
                lblCoreTempValue.Visible = false;
            }

            messageBoxProgress = new Progress<(
                MessageBoxIcon MessageBoxIcon,
                string ErrorMessage,
                string MessageTitle,
                Exception? Exception)>(ShowMessage);
        }

        #endregion

        #region Properties

        private ResidentialCorePatternTestsSummaryModel? Item { get; set; }

        private ResidentialCoreTestResultModel? TestResult { get; set; }

        private bool ItemValidationMessageEnabled { get; set; } = true;

        #endregion

        #region Events

        private void OnFormLoad(object sender, EventArgs e)
        {
            txtTestCode.Focus();
            TestTermoparConnectivity();
            ResetTest();
            FindCore();
        }

        private void TxtTestCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            int keyValue = Convert.ToInt32(e.KeyChar);

            if (keyValue is ((int)Keys.Space) or ((int)Keys.Enter))
            {
                e.Handled = true;
                TestCore();
            }
        }

        private void TxtTestCode_TextChanged(object sender, EventArgs e)
        {
            string controlText = ((Control)sender).Text ?? "";
            int maxLength = 8;
            int textLength = controlText.Trim().Length;
            UpdateLabelTextSize(lblCodeFieldSize, maxLength, textLength);
        }

        private void TxtTestCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void BtnSalir_Click(object sender, EventArgs e) => CloseForm();

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && pbFindCore.Visible)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Commands

        private void TestTermoparConnectivity()
        {
            mediator
                .Send(new TestTermoparConnectivityCommand())
                .ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        ShowErrorMessage("Ocurrió un error al leer el TermoPar", TestCoreMessageTitle, t.Exception);
                    }
                    else if (!t.Result)
                    {
                        ShowWarningMessage("No hay pistola IR conectada.", TestCoreMessageTitle);
                    }
                });
        }

        private async void TestCore()
        {
            OperationReporter<
                (TestCoreOperationStep Step,
                CoreTestsValues? TestValues,
                double Temperature)>
                operation = new(OnProgressChanged);

            try
            {
                if (Validate() && CanTestCore())
                {
                    string testCode = txtTestCode.Text =
                        (txtTestCode.Text ?? "")
                        .Trim().
                        ToUpper();

                    if (testCode.Length != 8)
                    {
                        ShowWarningMessage("El código debe de ser de 8 caracteres.", TestCoreMessageTitle);
                    }
                    else
                    {
                        ResetResults();

                        bool startTest = true;

                        if (Item?.SecondaryVoltage == 0d)
                        {
                            if (MessageBox.Show(
                                "La tensión secundaria es 0, sin este dato el porcentaje de corriente no se puede calcular, ¿desea continuar?",
                                TestCoreMessageTitle,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question)
                                == DialogResult.No)
                            {
                                startTest = false;
                            }
                        }

                        if (startTest
                            && Item != null
                            && Item.TestVoltage.HasValue)
                        {
                            operation.Start();

                            string stationId = await mediator
                                .Send(new StationIdentifierQuery())
                                .ConfigureAwait(false);

                            double coreTemperature = await mediator
                            .Send(new ReadTemperatureCommand())
                            .ConfigureAwait(false);

                            operation.Report((TestCoreOperationStep.ReadCoreTemperature, null, coreTemperature));

                            CoreTestsValues coreTestValues = await mediator
                                .Send(new ReadTestValuesCommand(Item.TestVoltage.Value), CancellationToken.None)
                                .ConfigureAwait(false);

                            operation.Report(
                                    (TestCoreOperationStep.ReadCoreTestValues, coreTestValues, coreTemperature));

                            TestResult = await mediator
                                .Send(new TestResidentialPatternCommand(
                                    testCode,
                                    coreTestValues.AverageVoltage,
                                    coreTestValues.RMSVoltage,
                                    coreTestValues.Current,
                                    coreTestValues.Temperature,
                                    coreTestValues.Watts,
                                    coreTemperature,
                                    stationId),
                                    CancellationToken.None)
                                .ConfigureAwait(false);

                            if (TestResult.Status == CoreTestResult.Passed)
                            {
                                await mediator
                                    .Send(new RegisterLastTimeCoreTestCommand(), CancellationToken.None)
                                    .ConfigureAwait(false);
                            }

                            operation.Report((TestCoreOperationStep.CoreTestResult, null, 0d));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Ocurrió un error al probar el núcleo.", TestCoreMessageTitle, ex);
            }
            finally
            {
                operation.Finish();
            }

            void OnProgressChanged(OperationProgress<(TestCoreOperationStep Step, CoreTestsValues? TestValues, double Temperature)> operation)
            {
                if (operation.State == OperationState.Started)
                {
                    SetBusy(true);
                }
                else if (operation.State == OperationState.Running)
                {
                    if (operation.Value.Step == TestCoreOperationStep.ReadCoreTemperature)
                    {
                        OnTemperatureSensorValueChanged(operation.Value.Temperature);
                    }
                    else if (operation.Value.Step == TestCoreOperationStep.ReadCoreTestValues)
                    {
                        OnCoreTestParametersChanged(operation.Value.TestValues);
                    }
                    else if (operation.Value.Step == TestCoreOperationStep.CoreTestResult)
                    {
                        DisplayTestResult();
                    }
                }
                else if (operation.State is OperationState.Canceled or
                    OperationState.Finished)
                {
                    SetBusy(false);
                    ValidateTestResult();
                }
            }
        }

        private void ResetTest()
        {
            Item = null;

            DisplayItem();
            ResetResults();
        }

        private void ResetResults()
        {
            TestResult = null;
            OnTemperatureSensorValueChanged(0);
            OnCoreTestParametersChanged(null, false);
            DisplayTestResult();
        }

        private void CloseForm() => Close();

        #endregion

        #region Queries

        private async void FindCore()
        {
            OperationReporter<bool> operation = new(OnProgressChanged);

            try
            {
                operation.Start();

                ResetTest();

                Item = await mediator
                    .Send(new ResidentialCorePatternTestsSummaryQuery(), CancellationToken.None)
                    .ConfigureAwait(false);

                operation.Report(true);

                operation.Finish();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Ocurrió un error al buscar el núcleo patrón.", FindCoreMessageTitle, ex);

                ItemValidationMessageEnabled = false;

                operation.Finish();
            }

            void OnProgressChanged(OperationProgress<bool> progress)
            {
                if (progress.State == OperationState.Started)
                {
                    SetBusy(true);
                }
                else if (progress.State == OperationState.Running)
                {
                    DisplayItem();
                }
                else if (progress.State is OperationState.Finished or OperationState.Canceled)
                {
                    SetBusy(false);

                    AllowTestCore(CanTestCore());
                    ValidateItem();
                }

                void AllowTestCore(bool allow)
                {
                    txtTestCode.Enabled = allow;

                    if (allow)
                    {
                        txtTestCode.Focus();
                    }
                }
            }
        }

        #endregion

        #region Functionality

        private bool CanTestCore()
        {
            bool can = false;

            if (Item != null
                && Item.KVA > 0
                && Item.SecondaryVoltage.HasValue
                && Item.TestVoltage > 0
                && Item.Limits.All(l => l.Max > 0))
            {
                can = true;
            }

            return can;
        }

        private void SetBusy(bool formIsBusy)
        {
            pbFindCore.Visible = formIsBusy;
            pbFindCore.Enabled = formIsBusy;
            txtTestCode.Enabled = (!formIsBusy) && CanTestCore();
            btnExit.Enabled = !formIsBusy;
        }

        private void DisplayItem()
        {
            try
            {
                gbInformation.ForeColor = ThemePrimaryColor;
                lblOrderValue.ForeColor = ThemePrimaryColor;
                lblOrderValue.Text = $"{Item?.ItemId}-{Item?.Batch}-{Item?.Serie}";

                lblTestNumberValue.Text = $"{Item?.TotalTests ?? 0}";

                txtTestCode.Text = null;

                gbItemDesign.ForeColor = ThemePrimaryColor;

                DisplayValueInLabel(Item?.KVA, lblKVAValue);

                lblPrimaryVoltageValue.Text = (Item?.PrimaryVoltage.ToString()) ?? "-";

                DisplayValueInLabel(Item?.SecondaryVoltage, lblSecondaryVoltageValue);

                DisplayValueInLabel(Item?.TestVoltage, lblTestVoltageValue);

                gbColors.ForeColor = ThemePrimaryColor;

                lblAzulMin.Text = (Item?.Limits.Where(e => e.Color == CoreLimitColor.Blue)
                    .Select(e => e.Min)
                    .FirstOrDefault()
                    .ToString()) ?? "-";

                lblAzulMax.Text = (Item?.Limits.Where(e => e.Color == CoreLimitColor.Blue)
                    .Select(e => e.Max)
                    .FirstOrDefault()
                    .ToString()) ?? "-";

                lblVerMin.Text = (Item?.Limits.Where(e => e.Color == CoreLimitColor.Green)
                    .Select(e => e.Min)
                    .FirstOrDefault()
                    .ToString()) ?? "-";

                lblVerMax.Text = (Item?.Limits.Where(e => e.Color == CoreLimitColor.Green)
                    .Select(e => e.Max)
                    .FirstOrDefault()
                    .ToString()) ?? "-";

                lblAmaMin.Text = (Item?.Limits.Where(e => e.Color == CoreLimitColor.Yellow)
                    .Select(e => e.Min)
                    .FirstOrDefault()
                    .ToString()) ?? "-";

                lblAmaMax.Text = (Item?.Limits.Where(e => e.Color == CoreLimitColor.Yellow)
                    .Select(e => e.Max)
                    .FirstOrDefault()
                    .ToString()) ?? "-";

                lblRojMin.Text = (Item?.Limits.Where(e => e.Color == CoreLimitColor.Red)
                    .Select(e => e.Min)
                    .FirstOrDefault()
                    .ToString()) ?? "-";

                lblRojMax.Text = (Item?.Limits.Where(e => e.Color == CoreLimitColor.Red)
                    .Select(e => e.Max)
                    .FirstOrDefault()
                    .ToString()) ?? "-";
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Ocurrió un error al mostrar la información del núcleo patrón.", FindCoreMessageTitle, ex);
            }

            static void DisplayValueInLabel(double? value, Label label)
            {
                label.ForeColor = ThemePrimaryColor;
                label.Text = value?.ToString() ?? "-";
            }
        }

        private void OnTemperatureSensorValueChanged(double temperature)
        {
            DisplayValueInLabel(lblCoreTempValue, temperature);

            static void DisplayValueInLabel(Label label, double? value)
            {
                label.ForeColor = ThemePrimaryColor;
                label.Text = value?.ToString() ?? "-";

                if (value == null)
                {
                    label.ForeColor = Color.Red;
                    label.Text = "Sin información.";
                }
            }
        }

        private void OnCoreTestParametersChanged(CoreTestsValues? coreTestValues, bool validate = true)
        {
            try
            {
                DisplayValueInLabel(lblAverageVoltageValue, !validate ? null : coreTestValues?.AverageVoltage, !validate);
                DisplayValueInLabel(lblRMSVoltageValue, !validate ? null : coreTestValues?.RMSVoltage);
                DisplayValueInLabel(lblCurrentValue, !validate ? null : coreTestValues?.Current, !validate);
                DisplayValueInLabel(lblCurrentValue2, !validate ? null : coreTestValues?.Current, !validate);
                DisplayValueInLabel(lblTemperatureValue, !validate ? null : coreTestValues?.Temperature);
                DisplayValueInLabel(lblWatsValue, !validate ? null : coreTestValues?.Watts);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Ocurrió un error al mostrar la información de los valores medidos.", TestCoreMessageTitle, ex);
            }

            static void DisplayValueInLabel(Label label, double? value, bool acceptZero = true)
            {
                label.ForeColor = ThemePrimaryColor;
                label.Text = value?.ToString() ?? "-";

                if (value == null || (!acceptZero && value == 0d))
                {
                    label.ForeColor = Color.Red;
                }
            }
        }

        private void DisplayTestResult()
        {
            try
            {
                lblCoreTempValue.ForeColor = ForeColor;
                lblResultValue.Text = "";
                lblResultValue.BackColor = BackColor;
                lblResultValue.ForeColor = BackColor;

                if (TestResult?.Status == CoreTestResult.Passed)
                {
                    lblResultValue.Text = "APROBADO";
                    lblResultValue.ForeColor = Color.Green;
                }
                else if (TestResult?.Status == CoreTestResult.Failed)
                {
                    lblResultValue.Text = "RECHAZADO";
                    lblResultValue.ForeColor = Color.Red;
                }

                lblCorrectedWattsValue.Text = (TestResult?.CorrectedWatts.ToString()) ?? "-";
                lblWattsNewValue.Text = (TestResult?.NewWatts.ToString()) ?? "-";
                double currentPercentage = TestResult?.CurrentPercentage ?? 0d;
                lblCurrentPercentageValue.Text = (currentPercentage > 0) ? (currentPercentage / 100d).ToString("p0") : "-";
                lblColorValue.BorderStyle = TestResult?.Color == CoreLimitColor.Yellow ?
                    BorderStyle.FixedSingle : BorderStyle.None;
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

                    lblTestNumberValue.Text = $"{totalTests}";

                    if (Item != null)
                    {
                        Item.TotalTests = totalTests;
                    }
                }
                else
                {
                    lblTestNumberValue.Text = $"{Item?.TotalTests ?? 0}";
                }
            }
            catch
            {
                ShowErrorMessage("Ocurrió un error al mostrar el resultado de la prueba.", TestCoreMessageTitle);
            }
        }

        private void ValidateItem()
        {
            if (Item == null)
            {
                gbInformation.ForeColor = Color.Red;
                gbItemDesign.ForeColor = Color.Red;
                gbColors.ForeColor = Color.Red;

                if (ItemValidationMessageEnabled)
                {
                    ShowErrorMessage(
                        "No existe información de un núcleo patrón.",
                        FindCoreMessageTitle,
                        new UserException("No existe información de un núcleo patrón.", (int)SystemErrorCode.DesignNotFound));
                }
                else
                {
                    ItemValidationMessageEnabled = true;
                }
            }
            else
            {
                lblKVAValue.ForeColor = Item.KVA <= 0d ? Color.Red : ThemePrimaryColor;
                lblSecondaryVoltageValue.ForeColor = Item.SecondaryVoltage == null ? Color.Red : ThemePrimaryColor;
                lblTestVoltageValue.ForeColor = Item.TestVoltage <= 0d ? Color.Red : ThemePrimaryColor;

                gbColors.ForeColor = Item.Limits.Any() ? ThemePrimaryColor : Color.Red;

                lblAzulMin.ForeColor = Item.Limits.Any(l => l.Color == CoreLimitColor.Blue && l.Min == 0 && l.Max == 0) ? Color.Red : ThemePrimaryColor;
                lblAzulMax.ForeColor = Item.Limits.Any(l => l.Color == CoreLimitColor.Blue && l.Min == 0 && l.Max == 0) ? Color.Red : ThemePrimaryColor;
                lblVerMin.ForeColor = Item.Limits.Any(l => l.Color == CoreLimitColor.Green && l.Min == 0 && l.Max == 0) ? Color.Red : ThemePrimaryColor;
                lblVerMax.ForeColor = Item.Limits.Any(l => l.Color == CoreLimitColor.Green && l.Min == 0 && l.Max == 0) ? Color.Red : ThemePrimaryColor;
                lblAmaMin.ForeColor = Item.Limits.Any(l => l.Color == CoreLimitColor.Yellow && l.Min == 0 && l.Max == 0) ? Color.Red : ThemePrimaryColor;
                lblAmaMax.ForeColor = Item.Limits.Any(l => l.Color == CoreLimitColor.Yellow && l.Min == 0 && l.Max == 0) ? Color.Red : ThemePrimaryColor;
                lblRojMin.ForeColor = Item.Limits.Any(l => l.Color == CoreLimitColor.Red && l.Min == 0 && l.Max == 0) ? Color.Red : ThemePrimaryColor;
                lblRojMax.ForeColor = Item.Limits.Any(l => l.Color == CoreLimitColor.Red && l.Min == 0 && l.Max == 0) ? Color.Red : ThemePrimaryColor;

                ShowIncompleteErrorMessage(
                    Item.KVA is null or <= 0d,
                    Item.SecondaryVoltage == null,
                    Item.TestVoltage is null or < 0d,
                    Item.Limits.Any(),
                    Item.Limits.Where(l => l.Min == 0 && l.Max == 0).Select(l => l.Color));
            }

            void ShowIncompleteErrorMessage(
                bool hasNoKVA,
                bool hasNoSecondaryVoltage,
                bool hasNoTestVoltage,
                bool hasLimits,
                IEnumerable<CoreLimitColor> incompleteColors)
            {
                if (hasNoKVA || hasNoSecondaryVoltage || hasNoTestVoltage || !hasLimits || incompleteColors.Any())
                {
                    System.Text.StringBuilder messageBuilder = new("");

                    messageBuilder.AppendLine("La información de diseño esta incompleta:");

                    if (hasNoKVA)
                    {
                        messageBuilder.AppendLine("-- No hay KVA's.");
                    }

                    if (hasNoSecondaryVoltage)
                    {
                        messageBuilder.AppendLine("-- No hay tensión secundaria.");
                    }

                    if (hasNoTestVoltage)
                    {
                        messageBuilder.AppendLine("-- No hay tensión de prueba.");
                    }

                    if (!hasLimits)
                    {
                        messageBuilder.AppendLine("-- No hay información de rango de colores.");
                    }

                    foreach (CoreLimitColor color in incompleteColors)
                    {
                        messageBuilder.AppendLine($"-- El color {GetColorName(color)} no cuenta con valores de medición.");
                    }

                    ShowErrorMessage(
                        messageBuilder.ToString(),
                        FindCoreMessageTitle,
                        new UserException(messageBuilder.ToString(), (int)SystemErrorCode.PartialDesignNotFound));
                }
            }
        }

        private void ValidateTestResult()
        {
            if (TestResult == null)
            {
                return;
            }

            if (TestResult.Warnings.Contains(CoreTestWarning.NoCoreTemp) && lblCoreTempValue.Visible)
            {
                lblCoreTempValue.ForeColor = Color.OrangeRed;

                ShowWarningMessage(
                    "¡Precaución! No esta presente la Pistola IR (SIN TEMPERATURA).",
                    TestCoreMessageTitle);
            }

            if (TestResult.Warnings.Contains(CoreTestWarning.HighCoreTemperature))
            {
                lblTemperatureValue.ForeColor = Color.OrangeRed;
                ShowWarningMessage("¡Precaución! La temperatura es mayor de 60°C.",
                    TestCoreMessageTitle);
            }

            if (TestResult.Warnings.Contains(CoreTestWarning.NoCurrentPercentageCalculated))
            {
                lblCurrentPercentageValue.ForeColor = Color.OrangeRed;
            }

            if (TestResult.Warnings.Contains(CoreTestWarning.Repeat))
            {
            }

            if (TestResult.Status == CoreTestResult.Failed)
            {
                ShowErrorMessage("El resultado de la prueba no esta dentro de los rangos establecidos.", TestCoreMessageTitle);
            }
        }

        private static void UpdateLabelTextSize(Label labelControl, int maxLength, int textLength)
        {
            labelControl.Text = $"{textLength}/{maxLength}";
            labelControl.ForeColor = textLength != maxLength ? Color.Red : ThemePrimaryColor;
        }

        private static string GetColorName(CoreLimitColor? color)
        {
            return color switch
            {
                CoreLimitColor.Blue => "AZUL",
                CoreLimitColor.Green => "VERDE",
                CoreLimitColor.Yellow => "AMARILLO",
                CoreLimitColor.Red => "ROJO",
                _ => "",
            };
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
            string messageTitle)
        {
            messageBoxProgress.Report(
                (MessageBoxIcon.Warning,
                errorMessage,
                messageTitle,
                null));
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
                        (int)SystemErrorCode.DesignNotFound => await mediator.Send(new MissingItemDesignContactQuery(), CancellationToken.None),
                        (int)SystemErrorCode.PartialDesignNotFound => await mediator.Send(new MissingItemDesignContactQuery(), CancellationToken.None),
                        (int)SystemErrorCode.ManufacturingPlanNotFound => await mediator.Send(new MissingCoreManufacturingPlanContactQuery(), CancellationToken.None),
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