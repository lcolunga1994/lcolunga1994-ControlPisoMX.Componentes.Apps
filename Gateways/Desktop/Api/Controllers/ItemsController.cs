namespace ProlecGE.ControlPisoMX.BFWeb.Components.Api.Controllers
{
    using Insulations.Models;

    using Microsoft.AspNetCore.Mvc;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    [Route("api/v1/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        #region Fields

        private readonly IResidentialCoresService service;
        private readonly IInsulationsService gateway;

        #endregion

        #region Constructor

        public ItemsController(IResidentialCoresService service, IInsulationsService gateway)
        {
            this.service = service;
            this.gateway = gateway;
        }

        #endregion

        #region Endpoints

        [Route("{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(ItemModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ItemModel?>> Item([Required][StringLength(47)] string itemId)
        {
            ItemModel? design = await service.GetItemAsync(itemId).ConfigureAwait(false);

            return design == null ? NotFound() : Ok(design);
        }

        [Obsolete("Use el controlador CoresResidentialV2Controller.")]
        [Route("design/voltage/{itemId}/{coreSize}")]
        [HttpGet]
        [ProducesResponseType(typeof(CoreVoltageDesignModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CoreVoltageDesignModel>> GetCoreVoltageDesign(
            string itemId,
            Cores.CoreSizes coreSize)
        {
            CoreVoltageDesignModel? design = await service
                .GetResidentialCoreVoltageDesignAsync(
                    itemId,
                    (int)coreSize,
                    CancellationToken.None)
                .ConfigureAwait(false);

            return design == null ? NotFound() : Ok(design);
        }

        #endregion

        #region Insulations Obsolete

        [Obsolete("Use el controlador InsulationsController.")]
        [Route("cartonShears/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CartonShearModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CartonShearModel>>> GetItemCartonShearsAsync(
            string itemId)
        {
            IEnumerable<CartonShearModel> materials = await gateway
                .GetItemCartonShearsAsync(
                    itemId,
                    CancellationToken.None)
                .ConfigureAwait(false);

            return materials == null ? NotFound() : Ok(materials);
        }

        [Obsolete("Use el controlador InsulationsController.")]
        [Route("guillotineShears/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GuillotineShearModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GuillotineShearModel>>> GetItemGuillotineShearsAsync(
          string itemId)
        {
            IEnumerable<GuillotineShearModel> materials = await gateway
                .GetItemGuillotineShearsAsync(
                    itemId,
                    CancellationToken.None)
                .ConfigureAwait(false);

            return materials == null ? NotFound() : Ok(materials);
        }

        [Obsolete("Use el controlador InsulationsController.")]
        [Route("sierraShears/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SierraShearModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<SierraShearModel>>> GetItemSierraShearsAsync(
         string itemId)
        {
            IEnumerable<SierraShearModel> materials = await gateway
                .GetItemSierraShearsAsync(
                    itemId,
                    CancellationToken.None)
                .ConfigureAwait(false);

            return materials == null ? NotFound() : Ok(materials);
        }

        [Obsolete("Use el controlador InsulationsController.")]
        [Route("aluminumShears/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(AluminumTipPuntasModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AluminumTipPuntasModel?>> GetItemAluminumTipsAsync(
            string itemId)
        {
            AluminumTipPuntasModel? materials = await gateway
                .GetItemAluminumTipsAsync(
                    itemId,
                    CancellationToken.None)
                .ConfigureAwait(false);

            return materials == null ? NotFound() : Ok(materials);
        }

        [Obsolete("Use el controlador InsulationsController.")]
        [Route("aluminiumCuts/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AluminiumCutModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AluminiumCutModel>>> GetItemAluminiumCutsAsync(
       string itemId)
        {
            IEnumerable<AluminiumCutModel> materials = await gateway
                .GetItemAluminiumCutsAsync(
                    itemId,
                    CancellationToken.None)
                .ConfigureAwait(false);

            return materials == null ? NotFound() : Ok(materials);
        }

        #endregion
    }
}