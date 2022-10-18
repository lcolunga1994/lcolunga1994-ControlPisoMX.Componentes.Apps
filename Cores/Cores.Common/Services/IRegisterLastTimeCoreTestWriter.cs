namespace ProlecGE.ControlPisoMX.Cores.Services
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRegisterLastTimeCoreTestWriter
    {
        Task WriteAsync(CancellationToken cancellationToken);
    }
}