namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using Insulations.Models;

    using Microsoft.Extensions.Logging;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class InsulationsHttpService : Http.WebApiClient, IInsulationsService
    {
        #region Fields

        private readonly ILogger<InsulationsHttpService> logger;

        #endregion

        #region Constructor

        public InsulationsHttpService(
           HttpClient httpClient,
           ILogger<InsulationsHttpService> logger)
           : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/v1";
        }

        #endregion

        #region Security

        public async Task<string> GetUserAsync(string username, string password, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Consultando el usuario.");

                if (string.IsNullOrWhiteSpace(username))
                {
                    throw new UserException("La usuario es requerido.");
                }
                return await GetAsync<string>($"insulations/getusername?username={username}&password={password}", cancellationToken).ConfigureAwait(false) ?? "";

            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar usuario", "GetUser");
            }
        }

        public async Task<bool> ValidateUserPasswordAsync(string username, string password, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Validando el usuario.");

                if (string.IsNullOrWhiteSpace(username))
                {
                    throw new UserException("La usuario es requerido.");
                }

                return await GetAsync<bool>($"insulations/validateuserpassword?username={username}&password={password}", CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede validar el usuario", "ValidateUserPassword");
            }
        }

        #endregion

        #region Configurations

        public async Task<bool> IsManufacturingAllowedAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el estado de las labores.");

                bool result = await GetAsync<bool>($"insulations/ismanufacturingallowed", cancellationToken)
                    .ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar el estado de las labores.", "IsManufacturingAllowed");
            }
        }

        public async Task ChangeAllowManufacturingAsync(bool allow, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Supendiendo/Reactivando Labores.");

#pragma warning disable CA2016 // Forward the 'CancellationToken' parameter to methods
                await PostAsync($"insulations/changeallowmanufacturing?allow={allow.ToString().ToLower()}")
#pragma warning restore CA2016 // Forward the 'CancellationToken' parameter to methods
                    .ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede suspender/reactivar labores", "changesAllowmanufacturing");
            }
        }

        public async Task<int?> GetMinimumManufactureMinutesAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando información de minutos minimos por orden.");
                int? result = await GetAsync<int?>($"insulations/minimummanufactureminutes", cancellationToken)
                    .ConfigureAwait(false);
                if (result == null)
                {
                    logger.LogInformation($"No se encontró la información de minutos minimos por orden.");
                }
                return result;
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar la información de minutos minimos por orden.", "MinimumManufactureMinutes");
            }
        }

        public async Task<int> GetManufacturingMinutesAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando información de minutos asignados por orden.");

                int result = await GetAsync<int>($"insulations/manufactureminutes", cancellationToken)
                    .ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar la información de minutos asignados por orden.", "ManufactureMinutes");
            }
        }

        public async Task<bool> MachineCanPrintAsync(string machine, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando si la maquina puede imprimir.");

                bool result = await GetAsync<bool>($"insulations/machinecanprint/{machine}", cancellationToken)
                    .ConfigureAwait(false);


                return result;
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar si la maquina puede imprimir.", "GetMachineCanPrint");
            }
        }

        public async Task<MachineWorkloadFlagConfigurationModel> GetMachineWorkloadSemaphoreAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando información de configuración de colores por carga de trabajo de las maquinas.");
                MachineWorkloadFlagConfigurationModel? result = await GetAsync<MachineWorkloadFlagConfigurationModel>($"insulations/machineworkloadconfiguration", cancellationToken)
                    .ConfigureAwait(false);
                if (result == null)
                {
                    throw new UserException("La orden no existe");
                }
                return result;
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar la información de asignaciones de maquinas.", "GetMachineMachineWorkloadFlagConfigurationsAsync");
            }
        }

        #endregion

        #region Queries

        public async Task<IEnumerable<InsulationMachineModel>> GetInsulationMachinesAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Consultando las maquinas CMS.");

                IEnumerable<InsulationMachineModel>? result = await GetAsync<IEnumerable<InsulationMachineModel>>($"insulations/machines", cancellationToken)
                    .ConfigureAwait(false);
                if (result == null)
                {
                    result = Enumerable.Empty<InsulationMachineModel>();
                }
                
                return result;
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar la información de las maquinas de aislamiento.", "InsulationMachines");
            }
        }

        public async Task<IEnumerable<OrderToManufacturingModel>> GetOrdersScheduledToManufactureAsync(DateTime utcDate, string machine, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando información de planes de fabricación en la maquina {machine} y fecha {utcDate}");
                IEnumerable<OrderToManufacturingModel>? result = await GetAsync<IEnumerable<OrderToManufacturingModel>, MachineAndUtcDateParameterModel>($"insulations/machinemanufacturingplan",
                    new MachineAndUtcDateParameterModel()
                    {
                        Machine = machine,
                        UtcDate = utcDate
                    },
                    cancellationToken)
                    .ConfigureAwait(false);
                if (result == null)
                {
                    result = Enumerable.Empty<OrderToManufacturingModel>();
                }
                return result;
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar la información de las maquinas de aislamiento.", "InsulationMachines");
            }
        }

        public async Task<IEnumerable<InsulationManufactureModel>> GetInsulationManufacturingOrdersAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando información de ordenes.");
                IEnumerable<InsulationManufactureModel>? result = await GetAsync<IEnumerable<InsulationManufactureModel>>($"insulations/manufactures",
                    cancellationToken)
                    .ConfigureAwait(false);
                if (result == null)
                {
                    result = Enumerable.Empty<InsulationManufactureModel>();
                }
                return result;
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar la información de las ordenes.", "InsulationManufacture");
            }
        }

        public async Task<IEnumerable<InsulationManufactureModel>> GetInsulationManufacturingOrdersInProgressAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando  las ordenes en ejecucion.");

                IEnumerable<InsulationManufactureModel>? result = await GetAsync<IEnumerable<InsulationManufactureModel>>($"insulations/ordersinprogress", cancellationToken)
                    .ConfigureAwait(false);

                if (result == null)
                {
                    result = Enumerable.Empty<InsulationManufactureModel>();
                }
                return result;
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar las ordenes en ejecucion.", "GetManufacturingOrdersInProgress");
            }
        }

        public async Task<InsulationManufactureModel?> GetManufacturingOrderAsync(string itemId, string batch, int serie, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando infromación de orden.");

                InsulationManufactureModel? result = await GetAsync<InsulationManufactureModel?>($"insulations/manufacturingorder/{itemId}/{batch}/{serie}", cancellationToken).ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar la información de la orden.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar la información de la orden.",
                    "GetManufacturingOrders");
            }
        }

        public async Task<IEnumerable<MachineAssignedOrdersModel>> GetMachineAssignedOrdersAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando información de asignaciones de maquinas.");
                IEnumerable<MachineAssignedOrdersModel>? result = await GetAsync<IEnumerable<MachineAssignedOrdersModel>>($"insulations/machineassignedorders", cancellationToken)
                    .ConfigureAwait(false);
                if (result == null)
                {
                    result = Enumerable.Empty<MachineAssignedOrdersModel>();
                }
                return result;
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar la información de asignaciones de maquinas.", "MachineAssignedOrdersAsync");
            }
        }

        public async Task<IEnumerable<OrderToManufacturingModel>> GetOrdersToManufactureAsync(DateTime utcDate, string machine, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando información de planes de fabricación en la maquina {machine} y fecha {utcDate}");
                IEnumerable<OrderToManufacturingModel>? result = await GetAsync<IEnumerable<OrderToManufacturingModel>, MachineAndUtcDateParameterModel>($"insulations/orderstomanufacture",
                    new MachineAndUtcDateParameterModel()
                    {
                        Machine = machine,
                        UtcDate = utcDate
                    },
                    cancellationToken)
                    .ConfigureAwait(false);
                if (result == null)
                {
                    result = Enumerable.Empty<OrderToManufacturingModel>();
                }
                return result;
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar la información de las maquinas de aislamiento.", "InsulationMachines");
            }
        }

        #endregion

        #region Manufacturing

        public async Task AddOrdersToManufacturingAsync(List<OrderToManufactureModel> orders)
        {
            try
            {
                logger.LogInformation($"Agregando ordenes a lista de fabricación.");

                await PostAsync($"insulations/addtomanufacturing", orders, CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                   $"No se pueden agregar ordenes a la lista de fabricación en este momento.",
                   "AddOrdersToManufacturing");
            }
        }

        public async Task AddRepairOrderAsync(string itemId, string batch, int quantity, int priority, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Agregando reparación de orden.");

                await PostAsync($"insulations/addrepairorder", new AddOrderToRepairParameterModel(itemId, batch, quantity, priority), cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede agregar la orden en reparación", "AddRepairOrder");
            }
        }

        public async Task StartOrderManufacturingAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Inicio de orden pediente por ejecutar.");

