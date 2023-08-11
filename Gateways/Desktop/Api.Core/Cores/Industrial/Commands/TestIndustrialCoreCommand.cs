namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Commands
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Models;

    using CoresModels = ControlPisoMX.Cores.Models;
    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using Microsoft.Extensions.Configuration;

    public class TestIndustrialCoreCommand : IRequest<IndustrialCoreTestResultModel>
    {
        #region Constructor

        public TestIndustrialCoreCommand(
            string itemId,
            string batch,
            int serie,
            int coreSize,
            double foilWidth,
            string testCode,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string? stationId,
            string? idSub)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            CoreSize = coreSize;
            FoilWidth = foilWidth;
            TestCode = testCode;
            AverageVoltage = averageVoltage;
            RMSVoltage = rmsVoltage;
            Current = current;
            Temperature = temperature;
            Watts = watts;
            CoreTemperature = coreTemperature;
            StationId = stationId;
            IdSub = idSub;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int CoreSize { get; set; }

        public double FoilWidth { get; set; }

        public string TestCode { get; internal set; }

        public double AverageVoltage { get; set; }

        public double RMSVoltage { get; set; }

        public double Current { get; set; }

        public double Temperature { get; set; }

        public double Watts { get; set; }

        public double CoreTemperature { get; set; }

        public string? StationId { get; set; }
        
        public string? IdSub { get; set; }

        #endregion
    }

    public class TestIndustrialCoreCommandHandler : IRequestHandler<TestIndustrialCoreCommand, IndustrialCoreTestResultModel>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public TestIndustrialCoreCommandHandler(ControlPisoMX.Cores.IMicroservice cores, IConfiguration configuration)
        {
            this.cores = cores;
            this._configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task<IndustrialCoreTestResultModel> Handle(
            TestIndustrialCoreCommand request,
            CancellationToken cancellationToken)
        {
            //CoresModels.IndustrialCoreTestResultModel testResult = await cores.TestIndustrialCoreAsync(
            //    request.ItemId,
            //    request.Batch,
            //    request.Serie,
            //    request.CoreSize,
            //    request.FoilWidth,
            //    request.TestCode,
            //    request.AverageVoltage,
            //    request.RMSVoltage,
            //    request.Current,
            //    request.Temperature,
            //    request.Watts,
            //    request.CoreTemperature,
            //    request.StationId,
            //    cancellationToken);

            CoresModels.IndustrialCoreTestResultModel testResult = bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ?
                await cores.TestIndustrialCoreAsync(
               request.ItemId,
               request.Batch,
               request.Serie,
               request.CoreSize,
               request.FoilWidth,
               request.TestCode,
               request.AverageVoltage,
               request.RMSVoltage,
               request.Current,
               request.Temperature,
               request.Watts,
               request.CoreTemperature,
               request.StationId,
               request.IdSub,
               cancellationToken)
                : await cores.TestIndustrialCoreAsync_sqlctp(
               request.ItemId,
               request.Batch,
               request.Serie,
               request.CoreSize,
               request.FoilWidth,
               request.TestCode,
               request.AverageVoltage,
               request.RMSVoltage,
               request.Current,
               request.Temperature,
               request.Watts,
               request.CoreTemperature,
               request.StationId,
               request.IdSub,
               cancellationToken);

            return await Task.FromResult(new IndustrialCoreTestResultModel(
                testResult.ItemId,
                testResult.Batch,
                testResult.Serie,
                testResult.TestCode,
                (CoreTestResult)testResult.Result,
                testResult.CorrectedWatts,
                testResult.CurrentPercentage,
                testResult.Warnings.Select(warning => (CoreTestWarning)warning).ToArray(),
                testResult.TotalCores,
                testResult.TestedCores,
                testResult.TotalTests,
                (CoreSizes)testResult.CoreSize));
        }

        #endregion
    }
}