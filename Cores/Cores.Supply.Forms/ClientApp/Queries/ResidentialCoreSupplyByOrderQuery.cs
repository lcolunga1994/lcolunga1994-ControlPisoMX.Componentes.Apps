namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.ClientApp.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;

    public class ResidentialCoreSupplyByOrderQuery : MediatR.IRequest<IEnumerable<ResidentialSuppliedCoreTestModel>>
    {
        #region Constructor

        public ResidentialCoreSupplyByOrderQuery(string itemId, string batch, int serie)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }
        public string Batch { get; set; }

        public int Serie { get; set; }

        #endregion
    }

    public class ResidentialCoreSupplyByOrderQueryHandler : MediatR.IRequestHandler<ResidentialCoreSupplyByOrderQuery, IEnumerable<ResidentialSuppliedCoreTestModel>>
    {
        #region Fields

        private readonly BFWeb.Components.IResidentialCoresService service;

        #endregion

        #region Constructor

        public ResidentialCoreSupplyByOrderQueryHandler(BFWeb.Components.IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<IEnumerable<ResidentialSuppliedCoreTestModel>> Handle(ResidentialCoreSupplyByOrderQuery request, CancellationToken cancellationToken)
        {
            return await service
                .GetResidentialCoreSupplyByOrderAsync(request.ItemId, request.Batch, request.Serie, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}