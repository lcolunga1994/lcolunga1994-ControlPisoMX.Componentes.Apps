namespace ProlecGE.ControlPisoMX.BFWeb.Components.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    [Swashbuckle.AspNetCore.Annotations.SwaggerTag("Suministro de núcleos")]
    [Route("api/v1/cores/supply")]
    [ApiController]
    public class CoresSupplyController : ControllerBase
    {
        #region Fields

        private readonly ICoresSupplyService service;

        #endregion

        #region Constructor

        public CoresSupplyController(ICoresSupplyService service)
        {
            this.service = service;
        }

        #endregion

        #region Endpoints

        [Route("ordersto")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MOManufacturingStatusModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MOManufacturingStatusModel>>> ManufacturingOrdersAvailableToSupply(DateAndMachineParameterModel model)
        {
            IEnumerable<MOManufacturingStatusModel> resultado = await service
                .GetManufacturingOrdersAvailableToSupplyAsync(model.Date, model.Machine, CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(resultado);
        }

        [Route("supplylist")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddOrdersToSupplyList([Required]List<OrderParameterModel> orders)
        {
            if (orders == null)
            {
                return BadRequest();
            }

            await service
                .AddOrdersToSupplyListAsync(orders, CancellationToken.None)
                .ConfigureAwait(false);

            return Ok();
        }
        
        [Route("pending")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MOSupplyItemModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MOSupplyItemModel>>> PendingSupplies()
        {
            IEnumerable<MOSupplyItemModel> resultado = await service
                .GetPendingSuppliesAsync(CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(resultado);
        }

        [Route("tag/{id:guid}")]
        [HttpGet]
        [ProducesResponseType(typeof(MOSupplyItemTagModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MOSupplyItemTagModel>> Tag(Guid id)
        {
            MOSupplyItemTagModel? item = await service
                .GetSupplyTagAsync(id)
                .ConfigureAwait(false);

            return item == null ? NotFound() : Ok(item);
        }

        [Route("summary")]
        [HttpGet]
        [ProducesResponseType(typeof(MOSupplySummaryModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MOSupplySummaryModel>> SupplySummary(BatchParameterModel model)
        {
            if (string.IsNullOrWhiteSpace(model.ItemId) || string.IsNullOrWhiteSpace(model.Batch))
            {
                throw new UserException("El artículo y el lote son requeridos.");
            }

            MOSupplySummaryModel? result = await service
                .GetManufacturingOrderSupplySummary(model.ItemId, model.Batch)
                .ConfigureAwait(false);

            return result == null ? NotFound() : Ok(result);
        }

        [Route("confirm/{itemId:maxlength(47)}/{batch:maxlength(3)}/{serie:int}")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> ConfirmSupply([Required] string itemId, [Required] string batch, [Required] int serie)
        {
            await service
                .ConfirmSupplyAsync(itemId, batch, serie)
                .ConfigureAwait(false);

            return Ok();
        }

        [Route("authorizereprint/{itemId:maxlength(47)}/{batch:maxlength(3)}/{serie:int}")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AuthorizeReprint([Required] string itemId, [Required] string batch, [Required] int serie)
        {
            await service
                .AuthorizeReprintAsync(itemId, batch, serie)
                .ConfigureAwait(false);

            return Ok();
        }

        [Route("reprint")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MOSupplyItemModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MOSupplyItemModel>>> OrdersToReprintSupply()
        {
            IEnumerable<MOSupplyItemModel> items = await service
                .GetSuppliesToReprintAsync()
                .ConfigureAwait(false);

            return Ok(items);
        }

        [Route("SupplyCores/{itemId:maxlength(47)}/{batch:maxlength(3)}/{serie:int}/{force:bool}/{user}")]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<SupplyCoreResultModel?>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SupplyCoreResultModel?>> SupplyCores([Required] string itemId, [Required] string batch, [Required] int serie, [Required] bool force, string user)
        {
            SupplyCoreResultModel? result =await service
                .SupplyCoresAsync(itemId, batch, serie, force, user)
                .ConfigureAwait(false);

            return Ok(result);
        }

        [Route("SupplyCores_discpiso/{itemId:maxlength(47)}/{batch:maxlength(3)}/{serie:int}/{force:bool}/{user}")]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<SupplyCoreResultModel?>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SupplyCoreResultModel?>> SupplyCores_discpiso([Required] string itemId, [Required] string batch, [Required] int serie, [Required] bool force, string user)
        {
            SupplyCoreResultModel? result = await service
                .SupplyCoresAsync_discpiso(itemId, batch, serie, force, user)
                .ConfigureAwait(false);

            return Ok(result);
        }

        [Route("reprint/{id:guid}/{user}")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Reprint([Required] Guid id, string user)
        {
            await service
                .ReprintAsync(id, user)
                .ConfigureAwait(false);

            return Ok();
        }
        #endregion
    }
}