namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Commands
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Residential.Models;

    using CoresModels = ControlPisoMX.Cores.Models;

    public class TestResidentialCoreCommand : IRequest<ResidentialCoreTestResultModel>
    {
        #region Constructor

        public TestResidentialCoreCommand(
            string? tag,
            string itemId,
            int coreSize,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string testCode,
            string? stationId)
        {
            if (string.IsNullOrWhiteSpace(itemId))
            {
                throw new UserException("El artículo no puede ser vacío o espacios en blanco.");
            }

            if (string.IsNullOrWhiteSpace(testCode))
            {
                throw new UserException("El identificador de la prueba no puede ser vacío o espacios en blanco.");
            }

            ItemId = itemId.Trim();
            CoreSize = coreSize;
            Tag = tag;
            AverageVoltage = averageVoltage;
            RMSVoltage = rmsVoltage;
            Current = current;
            Temperature = temperature;
            Watts = watts;
            CoreTemperature = coreTemperature;
            TestCode = testCode.Trim();
            StationId = stationId;
        }

        #endregion

        #region Properties

        public string? Tag { get; set; }


        public string ItemId { get; set; }

        public int CoreSize { get; set; }

        public double AverageVoltage { get; set; }

        public double RMSVoltage { get; set; }

        public double Current { get; set; }

        public double Temperature { get; set; }

        public double Watts { get; set; }

        public double CoreTemperature { get; set; }

        public string TestCode { get; set; }

        public string? StationId { get; }

        #endregion
    }

    public class TestResidentialCoreCommandHandler : IRequestHandler<TestResidentialCoreCommand, ResidentialCoreTestResultModel>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;
        private readonly ERP.IMicroservice erp;
        private readonly I40.IMicroservice i40;

        #endregion

        #region Constructor

        public TestResidentialCoreCommandHandler(
            ControlPisoMX.Cores.IMicroservice cores,
            ERP.IMicroservice erp,
            I40.IMicroservice i40)
        {
            this.cores = cores;
            this.erp = erp;
            this.i40 = i40;
        }

        #endregion

        #region Methods

        public async Task<ResidentialCoreTestResultModel> Handle(
            TestResidentialCoreCommand request,
            CancellationToken cancellationToken)
        {
            ERP.Models.ItemModel item =
                await GetItemAsync(request.ItemId, cancellationToken)
                .ConfigureAwait(false);

            ERP.Models.ItemVoltageDesignModel itemVoltageDesign =
                await GetItemVoltageDesignAsync(item.ItemId, item.DesignId, request.CoreSize, cancellationToken)
                .ConfigureAwait(false);

            CoresModels.ResidentialCoreTestResultModel coreTestResult = await cores.TestResidentialCoreAsync(
                    request.Tag,
                    item.ItemId,
                    item.DesignId,
                    request.CoreSize,
                    itemVoltageDesign.KVA,
                    itemVoltageDesign.PrimaryVoltage,
                    itemVoltageDesign.SecondaryVoltage,
                    itemVoltageDesign.TestVoltage,
                    itemVoltageDesign.Limits
                        .Select(l => new CoresModels.ItemVoltageLimitModel(l.Color, l.Min, l.Max))
                        .ToArray(),
                    request.AverageVoltage,
                    request.RMSVoltage,
                    request.Current,
                    request.Temperature,
                    request.Watts,
                    request.CoreTemperature,
                    request.TestCode,
                    request.StationId,
                    cancellationToken)
                .ConfigureAwait(false);

            if (!string.IsNullOrWhiteSpace(request.Tag))
            {
                await i40.SetCoreAsTestedAsync(request.Tag, cancellationToken).ConfigureAwait(false);
            }

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

        private async Task<ERP.Models.ItemModel> GetItemAsync(
            string itemId,
            CancellationToken cancellationToken)
        {
            ERP.Models.ItemModel? item = await erp.GetItemAsync(itemId, cancellationToken)
                .ConfigureAwait(false);

            return item ?? throw new UserException($"El artículo '{itemId}' no existe.");
        }

        private async Task<ERP.Models.ItemVoltageDesignModel> GetItemVoltageDesignAsync(
           string itemId,
           string designId,
           int coreSize,
           CancellationToken cancellationToken)
        {
            ERP.Models.ItemVoltageDesignModel? itemVoltageDesign = await erp
                .GetItemVoltageDesignAsync(itemId, designId, coreSize, cancellationToken)
                .ConfigureAwait(false);

            return itemVoltageDesign == null
                ? throw new UserException("No existe información de diseño.", "Cores.TestCoreCommand.NotDesignInformation")
                : itemVoltageDesign.Limits == null
                || !itemVoltageDesign.Limits.Any()
                ? throw new UserException("No existe información de diseño.", "Cores.TestCoreCommand.NotLimitsDesignInformation")
                : itemVoltageDesign;
        }

        #endregion
    }
}