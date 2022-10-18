namespace ProlecGE.ControlPisoMX.CoreSupply.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;
    using Utils;

    public partial class ManufacturingStatusForm : ThemedForm
    {
        #region Fields

        private readonly MediatR.IMediator mediator;
        private readonly ILogger<ManufacturingStatusForm> logger;

        #endregion

        #region Constructors

        public ManufacturingStatusForm(
            ILogger<ManufacturingStatusForm> logger,
            MediatR.IMediator mediator)
        {
            Machines = new List<ComboBoxItemModel>();
            Orders = new BindingList<DataGridViewItemModel>();
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mediator = mediator;
            InitializeComponent();
            CustomInitializeComponent();
        }

        #endregion

        #region Properties

        private List<ComboBoxItemModel> Machines { set; get; }

        private BindingList<DataGridViewItemModel> Orders { set; get; }

        private string? SelectedMachine { set; get; }

        #endregion

        #region Controls initialization

        private void CustomInitializeComponent()
        {
            UseLightTheme();
            ApplyStandarImages(picBoxEnterpriseLogo, picBoxTitleLine);
            ApplyUserImage(picBoxUserImage);
            lblUserName.Text = Program.User.Name;

            ApplySecondaryButtonTheme(btnClose);

            dpDate.Format = DateTimePickerFormat.Custom;
            dpDate.CustomFormat = "MM/dd/yyyy";

            cmbMachines.ValueMember = nameof(ComboBoxItemModel.Number);
            cmbMachines.DisplayMember = nameof(ComboBoxItemModel.Number);

            grOrders.Columns.Clear();
            grOrders.AutoGenerateColumns = false;
            grOrders.AllowUserToAddRows = false;
            grOrders.AllowUserToDeleteRows = false;
            grOrders.AllowUserToResizeRows = false;
            grOrders.RowHeadersVisible = false;
            grOrders.MultiSelect = false;
            grOrders.CellPainting += OnGrOrders_CellPainting;

            DataGridViewTextBoxColumn dataColumn = new();

            dataColumn.HeaderText = "ARTÍCULO";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.ItemId);
            dataColumn.ReadOnly = true;
            dataColumn.MinimumWidth = 90;
            grOrders.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.HeaderText = "CONSECUTIVO";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Batch);
            dataColumn.ReadOnly = true;
            dataColumn.MinimumWidth = 110;
            grOrders.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.HeaderText = "SERIE";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Serie);
            dataColumn.ReadOnly = true;
            grOrders.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.HeaderText = "ETAPA";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.InsulationStatusDescription);
            dataColumn.ReadOnly = true;
            dataColumn.MinimumWidth = 110;
            grOrders.Columns.Add(dataColumn);

            DataGridViewCheckBoxColumn checkColumn = new();

            checkColumn.ValueType = typeof(bool);
            checkColumn.HeaderText = "      ";
            checkColumn.DataPropertyName = nameof(DataGridViewItemModel.Check);
            checkColumn.ReadOnly = false;
            dataColumn.MinimumWidth = 30;
            grOrders.Columns.Add(checkColumn);

            dataColumn = new();
            dataColumn.HeaderText = "SECUENCIA";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Sequence);
            dataColumn.ReadOnly = true;
            dataColumn.MinimumWidth = 100;
            grOrders.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.HeaderText = "PROBADO";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.CoreResultText);
            dataColumn.Name = nameof(DataGridViewItemModel.CoreTestColor);
            dataColumn.ReadOnly = true;
            dataColumn.MinimumWidth = 90;
            grOrders.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.HeaderText = "RACK";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.CoreLocation);
            dataColumn.ReadOnly = true;
            dataColumn.MinimumWidth = 80;
            grOrders.Columns.Add(dataColumn);

            SetColumnContentAlign(grOrders, DataGridViewContentAlignment.MiddleCenter, new string[]
            {
                nameof(DataGridViewItemModel.Batch),
                nameof(DataGridViewItemModel.Serie),
                nameof(DataGridViewItemModel.Check),
                nameof(DataGridViewItemModel.Sequence),
                nameof(DataGridViewItemModel.CoreResultText)
            });
            grOrders.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            grOrders.MultiSelect = true;
            grOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grOrders.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            grOrders.DefaultCellStyle.SelectionForeColor = Color.White;
            grOrders.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            grOrders.ColumnHeadersDefaultCellStyle.SelectionForeColor = grOrders.ColumnHeadersDefaultCellStyle.ForeColor;
        }

        #endregion

        #region Events

        private void OnSupplyForm_Load(object sender, EventArgs e) => LoadMachines();

        private void OnGrOrders_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (sender is DataGridView dataGridView)
                {
                    if (dataGridView.Rows[e.RowIndex].DataBoundItem is DataGridViewItemModel itemModel)
                    {
                        DataGridViewCellStyle cellStyle = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style;

                        if (grOrders.Columns[e.ColumnIndex].DataPropertyName == nameof(DataGridViewItemModel.InsulationStatusDescription)
                          || grOrders.Columns[e.ColumnIndex].DataPropertyName == nameof(DataGridViewItemModel.ItemId)
                          || grOrders.Columns[e.ColumnIndex].DataPropertyName == nameof(DataGridViewItemModel.Batch)
                          || grOrders.Columns[e.ColumnIndex].DataPropertyName == nameof(DataGridViewItemModel.Serie))
                        {
                            switch (itemModel.InsulationStatus)
                            {
                                case 0:
                                    cellStyle.ForeColor = Color.Blue;
                                    cellStyle.BackColor = Color.Yellow;
                                    break;
                                case 1:
                                    cellStyle.ForeColor = Color.Blue;
                                    cellStyle.BackColor = Color.Yellow;
                                    break;
                                case 2:
                                    cellStyle.ForeColor = Color.Black;
                                    cellStyle.BackColor = Color.White;
                                    break;
                                case 3:
                                    cellStyle.ForeColor = Color.Black;
                                    cellStyle.BackColor = Color.Green;
                                    break;
                                case -1:
                                    cellStyle.ForeColor = Color.Blue;
                                    cellStyle.BackColor = Color.White;
                                    break;
                                default:
                                    cellStyle.ForeColor = Color.Black;
                                    cellStyle.BackColor = Color.White;
                                    break;
                            }
                        }
                        else if (grOrders.Columns[e.ColumnIndex].DataPropertyName == nameof(DataGridViewItemModel.CoreResultText))
                        {
                            cellStyle.BackColor = itemModel.CoreTestColor switch
                            {
                                CoreLimitColor.Blue => Color.Blue,
                                CoreLimitColor.Green => GreenColor,
                                CoreLimitColor.Yellow => YellowColor,
                                CoreLimitColor.Red => RedColor,
                                CoreLimitColor.None => Color.White,
                                _ => Color.White,
                            };
                        }
                        else if (grOrders.Columns[e.ColumnIndex].DataPropertyName == nameof(DataGridViewItemModel.Check))
                        {
                            if ((itemModel.InsulationStatus == (int)InsulationsState.Finished) || (itemModel.InsulationStatus == (int)InsulationsState.InProgress) || (itemModel.InsulationStatus == (int)InsulationsState.Pending))
                            {
                                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                            }
                            else
                            {
                                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                            }
                        }
                    }
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e) => LoadOrders();

        private void BtnAdd_Click(object sender, EventArgs e) => AddOrderToSupplyList();

        private void CmbMachines_SelectedIndexChanged(object sender, EventArgs e)
        {
            Orders.Clear();
            SelectedMachine = cmbMachines.SelectedValue?.ToString();
        }

        private void BtnClose_Click(object sender, EventArgs e) => Close();

        #endregion

        #region Queries

        public async void LoadMachines()
        {
            OperationProgress<bool> operation = new(OnProgressChanged);

            try
            {
                operation.Start();
                Machines = (await mediator
                        .Send(new ClientApp.Queries.MachinesQuery())
                        .ConfigureAwait(false))
                        .Select(i => new ComboBoxItemModel()
                        {
                            Number = i.Number
                        })
                        .ToList();
                operation.Report(true);
            }
            catch (Exception ex)
            {
                operation.Error("Ocurrió un error al cargar las maquinas.", ex);
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
                    cmbMachines.DataSource = null;
                }
                else if (progressReport.State == OperationState.Running)
                {
                    if (progressReport.Value == true)
                    {
                        DisplayMachines();
                    }
                }
                else if (progressReport.State == OperationState.Error)
                {
                    ShowErrorMessage(progressReport.ErrorMessage ?? "", "Lista de maquinas", progressReport.Exception);
                }
                else if (progressReport.State == OperationState.Canceled || progressReport.State == OperationState.Finished)
                {
                    SetBusy(false);
                }
            }
        }

        public async void LoadOrders()
        {
            OperationProgress<bool> operation = new(OnProgressChanged);

            try
            {
                if (SelectedMachine == null)
                {
                    MessageBox.Show("Seleccione una maquina.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    operation.Start();

                    DateTime localDate = dpDate.Value.Date;

                    Orders.Clear();

                    Orders = new((await mediator
                        .Send(new ClientApp.Queries.MOAvailableToSupplyQuery(localDate, SelectedMachine))
                        .ConfigureAwait(false))
                        .Select(i => new DataGridViewItemModel(i.ItemId, i.Batch, i.Serie, i.Sequence, i.Machine, i.ScheduledDate)
                        {
                            InsulationStatus = i.InsulationStatus ?? -1,
                            Check = false,
                            CoreTestColor = i.CoreTestResult.HasValue ? (
                                (i.CoreTestResult.Value == CoreTestResult.Failed) ?
                                    CoreLimitColor.Red :
                                    i.CoreTestColor ?? CoreLimitColor.None) :
                                CoreLimitColor.None,
                            CoreLocation = i.CoreLocation,
                            CoreResultText = (i.CoreTestResult == CoreTestResult.Failed) ? "FALLADO" : ""
                        })
                        .ToList());

                    operation.Report(true);

                    if (!Orders.Any())
                    {
                        throw new UserException($"No se encontró información para la maquina {SelectedMachine} y la fecha {localDate:MM/dd/yyyy}.");
                    }
                }
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
                    DisplayOrders();
                }
                else if (progressReport.State == OperationState.Running)
                {
                    if (progressReport.Value == true)
                    {
                        DisplayOrders();
                    }
                }
                else if (progressReport.State == OperationState.Error)
                {
                    ShowErrorMessage(progressReport.ErrorMessage ?? "", Text, progressReport.Exception);
                }
                else if (progressReport.State == OperationState.Canceled || progressReport.State == OperationState.Finished)
                {
                    SetBusy(false);
                }
            }
        }

        #endregion

        #region Command

        public async void AddOrderToSupplyList()
        {
            OperationProgress<bool> operation = new(OnProgressChanged);

            IEnumerable<DataGridViewItemModel> checkedOrdes = Orders.Where(e => e.Check);

            if (!checkedOrdes.Any())
            {
                MessageBox.Show("Seleccione una orden.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                operation.Start();

                try
                {
                    await mediator
                      .Send(new ClientApp.Commands.AddOrdersToSupplyListCommand(checkedOrdes
                          .Select(checkedOrder => new OrderParameterModel(
                              checkedOrder.ItemId,
                              checkedOrder.Batch,
                              checkedOrder.Serie,
                              checkedOrder.Sequence))
                          .ToList()))
                      .ConfigureAwait(false);

                    operation.Report(true);
                }
                catch (Exception ex)
                {
                    operation.Error($"Ocurrió un error al suministrar las ordenes seleccionadas.", ex);
                }
                finally
                {
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
                    if (progressReport.Value)
                    {
                        LoadOrders();
                    }
                }
                else if (progressReport.State == OperationState.Error)
                {
                    ShowErrorMessage(progressReport.ErrorMessage ?? "", Text, progressReport.Exception);
                }
                else if (progressReport.State == OperationState.Canceled || progressReport.State == OperationState.Finished)
                {
                    SetBusy(false);
                }
            }
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

            btnSearch.Enabled = !formIsBusy;
            btnAdd.Enabled = !formIsBusy;
            btnClose.Enabled = !formIsBusy;
        }

        public void DisplayMachines() => cmbMachines.DataSource = Machines;

        private void DisplayOrders() => grOrders.DataSource = Orders;

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

            if (!IsDisposed)
            {
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
        }

        #endregion

        internal class DataGridViewItemModel
        {
            #region Constructor

            public DataGridViewItemModel(string itemId, string batch, int serie, int sequence, string machine, DateTime scheduledDate)
            {
                ItemId = itemId;
                Batch = batch;
                Serie = serie;
                Sequence = sequence;
                Machine = machine;
                ScheduledDate = scheduledDate;
                CoreTestColor = (int)CoreLimitColor.None;
                Check = false;
            }

            #endregion

            #region Properties


            public string ItemId { get; }

            public string Batch { get; }

            public int Serie { get; set; }

            public int Sequence { get; set; }

            public string Machine { get; }

            public DateTime ScheduledDate { get; }

            public int InsulationStatus { get; set; }

            public CoreLimitColor CoreTestColor { get; set; }

            public string? CoreLocation { get; set; }

            public string InsulationStatusDescription => InsulationStatus switch
            {
                -1 => "Pendiente",
                (int)InsulationsState.Pending => "En cola", //0
                (int)InsulationsState.InProgress => "En proceso",//1
                (int)InsulationsState.Cancelled => "Pendiente",//2
                (int)InsulationsState.Finished => "Terminado",//3
                _ => "Pendiente"
            };

            public string? CoreResultText { get; set; }

            public bool Check { get; set; }

            #endregion
        }

        internal class ComboBoxItemModel
        {
            #region Constructor

            public ComboBoxItemModel()
            {
                Number = "noData";
            }

            #endregion

            #region Properties

            public string Number { get; set; }

            #endregion
        }
    }
}
