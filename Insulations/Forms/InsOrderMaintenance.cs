namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using Microsoft.AspNetCore.SignalR.Client;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;

    using Utils;

    public partial class InsOrderMaintenance : ThemedForm
    {
        #region Fields

        private readonly IServiceProvider serviceProvider;
        private readonly MediatR.IMediator mediator;
        private readonly ILogger<InsOrderMaintenance> logger;
        private readonly ILogger<AddOrdersToManufacturingForm> manufacturingLogger;
        private readonly ILogger<InOrderRequisition> orderRequisitionLogger;
        private readonly Microsoft.Extensions.Options.IOptionsMonitor<ThemeConfiguration> monitor;
        private readonly HubConnection connection;
        private readonly IProgress<HubConnectionState> connectionProgress;
        private readonly IProgress<bool> currentManufacturingProgress;
        private readonly IProgress<DataGridViewItemModel> orderAddedProgress;
        private readonly IProgress<ManufacturingOrderPriorityChangedModel> orderPriorityChangedProgress;
        private readonly IProgress<List<Guid>> ordersFinishedProgress;

        #endregion

        #region  Constructor

        public InsOrderMaintenance(
            ILogger<InsOrderMaintenance> logger,
            ILogger<AddOrdersToManufacturingForm> manufacturingLogger,
            IServiceProvider serviceProvider,
            ILogger<InOrderRequisition> orderRequisitionLogger,
            IConfiguration configuration,
            Microsoft.Extensions.Options.IOptionsMonitor<ThemeConfiguration> monitor,
            MediatR.IMediator mediator) : base(new ThemeConfiguration() { UseDarkTheme = true })
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.manufacturingLogger = manufacturingLogger ?? throw new ArgumentNullException(nameof(manufacturingLogger));
            this.orderRequisitionLogger = orderRequisitionLogger ?? throw new ArgumentNullException(nameof(orderRequisitionLogger));
            this.monitor = monitor ?? throw new ArgumentNullException(nameof(monitor));
            this.mediator = mediator;

            connection = new HubConnectionBuilder()
            .WithUrl(configuration.GetValue<string>("Urls:SignalR"))
            .WithAutomaticReconnect()
            .Build();
            connectionProgress = new Progress<HubConnectionState>(DisplayConnectionState);
            currentManufacturingProgress = new Progress<bool>(ReloadItems);
            orderAddedProgress = new Progress<DataGridViewItemModel>(AddOrder);
            orderPriorityChangedProgress = new Progress<ManufacturingOrderPriorityChangedModel>(ChangeOrderPriority);
            ordersFinishedProgress = new Progress<List<Guid>>(FinishOrders);

            Items = new BindingList<DataGridViewItemModel>();

            MachineAssignedOrdersModels = new List<MachineAssignedOrdersModel>();

            InitializeComponent();

            lblConnectionState.Visible = configuration.GetValue<bool>("SignalR:ShowConnectionState");

            CustomInitializeComponent();
        }

        #endregion

        #region Control initialization

        private void CustomInitializeComponent()
        {
            lblUserName.Text = Program.UserDisplayName;
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            grdManufacturePlan.Columns.Clear();
            grdManufacturePlan.AutoGenerateColumns = false;
            grdManufacturePlan.AllowUserToAddRows = false;
            grdManufacturePlan.AllowUserToDeleteRows = false;
            grdManufacturePlan.AllowUserToResizeRows = false;
            grdManufacturePlan.RowHeadersVisible = false;
            grdManufacturePlan.MultiSelect = false;
            grdManufacturePlan.Enabled = true;

            DataGridViewTextBoxColumn dataColumn = new();

            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.RowNumber);
            dataColumn.Name = nameof(DataGridViewItemModel.RowNumber);
            dataColumn.ReadOnly = true;
            dataColumn.HeaderText = "";
            grdManufacturePlan.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.Name = nameof(DataGridViewItemModel.Item);
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Item);
            dataColumn.ReadOnly = true;
            dataColumn.HeaderText = "ORDEN";
            grdManufacturePlan.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Batch);
            dataColumn.Name = nameof(DataGridViewItemModel.Batch);
            dataColumn.ReadOnly = true;
            dataColumn.HeaderText = "CONSECUTIVO";
            dataColumn.MinimumWidth = 120;
            grdManufacturePlan.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Serie);
            dataColumn.Name = nameof(DataGridViewItemModel.Serie);
            dataColumn.ReadOnly = true;
            dataColumn.HeaderText = "SERIE";
            grdManufacturePlan.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Quantity);
            dataColumn.Name = nameof(DataGridViewItemModel.Quantity);
            dataColumn.ReadOnly = true;
            dataColumn.HeaderText = "CANT. ORDEN";
            grdManufacturePlan.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.RequisitionDate);
            dataColumn.Name = nameof(DataGridViewItemModel.RequisitionDate);
            dataColumn.ReadOnly = true;
            dataColumn.HeaderText = "FECHA DE REQUISICIÓN";
            dataColumn.MinimumWidth = 120;
            grdManufacturePlan.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Machine);
            dataColumn.Name = nameof(DataGridViewItemModel.Machine);
            dataColumn.ReadOnly = true;
            dataColumn.HeaderText = "NÚMERO DE MÁQUINA";
            dataColumn.MinimumWidth = 120;
            grdManufacturePlan.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.InExecution);
            dataColumn.ReadOnly = true;
            dataColumn.HeaderText = "EN EJECUCIÓN";
            grdManufacturePlan.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Priority);
            dataColumn.ReadOnly = false;
            dataColumn.HeaderText = "PRIORIDAD";
            grdManufacturePlan.Columns.Add(dataColumn);

            DataGridViewCheckBoxColumn checkColumn = new();

            checkColumn.ValueType = typeof(bool);
            checkColumn.Name = nameof(DataGridViewItemModel.ChangePriority);
            checkColumn.DataPropertyName = nameof(DataGridViewItemModel.ChangePriority);
            checkColumn.HeaderText = "CAMBIAR PRIORIDAD";
            checkColumn.ReadOnly = false;
            grdManufacturePlan.Columns.Add(checkColumn);
        }

        private void InitializeMachineGrid()
        {
            int rowLimit = 15;
            int counter = 0;
            int records = MachineAssignedOrdersModels.Count;
            int columnNumber = (int)(records / rowLimit);
            if (records % 1 == 0)
            {
                columnNumber += 1;
            }

            grdMachines.Columns.Clear();
            grdMachines.AutoGenerateColumns = false;
            grdMachines.AllowUserToAddRows = false;
            grdMachines.AllowUserToDeleteRows = false;
            grdMachines.AllowUserToResizeRows = false;
            grdMachines.RowHeadersVisible = false;
            grdMachines.MultiSelect = false;
            grdMachines.EditMode = DataGridViewEditMode.EditProgrammatically;
            grdMachines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
            for (int i = 0; i < columnNumber; i++)
            {
                DataGridViewTextBoxColumn dataColumn = new();
                dataColumn.Name = i.ToString();
                dataColumn.ReadOnly = false;
                dataColumn.HeaderText = "Máquina";
                dataColumn.DefaultCellStyle = new DataGridViewCellStyle(grdMachines.DefaultCellStyle)
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                };
                dataColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                grdMachines.Columns.Add(dataColumn);
            }

            if (records > 0)
            {
                for (int cell = 0; cell < rowLimit; cell++)
                {
                    grdMachines.Rows.Add();
                }

                for (int i = 0; i < columnNumber; i++)
                {
                    for (int row = 0; row < rowLimit; row++)
                    {
                        if (MachineAssignedOrdersModels.Count <= counter)
                        {
                            return;
                        }
                        if (MachineAssignedOrdersModels[counter].Summary > 0)
                        {
                            grdMachines.Rows[row].Cells[i].Value = MachineAssignedOrdersModels[counter].Number
                                + " (" + MachineAssignedOrdersModels[counter].Summary + ")";
                        }
                        else
                        {
                            grdMachines.Rows[row].Cells[i].Value = MachineAssignedOrdersModels[counter].Number + " (-)";
                        }
                        counter += 1;
                    }
                }
            }
        }

        #endregion

        #region Propierties

        internal BindingList<DataGridViewItemModel> Items { get; private set; }

        internal List<MachineAssignedOrdersModel> MachineAssignedOrdersModels { get; set; }

        internal MachineWorkloadFlagConfigurationModel? MachineWorkLoadFlagConfiguration { get; set; }

        internal string? SelectedMachine { set; get; }

        internal Color SelectedMachineColor { set; get; }

        internal Color SelectedMachineForeColor { set; get; }

        internal Color ItemsGridColor { set; get; }

        internal bool IsManufacturingAllowed { get; set; }

        #endregion

        #region Events

        private void BtnCallCMSSupplie_Click(object sender, EventArgs e)
        {
            if (grdManufacturePlan.SelectedCells.Count > 0)
            {
                if (grdManufacturePlan.SelectedCells[0].Value.ToString()?.Split('(')[0] != "1")
                {
                    SelectedMachine = grdManufacturePlan.SelectedCells[0].Value.ToString()?.Split('(')[0].Trim();
                }
            }
            else
            {
                SelectedMachine = string.Empty;
            }

            AddOrdersToManufacturingForm form = new(manufacturingLogger, monitor, mediator);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void BtnRefresh_Click(object sender, EventArgs e) => LoadItems();

        private async void InsOrderMaintenance_Load(object sender, EventArgs e)
        {
            connection.Reconnecting += OnReconnecting;
            connection.Reconnected += OnReconnected;
            connection.Closed += OnConnectionClosed;

            connection.On<ManufacturingOrderModel?>("CurrentManufacturingChanged", OnCurrentManufacturingChanged);
            connection.On<IEnumerable<ManufacturingOrderAddedModel>>("OrdersAdded", OrdersAdded);
            connection.On<ManufacturingOrderPriorityChangedModel>("OrderPriorityChanged", OnOrderPriorityChanged);
            connection.On<List<Guid>>("OrdersFinished", OnOrdersFinished);
            connection.On("StopManufacturing", () => OnCurrentManufacturingChanged(null));

            LoadWorkLoadMachineConfiguration();
            RefreshAllowManufacturing();
            await ConnectAsync().ConfigureAwait(false);
        }

        private void BtnAccept_Click(object sender, EventArgs e) => UpdatePriorityProccess();

        private void GrdManufacturePlan_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1 && grdManufacturePlan.Columns[e.ColumnIndex].DataPropertyName == nameof(DataGridViewItemModel.Priority))
            {
                DataGridView dataGridView = (DataGridView)sender;
                dataGridView.Rows[e.RowIndex].ErrorText = "";
                if (!int.TryParse(e.FormattedValue.ToString(),
                               out int newInteger) || newInteger < 0 || newInteger > 999)
                {
                    e.Cancel = true;
                    dataGridView.Rows[e.RowIndex].ErrorText = "El valor debe encontrarse entre 0 y 999";
                }
            }
        }

        private void GrdManufacturePlan_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (grdManufacturePlan.Rows[e.RowIndex].DataBoundItem is DataGridViewItemModel custom)
                {
                    if (custom.Status != 0)// 0 means Pending
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void GrdMachines_SelectionChanged(object sender, EventArgs e)
        {
            if (grdMachines.SelectedCells.Count > 0)
            {
                DataGridViewCell? selectedCell = grdMachines.SelectedCells[0];
                if (selectedCell != null)
                {
                    if (selectedCell.Value != null && selectedCell.Value.ToString() != "1")
                    {
                        SelectedMachine = selectedCell.Value.ToString()?
                            .Split('(')[0].Trim();

                        if (MachineAssignedOrdersModels.Any(e => e.Number == SelectedMachine?.Trim()))
                        {
                            MachineAssignedOrdersModel? machine = MachineAssignedOrdersModels.Where(e => e.Number == SelectedMachine?.Trim()).FirstOrDefault();
                            if (machine != null)
                            {
                                (SelectedMachineColor, SelectedMachineForeColor) = GetBackGroundColor(machine.Summary, machine.Available);
                            }
                        }
                        grdManufacturePlan.Refresh();
                    }
                }
            }
        }

        private void GrdMachines_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                DataGridViewCell? cell = grdMachines.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell != null && cell.Value != null)
                {
                    string? machineNumber = cell.Value.ToString()?
                                                .Split('(')[0].Trim();

                    if (MachineAssignedOrdersModels.Any(e => e.Number == machineNumber?.Trim()))
                    {
                        MachineAssignedOrdersModel? machine = MachineAssignedOrdersModels.Where(e => e.Number == machineNumber?.Trim()).FirstOrDefault();
                        if (machine != null)
                        {
                            (cell.Style.BackColor, cell.Style.ForeColor) = GetBackGroundColor(machine.Summary, machine.Available);
                        }
                        cell.Style.SelectionBackColor = Color.FromKnownColor(KnownColor.Highlight);
                    }
                }
            }

        }

        private void GrdManufacturePlan_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DataGridViewCell cell = grdManufacturePlan.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.OwningRow.DataBoundItem is DataGridViewItemModel order)
                {
                    if (order.Machine != SelectedMachine)
                    {
                        cell.Style.BackColor = ItemsGridColor;
                        cell.Style.ForeColor = grdManufacturePlan.DefaultCellStyle.ForeColor;
                    }
                    else
                    {
                        cell.Style.BackColor = SelectedMachineColor;
                        cell.Style.ForeColor = SelectedMachineForeColor;
                    }
                }
            }
        }

        private void BtnExit_Click(object sender, EventArgs e) => Close();

        private void BtnSuspend_Click(object sender, EventArgs e) => ChangeAllowManufacturing();

        private void BtnOrderInsert_Click(object sender, EventArgs e) => AddOrderToRapir();

        #endregion

        #region ConnectionEvents

        private Task OnReconnecting(Exception? arg)
        {
            connectionProgress.Report(connection.State);
            return Task.CompletedTask;
        }

        private async Task OnReconnected(string? arg)
        {
            connectionProgress.Report(connection.State);
            await Task.CompletedTask;
        }

        private async Task OnConnectionClosed(Exception? arg)
        {
            connectionProgress.Report(connection.State);
            await ConnectAsync().ConfigureAwait(false);
        }

        private async Task<bool> ConnectAsync()
        {
            // Keep trying to until we can start or the token is canceled.
            while (true)
            {
                try
                {
                    connectionProgress.Report(HubConnectionState.Connecting);

                    await Task.Delay(new Random().Next(0, 3) * 1000).ConfigureAwait(false);

                    await connection.StartAsync().ConfigureAwait(false);

                    System.Diagnostics.Debug.Assert(connection.State == HubConnectionState.Connected);
                    connectionProgress.Report(connection.State);

                    return true;
                }
                catch
                {
                    System.Diagnostics.Debug.Assert(connection.State == HubConnectionState.Disconnected);
                    await Task.Delay(3000).ConfigureAwait(false);
                }
            }
        }


        private void DisplayConnectionState(HubConnectionState obj)
        {
            switch (obj)
            {
                case HubConnectionState.Disconnected:
                    lblConnectionState.Text = "Desconectado";
                    break;
                case HubConnectionState.Connected:
                    lblConnectionState.Text = "Conectado";
                    break;
                case HubConnectionState.Connecting:
                    lblConnectionState.Text = "Conectando...";
                    break;
                case HubConnectionState.Reconnecting:
                    lblConnectionState.Text = "Reconectando...";
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Signal R Hub events

        private void OnCurrentManufacturingChanged(ManufacturingOrderModel? manufacturingOrder)
            => currentManufacturingProgress.Report(manufacturingOrder != null);

        private void OrdersAdded(IEnumerable<ManufacturingOrderAddedModel> orders)
        {
            foreach (ManufacturingOrderAddedModel order in orders)
            {
                orderAddedProgress.Report(new DataGridViewItemModel(
                    order.Id,
                    order.ItemId,
                    order.Batch,
                    order.Serie,
                    order.Machine,
                    order.Quantity,
                    order.Priority,
                    order.RequestUtcDate,
                    order.Status));
            }
        }

        private void OnOrderPriorityChanged(ManufacturingOrderPriorityChangedModel orderChanged)
            => orderPriorityChangedProgress.Report(orderChanged);

        private void OnOrdersFinished(List<Guid> ids)
            => ordersFinishedProgress.Report(ids);

        #endregion

        #region Queries

        private async void LoadItems()
        {
            OperationProgress<bool> operation = new(OnProgressChanged);

            try
            {
                operation.Start();
                Items = new BindingList<DataGridViewItemModel>((await mediator
                    .Send(new ClientApp.Queries.InsulationManufactureQuery())
                    .ConfigureAwait(false))
                    .Select(e => new DataGridViewItemModel(
                        e.Id,
                        e.ItemId,
                        e.Batch,
                        e.Serie,
                        e.Machine,
                        e.Quantity,
                        e.Priority,
                        e.RequestUtcDate,
                        e.Status))
                    .ToList());

                operation.Report(true);
            }
            catch (Exception ex)
            {
                operation.Error("Ocurrió un error al cargar el listado de ordenes.", ex);
            }
            finally
            {
                operation.Finish();
            }

            void OnProgressChanged(OperationProgressReport<bool> progressReport)
            {
                if (progressReport.State == OperationState.Started)
                {
                    SetBusy(true);
                    grdManufacturePlan.DataSource = null;
                }
                else if (progressReport.State == OperationState.Running)
                {
                    if (progressReport.Value == true)
                    {
                        DisplayItems();
                        LoadMachines();
                    }
                }
                else if (progressReport.State == OperationState.Error)
                {
                    ShowErrorMessage(progressReport.ErrorMessage ?? "", "Cargando listado de ordenes", progressReport.Exception);
                }
                else if (progressReport.State == OperationState.Canceled || progressReport.State == OperationState.Finished)
                {
                    SetBusy(false);
                }
            }
        }

        private async void LoadMachines()
        {
            OperationProgress<bool> operation = new(OnProgressChanged);

            try
            {
                operation.Start();
                MachineAssignedOrdersModels = (await mediator
                    .Send(new ClientApp.Queries.MachineAssignedOrdersQuery())
                    .ConfigureAwait(false))
                    .ToList();

                operation.Report(true);
            }
            catch (Exception ex)
            {
                operation.Error("Ocurrió un error al cargar el listado de ordenes por maquina.", ex);
            }
            finally
            {
                operation.Finish();
            }

            void OnProgressChanged(OperationProgressReport<bool> progressReport)
            {
                if (progressReport.State == OperationState.Started)
                {
                    SetBusy(true);
                }
                else if (progressReport.State == OperationState.Running)
                {

                }
                else if (progressReport.State == OperationState.Error)
                {
                    ShowErrorMessage(progressReport.ErrorMessage ?? "", "Cargando listado de ordenes por maquina", progressReport.Exception);
                }
                else if (progressReport.State == OperationState.Canceled || progressReport.State == OperationState.Finished)
                {
                    InitializeMachineGrid();
                    LoadSelectionColor();
                    MachineSelection();
                    grdManufacturePlan.Refresh();
                    SetBusy(false);
                    grdMachines.ClearSelection();
                }
            }
        }

        private async void LoadWorkLoadMachineConfiguration()
        {
            OperationProgress<bool> operation = new(OnProgressChanged);

            try
            {
                operation.Start();
                MachineWorkLoadFlagConfiguration = (await mediator
                    .Send(new ClientApp.Queries.MachineWorkloadFlagConfigurationsQuery())
                    .ConfigureAwait(false));

                operation.Report(true);
            }
            catch (Exception ex)
            {
                operation.Error("Ocurrió un error al cargar la carga de trabajo por maquinas.", ex);
            }
            finally
            {
                operation.Finish();
            }

            void OnProgressChanged(OperationProgressReport<bool> progressReport)
            {
                if (progressReport.State == OperationState.Started)
                {
                    SetBusy(true);
                }
                else if (progressReport.State == OperationState.Running)
                {
                }
                else if (progressReport.State == OperationState.Error)
                {
                    ShowErrorMessage(progressReport.ErrorMessage ?? "", "Cargando configuración de colores de carga de trabajo por maquina", progressReport.Exception);
                }
                else if (progressReport.State == OperationState.Canceled || progressReport.State == OperationState.Finished)
                {
                    SetBusy(false);
                }
            }
        }

        private async void RefreshAllowManufacturing()
        {
            OperationProgress<bool> operation = new(OnProgressChanged);

            try
            {
                operation.Start();

                IsManufacturingAllowed = await mediator
                    .Send(new ClientApp.Queries.IsManufacturingAllowedQuery())
                    .ConfigureAwait(false);

                operation.Report(true);
            }
            catch (Exception ex)
            {
                operation.Error("Ocurrió un error al consultar el estado de las labores.", ex);
            }
            finally
            {
                operation.Finish();
            }

            void OnProgressChanged(OperationProgressReport<bool> progressReport)
            {
                if (progressReport.State == OperationState.Started)
                {
                    btnSuspend.Text = "";
                    btnSuspend.Enabled = false;
                }
                else if (progressReport.State == OperationState.Running)
                {
                }
                else if (progressReport.State == OperationState.Error)
                {
                    ShowErrorMessage(progressReport.ErrorMessage ?? "", "Inicio/Suspensión de labores.", progressReport.Exception);
                }
                else if (progressReport.State == OperationState.Canceled || progressReport.State == OperationState.Finished)
                {
                    btnSuspend.Text = (IsManufacturingAllowed) ? "Suspender labores" : "Iniciar labores";
                    btnSuspend.Enabled = true;
                }
            }
        }

        #endregion

        #region Commands

        private async void UpdatePriorityProccess()
        {
            if (!Items.Any(e => e.ChangePriority))
            {
                MessageBox.Show("Si desea cambiar la prioridad de la orden debe seleccionar la opción CAMBIAR PRIORIDAD.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            OperationProgress<bool> operation = new(OnProgressChanged);

            if (Items.Any(e => e.ChangePriority))
            {
                DialogResult dialogResult = MessageBox.Show("¿Esta seguró de actualizar la prioridad de las ordenes seleccionadas?", "Actualizar prioridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    operation.Start(true);
                    foreach (DataGridViewItemModel item in Items.Where(e => e.ChangePriority))
                    {
                        try
                        {
                            await mediator
                                .Send(new ClientApp.Commands.UpdateManufacturingOrderPriorityCommand(item.Id, item.Priority))
                                .ConfigureAwait(false);
                        }
                        catch (Exception ex)
                        {
                            operation.Error($"Ocurrió un error al cambiar la prioridad de la orden: {item.Item}-{item.Batch}-{item.Serie}.", ex);
                        }
                    }
                    operation.Report(true);
                    operation.Finish();
                }
            }

            void OnProgressChanged(OperationProgressReport<bool> progressReport)
            {
                if (progressReport.State == OperationState.Started)
                {
                    SetBusy(true);
                }
                else if (progressReport.State == OperationState.Running)
                {
                }
                else if (progressReport.State == OperationState.Error)
                {
                    ShowErrorMessage(progressReport.ErrorMessage ?? "", "Cambiando prioridad", progressReport.Exception);
                }
                else if (progressReport.State == OperationState.Canceled || progressReport.State == OperationState.Finished)
                {
                    SetBusy(false);
                    if (connection.State != HubConnectionState.Connected)
                    {
                        LoadItems();
                    }
                }
            }
        }

        public async void ChangeAllowManufacturing()
        {
            OperationProgress<bool> operation = new(OnProgressChanged);

            string actionAllowManufacturing = (IsManufacturingAllowed) ? "suspender" : "iniciar";
            string message = $"¿Desea { actionAllowManufacturing } las labores?";
            if (IsManufacturingAllowed)
            {
                message += ",\n NOTA: LA ORDEN EN PROCESO NO SE SUSPENDERA";
            }

            DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                frmLogin login = serviceProvider.GetRequiredService<frmLogin>();
                login.Text = "Autorizar";
                login.IsUserLogin = false;
                login.StartPosition = FormStartPosition.CenterParent;

                if (login.ShowDialog() == DialogResult.OK)
                {
                    try
                    {

                        operation.Start();

                        await mediator
                           .Send(new ClientApp.Commands.ChangeAllowManufacturingCommand(!IsManufacturingAllowed))
                           .ConfigureAwait(false);

                        operation.Report(true);
                    }
                    catch (Exception ex)
                    {
                        operation.Error("Ocurrió un error al suspender/iniciar labores.", ex);
                    }
                    finally
                    {
                        operation.Finish();
                    }
                }
            }

            void OnProgressChanged(OperationProgressReport<bool> progressReport)
            {
                if (progressReport.State == OperationState.Started)
                {
                    btnSuspend.Enabled = false;
                }
                else if (progressReport.State == OperationState.Running)
                {
                }
                else if (progressReport.State == OperationState.Error)
                {
                    ShowErrorMessage(progressReport.ErrorMessage ?? "", "Inicio/Suspensión de labores.", progressReport.Exception);
                }
                else if (progressReport.State == OperationState.Canceled || progressReport.State == OperationState.Finished)
                {
                    RefreshAllowManufacturing();
                }
            }
        }

        private void AddOrderToRapir()
        {
            frmLogin login = serviceProvider.GetRequiredService<frmLogin>();
            login.Text = "Autorizar";
            login.IsUserLogin = false;
            login.StartPosition = FormStartPosition.CenterParent;

            if (login.ShowDialog() == DialogResult.OK)
            {
                InOrderRequisition form = new(orderRequisitionLogger, monitor, mediator);
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog();
            }
        }

        #endregion

        #region Theme

        protected override void OnThemeChanged(bool useDarkTheme)
        {
            base.OnThemeChanged(useDarkTheme);

            Font defaultColumnHeaderCellFont = grdMachines.ColumnHeadersDefaultCellStyle.Font;

            grdMachines.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle(grdMachines.DefaultCellStyle)
            {
                Font = new Font(
                    defaultColumnHeaderCellFont.Name,
                    9F,
                    defaultColumnHeaderCellFont.Style,
                    defaultColumnHeaderCellFont.Unit,
                    defaultColumnHeaderCellFont.GdiCharSet,
                    defaultColumnHeaderCellFont.GdiVerticalFont)
            };

            Font defaultCellFont = grdMachines.ColumnHeadersDefaultCellStyle.Font;
            grdMachines.DefaultCellStyle = new DataGridViewCellStyle(grdMachines.DefaultCellStyle)
            {
                Font = new Font(
                   defaultCellFont.Name,
                   9F,
                   defaultCellFont.Style,
                   defaultCellFont.Unit,
                   defaultCellFont.GdiCharSet,
                   defaultCellFont.GdiVerticalFont)
            };

            CustomTheme.Instance.ApplyLabelThemeAccentColor(lblConnectionState);
            CustomTheme.Instance.ApplyStandarImages(picBoxEnterpriseLogo, picBoxSubTitleLine);
            CustomTheme.Instance.ApplyUserImage(picBoxUserImage);
            CustomTheme.Instance.ApplySecondaryButtonTheme(btnExit);
            CustomTheme.Instance.ApplySecondaryButtonTheme(btnSuspend);
            CustomTheme.Instance.ApplySecondaryButtonTheme(btnRefresh);

            grdManufacturePlan.SetAllColumnsContentAlign(DataGridViewContentAlignment.MiddleCenter);
            ItemsGridColor = grdManufacturePlan.DefaultCellStyle.BackColor;
            grdMachines.DefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Highlight);
        }

        #endregion

        #region Functionality

        private void SetBusy(bool formIsBusy)
        {
            if (formIsBusy)
            {
                Cursor.Current = Cursors.WaitCursor;
            }
            else
            {
                Cursor.Current = Cursors.Default;
            }
            btnCallCMSSupplie.Enabled = !formIsBusy;
            btnRefresh.Enabled = !formIsBusy;
            btnAccept.Enabled = !formIsBusy;
        }

        public void DisplayItems()
        {
            grdManufacturePlan.DataSource = Items;
            foreach (DataGridViewRow row in grdManufacturePlan.Rows)
            {
                row.Cells[0].Value = string.Format("{0}", row.Index + 1);
            }
        }

        private void ReloadItems(bool inProgress) => LoadItems();

        private void AddOrder(DataGridViewItemModel newItem)
        {
            Items.Add(newItem);
            DisplayItems();
            LoadMachines();
        }

        private void ChangeOrderPriority(ManufacturingOrderPriorityChangedModel orderChanged)
        {
            DataGridViewItemModel? order = Items.FirstOrDefault(e => e.Id == orderChanged.Id);
            if (order != null)
            {
                order.Priority = orderChanged.Priority;
                order.ChangePriority = false;
            }
            Items = new(Items.OrderBy(e => e.Priority).ThenBy(e => e.RequisitionDate).ToList());
            DisplayItems();
        }

        private void FinishOrders(List<Guid> ids)
        {
            foreach (DataGridViewItemModel item in Items
                .Where(e => ids.Contains(e.Id))
                .ToList())
            {
                Items.Remove(item);
                LoadMachines();
            }
        }

        private void MachineSelection()
        {
            foreach (DataGridViewRow row in grdMachines.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        if (cell.Value != null)
                        {
                            string? machineNumber = cell.Value.ToString()?.Split('(')[0].Trim();
                            GetSelectionColor(machineNumber);
                            if (SelectedMachine == machineNumber?.Trim())
                            {
                                cell.Selected = true;
                            }
                        }
                    }
                }
            }
        }

        private void LoadSelectionColor()
        {
            foreach (DataGridViewRow row in grdMachines.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        if (cell.Value != null)
                        {
                            string? machineNumber = cell.Value.ToString()?.Split('(')[0].Trim();
                            MachineAssignedOrdersModel? machine = MachineAssignedOrdersModels.Where(e => e.Number == machineNumber?.Trim()).FirstOrDefault();
                            if (SelectedMachine == machineNumber?.Trim() && machine != null)
                            {
                                (SelectedMachineColor, SelectedMachineForeColor) = GetBackGroundColor(machine.Summary, machine.Available);
                            }
                        }
                    }
                }
            }
        }

        private void GetSelectionColor(string? machineNumber)
        {
            foreach (DataGridViewRow row in grdMachines.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        if (cell.Value != null)
                        {
                            MachineAssignedOrdersModel? machine = MachineAssignedOrdersModels.Where(e => e.Number == machineNumber?.Trim()).FirstOrDefault();
                            if (SelectedMachine == machineNumber?.Trim() && machine != null)
                            {
                                (SelectedMachineColor, SelectedMachineForeColor) = GetBackGroundColor(machine.Summary, machine.Available);
                            }
                        }
                    }
                }
            }
        }

        private (Color, Color) GetBackGroundColor(int summary, bool availeable)
        {
            Color backColor = grdManufacturePlan.DefaultCellStyle.BackColor;
            Color foreColor = grdManufacturePlan.DefaultCellStyle.BackColor;
            //critical color
            if (summary <= MachineWorkLoadFlagConfiguration?.LowLevel)
            {
                backColor = ColorTranslator.FromHtml(MachineWorkLoadFlagConfiguration.CriticalColor);
                foreColor = Color.White;
            }
            //warning color
            if (summary <= MachineWorkLoadFlagConfiguration?.HighLevel && summary > MachineWorkLoadFlagConfiguration?.LowLevel)
            {
                backColor = ColorTranslator.FromHtml(MachineWorkLoadFlagConfiguration.WarningColor);
                foreColor = Color.Black;
            }
            //normal color
            if (summary > MachineWorkLoadFlagConfiguration?.HighLevel)
            {
                backColor = ColorTranslator.FromHtml(MachineWorkLoadFlagConfiguration.NormalColor);
                foreColor = Color.White;
            }
            //Unable color
            if (!availeable)
            {
                if (MachineWorkLoadFlagConfiguration != null)
                {
                    backColor = ColorTranslator.FromHtml(MachineWorkLoadFlagConfiguration.LockedColor);
                    foreColor = Color.White;
                }
            }
            return (backColor, foreColor);
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

            ShowMessage(
                (MessageBoxIcon.Error,
                errorMessage,
                messageTitle,
                ex));
        }

        private void ShowMessage((
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
                    string? customMessage = null;

                    System.Text.StringBuilder stringBuilder = new();
                    stringBuilder.AppendLine(userException.Message);

                    if (!string.IsNullOrEmpty(customMessage))
                    {
                        stringBuilder.Append(customMessage);

                        if (userException.SystemErrorCode == 500)
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

        internal class DataGridViewItemModel
        {
            #region Constructor

            public DataGridViewItemModel(
                Guid id,
                string itemId,
                string batch,
                int serie,
                string machine,
                int quantity,
                int priority,
                DateTime requestUtcDate,
                int status)
            {
                Id = id;
                Item = itemId;
                Batch = batch;
                Serie = serie;
                Machine = machine;
                Quantity = quantity;
                Priority = priority;
                RequisitionDate = requestUtcDate.ToLocalTime().ToString("MM/dd/yyyy HH:mm");
                Status = status;
                InExecution = status == 1 ? "Si" : "No";
                CancelOrder = false;
                ChangePriority = false;
                RowNumber = 0;
                Status = status;
            }

            #endregion

            #region Properties

            public Guid Id { get; set; }

            //row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            public int RowNumber { set; get; }

            public string Item { get; set; }

            public string Batch { get; set; }

            public double Serie { get; set; }

            public int Quantity { get; set; }

            public string RequisitionDate { get; set; }

            public string Machine { get; set; }

            public string InExecution { get; set; }

            public int Priority { get; set; }

            public bool CancelOrder { get; set; }

            public bool ChangePriority { get; set; }

            public int Status { get; set; }

            #endregion
        }

    }
}