namespace ProlecGE.ControlPisoMX.BFWeb.Components.Api.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using Clamps;

    using Components.Models;

    using Microsoft.AspNetCore.Mvc;

    using ProlecGE.ControlPisoMX.BFWeb.Components;

    [Route("api/v1/clamps")]
    [ApiController]
    public class ClampsController : ControllerBase
    {
        #region Fields

        private readonly IClampsService service;

        #endregion

        #region Constructor

        public ClampsController(IClampsService service)
        {
            this.service = service;
        }

        #endregion

        #region Queries

        [Route("orderstoplace")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderWithClampsModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderWithClampsModel>>> OrdersToPlaceClamps()
        {
            IEnumerable<OrderWithClampsModel> items = await service
                .GetOrdersToPlaceClampsAsync()
                .ConfigureAwait(false);

            return Ok(items);
        }

        #endregion

        #region Commands

        
        [Route("removeclamp")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> RemoveClamp(OrderModel remove)
        {
            await service.RemoveClampAsync(remove.ItemId, remove.Batch, remove.Serie, remove.Sequence)
               .ConfigureAwait(false);

            return Ok();
        }

        #endregion
    }
}