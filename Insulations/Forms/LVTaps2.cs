namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    using Microsoft.AspNetCore.SignalR.Client;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    using System;

    using Utils;

    public partial class LVTaps2 : ThemedForm
    {
        #region Fields

        private const string FindMessageTitle = "Busqueda de material.";

        private readonly ILogger<LVTaps2> logger;
        private readonly MediatR.IMediator mediator;
        private readonly HubConnection connection;
        private readonly IProgress<HubConnectionState> connectionProgress;
        private readonly OperationProgress<CurrentManufactureModel?> hubProgress;
        private readonly OperationProgress<CurrentManufactureModel?> nextOrderProgress;
        private readonly OperationProgress<int> findProgress;
        private readonly OperationProgress<int> findNextProgress;

        #endregion

        #region Constructors

        public LVTaps2(
            ILogger<LVTaps2> logger,
            IConfiguration configuration,
            IOptionsMonitor<ThemeConfiguration> monitor,
            MediatR.IMediator mediator) : base(new ThemeConfiguration() { UseDarkTheme = true })
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mediator = mediator;

            connection = new HubConnectionBuilder()
                .WithUrl(configuration.GetValue<string>("Urls:SignalR"))
                .WithAutomaticReconnect()
                .Build();
            connectionProgress = new Progress<HubConnectionState>(DisplayConnectionState);
            hubProgress = new OperationProgress<CurrentManufactureModel?>(ChangeOrder);
            nextOrderProgress = new OperationProgress<CurrentManufactureModel?>(ChangeNextOrder);
            findProgress = new OperationProgress<int>(OnFindMaterial);
            findNextProgress = new OperationProgress<int>(OnFindNextMaterial);

            Material = new List<DataGridViewItemModel>();
            NextMaterial = new List<DataGridViewItemModel>();

            InitializeComponent();
            CustomInitializeComponent();
        }

        #endregion

        #region Properties

        internal CurrentManufactureModel? Order { get; set; }

        internal CurrentManufactureModel? NextOrder { get; set; }

        internal List<DataGridViewItemModel> Material { get; set; }

        internal List<DataGridViewItemModel> NextMaterial { get; set; }

        #endregion

        #region Controls initialization
        
        private void CustomInitializeComponent()
        {
            lblUserName.Text = Environment.UserName.Trim();
            lblConnectionMessage.Font = new Font("Arial", 24F);
            lblLodingItems.Font = new Font("Arial", 24F);
            lblNoOrder.Font = new Font("Arial", 24F);
            lblNoNextOrder.Font = new Font("Arial", 24F);

            InitializeGrid(grMaterial);
            InitializeGrid(grNextMaterial);
        }

        private static void InitializeGrid(DataGridView dataGridView)
        {
            dataGridView.AutoGenerateColumns = false;

            dataGridView.Columns[0].DataPropertyName = nameof(DataGridViewItemModel.Item);
            dataGridView.Columns[1].DataPropertyName = nameof(DataGridViewItemModel.Description);
            dataGridView.Columns[2].DataPropertyName = nameof(DataGridViewItemModel.Quantity);
            dataGridView.Columns[3].DataPropertyName = nameof(DataGridViewItemModel.Dimensions);
        }

        #endregion

        #region Events

        private async void LVTaps2_Load(object sender, EventArgs e)
        {
            connection.Reconnecting += OnReconnecting;
            connection.Reconnected += OnReconnected;
            connection.Closed += OnConnectionClosed;

            connection.On<CurrentManufactureModel>("CurrentManufacturingChanged", (current) => OnOrderChanged(current));
            connection.On<CurrentManufactureModel>("NextManufacturingOrderChanged", (current) => OnNextOrderChanged(current));
            connection.On("StopManufacturing", () => OnManufacturingStopped());

            ResetOrder();
            ResetNextOrder();

            await ConnectAsync().ConfigureAwait(false);
        }

        private void LVTaps2_SizeChanged(object sender, EventArgs e)
        {
            CenterConnectionMessageLabel();
            CenterNoOrderLabel();
        }

        #endregion

        #region Connection events

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

        private void DisplayConnectionState(HubConnectionState obj)
        {
            if (obj == HubConnectionState.Connected)
            {
                lblConnectionMessage.Visible = false;
            }
            else
            {
                lblConnectionMessage.Visible = true;
                lblConnectionMessage.BringToFront();
                ResetOrder();
            }

            switch (obj)
            {
                case HubConnectionState.Disconnected:
                    lblConnectionMessage.Text = "Desconectado del servidor.";
                    CenterConnectionMessageLabel();
                    break;
                case HubConnectionState.Connected:
                    lblConnectionMessage.Text = "Conectado";
                    CenterConnectionMessageLabel();
                    break;
                case HubConnectionState.Connecting:
                    lblConnectionMessage.Text = "Conectando con el servidor...";
                    CenterConnectionMessageLabel();
                    break;
                case HubConnectionState.Reconnecting:
                    lblConnectionMessage.Text = "Reconectando...";
                    CenterConnectionMessageLabel();
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Signal R Hub events

        private void OnOrderChanged(CurrentManufactureModel manufacturingModel)
            => hubProgress.Report(manufacturingModel);

        private void OnNextOrderChanged(CurrentManufactureModel manufacturingModel)
            => nextOrderProgress.Report(manufacturingModel);

        private void OnManufacturingStopped()
            => hubProgress.Report(null);

        private void ChangeOrder(OperationProgressReport<CurrentManufactureModel?> progressReport)
        {
            if (progressReport.State == OperationState.Running)
            {
                string? oldItemId = Order?.ItemId;
                Order = progressReport.Value;
                DisplayOrder();

                if (oldItemId != progressReport.Value?.ItemId)
                {
                    FindMaterial();
                }
            }
        }

        private void ChangeNextOrder(OperationProgressReport<CurrentManufactureModel?> progressReport)
        {
            if (progressReport.State == OperationState.Running)
            {
                string? oldItemId = NextOrder?.ItemId;
                NextOrder = progressReport.Value;
                DisplayNextOrder();

                if (oldItemId != progressReport.Value?.ItemId)
                {
                    FindNextMaterial();
                }
            }
        }

        #endregion

        #region Commands

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

        #endregion

        #region Queries

        public async void FindMaterial()
        {
            try
            {
                findProgress.Start();

                if (Order != null)
                {
                    Material = (await mediator
                        .Send(new ClientApp.Queries.AluminiumCutsQuery(Order.ItemId))
                        .ConfigureAwait(false))
                        .Select(i => new DataGridViewItemModel()
                        {
                            Item = i.Item,
                            Description = i.Description,
                            Quantity = i.Quantity == 0 ? "" : i.Quantity.ToString(),
                            Dimensions = i.Dimensions ?? ""
                        })
                        .ToList();

                    findProgress.Report(1);
                }
            }
            catch (Exception ex)
            {
                findProgress.Error("Ocurrió un error al cargar el material.", ex);
            }
            finally
            {
                findProgress.Finish();
            }
        }

        public async void FindNextMaterial()
        {
            try
            {
                findNextProgress.Start();

                if (NextOrder != null)
                {
                    NextMaterial = (await mediator
                        .Send(new ClientApp.Queries.AluminiumCutsQuery(NextOrder.ItemId))
                        .ConfigureAwait(false))
                        .Select(i => new DataGridViewItemModel()
                        {
                            Item = i.Item,
                            Description = i.Description,
                            Quantity = i.Quantity == 0 ? "" : i.Quantity.ToString(),
                            Dimensions = i.Dimensions ?? ""
                        })
                        .ToList();

                    findNextProgress.Report(2);
                }

            }
            catch (Exception ex)
            {
                findNextProgress.Error("Ocurrió un error al cargar el material de la orden siguiente.", ex);
            }
            finally
            {
                findNextProgress.Finish();
            }
        }

        #endregion

        #region Theme

        protected override void OnThemeChanged(bool useDarkTheme)
        {
            base.OnThemeChanged(useDarkTheme);

            CustomTheme.Instance.ApplyLabelThemeBackground(lblItemValue);
            CustomTheme.Instance.ApplyLabelThemeAccentColor(lblItemValue);
            CustomTheme.Instance.ApplyLabelThemeBackground(lblQuantityValue);
            CustomTheme.Instance.ApplyLabelThemeAccentColor(lblQuantityValue);
            CustomTheme.Instance.ApplyLabelThemeBackground(lblNextItemValue);
            CustomTheme.Instance.ApplyLabelThemeAccentColor(lblNextItemValue);
            CustomTheme.Instance.ApplyLabelThemeBackground(lblNextQuantityValue);
            CustomTheme.Instance.ApplyLabelThemeAccentColor(lblNextQuantityValue);

            DataGridViewExtensions.ApplyMaterialStyle(grMaterial);
            DataGridViewExtensions.ApplyMaterialStyle(grNextMaterial);

            CustomTheme.Instance.ApplyStandarImages(picBoxEnterpriseLogo, picBoxSubTitleLine);
            CustomTheme.Instance.ApplyUserImage(picBoxUserImage);

            grMaterial.SetColumnContentAlign(DataGridViewContentAlignment.MiddleCenter, nameof(DataGridViewItemModel.Quantity));
            grNextMaterial.SetColumnContentAlign(DataGridViewContentAlignment.MiddleCenter, nameof(DataGridViewItemModel.Quantity));
        }

        #endregion        

        #region Functionality

        private void OnFindMaterial(OperationProgressReport<int> progressReport)
        {
            if (progressReport.State == OperationState.Started)
            {
                grMaterial.DataSource = null;

                SetMaterialLabelText("Consultando información...");

                lblLodingItems.Visible = true;
                CenterLoadingMaterialLabel();
            }
            else if (progressReport.State == OperationState.Running)
            {
                if (progressReport.Value == 1)
                {
                    DisplayCurrentArticleMaterial();
                }
            }
            else if (progressReport.State == OperationState.Error)
            {
                ShowErrorMessage(progressReport.ErrorMessage ?? "", FindMessageTitle, progressReport.Exception);
            }
            else if (progressReport.State == OperationState.Canceled
                || progressReport.State == OperationState.Finished)
            {
                lblLodingItems.Visible = false;
            }
        }

        private void OnFindNextMaterial(OperationProgressReport<int> progressReport)
        {
            if (progressReport.State == OperationState.Started)
            {
                grNextMaterial.DataSource = null;

                SetMaterialLabelText("Consultando información...");

                lblLodingItems.Visible = true;
                CenterLoadingMaterialLabel();
            }
            else if (progressReport.State == OperationState.Running)
            {
                if (progressReport.Value == 2)
                {
                    DisplayNextArticleMaterial();
                }
            }
            else if (progressReport.State == OperationState.Error)
            {
                ShowErrorMessage(progressReport.ErrorMessage ?? "", FindMessageTitle, progressReport.Exception);
            }
            else if (progressReport.State == OperationState.Canceled
                || progressReport.State == OperationState.Finished)
            {
                lblLodingItems.Visible = false;
            }
        }

        private void ResetOrder()
        {
            Order = null;
            DisplayOrder();
        }

        private void ResetNextOrder()
        {
            NextOrder = null;
            DisplayNextOrder();
        }

        private void DisplayOrder()
        {
            lblItemValue.Text = Order == null ? "" : $"{Order.ItemId}-{Order.Batch}";
            lblQuantityValue.Text = Order?.Quantity.ToString();

            if (Order == null)
            {
                pnlOrder.Visible = false;
                tbLayoutGrpGrd.Visible = false;
                lblLodingItems.Visible = false;

                lblNoOrder.AutoSize = true;
                lblNoOrder.Text = "No hay unidades por procesar.";
                CenterNoOrderLabel();
                lblNoOrder.Visible = (connection.State == HubConnectionState.Connected);
            }
            else
            {
                pnlOrder.Visible = true;
                tbLayoutGrpGrd.Visible = true;
                lblNoOrder.Visible = false;
            }
        }

        private void DisplayNextOrder()
        {
            lblNextItemValue.Text = NextOrder == null ? "" : $"{NextOrder.ItemId}-{NextOrder.Batch}";
            lblNextQuantityValue.Text = NextOrder?.Quantity.ToString();

            if (NextOrder == null)
            {
                pnlNextOrder.Visible = false;
                grNextMaterial.Visible = false;
                lblNoNextOrder.AutoSize = true;
                lblNoNextOrder.Text = "No hay unidades siguientes por procesar.";
                CenterNoNextOrderLabel();
                lblNoNextOrder.Visible = true;
            }
            else
            {
                pnlNextOrder.Visible = true;
                grNextMaterial.Visible = true;
                lblNoNextOrder.Visible = false;
            }
        }

        private void DisplayCurrentArticleMaterial() => grMaterial.DataSource = Material;

        private void DisplayNextArticleMaterial() => grNextMaterial.DataSource = NextMaterial;

        private void SetMaterialLabelText(string labelText)
        {
            lblLodingItems.AutoSize = true;
            lblLodingItems.Text = labelText;
            CenterLoadingMaterialLabel();
        }

        private void CenterLoadingMaterialLabel()
        {
            int lblTop = ((ClientSize.Height / 2) - (lblLodingItems.ClientSize.Height / 2));
            int lblLeft = ((ClientSize.Width / 2) - (lblLodingItems.ClientSize.Width / 2));
            lblLodingItems.Location = new Point(lblLeft, lblTop);
        }

        private void CenterConnectionMessageLabel()
        {
            int lblTop = ((ClientSize.Height / 2) - (lblConnectionMessage.Height / 2));
            int lblLeft = ((ClientSize.Width / 2) - (lblConnectionMessage.Width / 2));
            lblConnectionMessage.Location = new Point(lblLeft, lblTop);
        }

        private void CenterNoOrderLabel()
        {
            int lblTop = ((ClientSize.Height / 2) - (lblNoOrder.ClientSize.Height / 2));
            int lblLeft = ((ClientSize.Width / 2) - (lblNoOrder.ClientSize.Width / 2));
            lblNoOrder.Location = new Point(lblLeft, lblTop);
        }

        private void CenterNoNextOrderLabel()
        {
            int lblTop = ((pnlNext.ClientSize.Height / 2) - (lblNextOrder.ClientSize.Height / 2));
            int lblLeft = (pnlNextOrder.Location.X + ((pnlNextOrder.Width / 2) - (lblNoNextOrder.Width / 2)));
            lblNoNextOrder.Location = new Point(lblLeft, lblTop);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                FindMaterial();
                FindNextMaterial();
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void ShowErrorMessage(
            string errorMessage,
            string messageTitle,
            Exception? exception)
        {
            if (exception != null)
            {
                logger.LogError(exception, errorMessage);
            }

            string userMessage = errorMessage;

            if (exception != null)
            {
                if (exception is UserException userException)
                {
                    string? customMessage = userException.SystemErrorCode switch
                    {
                        //    (int)SystemErrorCode.InternalServerError => await mediator.Send(new InternalErrorContactQuery(), CancellationToken.None),
                        //    (int)SystemErrorCode.DesignNotFound => await mediator.Send(new MissingItemDesignContactQuery(), CancellationToken.None),
                        //    (int)SystemErrorCode.PartialDesignNotFound => await mediator.Send(new MissingItemDesignContactQuery(), CancellationToken.None),
                        //    (int)SystemErrorCode.ManufacturingPlanNotFound => await mediator.Send(new MissingCoreManufacturingPlanContactQuery(), CancellationToken.None),
                        401 => null,
                        _ => null,
                    };

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

            MessageBox.Show(
                this,
                userMessage,
                messageTitle,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        #endregion

        internal class DataGridViewItemModel
        {
            #region Constructor

            public DataGridViewItemModel()
            {
                DesignId = "noData";
                Description = "noData";
                Quantity = "";
                Dimensions = "noData";
            }

            #endregion

            #region Properties

            public string DesignId { get; set; }

            public string? Item { get; set; }

            public string Description { get; set; }

            public string Quantity { get; set; }

            public string Dimensions { get; set; }

            #endregion
        }
    }
}