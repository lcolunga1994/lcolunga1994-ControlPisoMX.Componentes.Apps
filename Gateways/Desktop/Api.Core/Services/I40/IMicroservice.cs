namespace ProlecGE.ControlPisoMX.I40
{
    using System.Threading;
    using System.Threading.Tasks;

    using Models;

    public interface IMicroservice
    {
        #region Methods

        Task<QueryResult<ManufacturedCoreModel>> GetManufacturedCoresAsync(
            int page,
            int pageSize,
            CancellationToken cancellationToken);

        Task<ManufacturedCoreModel?> GetManufacturedCoreAsync(
            string tag,
            CancellationToken cancellationToken);

        Task<string?> GetCoreTagAsync(
            string itemId,
            string batch,
            int sequence);

        Task SetCoreAsTestedAsync(string tag, CancellationToken cancellationToken);
        
        Task UpdateCoreTestAvailabilityAsync();

        #endregion
    }
}