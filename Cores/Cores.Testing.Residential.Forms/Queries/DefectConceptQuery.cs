namespace ProlecGE.ControlPisoMX.Cores.Testing.Residential.Queries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;

    public class DefectConceptQuery 
        : IRequest<IEnumerable<CoreTestDefectConceptModel>>
    {

        #region Constructor

        public DefectConceptQuery(
            int page = 1,
            int pageSize = 100
            )
        {
            Page = page;
            PageSize = pageSize;
        }

        #endregion

        #region Properties

        public int Page { get; }
        public int PageSize { get; }

        #endregion
    }

    public class DefectConceptQueryHandler 
        : IRequestHandler<DefectConceptQuery, IEnumerable<CoreTestDefectConceptModel>>
    {
        #region Fields

        private readonly IResidentialCoresService service;

        #endregion

        #region Constructor

        public DefectConceptQueryHandler(
            IResidentialCoresService service
            )
        {
            this.service = service;
        }

        #endregion

        public async Task<IEnumerable<CoreTestDefectConceptModel>> Handle(
            DefectConceptQuery request, 
            CancellationToken cancellationToken
            )
        {
            return await service
                .GetDefectConceptListAsync(
                request.Page,
                request.PageSize,
                cancellationToken
                )
                .ConfigureAwait(false);
        }
    }
}
