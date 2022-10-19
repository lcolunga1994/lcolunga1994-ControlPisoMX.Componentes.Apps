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
    using ProlecGE.ControlPisoMX.BFWeb.Components.InspectionCMS.Models;
    using ProlecGE.ControlPisoMX.BFWeb.Components.InspectionCMS.Queries;

    internal class InspectionCMService : IInspectionCMService
    {
        #region Fields

        private readonly ILogger<InspectionCMService> logger;
        private readonly IServiceProvider serviceProvider;
        private readonly IMediator mediator;

        #endregion

        #region Constructor

        public InspectionCMService(
            ILogger<InspectionCMService> logger,
            IServiceProvider serviceProvider,
            IMediator mediator)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            this.mediator = mediator;
        }

        #endregion

        #region Winding

        public async Task<IEnumerable<WindingModel>> GetItemWindingAsync(string itemId)
        {
            try
            {
                return await mediator.Send(new ItemWindingQuery(itemId), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, $"Ocurrió un error al consultar la información de devenado para el artículo:{itemId}.");
                }

                throw;
            }
        }

        #endregion

        #region ArmingAndConnecing

        public async Task<IEnumerable<ArmingAndConnectingModel>> GetArmingAndConnectingAsync(string itemId)
        {
            try
            {
                return await mediator.Send(new ItemArmingAndConnectingQuery(itemId), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, $"Ocurrió un error al consultar la información de devenado para el artículo:{itemId}.");
                }

                throw;
            }
        }

        #endregion

        #region Insulation

        public async Task<IEnumerable<InsulationModel>> GetItemInsulationAsync(string itemId)
        {
            try
            {
                return await mediator.Send(new InsulationQuery(itemId), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, $"Ocurrió un error al consultar la información de aislamientos para el artículo:{itemId}.");
                }

                throw;
            }
        }

        #endregion

        #region Clamp

        public async Task<ClampModel?> GetItemClampAsync(string itemId)
        {
            try
            {
                return await mediator.Send(new ClampQuery(itemId), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, $"Ocurrió un error al consultar la información de Herrajes para el artículo:{itemId}.");
                }

                throw;
            }
        }

        #endregion

        #region LVConneting(ConectadoBT)

        public async Task<LVConnetingModel?> GetItemLVConnetingAsync(string itemId)
        {
            try
            {
                return await mediator.Send(new ItemLVConnectingQuery(itemId), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, $"Ocurrió un error al consultar la información de Conectado BT para el artículo:{itemId}.");
                }

                throw;
            }
        }

        #endregion

        #region Laboratory

        public async Task<IEnumerable<LaboratoryModel>> GetItemLaboratoryAsync(string itemId)
        {
            try
            {
                return await mediator.Send(new ItemLaboratoryQuery(itemId), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, $"Ocurrió un error al consultar la información de Conectado BT para el artículo:{itemId}.");
                }

                throw;
            }
        }

        #endregion

        #region LVConnector

        public async Task<IEnumerable<LVConnectorModel>> GetItemLVConnectorAsync(string itemId)
        {
            try
            {
                ERP.IMicroservice erp = serviceProvider.GetRequiredService<ERP.IMicroservice>();

                return (await erp.GetLVConnectorAsync(itemId).ConfigureAwait(false))
                    .Select(e => new LVConnectorModel { ItemId = e.ItemId, Description = e.Description })
                    .ToArray();
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, $"Ocurrió un error al consultar la información de Conector BT para el artículo:{itemId}.");
                }

                throw;
            }
        }

        #endregion

        #region AcceptInspection

        public async Task AcceptInspectionAsync(string itemId, string batch, int serie, string user)
        {
            try
            {
                ControlPisoMX.InspectionCMS.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.InspectionCMS.IMicroservice>();

                await cores.AcceptInspectionAsync(itemId, batch, serie, user).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al aceptar la inspección para la orden:{itemId}-{batch}-{serie}.", itemId, batch, serie);
                }

                throw;
            }
        }
        public async Task AcceptInspectionAsync_discpiso(string itemId, string batch, int serie, string user)
        {
            try
            {
                ControlPisoMX.InspectionCMS.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.InspectionCMS.IMicroservice>();

                await cores.AcceptInspectionAsync_discpiso(itemId, batch, serie, user).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al aceptar la inspección para la orden:{itemId}-{batch}-{serie}.", itemId, batch, serie);
                }

                throw;
            }
        }

        #endregion

        #region RejectInspection

        public async Task RejectInspectionAsync(string itemId, string batch, int serie, string machine, string user, string card, string code, CancellationToken cancellationToken)
        {
            try
            {
                ControlPisoMX.InspectionCMS.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.InspectionCMS.IMicroservice>();
                await cores.RejectInspectionAsync(itemId, batch, serie, machine, user, card, code, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, $"Ocurrió un error al rechazar la inspección:{itemId}-{batch}-{serie}.");
                }

                throw;
            }
        }
        public async Task RejectInspectionAsync_discpiso(string itemId, string batch, int serie, string machine, string user, string card, string code, CancellationToken cancellationToken)
        {
            try
            {
                ControlPisoMX.InspectionCMS.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.InspectionCMS.IMicroservice>();
                await cores.RejectInspectionAsync_discpiso(itemId, batch, serie, machine, user, card, code, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, $"Ocurrió un error al rechazar la inspección:{itemId}-{batch}-{serie}.");
                }

                throw;
            }
        }


        public async Task<LastRejectedModel?> LastRejectedAsync(string itemId, string batch, int serie, string code)
        {
            try
            {
                ControlPisoMX.InspectionCMS.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.InspectionCMS.IMicroservice>();

                var result = (await cores.LastRejectedAsync(itemId, batch, serie, code).ConfigureAwait(false));
                if (result is not null)
                {
                    LastRejectedModel lastRejectedModel = new(result.RejectDate, result.Description);
                    return lastRejectedModel;
                }
                else
                {
                    throw new UserException($"No se encontró información relacionada al rechazo {itemId}-{batch}-{serie}-{code}");
                }
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, $"Ocurrió un error al consultar la información de rechazo para la orden:{itemId}-{batch}-{serie}-{code}.");
                }

                throw;
            }
        }
        #endregion

        #region OrderExists

        public async Task<bool> OrderExistsAsync(string itemId, string batch, int serie)
        {
            try
            {
                ControlPisoMX.InspectionCMS.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.InspectionCMS.IMicroservice>();

                return await cores.OrderExistsAsync(itemId, batch, serie).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, $"Ocurrió un error al consultar la información para la orden:{itemId}-{batch}-{serie}.");
                }

                throw;
            }
        }
        public async Task<bool> OrderExistsAsync_discpiso(string itemId, string batch, int serie)
        {
            try
            {
                ControlPisoMX.InspectionCMS.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.InspectionCMS.IMicroservice>();

                return await cores.OrderExistsAsync_discpiso(itemId, batch, serie).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, $"Ocurrió un error al consultar la información para la orden:{itemId}-{batch}-{serie}.");
                }

                throw;
            }
        }

        #endregion
    }
}
