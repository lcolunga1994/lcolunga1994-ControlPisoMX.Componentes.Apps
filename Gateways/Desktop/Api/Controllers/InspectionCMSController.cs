namespace ProlecGE.ControlPisoMX.BFWeb.Components.Api.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using ProlecGE.ControlPisoMX.BFWeb.Components.InspectionCMS.Models;


    [Route("api/v1/inspectionCMS")]
    [ApiController]
    public class InspectionCMSController : ControllerBase
    {
        #region Fields

        private readonly IInspectionCMService service;

        #endregion

        #region Constructor

        public InspectionCMSController(IInspectionCMService service)
        {
            this.service = service;
        }

        #endregion

        #region Endpoints

        [Route("windings/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<WindingModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<WindingModel>>> Windings(string itemId)
        {
            IEnumerable<WindingModel> result = await service.GetItemWindingAsync(itemId)
                .ConfigureAwait(false);

            return Ok(result);
        }

        [Route("armingandconnecting/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(ArmingAndConnectingModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ArmingAndConnectingModel?>> WindGetArmingAndConnecting(string itemId)
        {
            IEnumerable<ArmingAndConnectingModel> result = await service.GetArmingAndConnectingAsync(itemId)
                .ConfigureAwait(false);

            return result == null ? NotFound() : Ok(result);
        }

        [Route("insulation/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(InsulationModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<InsulationModel?>> Insulation(string itemId)
        {
            IEnumerable<InsulationModel> result = await service.GetItemInsulationAsync(itemId)
                .ConfigureAwait(false);

            return result == null ? NotFound() : Ok(result);
        }

        [Route("clamp/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(ClampModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ClampModel?>> Clamp(string itemId)
        {
            ClampModel? result = await service.GetItemClampAsync(itemId)
                .ConfigureAwait(false);

            return result == null ? NotFound() : Ok(result);
        }

        [Route("lvconnecting/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(LVConnetingModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<LVConnetingModel?>> LVConnecting(string itemId)
        {
            LVConnetingModel? result = await service.GetItemLVConnetingAsync(itemId)
                .ConfigureAwait(false);

            return result == null ? NotFound() : Ok(result);
        }

        [Route("laboratory/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LaboratoryModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<LaboratoryModel>>> GetLaboratory(string itemId)
        {
            IEnumerable<LaboratoryModel> result = await service.GetItemLaboratoryAsync(itemId);

            return Ok(result);
        }

        [Route("lvconnector/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LVConnectorModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<LVConnectorModel>>> GetLVConnector(string itemId)
        {
            IEnumerable<LVConnectorModel> result = await service.GetItemLVConnectorAsync(itemId);

            return Ok(result);
        }

        [Route("accept")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]

        public async Task<ActionResult> AcceptInspection(string itemId, string batch, int serie, string user)
        {
            await service.AcceptInspectionAsync(itemId, batch, serie, user);

            return Ok();
        }
        [Route("accept_discpiso")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]

        public async Task<ActionResult> AcceptInspection_discpiso(string itemId, string batch, int serie, string user)
        {
            await service.AcceptInspectionAsync_discpiso(itemId, batch, serie, user);

            return Ok();
        }

        [Route("rejected")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Rejected(RejectInspectionParameter parameters)
        {
            await service.RejectInspectionAsync(parameters.ItemId, parameters.Batch, parameters.Serie, parameters.Machine, parameters.User, parameters.Card, parameters.Code, CancellationToken.None)
                        .ConfigureAwait(false);
            return Ok();
        }

        [Route("rejected_discpiso")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Rejected_discpiso(RejectInspectionParameter parameters)
        {
            await service.RejectInspectionAsync_discpiso(parameters.ItemId, parameters.Batch, parameters.Serie, parameters.Machine, parameters.User, parameters.Card, parameters.Code, CancellationToken.None)
                        .ConfigureAwait(false);
            return Ok();
        }

        [Route("orderexists")]
        [HttpGet]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<bool>> GetItemOrderExists(string itemId, string batch, int serie)
        {
            bool result = await service.OrderExistsAsync(itemId, batch, serie)
                 .ConfigureAwait(false);

            return Ok(result);
        }

        [Route("orderexists_discpiso")]
        [HttpGet]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<bool>> GetItemOrderExists_discpiso(string itemId, string batch, int serie)
        {
            bool result = await service.OrderExistsAsync_discpiso(itemId, batch, serie)
                 .ConfigureAwait(false);

            return Ok(result);
        }

        [Route("lastrejected")]
        [HttpGet]
        [ProducesResponseType(typeof(LastRejectedModel), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<LastRejectedModel?>> GetLastRejectedCMSInspection(string itemId, string batch, int serie, string code)
        {
            LastRejectedModel? result = await service.LastRejectedAsync(itemId, batch, serie, code)
                 .ConfigureAwait(false);

            return Ok(result);
        }

        #endregion
    }
}
