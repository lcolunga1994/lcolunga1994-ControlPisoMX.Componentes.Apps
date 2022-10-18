namespace ProlecGE.ControlPisoMX.BFWeb.Components.Api.Controllers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using Cores;
    using Cores.Industrial.Models;

    using Microsoft.AspNetCore.Mvc;

    using Models;

    using ProlecGE.ControlPisoMX.BFWeb.Components;

    [Route("api/v1/cores/testing/industrial")]
    [ApiController]
    public class CoresIndustrialController : ControllerBase
    {
        #region Fields

        private readonly IIndustrialCoresService service;

        #endregion

        #region Constructor

        public CoresIndustrialController(IIndustrialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Pattern

        [Route("pattern")]
        [HttpGet]
        [ProducesResponseType(
            typeof(IndustrialCorePatternModel),
            (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IndustrialCorePatternModel?>> GetIndustrialCorePatternDesignAsync()
        {
            IndustrialCorePatternModel? item =
                await service.GetIndustrialCorePatternDesignAsync();

            return item == null ? NotFound() : Ok(item);
        }

        [Route("testpattern")]
        [HttpPost]
        [ProducesResponseType(
            typeof(IndustrialCoreTestResultModel),
            (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IndustrialCoreTestResultModel>> TestIndustrialCorePattern(TestCorePatternParametersModel command)
        {
            if (command is null)
            {
                return BadRequest();
            }

            IndustrialCoreTestResultModel result = await service
                .TestIndustrialCorePatternAsync(
                    command.TestCode,
                    command.AverageVoltage,
                    command.RMSVoltage,
                    command.Current,
                    command.Temperature,
                    command.Watts,
                    command.CoreTemperature,
                    command.StationId,
                    CancellationToken.None);

            return Ok(result);
        }

        #endregion

        #region Queries

        [Route("corefoilwidths/{itemId}/{coreSize}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<double>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<double>?>> CoreFoilWidths(string itemId, int coreSize)
        {
            IEnumerable<double>? item = await service.GetIndustrialCoreFoilWidthsAsync(itemId, coreSize);

            return item == null ? NotFound() : Ok(item);
        }

        [Route("corevoltagedesign/{itemId}/{coreSize}/{foilWidth}")]
        [HttpGet]
        [ProducesResponseType(typeof(IndustrialItemVoltageDesignModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IndustrialItemVoltageDesignModel?>> GetIndustrialCoreVoltageDesignAsync(string itemId, int coreSize, double foilWidth)
        {
            IndustrialItemVoltageDesignModel? item = await service.GetIndustrialCoreVoltageDesignAsync(itemId, coreSize, foilWidth);

            return item == null ? NotFound() : Ok(item);
        }

        #endregion

        #region Tests

        [Route("summary/{itemId}/{batch}/{serie}")]
        [HttpGet]
        [ProducesResponseType(
            typeof(IndustrialCoreTestSummaryModel),
            (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IndustrialCoreTestSummaryModel?>> GetIndustrialCoreTestSummaryAsync(string itemId, string batch, int serie)
        {
            IndustrialCoreTestSummaryModel? item = await service.GetIndustrialCoreTestSummaryAsync(itemId, batch, serie, CancellationToken.None);

            return item == null ? NotFound() : Ok(item);
        }

        [Route("test/{testCode}")]
        [HttpGet]
        [ProducesResponseType(
          typeof(IndustrialCoreTestResultModel),
          (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IndustrialCoreTestResultModel?>> CoreTestResult([Required][StringLength(8)] string testCode)
        {
            IndustrialCoreTestResultModel? item = await service
                .GetIndustrialCoreTestResultAsync(testCode)
                .ConfigureAwait(false);

            return item == null ? NotFound() : Ok(item);
        }

        [Route("testcore/{testCode}")]
        [HttpGet]
        [ProducesResponseType(
          typeof(IndustrialCoreTestModel),
          (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IndustrialCoreTestModel?>> CoreTest([Required][StringLength(8)] string testCode)
        {
            IndustrialCoreTestModel? item = await service
                .GetIndustrialCoreTestAsync(testCode)
                .ConfigureAwait(false);

            return item == null ? NotFound() : Ok(item);
        }

        [Route("suggestedcode/{testCode}")]
        [HttpGet]
        [ProducesResponseType(
          typeof(IndustrialCoreSuggestedCodeResultModel),
          (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IndustrialCoreSuggestedCodeResultModel?>> CoreSuggestedCodeResult([Required][StringLength(8)] string testCode)
        {
            IndustrialCoreSuggestedCodeResultModel? item = await service
                .GetIndustrialCoreSuggestedCodeResultAsync(testCode)
                .ConfigureAwait(false);

            return item == null ? NotFound() : Ok(item);
        }

        [Route("location/{testCode}")]
        [HttpGet]
        [ProducesResponseType(
          typeof(IndustrialCoreLocationResultModel),
          (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IndustrialCoreLocationResultModel?>> CoreLocationResult([Required][StringLength(8)] string testCode)
        {
            IndustrialCoreLocationResultModel? item = await service
                .GetIndustrialCoreLocationResultAsync(testCode)
                .ConfigureAwait(false);

            return item == null ? NotFound() : Ok(item);
        }

        [Route("test")]
        [HttpPost]
        [ProducesResponseType(
            typeof(IndustrialCoreTestResultModel),
            (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IndustrialCoreTestResultModel>> TestIndustrialCore(TestCoreParametersModel request)
        {
            if (request is null)
            {
                return BadRequest();
            }

            IndustrialCoreTestResultModel result = await service
                .TestIndustrialCoreAsync(request, CancellationToken.None);

            return Ok(result);
        }

        #endregion

        #region Store

        [Route("store")]
        [HttpPost]
        [ProducesResponseType(
            (int)HttpStatusCode.OK)]
        public async Task StoreCore(StoreCoreParametersModel model)
        {
            await service
                .StoreIndustrialCoreAsync(
                    model.CoreTestId,
                    model.Location ?? "NoData",
                    model.AssociatedCode,
                    model.Force,
                    CancellationToken.None
                );
        }

        #endregion
    }
}