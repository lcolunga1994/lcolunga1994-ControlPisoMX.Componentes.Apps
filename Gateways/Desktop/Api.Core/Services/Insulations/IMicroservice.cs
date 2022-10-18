namespace ProlecGE.ControlPisoMX.Insulations
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Models;

    public interface IMicroservice
    {
        #region Security

        Task<string> GetUserAsync(string username, string password, CancellationToken cancellationToken);

        Task<bool> ValidateUserPasswordAsync(string username, string password, CancellationToken cancellationToken);
        Task<bool> ValidateUserPasswordAsync_sqlctp(string username, string password, CancellationToken cancellationToken);

        #endregion

        #region Configurations

        Task<bool> IsManufacturingAllowedAsync(CancellationToken cancellationToken);

        Task ChangeAllowManufacturingAsync(bool allow, CancellationToken cancellationToken);
        Task ChangeAllowManufacturingAsync_sqlctp(bool allow, CancellationToken cancellationToken);

        Task<int?> GetMinimumManufactureMinutesAsync(CancellationToken cancellationToken);

        Task<int> GetManufacturingMinutesAsync(CancellationToken cancellationToken);

        Task<bool> MachineCanPrintAsync(string machine, CancellationToken cancellationToken);

        Task<MachineWorkloadFlagConfigurationModel> GetMachineWorkloadSemaphoreAsync(CancellationToken cancellationToken);

        #endregion

        #region Queries

        Task<IEnumerable<InsulationMachineModel>> GetMachinesAsync(CancellationToken cancellationToken);
        Task<IEnumerable<InsulationMachineModel>> GetMachinesAsync_sqlctp(CancellationToken cancellationToken);

        Task<IEnumerable<ManufacturingPlanItemModel>> GetManufacturingPlanByMachineAsync(DateTime date, string machine, CancellationToken cancellationToken);

        Task<ManufacturingPlanItemModel?> GetManufacturingPlanBySerieAsync(string itemId, string batch, int serie, int sequence, CancellationToken cancellationToken);

        Task<IEnumerable<ManufacturingItemModel>> GetManufacturingOrdersAsync(CancellationToken cancellationToken);

        Task<IEnumerable<ManufacturingItemModel>> GetManufacturingOrdersInProgressAsync(CancellationToken cancellationToken);

        Task<ManufacturingItemModel?> GetManufacturingOrderAsync(string itemId, string batch, int serie, CancellationToken cancellationToken);

        Task<IEnumerable<MachineAssignedOrdersModel>> GetMachineAssignedOrdersAsync(CancellationToken cancellationToken);

        Task<IEnumerable<ManufacturingPlanItemModel>> GetOrdersToManufactureAsync(DateTime utcDate, string machine, CancellationToken cancellationToken);
        Task<IEnumerable<ManufacturingPlanItemModel>> GetOrdersToManufactureAsync_sqlctp(DateTime utcDate, string machine, CancellationToken cancellationToken);

        #endregion

        #region Manufacturing

        Task AddOrdersToManufacturingAsync(List<OrderToManufactureModel> orders);
        Task AddOrdersToManufacturingAsync_sqlctp(List<OrderToManufactureModel> orders);

        Task AddRepairOrderAsync(string itemId, string batch, int quantity, int priority, CancellationToken cancellationToken);
        Task AddRepairOrderAsync_sqlctp(string itemId, string batch, int quantity, int priority, CancellationToken cancellationToken);

        Task StartOrderManufacturingAsync(CancellationToken cancellationToken);
        Task StartOrderManufacturingAsync_sqlctp(CancellationToken cancellationToken);

        Task FinishOrderManufacturingAsync(CancellationToken cancellationToken);
        Task FinishOrderManufacturingAsync_sqlctp(CancellationToken cancellationToken);

        Task UpdateOrderManufacturingPriorityAsync(Guid Id, int priority, CancellationToken cancellationToken);
        Task UpdateOrderManufacturingPriorityAsync_sqlctp(Guid Id, int priority, CancellationToken cancellationToken);

        #endregion
    }
}