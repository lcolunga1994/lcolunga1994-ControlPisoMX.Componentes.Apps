namespace ProlecGE.ControlPisoMX.Cores
{
    using System.Threading;
    using System.Threading.Tasks;

    using Services;

    public class RackLocationLengthValidator : IRackLocationLengthValidator
    {
        #region Methods

        public async Task<bool> ReadAsync(string? textToValidate, CancellationToken cancellationToken)
        {
            await Task.Delay(100, cancellationToken);

            return textToValidate != null && textToValidate.Length <= 7;
        }

        #endregion
    }
}