namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    public interface ICoresSupplyService
    {
        Task<IEnumerable<MOManufacturingStatusModel>> GetManufacturingOrdersAvailableToSupplyAsync(DateTime date, string machine, CancellationToken cancellationToken);

        Task AddOrdersToSupplyListAsync(List<OrderParameterModel> orders, CancellationToken cancellation);

        Task<IEnumerable<MOSupplyItemModel>> GetPendingSuppliesAsync(CancellationToken cancellationToken);

        Task<MOSupplyItemTagModel?> GetSupplyTagAsync(Guid manufacturingOrderId);

        Task<MOSupplySummaryModel?> GetManufacturingOrderSupplySummary(string itemId, string batch);

        Task ConfirmSupplyAsync(string itemId, string batch, int serie);

        Task AuthorizeReprintAsync(string itemId, string batch, int serie);

        Task<IEnumerable<MOSupplyItemModel>> GetSuppliesToReprintAsync();

        Task<SupplyCoreResultModel?> SupplyCoresAsync(string itemId, string batch, int serie, bool force, string user);

        Task<SupplyCoreResultModel?> SupplyCoresAsync_discpiso(string itemId, string batch, int serie, bool force, string user);

        Task ReprintAsync(Guid manufacturingOrderId, string user);
    }
}