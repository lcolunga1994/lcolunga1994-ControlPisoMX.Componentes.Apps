namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Cores.Models;

    using MediatR;
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
        private readonly LN.ITtxpcf925Repository ln;
        private readonly AppSettings _appSettings;

        #endregion

        #region Constructor

        public CoreVoltageDesignQueryHandler(
            ERP.IMicroservice erp, LN.ITtxpcf925Repository ln, AppSettings _appSettings)
        {
            this.erp = erp;
            this.ln = ln;
            this._appSettings = _appSettings;
        }

        #endregion

        #region Methods

        public async Task<CoreVoltageDesignModel?> Handle(
            CoreVoltageDesignQuery request, CancellationToken cancellationToken)
        {
            ERP.Models.ItemModel? item =
                await erp.GetItemAsync(request.ItemId, cancellationToken)
                .ConfigureAwait(false);

            if (item == null)
            {
                return null;
            }

            if (_appSettings.AmbientERP) //Apunta a ERP BAAN4
            {
                ERP.Models.ItemVoltageDesignModel? coreVoltageDesign = await erp
                .GetItemVoltageDesignAsync(
                    item.ItemId,
                    item.DesignId,
                    request.CoreSize,
                    cancellationToken)
                .ConfigureAwait(false);

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
            else //Trae valores de diseño y colores de LN, Luis Colunga, 24/Ago/2022.
            {

                ProlecGE.ControlPisoMX.BFWeb.Components.Services.LN.Models.ItemVoltageDesignModel? coreVoltageDesign
                    = await ln.GetItemVoltageDesignAsync(
                        _appSettings.cia,
                        item.ItemId,
                        item.DesignId,
                        cancellationToken)
                    .ConfigureAwait(false);

                if (coreVoltageDesign.KVA == 0 && coreVoltageDesign.PrimaryVoltage == 0)
                {
                    ERP.Models.ItemVoltageDesignModel? coreVoltageDesignERP = await erp
                                               .GetItemVoltageDesignAsync_sqlctp(
                                                   item.ItemId,
                                                   item.DesignId,
                                                   request.CoreSize,
                                                   cancellationToken)
                                               .ConfigureAwait(false);
                    if (coreVoltageDesignERP is null)
                        return null;
                    else
                    {
                        return new CoreVoltageDesignModel(item.DesignId)
                        {
                            KVA = coreVoltageDesignERP.KVA,
                            PrimaryVoltage = coreVoltageDesignERP.PrimaryVoltage,
                            SecondaryVoltage = coreVoltageDesignERP.SecondaryVoltage,
                            TestVoltage = coreVoltageDesignERP.TestVoltage,

                            Limits = coreVoltageDesignERP.Limits
                            .Select(i => new CoreVoltageLimitModel((CoreLimitColor)i.Color, i.Min, i.Max))
                            .ToArray()
                        };
                    }
                }
                else
                {
                    return new CoreVoltageDesignModel(item.DesignId)
                    {
                        KVA = coreVoltageDesign.KVA,
                        PrimaryVoltage = coreVoltageDesign.PrimaryVoltage,
                        SecondaryVoltage = coreVoltageDesign.SecondaryVoltage,
                        TestVoltage = coreVoltageDesign.TestVoltage,

                        Limits = coreVoltageDesign.Limits
                            .Select(i => new CoreVoltageLimitModel((CoreLimitColor)i.Color, i.Min, i.Max))
                            .ToArray()
                    };
                }

                //return coreVoltageDesign != null
                //    ? new CoreVoltageDesignModel(item.DesignId)
                //    {
                //        KVA = coreVoltageDesign.KVA,
                //        PrimaryVoltage = coreVoltageDesign.PrimaryVoltage,
                //        SecondaryVoltage = coreVoltageDesign.SecondaryVoltage,
                //        TestVoltage = coreVoltageDesign.TestVoltage,

                //        Limits = coreVoltageDesign.Limits
                //            .Select(i => new CoreVoltageLimitModel((CoreLimitColor)i.Color, i.Min, i.Max))
                //            .ToArray()
                //    }
                //    : null;
            }
        }

        #endregion
    }
}