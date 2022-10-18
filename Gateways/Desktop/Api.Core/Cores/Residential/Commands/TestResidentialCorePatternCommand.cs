namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Commands
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Residential.Models;

    public class TestResidentialCorePatternCommand : IRequest<ResidentialCoreTestResultModel>
    {
        #region Constructor

        public TestResidentialCorePatternCommand(
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

    public class TestResidentialCorePatternCommandHandler : IRequestHandler<TestResidentialCorePatternCommand, ResidentialCoreTestResultModel>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;
        private readonly ControlPisoMX.I40.IMicroservice i40;

        #endregion

        #region Constructor

        public TestResidentialCorePatternCommandHandler(
            ControlPisoMX.Cores.IMicroservice cores,
            I40.IMicroservice i40)
        {
            this.cores = cores;
            this.i40 = i40;
        }

        #endregion

        #region Methods

        public async Task<ResidentialCoreTestResultModel> Handle(TestResidentialCorePatternCommand request, CancellationToken cancellationToken)
        {
            ControlPisoMX.Cores.Models.ResidentialCoreTestResultModel? coreTestResult = await cores
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

            await i40.UpdateCoreTestAvailabilityAsync().ConfigureAwait(false);

            return new ResidentialCoreTestResultModel(
                coreTestResult.ItemId,
                coreTestResult.Batch,
                coreTestResult.Serie,
                coreTestResult.Sequence,
                (ProductLine)(int)coreTestResult.ProductLine,
                coreTestResult.TestCode,
                (CoreTestResult)(int)coreTestResult.Status,
                coreTestResult.CorrectedWatts,
                coreTestResult.NewWatts,
                coreTestResult.CurrentPercentage,
                (CoreLimitColor)(int)coreTestResult.Color,
                coreTestResult.Warnings.Select(warning => (CoreTestWarning)(int)warning).ToArray(),
                coreTestResult.TotalCores,
                coreTestResult.TestedCores,
                coreTestResult.TotalTests);
        }

        #endregion        
    }
}