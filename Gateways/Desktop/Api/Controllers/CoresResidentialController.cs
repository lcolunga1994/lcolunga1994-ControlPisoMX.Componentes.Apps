namespace ProlecGE.ControlPisoMX.BFWeb.Components.Api.Controllers
{
    using Cores.Models;
    using Cores.Residential.Models;

    using Microsoft.AspNetCore.Mvc;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    [Route("api/v1/cores/testing/residential")]
    [ApiController]
    public class CoresResidentialController : ControllerBase
    {
        #region Fields

        private readonly IResidentialCoresService service;

        #endregion

        #region Constructor

        public CoresResidentialController(IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Plan

        [Route("manufacturing/daterange")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DateRangeAvailableModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<DateRangeAvailableModel>>> DateRangeAvailableForTestQuery()
        {
            IEnumerable<DateRangeAvailableModel> result = await service.GetDateRangeAvailableForTestQueryAsync()
                .ConfigureAwait(false);

            return Ok(result);
        }

        [Route("manufacturing/itemsplanned")]
        [HttpGet]
        [ProducesResponseType(typeof(Cores.QueryResult<string>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Cores.QueryResult<string>>> ItemsPlannedToBeManufactured(int page = 1, int pageSize = 100)
        {
            Cores.QueryResult<string> result = await service
                .GetItemsPlannedToBeManufacturedAsync(page, pageSize, CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(result);
        }

        [Route("manufactured")]
        [HttpGet]
        [ProducesResponseType(
            typeof(Cores.QueryResult<ManufacturedResidentialCoreModel>),
            (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Cores.QueryResult<ManufacturedResidentialCoreModel>>> GetManufacturedCores(
            int page = 1,
            int pageSize = 100)
        {
            Cores.QueryResult<ManufacturedResidentialCoreModel> items = await service
                .GetManufacturedCoresAsync(
                    page,
                    pageSize,
                    CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(items);
        }

        [Route("manufacturing/nextcore/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(CoreManufacturingPlanModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CoreManufacturingPlanModel?>> NextCoreToBeManufactured([Required][StringLength(47)] string itemId)
        {
            CoreManufacturingPlanModel? result = await service
                .GetNextCoreToBeManufacturedAsync(itemId.Trim(), CancellationToken.None)
                .ConfigureAwait(false);

            return result == null ? NotFound() : Ok(result);
        }

        #endregion

        #region Pattern

        [Route("patternsummary")]
        [HttpGet]
        [ProducesResponseType(
            typeof(ResidentialCorePatternTestsSummaryModel),
            (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCorePatternTestsSummaryModel?>> ResidentialCorePatternTestSummary()
        {
            ResidentialCorePatternTestsSummaryModel? item = await service.GetResidentialCorePatternTestSummaryAsync();

            return item == null ? NotFound() : (ActionResult<ResidentialCorePatternTestsSummaryModel?>)Ok(item);
        }

        [Route("testpattern")]
        [HttpPost]
        [ProducesResponseType(
            typeof(ResidentialCoreTestResultModel),
            (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCoreTestResultModel>> TestResidentialCorePattern(TestCorePatternParametersModel command)
        {
            if (command is null)
            {
                return BadRequest();
            }

            ResidentialCoreTestResultModel result = await service
                .TestResidentialCorePatternAsync(
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

        #region Tests

        [Route("summary/{itemId}/{batch}/{serie}/{sequence}")]
        [HttpGet]
        [ProducesResponseType(
            typeof(ResidentialCoreTestSummaryModel),
            (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCoreTestSummaryModel?>> GetCoreTestSummary(
            [Required][StringLength(47)] string itemId,
            [Required][StringLength(3)] string batch,
            int serie,
            int sequence)
        {
            ResidentialCoreTestSummaryModel? item = await service
                .GetResidentialCoreTestSummaryAsync(itemId, batch, serie, sequence, CancellationToken.None)
                .ConfigureAwait(false);

            return item == null ? NotFound() : Ok(item);
        }

        [Route("test/{testCode}")]
        [HttpGet]
        [ProducesResponseType(typeof(ResidentialCoreTestModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCoreTestModel?>> CoreTest([Required][StringLength(8)] string testCode)
        {
            ResidentialCoreTestModel? item = await service
                .GetResidentialCoreTestAsync(testCode)
                .ConfigureAwait(false);

            return item == null ? NotFound() : Ok(item);
        }

        [Route("suggestedcode/{testCode}")]
        [HttpGet]
        [ProducesResponseType(
          typeof(ResidentialCoreSuggestedCodeResultModel),
          (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCoreSuggestedCodeResultModel?>> CoreSuggestedCodeResult([Required][StringLength(8)] string testCode)
        {
            ResidentialCoreSuggestedCodeResultModel? item = await service
                .GetResidentialCoreSuggestedCodeResultAsync(testCode)
                .ConfigureAwait(false);

            return item == null ? NotFound() : Ok(item);
        }

        [Route("location/{testCode}")]
        [HttpGet]
        [ProducesResponseType(
          typeof(ResidentialCoreLocationResultModel),
          (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCoreLocationResultModel?>> CoreLocationResult([Required][StringLength(8)] string testCode)
        {
            ResidentialCoreLocationResultModel? item = await service
                .GetResidentialCoreLocationResultAsync(testCode)
                .ConfigureAwait(false);

            return item == null ? NotFound() : Ok(item);
        }

        [Route("test")]
        [HttpPost]
        [ProducesResponseType(
            typeof(ResidentialCoreTestResultModel),
            (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCoreTestResultModel>> TestCore(TestCoreParametersModel command)
        {
            if (command is null)
            {
                return BadRequest();
            }

            ResidentialCoreTestResultModel result = await service
                .TestResidentialCoreAsync(
                    command.Tag,
                    command.ItemId,
                    command.CoreSize,
                    command.AverageVoltage,
                    command.RMSVoltage,
                    command.Current,
                    command.Temperature,
                    command.Watts,
                    command.CoreTemperature,
                    command.TestCode,
                    command.StationId,
                    CancellationToken.None);

            return Ok(result);
        }

        [Route("rework")]
        [HttpPost]
        [ProducesResponseType(
            typeof(ResidentialCoreTestResultModel),
            (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCoreTestResultModel>> Rework(ReworkCoreParametersModel command)
        {
            if (command is null)
            {
                return BadRequest();
            }

            ResidentialCoreTestResultModel result = await service
                .ReworkResidentialCoreAsync(
                    command.ItemId,
                    command.CoreSize,
                    command.AverageVoltage,
                    command.RMSVoltage,
                    command.Current,
                    command.Temperature,
                    command.Watts,
                    command.CoreTemperature,
                    command.TestCode,
                    command.StationId,
                    CancellationToken.None);

            return Ok(result);
        }

        #endregion

        #region Defects

        [Route("defects")]
        [HttpGet]
        [ProducesResponseType(
                    typeof(IEnumerable<string>),
                    (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CoreTestDefectConceptModel>>> Defects(
                    int page = 1,
                    int pageSize = 100)
        {
            IEnumerable<CoreTestDefectConceptModel> items = await service
                .GetDefectConceptListAsync(
                    page,
                    pageSize,
                    CancellationToken.None);

            return Ok(items);
        }

        [Route("defect")]
        [HttpPost]
        [ProducesResponseType(typeof(ResidentialCoreTestResultModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCoreTestResultModel>> RegisterDefect(RegisterDefectParametersModel model)
        {
            ResidentialCoreTestResultModel result = await service
                .RegisterDefectAsync(
                    model.TestCode,
                    model.Defect,
                    CancellationToken.None);

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
                .StoreResidentialCoreAsync(
                    model.CoreTestId,
                    model.Location ?? throw new UserException("La ubicación es requerida"),
                    model.AssociatedCode,
                    model.Force,
                    CancellationToken.None);
        }

        #endregion
    }

    [Swashbuckle.AspNetCore.Annotations.SwaggerTag("Núcleos residenciales")]
    [Route("api/v1/cores/residential")]
    [ApiController]
    public class CoresResidentialV2Controller : ControllerBase
    {
        #region Fields

        private readonly IResidentialCoresService service;

        #endregion

        #region Constructor

        public CoresResidentialV2Controller(IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Plan

        [Route("manufacturing/daterange")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DateRangeAvailableModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<DateRangeAvailableModel>>> DateRangeAvailableForTestQuery()
        {
            IEnumerable<DateRangeAvailableModel> result = await service.GetDateRangeAvailableForTestQueryAsync()
                .ConfigureAwait(false);

            return Ok(result);
        }

        [Route("manufacturing/itemsplanned")]
        [HttpGet]
        [ProducesResponseType(typeof(Cores.QueryResult<string>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Cores.QueryResult<string>>> ItemsPlannedToBeManufactured(int page = 1, int pageSize = 100)
        {
            Cores.QueryResult<string> result = await service
                .GetItemsPlannedToBeManufacturedAsync(page, pageSize, CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(result);
        }

        [Route("testing/manufactured")]
        [HttpGet]
        [ProducesResponseType(
            typeof(Cores.QueryResult<ManufacturedResidentialCoreModel>),
            (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Cores.QueryResult<ManufacturedResidentialCoreModel>>> GetManufacturedCores(
            int page = 1,
            int pageSize = 100)
        {
            Cores.QueryResult<ManufacturedResidentialCoreModel> items = await service
                .GetManufacturedCoresAsync(
                    page,
                    pageSize,
                    CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(items);
        }

        [Route("manufacturing/nextcore/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(CoreManufacturingPlanModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CoreManufacturingPlanModel?>> NextCoreToBeManufactured([Required][StringLength(47)] string itemId)
        {
            CoreManufacturingPlanModel? result = await service
                .GetNextCoreToBeManufacturedAsync(itemId.Trim(), CancellationToken.None)
                .ConfigureAwait(false);

            return result == null ? NotFound() : Ok(result);
        }

        #endregion

        #region Item design

        [Route("design/voltage/{itemId}/{coreSize}")]
        [HttpGet]
        [ProducesResponseType(typeof(CoreVoltageDesignModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CoreVoltageDesignModel>> GetCoreVoltageDesign(
            string itemId,
            int coreSize)
        {
            CoreVoltageDesignModel? design = await service
                .GetResidentialCoreVoltageDesignAsync(
                    itemId,
                    coreSize,
                    CancellationToken.None)
                .ConfigureAwait(false);

            return design == null ? NotFound() : Ok(design);
        }

        #endregion

        #region Pattern

        [Route("testing/patternsummary")]
        [HttpGet]
        [ProducesResponseType(
            typeof(ResidentialCorePatternTestsSummaryModel),
            (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCorePatternTestsSummaryModel?>> ResidentialCorePatternTestSummary()
        {
            ResidentialCorePatternTestsSummaryModel? item = await service.GetResidentialCorePatternTestSummaryAsync();

            return item == null ? NotFound() : (ActionResult<ResidentialCorePatternTestsSummaryModel?>)Ok(item);
        }

        [Route("testing/testpattern")]
        [HttpPost]
        [ProducesResponseType(
            typeof(ResidentialCoreTestResultModel),
            (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCoreTestResultModel>> TestResidentialCorePattern(TestCorePatternParametersModel command)
        {
            if (command is null)
            {
                return BadRequest();
            }

            ResidentialCoreTestResultModel result = await service
                .TestResidentialCorePatternAsync(
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

        #region Tests

        [Route("testing/summary/{itemId}/{batch}/{serie}/{sequence}")]
        [HttpGet]
        [ProducesResponseType(
            typeof(ResidentialCoreTestSummaryModel),
            (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCoreTestSummaryModel?>> GetCoreTestSummary(
            [Required][StringLength(47)] string itemId,
            [Required][StringLength(3)] string batch,
            int serie,
            int sequence)
        {
            ResidentialCoreTestSummaryModel? item = await service
                .GetResidentialCoreTestSummaryAsync(itemId, batch, serie, sequence, CancellationToken.None)
                .ConfigureAwait(false);

            return item == null ? NotFound() : Ok(item);
        }

        [Route("testing/test/{testCode}")]
        [HttpGet]
        [ProducesResponseType(
          typeof(ResidentialCoreTestModel),
          (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCoreTestModel?>> CoreTest([Required][StringLength(8)] string testCode)
        {
            ResidentialCoreTestModel? item = await service
                .GetResidentialCoreTestAsync(testCode)
                .ConfigureAwait(false);

            return item == null ? NotFound() : Ok(item);
        }

        [Route("testing/suggestedcode/{testCode}")]
        [HttpGet]
        [ProducesResponseType(
          typeof(ResidentialCoreSuggestedCodeResultModel),
          (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCoreSuggestedCodeResultModel?>> CoreSuggestedCodeResult([Required][StringLength(8)] string testCode)
        {
            ResidentialCoreSuggestedCodeResultModel? item = await service
                .GetResidentialCoreSuggestedCodeResultAsync(testCode)
                .ConfigureAwait(false);

            return item == null ? NotFound() : Ok(item);
        }

        [Route("testing/location/{testCode}")]
        [HttpGet]
        [ProducesResponseType(
          typeof(ResidentialCoreLocationResultModel),
          (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCoreLocationResultModel?>> CoreLocationResult([Required][StringLength(8)] string testCode)
        {
            ResidentialCoreLocationResultModel? item = await service
                .GetResidentialCoreLocationResultAsync(testCode)
                .ConfigureAwait(false);

            return item == null ? NotFound() : Ok(item);
        }

        [Route("testing/test")]
        [HttpPost]
        [ProducesResponseType(
            typeof(ResidentialCoreTestResultModel),
            (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCoreTestResultModel>> TestCore(TestCoreParametersModel command)
        {
            if (command is null)
            {
                return BadRequest();
            }

            ResidentialCoreTestResultModel result = await service
                .TestResidentialCoreAsync(
                    command.Tag,
                    command.ItemId,
                    command.CoreSize,
                    command.AverageVoltage,
                    command.RMSVoltage,
                    command.Current,
                    command.Temperature,
                    command.Watts,
                    command.CoreTemperature,
                    command.TestCode,
                    command.StationId,
                    CancellationToken.None);

            return Ok(result);
        }

        [Route("testing/rework")]
        [HttpPost]
        [ProducesResponseType(
            typeof(ResidentialCoreTestResultModel),
            (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCoreTestResultModel>> Rework(ReworkCoreParametersModel command)
        {
            if (command is null)
            {
                return BadRequest();
            }

            ResidentialCoreTestResultModel result = await service
                .ReworkResidentialCoreAsync(
                    command.ItemId,
                    command.CoreSize,
                    command.AverageVoltage,
                    command.RMSVoltage,
                    command.Current,
                    command.Temperature,
                    command.Watts,
                    command.CoreTemperature,
                    command.TestCode,
                    command.StationId,
                    CancellationToken.None);

            return Ok(result);
        }

        #endregion

        #region Defects

        [Route("testing/defects")]
        [HttpGet]
        [ProducesResponseType(
                    typeof(IEnumerable<string>),
                    (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CoreTestDefectConceptModel>>> Defects(
                    int page = 1,
                    int pageSize = 100)
        {
            IEnumerable<CoreTestDefectConceptModel> items = await service
                .GetDefectConceptListAsync(
                    page,
                    pageSize,
                    CancellationToken.None);

            return Ok(items);
        }

        [Route("testing/defect")]
        [HttpPost]
        [ProducesResponseType(
            typeof(ResidentialCoreTestResultModel),
            (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResidentialCoreTestResultModel>> RegisterDefect(RegisterDefectParametersModel model)
        {
            ResidentialCoreTestResultModel result = await service
                .RegisterDefectAsync(
                    model.TestCode,
                    model.Defect,
                    CancellationToken.None);

            return Ok(result);
        }

        #endregion

        #region Store

        [Route("testing/store")]
        [HttpPost]
        [ProducesResponseType(
            (int)HttpStatusCode.OK)]
        public async Task StoreCore(StoreCoreParametersModel model)
        {
            await service
                .StoreResidentialCoreAsync(
                    model.CoreTestId,
                    model.Location ?? throw new UserException("La ubicación es requerida"),
                    model.AssociatedCode,
                    model.Force,
                    CancellationToken.None);
        }

        #endregion

        #region Supply        

        [Route("windingmachines")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InsulationMachineModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<InsulationMachineModel>>> WindingMachines()
        {
            IEnumerable<InsulationMachineModel> insulationMachineItem = await service
                .GetWindingMachinesAsync(CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(insulationMachineItem);
        }

        [Route("coresupplybyorder/{itemId}/{batch}/{serie}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ResidentialSuppliedCoreTestModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ResidentialSuppliedCoreTestModel>>> ResidentialCoreSupplyByOrder(string itemId, string batch, int serie)
        {
            IEnumerable<ResidentialSuppliedCoreTestModel> resultado = await service
                .GetResidentialCoreSupplyByOrderAsync(itemId, batch, serie, CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(resultado);
        }


        [Route("addsupplycore")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddSupplyCore(AddSupplyCoreModel addsupply)
        {
            await service.AddSupplyCoreAsync(addsupply, CancellationToken.None)
                .ConfigureAwait(false);

            return Ok();
        }

        [Route("removesupplycore")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> RemoveSupplyCore(RemoveSupplyCoreModel remove)
        {
            await service.RemoveSupplyCoreAsync(remove.Id, CancellationToken.None)
                .ConfigureAwait(false);

            return Ok();
        }


        #endregion
    }
}