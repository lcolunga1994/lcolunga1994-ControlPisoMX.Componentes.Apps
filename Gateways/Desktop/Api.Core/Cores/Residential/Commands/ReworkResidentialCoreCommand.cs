namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Commands
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Residential.Models;

    using CoresModels = ControlPisoMX.Cores.Models;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using Microsoft.Extensions.Configuration;

    public class ReworkResidentialCoreCommand : IRequest<ResidentialCoreTestResultModel>
    {
        #region Constructor

        public ReworkResidentialCoreCommand(
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

    public class ReworkResidentialCoreCommandHandler : IRequestHandler<ReworkResidentialCoreCommand, ResidentialCoreTestResultModel>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;
        private readonly ControlPisoMX.ERP.IMicroservice erp;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public ReworkResidentialCoreCommandHandler(
            ControlPisoMX.Cores.IMicroservice cores,
            ControlPisoMX.ERP.IMicroservice erp, IConfiguration configuration)
        {
            this.cores = cores;
            this.erp = erp;
            this._configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task<ResidentialCoreTestResultModel> Handle(
            ReworkResidentialCoreCommand request,
            CancellationToken cancellationToken)
        {
            ControlPisoMX.ERP.Models.ItemModel item = bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ?
            await GetItemAsync(request.ItemId, cancellationToken).ConfigureAwait(false) :
            await GetItemAsync_discpiso(request.ItemId, cancellationToken).ConfigureAwait(false);

            ControlPisoMX.ERP.Models.ItemVoltageDesignModel itemVoltageDesign = bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ?
            await GetItemVoltageDesignAsync(item.ItemId, item.DesignId, request.CoreSize, cancellationToken).ConfigureAwait(false):
            await GetItemVoltageDesignAsync_LN(item.ItemId, item.DesignId, request.CoreSize,int.Parse(_configuration.GetSection("Cia").Value.ToString()), cancellationToken).ConfigureAwait(false);

            CoresModels.ResidentialCoreTestResultModel coreTestResult = bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ?
                await cores.ReworkResidentialCoreAsync(
                    item.ItemId,
                    item.DesignId,
                    item.ProductLine,
                    item.Phases,
                    (int)request.CoreSize,
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
                .ConfigureAwait(false):
                await cores.ReworkResidentialCoreAsync_sqlctp(
                    item.ItemId,
                    item.DesignId,
                    item.ProductLine,
                    item.Phases,
                    (int)request.CoreSize,
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

        private async Task<ControlPisoMX.ERP.Models.ItemModel> GetItemAsync(
            string itemId,
            CancellationToken cancellationToken)
        {
            ControlPisoMX.ERP.Models.ItemModel? item = await erp.GetItemAsync(itemId, cancellationToken)
                .ConfigureAwait(false);

            return item ?? throw new UserException($"El artículo '{itemId}' no existe.");
        }
        private async Task<ControlPisoMX.ERP.Models.ItemModel> GetItemAsync_discpiso(
            string itemId,
            CancellationToken cancellationToken)
        {
            ControlPisoMX.ERP.Models.ItemModel? item = await erp.GetItemAsync_discpiso(itemId, cancellationToken)
                .ConfigureAwait(false);

            return item ?? throw new UserException($"El artículo '{itemId}' no existe.");
        }

        private async Task<ControlPisoMX.ERP.Models.ItemVoltageDesignModel> GetItemVoltageDesignAsync(
           string itemId,
           string designId,
           int coreSize,
           CancellationToken cancellationToken)
        {
            ControlPisoMX.ERP.Models.ItemVoltageDesignModel? itemVoltageDesign = await erp
                .GetItemVoltageDesignAsync(itemId, designId, coreSize, cancellationToken)
                .ConfigureAwait(false);

            return itemVoltageDesign == null
                ? throw new UserException("No existe información de diseño.", "Cores.TestCoreCommand.NotDesignInformation")
                : itemVoltageDesign.Limits == null
                || !itemVoltageDesign.Limits.Any()
                ? throw new UserException("No existe información de diseño.", "Cores.TestCoreCommand.NotLimitsDesignInformation")
                : itemVoltageDesign;
        }
        private async Task<ControlPisoMX.ERP.Models.ItemVoltageDesignModel> GetItemVoltageDesignAsync_LN(
           string itemId,
           string designId,
           int coreSize,
           int cia,
           CancellationToken cancellationToken)
        {
            ControlPisoMX.ERP.Models.ItemVoltageDesignModel? itemVoltageDesign = await erp
                .GetItemVoltageDesignAsync_LN(itemId, designId, coreSize,cia, cancellationToken)
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