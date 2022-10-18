namespace ProlecGE.ControlPisoMX.Cores
{
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Services;

    public class TestCodeTextValidator : ITestCodeTextValidator
    {
        #region Methods

        public async Task<bool> ReadAsync(string? textToValidate, CancellationToken cancellationToken)
        {
            Regex rgx = new(@"^[A-Z0-9]{8}$");

            await Task.Delay(100, cancellationToken);

            return textToValidate != null && rgx.IsMatch(input: textToValidate);
        }

        #endregion
    }
}