namespace ProlecGE.ControlPisoMX.Cores
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Models;

    using ProlecGE.ControlPisoMX.Cores.Models.Industrial;
    using ProlecGE.ControlPisoMX.Cores.Models.ManufacturingOrders;
    using ProlecGE.ControlPisoMX.Cores.Models.Residential;

    public interface IMicroservice
    {
        #region Residential

        #region Pattern

        Task<ResidentialCorePatternModel?> GetResidentialCorePatternAsync();

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

        #region Plan

        Task<IEnumerable<DateRangeAvailableModel>> GetDateRangeAvailableForTestQueryAsync();

        Task<IEnumerable<DateRangeAvailableModel>> GetDateRangeAvailableForTestQueryAsync_discpiso();

        Task<QueryResult<string>> GetItemsPlannedToBeTestedAsync(
            int page,
            int pageSize,
            CancellationToken cancellationToken);
        Task<QueryResult<string>> GetItemsPlannedToBeTestedAsync_discpiso(
            int page,
            int pageSize,
            CancellationToken cancellationToken);

        Task<IEnumerable<CoreManufacturingPlanItemModel>> GetPendingManufacturingPlanAsync(int productLine, CancellationToken cancellationToken);

        Task<CoreManufacturingPlanItemModel?> GetNextItemSequenceInPlanAsync(string itemId, CancellationToken cancellationToken);

        Task<CoreManufacturingPlanItemModel?> GetNextItemSequenceInPlanAsync_discpiso(string itemId, CancellationToken cancellationToken);

        #endregion

        #region Tests

        Task<ResidentialCoreTestModel?> GetResidentialCoreTestAsync(string testCode);

        Task<ResidentialCoreTestModel?> GetResidentialCoreTestAsync_discpiso(string testCode);

        Task<ResidentialCoreTestSummaryModel?> GetResidentialCoreTestSummaryAsync(
            string itemId,
            string batch,
            int serie,
            int sequence,
            CancellationToken cancellationToken);

        Task<ResidentialCoreTestResultModel> TestResidentialCoreAsync(
            string? tag,
            string itemId,
            string designId,
            int coreSize,
            double? kva,
            double primaryVoltage,
            double? secondaryVoltage,
            double? testVoltage,
            IEnumerable<ItemVoltageLimitModel> limits,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string testCode,
            string? stationId,
            CancellationToken cancellationToken);
        Task<ResidentialCoreTestResultModel> TestResidentialCoreAsync_sqlctp(
            string? tag,
            string itemId,
            string designId,
            int coreSize,
            double? kva,
            double primaryVoltage,
            double? secondaryVoltage,
            double? testVoltage,
            IEnumerable<ItemVoltageLimitModel> limits,
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
           string designId,
           int productLine,
           int phases,
           int coreSize,
           double? kva,
           double primaryVoltage,
           double? secondaryVoltage,
           double? testVoltage,
           IEnumerable<ItemVoltageLimitModel> limits,
           double averageVoltage,
           double rmsVoltage,
           double current,
           double temperature,
           double watts,
           double coreTemperature,
           string testCode,
           string? stationId,
           CancellationToken cancellationToken);

        Task<ResidentialCoreTestResultModel> ReworkResidentialCoreAsync_sqlctp(
           string itemId,
           string designId,
           int productLine,
           int phases,
           int coreSize,
           double? kva,
           double primaryVoltage,
           double? secondaryVoltage,
           double? testVoltage,
           IEnumerable<ItemVoltageLimitModel> limits,
           double averageVoltage,
           double rmsVoltage,
           double current,
           double temperature,
           double watts,
           double coreTemperature,
           string testCode,
           string? stationId,
           CancellationToken cancellationToken);
        Task<ResidentialCoreTestModel?> GetResidentialCoreTestByOrder(string itemId, string batch, int serie, int sequence);

        #endregion

        #region Defects

        Task<IEnumerable<CoreTestDefectConceptModel>> GetDefectsAsync(
            int page,
            int pageSize,
            CancellationToken cancellationToken);

        Task<ResidentialCoreTestResultModel> RegisterDefectAsync(
            string testCode,
            string defect,
            CancellationToken cancellationToken);

        #endregion

        #region Store

        Task StoreResidentialCoreAsync(Guid coreTestId, string location, string? associatedCode, bool force);

        #endregion

        #region Supply

        Task<IEnumerable<MOSupplyItemStatusModel>> GetSuppliesByBatchAsync(string itemId, string batch);

        Task<IEnumerable<MOSupplyItemModel>> GetSuppliesByScheduleAsync(DateTime scheduledDate, string machine);

        Task<IEnumerable<MOSupplyItemModel>> GetPendingSuppliesAsync(CancellationToken cancellationToken);

        Task AddOrdersToSupplyListAsync(List<MOSupplyParameterModel> orders, CancellationToken cancellation);

        Task<MOPrintableModel?> GetSupplyTagAsync(Guid manufacturingOrderId);

        Task ConfirmSupplyAsync(string itemId, string batch, int serie);

        Task AuthorizeReprintAsync(string itemId, string batch, int serie);

        Task<IEnumerable<MOSupplyItemModel>> GetSuppliesToReprintAsync();

        Task<IEnumerable<ResidentialSuppliedCoreTestModel>> GetResidentialCoreSupplyByOrderAsync(string itemId, string batch, int serie, CancellationToken cancellationToken);

        Task AddSupplyCoreAsync(AddSupplyCoreModel supply, CancellationToken cancellationToken);

        Task RemoveSupplyCoreAsync(Guid id, CancellationToken cancellationToken);

        Task<SupplyCoreResultModel?> SupplyCoresAsync(string itemId, string batch, int serie, bool force, string user);

        Task<SupplyCoreResultModel?> SupplyCoresAsync_discpiso(string itemId, string batch, int serie, bool force, string user);

        Task ReprintAsync(Guid manufacturingOrderId, string user);

        Task RefreshPrintableAttributesAsync(string itemId, string batch, int serie, List<MOPrintableAttributeModel> attributes);

        #endregion

        #endregion

        #region Industrial

        #region Pattern

        Task<IndustrialCorePatternModel?> GetIndustrialCorePatternAsync();

        Task<IndustrialCoreTestResultModel> TestIndustrialCorePatternAsync(
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

        #region Queries

        Task<IEnumerable<double>?> GetCoreFoilWidthsAsync(string itemId, int coreSize);

        Task<IEnumerable<double>?> GetCoreFoilWidthsAsync_sqlctp(string itemId, int coreSize);

        Task<IndustrialItemVoltageDesignModel?> GetIndustrialCoreVoltageDesignAsync(
            string itemId,
            int coreSize,
            double foilWidth);
        Task<IndustrialItemVoltageDesignModel?> GetIndustrialCoreVoltageDesignAsync_sqlctp(
            string itemId,
            int coreSize,
            double foilWidth);


        #endregion

        #region Tests

        Task<IndustrialCoreTestResultModel?> GetIndustrialCoreTestResultAsync(string testCode);

        Task<IndustrialCoreTestModel?> GetIndustrialCoreTestAsync(string testCode);

        Task<IndustrialCoreTestSummaryModel?> GetIndustrialCoreTestSummaryAsync(string itemId, string batch, int serie);

        Task<IndustrialCoreTestResultModel> TestIndustrialCoreAsync(
            string itemId,
            string batch,
            int serie,
            int coreSize,
            double foilWidth,
            string testCode,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string? stationId,
            string idSub,
            CancellationToken cancellationToken);
        Task<IndustrialCoreTestResultModel> TestIndustrialCoreAsync_sqlctp(
            string itemId,
            string batch,
            int serie,
            int coreSize,
            double foilWidth,
            string testCode,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string? stationId,
            string idSub,
            CancellationToken cancellationToken);

        #endregion

        #region Store

        Task StoreIndustrialCoreAsync(Guid coreTestId, string location, string? associatedCode, bool force);

        Task<ResidentialCoreSuggestedCodeModel?> GetResidentialCoreSuggestedCode(string testCode);

        Task<IndustrialCoreSuggestedCodeModel?> GetIndustrialCoreSuggestedCode(string testCode);
        #endregion

        #endregion

        #region Clamps

        Task<IEnumerable<MOSupplyItemModel>> GetOrdersToPlaceClampsAsync(CancellationToken cancellationToken);

        Task RemoveClampOrderAsync(string itemId, string batch, int serie, int sequence, CancellationToken cancellation);
        

        #endregion
    }
}