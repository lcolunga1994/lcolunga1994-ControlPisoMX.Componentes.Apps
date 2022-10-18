namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Commands
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Models;

    using CoresModels = ControlPisoMX.Cores.Models;

    public class TestIndustrialCorePatternCommand : IRequest<IndustrialCoreTestResultModel>
    {
        #region Constructor

        public TestIndustrialCorePatternCommand(
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

    public class TestIndustrialCorePatternCommandHandler : IRequestHandler<TestIndustrialCorePatternCommand, IndustrialCoreTestResultModel>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;

        #endregion

        #region Constructor

        public TestIndustrialCorePatternCommandHandler(ControlPisoMX.Cores.IMicroservice cores)
        {
            this.cores = cores;
        }

        #endregion

        #region Methods

        public async Task<IndustrialCoreTestResultModel> Handle(TestIndustrialCorePatternCommand request, CancellationToken cancellationToken)
        {
            CoresModels.IndustrialCoreTestResultModel testResult = await cores.TestIndustrialCorePatternAsync(
                request.TestCode,
                request.AverageVoltage,
                request.RMSVoltage,
                request.Current,
                request.Temperature,
                request.Watts,
                request.CoreTemperature,
                request.StationId,
                cancellationToken);

            return await Task.FromResult(new IndustrialCoreTestResultModel(
                testResult.ItemId,
                testResult.Batch,
                testResult.Serie,
                testResult.TestCode,
                (CoreTestResult)(int)testResult.Result,
                testResult.CorrectedWatts,
                testResult.CurrentPercentage,
                testResult.Warnings.Select(warning => (CoreTestWarning)(int)warning).ToArray(),
                testResult.TotalCores,
                testResult.TestedCores,
                testResult.TotalTests,
                (CoreSizes)(int)testResult.CoreSize));
        }

        #endregion
    }
}