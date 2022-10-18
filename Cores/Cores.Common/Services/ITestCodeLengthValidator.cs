namespace ProlecGE.ControlPisoMX.Cores.Services
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface ITestCodeLengthValidator
    {
        Task<bool> ReadAsync(string textToValidate, CancellationToken cancellationToken);
    }
}