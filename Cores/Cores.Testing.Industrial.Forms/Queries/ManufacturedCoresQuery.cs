//namespace ProlecGE.ControlPisoMX.Cores.Testing.Industrial.Queries
//{
//    using System.Threading;
//    using System.Threading.Tasks;

//    using MediatR;

//    using ProlecGE.ControlPisoMX;
//    using ProlecGE.ControlPisoMX.BFWeb.Components;    
//    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;

//    public class ManufacturedCoresQuery
//        : IRequest<QueryResult<ManufacturedResidentialCoreModel>>
//    {
//        #region Constructor

//        public ManufacturedCoresQuery(
//            int page,
//            int pageSize)
//        {
//            Page = page;
//            PageSize = pageSize;
//        }

//        #endregion

//        #region Properties

//        public int Page { get; set; }

//        public int PageSize { get; set; }

//        #endregion
//    }

//    public class ManufacturedCoresQueryHandler
//        : IRequestHandler<ManufacturedCoresQuery, QueryResult<ManufacturedResidentialCoreModel>>
//    {
//        #region Fields

//        private readonly IIndustrialCoresService service;

//        #endregion

//        #region Constructor

//        public ManufacturedCoresQueryHandler(IIndustrialCoresService service)
//        {
//            this.service = service;
//        }
//        #endregion

//        #region Methods

//        public async Task<QueryResult<ManufacturedResidentialCoreModel>> Handle(
//            ManufacturedCoresQuery request,
//            CancellationToken cancellationToken)
//        {
//            return await service
//                .GetManufacturedCoresAsync(
//                    request.Page,
//                    request.PageSize,
//                    cancellationToken)
//                .ConfigureAwait(false);
//        }

//        #endregion
//    }
//}