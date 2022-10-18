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

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;

    using Utils;

    public partial class LVTaps : ThemedForm
    {
        #region Fields

        private const string FindMessageTitle = "Busqueda de material.";

        private readonly ILogger<LVTaps> logger;
        private readonly MediatR.IMediator mediator;
        private readonly HubConnection connection;
        private readonly IProgress<HubConnectionState> connectionProgress;
        private readonly OperationProgress<CurrentManufactureModel?> hubProgress;
        private readonly OperationProgress<int> findProgress;

        #endregion

        #region Constructors

        public LVTaps(
            ILogger<LVTaps> logger,
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
            findProgress = new OperationProgress<int>(OnFindMaterial);

            AluminumDataGrid = new List<DataGridViewItemModel>();

            InitializeComponent();
            CustomInitializeComponent();
        }

        #endregion

        #region Properties

        internal CurrentManufactureModel? Order { get; set; }

        internal List<DataGridViewItemModel> AluminumDataGrid { get; set; }

        internal AluminumTipPuntasModel? EndPointInfo { set; get; }

        #endregion

        #region Events

        private async void LVTaps_Load(object sender, EventArgs e)
        {
            connection.Reconnecting += OnReconnecting;
            connection.Reconnected += OnReconnected;
            connection.Closed += OnConnectionClosed;

            connection.On<CurrentManufactureModel>("CurrentManufacturingChanged", (current) => OnOrderChanged(current));
            connection.On("StopManufacturing", () => OnManufacturingStopped());

            ResetOrder();

            await ConnectAsync().ConfigureAwait(false);
        }

        private void GrItems_Resize(object sender, EventArgs e)
        => CenterLoadingMaterialLabel();

        private void LVTaps_Resize(object sender, EventArgs e)
        {
            CenterConnectionMessageLabel();
            CenterNoOrderLabel();
        }

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

        private void InitializeGrid()
        {
            grItems.AutoGenerateColumns = false;

            grcItem.DataPropertyName = nameof(DataGridViewItemModel.Item);
            grcDescription.DataPropertyName = nameof(DataGridViewItemModel.Description);
            grcQuantity.DataPropertyName = nameof(DataGridViewItemModel.Quantity);
            grcDimensions.DataPropertyName = nameof(DataGridViewItemModel.Dimensions);

            grdPuntoInicialBTI.AutoGenerateColumns = false;
            grdPuntoInicialBTI.ColumnHeadersVisible = false;
            grcInitBTI.DataPropertyName = nameof(PuntaGridItem.Description);
            grdPuntaFinBTI.AutoGenerateColumns = false;
            grdPuntaFinBTI.ColumnHeadersVisible = false;
            grcEndBTI.DataPropertyName = nameof(PuntaGridItem.Description);
            grdPuntaInicioBTE.AutoGenerateColumns = false;
            grdPuntaInicioBTE.ColumnHeadersVisible = false;
            grcInitBTE.DataPropertyName = nameof(PuntaGridItem.Description);
            grdPuntaFinBTE.AutoGenerateColumns = false;
            grdPuntaFinBTE.ColumnHeadersVisible = false;
            grcEndBTE.DataPropertyName = nameof(PuntaGridItem.Description);
        }


        //private void AdditionalGridFormat()
        //{
        //    //grdPuntoInicialBTI
        //    grdPuntoInicialBTI.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 40);//ColorTranslator.FromHtml("4,4,96");
        //    grdPuntoInicialBTI.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(25, 225, 132);//Color.FromArgb(37,209,145);//ColorTranslator.FromHtml("25,225,132");//color verde
        //    grdPuntoInicialBTI.ForeColor = Color.White;//ColorTranslator.FromHtml("25,225,132");//ColorTranslator.FromHtml("25,225,132");
        //    grdPuntoInicialBTI.BackgroundColor = Color.FromArgb(0, 0, 40);//ColorTranslator.FromHtml("4,4,96");
        //    grdPuntoInicialBTI.AllowUserToAddRows = false;
        //    grdPuntoInicialBTI.DefaultCellStyle.BackColor = Color.FromArgb(0, 0, 40);
        //    grdPuntoInicialBTI.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 0, 40);
        //    grdPuntoInicialBTI.DefaultCellStyle.SelectionForeColor = Color.White;
        //    grdPuntoInicialBTI.EnableHeadersVisualStyles = false;
        //    grdPuntoInicialBTI.RowHeadersVisible = false;

        //    //grdPuntaFinBTI
        //    grdPuntaFinBTI.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 40);//ColorTranslator.FromHtml("4,4,96");
        //    grdPuntaFinBTI.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(25, 225, 132);//Color.FromArgb(37,209,145);//ColorTranslator.FromHtml("25,225,132");//color verde
        //    grdPuntaFinBTI.ForeColor = Color.White;//ColorTranslator.FromHtml("25,225,132");//ColorTranslator.FromHtml("25,225,132");
        //    grdPuntaFinBTI.BackgroundColor = Color.FromArgb(0, 0, 40);//ColorTranslator.FromHtml("4,4,96");
        //    grdPuntaFinBTI.AllowUserToAddRows = false;
        //    grdPuntaFinBTI.DefaultCellStyle.BackColor = Color.FromArgb(0, 0, 40);
        //    grdPuntaFinBTI.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 0, 40);
        //    grdPuntaFinBTI.DefaultCellStyle.SelectionForeColor = Color.White;
        //    grdPuntaFinBTI.EnableHeadersVisualStyles = false;
        //    grdPuntaFinBTI.RowHeadersVisible = false;

        //    //grdPuntaInicioBTE
        //    grdPuntaInicioBTE.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 40);//ColorTranslator.FromHtml("4,4,96");
        //    grdPuntaInicioBTE.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(25, 225, 132);//Color.FromArgb(37,209,145);//ColorTranslator.FromHtml("25,225,132");//color verde
        //    grdPuntaInicioBTE.ForeColor = Color.White;//ColorTranslator.FromHtml("25,225,132");//ColorTranslator.FromHtml("25,225,132");
        //    grdPuntaInicioBTE.BackgroundColor = Color.FromArgb(0, 0, 40);//ColorTranslator.FromHtml("4,4,96");
        //    grdPuntaInicioBTE.AllowUserToAddRows = false;
        //    grdPuntaInicioBTE.DefaultCellStyle.BackColor = Color.FromArgb(0, 0, 40);
        //    grdPuntaInicioBTE.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 0, 40);
        //    grdPuntaInicioBTE.DefaultCellStyle.SelectionForeColor = Color.White;
        //    grdPuntaInicioBTE.EnableHeadersVisualStyles = false;
        //    grdPuntaInicioBTE.RowHeadersVisible = false;

        //    //grdPuntaFinBTE
        //    grdPuntaFinBTE.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 40);//ColorTranslator.FromHtml("4,4,96");
        //    grdPuntaFinBTE.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(25, 225, 132);//Color.FromArgb(37,209,145);//ColorTranslator.FromHtml("25,225,132");//color verde
        //    grdPuntaFinBTE.ForeColor = Color.White;//ColorTranslator.FromHtml("25,225,132");//ColorTranslator.FromHtml("25,225,132");
        //    grdPuntaFinBTE.BackgroundColor = Color.FromArgb(0, 0, 40);//ColorTranslator.FromHtml("4,4,96");
        //    grdPuntaFinBTE.AllowUserToAddRows = false;
        //    grdPuntaFinBTE.DefaultCellStyle.BackColor = Color.FromArgb(0, 0, 40);
        //    grdPuntaFinBTE.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 0, 40);
        //    grdPuntaFinBTE.DefaultCellStyle.SelectionForeColor = Color.White;
        //    grdPuntaFinBTE.EnableHeadersVisualStyles = false;
        //    grdPuntaFinBTE.RowHeadersVisible = false;

        //    //colores alternos
        //    //grItems.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(60, 0, 40);
        //}

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
                tbLayoutGrpGrd.Visible = true;
            }
            else
            {
                ResetOrder();
                lblConnectionMessage.Visible = true;
                tbLayoutGrpGrd.Visible = false;
            }

            switch (obj)
            {
                case HubConnectionState.Disconnected:
                    lblConnectionMessage.Text = "Desconectado del servidor.";
                    tbLayoutGrpGrd.Visible = false;
                    CenterLoadingMaterialLabel();
                    break;
                case HubConnectionState.Connected:
                    lblConnectionMessage.Text = "Conectado";
                    tbLayoutGrpGrd.Visible = true;
                    CenterLoadingMaterialLabel();
                    break;
                case HubConnectionState.Connecting:
                    lblConnectionMessage.Text = "Conectando con el servidor...";
                    tbLayoutGrpGrd.Visible = false;
                    CenterLoadingMaterialLabel();
                    break;
                case HubConnectionState.Reconnecting:
                    lblConnectionMessage.Text = "Reconectando...";
                    tbLayoutGrpGrd.Visible = false;
                    CenterLoadingMaterialLabel();
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

                List<DataGridViewItemModel> items = new();

                if (Order != null)
                {
                    EndPointInfo = (await mediator
                       .Send(new ClientApp.Queries.AluminumTipQuery(Order.ItemId))
                       .ConfigureAwait(false));
                    if (EndPointInfo != null)
                    {
                        items = EndPointInfo.Materials.Select(i => new DataGridViewItemModel()
                        {
                            Item = i.Item,
                            Description = i.Description,
                            Quantity = i.Quantity == 0 ? "" : i.Quantity.ToString(),
                            Dimensions = i.Dimensions ?? "",
                        }).ToList();
                    }

                    AluminumDataGrid = items;
                }
                findProgress.Report(1);
            }
            catch (Exception ex)
            {
                findProgress.Error("Ocurrió un error al cargar los artículos planeados.", ex);
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

            CustomTheme.Instance.ApplyLabelThemeBackground(lblItemValue);
            CustomTheme.Instance.ApplyLabelThemeAccentColor(lblItemValue);
            CustomTheme.Instance.ApplyLabelThemeBackground(lblQuantityValue);
            CustomTheme.Instance.ApplyLabelThemeAccentColor(lblQuantityValue);

            DataGridViewExtensions.ApplyMaterialStyle(grItems);
            DataGridViewExtensions.ApplyMaterialStyle(grdPuntoInicialBTI);
            CustomTheme.Instance.ApplyLabelThemeGreenColor(lblPuntaInicio);
            DataGridViewExtensions.ApplyMaterialStyle(grdPuntaFinBTI);
            DataGridViewExtensions.ApplyMaterialStyle(grdPuntaInicioBTE);
            CustomTheme.Instance.ApplyLabelThemeGreenColor(lblPuntaFin);
            DataGridViewExtensions.ApplyMaterialStyle(grdPuntaFinBTE);

            grItems.SetColumnContentAlign(DataGridViewContentAlignment.MiddleCenter, nameof(DataGridViewItemModel.Quantity));
        }

        #endregion

        #region Functionality        

        private void OnFindMaterial(OperationProgressReport<int> progressReport)
        {
            if (progressReport.State == OperationState.Started)
            {
                grItems.DataSource = null;
                grdPuntoInicialBTI.DataSource = null;
                grdPuntaInicioBTE.DataSource = null;
                grdPuntaFinBTI.DataSource = null;
                grdPuntaFinBTE.DataSource = null;

                SetMaterialLabelText("Consultando información...");

                lblLodingItems.Visible = true;
                lblLodingItems.BringToFront();
                CenterLoadingMaterialLabel();
            }
            else if (progressReport.State == OperationState.Running)
            {
                if (progressReport.Value == 1)
                {
                    DisplayMaterial();
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
            //agregar los resets de los demas grids
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
                lblNoOrder.Visible = true;
                lblNoOrder.BringToFront();
                lblNoOrder.Visible = (connection.State == HubConnectionState.Connected);
                CenterNoOrderLabel();
                pnlOrder.Visible = false;
                grItems.Visible = false;
                lblLodingItems.Visible = false;
                //grids de puntas                
                grdPuntoInicialBTI.Visible = false;
                grdPuntaFinBTI.Visible = false;
                grdPuntaInicioBTE.Visible = false;
                grdPuntaFinBTE.Visible = false;
                tbLayoutGrpGrd.Visible = false;
            }
            else
            {
                pnlOrder.Visible = true;
                lblNoOrder.Visible = false;
                grItems.Visible = true;
                //grids de puntas
                grdPuntoInicialBTI.Visible = true;
                grdPuntaFinBTI.Visible = true;
                grdPuntaInicioBTE.Visible = true;
                grdPuntaFinBTE.Visible = true;
                tbLayoutGrpGrd.Visible = true;
            }
        }

        private void DisplayMaterial()
        {
            grItems.DataSource = AluminumDataGrid;

            if (EndPointInfo != null)
            {
                List<PuntaGridItem> lstData = EndPointInfo.PuntasIni.BTE.Select(r => new PuntaGridItem() { Description = r }).ToList();//EndPointInfo.PuntasIni.BTE.Take(2).Select(r => new PuntaGridItem() { Description = r }).ToList();
                grdPuntaInicioBTE.DataSource = lstData.ToList();
                lstData = EndPointInfo.PuntasIni.BTI.Select(r => new PuntaGridItem() { Description = r }).ToList();//EndPointInfo.PuntasIni.BTI.Take(2).Select(r => new PuntaGridItem() { Description = r }).ToList();
                grdPuntoInicialBTI.DataSource = lstData.ToList();
                lstData = EndPointInfo.PuntasFin.BTE.Select(r => new PuntaGridItem() { Description = r }).ToList();//EndPointInfo.PuntasFin.BTE.Take(2).Select(r => new PuntaGridItem() { Description = r }).ToList();
                grdPuntaFinBTE.DataSource = lstData.ToList();
                lstData = EndPointInfo.PuntasFin.BTI.Select(r => new PuntaGridItem() { Description = r }).ToList();//EndPointInfo.PuntasFin.BTI.Take(2).Select(r => new PuntaGridItem() { Description = r }).ToList();
                grdPuntaFinBTI.DataSource = lstData.ToList();
            }
        }

        private void SetMaterialLabelText(string labelText)
        {
            lblLodingItems.AutoSize = true;
            lblLodingItems.Text = labelText;
            CenterLoadingMaterialLabel();
        }

        private void CenterLoadingMaterialLabel()
        {
            int lblTop = Top + ((ClientSize.Height / 2) - (lblLodingItems.Height / 2));
            int lblLeft = Left + ((ClientSize.Width / 2) - (lblLodingItems.Width / 2));
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

            #endregion
        }

        internal class PuntaGridItem
        {
            #region Constructor

            public PuntaGridItem()
            {
                Description = "noData";
            }

            #endregion

            #region Properties

            public string Description { get; set; }

            #endregion
        }
    }
}