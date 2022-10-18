namespace ProlecGE.ControlPisoMX.Cores.Services
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICalibrationStatusValidateReader
    {
        Task<bool> ReadAsync(CancellationToken cancellationToken);
    }
}