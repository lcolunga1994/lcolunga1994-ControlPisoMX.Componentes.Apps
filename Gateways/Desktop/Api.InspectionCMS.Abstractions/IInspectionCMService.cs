namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using InspectionCMS.Models;

    public interface IInspectionCMService
    {
        #region Winding

        Task<IEnumerable<WindingModel>> GetItemWindingAsync(string itemId);

        Task<IEnumerable<ArmingAndConnectingModel>> GetArmingAndConnectingAsync(string itemId);

        Task<IEnumerable<InsulationModel>> GetItemInsulationAsync(string itemId);

        Task<ClampModel?> GetItemClampAsync(string itemId);

        Task<LVConnetingModel?> GetItemLVConnetingAsync(string itemId);

        Task<IEnumerable<LaboratoryModel>> GetItemLaboratoryAsync(string itemId);

        Task<IEnumerable<LVConnectorModel>> GetItemLVConnectorAsync(string itemId);

        Task AcceptInspectionAsync(string itemId, string batch, int serie, string user);
        Task AcceptInspectionAsync_discpiso(string itemId, string batch, int serie, string user);

        Task RejectInspectionAsync(string itemId, string batch, int serie, string machine, string user, string card, string code, CancellationToken cancellationToken);
        Task RejectInspectionAsync_discpiso(string itemId, string batch, int serie, string machine, string user, string card, string code, CancellationToken cancellationToken);

        Task<bool> OrderExistsAsync(string itemId, string batch, int serie);
        Task<bool> OrderExistsAsync_discpiso(string itemId, string batch, int serie);

        Task<LastRejectedModel?> LastRejectedAsync(string itemId, string batch, int serie, string code);

        #endregion
    }
}