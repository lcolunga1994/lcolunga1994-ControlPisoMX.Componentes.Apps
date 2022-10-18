namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using Insulations.Models;

    public interface IInsulationsService
    {
        #region Security

        Task<string> GetUserAsync(string username, string password, CancellationToken cancellationToken);

        Task<bool> ValidateUserPasswordAsync(string username, string password, CancellationToken cancellationToken);

        #endregion

        #region Configurations

        Task<bool> IsManufacturingAllowedAsync(CancellationToken cancellationToken);

        Task ChangeAllowManufacturingAsync(bool allow, CancellationToken cancellationToken);

        Task<int?> GetMinimumManufactureMinutesAsync(CancellationToken cancellationToken);

        Task<int> GetManufacturingMinutesAsync(CancellationToken cancellationToken);

        Task<bool> MachineCanPrintAsync(string machine, CancellationToken cancellationToken);

        Task<MachineWorkloadFlagConfigurationModel> GetMachineWorkloadSemaphoreAsync(CancellationToken cancellationToken);

        #endregion

        #region Queries

        Task<IEnumerable<InsulationMachineModel>> GetInsulationMachinesAsync(CancellationToken cancellationToken);

        Task<IEnumerable<OrderToManufacturingModel>> GetOrdersScheduledToManufactureAsync(DateTime utcDate, string machine, CancellationToken cancellationToken);

        Task<IEnumerable<InsulationManufactureModel>> GetInsulationManufacturingOrdersAsync(CancellationToken cancellationToken);

        Task<IEnumerable<InsulationManufactureModel>> GetInsulationManufacturingOrdersInProgressAsync(CancellationToken cancellationToken);

        Task<InsulationManufactureModel?> GetManufacturingOrderAsync(string itemId, string batch, int serie, CancellationToken cancelationToken);

        Task<IEnumerable<MachineAssignedOrdersModel>> GetMachineAssignedOrdersAsync(CancellationToken cancellationToken);

        #endregion

        #region Manufacturing

        Task AddOrdersToManufacturingAsync(List<OrderToManufactureModel> orders);

        Task AddRepairOrderAsync(string itemId, string batch, int quantity, int priority, CancellationToken cancelationToken);

        Task StartOrderManufacturingAsync(CancellationToken cancellationToken);

        Task FinishOrderManufacturingAsync(CancellationToken cancellationToken);

        Task UpdateOrderManufacturingPriorityAsync(Guid Id, int priority, CancellationToken cancellationToken);

        Task<IEnumerable<OrderToManufacturingModel>> GetOrdersToManufactureAsync(DateTime utcDate, string machine, CancellationToken cancellationToken);

        #endregion

        #region Materials

        Task<IEnumerable<CartonShearModel>> GetItemCartonShearsAsync(string itemId, CancellationToken cancellationToken);

        Task<IEnumerable<GuillotineShearModel>> GetItemGuillotineShearsAsync(string itemId, CancellationToken cancellationToken);

        Task<IEnumerable<SierraShearModel>> GetItemSierraShearsAsync(string itemId, CancellationToken cancellationToken);

        Task<AluminumTipPuntasModel?> GetItemAluminumTipsAsync(string itemId, CancellationToken cancellationToken);

        Task<IEnumerable<AluminiumCutModel>> GetItemAluminiumCutsAsync(string itemId, CancellationToken cancellationToken);

        #endregion
    }
}
