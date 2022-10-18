namespace ProlecGE.ControlPisoMX.Cores
{
    using System.Threading;
    using System.Threading.Tasks;

    using Services;

    public class TemperatureDummyReader : ITemperatureReader
    {
        public async Task<double> ReadAsync(CancellationToken cancellationToken) => await Task.FromResult(29d);
    }

    public class CoreTestValuesDummyReader : ICoreTestValuesReader
    {
        public async Task<CoreTestsValues> ReadAsync(double testVoltage, CancellationToken cancellationToken)
        {
            CoreTestsValues coreTestValues;

            await Task.Delay(100, cancellationToken)
                .ConfigureAwait(false);

            if (testVoltage == 50d)
            {
                //Amarillo
                //coreTestValues = new CoreTestsValues(
                //        49.43d,
                //        50d,
                //        1.696d,
                //        17.954d,
                //        66.06d);

                //Verde
                //coreTestValues = new CoreTestsValues(
                //        49.378d,
                //        50d,
                //        1.626d,
                //        18.019d,
                //        64.28d);

                //Azul
                coreTestValues = new CoreTestsValues(
                        49.375d,
                        50d,
                        1.608d,
                        18.092d,
                        61.99d);
            }
            else
            {
                coreTestValues = new CoreTestsValues(
                    49.361d,
                    50d,
                    1.44d,
                    15.21,
                    58.19);
            }

            return coreTestValues;
        }
    }
}