#pragma warning disable CA2016 // Forward the 'CancellationToken' parameter to methods
                await PostAsync($"insulations/startordermanufacturing")
#pragma warning restore CA2016 // Forward the 'CancellationToken' parameter to methods
                   .ConfigureAwait(false);

                logger.LogInformation($"Orden iniciada .");

            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                   $"No se puede iniciar la orden  en este momento.",
                   "StartOrderManufacturing");
            }
        }

        public async Task FinishOrderManufacturingAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Termina la  orden en ejecucion.");

#pragma warning disable CA2016 // Forward the 'CancellationToken' parameter to methods
                await PostAsync($"insulations/finishordermanufacturing")
#pragma warning restore CA2016 // Forward the 'CancellationToken' parameter to methods
                   .ConfigureAwait(false);

                logger.LogInformation($"Orden terminaada .");

            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                   $"No se puede terminar la orden en ejecucion.",
                   "EndOrderManufacturing");
            }
        }

        public async Task UpdateOrderManufacturingPriorityAsync(Guid id, int priority, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Actualización de prioridad de la orden: {id}.");

                await PostAsync($"insulations/changepriority", new UpdatePriorityParameterModel(id, priority), cancellationToken)
                    .ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede actualizar la prioridad de la orden {id}.", "changepriority");
            }
        }

        #endregion

        #region Materials

        public async Task<IEnumerable<CartonShearModel>> GetItemCartonShearsAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando información de los materiales de cizalla '{itemId}'.");

                return (await GetAsync<IEnumerable<CartonShearModel>>($"insulations/cartonShears/{itemId}", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<CartonShearModel>();
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar la información de los materiales de cizalla del artículo '{itemId}' en este momento.", "ItemCartonShears");
            }
        }

        public async Task<IEnumerable<GuillotineShearModel>> GetItemGuillotineShearsAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando información de los materiales de guillotina del artículo '{itemId}'.");

                return (await GetAsync<IEnumerable<GuillotineShearModel>>($"insulations/guillotineShears/{itemId}", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<GuillotineShearModel>();
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar la información de guillotina del artículo '{itemId}' en este momento.", "ItemGuillotineShears");
            }
        }

        public async Task<IEnumerable<SierraShearModel>> GetItemSierraShearsAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando información de los materiales de sierra del artículo '{itemId}'.");

                return (await GetAsync<IEnumerable<SierraShearModel>>($"insulations/sierraShears/{itemId}", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<SierraShearModel>();
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar la información de sierra del artículo '{itemId}' en este momento.", "ItemSierraShears");
            }
        }

        public async Task<AluminumTipPuntasModel?> GetItemAluminumTipsAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando información de los materiales de soldadura de puntas de alumunio del artículo '{itemId}'.");

                return await GetAsync<AluminumTipPuntasModel?>($"insulations/aluminumShears/{itemId}", cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar la información de soldadura de puntas de aluminio del artículo '{itemId}' en este momento.", "ItemAluminumTips");
            }
        }

        public async Task<IEnumerable<AluminiumCutModel>> GetItemAluminiumCutsAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando información de corte de puntas de aluminio del artículo '{itemId}'.");

                return (await GetAsync<IEnumerable<AluminiumCutModel>>($"insulations/aluminiumCuts/{itemId}", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<AluminiumCutModel>();
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar la información de corte de puntas de aluminio del artículo '{itemId}' en este momento.", "ItemAluminiumCuts");
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