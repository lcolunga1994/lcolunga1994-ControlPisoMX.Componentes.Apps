namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CoresSupplyServiceHttpService : Http.WebApiClient, ICoresSupplyService
    {
        #region Fields

        private readonly ILogger<CoresSupplyServiceHttpService> logger;

        #endregion

        #region Constructor

        public CoresSupplyServiceHttpService(
           HttpClient httpClient,
           ILogger<CoresSupplyServiceHttpService> logger)
           : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/v1";
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<MOManufacturingStatusModel>> GetManufacturingOrdersAvailableToSupplyAsync(DateTime date, string machine, CancellationToken cancellationToken)
        {
            try
            {
                return (await GetAsync<IEnumerable<MOManufacturingStatusModel>, DateAndMachineParameterModel>("cores/supply/ordersto",
                    new DateAndMachineParameterModel()
                    {
                        Machine = machine,
                        Date = date
                    },
                    cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<MOManufacturingStatusModel>();
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar las ordenes planificadas para el día {date} y maquina {machine} disponibles para suministrar.", date.ToString("G"), machine);
                throw CreateServiceException($"No se pueden consultar las ordenes planificadas para el día {date:G} y maquina {machine} disponibles para suministrar en este momento.", "ManufacturingOrdersAvailableToSupply");
            }
        }

        public async Task AddOrdersToSupplyListAsync(List<OrderParameterModel> orders, CancellationToken cancellationToken)
        {
            try
            {
                await PostAsync($"cores/supply/supplylist", orders, CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al registrar las ordenes como disponibles para suministrar núcleos.");
                throw CreateServiceException("No se pueden registrar las ordenes como disponibles para suministrar núcleos en este momento.", "AddOrdersToSupplyList");
            }
        }

        public async Task<IEnumerable<MOSupplyItemModel>> GetPendingSuppliesAsync(CancellationToken cancellationToken)
        {
            try
            {
                return (await GetAsync<IEnumerable<MOSupplyItemModel>>("cores/supply/pending", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<MOSupplyItemModel>();
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar las ordenes disponibles para suministrar núcleos.");
                throw CreateServiceException("No se pueden consultar las ordenes disponibles para suministrar núcleos en este momento.", "PendingSupplies");
            }
        }

        public async Task<MOSupplyItemTagModel?> GetSupplyTagAsync(Guid manufacturingOrderId)
        {
            try
            {
                return (await GetAsync<MOSupplyItemTagModel>($"cores/supply/tag/{manufacturingOrderId}", CancellationToken.None)
                    .ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError("Ocurrió un error al consultar información para imprimir el suministro de orden con Id {id}", manufacturingOrderId);
                throw CreateServiceException("No se puede consultar la información para imprimir el suministro de orden en este momento.", "SupplyTag");
            }
        }

        public async Task<MOSupplySummaryModel?> GetManufacturingOrderSupplySummary(string itemId, string batch)
        {
            try
            {
                return await GetAsync<MOSupplySummaryModel, BatchParameterModel>(
                        "cores/supply/summary",
                        new BatchParameterModel(itemId, batch),
                        CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar las ordenes suministradas para el pedido {itemId}-{batch}.", itemId, batch);
                throw CreateServiceException($"No se pueden consultar las ordenes suministradas para el pedido {itemId}-{batch} en este momento.", "ManufacturingOrderSupply");
            }
        }

        public async Task ConfirmSupplyAsync(string itemId, string batch, int serie)
        {
            try
            {
                await PostAsync($"cores/supply/confirm/{itemId}/{batch}/{serie}")
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al confirmar el suministro de la orden '{itemId}-{batch}-{serie}'.", itemId, batch, serie);

                throw CreateServiceException("No se puede confirmar el suministro de la orden en este momento.", "ConfirmSupply");
            }
        }

        public async Task AuthorizeReprintAsync(string itemId, string batch, int serie)
        {
            try
            {
                await PostAsync($"cores/supply/authorizereprint/{itemId}/{batch}/{serie}")
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al autorizar la reimpresión de la orden {itemId}-{batch}-{serie}'.", itemId, batch, serie);

                throw CreateServiceException("No se puede autorizar la reimpresión de la orden en este momento.", "AuthorizeReprint");
            }
        }

        public async Task<IEnumerable<MOSupplyItemModel>> GetSuppliesToReprintAsync()
        {
            try
            {
                return (await GetAsync<IEnumerable<MOSupplyItemModel>>($"cores/supply/reprint", CancellationToken.None)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<MOSupplyItemModel>();
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar las ordenes autorizadas para reimprimir.");

                throw CreateServiceException("No se pueden consultar las ordenes autorizadas para reimprimir en este momento.", "SuppliesToReprint");
            }
        }

        public async Task<SupplyCoreResultModel?> SupplyCoresAsync(string itemId, string batch, int serie, bool force, string user)
        {
            try
            {
                return await PostAsync<SupplyCoreResultModel>($"cores/supply/SupplyCores/{itemId}/{batch}/{serie}/{force}/{user}", CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al suministrar núcleos {itemId}-{batch}-{serie} {user}'.", itemId, batch, serie, user);

                throw CreateServiceException(
                    "No se pueden suministrar núcleos.",
                    "SupplyCores");
            }
        }
        public async Task<SupplyCoreResultModel?> SupplyCoresAsync_discpiso(string itemId, string batch, int serie, bool force, string user)
        {
            try
            {
                return await PostAsync<SupplyCoreResultModel>($"cores/supply/SupplyCores_discpiso/{itemId}/{batch}/{serie}/{force}/{user}", CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al suministrar núcleos {itemId}-{batch}-{serie} {user}'.", itemId, batch, serie, user);

                throw CreateServiceException(
                    "No se pueden suministrar núcleos.",
                    "SupplyCores");
            }
        }

        public async Task ReprintAsync(Guid manufacturingOrderId, string user)
        {
            try
            {
                await PostAsync($"cores/supply/reprint/{manufacturingOrderId}/{user}")
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al registrar la reimpresión de la orden con id {id}'.", manufacturingOrderId);

                throw CreateServiceException("No se puede registar la reimpresión de la orden en este momento.", "Reprint");
            }
        }

        #endregion

        #region Functionality

        private static UserException CreateServiceException(string message, string errorCode)
        {
            System.Text.StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(message);
            throw new UserException(stringBuilder.ToString(), errorCode, true);
        }

        #endregion
    }
}