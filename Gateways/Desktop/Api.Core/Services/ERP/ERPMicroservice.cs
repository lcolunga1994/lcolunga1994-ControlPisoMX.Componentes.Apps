namespace ProlecGE.ControlPisoMX.ERP.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.ERP;
    using ProlecGE.ControlPisoMX.ERP.Models;
    using ProlecGE.ControlPisoMX.ERP.Models.CoresSupply;

    public class ERPMicroservice : Http.WebApiClient, IMicroservice
    {
        #region Fields

        private readonly ILogger<ERPMicroservice> logger;

        #endregion

        #region Constructor

        public ERPMicroservice(
            HttpClient httpClient,
            ILogger<ERPMicroservice> logger)
            : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/v1";
        }

        #endregion

        #region Item

        public async Task<ItemModel?> GetItemAsync(
            string itemId,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el artículo '{itemId}'.");

                return await GetAsync<ItemModel?>(
                    $"items/{itemId}",
                    cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar el artículo '{itemId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar la información del artículo en este momento.",
                    "ERPItem");
            }
        }

        public async Task<ItemModel?> GetItemGeneralDataAsync(
            string itemId,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando la información general del artículo '{itemId}'.");

                return await GetAsync<ItemModel?>(
                    $"items/{itemId}/general",
                    cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar la información general del artículo '{itemId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar la información general del artículo en este momento.",
                    "ERPGeneralData");
            }
        }

        public async Task<WindingModel?> GetWindingAsync(string itemId)
        {
            try
            {
                return await GetAsync<WindingModel>($"items/windings/{itemId}", CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar los datos de devanado para el artículo '{itemId}' en este momento.", itemId);
                throw CreateServiceException(
                    $"No se pueden consultar los datos de devanado para el artículo '{itemId}' en este momento.",
                    "GetItemGuillotineShears");
            }
        }

        public async Task<ArmingAndConnectingModel?> GetArmingAndConnectingAsync(string itemId)
        {
            try
            {
                return await GetAsync<ArmingAndConnectingModel>($"items/armingandconnecting/{itemId}", CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar los datos de armado y conectado BT para el artículo '{itemId}' en este momento.", itemId);
                throw CreateServiceException(
                    $"No se pueden consultar los datos de armado y conectado BT para el artículo '{itemId}' en este momento.",
                    "GetItemGuillotineShears");
            }
        }

        public async Task<ItemLaboratoryModel?> GetLaboratoryAsync(string itemId)
        {
            try
            {
                return await GetAsync<ItemLaboratoryModel>($"items/laboratory/{itemId}", CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar los datos de laboratorio para el artículo '{itemId}' en este momento.", itemId);
                throw CreateServiceException(
                    $"No se pueden consultar los datos de laboratorio para el artículo '{itemId}' en este momento.",
                    "GetItemGuillotineShears");
            }
        }

        public async Task<IEnumerable<ItemLVConnectorModel>> GetLVConnectorAsync(string itemId)
        {
            try
            {
                return (await GetAsync<IEnumerable<ItemLVConnectorModel>>($"items/lvconnector/{itemId}", CancellationToken.None)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<ItemLVConnectorModel>();
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar los datos de connector BT para el artículo '{itemId}' en este momento.", itemId);
                throw CreateServiceException(
                    $"No se pueden consultar los datos de connector BT para el artículo '{itemId}' en este momento.",
                    "GetItemGuillotineShears");
            }
        }

        #endregion

        #region Orders

        public async Task<ManufacturingOrderModel?> GetManufacturingOrderAsync(string itemId, string batch, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Consultando orden de fabricación {itemId}-{batch}.", itemId, batch);

                return await GetAsync<ManufacturingOrderModel>($"orders/manufacturing/{itemId}/{batch}", cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar la orden de fabricación {itemId}-{batch}.", itemId, batch);

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar la orden de fabricación {itemId}-{batch}. en este momento.",
                    "ManufacturingOrder");
            }
        }

        public async Task<bool> GetManufacturingProgramValidationAsync(string itemId, string batch, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Cunsultando validación de programa de fabricación ' {itemId}', {batch}.");

                return await GetAsync<bool>($"items/manufacturingprogramvalidation/{itemId}/{batch}", cancellationToken)
                    .ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar validación de programa de fabricación ' {itemId}', {batch}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar la validación de programa de fabricación ' {itemId}', {batch}..",
                    "manufacturingprogramvalidation");
            }
        }

        #endregion

        #region Cores

        public async Task<ItemVoltageDesignModel?> GetItemVoltageDesignAsync(
            string itemId,
            string designId,
            int coreSize,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando los voltajes del artículo '{itemId}' - diseño '{designId}'.");

                return await GetAsync<ItemVoltageDesignModel?>(
                    $"cores/design/voltage/{itemId}/{designId}/{(int)coreSize}",
                    cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar los voltajes del artículo '{itemId}' - diseño '{designId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar la información de diseño en este momento.",
                    "CoresVoltageDesign");
            }
        }

        #region Cores supply

        public async Task<CoreSupplyTagModel?> GetItemCoresSupplyTagDataAsync(string itemId, string batch, int serie)
        {
            try
            {
                return (await GetAsync<CoreSupplyTagModel>($"custom/supplytag/{itemId}/{batch}/{serie}", CancellationToken.None)
                    .ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar los valores para imprimir en la etiqueta de suministro de núcleos.");
                throw CreateServiceException(
                    $"No se pueden consultar los valores para imprimir en la etiqueta de suministro de núcleos en este momento.",
                    "ItemCoresSupplyTagData");
            }
        }

        #endregion

        #endregion

        #region Insulations

        public async Task<string> GetMachineManufacturingAsync(
            string itemId,
            string batch,
            int serie,
            int sequence,
            CancellationToken cancellationToken)
        {
            try
            {
                return (await GetAsync<string>($"insulations/machineManufacturing/{itemId}/{batch}/{serie}/{sequence}", cancellationToken)
                    .ConfigureAwait(false)) ?? "";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar maquina CMS para la orden {itemId}-{batch}-{serie}.", itemId, batch, serie);

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden consultar maquina CMS en este momento.",
                    "MachineManufacturing");
            }
        }

        public async Task<IEnumerable<CartonShearModel>> GetItemCartonShearsAsync(
            string itemId,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando datos de materiales de Cizalla '{itemId}'.");

                return (await GetAsync<IEnumerable<CartonShearModel>>($"insulations/cartonShears/{itemId}", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<CartonShearModel>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar datos de los materiales de Cizalla'{itemId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden consultar los datos de los materiales en este momento",
                    "GetItemCartonShears");
            }
        }

        public async Task<IEnumerable<GuillotineShearModel>> GetItemGuillotineShearsAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando datos de materiales de la guillotina para el artículo '{itemId}'.");

                return (await GetAsync<IEnumerable<GuillotineShearModel>>($"insulations/guillotineShears/{itemId}", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<GuillotineShearModel>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar datos de los materiales de la guillotina para el artículo '{itemId}' en este momento.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar los datos de los materiales de la guillotina para el artículo '{itemId}' en este momento.",
                    "GetItemGuillotineShears");
            }
        }

        public async Task<IEnumerable<SierraShearModel>> GetItemSierraShearsAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando datos de materiales de sierra para el artículo '{itemId}'.");

                return (await GetAsync<IEnumerable<SierraShearModel>>($"insulations/sierraShears/{itemId}", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<SierraShearModel>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar datos de los materiales de sierra para el artículo '{itemId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar los datos de los materiales de sierra para el artículo '{itemId}' en este momento.",
                    "ItemSierraShears");
            }
        }

        public async Task<AluminumTipPuntasModel?> GetItemAluminumTipsAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando datos de materiales de soldadura de puntas de aluminio para el artículo '{itemId}'.");

                return await GetAsync<AluminumTipPuntasModel?>($"insulations/aluminumShears/{itemId}", cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar datos de los materiales de soldadura de puntas de aluminio para el artículo '{itemId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar los datos de los materiales de soldadura de puntas de aluminio para el artículo '{itemId}' en este momento.",
                    "ItemAluminumTips");
            }
        }

        public async Task<IEnumerable<AluminiumCutModel>> GetItemAluminiumCutsAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando datos de materiales de cortes de aluminio para el artículo '{itemId}'.");

                return (await GetAsync<IEnumerable<AluminiumCutModel>>($"insulations/aluminiumCuts/{itemId}", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<AluminiumCutModel>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar datos de cortes de puntas de aluminio para el artículo '{itemId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar los datos de los materiales de cortes de aluminio para el artículo '{itemId}' en este momento.",
                    "ItemAluminiumCuts");
            }
        }

        public async Task<string?> GetItemDimensionsAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando las dimensiones del articulo '{itemId}'.");

                return await GetAsync<string?>($"insulations/dimensions/{itemId}", cancellationToken)
                    .ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar las dimensiones del articulo '{itemId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar las dimensiones del articulo '{itemId}' en este momento.",
                    "ItemDimensions");
            }
        }

        #endregion

        #region Assembly

        public async Task<IEnumerable<MaterialModel>> GetMaterialsAsync(
            string itemId,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando los materiales del diseño '{itemId}'.");

                return (await GetAsync<IEnumerable<MaterialModel>>($"assembly/{itemId}/materials", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<MaterialModel>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar los materiales del diseño '{itemId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden consultar los materiales del artículo en este momento.",
                    "ERPItemMaterials");
            }
        }

        public async Task<IEnumerable<string>> GetNotesAsync(
            string designId,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando los notas del diseño '{designId}'.");

                return (await GetAsync<IEnumerable<string>>($"assembly/{designId}/notes", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<string>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar las notas del diseño '{designId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden consultar las notas del diseño en este momento.",
                    "ERPItemNotes");
            }
        }

        public async Task<IEnumerable<PositionModel>> GetPositionsAsync(
            string designId,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando las posiciones del diseño '{designId}'.");

                return (await GetAsync<IEnumerable<PositionModel>>($"assembly/{designId}/positions", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<PositionModel>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar las posiciones del diseño '{designId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden consultar las posiciones del diseño en este momento.",
                    "ERPItemPositions");
            }
        }

        public async Task<IEnumerable<AccessoryModel>> GetAccessoriesAsync(
            string itemId,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando los accesorios en el diseño '{itemId}'.");

                return (await GetAsync<IEnumerable<AccessoryModel>>($"assembly/{itemId}/accessories", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<AccessoryModel>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar los accesorios del diseño '{itemId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden consultar los accesorios del diseño en este momento.",
                    "ERPItemAccessories");
            }
        }

        #endregion

        #region Clamps

        public async Task<IEnumerable<ItemClampModel>> GetItemClampsAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Consultando los herrajes del artículo '{itemId}'.", itemId);

                return (await GetAsync<IEnumerable<ItemClampModel>>($"clamps/{itemId}", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<ItemClampModel>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar los herrajes del artículo '{itemId}'.", itemId);

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar los herrajes del artículo '{itemId}' en este momento.",
                    "ItemClamps");
            }
        }

        public async Task<string> GetItemMarketAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Consultando el meracado del artículo '{itemId}'.", itemId);

                return (await GetAsync<string>($"clamps/market/{itemId}", cancellationToken)
                    .ConfigureAwait(false)) ?? string.Empty;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar el mercado del artículo '{itemId}'.", itemId);

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar el mercado del artículo '{itemId}' en este momento.",
                    "ItemMarket");
            }
        }


        #endregion

        #region Combo

        public async Task<IEnumerable<ComboOrderDesignModel>> GetComboOrderDesignAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando datos de diseño de orden '{itemId}'.");

                return (await GetAsync<IEnumerable<ComboOrderDesignModel>>($"combo/comboorderdesign/{itemId}", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<ComboOrderDesignModel>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar los datos de diseño de orden '{itemId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar los datos de diseño de orden '{itemId}' en este momento.",
                    "ComboOrderDesign");
            }
        }

        #endregion

        #region Guitonille

        public async Task<TankGuillotineModel?> GetItemTankInfoAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando Información de la orden '{itemId}'.");

                return (await GetAsync<TankGuillotineModel>($"items/tankguillotineinfo?itemId={itemId}", cancellationToken)
                    .ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar la orden '{itemId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar los datos de la orden '{itemId}' en este momento.",
                    "GuillotineOrders");
            }
        }

        #endregion

        #region Functionality

        private static UserException CreateServiceException(string message, string errorCode)
        {
            System.Text.StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(message);
            stringBuilder.AppendLine("Ocurrió un error en el servidor.");
            stringBuilder.AppendLine($"Contacte al area de sistemas ({errorCode}).");
            throw new UserException(stringBuilder.ToString(), errorCode, true);
        }        

        #endregion
    }
}