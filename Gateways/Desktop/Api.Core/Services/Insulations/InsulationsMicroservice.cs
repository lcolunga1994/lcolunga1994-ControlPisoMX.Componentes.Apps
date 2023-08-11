namespace ProlecGE.ControlPisoMX.Insulations.Api
{
    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.Insulations.Api.Models;
    using ProlecGE.ControlPisoMX.Insulations.Models;

    public class InsulationsMicroservice : Http.WebApiClient, IMicroservice
    {
        #region Fields

        private readonly ILogger<InsulationsMicroservice> logger;

        #endregion

        #region Constructor

        public InsulationsMicroservice(HttpClient httpClient,
            ILogger<InsulationsMicroservice> logger)
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
                logger.LogInformation($"Consultando el usuario");

                if (string.IsNullOrWhiteSpace(username))
                {
                    throw new UserException("La usuario es requerido.");
                }
#pragma warning disable CS8603 // Possible null reference return.
                return await GetAsync<string>($"insulations/getusername?username={username}&password={password}", CancellationToken.None).ConfigureAwait(false);
#pragma warning restore CS8603 // Possible null reference return.       
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar el usuario");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar el usuario",
                    "GetUser");
            }
        }

        public async Task<bool> ValidateUserPasswordAsync(string username, string password, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Validando el usuario");

                if (string.IsNullOrWhiteSpace(username))
                {
                    throw new UserException("La usuario es requerido.");
                }

                return await GetAsync<bool>($"insulations/validateuserpassword?username={username}&password={password}", CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al validar el usuario");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar el usuario",
                    "ValidatePassword");
            }
        }
        public async Task<bool> ValidateUserPasswordAsync_sqlctp(string username, string password, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Validando el usuario");

                if (string.IsNullOrWhiteSpace(username))
                {
                    throw new UserException("La usuario es requerido.");
                }

                return await GetAsync<bool>($"insulations/validateuserpassword_sqlctp?username={username}&password={password}", CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al validar el usuario");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar el usuario",
                    "ValidatePassword");
            }
        }

        #endregion

        #region Configurations

        public async Task<bool> IsManufacturingAllowedAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el estado de las labores.");

                bool result = await GetAsync<bool>($"insulations/ismanufacturingallowed", CancellationToken.None).ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar el estado de la labores");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar el estado de las labores",
                    "IsManufacturingAllowed");
            }
        }

        public async Task ChangeAllowManufacturingAsync(bool allow, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Ejecutando proceso suspender/reactivar labores");

#pragma warning disable CA2016 // Forward the 'CancellationToken' parameter to methods
                await PostAsync(url: $"insulations/changeallowmanufacturing?allow={allow.ToString().ToLower()}")
                    .ConfigureAwait(false);
#pragma warning restore CA2016 // Forward the 'CancellationToken' parameter to methods

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al suspender/reactivar labores.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede  suspender suspender/reactivar labores.",
                    "ChangesAllowManufacturing");
            }
        }
        public async Task ChangeAllowManufacturingAsync_sqlctp(bool allow, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Ejecutando proceso suspender/reactivar labores");

#pragma warning disable CA2016 // Forward the 'CancellationToken' parameter to methods
                await PostAsync(url: $"insulations/changeallowmanufacturing_sqlctp?allow={allow.ToString().ToLower()}")
                    .ConfigureAwait(false);
#pragma warning restore CA2016 // Forward the 'CancellationToken' parameter to methods

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al suspender/reactivar labores.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede  suspender suspender/reactivar labores.",
                    "ChangesAllowManufacturing");
            }
        }

        public async Task<int?> GetMinimumManufactureMinutesAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el minimo de minutos por orden.");

                int? result = await GetAsync<int?>("insulations/minimummanufactureminutes", cancellationToken).ConfigureAwait(false);

                if (result == null)
                {
                    logger.LogInformation($"El valor minimo de minutos por orden no se econtró.");
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar minimo de minutos por orden..");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar el minimo de minutos por orden..",
                    "GetMinimumManufactureMinutesAsync");
            }
        }

        public async Task<int> GetManufacturingMinutesAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando los minutos asignados por orden.");

                int result = await GetAsync<int>("insulations/manufactureminutes", cancellationToken).ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar los minutos por ordenes..");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar los minutos para ordenes..",
                    "GetManufacturingMinutesAsync");
            }
        }

        public async Task<bool> MachineCanPrintAsync(string machine, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando si la maquina puede imprimir.");

                bool result = await GetAsync<bool>($"insulations/machinecanprint/{machine}", CancellationToken.None).ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar si la maquina puede imprimir.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar si la maquina puede imprimir",
                    "GetMachineCanPrint");
            }
        }

        public async Task<MachineWorkloadFlagConfigurationModel> GetMachineWorkloadSemaphoreAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando configuración de colores para carga de trabajo de las maquinas.");

                MachineWorkloadFlagConfigurationModel? result = await GetAsync<MachineWorkloadFlagConfigurationModel>("insulations/machineworkloadconfiguration", cancellationToken).ConfigureAwait(false);

                if (result == null)
                {
                    throw new UserException("La orden no existe");
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar configuración de colores para carga de trabajo de las maquinas.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar la configuración de colores para carga de trabajo de las maquinas.",
                    "machineworkloadconfiguration");
            }
        }

        #endregion

        #region Queries

        public async Task<IEnumerable<InsulationMachineModel>> GetMachinesAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando las maquinas de aislamiento.");

                IEnumerable<InsulationMachineModel>? result = await GetAsync<IEnumerable<InsulationMachineModel>>("insulations/machines", CancellationToken.None).ConfigureAwait(false);

                if (result == null)
                {
                    return Enumerable.Empty<InsulationMachineModel>();
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar las maquinas de aislamiento.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar las maquinas de aislamiento en este momento.",
                    "Machines");
            }
        }
        public async Task<IEnumerable<InsulationMachineModel>> GetMachinesAsync_sqlctp(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando las maquinas de aislamiento.");

                IEnumerable<InsulationMachineModel>? result = await GetAsync<IEnumerable<InsulationMachineModel>>("insulations/machines_sqlctp", CancellationToken.None).ConfigureAwait(false);

                if (result == null)
                {
                    return Enumerable.Empty<InsulationMachineModel>();
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar las maquinas de aislamiento.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar las maquinas de aislamiento en este momento.",
                    "Machines");
            }
        }

        public async Task<IEnumerable<ManufacturingPlanItemModel>> GetManufacturingPlanByMachineAsync(DateTime date, string machine, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el plan de fabricación de la maquina {machine} en la fecha:{date:G}.");

                IEnumerable<ManufacturingPlanItemModel>? result =
                    await GetAsync<IEnumerable<ManufacturingPlanItemModel>, MachineManufacturingPlanModel>($"insulations/machinemanufacturingPlan",
                    new MachineManufacturingPlanModel()
                    {
                        Machine = machine,
                        Date = date
                    },
                    cancellationToken)
                    .ConfigureAwait(false);

                if (result == null)
                {
                    return Enumerable.Empty<ManufacturingPlanItemModel>();
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar el plan de fabricación de la maquina {machine} en la fecha:{date}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar el plan de fabricación de la maquina {machine} en este momento.",
                    "Machines");
            }
        }
        public async Task<IEnumerable<ManufacturingPlanItemModel>> GetManufacturingPlanByMachineAsync_sqlctp(DateTime date, string machine, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el plan de fabricación de la maquina {machine} en la fecha:{date:G}.");

                IEnumerable<ManufacturingPlanItemModel>? result =
                    await GetAsync<IEnumerable<ManufacturingPlanItemModel>, MachineManufacturingPlanModel>($"insulations/machinemanufacturingPlan_sqlctp",
                    new MachineManufacturingPlanModel()
                    {
                        Machine = machine,
                        Date = date
                    },
                    cancellationToken)
                    .ConfigureAwait(false);

                if (result == null)
                {
                    return Enumerable.Empty<ManufacturingPlanItemModel>();
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar el plan de fabricación de la maquina {machine} en la fecha:{date}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar el plan de fabricación de la maquina {machine} en este momento.",
                    "Machines");
            }
        }

        public async Task<ManufacturingPlanItemModel?> GetManufacturingPlanBySerieAsync(string itemId, string batch, int serie, int sequence, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Consultando el plan de fabricación para la orden '{itemId}, {batch}-{serie}.", itemId, batch, serie);

                return await GetAsync<ManufacturingPlanItemModel, OrderModel>($"insulations/seriemanufacturingplan",
                        new OrderModel()
                        {
                            ItemId = itemId,
                            Batch = batch,
                            Serie = serie,
                            Sequence = sequence
                        },
                        cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar el plan de fabricación para la orden '{itemId}, {batch}-{serie}.", itemId, batch, serie);

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar el plan de fabricación para la orden '{itemId}, {batch}-{serie}. en este momento.",
                    "ManufacturingPlanBySerie");
            }
        }
        public async Task<ManufacturingPlanItemModel?> GetManufacturingPlanBySerieAsync_sqlctp(string itemId, string batch, int serie, int sequence, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Consultando el plan de fabricación para la orden '{itemId}, {batch}-{serie}.", itemId, batch, serie);

                return await GetAsync<ManufacturingPlanItemModel, OrderModel>($"insulations/seriemanufacturingplan_sqlctp",
                        new OrderModel()
                        {
                            ItemId = itemId,
                            Batch = batch,
                            Serie = serie,
                            Sequence = sequence
                        },
                        cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar el plan de fabricación para la orden '{itemId}, {batch}-{serie}.", itemId, batch, serie);

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar el plan de fabricación para la orden '{itemId}, {batch}-{serie}. en este momento.",
                    "ManufacturingPlanBySerie");
            }
        }

        public async Task<IEnumerable<ManufacturingItemModel>> GetManufacturingOrdersAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando de ordenes.");

                IEnumerable<ManufacturingItemModel>? result = await GetAsync<IEnumerable<ManufacturingItemModel>>("insulations/manufactures", cancellationToken).ConfigureAwait(false);

                if (result == null)
                {
                    return Enumerable.Empty<ManufacturingItemModel>();
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar las ordenes.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar las ordenes.",
                    "InsulationManufacture");
            }
        }

        public async Task<IEnumerable<ManufacturingItemModel>> GetManufacturingOrdersInProgressAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando de ordenes.");

                IEnumerable<ManufacturingItemModel>? result = await GetAsync<IEnumerable<ManufacturingItemModel>>("insulations/ordersinprogress", cancellationToken).ConfigureAwait(false);

                if (result == null)
                {
                    return Enumerable.Empty<ManufacturingItemModel>();
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar las ordenes.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar las ordenes.",
                    "GetManufacturingOrdersInProgress");
            }
        }

        public async Task<ManufacturingItemModel?> GetManufacturingOrderAsync(string itemId, string batch, int serie, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando infromación de orden.");

                ManufacturingItemModel? result = await GetAsync<ManufacturingItemModel>($"insulations/manufacturingorder/{itemId}/{batch}/{serie}", cancellationToken).ConfigureAwait(false);

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
                logger.LogInformation($"Consultando el numero de ordenes por maquina.");

                IEnumerable<MachineAssignedOrdersModel>? result = await GetAsync<IEnumerable<MachineAssignedOrdersModel>>("insulations/machineassignedorders", cancellationToken)
                    .ConfigureAwait(false);

                if (result == null)
                {
                    return Enumerable.Empty<MachineAssignedOrdersModel>();
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar número de ordenes por maquina..");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar el número de ordenes por maquina..",
                    "GetMachineAssignedOrdersAsync");
            }
        }

        public async Task<IEnumerable<ManufacturingPlanItemModel>> GetOrdersToManufactureAsync(DateTime date, string machine, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el plan de fabricación de la maquina {machine} en la fecha:{date:G}.");

                IEnumerable<ManufacturingPlanItemModel>? result =
                    await GetAsync<IEnumerable<ManufacturingPlanItemModel>, MachineManufacturingPlanModel>($"insulations/orderstomanufacture",
                    new MachineManufacturingPlanModel()
                    {
                        Machine = machine,
                        Date = date
                    },
                    cancellationToken)
                    .ConfigureAwait(false);

                if (result == null)
                {
                    return Enumerable.Empty<ManufacturingPlanItemModel>();
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar el plan de fabricación de la maquina {machine} en la fecha:{date}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar el plan de fabricación de la maquina {machine} en este momento.",
                    "OrdersToManufacture");
            }
        }
        public async Task<IEnumerable<ManufacturingPlanItemModel>> GetOrdersToManufactureAsync_sqlctp(DateTime date, string machine, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el plan de fabricación de la maquina {machine} en la fecha:{date:G}.");

                IEnumerable<ManufacturingPlanItemModel>? result =
                    await GetAsync<IEnumerable<ManufacturingPlanItemModel>, MachineManufacturingPlanModel>($"insulations/orderstomanufacture_sqlctp",
                    new MachineManufacturingPlanModel()
                    {
                        Machine = machine,
                        Date = date
                    },
                    cancellationToken)
                    .ConfigureAwait(false);

                if (result == null)
                {
                    return Enumerable.Empty<ManufacturingPlanItemModel>();
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar el plan de fabricación de la maquina {machine} en la fecha:{date}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar el plan de fabricación de la maquina {machine} en este momento.",
                    "OrdersToManufacture");
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
                logger.LogError(ex, $"Ocurrió un error al agregar ordenes a la lista de fabricación.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden agregar ordenes a la lista de fabricación en este momento.",
                    "AddOrdersToManufacturing");
            }
        }
        public async Task AddOrdersToManufacturingAsync_sqlctp(List<OrderToManufactureModel> orders)
        {
            try
            {
                logger.LogInformation($"Agregando ordenes a lista de fabricación.");

                await PostAsync($"insulations/addtomanufacturing_sqlctp", orders, CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al agregar ordenes a la lista de fabricación.");

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
                logger.LogInformation($"Agregando orden a reparar.");

                await PostAsync($"insulations/addrepairorder", new OrderToRepairModel(itemId, batch, quantity, priority), cancellationToken).ConfigureAwait(false);


            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al agregar orden a reparar.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede agregar orden a reparar.",
                    "AddRepairOrder");
            }
        }
        public async Task AddRepairOrderAsync_sqlctp(string itemId, string batch, int quantity, int priority, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Agregando orden a reparar.");

                await PostAsync($"insulations/addrepairorder_sqlctp", new OrderToRepairModel(itemId, batch, quantity, priority), cancellationToken).ConfigureAwait(false);


            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al agregar orden a reparar.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede agregar orden a reparar.",
                    "AddRepairOrder");
            }
        }

        public async Task StartOrderManufacturingAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Iniciando la orden pendiente.");

