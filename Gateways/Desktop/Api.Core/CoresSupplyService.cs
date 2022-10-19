namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Commands;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Queries;

    public class CoresSupplyService : ICoresSupplyService
    {
        #region Fields

        private readonly IServiceProvider serviceProvider;
        private readonly IMediator mediator;
        private readonly ILogger<CoresSupplyService> logger;

        #endregion

        #region Constructor

        public CoresSupplyService(
            IServiceProvider serviceProvider,
            IMediator mediator,
            ILogger<CoresSupplyService> logger)
        {
            this.serviceProvider = serviceProvider;
            this.mediator = mediator;
            this.logger = logger;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<MOManufacturingStatusModel>> GetManufacturingOrdersAvailableToSupplyAsync(DateTime date, string machine, CancellationToken cancellationToken)
        {
            try
            {
                return await mediator
                    .Send(new MOAvailableToSupplyQuery(date, machine), cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al consultar las ordenes planificadas para el día {utcDate} y maquina {machine} disponibles para suministrar.", date.ToString("G"), machine);
                }

                throw;
            }
        }

        public async Task AddOrdersToSupplyListAsync(List<OrderParameterModel> orders, CancellationToken cancellationToken)
        {
            try
            {
                await mediator
                    .Send(new AddOrderToSupplyListCommand(orders), cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al registrar las ordenes como disponibles para suministrar núcleos.");
                }
                throw;
            }
        }

        public async Task<IEnumerable<MOSupplyItemModel>> GetPendingSuppliesAsync(CancellationToken cancellationToken)
        {
            try
            {
                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                return (await cores.GetPendingSuppliesAsync(cancellationToken)
                    .ConfigureAwait(false))
                    .Select(e => new MOSupplyItemModel()
                    {
                        Id = e.Id,
                        ItemId = e.ItemId,
                        Batch = e.Batch,
                        Serie = e.Serie,
                        Sequence = e.Sequence,
                        ScheduleDate = e.ScheduleDate,
                        Machine = e.Machine,
                        ProductLine = e.ProductLine,
                        Phases = e.Phases,
                        Line = e.Line,
                        RegisterUtcDate = e.RegisterUtcDate
                    });
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al consultar las ordenes disponibles para suministrar núcleos.");
                }

                throw;
            }
        }

        public async Task<MOSupplyItemTagModel?> GetSupplyTagAsync(Guid manufacturingOrderId)
        {
            try
            {
                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                ControlPisoMX.Cores.Models.ManufacturingOrders.MOPrintableModel? supplyTag = await cores
                    .GetSupplyTagAsync(manufacturingOrderId)
                    .ConfigureAwait(false);

                if (supplyTag != null)
                {
                    return new MOSupplyItemTagModel()
                    {
                        ItemId = supplyTag.ItemId,
                        Batch = supplyTag.Batch,
                        Serie = supplyTag.Serie,
                        Sequence = supplyTag.Sequence,
                        ScheduledDate = supplyTag.ScheduledDate,
                        Machine = supplyTag.Machine,
                        ProductLine = supplyTag.ProductLine,
                        Line = supplyTag.Line,
                        Attributes = supplyTag.Attributes
                            .Select(e => new MOSupplyItemPrintableAttributeModel()
                            {
                                Attribute = e.Attribute,
                                Value = e.Value
                            })
                            .ToList()
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError("Ocurrió un error al consultar información para imprimir el suministro de orden con Id {id}", manufacturingOrderId);
                }

                throw;
            }
        }

        public async Task<MOSupplySummaryModel?> GetManufacturingOrderSupplySummary(string itemId, string batch)
        {
            try
            {
                return await mediator
                    .Send(new MOSupplySummaryQuery(itemId, batch), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al consultar las ordenes suministradas para el pedido {itemId}-{batch}.", itemId, batch);
                }

                throw;
            }
        }

        public async Task ConfirmSupplyAsync(string itemId, string batch, int serie)
        {
            try
            {
                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                await cores.ConfirmSupplyAsync(itemId, batch, serie).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al confirmar la orden '{itemId}-{batch}-{serie}'.", itemId, batch, serie);
                }

                throw;
            }
        }

        public async Task AuthorizeReprintAsync(string itemId, string batch, int serie)
        {
            try
            {
                await mediator
                    .Send(new AuthorizeReprintCommand(itemId, batch, serie), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al confirmar la orden '{itemId}-{batch}-{serie}'.", itemId, batch, serie);
                }

                throw;
            }
        }

        public async Task<IEnumerable<MOSupplyItemModel>> GetSuppliesToReprintAsync()
        {
            try
            {
                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                return (await cores.GetSuppliesToReprintAsync().ConfigureAwait(false))
                    .Select(e => new MOSupplyItemModel()
                    {
                        Id = e.Id,
                        ItemId = e.ItemId,
                        Batch = e.Batch,
                        Serie = e.Serie,
                        Sequence = e.Sequence,
                        ScheduleDate = e.ScheduleDate,
                        Machine = e.Machine,
                        ProductLine = e.ProductLine,
                        Phases = e.Phases,
                        Line = e.Line,
                        RegisterUtcDate = e.RegisterUtcDate
                    })
                    .ToArray();
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al consultar las ordenes autorizadas para reimprimir.");
                }

                throw;
            }
        }

        public async Task<SupplyCoreResultModel?> SupplyCoresAsync(string itemId, string batch, int serie, bool force, string user)
        {
            try
            {
                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                ControlPisoMX.Cores.Models.Residential.SupplyCoreResultModel? preview = (await cores.SupplyCoresAsync(itemId, batch, serie, force, user)
                    .ConfigureAwait(false));
                if (preview is not null)
                {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
                    return new SupplyCoreResultModel(preview.ItemId, preview.Batch, preview.Serie,
                        new SupplyCoresValidationModel(preview.SupplyValidationResult.Phases,
                            preview.SupplyValidationResult.CoreNumber, preview.SupplyValidationResult.Validation
                                .Select(e => new CoreValidationModel(e.CoreIndex, e.TestCode, e.Color, e.ColorSugetions)).ToList()
                               , preview.SupplyValidationResult.IsPhasesRuleValid, preview.SupplyValidationResult.IsCoreColorRuleValid,
                            preview.SupplyValidationResult.Accomplished, preview.SupplyValidationResult.Message),
                        new MOSupplyItemTagModel()
                        {
                            ItemId = preview.Printable.ItemId,
                            Batch = preview.Printable.Batch,
                            Serie = preview.Printable.Serie,
                            Sequence = preview.Printable.Sequence,
                            ScheduledDate = preview.Printable.ScheduledDate,
                            Machine = preview.Printable.Machine,
                            ProductLine = preview.Printable.ProductLine,
                            Line = preview.Printable.Line,
                            Attributes = preview.Printable.Attributes.Select(e => new MOSupplyItemPrintableAttributeModel()
                            { Attribute = e.Attribute, Value = e.Value }).ToList()
                        });
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al suministrar núcleos '{itemId}-{batch}-{serie}'.", itemId, batch, serie);
                }

                throw;
            }
        }
        public async Task<SupplyCoreResultModel?> SupplyCoresAsync_discpiso(string itemId, string batch, int serie, bool force, string user)
        {
            try
            {
                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                ControlPisoMX.Cores.Models.Residential.SupplyCoreResultModel? preview = (await cores.SupplyCoresAsync_discpiso(itemId, batch, serie, force, user)
                    .ConfigureAwait(false));
                if (preview is not null)
                {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
                    return new SupplyCoreResultModel(preview.ItemId, preview.Batch, preview.Serie,
                        new SupplyCoresValidationModel(preview.SupplyValidationResult.Phases,
                            preview.SupplyValidationResult.CoreNumber, preview.SupplyValidationResult.Validation
                                .Select(e => new CoreValidationModel(e.CoreIndex, e.TestCode, e.Color, e.ColorSugetions)).ToList()
                               , preview.SupplyValidationResult.IsPhasesRuleValid, preview.SupplyValidationResult.IsCoreColorRuleValid,
                            preview.SupplyValidationResult.Accomplished, preview.SupplyValidationResult.Message),
                        new MOSupplyItemTagModel()
                        {
                            ItemId = preview.Printable.ItemId,
                            Batch = preview.Printable.Batch,
                            Serie = preview.Printable.Serie,
                            Sequence = preview.Printable.Sequence,
                            ScheduledDate = preview.Printable.ScheduledDate,
                            Machine = preview.Printable.Machine,
                            ProductLine = preview.Printable.ProductLine,
                            Line = preview.Printable.Line,
                            Attributes = preview.Printable.Attributes.Select(e => new MOSupplyItemPrintableAttributeModel()
                            { Attribute = e.Attribute, Value = e.Value }).ToList()
                        });
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al suministrar núcleos '{itemId}-{batch}-{serie}'.", itemId, batch, serie);
                }

                throw;
            }
        }

        public async Task ReprintAsync(Guid manufacturingOrderId, string user)
        {
            try
            {
                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                await cores.ReprintAsync(manufacturingOrderId, user).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al registrar la reimpresión de la orden con id {id}'.", manufacturingOrderId);
                }

                throw;
            }
        }

        #endregion
    }
}