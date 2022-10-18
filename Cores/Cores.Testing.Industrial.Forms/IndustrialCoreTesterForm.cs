namespace ProlecGE.ControlPisoMX.Cores.Testing.Industrial.Forms
{
    using MediatR;

    using Microsoft.Extensions.Configuration;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Models;
    using ProlecGE.ControlPisoMX.Cores.Commands;
    using ProlecGE.ControlPisoMX.Cores.Industrial.Queries;
    using ProlecGE.ControlPisoMX.Cores.Queries;
    using ProlecGE.ControlPisoMX.Cores.Testing.Industrial.Commands;
    using ProlecGE.ControlPisoMX.Cores.Testing.Industrial.Queries;
    using ProlecGE.ControlPisoMX.CoresTesting.Application.Utils;

    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows.Forms;

    public partial class IndustrialCoreTesterForm : Form
    {
        #region Fields

        private const string FindCoreMessageTitle = "Buscar núcleo industrial.";
        private const string TestCoreMessageTitle = "Probar núcleo industrial.";

        public static readonly Color ThemePrimaryColor = Color.FromArgb(0, 0, 40);
        private readonly Regex rgx = new(@"^[A-Z0-9]*$");

        private readonly IProgress<(
                MessageBoxIcon MessageBoxIcon,
                string ErrorMessage,
                string MessageTitle,
                Exception? Exception)> messageBoxProgress;
        private readonly IMediator mediator;
        private readonly IConfiguration configuration;

        #endregion

        #region Constructor

        public IndustrialCoreTesterForm(IMediator mediator, IConfiguration configuration)
        {
            InitializeComponent();

            this.mediator = mediator;
            this.configuration = configuration;

            messageBoxProgress = new Progress<(
                MessageBoxIcon MessageBoxIcon,
                string ErrorMessage,
                string MessageTitle,
                Exception? Exception)>(ShowMessage);

            Core = new CoreModel();

            if (!configuration.GetValue<bool>("DeviceIR:UseSerialPort"))
            {
                lblCoreTemp.Visible = false;
                lblCoreTempValue.Visible = false;
            }
        }

        #endregion

        #region Properties

        private CoreModel Core { get; set; }

        private IndustrialItemTestSummaryModel? ItemTestSummary { get; set; }

        private IndustrialCoreTestResultModel? TestResult { get; set; }

        private bool CoreValidationMessageEnabled { get; set; } = true;

        #endregion

        #region Events

        private void OnFormLoad(object sender, EventArgs e)
        {
            ResetTest();
            Calibrate();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && MessageBox.Show(
                "¿Desea salir de la aplicación?",
                "Mesa de pruebas",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e) => CloseForm();

        private void TxtOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SelectNextControl((Control)sender, true, false, true, true);
            }
        }

        private void TxtOrder_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOrder.Text))
            {
                cmbDonutSize.Enabled = true;
            }
            else
            {
                cmbDonutSize.Enabled = false;
                cmbDonutSize.SelectedIndex = -1;
            }

            if (Core.ItemId != txtOrder.Text)
            {
                cmbFoilWidth.Enabled = false;
                cmbFoilWidth.SelectedIndex = -1;
            }
        }

        private void TxtBatch_Leave(object sender, EventArgs e)
        {
            if (txtBatch.Text.Length > 3)
            {
                ShowWarningMessage("El lote no admite más de 3 caracteres.", FindCoreMessageTitle);
                return;
            }
            if (txtBatch.Text.Length < 2)
            {
                char str = '0';
                txtBatch.Text = txtBatch.Text.PadLeft(2, str);
            }
        }

        private void TxtBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SelectNextControl((Control)sender, true, false, true, true);
            }
        }

        private void TxtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SelectNextControl((Control)sender, true, false, true, true);
            }
        }

        private void CmbDonutSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            CoreSizes? selectedCoreSize = GetSelectedCoreSize();

            if (selectedCoreSize.HasValue)
            {
                FindFoilWidths(txtOrder.Text, selectedCoreSize.Value);
            }
            else
            {
                cmbFoilWidth.DataSource = null;
                cmbFoilWidth.Items.Clear();
                cmbFoilWidth.Items.Add("");
                cmbFoilWidth.Enabled = false;
            }
        }
        private void cmbFoilWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            CoreSizes? selectedCoreSize = GetSelectedCoreSize();

            if (selectedCoreSize.HasValue)
            {
                SelectDesign(selectedCoreSize.Value, cmbFoilWidth.SelectedIndex);
            }

        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                FindItem();
            }
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

        #region Validation

        private void TxtTestCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string text = ((Control)sender).Text;
            if (!string.IsNullOrWhiteSpace(text) && !rgx.IsMatch(text))
            {
                //e.Cancel = true;
                //epForm.SetError((Control)sender, "Solo se admiten letras y números.");
            }
        }

        private void TxtOrder_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string text = ((Control)sender).Text;
            if (!string.IsNullOrWhiteSpace(text) && !rgx.IsMatch(text))
            {
                //e.Cancel = true;
                //epForm.SetError((Control)sender, "Solo se admiten letras y números.");
            }
        }

        private void TxtTestCode_Validated(object sender, EventArgs e)
            => epForm.SetError((Control)sender, "");

        private void TxtOrder_Validated(object sender, EventArgs e)
            => epForm.SetError((Control)sender, "");

        #endregion

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

        private void ResetTest()
        {
            cmbDonutSize.Text = null;
            cmbDonutSize.SelectedIndex = -1;

            ResetCore();
        }

        private void ResetCore()
        {
            Core.VoltageDesign = null;

            DisplayTestSummary();
            DisplayItemVoltages();
            ResetResults();
        }

        private void ResetResults()
        {
            OnTemperatureSensorValueChanged(0);
            OnCoreTestParemetersChanged(null, false);

            TestResult = null;
            DisplayTestResult();
        }

        private string GetDesign()
        {
            if (rdDN1.Checked)
            {
                return "DN1";
            }
            else if (rdDN2.Checked)
            {
                return "DN2";
            }
            else if (rdDN3.Checked)
            {
                return "DN3";
            }
            else if (rdDN4.Checked)
            {
                return "DN4";
            }
            else
            {
                return String.Empty;
            }
        }

        private void CloseForm() => Close();

        private async void Calibrate()
        {
            try
            {
                bool needsCalibration = !await mediator
                    .Send(new ReadCalibrationStatusCommand(), CancellationToken.None);

                if (needsCalibration)
                {
                    int calibrationTimeMinutes = configuration.GetValue<int>("CoreTests:CalibrationTimeMinutes");

                    if (calibrationTimeMinutes == 0)
                    {
                        throw new UserException("El valor del tiempo de calibración no está definido.", "UserError");
                    }

                    string timeText = $"{calibrationTimeMinutes} minuto{(calibrationTimeMinutes > 1 ? "s" : "")}";

                    MessageBox.Show(
                        $"Han pasado '{timeText}' de inactividad, se requiere realizar la prueba de núcleo patrón para poder continuar.",
                        TestCoreMessageTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    CalibrationForm form = new(mediator, configuration);

                    form.ShowDialog();

                }
                else
                {
                    TestTermoparConnectivity();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Ocurrió un error al verificar si se requiere calibración.", TestCoreMessageTitle, ex);
            }
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

                        bool needsCalibration = !await mediator.Send(new ReadCalibrationStatusCommand(), CancellationToken.None);

                        if (needsCalibration)
                        {
                            Calibrate();
                        }
                        else
                        {
                            bool startTest = true;

                            if (Core.VoltageDesign?.SecondaryVoltage == 0d)
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

                            if (startTest && ItemTestSummary != null
                                && Core.VoltageDesign != null
                                && Core.VoltageDesign.TestVoltage.HasValue)
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
                                    .Send(new ReadTestValuesCommand(Core.VoltageDesign.TestVoltage.Value), CancellationToken.None)
                                    .ConfigureAwait(false);

                                operation.Report(
                                        (TestCoreOperationStep.ReadCoreTestValues, coreTestValues, coreTemperature));

                                TestResult = await mediator
                                    .Send(new TestIndustrialCoreCommand(
                                        ItemTestSummary.ItemId,
                                        ItemTestSummary.Batch,
                                        ItemTestSummary.Serie,
                                        Core.VoltageDesign.CoreSize,
                                        Core.VoltageDesign.FoilWidth,
                                        testCode,
                                        coreTestValues.AverageVoltage,
                                        coreTestValues.RMSVoltage,
                                        coreTestValues.Current,
                                        coreTestValues.Temperature,
                                        coreTestValues.Watts,
                                        coreTemperature,
                                        stationId,
                                        GetDesign()),
                                        CancellationToken.None)
                                    .ConfigureAwait(false);

                                operation.Report((TestCoreOperationStep.CoreTestResult, null, 0d));

                                await mediator
                                    .Send(new RegisterLastTimeCoreTestCommand(), CancellationToken.None)
                                    .ConfigureAwait(false);
                            }
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
                        OnCoreTestParemetersChanged(operation.Value.TestValues);
                    }
                    else if (operation.Value.Step == TestCoreOperationStep.CoreTestResult)
                    {
                        DisplayTestResult();
                    }
                }
                else if (operation.State is OperationState.Canceled or OperationState.Finished)
                {
                    SetBusy(false);
                    cmbDonutSize.Select(0, 0);
                    cmbDonutSize.Focus();
                    ValidateTestResult();
                }
            }
        }

        #endregion

        #region Queries

        private async void FindFoilWidths(string itemId, CoreSizes coreSize)
        {
            OperationReporter<IEnumerable<double>?> operation = new(OnProgressChanged);

            try
            {
                if (string.IsNullOrWhiteSpace(itemId))
                {
                    throw new UserException($"La orden es requerida.");
                }

                operation.Start();
                IEnumerable<double>? foilList = await mediator
                    .Send(new IndustrialCoreFoilWidthsQuery(itemId, coreSize))
                    .ConfigureAwait(false);
                operation.Report(foilList);
                operation.Finish();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Ocurrió un error al buscar el núcleo.", FindCoreMessageTitle, ex);
                CoreValidationMessageEnabled = false;
                operation.Finish();
            }

            void OnProgressChanged(OperationProgress<IEnumerable<double>?> progress)
            {
                if (progress.State == OperationState.Started)
                {
                    SetBusy(true);

                    cmbFoilWidth.DataSource = null;
                    cmbFoilWidth.Items.Clear();
                    cmbFoilWidth.Items.Add("");
                }
                else if (progress.State == OperationState.Running)
                {
                    if (progress.Value != null)
                    {
                        if (!progress.Value.Any())
                        {
                            ShowErrorMessage("La información de diseño esta incompleta: No hay anchos de lámina.", FindCoreMessageTitle);
                        }

                        cmbFoilWidth.DataSource = progress.Value.ToList();
                        cmbFoilWidth.SelectedIndex = -1;
                        cmbFoilWidth.Enabled = true;
                    }
                    else
                    {
                        ShowWarningMessage("La orden indicada no existe.", FindCoreMessageTitle);
                        cmbFoilWidth.DataSource = null;
                        cmbFoilWidth.SelectedIndex = -1;
                        cmbFoilWidth.Items.Add("");
                    }
                }
                else if (progress.State is OperationState.Finished or OperationState.Canceled)
                {
                    SetBusy(false);
                }
            }
        }

        private void SelectDesign(CoreSizes coreSize, int Tipo)
        {
            if (coreSize == CoreSizes.Small)
            {
                switch (Tipo)
                {
                    case 0:
                        rdDN1.Checked = true;
                        break;
                    case 1:
                        rdDN2.Checked = true;
                        break;
                }

            }
            else if (coreSize == CoreSizes.Big)
            {
                switch (Tipo)
                {
                    case 0:
                        rdDN3.Checked = true;
                        break;
                    case 1:
                        rdDN4.Checked = true;
                        break;
                }
            }
        }

        private void FindItem()
        {
            OperationReporter<FindCoreOperationStep> operation = new(OnProgressChanged);

            try
            {
                if (string.IsNullOrWhiteSpace(txtOrder.Text))
                {
                    ShowWarningMessage("Ingrese la orden.", FindCoreMessageTitle);
                    return;
                }

                if (txtBatch.Text.Length > 3)
                {
                    ShowWarningMessage("El lote no admite más de 3 caracteres.", FindCoreMessageTitle);
                    return;
                }

                CoreSizes? coreSize = GetSelectedCoreSize();
                if (coreSize == null)
                {
                    ShowWarningMessage("El tamaño de la dona es requerido.", FindCoreMessageTitle);
                    return;
                }

                _ = double.TryParse((cmbFoilWidth.SelectedItem?.ToString() ?? "0").Trim(), out double foilWidth);

                if (foilWidth <= 0)
                {
                    ShowWarningMessage("El ancho de la lámina es requerido.", FindCoreMessageTitle);
                    return;
                }

                Core.ItemId = txtOrder.Text;
                Core.Batch = txtBatch.Text;
                
                if (int.TryParse(txtSerie.Text, out int serie))
                {
                    Core.Serie = serie;
                };
                
                Core.Size = coreSize;
                Core.FoilWidth = foilWidth;

                FindItemVoltageDesign();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Ocurrió un error al buscar el núcleo.", FindCoreMessageTitle, ex);

                CoreValidationMessageEnabled = false;

                operation.Finish();
            }

            async void FindItemVoltageDesign()
            {
                try
                {
                    operation.Start();

                    if (Core.VoltageDesign == null
                        || Core.VoltageDesign.ItemId != Core.ItemId
                        || Core.VoltageDesign.CoreSize != Core.Size.Value
                        || Core.VoltageDesign.FoilWidth != Core.FoilWidth)
                    {
                        if (ItemTestSummary == null && (!string.IsNullOrWhiteSpace(Core.Batch) && Core.Serie > 0))
                        {
                            ItemTestSummary = new IndustrialItemTestSummaryModel(Core.ItemId, Core.Batch, Core.Serie);
                        }

                        ResetCore();

                        Core.VoltageDesign = await mediator
                            .Send(new IndustrialCoreVoltageDesignQuery(Core.ItemId, Core.Size.Value, Core.FoilWidth), CancellationToken.None)
                            .ConfigureAwait(false);
                    }

                    operation.Report(FindCoreOperationStep.RefreshItemVoltages);

                    ItemTestSummary = null;

                    if (Core.VoltageDesign != null)
                    {
                        operation.Report(FindCoreOperationStep.RefreshItemVoltages);

                        if (!string.IsNullOrWhiteSpace(Core.Batch) && Core.Serie > 0)
                        {
                            await mediator
                                .Send(new IndustrialCoreTestSummaryQuery(Core.ItemId, Core.Batch, Core.Serie), CancellationToken.None)
                                .ContinueWith(antecedent =>
                                {
                                    if (!antecedent.IsFaulted)
                                    {
                                        ItemTestSummary = new(Core.ItemId, Core.Batch, Core.Serie);

                                        ItemTestSummary.TotalCores = antecedent.Result?.TotalCores ?? 0;
                                        ItemTestSummary.TestedCores = antecedent.Result?.TestedCores ?? 0;
                                        ItemTestSummary.TotalTests = 0;

                                        operation.Report(FindCoreOperationStep.RefreshTestSummary);
                                    }
                                    else
                                    {
                                        CoreValidationMessageEnabled = false;
                                        ShowErrorMessage("Ocurrió un error al consultar el resumen de las pruebas.", FindCoreMessageTitle, antecedent.Exception);
                                    }
                                })
                                .ConfigureAwait(false);
                        }
                    }

                    operation.Finish();
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Ocurrió un error al buscar el núcleo.", FindCoreMessageTitle, ex);

                    CoreValidationMessageEnabled = false;

                    operation.Finish();
                }
            }

            void OnProgressChanged(OperationProgress<FindCoreOperationStep> progress)
            {
                if (progress.State == OperationState.Started)
                {
                    SetBusy(true);
                }
                else if (progress.State == OperationState.Running)
                {
                    if (progress.Value == FindCoreOperationStep.RefreshItemVoltages)
                    {
                        DisplayItemVoltages();
                    }
                    else if (progress.Value == FindCoreOperationStep.RefreshTestSummary)
                    {
                        DisplayTestSummary();
                    }
                    else if (progress.Value == FindCoreOperationStep.NoManufacturingPlan)
                    {
                        DisplayTestSummary();
                    }
                }
                else if (progress.State is OperationState.Finished or OperationState.Canceled)
                {
                    SetBusy(false);

                    AllowTestCore(CanTestCore());
                    ValidateItemVoltages();
                }

                void AllowTestCore(bool allow)
                {
                    txtTestCode.Enabled = allow;

                    if (allow)
                    {
                        txtTestCode.Focus();
                    }
                    else
                    {
                        txtOrder.Focus();
                    }
                }
            }
        }

        #endregion

        #region Functionality

        private bool CanTestCore()
        {
            return ItemTestSummary != null && Core.VoltageDesign != null
                && !string.IsNullOrWhiteSpace(ItemTestSummary.ItemId)
                && !string.IsNullOrWhiteSpace(ItemTestSummary.Batch)
                && ItemTestSummary.Serie > 0
                && Core.VoltageDesign.FoilWidth > 0d
                && Core.VoltageDesign.KVA.HasValue
                && Core.VoltageDesign.SecondaryVoltage.HasValue
                && Core.VoltageDesign.TestVoltage.HasValue
                && Core.VoltageDesign.MaxWattsLimit > 0;
        }

        private CoreSizes? GetSelectedCoreSize()
        {
            string? selectedDonut = cmbDonutSize.SelectedItem?.ToString() ?? null;
            CoreSizes? coreSize = null;

            if (!string.IsNullOrEmpty(selectedDonut))
            {
                if (selectedDonut == "CHICA")
                {
                    coreSize = CoreSizes.Small;
                }
                else if (selectedDonut == "GRANDE")
                {
                    coreSize = CoreSizes.Big;
                }
                else
                {
                    coreSize = null;
                }
            }

            return coreSize;
        }

        private void SetBusy(bool formIsBusy)
        {
            pbFindCore.Visible = formIsBusy;
            pbFindCore.Enabled = formIsBusy;
            txtOrder.Enabled = !formIsBusy;
            txtBatch.Enabled = !formIsBusy;
            txtSerie.Enabled = !formIsBusy;
            cmbDonutSize.Enabled = !formIsBusy;
            cmbFoilWidth.Enabled = !formIsBusy;
            txtTestCode.Enabled = (!formIsBusy) && CanTestCore();
            btnClose.Enabled = !formIsBusy;
        }

        private void DisplayItemVoltages()
        {
            try
            {
                gbItemDesign.ForeColor = ThemePrimaryColor;

                DisplayValueInLabel(Core.VoltageDesign?.KVA, lblKVAValue);

                lblPrimaryVoltageValue.Text = (Core.VoltageDesign?.PrimaryVoltage.ToString()) ?? "-";

                DisplayValueInLabel(Core.VoltageDesign?.SecondaryVoltage, lblSecondaryVoltageValue);

                DisplayValueInLabel(Core.VoltageDesign?.TestVoltage, lblTestVoltageValue);

                gbWattsLimits.ForeColor = ThemePrimaryColor;

                lblAzulMin.Text = (Core.VoltageDesign?.MinWattsLimit.ToString()) ?? "-";

                lblAzulMax.Text = (Core.VoltageDesign?.MaxWattsLimit.ToString()) ?? "-";
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Ocurrió un error al mostrar la información de diseño.", FindCoreMessageTitle, ex);
            }

            static void DisplayValueInLabel(double? value, Label label)
            {
                label.ForeColor = ThemePrimaryColor;
                label.Text = value?.ToString() ?? "-";
            }
        }

        private void DisplayTestSummary()
        {
            try
            {
                gbInformation.ForeColor = ThemePrimaryColor;
                txtOrder.ForeColor = ThemePrimaryColor;

                lblPieceNumberValue.Text = $"{ItemTestSummary?.TestedCores ?? 0}/{ItemTestSummary?.TotalCores ?? 0}";

                lblTestNumberValue.Text = $"{ItemTestSummary?.TotalTests ?? 0}";

                txtTestCode.Text = null;
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Ocurrió un error al mostrar el resumen de las pruebas.", FindCoreMessageTitle, ex);
            }
        }

        private void OnTemperatureSensorValueChanged(double temperature)
        {
            try
            {
                DisplayValueInLabel(lblCoreTempValue, temperature);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(
                    "Ocurrió un error al mostrar la información de diseño.",
                    FindCoreMessageTitle,
                    ex);
            }

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

        private void OnCoreTestParemetersChanged(CoreTestsValues? coreTestValues, bool validate = true)
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
                ShowErrorMessage("Ocurrió un error al mostrar la información de diseño.", FindCoreMessageTitle, ex);
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

                if (TestResult?.Result == CoreTestResult.Passed)
                {
                    lblResultValue.Text = "APROBADO";
                    lblResultValue.ForeColor = Color.Green;
                }
                else if (TestResult?.Result == CoreTestResult.Failed)
                {
                    lblResultValue.Text = "RECHAZADO";
                    lblResultValue.ForeColor = Color.Red;
                }

                lblCorrectedWattsValue.Text = (TestResult?.CorrectedWatts.ToString()) ?? "-";
                double currentPercentage = TestResult?.CurrentPercentage ?? 0d;
                lblCurrentPercentageValue.Text = (currentPercentage > 0) ? (currentPercentage / 100d).ToString("p0") : "-";

                if (TestResult != null)
                {
                    int totalCores = TestResult.TotalCores;
                    int testedCores = TestResult.TestedCores;
                    int totalTests = TestResult.TotalTests;

                    lblPieceNumberValue.Text = $"{testedCores}/{totalCores}";
                    lblTestNumberValue.Text = $"{totalTests}";

                    if (ItemTestSummary != null)
                    {
                        ItemTestSummary.TotalCores = totalCores;
                        ItemTestSummary.TestedCores = testedCores;
                        ItemTestSummary.TotalTests = totalTests;
                    }
                }
                else
                {
                    lblPieceNumberValue.Text = $"{ItemTestSummary?.TestedCores ?? 0}/{ItemTestSummary?.TotalCores ?? 0}";
                    lblTestNumberValue.Text = $"{ItemTestSummary?.TotalTests ?? 0}";
                }
            }
            catch
            {
                ShowErrorMessage("Ocurrió un error al mostrar el resultado de la prueba.", TestCoreMessageTitle);
            }
        }

        private void ValidateItemVoltages()
        {
            if (ItemTestSummary == null && Core.VoltageDesign == null)
            {
                gbInformation.ForeColor = Color.Red;

                if (CoreValidationMessageEnabled)
                {
                    ShowWarningMessage("La orden indicada no existe.", FindCoreMessageTitle);
                }
                else
                {
                    CoreValidationMessageEnabled = true;
                }

            }
            else if (Core.VoltageDesign != null)
            {
                SetRedLabel(Core.VoltageDesign?.KVA, lblKVAValue);

                lblPrimaryVoltageValue.Text = (Core.VoltageDesign?.PrimaryVoltage.ToString()) ?? "-";

                SetRedLabel(Core.VoltageDesign?.SecondaryVoltage, lblSecondaryVoltageValue);

                SetRedLabel(Core.VoltageDesign?.TestVoltage, lblTestVoltageValue);

                ShowIncompleteErrorMessage(
                    Core.VoltageDesign?.KVA is null or <= 0d,
                    Core.VoltageDesign?.SecondaryVoltage == null,
                    Core.VoltageDesign?.TestVoltage is null or < 0d,
                    Core.VoltageDesign?.MaxWattsLimit > 0);

                gbWattsLimits.ForeColor = Core.VoltageDesign?.MaxWattsLimit == 0 ?
                    Color.Red :
                    ThemePrimaryColor;
            }

            void SetRedLabel(double? value, Label label) => label.ForeColor = (value == null) ? Color.Red : ThemePrimaryColor;

            void ShowIncompleteErrorMessage(bool hasNoKVA, bool hasNoSecondaryVoltage, bool hasNoTestVoltage, bool hasLimit)
            {
                if (hasNoKVA || hasNoSecondaryVoltage || hasNoTestVoltage || !hasLimit)
                {
                    System.Text.StringBuilder messageBuilder = new("");

                    messageBuilder.AppendLine("La información de diseño esta incompleta:");

                    if (hasNoKVA)
                    {
                        messageBuilder.AppendLine("No hay KVA's.");
                    }

                    if (hasNoSecondaryVoltage)
                    {
                        messageBuilder.AppendLine("No hay tensión secundaria.");
                    }

                    if (hasNoTestVoltage)
                    {
                        messageBuilder.AppendLine("No hay tensión de prueba.");
                    }

                    if (!hasLimit)
                    {
                        messageBuilder.AppendLine("No hay información de rango de watts.");
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
                ShowWarningMessage("¡Precaución! La temperatura es mayor de 60°C.", TestCoreMessageTitle);
            }

            if (TestResult.Warnings.Contains(CoreTestWarning.NoCurrentPercentageCalculated))
            {
                lblCurrentPercentageValue.ForeColor = Color.OrangeRed;
            }

            if (TestResult.Warnings.Contains(CoreTestWarning.Repeat))
            {
            }

            if (TestResult.Result == CoreTestResult.Failed)
            {
                ShowErrorMessage("El resultado de la prueba no esta dentro de los rangos establecidos.", TestCoreMessageTitle);
            }
        }

        private static void UpdateLabelTextSize(Label labelControl, int maxLength, int textLength)
        {
            labelControl.Text = $"{textLength}/{maxLength}";
            labelControl.ForeColor = textLength != maxLength ? Color.Red : ThemePrimaryColor;
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

        internal enum FindCoreOperationStep
        {
            RefreshItemVoltages,
            RefreshTestSummary,
            NoManufacturingPlan
        }

        public enum TestCoreOperationStep
        {
            ReadCoreTemperature,
            ReadCoreTestValues,
            CoreTestResult
        }

        
    }
}