#pragma warning disable CA2016 // Forward the 'CancellationToken' parameter to methods
                await PostAsync($"insulations/startordermanufacturing")
                    .ConfigureAwait(false);
#pragma warning restore CA2016 // Forward the 'CancellationToken' parameter to methods
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al iniciar la orden pendiente.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar al iniciar la orden pendiente",
                    "StarOrderManufacturing");
            }
        }
        public async Task StartOrderManufacturingAsync_sqlctp(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Iniciando la orden pendiente.");

#pragma warning disable CA2016 // Forward the 'CancellationToken' parameter to methods
                await PostAsync($"insulations/startordermanufacturing_sqlctp")
                    .ConfigureAwait(false);
#pragma warning restore CA2016 // Forward the 'CancellationToken' parameter to methods
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al iniciar la orden pendiente.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar al iniciar la orden pendiente",
                    "StarOrderManufacturing");
            }
        }

        public async Task FinishOrderManufacturingAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Terminando la orden en ejecucion.");

#pragma warning disable CA2016 // Forward the 'CancellationToken' parameter to methods
                await PostAsync($"insulations/finishordermanufacturing")
                    .ConfigureAwait(false);
#pragma warning restore CA2016 // Forward the 'CancellationToken' parameter to methods
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al terminar la orden en ejecucion.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede terminar la orden en ejecucion",
                    "EndOrderManufacturing");
            }
        }
        public async Task FinishOrderManufacturingAsync_sqlctp(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Terminando la orden en ejecucion.");

#pragma warning disable CA2016 // Forward the 'CancellationToken' parameter to methods
                await PostAsync($"insulations/finishordermanufacturing_sqlctp")
                    .ConfigureAwait(false);
#pragma warning restore CA2016 // Forward the 'CancellationToken' parameter to methods
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al terminar la orden en ejecucion.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede terminar la orden en ejecucion",
                    "EndOrderManufacturing");
            }
        }

        public async Task UpdateOrderManufacturingPriorityAsync(Guid id, int priority, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Actualizando prioridad de la orden {id}.");

                await PostAsync($"insulations/changepriority", new UpdatePriorityModel(id, priority), cancellationToken)
                    .ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al actualizar la prioridad del plan de fabricación de la orden {id}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede  actualizar la prioridad del plan de fabricación {id} en este momento.",
                    "AddOrderToManufacturing");
            }
        }
        public async Task UpdateOrderManufacturingPriorityAsync_sqlctp(Guid id, int priority, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Actualizando prioridad de la orden {id}.");

                await PostAsync($"insulations/changepriority_sqlctp", new UpdatePriorityModel(id, priority), cancellationToken)
                    .ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al actualizar la prioridad del plan de fabricación de la orden {id}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede  actualizar la prioridad del plan de fabricación {id} en este momento.",
                    "AddOrderToManufacturing");
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