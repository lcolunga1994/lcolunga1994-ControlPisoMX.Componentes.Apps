namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using Cores.Models;
    using Cores.Residential.Models;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    public interface IResidentialCoresService
    {
        #region Item design

        Task<ItemModel?> GetItemAsync(string itemId);

        Task<CoreVoltageDesignModel?> GetResidentialCoreVoltageDesignAsync(
            string itemId,
            int coreSize,
            CancellationToken cancellationToken);

        #endregion

        #region Plan

        Task<IEnumerable<DateRangeAvailableModel>> GetDateRangeAvailableForTestQueryAsync();
        Task<IEnumerable<DateRangeAvailableModel>> GetDateRangeAvailableForTestQueryAsync_discpiso();

        Task<Cores.QueryResult<string>> GetItemsPlannedToBeManufacturedAsync(int page, int pageSize, CancellationToken cancellationToken);
        Task<Cores.QueryResult<string>> GetItemsPlannedToBeManufacturedAsync_discpiso(int page, int pageSize, CancellationToken cancellationToken);

        Task<Cores.QueryResult<ManufacturedResidentialCoreModel>> GetManufacturedCoresAsync(
            int page,
            int pageSize,
            CancellationToken cancellationToken);

        Task<CoreManufacturingPlanModel?> GetNextCoreToBeManufacturedAsync(string itemId, CancellationToken cancellationToken);

        #endregion

        #region Pattern

        Task<ResidentialCorePatternTestsSummaryModel?> GetResidentialCorePatternTestSummaryAsync();

        Task<ResidentialCoreTestResultModel> TestResidentialCorePatternAsync(
           string testCode,
           double averageVoltage,
           double rmsVoltage,
           double current,
           double temperature,
           double watts,
           double coreTemperature,
           string? stationId,
           CancellationToken cancellationToken);

        #endregion

        #region Tests

        Task<ResidentialCoreTestSummaryModel?> GetResidentialCoreTestSummaryAsync(
            string itemId,
            string batch,
            int serie,
            int sequence,
            CancellationToken cancellationToken);

        Task<ResidentialCoreTestModel?> GetResidentialCoreTestAsync(string testCode);
        Task<ResidentialCoreTestModel?> GetResidentialCoreTestAsync_discpiso(string testCode);

        Task<ResidentialCoreSuggestedCodeResultModel?> GetResidentialCoreSuggestedCodeResultAsync(string testCode);

        Task<ResidentialCoreLocationResultModel?> GetResidentialCoreLocationResultAsync(string testCode);

        Task<ResidentialCoreTestResultModel> TestResidentialCoreAsync(
            string? tag,
            string itemId,
            int coreSize,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string testCode,
            string? stationId,
            CancellationToken cancellationToken);

        Task<ResidentialCoreTestResultModel> ReworkResidentialCoreAsync(
            string itemId,
            int coreSize,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string testCode,
            string? stationId,
            CancellationToken cancellationToken);

        #endregion

        #region Defects

        Task<IEnumerable<CoreTestDefectConceptModel>> GetDefectConceptListAsync(
            int page,
            int pageSize,
            CancellationToken cancellationToken);

        Task<ResidentialCoreTestResultModel> RegisterDefectAsync(
            string testCode,
            string defect,
            CancellationToken cancellationToken);

        #endregion

        #region Store

        Task StoreResidentialCoreAsync(Guid coreTestId, string location, string? associatedCode, bool force, CancellationToken cancellationToken);

        #endregion

        #region Supply

        Task<IEnumerable<InsulationMachineModel>> GetWindingMachinesAsync(CancellationToken cancellationToken);

        Task<IEnumerable<ResidentialSuppliedCoreTestModel>> GetResidentialCoreSupplyByOrderAsync(string itemId, string batch, int serie, CancellationToken cancellationToken);

        Task AddSupplyCoreAsync(AddSupplyCoreModel supply, CancellationToken cancellation);

        Task RemoveSupplyCoreAsync(Guid id, CancellationToken cancellation);

        #endregion
    }
}