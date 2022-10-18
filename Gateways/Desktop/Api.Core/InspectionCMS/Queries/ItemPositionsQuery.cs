//namespace ProlecGE.ControlPisoMX.BFWeb.InspectionCMS.Queries
//{
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Threading;
//    using System.Threading.Tasks;

//    using AutoMapper;

//    using MediatR;

//    using ProlecGE.ControlPisoMX.BFWeb.ERP.Models;

//    public class ItemPositionsQuery
//        : IRequest<IEnumerable<PositionModel>>
//    {
//        #region Constructor

//        public ItemPositionsQuery(string itemId)
//        {
//            ItemId = itemId;
//        }

//        #endregion

//        #region Properties

//        public string ItemId { get; set; }

//        #endregion
//    }

//    public class ItemPositionsQueryHandler
//        : IRequestHandler<ItemPositionsQuery, IEnumerable<PositionModel>>
//    {
//        #region Fields

//        private readonly IMapper mapper;
//        private readonly ControlPisoMX.ERP.IMicroservice erp;

//        #endregion

//        #region Constructor

//        public ItemPositionsQueryHandler(IMapper mapper, ControlPisoMX.ERP.IMicroservice erp)
//        {
//            this.mapper = mapper;
//            this.erp = erp;
//        }

//        #endregion

//        #region Methods

//        public async Task<IEnumerable<PositionModel>> Handle(ItemPositionsQuery request, CancellationToken cancellationToken)
//        {
//            ControlPisoMX.ERP.Models.ItemModel? item = await erp
//                .GetItemAsync(request.ItemId, cancellationToken)
//                .ConfigureAwait(false);

//            if (item == null)
//            {
//                return Enumerable.Empty<PositionModel>();
//            }

//            IEnumerable<ControlPisoMX.ERP.Models.PositionModel> positions =
//                await erp.GetPositionsAsync(item.DesignId, cancellationToken)
//                .ConfigureAwait(false);

//            return mapper.Map<IEnumerable<PositionModel>>(positions);
//        }

//        #endregion
//    }
//}