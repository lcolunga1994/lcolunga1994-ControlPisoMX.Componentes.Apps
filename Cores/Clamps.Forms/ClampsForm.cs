namespace ProlecGE.ControlPisoMX.Clamps.Forms
{
    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Models;

    using System.Collections.ObjectModel;

    public partial class ClampsForm : ThemedForm
    {
        #region Fields

        private readonly MediatR.IMediator mediator;
        
        #endregion

        #region Constructor

        public ClampsForm(MediatR.IMediator mediator)
        {
            this.mediator = mediator;
            InitializeComponent();
            CustomInitializeComponent();
            Items = new List<DataGridViewItemModel>();
            SelectedClamps = new ObservableCollection<SelectedOrderModel>();
            SelectedClamps.CollectionChanged += OnSelectedClampChanged;
        }

        #endregion

        #region Properties

        internal List<DataGridViewItemModel> Items { get; private set; }

        internal ObservableCollection<SelectedOrderModel> SelectedClamps { get; private set; }

        internal ProductLine SelectedProductLine { set; get; }

        internal bool SelectedNationalCheck { set; get; }

        internal bool SelectedExportationCheck { set; get; }

        #endregion

        #region Controls initialization

        private void CustomInitializeComponent()
        {
            UseLightTheme();
            ApplyStandarImages(picBoxEnterpriseLogo, picBoxSubTitleLine);
            ApplyUserImage(picBoxUserImage);
            lblUserName.Text = Environment.UserName.Trim();

            ApplyDataGridViewDefaultProperties(grItems);
            ApplySecondaryButtonTheme(btnClearSelection);
            ApplySecondaryButtonTheme(btnRefresh);
            ApplySecondaryButtonTheme(btnExit);

            grItems.AutoGenerateColumns = false;
            grItems.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle(grItems.ColumnHeadersDefaultCellStyle)
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                WrapMode = DataGridViewTriState.True
            };

            Producto.DataPropertyName = nameof(DataGridViewItemModel.ItemId);
            Lote.DataPropertyName = nameof(DataGridViewItemModel.Batch);
            Serie.DataPropertyName = nameof(DataGridViewItemModel.SerieString);
            Herraje.DataPropertyName = nameof(DataGridViewItemModel.Position);
            A.DataPropertyName = nameof(DataGridViewItemModel.A);
            A.DefaultCellStyle.Font = new Font(grItems.Font.FontFamily, A.DefaultCellStyle.Font.Size + 2, FontStyle.Bold);
            A.HeaderCell.Style.Font = new Font(grItems.Font.FontFamily, A.DefaultCellStyle.Font.Size + 2, FontStyle.Bold);
            C.DataPropertyName = nameof(DataGridViewItemModel.C);
            C.DefaultCellStyle.Font = new Font(grItems.Font.FontFamily, C.DefaultCellStyle.Font.Size + 2, FontStyle.Bold);
            C.HeaderCell.Style.Font = new Font(grItems.Font.FontFamily, C.DefaultCellStyle.Font.Size + 2, FontStyle.Bold);
            E.DataPropertyName = nameof(DataGridViewItemModel.E);
            K.DataPropertyName = nameof(DataGridViewItemModel.K);
            L.DataPropertyName = nameof(DataGridViewItemModel.L);
            G.DataPropertyName = nameof(DataGridViewItemModel.G);
            H.DataPropertyName = nameof(DataGridViewItemModel.H);
            Dibujo.DataPropertyName = nameof(DataGridViewItemModel.DrawId);
            Maquina.DataPropertyName = nameof(DataGridViewItemModel.Machine);
            Nota.DataPropertyName = nameof(DataGridViewItemModel.Notes);
            Tipo.DataPropertyName = nameof(DataGridViewItemModel.ProductLine);
            grItems.SelectionMode = DataGridViewSelectionMode.CellSelect;
            grItems.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            grItems.DefaultCellStyle.SelectionForeColor = Color.White;
            grItems.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            grItems.ColumnHeadersDefaultCellStyle.SelectionForeColor = grItems.ColumnHeadersDefaultCellStyle.ForeColor;
            cmbProductLine.SelectedIndex = 0;
        }

        #endregion

        #region Control events

        private void OnForm_Load(object sender, EventArgs e) => LoadFilters();

        private void BtnRefresh_Click(object sender, EventArgs e) => LoadFilters();

        private void GrItems_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    DataGridView dataGridView = (DataGridView)sender;

                    if (dataGridView != null)
                    {
                        DataGridViewCell dataGridViewCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                        if (dataGridViewCell.OwningRow.DataBoundItem is DataGridViewItemModel item)
                        {
                            if (item.Position == "SUPERIOR")
                            {
                                SelectedOrderModel? selectedOrder = SelectedClamps
                                .FirstOrDefault(e => e.ItemId == item.ItemId && e.Batch == item.Batch && e.Serie == item.Serie);

                                if (selectedOrder != null)
                                {
                                    dataGridViewCell.OwningRow.DefaultCellStyle.BackColor = Color.Yellow;
                                }
                                else
                                {
                                    dataGridViewCell.OwningRow.DefaultCellStyle.BackColor = Color.White;

                                    if (dataGridViewCell.OwningColumn.DataPropertyName == "")
                                    {
                                        dataGridViewCell.Style.BackColor = Color.Silver;
                                    }
                                }
                            }
                            else
                            {
                                dataGridViewCell.OwningRow.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder);
                            }

                            RefreshDataGridViewCellColor(dataGridViewCell);
                        }
                    }

                    void RefreshDataGridViewCellColor(DataGridViewCell dataGridViewCell)
                    {
                        if (dataGridViewCell.OwningRow.DataBoundItem is DataGridViewItemModel item)
                        {
                            if (item.Position == "SUPERIOR")
                            {
                                if (dataGridViewCell.OwningColumn.DataPropertyName == nameof(DataGridViewItemModel.E))
                                {
                                    if (item.E != "-")
                                    {
                                        dataGridViewCell.Style.ForeColor = Color.Red;
                                        dataGridViewCell.Style.Font = new Font(grItems.Font, FontStyle.Bold);
                                    }
                                }
                                else if (dataGridViewCell.OwningColumn.DataPropertyName == nameof(DataGridViewItemModel.DrawId))
                                {
                                    if (item.DrawId == "DNA3364")
                                    {
                                        dataGridViewCell.Style.ForeColor = Color.Blue;
                                    }
                                    else if (item.DrawId == "DNA3345")
                                    {
                                        dataGridViewCell.Style.ForeColor = Color.Green;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void GrItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    DataGridView dataGridView = (DataGridView)sender;

                    if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {
                        DataGridViewRow selectedRow = dataGridView.Rows[e.RowIndex];

                        if (selectedRow.DataBoundItem is DataGridViewItemModel item)
                        {
                            if (item.Position == "SUPERIOR")
                            {
                                SelectedOrderModel? selectedOrder = SelectedClamps
                                    .FirstOrDefault(e => e.ItemId == item.ItemId && e.Batch == item.Batch && e.Serie == item.Serie);

                                if (selectedOrder != null)
                                {
                                    SelectedClamps.Remove(selectedOrder);
                                }
                                else
                                {
                                    SelectedClamps.Add(new SelectedOrderModel(item.ItemId, item.Batch, item.Serie, item.Sequence));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e) => PlaceClamps();

        private void BtnClearSelection_Click(object sender, EventArgs e) => ClearSelection();

        private void BtnExit_Click(object sender, EventArgs e) => Close();

        private void OnForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SelectedClamps.Any() && e.CloseReason == CloseReason.UserClosing && MessageBox.Show(
                    "¿Desea salir de la aplicación?\r Las filas seleccionadas no se guardaran.",
                    "Herrajes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Queries

        public async void LoadClamps()
        {
            OperationProgress<bool> operation = new(OnProgressChanged);

            try
            {
                int page = 1;
                int pageSize = 200;

                operation.Start();

                Items.Clear();

                int totalRecords = await FindClampsAsync(page, pageSize, Items).ConfigureAwait(false);

                while (Items.Count < totalRecords)
                {
                    page++;

                    totalRecords = await FindClampsAsync(page, pageSize, Items).ConfigureAwait(false);
                }

                operation.Report(true);
            }
            catch (Exception ex)
            {
                operation.Error("Ocurrió un error al cargar los herrajes.", ex);
            }
            finally
            {
                operation.Finish();
            }

            async Task<int> FindClampsAsync(int page, int pageSize, List<DataGridViewItemModel> items)
            {
                IEnumerable<OrderWithClampsModel> orders =
                    await mediator.Send(new App.Queries.ClampsQuery())
                    .ConfigureAwait(false);

                if (SelectedProductLine == ProductLine.Poste)
                {
                    orders = orders.Where(e => e.ProductLine == ProductLine.Poste);
                }

                if (SelectedProductLine == ProductLine.Pedestal)
                {
                    orders = orders.Where(e => e.ProductLine == ProductLine.Pedestal);
                }

                if (!SelectedNationalCheck)
                {
                    orders = orders.Where(e => e.Market.Trim() != "MX"
                            && e.Market.ToUpper().Trim() != "MEX"
                            && !string.IsNullOrWhiteSpace(e.Market)
                            );
                }

                if (!SelectedExportationCheck)
                {
                    orders = orders.Where(e => e.Market.Trim() == "MX"
                            || e.Market.ToUpper().Trim() == "MEX"
                            || string.IsNullOrWhiteSpace(e.Market)
                            );
                }

                foreach (OrderWithClampsModel order in orders)
                {
                    items.Add(new DataGridViewItemModel(
                        order.ItemId,
                        order.Batch,
                        order.Serie,
                        "SUPERIOR",
                        order.Top?.A ?? 0d,
                        order.Top?.C ?? 0d,
                        order.Top?.E ?? null,
                        order.Top?.K ?? 0d,
                        order.Top?.L ?? 0d,
                        order.Top?.G ?? 0d,
                        order.Top?.H ?? 0d,
                        order.Top?.DrawId,
                        order.Machine == "REP" ? "REPARACION" : order.Machine,
                        GetNote(order.Top?.K, order.Top?.G, order.Top?.H, order.Top?.L),//order.Notes,
                        Type(order.ProductLine, order.Market))
                    { Sequence = order.Sequence });
                    items.Add(new DataGridViewItemModel(
                        "* * *",
                        "* * *",
                        order.Serie,
                        "INFERIOR",
                        order.Bottom?.A ?? 0d,
                        order.Bottom?.C ?? 0d,
                        order.Bottom?.E ?? 0d,
                        order.Bottom?.K ?? 0d,
                        order.Bottom?.L ?? 0d,
                        order.Bottom?.G ?? 0d,
                        order.Bottom?.H ?? 0d,
                        "* * *",
                        "* * *",
                        "",
                        "* * *")
                    { Sequence = order.Sequence });
                }

                return orders.Count();
            }

            void OnProgressChanged(OperationProgressReport<bool> progressReport)
            {
                if (progressReport.State == OperationState.Started)
                {
                    SetBusyButtons(true);
                    grItems.DataSource = null;
                }
                else if (progressReport.State == OperationState.Running)
                {
                    if (progressReport.Value)
                    {
                        if (Items.Count > 0)
                        {
                            grItems.ClearSelection();
                            grItems.DataSource = null;
                            grItems.DataBindings.Clear();
                            grItems.DataSource = Items;
                            grItems.Refresh();
                        }
                    }
                }
                else if (progressReport.State == OperationState.Error)
                {
                    this.ShowErrorMessage(progressReport.ErrorMessage ?? "", Text, progressReport.Exception);
                }
                else if (progressReport.State == OperationState.Canceled
                    || progressReport.State == OperationState.Finished)
                {
                    SetBusyButtons(false);
                }
            }
        }

        #endregion

        #region Commands

        private void ClearSelection()
        {
            SelectedClamps.Clear();
            grItems.Refresh();
        }

        public async void PlaceClamps()
        {
            OperationProgress<bool> operation = new(OnProgressChanged);

            try
            {
                if (SelectedClamps.Any() && MessageBox.Show("¿Esta seguro de que desea borrar la orden?", "Borrar orden", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    operation.Start();

                    List<SelectedOrderModel> deletedOrders = new();
                    foreach (SelectedOrderModel selectedOrder in SelectedClamps)
                    {
                        try
                        {
                            await mediator
                                .Send(new App.Commands.PlaceClampsCommand(selectedOrder.ItemId, selectedOrder.Batch, selectedOrder.Serie, selectedOrder.Sequence))
                                .ConfigureAwait(false);

                            deletedOrders.Add(selectedOrder);
                        }
                        catch (Exception ex)
                        {
                            operation.Error($"Ocurrió un error al borrar la orden {selectedOrder}", ex);
                        }
                    }

                    foreach (SelectedOrderModel selectedOrder in deletedOrders)
                    {
                        if (SelectedClamps.Contains(selectedOrder))
                        {
                            SelectedClamps.Remove(selectedOrder);
                        }
                    }

                    deletedOrders.Clear();
                }
            }
            catch (Exception ex)
            {
                operation.Error("Ocurrió un error al borrar las ordenes seleccionadas.", ex);
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
                    this.ShowErrorMessage(progressReport.ErrorMessage ?? "", "Borrar orden", progressReport.Exception);
                }
                else if (progressReport.State == OperationState.Canceled
                    || progressReport.State == OperationState.Finished)
                {
                    SetBusy(false);

                    LoadClamps();
                }
            }
        }

        #endregion

        #region Functionality

        private void LoadFilters()
        {
            SelectedProductLine = (ProductLine)(int)cmbProductLine.SelectedIndex;
            SelectedNationalCheck = chkNational.Checked;
            SelectedExportationCheck = chkExportation.Checked;

            LoadClamps();
        }

        private static string GetNote(double? k, double? g, double? h, double? l)
        {
            string result = "";
            k ??= 0;
            g ??= 0;
            h ??= 0;
            l ??= 0;
            if (k != 0 && g != 0 && h != 0)
            {
                result = "Apartarrayos";
            }
            else if (l != 0)
            {
                result = "Oreja Izar";
            }
            return result;
        }

        private static string Type(ProductLine prodLine, string? market)
        {
            market ??= "";
            string productLine = "";

            if (prodLine == ProductLine.Poste)
            {
                productLine = "POSTE";
            }
            if (prodLine == ProductLine.Pedestal)
            {
                productLine = "PEDESTAL";
            }

            if (market.ToUpper().Trim() == "MX" || market.ToUpper().Trim() == "MEX"
                || string.IsNullOrWhiteSpace(market))
            {
                productLine += " NAC";
            }
            else
            {
                productLine += " EXP";
            }

            return productLine;
        }

        private void SetBusy(bool formIsBusy)
        {
            grItems.Enabled = !formIsBusy;
            btnRefresh.Enabled = !formIsBusy;
            btnDelete.Enabled = !formIsBusy && SelectedClamps.Any();
            btnClearSelection.Enabled = !formIsBusy && SelectedClamps.Any();
            btnExit.Enabled = !formIsBusy;
        }

        private void SetBusyButtons(bool formIsBusy)
        {
            btnRefresh.Enabled = !formIsBusy;
            btnDelete.Enabled = !formIsBusy && SelectedClamps.Any();
            btnClearSelection.Enabled = !formIsBusy && SelectedClamps.Any();
            btnExit.Enabled = !formIsBusy;
        }

        private void OnSelectedClampChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (!InvokeRequired)
            {
                btnDelete.Enabled = SelectedClamps.Any();
                btnClearSelection.Enabled = SelectedClamps.Any();
            }
        }

        #endregion

        internal class DataGridViewItemModel
        {
            #region Fields

            private readonly double a;
            private readonly double c;
            private readonly double? e;
            private readonly double k;
            private readonly double l;
            private readonly double g;
            private readonly double h;

            #endregion

            #region Constructor

            public DataGridViewItemModel(
                string itemId,
                string batch,
                int serie,
                string position,
                double a,
                double c,
                double? e,
                double k,
                double l,
                double g,
                double h,
                string? drawId,
                string machine,
                string? notes,
                string productLine)
            {
                ItemId = itemId;
                Batch = batch;
                Serie = serie;
                SerieString = (position == "INFERIOR") ? "* * *" : serie.ToString();
                Position = position;
                this.a = a;
                this.c = c;
                this.e = e;
                this.k = k;
                this.l = l;
                this.g = g;
                this.h = h;

                if (k != 0 && g != 0 && h != 0)
                {
                    Notes = "Apartarrayos";
                }
                else if (l != 0)
                {
                    Notes = "Oreja Izar";
                }

                DrawId = drawId;
                Machine = (machine == "REP") ? "REPARACIÓN" : machine;
                Notes = notes;
                ProductLine = productLine;
            }

            #endregion

            #region Properties

            public string ItemId { get; set; } = null!;

            public string Batch { get; set; } = null!;

            public int Serie { get; set; }

            public int Sequence { get; set; }

            public string SerieString { get; set; }

            public string Position { get; set; } = null!;

            public string A => a == 0d ? "-" : a.ToString();

            public string C => c == 0d ? "-" : c.ToString();

            public string E => e == null ? "-" : (e?.ToString() ?? "");

            public string K => k == 0d ? "-" : k.ToString();

            public string L => l == 0d ? "-" : l.ToString();

            public string G => g == 0d ? "-" : g.ToString();

            public string H => h == 0d ? "-" : h.ToString();

            public string? DrawId { get; set; }

            public string Machine { get; set; } = null!;

            public string? Notes { get; set; } = null!;

            public string ProductLine { get; set; } = null!;

            #endregion
        }

        internal class SelectedOrderModel
        {
            #region Constructor

            public SelectedOrderModel(string itemId, string batch, int serie, int sequence)
            {
                ItemId = itemId;
                Batch = batch;
                Serie = serie;
                Sequence = sequence;
            }

            #endregion

            #region Properties

            public string ItemId { get; set; } = null!;

            public string Batch { get; set; } = null!;

            public int Serie { get; set; }

            public int Sequence { set; get; }

            #endregion

            #region Method

            public override string ToString() => $"{ItemId}-{Batch}-{Serie}";

            #endregion
        }
    }
}