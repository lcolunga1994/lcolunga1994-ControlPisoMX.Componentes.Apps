namespace ProlecGE.ControlPisoMX.CoreSupply.Forms
{
    using System;
    using System.Windows.Forms;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;
    using ProlecGE.ControlPisoMX.CoreSupply.Forms.Utils;

    public partial class PrintSupplyTagForm : ThemedForm
    {
        #region Fields

        private readonly ILogger<PrintInsulationTagForm> printLogger;
        private readonly MediatR.IMediator mediator;
        private readonly IConfiguration configuration;
        private readonly Services.IInsulationsService insulationsService;

        private bool preventCheckUnCheckAllFlag = false;

        public bool IsPr1333 { set; get; }

        #endregion

        #region Constructor

        public PrintSupplyTagForm(
            ILogger<PrintInsulationTagForm> printLogger,
            IConfiguration configuration,
            MediatR.IMediator mediator,
            Services.IInsulationsService insulationsService)
        {
            this.printLogger = printLogger;
            this.mediator = mediator;
            this.configuration = configuration;
            this.insulationsService = insulationsService;

            Orders = new List<DataGridViewItemModel>();

            InitializeComponent();
            CustomInitializeComponent();
            IsPr1333 = Program.User.Name?.ToUpper().Trim() == "PR133";
        }

        #endregion

        #region Properties 

        private List<DataGridViewItemModel> Orders { set; get; }

        #endregion

        #region Controls initialization

        private void CustomInitializeComponent()
        {
            UseLightTheme();
            ApplyStandarImages(picBoxEnterpriseLogo, picBoxTitleLine);
            ApplyUserImage(picBoxUserImage);
            lblUserName.Text = Program.User.Name;
            btnPrint.Enabled = !IsPr1333;

            ApplySecondaryButtonTheme(btnClose);
            ApplySecondaryButtonTheme(btnReprint);
            ApplySecondaryButtonTheme(btnOrders);
            ApplySecondaryButtonTheme(btnReprintInsulations);
            ApplySecondaryButtonTheme(btnClear);

            txtItem.InitializeItemTextboxBehavior();
            txtBatch.InitializeBatchTextboxBehavior();

            grOrders.Columns.Clear();
            grOrders.AutoGenerateColumns = false;
            ApplyDataGridViewDefaultProperties(grOrders);
            grOrders.CellPainting += OnGrOrders_CellPainting;

            DataGridViewTextBoxColumn dataColumn = new()
            {
                HeaderText = "ARTÍCULO",
                DataPropertyName = nameof(DataGridViewItemModel.ItemId),
                ReadOnly = true
            };
            grOrders.Columns.Add(dataColumn);

            dataColumn = new()
            {
                HeaderText = "LOTE",
                DataPropertyName = nameof(DataGridViewItemModel.Batch),
                ReadOnly = true
            };
            grOrders.Columns.Add(dataColumn);

            dataColumn = new()
            {
                HeaderText = "SERIE",
                DataPropertyName = nameof(DataGridViewItemModel.Serie),
                ReadOnly = true
            };
            grOrders.Columns.Add(dataColumn);

            DataGridViewCheckBoxColumn checkColumn = new()
            {
                ValueType = typeof(bool),
                HeaderText = "IMPRIMIR",
                DataPropertyName = nameof(DataGridViewItemModel.Check),
                ReadOnly = false
            };
            grOrders.Columns.Add(checkColumn);

            dataColumn = new()
            {
                HeaderText = "FECHA REGISTRADA",
                DataPropertyName = nameof(DataGridViewItemModel.Date),
                ReadOnly = true,
                MinimumWidth = 190
            };
            grOrders.Columns.Add(dataColumn);

            dataColumn = new()
            {
                HeaderText = "LÍNEA",
                DataPropertyName = nameof(DataGridViewItemModel.Line),
                ReadOnly = true
            };
            grOrders.Columns.Add(dataColumn);

            dataColumn = new()
            {
                HeaderText = "MÁQUINA",
                DataPropertyName = nameof(DataGridViewItemModel.Machine),
                Name = nameof(DataGridViewItemModel.Shots),
                ReadOnly = true
            };
            grOrders.Columns.Add(dataColumn);

            SetColumnContentAlign(grOrders, DataGridViewContentAlignment.MiddleCenter, new string[]
            {
                nameof(DataGridViewItemModel.Batch),
                nameof(DataGridViewItemModel.Serie),
                nameof(DataGridViewItemModel.Check),
                nameof(DataGridViewItemModel.Date),
                nameof(DataGridViewItemModel.Line),
                nameof(DataGridViewItemModel.Machine)
            });
            grOrders.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            grOrders.DefaultCellStyle.SelectionForeColor = Color.White;
            grOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grOrders.MultiSelect = false;
            grOrders.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            grOrders.ColumnHeadersDefaultCellStyle.SelectionForeColor = grOrders.ColumnHeadersDefaultCellStyle.ForeColor;
        }

        #endregion

        #region Events

        private void PrintSupplyTagForm_Load(object sender, EventArgs e) => LoadOrders();

        private void OnGrOrders_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (grOrders.Columns[e.ColumnIndex].DataPropertyName == nameof(DataGridViewItemModel.Machine))
                {
                    if (sender is DataGridView dataGridView)
                    {
                        if (dataGridView.Rows[e.RowIndex].DataBoundItem is DataGridViewItemModel itemModel)
                        {
                            DataGridViewCellStyle cellStyle = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style;
                            cellStyle.Font = new Font(dataGridView.DefaultCellStyle.Font, FontStyle.Bold);

                            if (itemModel.Shots == 1)
                            {
                                cellStyle.BackColor = GreenColor;
                            }
                            else if (itemModel.Shots == 2)
                            {
                                cellStyle.BackColor = YellowColor;
                            }
                            else if (itemModel.Shots >= 3)
                            {
                                cellStyle.BackColor = RedColor;
                            }
                            else
                            {
                                cellStyle.BackColor = dataGridView.DefaultCellStyle.BackColor;
                            }
                        }
                    }
                }
            }
        }

        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ChkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!preventCheckUnCheckAllFlag)
            {
                foreach (DataGridViewItemModel item in Orders)
                {
                    item.Check = chkSelectAll.Checked;
                }

                preventCheckUnCheckAllFlag = false;

                grOrders.Refresh();

                EnablePrint();
            }
        }

        private void GrOrders_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (sender is DataGridView dataGridView)
                {
                    if (dataGridView.Columns[e.ColumnIndex].DataPropertyName == nameof(DataGridViewItemModel.Check))
                    {
                        int count = Orders.Count;
                        int checkedCount = Orders.Count(i => i.Check);

                        preventCheckUnCheckAllFlag = true;

                        if (checkedCount == 0)
                        {
                            chkSelectAll.CheckState = CheckState.Unchecked;
                        }
                        else if (checkedCount == count)
                        {
                            chkSelectAll.CheckState = CheckState.Checked;
                        }
                        else
                        {
                            chkSelectAll.CheckState = CheckState.Indeterminate;
                        }

                        preventCheckUnCheckAllFlag = false;

                        EnablePrint();
                    }
                }
            }
        }

        private void GrOrders_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (grOrders.IsCurrentCellDirty)
            {
                grOrders.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e) => LoadOrders();

        private void BtnPrint_Click(object sender, EventArgs e) => Print();

        private void BtnConfirm_Click(object sender, EventArgs e) => new ConfirmSupplyForm(mediator).Show();

        private void BtnAuthorize_Click(object sender, EventArgs e) => new AuthorizeReprintForm(mediator).Show();

        private void BtnReprintInsulation_Click(object sender, EventArgs e) => new PrintInsulationTagForm(printLogger, configuration, insulationsService).ShowDialog();

        private void BtnOrders_Click(object sender, EventArgs e) => new OrderForms(mediator).Show();

        private void BtnClose_Click(object sender, EventArgs e) => Close();

        private void BtnReprint_Click(object sender, EventArgs e) => new ReprintSupplyTagForm(mediator).Show();

        private void BtnClear_Click(object sender, EventArgs e) => Clean();

        #endregion

        #region Queries

        public async void LoadOrders()
        {
            OperationProgress<bool> operation = new(OnProgressChanged);

            try
            {
                operation.Start();

                IEnumerable<MOSupplyItemModel> orders = await mediator
                    .Send(new ClientApp.Queries.MOSuppliesPendingQueryQuery())
                    .ConfigureAwait(false);

                Orders.Clear();

                foreach (var machineBatchGroup in orders
                    .GroupBy(e => new { e.ItemId, e.Batch, e.Machine }, (key, collection) => new
                    {
                        key.ItemId,
                        key.Batch,
                        key.Machine,
                        Shots = collection.Count(),
                        MinRegisterUtcDate = collection.Min(e => e.RegisterUtcDate),
                        Series = collection
                            .OrderBy(i => i.Serie)
                            .Select(i => new DataGridViewItemModel(
                                i.Id,
                                i.ItemId,
                                i.Batch,
                                i.Serie,
                                i.Sequence,
                                i.ScheduleDate,
                                i.Machine,
                                i.ProductLine,
                                i.Phases,
                                i.Line,
                                i.RegisterUtcDate)
                            {
                                Shots = collection.Count()
                            })
                            .ToArray()
                    })
                    .OrderByDescending(i => i.Shots)
                    .ThenBy(i => i.MinRegisterUtcDate))
                {
                    Orders.AddRange(machineBatchGroup.Series);
                }

                operation.Report(true);
            }
            catch (Exception ex)
            {
                operation.Error("Ocurrió un error al cargar la información.", ex);
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
                    if (progressReport.Value)
                    {
                        FilterOrders();
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

        #endregion

        #region Commands

        public void FilterOrders()
        {
            List<DataGridViewItemModel> dataSource = Orders.ToList();

            if (!string.IsNullOrWhiteSpace(txtItem.Text) || !string.IsNullOrWhiteSpace(txtBatch.Text) || !string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                if (string.IsNullOrWhiteSpace(txtItem.Text) || string.IsNullOrWhiteSpace(txtBatch.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text))
                {
                    MessageBox.Show("Debe establecer los parámetros de búsqueda", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    _ = int.TryParse(txtQuantity.Text, out int quantity);

                    string itemId = txtItem.Text.Trim();
                    string batch = txtBatch.Text.Trim();

                    dataSource = Orders
                        .Where(e => e.ItemId == itemId && e.Batch == batch)
                        .Take(quantity)
                        .OrderBy(e => e.ItemId).ThenBy(e => e.Batch).ThenBy(e => e.Serie)
                        .ToList();

                    if (dataSource.Count < quantity)
                    {
                        MessageBox.Show($"Solo se encuentran disponibles {dataSource.Count} unidades.");
                    }
                }
            }

            grOrders.DataSource = new SortableBindingList<DataGridViewItemModel>(dataSource);
            chkSelectAll.Checked = false;
        }

        private void Print()
        {
            DataGridViewItemModel[] checkedOrders = Orders.Where(e => e.Check).ToArray();

            if (checkedOrders.Any())
            {
                foreach (DataGridViewItemModel? item in checkedOrders)
                {
                    ValidSupplyForm form = new(mediator, new TagItemModel(item.ItemId, item.Batch, item.Serie))
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        Orders.Remove(item);
                    }
                }

                FilterOrders();
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos una orden para imprimir.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #region Functionality

        private void SetBusy(bool formIsBusy)
        {
            Cursor.Current = formIsBusy ? Cursors.WaitCursor : Cursors.Default;
            txtItem.Enabled = !formIsBusy;
            txtBatch.Enabled = !formIsBusy;
            txtQuantity.Enabled = !formIsBusy;
            btnClear.Enabled = !formIsBusy;
            btnSearch.Enabled = !formIsBusy;
            btnClose.Enabled = !formIsBusy;
            btnReprint.Enabled = Program.User.IsCodbar && !formIsBusy;
            btnOrders.Enabled = !formIsBusy;
            btnReprintInsulations.Enabled = !formIsBusy;
            btnAuthorize.Enabled = Program.User.CanReprint && !formIsBusy;
            btnConfirm.Enabled = Program.User.IsCodbar && !formIsBusy;

            if (formIsBusy)
            {
                EnablePrint();
            }
            else
            {
                btnPrint.Enabled = false;
            }
        }

        private void Clean()
        {
            txtItem.Text = string.Empty;
            txtBatch.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            LoadOrders();
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

        private void EnablePrint() => btnPrint.Enabled = Program.User.IsCodbar && Orders.Any(e => e.Check);

        #endregion

        internal class DataGridViewItemModel : MOSupplyItemModel
        {
            #region Constructor

            public DataGridViewItemModel(
                Guid id,
                string itemId,
                string batch,
                int serie,
                int sequence,
                DateTime scheduleUtcDate,
                string machine,
                int productLine,
                int phases,
                int line,
                DateTime registerUtcDate)
            {
                Id = id;
                ItemId = itemId;
                Batch = batch;
                Serie = serie;
                Sequence = sequence;
                ScheduleDate = scheduleUtcDate;
                Machine = machine;
                ProductLine = productLine;
                Phases = phases;
                Line = line;
                RegisterUtcDate = registerUtcDate;
                Shots = 0;
                Check = false;
            }

            #endregion

            #region Properties

            public string Date => (RegisterUtcDate.ToLocalTime().ToString("MM/dd/yyyy hh:mm:ss tt")) ?? "";

            public int Shots { get; set; }

            public bool Check { get; set; }

            #endregion
        }

        internal class PrintingOrder
        {
            #region Constructor

            public PrintingOrder(string order, string batch, int serie)
            {
                Item = order;
                Batch = batch;
                Serie = serie;
            }

            #endregion

            #region Properties

            public string Item { get; set; }

            public string Batch { get; set; }

            public int Serie { get; set; }

            #endregion
        }
    }
}