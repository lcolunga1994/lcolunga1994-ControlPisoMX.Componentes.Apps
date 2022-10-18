namespace ProlecGE.ControlPisoMX.Cores.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Services;

    public class ReadTemperatureCommand : IRequest<double> { }

    public class ReadTemperatureCommandHandler : IRequestHandler<ReadTemperatureCommand, double>
    {
        #region Fields

        private readonly ITemperatureReader temperatureReader;

        #endregion

        #region Constructor

        public ReadTemperatureCommandHandler(ITemperatureReader temperatureReader)
        {
            this.temperatureReader = temperatureReader;
        }

        #endregion

        #region Methods

        public async Task<double> Handle(ReadTemperatureCommand request, CancellationToken cancellationToken)
        {
            return await temperatureReader
                .ReadAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}