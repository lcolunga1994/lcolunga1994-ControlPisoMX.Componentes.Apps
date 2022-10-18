namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Queries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using AutoMapper;

    using MediatR;

    using Residential.Models;

    public class DefectConceptQuery : PaginatedQuery,
        IRequest<IEnumerable<CoreTestDefectConceptModel>>
    {

        #region Constructor

        public DefectConceptQuery(int page = 1, int pageSize = 100)
            : base(page, pageSize)
        {

        }

        #endregion
    }

    public class DefectConceptQueryHandler
        : IRequestHandler<DefectConceptQuery, IEnumerable<CoreTestDefectConceptModel>>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;
        private readonly IMapper mapper;

        #endregion

        #region Constructor

        public DefectConceptQueryHandler(
            ControlPisoMX.Cores.IMicroservice cores,
            IMapper mapper
            )
        {
            this.cores = cores;
            this.mapper = mapper;
        }

        #endregion

        public async Task<IEnumerable<CoreTestDefectConceptModel>> Handle(
            DefectConceptQuery request,
            CancellationToken cancellationToken)
        {
            var defectConceptList = await cores.GetDefectsAsync(
                request.Page,
                request.PageSize,
                cancellationToken)
                .ConfigureAwait(false);

            return mapper.Map<IEnumerable<CoreTestDefectConceptModel>>(defectConceptList);
        }
    }
}