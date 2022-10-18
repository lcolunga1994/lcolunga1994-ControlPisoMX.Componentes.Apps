﻿namespace ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using AutoMapper;

    using MediatR;

    using Models;

    public class SierraShearsQuery : IRequest<IEnumerable<SierraShearModel>>
    {
        #region Constructor

        public SierraShearsQuery(
            string itemId)
        {
            ItemId = itemId;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        #endregion
    }

    public class SierraShearsQueryHandler : IRequestHandler<SierraShearsQuery, IEnumerable<SierraShearModel>>
    {
        #region Fields

        private readonly ControlPisoMX.ERP.IMicroservice erp;

        #endregion

        #region Constructor

        public SierraShearsQueryHandler(ControlPisoMX.ERP.IMicroservice erp)
        {
            this.erp = erp;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<SierraShearModel>> Handle(SierraShearsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ControlPisoMX.ERP.Models.SierraShearModel> items = await erp.GetItemSierraShearsAsync(request.ItemId, cancellationToken)
                 .ConfigureAwait(false);

            return items
                .Select(item => new SierraShearModel()
                {
                    DesignId = item.DesignId,
                    Item = item.Item,
                    Description = item.Description,
                    Quantity = item.Quantity,
                    L = item.L,
                    A = item.A,
                    B = item.B,
                    Y = item.Y,
                    T = item.T,
                    Dimensions = item.Dimensions,
                    Fold = item.Fold,
                })
                .ToList();
        }

        #endregion
    }
}