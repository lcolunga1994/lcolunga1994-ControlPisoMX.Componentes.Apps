namespace ProlecGE.ControlPisoMX.CoreSupply.Forms
{
    using System;
    using System.Windows.Forms;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    public partial class ReprintSupplyTagForm : ThemedForm
    {
        #region Fields

        private readonly IMediator mediator;

        private bool preventCheckUnCheckAllFlag = false;

        #endregion

        #region Constructor

        public ReprintSupplyTagForm(IMediator mediator)
        {
            this.mediator = mediator;
            Orders = new SortableBindingList<DataGridViewItemModel>();
            InitializeComponent();
            CenterToParent();
            CustomInitializeComponent();
        }

        #endregion

        #region Properties 

        private SortableBindingList<DataGridViewItemModel> Orders { set; get; }

        #endregion

        #region Controls initialization

        private void CustomInitializeComponent()
        {
            UseLightTheme();
            ApplyStandarImages(picBoxEnterpriseLogo, picBoxTitleLine);
            ApplyUserImage(picBoxUserImage);
            ApplySecondaryButtonTheme(btnClose);
            ApplySecondaryButtonTheme(btnRefresh);
            lblUserName.Text = Program.User.Name;
            StartPosition = FormStartPosition.CenterParent;

            grItems.Columns.Clear();
            grItems.AutoGenerateColumns = false;
            ApplyDataGridViewDefaultProperties(grItems);

            DataGridViewTextBoxColumn dataColumn = new();

            dataColumn.HeaderText = "ARTÍCULO";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.ItemId);
            dataColumn.ReadOnly = true;
            grItems.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.HeaderText = "LOTE";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Batch);
            dataColumn.ReadOnly = true;
            grItems.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.HeaderText = "SERIE";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Serie);
            dataColumn.ReadOnly = true;
            grItems.Columns.Add(dataColumn);

            DataGridViewCheckBoxColumn checkColumn = new();

            checkColumn.ValueType = typeof(bool);
            checkColumn.HeaderText = "IMPRIMIR";
            checkColumn.DataPropertyName = nameof(DataGridViewItemModel.Check);
            checkColumn.ReadOnly = false;
            grItems.Columns.Add(checkColumn);

            dataColumn = new();
            dataColumn.HeaderText = "FECHA REGISTRADA";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Date);
            dataColumn.ReadOnly = true;
            dataColumn.MinimumWidth = 170;
            grItems.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.HeaderText = "LÍNEA";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Line);
            dataColumn.ReadOnly = true;
            grItems.Columns.Add(dataColumn);

            dataColumn = new();
            dataColumn.HeaderText = "MÁQUINA";
            dataColumn.DataPropertyName = nameof(DataGridViewItemModel.Machine);
            dataColumn.ReadOnly = true;
            grItems.Columns.Add(dataColumn);

            SetColumnContentAlign(grItems, DataGridViewContentAlignment.MiddleCenter, new string[]
            {
                nameof(DataGridViewItemModel.Batch),
                nameof(DataGridViewItemModel.Serie),
                nameof(DataGridViewItemModel.Check),
                nameof(DataGridViewItemModel.Date),
                nameof(DataGridViewItemModel.Line),
                nameof(DataGridViewItemModel.Machine)
            });
        }

        #endregion

        #region Events

        private void ReprintSupplyTagForm_Load(object sender, EventArgs e) => LoadItems();

        private void BtnRefresh_Click(object sender, EventArgs e) => LoadItems();

        private void ChkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!preventCheckUnCheckAllFlag)
            {
                foreach (DataGridViewItemModel item in Orders)
                {
                    item.Check = chkSelectAll.Checked;
                }

                preventCheckUnCheckAllFlag = false;

                grItems.Refresh();

                EnablePrint();
            }
        }

        private void GrItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (sender is DataGridView dataGridView)
            {
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void GrItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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

        private void BtnPrint_Click(object sender, EventArgs e) => PrintOrders();

        private void BtnClose_Click(object sender, EventArgs e) => Close();

        #endregion

        #region Queries

        public async void LoadItems()
        {
            OperationProgress<bool> operation = new(UpdateUI);

            try
            {
                operation.Start();

                Orders = new SortableBindingList<DataGridViewItemModel>((await mediator
                    .Send(new Queries.MOSuppliesToReprintSupplyQuery())
                    .ConfigureAwait(false))
                    .Select(i => new DataGridViewItemModel(i))
                    .ToList() ?? new List<DataGridViewItemModel>());

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
                    btnRefresh.Enabled = false;
                    btnClose.Enabled = false;
                    btnPrint.Enabled = false;
                }
                else if (progress.State == OperationState.Running && progress.Value)
                {
                    DisplayOrders();
                    EnablePrint();
                }
                else if (progress.State == OperationState.Error)
                {
                    this.ShowErrorMessage(progress.ErrorMessage ?? "", Text, progress.Exception);
                }
                else if (progress.State == OperationState.Finished)
                {
                    btnRefresh.Enabled = true;
                    btnClose.Enabled = true;
                    EnablePrint();
                }
            }
        }

        #endregion

        #region Commands

        private async void PrintOrders()
        {
            if (!Orders.Any(e => e.Check))
            {
                MessageBox.Show("Debe seleccionar una orden para imprimir.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                OperationProgress<MOSupplyItemTagModel?> operation = new(UpdateUI);

                try
                {
                    operation.Start();

                    foreach (DataGridViewItemModel checkedOrder in Orders.Where(e => e.Check))
                    {
                        MOSupplyItemTagModel? supplyTag = await mediator
                            .Send(new ClientApp.Queries.MOSupplyItemTagQuery(checkedOrder.Id))
                            .ConfigureAwait(false);
                        
                        await mediator
                            .Send(new Commands.ReprintCommand(checkedOrder.Id))
                            .ConfigureAwait(false);

                        operation.Report(supplyTag);
                    }
                }
                catch (Exception ex)
                {
                    operation.Error("Ocurrió un problema al imprimir las ordenes seleccionadas.", ex);
                }
                finally
                {
                    operation.Finish();
                }

                async void UpdateUI(OperationProgressReport<MOSupplyItemTagModel?> progress)
                {
                    if (progress.State == OperationState.Started)
                    {
                        btnRefresh.Enabled = false;
                        btnClose.Enabled = false;
                        btnPrint.Enabled = false;
                    }
                    else if (progress.State == OperationState.Running && progress.Value != null)
                    {
                        await mediator
                            .Send(new ClientApp.Commands.PrintTagCommand(progress.Value), CancellationToken.None);
                    }
                    else if (progress.State == OperationState.Error)
                    {
                        this.ShowErrorMessage(progress.ErrorMessage ?? "", Text, progress.Exception);
                    }
                    else if (progress.State == OperationState.Finished)
                    {
                        btnRefresh.Enabled = true;
                        btnClose.Enabled = true;
                        btnPrint.Enabled = true;
                        LoadItems();
                    }
                }
            }
        }

        #endregion

        #region Functionality

        private void DisplayOrders() => grItems.DataSource = Orders;

        private void EnablePrint() => btnPrint.Enabled = Orders.Any(e => e.Check);

        #endregion

        internal class DataGridViewItemModel : MOSupplyItemModel
        {
            #region Constructor

            public DataGridViewItemModel(MOSupplyItemModel model)
            {
                Id = model.Id;
                ItemId = model.ItemId;
                Batch = model.Batch;
                Serie = model.Serie;
                ScheduleDate = model.ScheduleDate;
                Machine = model.Machine;
                RegisterUtcDate = model.RegisterUtcDate;
                Line = model.Line;
                Check = false;
            }

            #endregion

            #region Properties

            public bool Check { get; set; }

            public string Date => (RegisterUtcDate.ToLocalTime().ToString()) ?? "";

            #endregion
        }
    }
}