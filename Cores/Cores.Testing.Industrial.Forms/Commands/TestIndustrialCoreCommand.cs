namespace ProlecGE.ControlPisoMX.Cores.Testing.Industrial.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Models;

    public class TestIndustrialCoreCommand : IRequest<IndustrialCoreTestResultModel>
    {
        #region Constructor

        public TestIndustrialCoreCommand(
            string itemId,
            string batch,
            int serie,
            CoreSizes coreSize,
            double foilWidth,
            string testCode,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string stationId)
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
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        public string Batch { get; }

        public int Serie { get; }

        public CoreSizes CoreSize { get; }

        public double FoilWidth { get; }

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

    public class TestIndustrialCoreCommandHandler : IRequestHandler<TestIndustrialCoreCommand, IndustrialCoreTestResultModel>
    {
        #region Fields

        private readonly IIndustrialCoresService service;

        #endregion

        #region Constructor

        public TestIndustrialCoreCommandHandler(IIndustrialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<IndustrialCoreTestResultModel> Handle(TestIndustrialCoreCommand request, CancellationToken cancellationToken)
        {
            return await service.TestIndustrialCoreAsync(
                new TestCoreParametersModel(
                    request.ItemId,
                    request.Batch,
                    request.Serie,
                    (int)request.CoreSize,
                    request.FoilWidth,
                    request.TestCode,
                    request.AverageVoltage,
                    request.RMSVoltage,
                    request.Current,
                    request.Temperature,
                    request.Watts,
                    request.CoreTemperature,
                    request.StationId),
                cancellationToken);
        }

        #endregion
    }
}