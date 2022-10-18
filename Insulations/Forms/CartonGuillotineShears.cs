namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using Microsoft.AspNetCore.SignalR.Client;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    using Utils;

    public partial class CartonGuillotineShears : ThemedForm
    {
        #region Fields

        private const string FindMessageTitle = "Busqueda de material.";

        private readonly ILogger<CartonGuillotineShears> logger;
        private readonly MediatR.IMediator mediator;
        private readonly HubConnection connection;
        private readonly IProgress<HubConnectionState> connectionProgress;
        private readonly OperationProgress<CurrentManufactureModel?> hubProgress;
        private readonly OperationProgress<int> findProgress;

        #endregion

        #region Constructors

        public CartonGuillotineShears(
            ILogger<CartonGuillotineShears> logger,
            IConfiguration configuration,
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
            findProgress = new OperationProgress<int>(OnFindMaterial);

            GuillotineShears = new List<DataGridViewItemModel>();
            SierraShears = new List<DataGridViewItemModel>();

            InitializeComponent();
            CustomInitializeComponent();
        }

        #endregion

        #region Properties

        internal CurrentManufactureModel? Order { get; set; }

        internal List<DataGridViewItemModel> GuillotineShears { get; set; }

        internal List<DataGridViewItemModel> SierraShears { get; set; }

        #endregion

        #region Controls initialization

        private void CustomInitializeComponent()
        {
            lblUserName.Text = Environment.UserName.Trim();
            lblConnectionMessage.Font = new Font("Arial", 24F);
            lblLodingItems.Font = new Font("Arial", 24F);
            lblNoOrder.Font = new Font("Arial", 24F);

            InitializeGrid();
        }

        #endregion

        #region Events

        private async void CartonGuillotineShears_Load(object sender, EventArgs e)
        {
            connection.Reconnecting += OnReconnecting;
            connection.Reconnected += OnReconnected;
            connection.Closed += OnConnectionClosed;

            connection.On<CurrentManufactureModel>("CurrentManufacturingChanged", (current) => OnOrderChanged(current));
            connection.On("StopManufacturing", () => OnManufacturingStopped());

            ResetOrder();

            await ConnectAsync().ConfigureAwait(false);
        }

        private void ManualCartonShears_Resize(object sender, EventArgs e)
        {
            CenterConnectionMessageLabel();
            CenterNoOrderLabel();
        }

        private void TlpItems_Resize(object sender, EventArgs e)
            => CenterLoadingMaterialLabel();

        private void PnlSierra_Resize(object sender, EventArgs e)
        {
            int lblLeft = pnlSierra.Left + (lblSierra.Width / 2);
            lblSierra.Location = new Point(lblLeft, lblSierra.Location.Y);
        }

        #endregion

        #region Controls initialization

        private void InitializeGrid()
        {
            grGuillotine.AutoSize = true;
            grGuillotine.AutoGenerateColumns = false;

            grcItem.DataPropertyName = nameof(DataGridViewItemModel.Item);
            grcDescription.DataPropertyName = nameof(DataGridViewItemModel.Description);
            grcQuantity.DataPropertyName = nameof(DataGridViewItemModel.Quantity);
            grcDimensions.DataPropertyName = nameof(DataGridViewItemModel.Dimensions);
            grcDoblez.DataPropertyName = nameof(DataGridViewItemModel.Fold);
            grcDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            grSierra.AutoGenerateColumns = false;
            grSierra.ColumnHeadersVisible = true;

            grcSierraItem.DataPropertyName = nameof(DataGridViewItemModel.Item);
            grSierraDescription.DataPropertyName = nameof(DataGridViewItemModel.Description);
            grcSierraQuantity.DataPropertyName = nameof(DataGridViewItemModel.Quantity);
            grcSierraDimensions.DataPropertyName = nameof(DataGridViewItemModel.Dimensions);
            grcSierraDimensions.MinimumWidth = 400;
            grcDoblez.DataPropertyName = nameof(DataGridViewItemModel.Fold);
            grSierraDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void OnManufacturingStopped()
            => hubProgress.Report(null);

        private void ChangeOrder(OperationProgressReport<CurrentManufactureModel?> progressReport)
        {
            if (progressReport.State == OperationState.Running)
            {
                if ((Order == null && progressReport.Value == null) || Order?.ItemId != progressReport.Value?.ItemId)
                {
                    Order = progressReport.Value;
                    DisplayOrder();
                    FindMaterial();
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
                    GuillotineShears = (await mediator
                        .Send(new ClientApp.Queries.GuillotineShearsQuery(Order.ItemId))
                        .ConfigureAwait(false))
                        .Select(i => new DataGridViewItemModel()
                        {
                            Item = i.Item,
                            Description = i.Description,
                            Quantity = i.Quantity == 0 ? "" : i.Quantity.ToString(),
                            Dimensions = i.Dimensions ?? "",
                            Fold = i.Fold
                        })
                        .ToList();

                    findProgress.Report(1);

                    SierraShears = (await mediator
                        .Send(new ClientApp.Queries.SierraShearsQuery(Order.ItemId))
                        .ConfigureAwait(false))
                        .Select(i => new DataGridViewItemModel()
                        {
                            Item = i.Item,
                            Description = i.Description,
                            Quantity = i.Quantity == 0 ? "" : i.Quantity.ToString(),
                            Dimensions = i.Dimensions ?? "",
                            Fold = i.Fold
                        })
                        .ToList();

                    findProgress.Report(2);
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

        #endregion

        #region Theme

        protected override void OnThemeChanged(bool useDarkTheme)
        {
            base.OnThemeChanged(useDarkTheme);

            CustomTheme.Instance.ApplyStandarImages(picBoxEnterpriseLogo, picBoxSubTitleLine);
            CustomTheme.Instance.ApplyUserImage(picBoxUserImage);

            DataGridViewExtensions.ApplyMaterialStyle(grGuillotine);
            DataGridViewExtensions.ApplyMaterialStyle(grSierra);
            CustomTheme.Instance.ApplyLabelThemeAccentColor(lblItemValue);
            CustomTheme.Instance.ApplyLabelThemeAccentColor(lblQuantityValue);

            grGuillotine.SetColumnContentAlign(DataGridViewContentAlignment.MiddleCenter, nameof(DataGridViewItemModel.Quantity));
            grSierra.SetColumnContentAlign(DataGridViewContentAlignment.MiddleCenter, nameof(DataGridViewItemModel.Quantity));
        }

        #endregion

        #region Functionality

        private void OnFindMaterial(OperationProgressReport<int> progressReport)
        {
            if (progressReport.State == OperationState.Started)
            {
                grGuillotine.DataSource = null;
                grSierra.DataSource = null;

                SetMaterialLabelText("Consultando información...");

                lblSierra.Visible = false;
                tlpItems.Visible = false;
                lblLodingItems.Visible = true;
            }
            else if (progressReport.State == OperationState.Running)
            {
                if (progressReport.Value == 1)
                {
                    DisplayGuillotineMaterial();
                }
                else if (progressReport.Value == 2)
                {
                    DisplaySierraMaterial();
                }
            }
            else if (progressReport.State == OperationState.Error)
            {
                ShowErrorMessage(progressReport.ErrorMessage ?? "", FindMessageTitle, progressReport.Exception);
            }
            else if (progressReport.State == OperationState.Canceled
                || progressReport.State == OperationState.Finished)
            {
                tlpItems.Visible = true;
                lblLodingItems.Visible = false;
            }
        }

        private void ResetOrder()
        {
            Order = null;
            DisplayOrder();
        }

        private void DisplayOrder()
        {
            lblItemValue.Text = Order == null ? "" : $"{Order.ItemId}-{Order.Batch}";
            lblQuantityValue.Text = Order?.Quantity.ToString();

            if (Order == null)
            {
                lblNoOrder.AutoSize = true;
                lblNoOrder.Text = "No hay unidades por procesar.";
                CenterNoOrderLabel();
                lblNoOrder.Visible = (connection.State == HubConnectionState.Connected);
                pnlOrder.Visible = false;
                grGuillotine.Visible = false;
                pnlSierra.Visible = false;
                lblLodingItems.Visible = false;
                lblSierra.Visible = false;
            }
            else
            {
                pnlOrder.Visible = true;
                lblNoOrder.Visible = false;
                grGuillotine.Visible = true;
                pnlSierra.Visible = true;
                lblSierra.Visible = true;
            }
        }

        private void DisplayGuillotineMaterial() => grGuillotine.DataSource = GuillotineShears;

        private void DisplaySierraMaterial()
        {
            lblSierra.Visible = true;
            grSierra.DataSource = SierraShears;
        }

        private void SetMaterialLabelText(string labelText)
        {
            lblLodingItems.AutoSize = true;
            lblLodingItems.Text = labelText;
            CenterLoadingMaterialLabel();
        }

        private void CenterLoadingMaterialLabel()
        {
            int lblTop = Top + ((ClientSize.Height / 2) - (lblLodingItems.ClientSize.Height / 2));
            int lblLeft = Left + ((ClientSize.Width / 2) - (lblLodingItems.ClientSize.Width / 2));
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                FindMaterial();
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

            public string? Fold { get; set; }

            #endregion
        }
    }
}