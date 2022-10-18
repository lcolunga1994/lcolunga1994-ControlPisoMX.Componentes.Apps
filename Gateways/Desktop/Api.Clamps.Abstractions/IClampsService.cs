namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using Models;

    public interface IClampsService
    {
        #region Queries

        Task<IEnumerable<OrderWithClampsModel>> GetOrdersToPlaceClampsAsync();

        Task RemoveClampAsync(string itemId, string batch, int serie, int sequence);

        Task UpdateOrder(string itemId, string batch, int serie);

        Task UpdateImpetiOrder(string itemId, string batch, int serie);

        #endregion
    }
}