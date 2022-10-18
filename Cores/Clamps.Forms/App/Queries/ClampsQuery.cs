namespace ProlecGE.ControlPisoMX.Clamps.Forms.App.Queries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Models;

    public class ClampsQuery : IRequest<IEnumerable<OrderWithClampsModel>> { }

    internal class ClampsQueryHandler : IRequestHandler<ClampsQuery, IEnumerable<OrderWithClampsModel>>
    {
        #region Fields

        private readonly BFWeb.Components.IClampsService service;

        #endregion

        #region Constructor

        public ClampsQueryHandler(BFWeb.Components.IClampsService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<OrderWithClampsModel>> Handle(ClampsQuery request, CancellationToken cancellationToken)
        {
            return await service.GetOrdersToPlaceClampsAsync()
                .ConfigureAwait(false);
        }

        #endregion
    }
}