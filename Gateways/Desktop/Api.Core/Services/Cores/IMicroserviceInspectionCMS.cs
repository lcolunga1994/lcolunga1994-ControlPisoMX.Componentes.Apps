namespace ProlecGE.ControlPisoMX.InspectionCMS
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ProlecGE.ControlPisoMX.Cores.Models.InspectionCMS;

    public interface IMicroservice
    {
        Task AcceptInspectionAsync(string itemId, string batch, int serie, string user);
        Task AcceptInspectionAsync_discpiso(string itemId, string batch, int serie, string user);

        Task RejectInspectionAsync(string itemId, string batch, int serie, string machine, string user, string card, string code, CancellationToken cancellation);
        Task RejectInspectionAsync_discpiso(string itemId, string batch, int serie, string machine, string user, string card, string code, CancellationToken cancellation);

        Task<bool> OrderExistsAsync(string itemId, string batch, int serie);
        Task<bool> OrderExistsAsync_discpiso(string itemId, string batch, int serie);

        Task<LastRejectedModel?> LastRejectedAsync(string itemId, string batch, int serie, string code);
    }
}
