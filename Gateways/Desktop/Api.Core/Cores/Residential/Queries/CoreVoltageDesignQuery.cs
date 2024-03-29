﻿namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Cores.Models;

    using MediatR;
    using Microsoft.Extensions.Configuration;
    using ProlecGE.ControlPisoMX.BFWeb.Components;

    public class CoreVoltageDesignQuery
        : IRequest<CoreVoltageDesignModel?>
    {
        #region Constructor

        public CoreVoltageDesignQuery(
            string itemId, int coreSize)
        {
            ItemId = itemId;
            CoreSize = coreSize;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        public int CoreSize { get; }

        #endregion
    }

    public class CoreVoltageDesignQueryHandler
        : IRequestHandler<CoreVoltageDesignQuery, CoreVoltageDesignModel?>
    {
        #region Fields

        private readonly ERP.IMicroservice erp;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public CoreVoltageDesignQueryHandler(
            ERP.IMicroservice erp,IConfiguration configuration)
        {
            this.erp = erp;
            this._configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task<CoreVoltageDesignModel?> Handle(
            CoreVoltageDesignQuery request, CancellationToken cancellationToken)
        {
            ERP.Models.ItemModel? item = bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ?
                await erp.GetItemAsync(request.ItemId, cancellationToken)
                .ConfigureAwait(false):
                await erp.GetItemAsync_discpiso(request.ItemId, cancellationToken)
                .ConfigureAwait(false);

            if (item == null)
            {
                return null;
            }

            ERP.Models.ItemVoltageDesignModel? coreVoltageDesign = bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ?
            await erp.GetItemVoltageDesignAsync(
                item.ItemId,
                item.DesignId,
                request.CoreSize,
                cancellationToken).ConfigureAwait(false)
            :
            await erp.GetItemVoltageDesignAsync_LN(
                item.ItemId,
                item.DesignId,
                request.CoreSize,
                int.Parse(_configuration.GetSection("Cia").Value.ToString()),
                cancellationToken).ConfigureAwait(false);

            return coreVoltageDesign != null
                ? new CoreVoltageDesignModel(item.DesignId)
                {
                    KVA = coreVoltageDesign.KVA,
                    PrimaryVoltage = coreVoltageDesign.PrimaryVoltage,
                    SecondaryVoltage = coreVoltageDesign.SecondaryVoltage,
                    TestVoltage = coreVoltageDesign.TestVoltage,
                    Limits = coreVoltageDesign.Limits
                        .Select(i => new CoreVoltageLimitModel((CoreLimitColor)i.Color, i.Min, i.Max))
                        .ToArray()
                }
                : null;
            
        }

        #endregion
    }
}