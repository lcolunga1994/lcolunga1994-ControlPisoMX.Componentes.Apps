namespace ProlecGE.ControlPisoMX.Cores.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Microsoft.Extensions.Configuration;

    using Services;

    public class TestTermoparConnectivityCommand : IRequest<bool> { }

    public class TestTermoparConnectivityCommandHandler : IRequestHandler<TestTermoparConnectivityCommand, bool>
    {
        #region Fields

        private readonly ITemperatureReader temperatureReader;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public TestTermoparConnectivityCommandHandler(IConfiguration configuration, ITemperatureReader temperatureReader)
        {
            this._configuration = configuration;
            this.temperatureReader = temperatureReader;
        }

        #endregion

        #region Methods

        public async Task<bool> Handle(TestTermoparConnectivityCommand request, CancellationToken cancellationToken)
        {
            if (_configuration.GetValue<bool>("DeviceIR:UseSerialPort"))
            {
                double coreTemperature = await temperatureReader
                    .ReadAsync(cancellationToken)
                    .ConfigureAwait(false);

                return coreTemperature != -10d;
            }

            return true;
        }

        #endregion
    }
}