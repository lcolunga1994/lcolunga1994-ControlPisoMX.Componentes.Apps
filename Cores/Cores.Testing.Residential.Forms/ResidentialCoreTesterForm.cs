namespace ProlecGE.ControlPisoMX.Cores.Testing.Residential.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using MediatR;

    using Microsoft.Extensions.Configuration;

    using ProlecGE.ControlPisoMX;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;
    using ProlecGE.ControlPisoMX.Cores.Commands;
    using ProlecGE.ControlPisoMX.Cores.Queries;
    using ProlecGE.ControlPisoMX.Cores.Residential.Queries;
    using ProlecGE.ControlPisoMX.Cores.Testing.Residential.Commands;
    using ProlecGE.ControlPisoMX.Cores.Testing.Residential.Queries;

    using Utils;

    public partial class ResidentialCoreTesterForm : Form
    {
        #region Fields

        private const string FindCoreMessageTitle = "Buscar núcleo residencial.";
        private const string TestCoreMessageTitle = "Probar núcleo residencial.";

        public static readonly Color ThemePrimaryColor = Color.FromArgb(0, 0, 40);
        private readonly Regex rgx = new("^[A-Z0-9]*$");

        private readonly IProgress<(
                MessageBoxIcon MessageBoxIcon,
                string ErrorMessage,
                string MessageTitle,
                Exception? Exception)> messageBoxProgress;
        private readonly IMediator mediator;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public ResidentialCoreTesterForm(IMediator mediator, IConfiguration configuration)
        {
            InitializeComponent();

            this.mediator = mediator;
            this._configuration = configuration;

            messageBoxProgress = new Progress<(
                MessageBoxIcon MessageBoxIcon,
                string ErrorMessage,
                string MessageTitle,
                Exception? Exception)>(ShowMessage);

            UserInput = new FormInput();

            DateRangeAvailable = new List<DateRangeAvailableModel>();
            Tags = new List<ManufacturedResidentialCoreModel>();

            Items = new List<string>();

            if (!configuration.GetValue<bool>("DeviceIR:UseSerialPort"))
            {
                lblCoreTemp.Visible = false;
                lblCoreTempValue.Visible = false;
            }
        }

        #endregion

        #region Properties

        protected FormInput UserInput { get; set; }

        public IEnumerable<DateRangeAvailableModel> DateRangeAvailable { get; set; }

        public List<ManufacturedResidentialCoreModel> Tags { get; private set; }

        public List<string> Items { get; private set; }

        private ItemModel? Item { get; set; }

        private bool CoreValidationMessageEnabled { get; set; } = true;

        private CoreVoltageDesignModel? ItemVoltage { get; set; }

        private bool CoreVoltageValidationMessageEnabled { get; set; } = true;

        private ResidentialCoreTestResultModel? TestResult { get; set; }

        #endregion

        #region Events

        private void OnFormLoad(object sender, EventArgs e)
        {
            cmbDonutSizes.ValueMember = nameof(CoreSizeModel.Id);
            cmbDonutSizes.DisplayMember = nameof(CoreSizeModel.Name);
            cmbDonutSizes.DataSource = new System.ComponentModel.BindingList<CoreSizeModel>() {
                CoreSizeModel.None,
                CoreSizeModel.Small,
                CoreSizeModel.Big,
            };

            ResetTest();
            FindTags();
            FindItems();
            Calibrate();
            cmbTags.Focus();
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

        private void ChkRework_CheckedChanged(object sender, EventArgs e)
        {
            cmbItems.CausesValidation = !chkRework.Checked;
            txtItem.CausesValidation = !cmbItems.CausesValidation;
            cmbTags.Enabled = !chkRework.Checked;
            btnRefreshTags.Enabled = !chkRework.Checked;
            pnlOrder.Visible = !chkRework.Checked;
            pnlReworkOrder.Visible = chkRework.Checked;

            ResetTest();
            UpdateUserInput();
        }

        private void PnlOrder_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlOrder.Visible)
            {
                cmbTags.Focus();
            }
        }

        private void PnlReworkOrder_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlReworkOrder.Visible)
            {
                txtItem.Focus();
            }
        }

        private void CmbTags_TextChanged(object sender, EventArgs e)
        {
            string controlText = ((Control)sender).Text ?? "";
            int maxLength = 8;
            int textLength = controlText.Trim().Length;
            UpdateLabelTextSize(lblTagFieldSize, maxLength, textLength);
            UserInput.Tag = cmbTags.Text = cmbTags.Text.Trim();
        }

        private void CmbTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null)
            {
                string controlText = ((Control)sender).Text ?? "";
                int maxLength = 8;
                int textLength = controlText.Trim().Length;
                UpdateLabelTextSize(lblTagFieldSize, maxLength, textLength);
                UserInput.Tag = cmbTags.Text = cmbTags.Text.Trim();

                ManufacturedResidentialCoreModel? manufacturedCore = Tags
                    .FirstOrDefault(e => e.Tag == UserInput.Tag);

                if (manufacturedCore != null)
                {
                    cmbItems.SelectedItem = null;
                    cmbItems.SelectedItem = manufacturedCore.ItemId;

                    if (cmbItems.SelectedItem == null && !string.IsNullOrWhiteSpace(manufacturedCore.ItemId))
                    {
                        ShowWarningMessage(
                            $"La orden {manufacturedCore.ItemId} no se encuentra en el rango de fechas disponible en el plan de fabricación de núcleos.",
                            FindCoreMessageTitle,
                            new UserException($"La orden {manufacturedCore.ItemId} no se encuentra en el plan de fabricación de núcleos.", (int)SystemErrorCode.ManufacturingPlanNotFound));
                    }
                }
            }
        }

        private void CmbTags_KeyPress(object sender, KeyPressEventArgs e)
        {
            int keyValue = Convert.ToInt32(e.KeyChar);

            if (keyValue is ((int)Keys.Enter) or ((int)Keys.Space))
            {
                e.Handled = true;
                if (Validate())
                {
                    UpdateUserInput();
                }
            }
        }

        private void BtnRefreshTags_Click(object sender, EventArgs e)
        {
            ResetTest();
            FindTags();
        }

        private void BtnFindItems_Click(object sender, EventArgs e) => FindItems();

        private void CmbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUserInput();

            if (((ComboBox)sender).SelectedItem != null)
            {
                FindCore();
            }
        }

        private void TxtItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            int keyValue = Convert.ToInt32(e.KeyChar);

            if (keyValue is ((int)Keys.Enter) or ((int)Keys.Space))
            {
                e.Handled = true;  //keeps event from bubbling to next handler

                UpdateUserInput();
                FindCore();
            }
        }

        private void TxtItem_Leave(object sender, EventArgs e) => UpdateUserInput();

        private void BtnFindItem_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                FindCore();
            }
        }

        private void CmbDonutSizes_SelectedValueChanged(object sender, EventArgs e) => UpdateUserInput();

        private void TxtTestCode_TextChanged(object sender, EventArgs e)
        {
            string controlText = ((Control)sender).Text ?? "";
            int maxLength = 8;
            int textLength = controlText.Trim().Length;
            UpdateLabelTextSize(lblCodeFieldSize, maxLength, textLength);
            UserInput.TestCode = txtTestCode.Text = txtTestCode.Text.Trim();
        }

        private void TxtTestCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            int keyValue = Convert.ToInt32(e.KeyChar);

            if (keyValue is ((int)Keys.Space) or ((int)Keys.Enter))
            {
                e.Handled = true;
                UserInput.TestCode = txtTestCode.Text = txtTestCode.Text.Trim();
                TestCore();
            }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                TestCore();
            }
        }

        private void BtnRegisterDefect_Click(object sender, EventArgs e)
        {
            if (Item != null)
            {
                DefectForm form = new(Item, mediator);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RegisterDefect(Item, form.Defect);
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e) => CloseForm();

        #region Validations

        private void CmbTags_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string text = ((Control)sender).Text;
            if (!string.IsNullOrWhiteSpace(text) && !rgx.IsMatch(text))
            {
                e.Cancel = true;
                epForm.SetError((Control)sender, "Solo se admiten letras y números.");
            }
        }

        private void CmbItems_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string text = ((Control)sender).Text;
            if (!string.IsNullOrWhiteSpace(text) && !rgx.IsMatch(text))
            {
                e.Cancel = true;
                epForm.SetError((Control)sender, "Solo se admiten letras y números.");
            }
        }

        private void TxtItem_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string text = ((Control)sender).Text;
            if (!string.IsNullOrWhiteSpace(text) && !rgx.IsMatch(text))
            {
                e.Cancel = true;
                epForm.SetError((Control)sender, "Solo se admiten letras y números.");
            }
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

        private void CmbTags_Validated(object sender, EventArgs e) => epForm.SetError((Control)sender, "");

        private void CmbItems_Validated(object sender, EventArgs e) => epForm.SetError((Control)sender, "");

        private void TxtItem_Validated(object sender, EventArgs e) => epForm.SetError((Control)sender, "");

        private void TxtTestCode_Validated(object sender, EventArgs e) => epForm.SetError((Control)sender, "");

        #endregion

        #endregion

        #region Queries

        private async void FindTags()
        {
            OperationReporter<bool> operation = new(OnProgressChanged);

            try
            {
                operation.Start();

                Tags.Clear();

                int page = 1;
                int pageSize = 200;

                int totalRecords = await FindTagsAsync(
                    page,
                    pageSize,
                    Tags)
                .ConfigureAwait(false);

                while (Tags.Count < totalRecords)
                {
                    page++;

                    totalRecords = await FindTagsAsync(
                        page,
                        pageSize,
                        Tags)
                    .ConfigureAwait(false);
                }

                operation.Report(true);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Ocurrió un error al cargar las etiquetas.", TestCoreMessageTitle, ex);
            }
            finally
            {
                operation.Finish();
            }

            async Task<int> FindTagsAsync(
                int page,
                int pageSize,
                List<ManufacturedResidentialCoreModel> tags)
            {
                QueryResult<ManufacturedResidentialCoreModel> corePlan =
                    await mediator.Send(
                        new ManufacturedCoresQuery(page, pageSize))
                    .ConfigureAwait(false);

                tags.AddRange(corePlan.Data);

                return corePlan.Count;
            }

            void OnProgressChanged(OperationProgress<bool> operation)
            {
                if (operation.State == OperationState.Started)
                {
                    SetBusy(true);
                }
                else if (operation.State is OperationState.Canceled or OperationState.Finished)
                {
                    RefreshTagsComboBox();
                    SetBusy(false);
                    cmbTags.Select(0, 1);
                    cmbTags.Focus();
                }
            }
        }

        private async void FindItems()
        {
            OperationReporter<bool> operation = new(OnProgressChanged);

            try
            {
                int page = 1;
                int pageSize = 200;

                operation.Start();

                Items.Clear();

                int totalRecords = await FindPlannedItemsAsync(page, pageSize, Items).ConfigureAwait(false);

                while (Items.Count < totalRecords)
                {
                    page++;

                    totalRecords = await FindPlannedItemsAsync(page, pageSize, Items).ConfigureAwait(false);
                }

                DateRangeAvailable = await mediator.Send(new DateRangeAvailableForTestQuery(), CancellationToken.None)
                    .ConfigureAwait(false);

                operation.Report(true);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Ocurrió un error al cargar los artículos planeados.", TestCoreMessageTitle, ex);
            }
            finally
            {
                operation.Finish();
            }

            async Task<int> FindPlannedItemsAsync(int page, int pageSize, List<string> items)
            {
                QueryResult<string> plannedItems =
                    await mediator.Send(new ItemsPlannedToBeManufacturedQuery(page, pageSize))
                    .ConfigureAwait(false);

                items.AddRange(plannedItems.Data);

                return plannedItems.Count;
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
                        cmbItems.BeginUpdate();
                        cmbItems.Text = "";
                        cmbItems.Items.Clear();
                        cmbItems.Items.AddRange(Items.ToArray());
                        cmbItems.EndUpdate();
                    }
                }
                if (operation.State is OperationState.Canceled or OperationState.Finished)
                {
                    SetBusy(false);

                    if (cmbItems.CanFocus)
                    {
                        cmbItems.Focus();
                    }

                    DisplayDateRanges();
                }
            }
        }

        private async void FindCore()
        {
            OperationReporter<FindCoreOperationStep> operation = new(OnProgressChanged);

            try
            {
                if (Validate())
                {
                    if (string.IsNullOrEmpty(UserInput.ItemId))
                    {
                        ShowWarningMessage("Ingrese una orden.", FindCoreMessageTitle);
                    }
                    else
                    {
                        if (UserInput.ItemId.Length > 47)
                        {
                            ShowWarningMessage("La orden no debe ser mayor de 47 caracteres.", FindCoreMessageTitle);
                        }
                        else
                        {
                            operation.Start();

                            if (UserInput.ItemId != Item?.ItemId)
                            {
                                Item = null;
                            }

                            if (Item == null)
                            {
                                UserInput.CoreSize = CoreSizeModel.None;
                            }

                            ResetCore();

                            BFWeb.Components.Cores.Models.ItemModel? item = await mediator.Send(new ItemQuery(UserInput.ItemId)).ConfigureAwait(false);

                            if (item != null)
                            {
                                Item = new ItemModel(item.ItemId, item.Phases);

                                Task? findVoltageInfoTask = null;

                                if (item.Phases == 1)
                                {
                                    UserInput.CoreSize = CoreSizeModel.Small;
                                }

                                if (UserInput.CoreSize != CoreSizeModel.None)
                                {
                                    Item.CoreSize = (CoreSizes)UserInput.CoreSize.Id;
                                    findVoltageInfoTask = StartFindVoltageInfoTasksAsync(Item.ItemId, Item.CoreSize);
                                }
                                else
                                {
                                    operation.Report(FindCoreOperationStep.RefreshCoreInformation);
                                }

                                if (!chkRework.Checked)
                                {
                                    CoreManufacturingPlanModel? core = await mediator
                                        .Send(new NextCoreToBeManufacturedQuery(item.ItemId))
                                        .ConfigureAwait(false);

                                    if (core != null)
                                    {
                                        Item.Batch = core.Batch;
                                        Item.Serie = core.Serie;
                                        Item.Sequence = core.Sequence;
                                        Item.ProductLine = core.ProductLine;
                                        Item.ScheduledDate = core.ScheduledUtcDate.ToMexicoDateTime();
                                        Item.Tag = core.Tag;
                                        operation.Report(FindCoreOperationStep.RefreshCoreInformation);
                                    }
                                    else
                                    {
                                        operation.Report(FindCoreOperationStep.NoManufacturingPlan);
                                    }
                                }
                                else
                                {
                                    operation.Report(FindCoreOperationStep.RefreshCoreInformation);
                                }

                                if (findVoltageInfoTask != null)
                                {
                                    await findVoltageInfoTask.ConfigureAwait(false);
                                }
                            }

                            operation.Finish();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Ocurrió un error al buscar el núcleo.", FindCoreMessageTitle, ex);

                CoreValidationMessageEnabled = false;
                CoreVoltageValidationMessageEnabled = false;

                operation.Finish();
            }

            Task StartFindVoltageInfoTasksAsync(string itemId, CoreSizes coreSize)
                => mediator.Send(new CoreVoltageDesignQuery(itemId, coreSize), CancellationToken.None)
                .ContinueWith(antecedent =>
                {
                    ItemVoltage = null;

                    if (!antecedent.IsFaulted)
                    {
                        ItemVoltage = antecedent.Result;
                        operation.Report(FindCoreOperationStep.RefreshCoreVoltages);
                    }
                    else
                    {
                        CoreVoltageValidationMessageEnabled = false;
                        ShowErrorMessage("Ocurrió un error al buscar la información de diseño.", FindCoreMessageTitle, antecedent.Exception);
                    }
                });

            void OnProgressChanged(OperationProgress<FindCoreOperationStep> progress)
            {
                if (progress.State == OperationState.Started)
                {
                    SetBusy(true);
                }
                else if (progress.State == OperationState.Running)
                {
                    if (progress.Value == FindCoreOperationStep.RefreshCoreInformation)
                    {
                        DisplayItem();
                    }
                    else if (progress.Value == FindCoreOperationStep.RefreshCoreVoltages)
                    {
                        DisplayItemVoltages();
                    }
                    else if (progress.Value == FindCoreOperationStep.NoManufacturingPlan)
                    {
                        DisplayItem();
                    }
                }
                else if (progress.State is OperationState.Finished or OperationState.Canceled)
                {
                    cmbDonutSizes.SelectedItem = UserInput.CoreSize;

                    SetBusy(false);

                    TryEnableTesting();
                    ValidateItem();
                    ValidateItemVoltageValue();
                }
            }

            void TryEnableTesting()
            {
                if (cmbDonutSizes.CanFocus)
                {
                    cmbDonutSizes.Focus();
                }

                EnableTesting();

                if (txtTestCode.CanFocus)
                {
                    txtTestCode.Focus();
                }
            }
        }

        #endregion

        #region Commands

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
                    if (UserInput.TestCode.Length != 8)
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

                            if (!chkRework.Checked)
                            {
                                if (string.IsNullOrWhiteSpace(UserInput.Tag))
                                {
                                    if (MessageBox.Show(
                                        "No se ha registrado una etiqueta ¿desea continuar?",
                                        TestCoreMessageTitle,
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question)
                                        == DialogResult.No)
                                    {
                                        startTest = false;
                                    }
                                }
                                else if (UserInput.Tag.Length != 8)
                                {
                                    ShowWarningMessage("La etiqueta debe de ser de 8 caracteres.", TestCoreMessageTitle);
                                }
                            }

                            //if (!string.IsNullOrWhiteSpace(UserInput.Tag) && UserInput.Tag.Length != 8 && !chkRework.Checked)
                            //{
                            //    ShowWarningMessage("La etiqueta debe de ser de 8 caracteres.", TestCoreMessageTitle);
                            //}

                            if (startTest && ItemVoltage?.SecondaryVoltage == 0d)
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

                            if (startTest && Item != null
                                && ItemVoltage != null
                                && ItemVoltage.TestVoltage.HasValue)
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
                                    .Send(new ReadTestValuesCommand(ItemVoltage.TestVoltage.Value), CancellationToken.None)
                                    .ConfigureAwait(false);

                                operation.Report((TestCoreOperationStep.ReadCoreTestValues, coreTestValues, coreTemperature));

                                if (chkRework.Checked)
                                {
                                    TestResult = await mediator
                                        .Send(new ReworkResidentialCoreCommand(
                                            Item.ItemId,
                                            Item.CoreSize,
                                            coreTestValues.AverageVoltage,
                                            coreTestValues.RMSVoltage,
                                            coreTestValues.Current,
                                            coreTestValues.Temperature,
                                            coreTestValues.Watts,
                                            coreTemperature,
                                            UserInput.TestCode,
                                            stationId),
                                            CancellationToken.None)
                                        .ConfigureAwait(false);
                                }
                                else
                                {
                                    TestResult = await mediator
                                        .Send(new TestResidentialCoreCommand(
                                            UserInput.Tag,
                                            Item.ItemId,
                                            Item.CoreSize,
                                            coreTestValues.AverageVoltage,
                                            coreTestValues.RMSVoltage,
                                            coreTestValues.Current,
                                            coreTestValues.Temperature,
                                            coreTestValues.Watts,
                                            coreTemperature,
                                            UserInput.TestCode,
                                            stationId),
                                            CancellationToken.None)
                                        .ConfigureAwait(false);
                                }

                                operation.Report((TestCoreOperationStep.CoreTestResult, null, 0d));

                                Tags.RemoveAll(t => t.Tag == Item.Tag);

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

                    if (TestResult != null)
                    {
                        RefreshTagsComboBox();
                        txtTestCode.Text = "";
                        FindItems();
                    }
                    txtTestCode.Focus();
                    ValidateTestResult();
                }
            }
        }

        private async void RegisterDefect(ItemModel core, string defect)
        {
            OperationReporter<bool> operation = new(OnProgressChanged);

            try
            {
                operation.Start();

                TestResult = await mediator.Send(new RegisterDefectCommand(UserInput.TestCode, defect))
                     .ConfigureAwait(false);

                operation.Report(true);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Ocurrió un error al registrar un defecto al núcleo.", TestCoreMessageTitle, ex);
            }
            finally
            {
                operation.Finish();
            }

            void OnProgressChanged(OperationProgress<bool> progress)
            {
                if (progress.State == OperationState.Started)
                {
                    SetBusy(true);
                }
                else if (progress.State is OperationState.Canceled or OperationState.Finished)
                {
                    DisplayTestResult();
                    SetBusy(false);
                }
            }
        }

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

        private async void Calibrate()
        {
            try
            {
                bool needsCalibration = !await mediator
                    .Send(new ReadCalibrationStatusCommand(), CancellationToken.None);

                if (needsCalibration)
                {
                    int calibrationTimeMinutes = _configuration.GetValue<int>("CoreTests:CalibrationTimeMinutes");

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

                    CalibrationForm form = new(mediator, _configuration);

                    form.ShowDialog();

                    needsCalibration = !await mediator.Send(new ReadCalibrationStatusCommand(), CancellationToken.None);
                    if (!needsCalibration)
                    {
                        FindTags();
                    }

                    if (CanTestCore() && txtTestCode.CanFocus)
                    {
                        txtTestCode.Focus();
                    }
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

        private void CloseForm() => Close();

        #endregion

        #region Functionality

        private void UpdateUserInput()
        {
            string itemId = cmbItems.Text = cmbItems.Text.Trim();

            if (chkRework.Checked)
            {
                itemId = txtItem.Text = txtItem.Text.Trim();
            }

            if (UserInput.ItemId != itemId)
            {
                UserInput.ItemId = itemId;
                ResetCore();
                cmbDonutSizes.SelectedItem = CoreSizeModel.None;
                txtTestCode.Text = string.Empty;
            }

            if (cmbDonutSizes.SelectedItem is CoreSizeModel selectedCoreSize)
            {
                if (UserInput.CoreSize != selectedCoreSize)
                {
                    UserInput.CoreSize = selectedCoreSize;
                }

                if (!string.IsNullOrWhiteSpace(UserInput.ItemId)
                    && UserInput.ItemId == itemId)
                {
                    if (UserInput.CoreSize == CoreSizeModel.None)
                    {
                        if (Item != null)
                        {
                            int phases = Item?.Phases ?? 0;

                            ResetCore();
                            Item = new(UserInput.ItemId, phases);
                            cmbTags.Text = string.Empty;
                            UserInput.Tag = string.Empty;
                        }
                    }
                    else if (Item == null || (int)Item.CoreSize != UserInput.CoreSize.Id || ItemVoltage == null)
                    {
                        FindCore();
                    }
                }
            }
        }

        private void ResetTest()
        {
            cmbItems.Text = null;
            cmbItems.SelectedIndex = -1;
            txtItem.Text = string.Empty;
            cmbTags.Text = string.Empty;
            cmbTags.SelectedIndex = -1;
            txtTestCode.Text = string.Empty;
            epForm.SetError(cmbItems, string.Empty);
            epForm.SetError(txtItem, string.Empty);
            epForm.SetError(cmbTags, string.Empty);
            epForm.SetError(txtTestCode, string.Empty);

            ResetCore();
        }

        private void ResetCore()
        {
            Item = null;
            ItemVoltage = null;

            DisplayItem();
            DisplayItemVoltages();
            ResetResults();
            EnableTesting();
        }

        private void EnableTesting()
            => txtTestCode.Enabled = CanTestCore();

        private void ResetResults()
        {
            OnTemperatureSensorValueChanged(0);
            OnCoreTestParemetersChanged(null, false);

            TestResult = null;
            DisplayTestResult();
        }

        private void RefreshTagsComboBox()
        {
            cmbTags.BeginUpdate();
            cmbTags.Items.Clear();
            cmbTags.Items.AddRange(Tags.Select(e => e.Tag).ToArray());
            cmbTags.EndUpdate();
            cmbTags.Refresh();
        }

        private bool CanTestCore()
        {
            if (Item != null && ItemVoltage != null
                    && ItemVoltage.KVA.HasValue
                    && ItemVoltage.SecondaryVoltage.HasValue
                    && ItemVoltage.TestVoltage.HasValue
                    && ItemVoltage.Limits.Any())
            {
                return chkRework.Checked || Item.ScheduledDate.HasValue;
            }

            return false;
        }

        private void SetBusy(bool formIsBusy)
        {
            chkRework.Enabled = !formIsBusy;
            pbFindCore.Visible = formIsBusy;
            pbFindCore.Enabled = formIsBusy;
            cmbItems.Enabled = !formIsBusy;
            btnFindItems.Enabled = cmbItems.Enabled;
            txtItem.Enabled = !formIsBusy;
            btnFindItem.Enabled = txtItem.Enabled;
            cmbDonutSizes.Enabled = !formIsBusy && (Item?.Phases > 1);
            cmbTags.Enabled = !formIsBusy && !chkRework.Checked;
            btnRefreshTags.Enabled = cmbTags.Enabled;
            txtTestCode.Enabled = (!formIsBusy) && CanTestCore();
            btnTest.Enabled = (!formIsBusy) && CanTestCore();
            btnRegisterDefect.Enabled = (!formIsBusy) && (TestResult != null);
            btnExit.Enabled = !formIsBusy;
        }

        private void DisplayDateRanges()
        {
            try
            {
                DateRangeAvailableModel? posteDateRange = DateRangeAvailable.FirstOrDefault(e => e.ProductLine == (int)ProductLine.Poste);
                DateRangeAvailableModel? pedestalDateRange = DateRangeAvailable.FirstOrDefault(e => e.ProductLine == (int)ProductLine.Pedestal);

                string posteStartDateString = posteDateRange == null ? "-" : posteDateRange.StartUtcDate.ToLocalTime().ToString("MM/dd/yyyy");
                string posteEndDateString = posteDateRange == null ? "-" : posteDateRange.EndUtcDate.ToLocalTime().ToString("MM/dd/yyyy");
                string pedestalStartDateString = pedestalDateRange == null ? "-" : pedestalDateRange.StartUtcDate.ToLocalTime().ToString("MM/dd/yyyy");
                string pedestalEndDateString = pedestalDateRange == null ? "-" : pedestalDateRange.EndUtcDate.ToLocalTime().ToString("MM/dd/yyyy");

                System.Text.StringBuilder stringBuilder = new();
                stringBuilder.AppendLine("Fechas de programa");
                stringBuilder.AppendLine($"POSTE: desde {posteStartDateString} al {posteEndDateString}");
                stringBuilder.AppendLine($"PEDESTAL: desde {pedestalStartDateString} al {pedestalEndDateString}");

                lblDateRanges.Text = stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(
                    "Ocurrió un error al mostrar los rangos de fecha disponibles.",
                    FindCoreMessageTitle,
                    ex);
            }
        }

        private void DisplayItem()
        {
            try
            {
                gbFind.ForeColor = ThemePrimaryColor;
                gbInformation.ForeColor = ThemePrimaryColor;
                cmbItems.ForeColor = ThemePrimaryColor;
                txtItem.ForeColor = ThemePrimaryColor;

                lblBatchValue.Text = chkRework.Checked ? "00" : $"{Item?.Batch ?? "00"}";
                lblSerieValue.Text = chkRework.Checked ? "-1" : $"{Item?.Serie ?? -1}";

                lblSequenceValue.Text = chkRework.Checked ? "0" : $"{Item?.Sequence ?? 0}";

                lblLineTypeValue.Text = Item?.ProductLine switch
                {
                    ProductLine.Poste => "POSTE",
                    ProductLine.Pedestal => "PEDESTAL",
                    _ => Item == null ? "-" : "Desconocido",
                };

                lblScheduledDateValue.Text = (Item?.ScheduledDate?.ToString("d")) ?? "-";

                lblPieceNumberValue.Text = $"{Item?.TestedCores ?? 0}/{Item?.TotalCores ?? 0}";

                lblTestNumberValue.Text = "-";
            }
            catch (Exception ex)
            {
                ShowErrorMessage(
                    "Ocurrió un error al mostrar la información del núcleo.",
                    FindCoreMessageTitle,
                    ex);
            }
        }

        private void DisplayItemVoltages()
        {
            try
            {
                gbDiseño.ForeColor = ThemePrimaryColor;
                DisplayValueInLabel(ItemVoltage?.KVA, lblKVAValue);

                lblPrimaryVoltageValue.Text = (ItemVoltage?.PrimaryVoltage.ToString()) ?? "-";

                DisplayValueInLabel(ItemVoltage?.SecondaryVoltage, lblSecondaryVoltageValue);

                DisplayValueInLabel(ItemVoltage?.TestVoltage, lblTestVoltageValue);

                gbColores.ForeColor = ThemePrimaryColor;

                lblAzulMin.Text = (ItemVoltage?.Limits.Where(e => e.Color == CoreLimitColor.Blue)
                    .Select(e => e.Min)
                    .FirstOrDefault()
                    .ToString()) ?? "-";

                lblAzulMax.Text = (ItemVoltage?.Limits.Where(e => e.Color == CoreLimitColor.Blue)
                    .Select(e => e.Max)
                    .FirstOrDefault()
                    .ToString()) ?? "-";

                lblVerMin.Text = (ItemVoltage?.Limits.Where(e => e.Color == CoreLimitColor.Green)
                    .Select(e => e.Min)
                    .FirstOrDefault()
                    .ToString()) ?? "-";

                lblVerMax.Text = (ItemVoltage?.Limits.Where(e => e.Color == CoreLimitColor.Green)
                    .Select(e => e.Max)
                    .FirstOrDefault()
                    .ToString()) ?? "-";

                lblAmaMin.Text = (ItemVoltage?.Limits.Where(e => e.Color == CoreLimitColor.Yellow)
                    .Select(e => e.Min)
                    .FirstOrDefault()
                    .ToString()) ?? "-";

                lblAmaMax.Text = (ItemVoltage?.Limits.Where(e => e.Color == CoreLimitColor.Yellow)
                    .Select(e => e.Max)
                    .FirstOrDefault()
                    .ToString()) ?? "-";

                lblRojMin.Text = (ItemVoltage?.Limits.Where(e => e.Color == CoreLimitColor.Red)
                    .Select(e => e.Min)
                    .FirstOrDefault()
                    .ToString()) ?? "-";

                lblRojMax.Text = (ItemVoltage?.Limits.Where(e => e.Color == CoreLimitColor.Red)
                    .Select(e => e.Max)
                    .FirstOrDefault()
                    .ToString()) ?? "-";
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
                double currentPercentage = TestResult?.CurrentPercentage ?? 0d;
                lblCurrentPercentageValue.Text = (currentPercentage > 0) ? (currentPercentage / 100d).ToString("p0") : "-";
                lblColorName.Text = TestResult?.Color switch
                {
                    CoreLimitColor.Blue => "AZUL",
                    CoreLimitColor.Green => "VERDE",
                    CoreLimitColor.Yellow => "AMARILLO",
                    CoreLimitColor.Red => "ROJO",
                    _ => "",
                };
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

                    lblPieceNumberValue.Text = $"{testedCores}/{totalCores}";
                    lblTestNumberValue.Text = $"{TestResult.TotalTests}";

                    if (Item != null)
                    {
                        Item.TotalCores = totalCores;
                        Item.TestedCores = testedCores;
                    }
                }
                else
                {
                    lblPieceNumberValue.Text = $"{Item?.TestedCores ?? 0}/{Item?.TotalCores ?? 0}";
                    lblTestNumberValue.Text = "-";
                }
            }
            catch
            {
                ShowErrorMessage("Ocurrió un error al mostrar el resultado de la prueba.", TestCoreMessageTitle);
            }
        }

        private void ValidateItem()
        {
            if (Item != null)
            {
                if (!chkRework.Checked && Item.ScheduledDate == null)
                {
                    cmbItems.ForeColor = Color.Red;

                    if (CoreValidationMessageEnabled)
                    {
                        ShowWarningMessage(
                            "La orden no se encuentra en el plan de fabricación de núcleos.",
                            FindCoreMessageTitle,
                            new UserException("La orden no se encuentra en el plan de fabricación de núcleos.", (int)SystemErrorCode.ManufacturingPlanNotFound));
                    }
                    else
                    {
                        CoreValidationMessageEnabled = true;
                    }
                }
            }
            else
            {
                if (CoreValidationMessageEnabled)
                {
                    gbFind.ForeColor = Color.Red;

                    ShowWarningMessage("El artículo no existe.", FindCoreMessageTitle);
                }
                else
                {
                    CoreValidationMessageEnabled = true;
                }
            }
        }

        private void ValidateItemVoltageValue()
        {
            if (Item == null)
            {
                return;
            }

            if (UserInput.CoreSize != CoreSizeModel.None)
            {
                if (ItemVoltage != null)
                {
                    SetRedLabel(ItemVoltage?.KVA, lblKVAValue);

                    lblPrimaryVoltageValue.Text = (ItemVoltage?.PrimaryVoltage.ToString()) ?? "-";

                    SetRedLabel(ItemVoltage?.SecondaryVoltage, lblSecondaryVoltageValue);

                    SetRedLabel(ItemVoltage?.TestVoltage, lblTestVoltageValue);

                    ShowIncompleteErrorMessage(
                       ItemVoltage?.KVA is null or <= 0d,
                       ItemVoltage?.SecondaryVoltage == null,
                       ItemVoltage?.TestVoltage is null or < 0d,
                       ItemVoltage?.Limits.Count());

                    gbColores.ForeColor = (ItemVoltage?.Limits == null || !ItemVoltage.Limits.Any()) ?
                        Color.Red :
                        ThemePrimaryColor;
                }
                else
                {
                    gbDiseño.ForeColor = Color.Red;
                    gbColores.ForeColor = Color.Red;

                    if (CoreVoltageValidationMessageEnabled)
                    {
                        ShowErrorMessage(
                            "No existe información de diseño.",
                            FindCoreMessageTitle,
                            new UserException("No existe información de diseño.", (int)SystemErrorCode.DesignNotFound));
                    }
                    else
                    {
                        CoreVoltageValidationMessageEnabled = true;
                    }
                }
            }

            void SetRedLabel(double? value, Label label) => label.ForeColor = (value == null) ? Color.Red : ThemePrimaryColor;

            void ShowIncompleteErrorMessage(bool hasNoKVA, bool hasNoSecondaryVoltage, bool hasNoTestVoltage, int? limitsCount)
            {
                if (hasNoKVA || hasNoSecondaryVoltage || hasNoTestVoltage || limitsCount == 0)
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

                    if (limitsCount == 0)
                    {
                        messageBuilder.AppendLine("No hay información de rango de colores.");
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
    }

    internal enum FindCoreOperationStep
    {
        RefreshCoreInformation,
        NoManufacturingPlan,
        RefreshCoreVoltages,
    }

    public enum TestCoreOperationStep
    {
        ReadCoreTemperature,
        ReadCoreTestValues,
        CoreTestResult
    }
}