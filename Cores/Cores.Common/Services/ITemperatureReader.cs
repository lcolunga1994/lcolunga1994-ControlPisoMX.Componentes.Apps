namespace ProlecGE.ControlPisoMX.Cores.Services
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface ITemperatureReader
    {
        #region Methods
        
        Task<double> ReadAsync(CancellationToken cancellationToken);

        #endregion
    }
}