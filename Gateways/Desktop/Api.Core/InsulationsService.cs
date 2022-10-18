namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Insulations;
    using Insulations.Models;
    using Insulations.Queries;

    using MediatR;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class InsulationsService : IInsulationsService
    {
        #region Fields

        private readonly ILogger<InsulationsService> logger;
        private readonly IServiceProvider serviceProvider;
        private readonly IMediator mediator;

        #endregion

        #region Constructor

        public InsulationsService(
            ILogger<InsulationsService> logger,
            IServiceProvider serviceProvider,
            IMediator mediator)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            this.mediator = mediator;
        }

        #endregion

        #region Security

        public async Task<string> GetUserAsync(string username, string password, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el usuario.");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();

                return await insulations.GetUserAsync(username, password, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al tratar de consultar el usuario");
                throw;
            }
        }

        public async Task<bool> ValidateUserPasswordAsync(string username, string password, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Validando usuario.");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();

                return await insulations.ValidateUserPasswordAsync(username, password, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al tratar de validar el usuario");
                throw;
            }
        }

        #endregion

        #region Configurations

        public async Task<bool> IsManufacturingAllowedAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el estado de las labores");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();

                return await insulations.IsManufacturingAllowedAsync(cancellationToken).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar el estado de la labores");
                throw;
            }
        }

        public async Task ChangeAllowManufacturingAsync(bool allow, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Suspendiendo/iniciar labores.");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();

                await insulations.ChangeAllowManufacturingAsync(allow, cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al tratar  de suspender/iniciar labores");
                throw;
            }
        }

        public async Task<int?> GetMinimumManufactureMinutesAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando minutos minimos por orden.");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();

                int? minutes = await insulations.GetMinimumManufactureMinutesAsync(cancellationToken)
                    .ConfigureAwait(false);

                if (minutes == null)
                {
                    logger.LogInformation($"No se encontró el minimo de minutos por orden.");
                }

                return minutes;
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar el minimo de minutos por orden.");
                throw;
            }
        }

        public async Task<int> GetManufacturingMinutesAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando minutos asignados para ordenes.");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();

                int minutes = await insulations.GetManufacturingMinutesAsync(cancellationToken)
                    .ConfigureAwait(false);

                return minutes;
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar de minutos asignados por ordenes.");
                throw;
            }
        }

        public async Task<bool> MachineCanPrintAsync(string machine, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando si la maquina puede imprimir");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();

                return await insulations.MachineCanPrintAsync(machine, cancellationToken).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar si la maquina puede imprimir.");
                throw;
            }
        }

        public async Task<MachineWorkloadFlagConfigurationModel> GetMachineWorkloadSemaphoreAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando de configuración de colores de carga de trabajo de las maquinas.");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();

                ProlecGE.ControlPisoMX.Insulations.Models.MachineWorkloadFlagConfigurationModel? config = await insulations.GetMachineWorkloadSemaphoreAsync(cancellationToken)
                    .ConfigureAwait(false);

                MachineWorkloadFlagConfigurationModel configurations = new(config.NormalColor
                    , config.WarningColor,
                    config.CriticalColor,
                    config.LockedColor,
                    config.HighLevel,
                    config.LowLevel);

                return configurations;
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar la configuración de colores de carga de trabajo de las maquinas.");
                throw;
            }
        }

        #endregion

        #region Queries

        public async Task<IEnumerable<InsulationMachineModel>> GetInsulationMachinesAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando maquinas de aislamiento.");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();

                return (await insulations.GetMachinesAsync(cancellationToken)
                    .ConfigureAwait(false))
                    .Select(e => new InsulationMachineModel(e.Number, e.Available))
                    .ToArray();
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar maquinas de aislamiento.");
                throw;
            }
        }

        public async Task<IEnumerable<OrderToManufacturingModel>> GetOrdersScheduledToManufactureAsync(DateTime utcDate, string machine, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando planes de fabricación en la maquina {machine} y fecha {utcDate:G}.");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();
                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                IEnumerable<ProlecGE.ControlPisoMX.Insulations.Models.ManufacturingPlanItemModel> scheduledOrders = await insulations
                    .GetManufacturingPlanByMachineAsync(utcDate, machine, cancellationToken)
                    .ConfigureAwait(false);

                List<OrderToManufacturingModel> result = new();

                OrderToManufacturingModel orderModel;

                foreach (ProlecGE.ControlPisoMX.Insulations.Models.ManufacturingPlanItemModel scheduledOrder in scheduledOrders)
                {
                    orderModel = new OrderToManufacturingModel(scheduledOrder.ItemId,
                        scheduledOrder.Batch,
                        scheduledOrder.Serie,
                        scheduledOrder.Sequence);

                    ControlPisoMX.Cores.Models.Residential.ResidentialCoreTestModel? coreTestResult = await cores
                        .GetResidentialCoreTestByOrder(scheduledOrder.ItemId, scheduledOrder.Batch, scheduledOrder.Serie, scheduledOrder.Sequence);

                    if (coreTestResult != null)
                    {
                        orderModel.CoreTestColor = coreTestResult.Color.ToLimitColorValue();
                    }

                    result.Add(orderModel);
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar planes de fabricación en la maquina {machine} y fecha {utcDate:G}.");
                throw;
            }
        }

        public async Task<IEnumerable<InsulationManufactureModel>> GetInsulationManufacturingOrdersAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando las ordenes.");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();

                return (await insulations.GetManufacturingOrdersAsync(cancellationToken).ConfigureAwait(false))
                    .Select(e => new InsulationManufactureModel(e.Id, e.ItemId, e.Batch, e.Quantity, e.Serie, e.Sequence, e.Machine, e.RequestUtcDate, e.Priority, e.Status, e.Dimensions))
                    .ToArray();
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar las ordenes.");
                throw;
            }
        }

        public async Task<IEnumerable<InsulationManufactureModel>> GetInsulationManufacturingOrdersInProgressAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando ordenes en ejecucion..");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();

                return (await insulations.GetManufacturingOrdersInProgressAsync(cancellationToken).ConfigureAwait(false)).Select(e =>
                     new InsulationManufactureModel(e.Id, e.ItemId, e.Batch, e.Quantity, e.Serie, e.Sequence, e.Machine, e.RequestUtcDate, e.Priority, e.Status, e.Dimensions))
                      .ToArray();

            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar ordenes en ejecucion.");
                throw;
            }
        }

        public async Task<InsulationManufactureModel?> GetManufacturingOrderAsync(string itemId, string batch, int serie, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando información de orden.");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();

                ProlecGE.ControlPisoMX.Insulations.Models.ManufacturingItemModel? result = (await insulations.GetManufacturingOrderAsync(itemId, batch, serie, cancellationToken).ConfigureAwait(false));

                if (result is null)
                {
                    return null;
                }

                return new InsulationManufactureModel(result.Id, result.ItemId, result.Batch, result.Quantity, result.Serie, result.Sequence,
                    result.Machine, result.RequestUtcDate, result.Priority, result.Status, result.Dimensions);

            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar información de orden.");
                throw;
            }
        }

        public async Task<IEnumerable<MachineAssignedOrdersModel>> GetMachineAssignedOrdersAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando asignación por maquina.");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();

                IEnumerable<InsulationMachineModel> machines = (await insulations.GetMachinesAsync(cancellationToken)
                    .ConfigureAwait(false))
                    .Select(e => new InsulationMachineModel(e.Number, e.Available))
                    .ToArray();

                IEnumerable<MachineAssignedOrdersModel> assignations = (await insulations.GetMachineAssignedOrdersAsync(cancellationToken)
                    .ConfigureAwait(false))
                    .Select(e => new MachineAssignedOrdersModel(e.Number, e.Summary, true))
                    .ToArray();

                List<MachineAssignedOrdersModel> result = machines.GroupJoin(
                    assignations,
                    outerKeySelector => outerKeySelector.Number,
                    innerKeySelector => innerKeySelector.Number,
                    (machine, collection) => new MachineAssignedOrdersModel(machine.Number,
                            collection.Select(e => e.Summary).Sum(),
                            machine.Available)).ToList();

                logger.LogInformation($"Termina consulta asignación por maquina.");

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar asignación por maquina.");
                throw;
            }
        }

        public async Task<IEnumerable<OrderToManufacturingModel>> GetOrdersToManufactureAsync(DateTime utcDate, string machine, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando planes de fabricación en la maquina {machine} y fecha {utcDate}.");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();
                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                IEnumerable<ProlecGE.ControlPisoMX.Insulations.Models.ManufacturingPlanItemModel> scheduledOrders = await insulations
                    .GetOrdersToManufactureAsync(utcDate, machine, cancellationToken)
                    .ConfigureAwait(false);

                List<OrderToManufacturingModel> result = new();

                OrderToManufacturingModel orderModel;

                foreach (ProlecGE.ControlPisoMX.Insulations.Models.ManufacturingPlanItemModel scheduledOrder in scheduledOrders)
                {
                    orderModel = new OrderToManufacturingModel(scheduledOrder.ItemId,
                        scheduledOrder.Batch,
                        scheduledOrder.Serie,
                        scheduledOrder.Sequence);

                    ControlPisoMX.Cores.Models.Residential.ResidentialCoreTestModel? coreTestResult = await cores
                        .GetResidentialCoreTestByOrder(scheduledOrder.ItemId, scheduledOrder.Batch, scheduledOrder.Serie, scheduledOrder.Sequence);

                    if (coreTestResult != null)
                    {
                        orderModel.CoreTestColor = coreTestResult.Color.ToLimitColorValue();
                    }

                    result.Add(orderModel);
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar planes de fabricación en la maquina {machine} y fecha {utcDate}.");
                throw;
            }
        }


        #endregion

        #region Manufacturing

        public async Task AddOrdersToManufacturingAsync(List<OrderToManufactureModel> orders)
        {
            try
            {
                List<ProlecGE.ControlPisoMX.Insulations.Models.OrderToManufactureModel> insulationOrders = new();
                ControlPisoMX.ERP.IMicroservice erp = serviceProvider.GetRequiredService<ControlPisoMX.ERP.IMicroservice>();

                foreach (OrderToManufactureModel order in orders)
                {
                    logger.LogInformation($"Agregando plan de fabricación con articulo: {order.ItemId}, lote: {order.Batch}, serie:{order.Serie}, secuncia:{order.Sequence}.");
                    string? dimentions = await erp.GetItemDimensionsAsync(order.ItemId, CancellationToken.None).ConfigureAwait(false);
                    insulationOrders.Add(new ProlecGE.ControlPisoMX.Insulations.Models.OrderToManufactureModel(order.ItemId, order.Batch, order.Serie, order.Sequence, dimentions));
                }

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();

                await insulations.AddOrdersToManufacturingAsync(insulationOrders).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al agregar ordenes a la lista de fabricación.");
                throw;
            }
        }

        public async Task AddRepairOrderAsync(string itemId, string batch, int quantity, int priority, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando información de validaciones para agregar orden a reparar.");

                ControlPisoMX.ERP.IMicroservice erpMicroservice = serviceProvider.GetRequiredService<ControlPisoMX.ERP.IMicroservice>();
                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();

                ControlPisoMX.ERP.Models.ManufacturingOrderModel? manufacturingOrder = await erpMicroservice.GetManufacturingOrderAsync(itemId, batch, cancellationToken);
                if (manufacturingOrder == null)
                {
                    throw new UserException($"No existe una orden de fabricación para el artículo {itemId} y lote {batch}.");
                }
                else if (manufacturingOrder.Status > 4)
                {
                    throw new UserException("El estatus actual de la orden de fabricación ya no permite realizar reparaciones.");
                }

                bool orderExistsInManufacturingPlan = await erpMicroservice.GetManufacturingProgramValidationAsync(itemId, batch, cancellationToken);
                if (!orderExistsInManufacturingPlan)
                {
                    throw new UserException("La orden no está registrada en el programa de fabricación. Revise el código de la orden y el consecutivo.");
                }

                await insulations.AddRepairOrderAsync(itemId, batch, quantity, priority, cancellationToken);

            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar la información de validaciones para agregar orden a reparar.");
                throw;
            }
        }

        public async Task StartOrderManufacturingAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Iniciando orden pendiente por ejecutar.");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();
                ControlPisoMX.ERP.IMicroservice erp = serviceProvider.GetRequiredService<ControlPisoMX.ERP.IMicroservice>();


                await insulations.StartOrderManufacturingAsync(CancellationToken.None)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex, "Ocurrió un error al iniciar la orden.");
                throw;
            }
        }

        public async Task UpdateOrderManufacturingPriorityAsync(Guid id, int priority, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Actualizando prioridad de orden: {id}.");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();



                await insulations.UpdateOrderManufacturingPriorityAsync(id, priority, cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al tratar  de actualizar la prioridad de la orden: {id}");
                throw;
            }
        }

        public async Task FinishOrderManufacturingAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Terminando orden pendiente por ejecutar.");

                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();
                ControlPisoMX.ERP.IMicroservice erp = serviceProvider.GetRequiredService<ControlPisoMX.ERP.IMicroservice>();


                await insulations.FinishOrderManufacturingAsync(CancellationToken.None)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex, "Ocurrió un error al terminar la orden.");
                throw;
            }
        }

        #endregion

        #region Materials

        public async Task<IEnumerable<CartonShearModel>> GetItemCartonShearsAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando información de los materiales de cizalla '{itemId}'.");

                return await mediator.Send(new CartonShearsQuery(itemId), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar los materiales de cizalla:{itemId}.");
                throw;
            }
        }

        public async Task<IEnumerable<GuillotineShearModel>> GetItemGuillotineShearsAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando información de los materiales de guillotina '{itemId}'.");

                return await mediator.Send(new GuillotineShearsQuery(itemId), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar los materiales de guillotina: {itemId}.");
                throw;
            }
        }

        public async Task<IEnumerable<SierraShearModel>> GetItemSierraShearsAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando información de los materiales de sierra '{itemId}'.");

                return await mediator.Send(new SierraShearsQuery(itemId), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar los materiales de sierra:{itemId}.");
                throw;
            }
        }

        public async Task<AluminumTipPuntasModel?> GetItemAluminumTipsAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando información de los materiales de cizalla '{itemId}'.");

                return await mediator.Send(new ItemAluminumTipsQuery(itemId), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar los materiales de cizalla:{itemId}.");
                throw;
            }
        }

        public async Task<IEnumerable<AluminiumCutModel>> GetItemAluminiumCutsAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando información de los cortes de puntas de aluminio '{itemId}'.");

                return await mediator.Send(new AluminiumCutsQuery(itemId), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar de los cortes de puntas de aluminio:{itemId}.");
                throw;
            }
        }

        #endregion
    }
}