namespace ProlecGE.ControlPisoMX.AMO.Testing.Residential.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;

    public class TestResidentialPatternCommand : IRequest<ResidentialCoreTestResultModel>
    {
        #region Constructor

        public TestResidentialPatternCommand(
            string testCode,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string? stationId)
        {
            TestCode = testCode;
            AverageVoltage = averageVoltage;
            RMSVoltage = rmsVoltage;
            Current = current;
            Temperature = temperature;
            Watts = watts;
            CoreTemperature = coreTemperature;
            StationId = stationId;
        }

        #endregion

        #region Properties

        public string TestCode { get; }

        public double AverageVoltage { get; }

        public double RMSVoltage { get; }

        public double Current { get; }

        public double Temperature { get; }

        public double Watts { get; }

        public double CoreTemperature { get; }

        public string? StationId { get; }

        #endregion
    }

    public class TestResidentialPatternCommandHandler : IRequestHandler<TestResidentialPatternCommand, ResidentialCoreTestResultModel>
    {
        #region Fields

        private readonly IResidentialCoresService service;

        #endregion

        #region Constructor

        public TestResidentialPatternCommandHandler(IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<ResidentialCoreTestResultModel> Handle(
            TestResidentialPatternCommand request,
            CancellationToken cancellationToken)
            => await service
            .TestResidentialCorePatternAsync(
                request.TestCode,
                request.AverageVoltage,
                request.RMSVoltage,
                request.Current,
                request.Temperature,
                request.Watts,
                request.CoreTemperature,
                request.StationId,
                cancellationToken)
            .ConfigureAwait(false);

        #endregion
    }
}
