namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;

    using Utils;

    public partial class AddOrdersToManufacturingForm : ThemedForm
    {
        #region Fields

        private readonly MediatR.IMediator mediator;
        private readonly ILogger<AddOrdersToManufacturingForm> logger;

        #endregion

        #region Constructors

        public AddOrdersToManufacturingForm(ILogger<AddOrdersToManufacturingForm> logger,
            Microsoft.Extensions.Options.IOptionsMonitor<ThemeConfiguration> monitor,
            MediatR.IMediator mediator) : base(new ThemeConfiguration() { UseDarkTheme = false })
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mediator = mediator;

            Machines = new List<ComboBoxItemModel>();
            Orders = new BindingList<DataGridViewItemModel>();

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
            lblUserName.Text = Program.UserDisplayName;
            datePickerSupplies.Format = DateTimePickerFormat.Custom;
            datePickerSupplies.CustomFormat = "MM/dd/yyyy";

            cmbMachines.ValueMember = nameof(ComboBoxItemModel.Number);
            cmbMachines.DisplayMember = nameof(ComboBoxItemModel.Number);

            grOrders.Columns.Clear();
            grOrders.AutoGenerateColumns = false;
            grOrders.AllowUserToAddRows = false;
            grOrders.AllowUserToDeleteRows = false;
            grOrders.AllowUserToResizeRows = false;
            grOrders.RowHeadersVisible = false;
            grOrders.MultiSelect = false;
            grOrders.CellPainting += OnOrders_CellPainting;

            DataGridViewTextBoxColumn dataColumn = new();

            dataColumn.HeaderText = "ARTÍCULO";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Item);
            dataColumn.ReadOnly = true;
            dataColumn.MinimumWidth = 90;
            grOrders.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.HeaderText = "CONSECUTIVO";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Consecutive);
            dataColumn.ReadOnly = true;
            dataColumn.MinimumWidth = 110;
            grOrders.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.HeaderText = "SERIE";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Serie);
            dataColumn.ReadOnly = true;
            grOrders.Columns.Add(dataColumn);

            DataGridViewCheckBoxColumn checkColumn = new();

            checkColumn.ValueType = typeof(bool);
            checkColumn.HeaderText = "      ";
            checkColumn.DataPropertyName = nameof(DataGridViewItemModel.Check);
            checkColumn.ReadOnly = false;
            grOrders.Columns.Add(checkColumn);

            dataColumn = new();
            dataColumn.HeaderText = "SECUENCIA";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Sequence);
            dataColumn.ReadOnly = true;
            dataColumn.MinimumWidth = 100;
            grOrders.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.HeaderText = "PROBADO";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.DummyTestColorName);
            dataColumn.Name = nameof(DataGridViewItemModel.TestColor);
            dataColumn.ReadOnly = true;
            grOrders.Columns.Add(dataColumn);
        }

        #endregion

        #region Events

        private void AddOrdersToManufacturingForm_Load(object sender, EventArgs e) => LoadMachines();

        private void OnOrders_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (grOrders.Columns[e.ColumnIndex].DataPropertyName == nameof(DataGridViewItemModel.DummyTestColorName))
                {
                    if (sender is DataGridView dataGridView)
                    {
                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = " ";

                        if (dataGridView.Rows[e.RowIndex].DataBoundItem is DataGridViewItemModel itemModel)
                        {
                            switch (itemModel.TestColor)
                            {
                                case CoreTestColor.None:
                                    break;
                                case CoreTestColor.Blue:
                                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Blue;
                                    break;
                                case CoreTestColor.Green:
                                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                                    break;
                                case CoreTestColor.Yellow:
                                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
                                    break;
                                case CoreTestColor.Red:
                                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e) => FindOrders();

        private void TxtSetRecords_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtSetRecords_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckOrders();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e) => AddOrdersToManufacturing();

        private void CmbMachines_SelectedIndexChanged(object sender, EventArgs e)
            => SelectedMachine = cmbMachines.SelectedValue?.ToString();

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
                        .Send(new ClientApp.Queries.MachineQuery())
                        .ConfigureAwait(true))
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

        public async void FindOrders()
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
                    DateTime date = datePickerSupplies.Value.Date;

                    Orders = new((await mediator
                        .Send(new ClientApp.Queries.OrdersToManufactureQuery(datePickerSupplies.Value.Date.ToUniversalTime(), SelectedMachine))
                        .ConfigureAwait(true))
                        .Select(i => new DataGridViewItemModel()
                        {
                            Item = i.ItemId,
                            Consecutive = i.Batch,
                            Serie = i.Serie,
                            Sequence = i.Sequence,
                            Check = false,
                            TestColor = i.CoreTestColor
                        })
                        .ToList());

                    operation.Report(true);
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
                    Orders.Clear();
                    grOrders.DataSource = null;
                    txtSetRecords.Text = string.Empty;
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

                    if (!Orders.Any())
                    {
                        DateTime selectedDate = datePickerSupplies.Value.Date;
                        MessageBox.Show($"No se encontró información para la maquina {SelectedMachine} y la fecha {selectedDate:MM/dd/yyyy}.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        #endregion

        #region Commands

        public void CheckOrders()
        {
            if (int.TryParse(txtSetRecords.Text, out int records))
            {
                for (int i = 0; i < Orders.Count; i++)
                {
                    if (i <= (records - 1))
                    {
                        Orders[i].Check = true;
                    }
                    else
                    {
                        Orders[i].Check = false;
                    }
                }

                grOrders.Refresh();
            }
        }

        public async void AddOrdersToManufacturing()
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
                    .Send(new ClientApp.Commands.AddOrderToManufacturingCommand(checkedOrdes
                        .Select(checkedOrder => new OrderToManufactureModel(
                            checkedOrder.Item,
                            checkedOrder.Consecutive,
                            checkedOrder.Serie,
                            checkedOrder.Sequence))
                        .ToList()))
                    .ConfigureAwait(false);

                    operation.Report(true);
                }
                catch (Exception ex)
                {
                    operation.Error($"Ocurrió un error al agregar las ordenes a la lista de fabricación.", ex);
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
                }
                else if (progressReport.State == OperationState.Error)
                {
                    ShowErrorMessage(progressReport.ErrorMessage ?? "", "Agregar orden", progressReport.Exception);
                    FindOrders();
                }
                else if (progressReport.State == OperationState.Canceled || progressReport.State == OperationState.Finished)
                {
                    SetBusy(false);

                    foreach (DataGridViewItemModel checkedItem in Orders.Where(e => e.Check).ToArray())
                    {
                        Orders.Remove(checkedItem);
                    }
                }
            }
        }

        #endregion

        #region Theme

        protected override void OnThemeChanged(bool useDarkTheme)
        {
            base.OnThemeChanged(useDarkTheme);

            CustomTheme.Instance.ApplySecondaryButtonTheme(btnClose);
            CustomTheme.Instance.ApplyStandarImages(picBoxEnterpriseLogo, picBoxSubTitleLine);
            CustomTheme.Instance.ApplyUserImage(picBoxUserImage);

            grOrders.SetColumnContentAlign(DataGridViewContentAlignment.MiddleCenter, new string[]
            {
                nameof(DataGridViewItemModel.Consecutive),
                nameof(DataGridViewItemModel.Serie),
                nameof(DataGridViewItemModel.Check),
                nameof(DataGridViewItemModel.Sequence),
                nameof(DataGridViewItemModel.DummyTestColorName)
            });
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

            public DataGridViewItemModel()
            {
                Item = "noData";
                Consecutive = "noData";
                Serie = 0;
                Check = false;
                Sequence = 0;
                TestColor = CoreTestColor.None;
            }

            #endregion

            #region Properties

            public string Item { get; set; }

            public string Consecutive { get; set; }

            public int Serie { get; set; }

            public bool Check { get; set; }

            public int Sequence { get; set; }

            public string? DummyTestColorName { get; set; }

            public CoreTestColor TestColor { get; set; }

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