namespace ProlecGE.ControlPisoMX.Cores.Testing.Industrial.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Models;

    public class TestIndustrialPatternCommand : IRequest<IndustrialCoreTestResultModel>
    {
        #region Constructor

        public TestIndustrialPatternCommand(
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

    public class TestIndustrialPatternCommandHandler : IRequestHandler<TestIndustrialPatternCommand, IndustrialCoreTestResultModel>
    {
        #region Fields

        private readonly IIndustrialCoresService service;

        #endregion

        #region Constructor

        public TestIndustrialPatternCommandHandler(IIndustrialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<IndustrialCoreTestResultModel> Handle(
            TestIndustrialPatternCommand request,
            CancellationToken cancellationToken)
            => await service
            .TestIndustrialCorePatternAsync(
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