namespace ProlecGE.ControlPisoMX.BFWeb.Components.Api.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using Components.Models;

    using Microsoft.AspNetCore.Mvc;

    using ProlecGE.ControlPisoMX.BFWeb.Components;

    [Route("api/v1/combo")]
    [ApiController]
    public class ComboController : ControllerBase
    {
        #region Fields

        private readonly IComboService service;

        #endregion

        #region Constructor

        public ComboController(IComboService service)
        {
            this.service = service;
        }

        #endregion

        #region Queries

        [Route("comboorderdesigns/{itemId:maxlength(47)}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ComboOrderDesignModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ComboOrderDesignModel>>> ComboOrderDesigns(string itemId)
        {
            IEnumerable<ComboOrderDesignModel> items = await service
                .GetComboOrderDesignAsync(itemId, CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(items);
        }

        #endregion
    }
}