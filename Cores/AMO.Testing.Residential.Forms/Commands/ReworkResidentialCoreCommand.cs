namespace ProlecGE.ControlPisoMX.AMO.Testing.Residential.Commands
{
    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;

    public class ReworkResidentialCoreCommand : IRequest<ResidentialCoreTestResultModel>
    {
        #region Constructor

        public ReworkResidentialCoreCommand(
            string itemId,
            CoreSizes coreSize,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string testCode,
            string stationId)
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

        public string ItemId { get; }

        public CoreSizes CoreSize { get; }

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

    public class ReworkResidentialCoreCommandHandler : IRequestHandler<ReworkResidentialCoreCommand, ResidentialCoreTestResultModel>
    {
        #region Fields

        private readonly IResidentialCoresService service;

        #endregion

        #region Constructor

        public ReworkResidentialCoreCommandHandler(IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<ResidentialCoreTestResultModel> Handle(ReworkResidentialCoreCommand request, CancellationToken cancellationToken)
        {
            return await service.ReworkResidentialCoreAsync(
                request.ItemId,
                (int)request.CoreSize,
                request.AverageVoltage,
                request.RMSVoltage,
                request.Current,
                request.Temperature,
                request.Watts,
                request.CoreTemperature,
                request.TestCode,
                request.StationId,
                cancellationToken);
        }

        #endregion
    }
}
