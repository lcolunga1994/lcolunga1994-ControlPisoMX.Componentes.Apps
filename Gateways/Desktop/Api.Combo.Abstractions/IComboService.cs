namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using Models;

    public interface IComboService
    {

        Task<IEnumerable<ComboOrderDesignModel>> GetComboOrderDesignAsync(string itemId, CancellationToken cancellationToken);
        
    }
}
