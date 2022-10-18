namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Queries
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Residential.Models;

    public class ResidentialCoreTestSummaryQuery
        : IRequest<ResidentialCoreTestSummaryModel?>
    {
        #region Constructor

        public ResidentialCoreTestSummaryQuery(
            string itemId,
            string batch,
            int serie,
            int sequence)
        {
            if (string.IsNullOrWhiteSpace(itemId))
            {
                throw new UserException("El artículo no puede ser vacío o espacios en blanco.");
            }

            if (string.IsNullOrWhiteSpace(batch))
            {
                throw new UserException("El lote no puede ser vacío o espacios en blanco.");
            }

            ItemId = itemId.Trim();
            Batch = batch.Trim();
            Serie = serie;
            Sequence = sequence;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int Sequence { get; set; }
        
        #endregion
    }

    public class ResidentialCoreTestSummaryQueryHandler
       : IRequestHandler<ResidentialCoreTestSummaryQuery, ResidentialCoreTestSummaryModel?>
    {
        #region Fields

        private readonly ControlPisoMX.ERP.IMicroservice erp;
        private readonly ControlPisoMX.Cores.IMicroservice cores;

        #endregion

        #region Constructor

        public ResidentialCoreTestSummaryQueryHandler(
            ControlPisoMX.ERP.IMicroservice erp,
            ControlPisoMX.Cores.IMicroservice cores)
        {
            this.erp = erp;
            this.cores = cores;
        }

        #endregion

        #region Methods

        public async Task<ResidentialCoreTestSummaryModel?> Handle(
            ResidentialCoreTestSummaryQuery request,
            CancellationToken cancellationToken)
        {
            ResidentialCoreTestSummaryModel? coreTestSummary = null;

            ControlPisoMX.ERP.Models.ItemModel? item = await erp
                .GetItemAsync(request.ItemId, cancellationToken)
                .ConfigureAwait(false);

            if (item == null)
            {
                throw new UserException($"El artículo '{request.ItemId}' no existe.");
            }

            ControlPisoMX.Cores.Models.ResidentialCoreTestSummaryModel? coreTest = await cores
                .GetResidentialCoreTestSummaryAsync(
                        request.ItemId,
                        request.Batch,
                        request.Serie,
                        request.Sequence,
                    cancellationToken)
                .ConfigureAwait(false);

            if (coreTest != null)
            {
                coreTestSummary = new ResidentialCoreTestSummaryModel(
                    coreTest.ItemId,
                    coreTest.Batch,
                    coreTest.Serie,
                    coreTest.Sequence)
                {
                    TotalCores = coreTest.TotalCores,
                    TestedCores = coreTest.TestedCores
                };
            }

            return coreTestSummary;
        }

        #endregion
    }
}