namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using Cores.Industrial.Models;

    public interface IIndustrialCoresService
    {
        #region Pattern

        Task<IndustrialCorePatternModel?> GetIndustrialCorePatternDesignAsync();

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

        Task<IEnumerable<double>?> GetIndustrialCoreFoilWidthsAsync(string itemId, int coreSize);

        Task<IndustrialItemVoltageDesignModel?> GetIndustrialCoreVoltageDesignAsync(string itemId, int coreSize, double foilWidth);

        #endregion

        #region Tests

        Task<IndustrialCoreTestSummaryModel?> GetIndustrialCoreTestSummaryAsync(
            string itemId,
            string batch,
            int serie,
            CancellationToken cancellationToken);

        Task<IndustrialCoreTestResultModel?> GetIndustrialCoreTestResultAsync(string testCode);

        Task<IndustrialCoreTestModel?> GetIndustrialCoreTestAsync(string testCode);

        Task<IndustrialCoreSuggestedCodeResultModel?> GetIndustrialCoreSuggestedCodeResultAsync(string testCode);

        Task<IndustrialCoreLocationResultModel?> GetIndustrialCoreLocationResultAsync(string testCode);

        Task<IndustrialCoreTestResultModel> TestIndustrialCoreAsync(TestCoreParametersModel command, CancellationToken cancellationToken);

        #endregion

        #region Store

        Task StoreIndustrialCoreAsync(Guid coreTestId, string location, string? associatedCode, bool force, CancellationToken cancellationToken);

        #endregion
    }
}