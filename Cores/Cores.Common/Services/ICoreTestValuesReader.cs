namespace ProlecGE.ControlPisoMX.Cores.Services
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICoreTestValuesReader
    {
        #region Methods

        Task<CoreTestsValues> ReadAsync(double testVoltage, CancellationToken cancellationToken);

        #endregion
    }
}