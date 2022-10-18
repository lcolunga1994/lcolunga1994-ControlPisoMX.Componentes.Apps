namespace ProlecGE.ControlPisoMX.CoreSupply.Forms
{
    using Microsoft.Extensions.Configuration;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;
    using ProlecGE.ControlPisoMX.CoreSupply.Forms.Utils;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class ValidSupplyForm : ThemedForm
    {
        #region Fields

        private readonly MediatR.IMediator mediator;

        #endregion

        #region Constructor

        public ValidSupplyForm(
            MediatR.IMediator mediator,
            TagItemModel item)
        {
            InitializeComponent();
            CustomInitializeComponent();
            this.mediator = mediator;
            this.Item = item;
            txtOrder.Text = item.ItemId;
            txtBatch.Text = item.Batch;
            txtSerie.Text = item.Serie.ToString();
            Orders = new BindingList<DataGridViewItemModel>();
            SendOrdersToPrint = new List<CoreManufacturingTagModel>();
        }

        #endregion

        #region Propieties 

        private BindingList<DataGridViewItemModel> Orders { set; get; }

        public List<CoreManufacturingTagModel> SendOrdersToPrint { set; get; }

        private TagItemModel Item { set; get; }

        private ItemModel? OrderItem { set; get; }

        private int Phases { set; get; }

        private bool Force { set; get; }

        private bool SensitiveAddCoreFlag { set; get; }

        private MOSupplyItemTagModel? PrintingOrder { set; get; }

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
            ApplySecondaryButtonTheme(btnClear);

            grItems.Columns.Clear();
            grItems.AutoGenerateColumns = false;
            ApplyDataGridViewDefaultProperties(grItems);
            grItems.CellPainting += OnGrOrders_CellPainting;

            DataGridViewTextBoxColumn dataColumn = new()
            {
                HeaderText = "IDENTIFICADOR",
                DataPropertyName = nameof(DataGridViewItemModel.Id),
                ReadOnly = true
            };
            grItems.Columns.Add(dataColumn);

            dataColumn = new()
            {
                HeaderText = "WHATTS CORREGIDOS",
                DataPropertyName = nameof(DataGridViewItemModel.WhattsCorr),
                ReadOnly = true,
                MinimumWidth = 100
            };
            grItems.Columns.Add(dataColumn);

            dataColumn = new()
            {
                HeaderText = "COLOR",
                DataPropertyName = nameof(DataGridViewItemModel.CoreResultText),
                Name = nameof(DataGridViewItemModel.CoreTestColor),
                ReadOnly = true,
                MinimumWidth = 50,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };
            grItems.Columns.Add(dataColumn);

            dataColumn = new()
            {
                HeaderText = "FECHA",
                DataPropertyName = nameof(DataGridViewItemModel.Date),
                ReadOnly = true,
                MinimumWidth = 170
            };
            grItems.Columns.Add(dataColumn);

            dataColumn = new()
            {
                HeaderText = "ETIQUETA HORNO",
                DataPropertyName = nameof(DataGridViewItemModel.Tag),
                ReadOnly = true,
                MinimumWidth = 100
            };
            grItems.Columns.Add(dataColumn);

            SetColumnContentAlign(grItems, DataGridViewContentAlignment.MiddleCenter, new string[]
            {
                nameof(DataGridViewItemModel.Id),
                nameof(DataGridViewItemModel.WhattsCorr),
                nameof(DataGridViewItemModel.CoreResultText),
                nameof(DataGridViewItemModel.Date)
            });

            txtOrder.Enabled = false;
            txtBatch.Enabled = false;
            txtSerie.Enabled = false;
        }

        #endregion

        #region Events
        private void TxtAddCore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddSupply();
            }
        }

        private void GrItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (grItems.Rows[e.RowIndex].DataBoundItem is DataGridViewItemModel custom)
                {
                    RemoveSupply(custom.CoreTestId);
                }
            }
        }

        private void ValidSupplyForm_Load(object sender, EventArgs e)
        {
            LoadItem();
        }

        private void OnGrOrders_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (grItems.Columns[e.ColumnIndex].DataPropertyName == nameof(DataGridViewItemModel.CoreResultText))
                {
                    if (sender is DataGridView dataGridView)
                    {
                        if (dataGridView.Rows[e.RowIndex].DataBoundItem is DataGridViewItemModel itemModel)
                        {
                            DataGridViewCellStyle cellStyle = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style;

                            cellStyle.BackColor = itemModel.CoreTestColor switch
                            {
                                CoreLimitColor.Blue => Color.Blue,
                                CoreLimitColor.Green => GreenColor,
                                CoreLimitColor.Yellow => YellowColor,
                                CoreLimitColor.Red => RedColor,
                                CoreLimitColor.None => dataGridView.DefaultCellStyle.BackColor,
                                _ => dataGridView.DefaultCellStyle.BackColor
                            };
                        }
                    }
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e) => ClearAll();

        private void BtnClose_Click(object sender, EventArgs e) => Close();

        private void BtnAcept_Click(object sender, EventArgs e)
        {
            SupplyCores();
        }

        #endregion

        #region Queries

        public async void LoadItems()
        {
            OperationProgress<bool> operation = new(OnProgressChanged);

            try
            {
                operation.Start();
                Orders = new BindingList<DataGridViewItemModel>((await mediator
                    .Send(new ClientApp.Queries.ResidentialCoreSupplyByOrderQuery(Item.ItemId, Item.Batch, Item.Serie))
                    .ConfigureAwait(false))
                    .Select(e => new DataGridViewItemModel()
                    {
                        Id = e.Identifier,
                        WhattsCorr = e.WattsCorr.ToString("N2"),
                        CoreTestColor = (CoreLimitColor)e.Color,
                        Date = e.SupplyUtcDate.ToLocalTime(),
                        Tag = e.Tag,
                        CoreTestId = e.Id
                    })
                    .ToList());

                operation.Report(true);
            }
            catch (Exception ex)
            {
                operation.Error("Ocurrió un error al cargar el listado de núcleos.", ex);
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
                    grItems.DataSource = null;
                }
                else if (progressReport.State == OperationState.Running)
                {
                    if (progressReport.Value == true)
                    {
                        DisplayManufacturingPlan();
                        CleanCore();
                        if (SensitiveAddCoreFlag)
                        {
                            SensitiveSupplyCores();
                        }
                        SensitiveAddCoreFlag = false;
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

        private async void LoadItem()
        {
            OperationProgress<bool> operation = new(OnProgressChanged);

            try
            {
                operation.Start();
                OrderItem = await mediator
                    .Send(new ClientApp.Queries.ItemQuery(Item.ItemId))
                    .ConfigureAwait(false);

                if (OrderItem is not null)
                {
                    Phases = OrderItem.Phases;
                }

                operation.Report(true);
            }
            catch (Exception ex)
            {
                operation.Error($"Ocurrió un error al cargar el item: {Item.ItemId}.", ex);
            }
            finally
            {
                operation.Finish();
            }

            void OnProgressChanged(OperationProgressReport<bool> progressReport)
            {
                if (progressReport.State == OperationState.Started)
                {
                }
                else if (progressReport.State == OperationState.Running)
                {
                    if (progressReport.Value == true)
                    {
                        LoadItems();
                    }
                }
                else if (progressReport.State == OperationState.Error)
                {
                    ShowErrorMessage(progressReport.ErrorMessage ?? "", "Cargando item.", progressReport.Exception);
                }
                else if (progressReport.State == OperationState.Canceled || progressReport.State == OperationState.Finished)
                {
                }
            }
        }

        #endregion

        #region Commands

        public async void RemoveSupply(Guid id)
        {
            Force = false;

            OperationProgress<bool> operation = new(OnProgressChanged);
            operation.Start();

            try
            {

                await mediator
               .Send(new ClientApp.Commands.RemoveSupplyCoreCommand(id))
               .ConfigureAwait(false);

                operation.Report(true);
            }
            catch (Exception ex)
            {
                operation.Error($"Ocurrió un error al remover el suministro de núcleo.", ex);
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
                    if (progressReport.Value == true)
                    {
                        LoadItems();
                    }
                }
                else if (progressReport.State == OperationState.Error)
                {
                    ShowErrorMessage(progressReport.ErrorMessage ?? "", "Remover suministro de núcleo.", progressReport.Exception);
                    CleanCore();
                }
                else if (progressReport.State == OperationState.Canceled || progressReport.State == OperationState.Finished)
                {
                    SetBusy(false);
                }
            }
        }

        public async void AddSupply()
        {
            Force = false;
            if (string.IsNullOrEmpty(txtAddCore.Text))
            {
                MessageBox.Show("Debe introducir un código de prueba.", "Código de prueba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                OperationProgress<bool> operation = new(OnProgressChanged);
                operation.Start();

                try
                {

                    await mediator
                   .Send(new ClientApp.Commands.AddSupplyCoreCommand(
                       new AddSupplyCoreModel(txtOrder.Text, txtBatch.Text, int.Parse(txtSerie.Text), txtAddCore.Text, "123")))
                   .ConfigureAwait(false);

                    operation.Report(true);
                }
                catch (Exception ex)
                {
                    operation.Error($"Ocurrió un error al agregar el suministro de núcleo.", ex);
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
                    if (progressReport.Value == true)
                    {
                        SensitiveAddCoreFlag = true;
                        LoadItems();
                    }
                }
                else if (progressReport.State == OperationState.Error)
                {
                    ShowErrorMessage(progressReport.ErrorMessage ?? "", "Agregar suministro de núcleo.", progressReport.Exception);
                    CleanCore();
                }
                else if (progressReport.State == OperationState.Canceled || progressReport.State == OperationState.Finished)
                {
                    SetBusy(false);
                }
            }
        }

        private async void SupplyCores()
        {
            bool accomplished = false;
            bool negativeAnswer = false;
            SupplyCoreResultModel? result;
            if (Phases == 1)
            {
                if (grItems.RowCount != 2)
                {
                    ShowErrorMessage("Articulos monofasicos deben contar con 2 núcleos", "Suministrar núcleos.", null);
                    return;
                }
            }

            if (Phases == 3)
            {
                if (grItems.RowCount != 4)
                {
                    ShowErrorMessage("Articulos trifasicos deben contar con 4 núcleos", "Suministrar núcleos.", null);
                    return;
                }
            }

            OperationProgress<bool> operation = new(OnProgressChanged);

            try
            {
                operation.Start();

                result = await mediator
                   .Send(new ClientApp.Commands.SupplyCoreCommand(txtOrder.Text, txtBatch.Text, int.Parse(txtSerie.Text), Force))
                   .ConfigureAwait(false);

                if (result is not null && result.SupplyValidationResult is not null)
                {
                    accomplished = result.SupplyValidationResult.Accomplished;
                    if (!result.SupplyValidationResult.Accomplished)
                    {
                        if ((result.SupplyValidationResult.IsPhasesRuleValid && !result.SupplyValidationResult.IsCoreColorRuleValid) || !result.SupplyValidationResult.IsAssignationCoreValid)
                        {
                            DialogResult dialogResult = MessageBox.Show(result.SupplyValidationResult.Message + Environment.NewLine + "¿Desea continuar?", "Confirmación", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                Force = true;
                            }
                            else
                            {
                                negativeAnswer = true;
                            }
                        }
                        else if (!result.SupplyValidationResult.IsPhasesRuleValid)
                        {
                            Force = false;
                            if (!result.SupplyValidationResult.MonophaseValid)
                            {
                                if (result.SupplyValidationResult.Phases == 1)
                                {
                                    throw new UserException($"La orden requiere {2} donas para ser suministrada.");
                                }
                                else if (result.SupplyValidationResult.Phases == 3)
                                {
                                    throw new UserException($"La orden requiere {4} donas para ser suministrada.");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (result.Printable is not null)
                        {
                            PrintingOrder = result.Printable;
                        }
                    }
                }

                operation.Report(true);
            }
            catch (Exception ex)
            {
                operation.Error($"Ocurrió un error al agregar el suministro de núcleo.", ex);
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
                    if (progressReport.Value == true)
                    {
                        if (Force)
                        {
                            SupplyCores();
                        }
                        CleanCore();
                        LoadItems();
                        Force = false;
                        if (negativeAnswer)
                        {
                            return;
                        }
                        if (accomplished)
                        {
                            PrintOrder();
                        }
                        DialogResult = DialogResult.OK;
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

        private void SensitiveSupplyCores()
        {
            if (Phases == 1 && grItems.Rows.Count == 2)
            {
                SupplyCores();
            }
            if (Phases == 3 && grItems.Rows.Count == 4)
            {
                SupplyCores();
            }
        }

        private void ClearAll()
        {
            foreach (DataGridViewItemModel? item in Orders)
            {
                if (item is not null)
                {
                    RemoveSupply(item.CoreTestId);
                }
            }
        }

        private void CleanCore()
        {
            txtAddCore.Text = String.Empty;
            txtAddCore.Focus();
        }

        private void PrintOrder()
        {
            OperationProgress<bool> operation = new(OnProgressChanged);

            try
            {
                operation.Start();
                if (PrintingOrder is not null)
                {
                    mediator
                        .Send(new ClientApp.Commands.PrintTagCommand(PrintingOrder))
                        .ConfigureAwait(false);
                }
                operation.Report(true);
            }
            catch (Exception ex)
            {
                operation.Error($"Problemas al imprmir etiquetas", ex);
            }
            finally
            {
                operation.Finish();
            }

            void OnProgressChanged(OperationProgressReport<bool> progressReport)
            {
                if (progressReport.State == OperationState.Started)
                {

                }
                else if (progressReport.State == OperationState.Running)
                {
                    if (progressReport.Value == true)
                    {
                        //Close();
                    }
                }
                else if (progressReport.State == OperationState.Error)
                {
                    ShowErrorMessage(progressReport.ErrorMessage ?? "", "Lista de maquinas", progressReport.Exception);
                }
                else if (progressReport.State == OperationState.Canceled || progressReport.State == OperationState.Finished)
                {
                }
            }
        }


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
            BtnAcept.Enabled = !formIsBusy;
            btnClear.Enabled = !formIsBusy;
            btnClose.Enabled = !formIsBusy;
        }

        private void DisplayManufacturingPlan()
        {
            grItems.DataSource = Orders;
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
                        if (userException.SystemErrorCode is (int)SystemErrorCode.SupplyCoreCombination)
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
                Id = "";
                WhattsCorr = "noData";
                Date = DateTime.UtcNow;
                CoreTestColor = (int)CoreLimitColor.None;
                CoreResultText = "";
                Tag = "noData";
                CoreTestId = new Guid();
            }

            #endregion

            #region Properties

            public Guid CoreTestId { set; get; }

            public string Id { get; set; }

            public string WhattsCorr { get; set; }

            public CoreLimitColor CoreTestColor { get; set; }

            public DateTime Date { get; set; }

            public string CoreResultText { get; set; }

            public string Tag { get; set; }

            #endregion
        }

    }
}
