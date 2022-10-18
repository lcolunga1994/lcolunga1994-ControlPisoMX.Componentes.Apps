namespace ProlecGE.ControlPisoMX.BFWeb.Components.InspectionCMS.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ProlecGE.ControlPisoMX.BFWeb.Components.InspectionCMS.Models;

    internal class ItemWindingQuery : IRequest<IEnumerable<WindingModel>>
    {
        #region Constructor

        public ItemWindingQuery(string itemId)
        {
            ItemId = itemId;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        #endregion
    }

    internal class ItemWindingQueryHandler : IRequestHandler<ItemWindingQuery, IEnumerable<WindingModel>>
    {
        #region Fields

        private readonly ControlPisoMX.ERP.IMicroservice erp;

        #endregion

        #region Constructor

        public ItemWindingQueryHandler(ControlPisoMX.ERP.IMicroservice erp)
        {
            this.erp = erp;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<WindingModel>> Handle(ItemWindingQuery request, CancellationToken cancellationToken)
        { 
            ERP.Models.WindingModel? itemWindingDesign = await erp.GetWindingAsync(request.ItemId)
                 .ConfigureAwait(false);

            if (itemWindingDesign == null)
            {
                return Enumerable.Empty<WindingModel>();
            }

            return new List<WindingModel>()
            {
                new WindingModel()
                {
                    Winding = "CONDUCTOR",
                    BTI = itemWindingDesign.Connector?.BTI
                        .Select(e => e.Value)
                        .Aggregate("", (accumulated, next) => string.IsNullOrEmpty(accumulated) ? next : $"{accumulated}\r{next}") ?? "",
                    CoilSequence1 = "",
                    CoilSequence2 = "",
                    BTE = ""
                },
                new WindingModel()
                {
                    Winding = "PUNTA INICIAL",
                    BTI = itemWindingDesign.InitPoint?.BTI
                        .Select(e => e.Value)
                        .Aggregate("", (accumulated, next) => string.IsNullOrEmpty(accumulated) ? next : $"{accumulated}\r{next}") ?? "",
                    CoilSequence1 = itemWindingDesign.InitPoint?.CoilSequence1
                        .Select(e => e.Value)
                        .Aggregate("", (accumulated, next) => string.IsNullOrEmpty(accumulated) ? next : $"{accumulated}\r{next}") ?? "",
                    CoilSequence2 = itemWindingDesign.InitPoint?.CoilSequence2
                        .Select(e => e.Value)
                        .Aggregate("", (accumulated, next) => string.IsNullOrEmpty(accumulated) ? next : $"{accumulated}\r{next}") ?? "",
                    BTE = itemWindingDesign.InitPoint?.BTE
                        .Select(e => e.Value)
                        .Aggregate("", (accumulated, next) => string.IsNullOrEmpty(accumulated) ? next : $"{accumulated}\r{next}") ?? "",
                },
                new WindingModel()
                {
                    Winding = "PUNTA FINAL",
                    BTI = itemWindingDesign.FinalPoint?.BTI
                        .Select(e => e.Value)
                        .Aggregate("", (accumulated, next) => string.IsNullOrEmpty(accumulated) ? next : $"{accumulated}\r{next}") ?? "",
                    CoilSequence1 = itemWindingDesign.FinalPoint?.CoilSequence1
                        .Select(e => e.Value)
                        .Aggregate("", (accumulated, next) => string.IsNullOrEmpty(accumulated) ? next : $"{accumulated}\r{next}") ?? "",
                    CoilSequence2 = itemWindingDesign.FinalPoint?.CoilSequence2
                        .Select(e => e.Value)
                        .Aggregate("", (accumulated, next) => string.IsNullOrEmpty(accumulated) ? next : $"{accumulated}\r{next}") ?? "",
                    BTE = itemWindingDesign.FinalPoint?.BTE
                        .Select(e => e.Value)
                        .Aggregate("", (accumulated, next) => string.IsNullOrEmpty(accumulated) ? next : $"{accumulated}\r{next}") ?? "",
                },
                new WindingModel()
                {
                    Winding = "COMBO",
                    BTI = itemWindingDesign.Combo?.BTI
                        .Select(e => e.Value)
                        .Aggregate("", (accumulated, next) => string.IsNullOrEmpty(accumulated) ? next : $"{accumulated}\r{next}") ?? "",
                    CoilSequence1 = "",
                    CoilSequence2 = "",
                    BTE = ""
                }
            };
        }

        #endregion
    }
}