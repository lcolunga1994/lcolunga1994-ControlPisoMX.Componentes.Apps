namespace ProlecGE.ControlPisoMX.CoreSupply.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    public partial class OrderForms : ThemedForm
    {
        #region Fields

        private readonly IMediator mediator;

        #endregion

        #region Constructor

        public OrderForms(IMediator mediator)
        {
            this.mediator = mediator;
            InitializeComponent();
            CenterToParent();
            CustomInitializeComponent();
        }

        #endregion

        #region Properties 

        public MOSupplySummaryModel? SupplySummary { get; private set; }

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

            txtOrder.InitializeItemTextboxBehavior();
            txtBatch.InitializeBatchTextboxBehavior();
            txtBatch.KeyPress += OnTxtBatch_EnterKeyPress;
            grItems.Columns.Clear();
            grItems.AutoGenerateColumns = false;
            ApplyDataGridViewDefaultProperties(grItems);

            DataGridViewTextBoxColumn dataColumn = new();

            dataColumn.HeaderText = "SERIE";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Serie);
            dataColumn.ReadOnly = true;
            grItems.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.HeaderText = "FECHA IMPRESIÓN";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Date);
            dataColumn.ReadOnly = true;
            dataColumn.MinimumWidth = 170;
            grItems.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.HeaderText = "CÓDIGO BARRAS CONFIRMADO";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.CodeBar);
            dataColumn.ReadOnly = true;
            dataColumn.MinimumWidth = 100;
            grItems.Columns.Add(dataColumn);

            SetColumnContentAlign(grItems, DataGridViewContentAlignment.MiddleCenter, new string[]
            {
                nameof(DataGridViewItemModel.Serie),
                nameof(DataGridViewItemModel.Date),
                nameof(DataGridViewItemModel.CodeBar),
            });
        }

        #endregion

        #region Events

        private void OrderForms_Load(object sender, EventArgs e) => DisplaySummary();

        private void OnTxtBatch_EnterKeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadItems();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e) => LoadItems();

        private void BtnClose_Click(object sender, EventArgs e) => Close();

        #endregion

        #region Queries

        public async void LoadItems()
        {
            string itemId = txtOrder.Text;
            string batch = txtBatch.Text;

            OperationProgress<bool> operation = new(UpdateUI);

            try
            {
                operation.Start();

                SupplySummary = await mediator
                    .Send(new Queries.MOSupplySummaryQuery(itemId, batch))
                    .ConfigureAwait(false);

                operation.Report(true);
            }
            catch (Exception ex)
            {
                operation.Error("Ocurrió un problema al consultar la información.", ex);
            }
            finally
            {
                operation.Finish();
            }

            void UpdateUI(OperationProgressReport<bool> progress)
            {
                if (progress.State == OperationState.Started)
                {
                    txtOrder.Enabled = false;
                    txtBatch.Enabled = false;
                    btnAccept.Enabled = false;
                }
                else if (progress.State == OperationState.Running && progress.Value)
                {
                    if (SupplySummary == null)
                    {
                        this.ShowErrorMessage($"No existe la orden de fabricación {txtOrder.Text}-{txtBatch.Text}.", Text, null);
                    }

                    DisplaySummary();
                }
                else if (progress.State == OperationState.Error)
                {
                    this.ShowErrorMessage(progress.ErrorMessage ?? "", Text, progress.Exception);
                }
                else if (progress.State == OperationState.Finished)
                {
                    txtOrder.Enabled = true;
                    txtBatch.Enabled = true;
                    btnAccept.Enabled = true;
                    txtOrder.Focus();
                }
            }
        }

        #endregion

        #region Functionality

        private void DisplaySummary()
        {
            lblTotalOrder.Text = $"Total Orden: {SupplySummary?.Quantity ?? 0}";
            lblTotalSupplied.Text = $"Total pedido: {SupplySummary?.SuppliedQuantity ?? 0}";
            lblPending.Text = $"Pendiente: {SupplySummary?.PendingQuantity ?? 0}";

            grItems.DataSource = new SortableBindingList<DataGridViewItemModel>(SupplySummary?.Orders
                .Select(i => new DataGridViewItemModel(i))
                .ToList() ?? new List<DataGridViewItemModel>());
        }

        #endregion

        internal class DataGridViewItemModel : MOSupplyItemStatusModel
        {
            #region Constructor

            public DataGridViewItemModel(MOSupplyItemStatusModel i)
            {
                ItemId = i.ItemId;
                Batch = i.Batch;
                Serie = i.Serie;
                Sequence = i.Sequence;
                SuppliedUtcDate = i.SuppliedUtcDate;
                Confirmed = i.Confirmed;
            }

            #endregion

            #region Properties

            public string Date => (SuppliedUtcDate?.ToLocalTime().ToString()) ?? "";

            public string CodeBar => Confirmed ? "Sí" : (SuppliedUtcDate.HasValue) ? "No" : "";

            #endregion
        }
    }
}