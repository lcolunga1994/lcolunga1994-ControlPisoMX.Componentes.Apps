namespace ProlecGE.ControlPisoMX.BFWeb.Components.Api.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using Insulations.Models;

    using Microsoft.AspNetCore.Mvc;

    using Models;

    using ProlecGE.ControlPisoMX.BFWeb.Components;

    [Route("api/v1/insulations")]
    [ApiController]
    public class InsulationsController : ControllerBase
    {
        #region Fields

        private readonly IInsulationsService service;

        #endregion

        #region Constructor

        public InsulationsController(IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Security

        [Route("getusername")]
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetUser(string username, string password)
        {
            string usrname = await service
                .GetUserAsync(username, password, CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(usrname);
        }

        [Route("validateuserpassword")]
        [HttpGet]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> ValidateUserPassword(string username, string password)
        {
            bool validateUserPassword = await service
                .ValidateUserPasswordAsync(username, password, CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(validateUserPassword);
        }

        #endregion

        #region Configurations

        [Route("ismanufacturingallowed")]
        [HttpGet]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> IsManufacturingAllowed()
        {
            bool isManufacturingAllowed = await service
                .IsManufacturingAllowedAsync(CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(isManufacturingAllowed);
        }

        [Route("changeallowmanufacturing")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> ChangeAllowManufacturing(bool allow)
        {
            await service
                .ChangeAllowManufacturingAsync(allow, CancellationToken.None)
                .ConfigureAwait(false);

            return Ok();
        }

        [Route("minimummanufactureminutes")]
        [HttpGet]
        [ProducesResponseType(typeof(int?), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<int?>> MinimumManufactureMinutes()
        {
            int? minutes = await service
                .GetMinimumManufactureMinutesAsync(CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(minutes);
        }

        [Route("manufactureminutes")]
        [HttpGet]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> ManufacturingMinutes()
        {
            int minutes = await service
                .GetManufacturingMinutesAsync(CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(minutes);
        }

        [Route("machinecanprint/{machine}")]
        [HttpGet]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> MachineCanPrint(string machine)
        {
            bool mahcineCanPrint = await service
                .MachineCanPrintAsync(machine, CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(mahcineCanPrint);
        }

        [Route("machineworkloadconfiguration")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MachineWorkloadFlagConfigurationModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MachineWorkloadFlagConfigurationModel>> MachineWorkloadSemaphore()
        {
            MachineWorkloadFlagConfigurationModel configuration = await service
                .GetMachineWorkloadSemaphoreAsync(CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(configuration);
        }

        #endregion

        #region Queries

        [Route("machines")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InsulationMachineModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<InsulationMachineModel>>> GetInsulationMachinesItemAsync()
        {
            IEnumerable<InsulationMachineModel> insulationMachineItem = await service
                .GetInsulationMachinesAsync(CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(insulationMachineItem);
        }

        [Route("machinemanufacturingplan")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderToManufacturingModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderToManufacturingModel>>> GetManufacturingPlanItemAsync(MachineAndUtcDateParameterModel model)
        {
            IEnumerable<OrderToManufacturingModel> manufacturingPlan = await service
                .GetOrdersScheduledToManufactureAsync(model.UtcDate, model.Machine, CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(manufacturingPlan);
        }

        [Route("manufactures")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<InsulationManufactureModel>>> GetInsulationManufacturesAsync(CancellationToken cancellationToken)
        {
            IEnumerable<InsulationManufactureModel> insulationMachineItem = await service
                .GetInsulationManufacturingOrdersAsync(cancellationToken)
                .ConfigureAwait(false);

            return Ok(insulationMachineItem);
        }

        [Route("ordersinprogress")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InsulationManufactureModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<InsulationManufactureModel>>> GetManufacturingOrdersInProgressAsync(CancellationToken cancelationToken)
        {
            IEnumerable<InsulationManufactureModel> ordersInProregress = await service
                .GetInsulationManufacturingOrdersInProgressAsync(cancelationToken)
                .ConfigureAwait(false);

            return Ok(ordersInProregress);
        }

        [Route("manufacturingorder/{itemId}/{batch}/{serie}")]
        [HttpGet]
        [ProducesResponseType(typeof(InsulationManufactureModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<InsulationManufactureModel>> GetManufacturingOrder(string itemId, string batch, int serie)
        {
            InsulationManufactureModel? result = await service
                .GetManufacturingOrderAsync(itemId, batch, serie, CancellationToken.None)
                 .ConfigureAwait(false);

            return result == null ? NotFound() : Ok(result);
        }

        [Route("machineassignedorders")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MachineAssignedOrdersModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MachineAssignedOrdersModel>>> GetMachineAssignedOrdersAsync(CancellationToken cancellationToken)
        {
            IEnumerable<MachineAssignedOrdersModel> asignation = await service
                .GetMachineAssignedOrdersAsync(cancellationToken)
                .ConfigureAwait(false);

            return Ok(asignation);
        }

        [Route("orderstomanufacture")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderToManufacturingModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderToManufacturingModel>>> GetOrdersToManufacture(MachineAndUtcDateParameterModel model)
        {
            IEnumerable<OrderToManufacturingModel> manufacturingPlan = await service
                .GetOrdersToManufactureAsync(model.UtcDate, model.Machine, CancellationToken.None)
                .ConfigureAwait(false);

            return Ok(manufacturingPlan);
        }

        #endregion

        #region Manufacturing

        [Route("addtomanufacturing")]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<InsulationMachineModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddOrdersToManufacturing(List<OrderToManufactureModel> orders)
        {
            if (orders == null)
            {
                return BadRequest();
            }

            await service
                .AddOrdersToManufacturingAsync(orders)
                .ConfigureAwait(false);

            return Ok();
        }

        [Route("addrepairorder")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddRepairOrderAsync(AddOrderToRepairParameterModel parameters)
        {
            await service
                .AddRepairOrderAsync(parameters.ItemId, parameters.Batch, parameters.Quantity, parameters.Priority, CancellationToken.None)
                .ConfigureAwait(false);

            return Ok();
        }

        [Route("startordermanufacturing")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> StartOrderManufacturingAsync()
        {
            await service
                .StartOrderManufacturingAsync(CancellationToken.None)
                .ConfigureAwait(false);

            return Ok();
        }

        [Route("finishordermanufacturing")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> FinishOrderManufacturingAsync()
        {
            await service
                .FinishOrderManufacturingAsync(CancellationToken.None)
                .ConfigureAwait(false);

            return Ok();
        }

        [Route("changepriority")]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<UpdatePriorityParameterModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateOrderManufacturingPriorityAsync(UpdatePriorityParameterModel parameters)
        {
            await service
                .UpdateOrderManufacturingPriorityAsync(parameters.Id, parameters.Priority, CancellationToken.None)
                .ConfigureAwait(false);

            return Ok();
        }

        #endregion

        #region Materials

        [Route("cartonShears/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CartonShearModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CartonShearModel>>> GetItemCartonShearsAsync(
            string itemId)
        {
            IEnumerable<CartonShearModel> materials = await service
                .GetItemCartonShearsAsync(
                    itemId,
                    CancellationToken.None)
                .ConfigureAwait(false);

            return materials == null ? NotFound() : Ok(materials);
        }

        [Route("guillotineShears/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GuillotineShearModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GuillotineShearModel>>> GetItemGuillotineShearsAsync(
          string itemId)
        {
            IEnumerable<GuillotineShearModel> materials = await service
                .GetItemGuillotineShearsAsync(
                    itemId,
                    CancellationToken.None)
                .ConfigureAwait(false);

            return materials == null ? NotFound() : Ok(materials);
        }

        [Route("sierraShears/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SierraShearModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<SierraShearModel>>> GetItemSierraShearsAsync(
         string itemId)
        {
            IEnumerable<SierraShearModel> materials = await service
                .GetItemSierraShearsAsync(
                    itemId,
                    CancellationToken.None)
                .ConfigureAwait(false);

            return materials == null ? NotFound() : Ok(materials);
        }


        [Route("aluminumShears/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(AluminumTipPuntasModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AluminumTipPuntasModel?>> GetItemAluminumTipsAsync(
            string itemId)
        {
            AluminumTipPuntasModel? materials = await service
                .GetItemAluminumTipsAsync(
                    itemId,
                    CancellationToken.None)
                .ConfigureAwait(false);

            return materials == null ? NotFound() : Ok(materials);
        }

        [Route("aluminiumCuts/{itemId}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AluminiumCutModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AluminiumCutModel>>> GetItemAluminiumCutsAsync(
       string itemId)
        {
            IEnumerable<AluminiumCutModel> materials = await service
                .GetItemAluminiumCutsAsync(
                    itemId,
                    CancellationToken.None)
                .ConfigureAwait(false);

            return materials == null ? NotFound() : Ok(materials);
        }
        
        #endregion
    }
}