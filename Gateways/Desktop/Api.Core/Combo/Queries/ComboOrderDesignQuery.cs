namespace ProlecGE.ControlPisoMX.BFWeb.Components.Combo.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Models;

    public class ComboOrderDesignQuery : IRequest<IEnumerable<ComboOrderDesignModel>>
    {
        public ComboOrderDesignQuery(string itemId)
        {
            ItemId = itemId;
        }

        #region Properties
        public string ItemId { set; get; }
        #endregion
    }

    public class ComboOrderDesignQueryHandler
    : IRequestHandler<ComboOrderDesignQuery, IEnumerable<ComboOrderDesignModel>>
    {
        #region Fields

        private readonly ILogger<ComboOrderDesignQueryHandler> logger;
        private readonly ControlPisoMX.ERP.IMicroservice erp;

        #endregion

        #region Constructor

        public ComboOrderDesignQueryHandler(
            ILogger<ComboOrderDesignQueryHandler> logger,
            ControlPisoMX.ERP.IMicroservice erp)
        {
            this.logger = logger;
            this.erp = erp;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<ComboOrderDesignModel>> Handle(ComboOrderDesignQuery request, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Consultando los diseños de orden.");

                IEnumerable<ComboOrderDesignModel>? designs = (await erp
                    .GetComboOrderDesignAsync(request.ItemId, CancellationToken.None)
                    .ConfigureAwait(false))
                    .Select(e => new ComboOrderDesignModel()
                    {
                        #region Load

                        TBUNU = e.TBUNU,
                        TPROL = e.TPROL,
                        TRATI = e.TRATI,
                        TPHAS = e.TPHAS,
                        THVN1 = e.THVN1,
                        THVN2 = e.THVN2,
                        THVBN = e.THVBN,
                        THVBI = e.THVBI,
                        TTAPL = e.TTAPL,
                        TLVNU = e.TLVNU,
                        TANUM = e.TANUM,
                        TBNUM = e.TBNUM,
                        THANB = e.THANB,
                        TARRN = e.TARRN,
                        TLVBK = e.TLVBK,
                        TLVBS = e.TLVBS,
                        THVCF = e.THVCF,
                        TTIFF = e.TTIFF,
                        TINTE = e.TINTE,
                        TSPSV = e.TSPSV,
                        TINAR = e.TINAR,
                        TCMPN = e.TCMPN,
                        TCOWE = e.TCOWE,
                        TBMPN = e.TBMPN,
                        TBEWE = e.TBEWE,
                        TTMPN = e.TTMPN,
                        TTAWE = e.TTAWE,
                        TN1PN = e.TN1PN,
                        TN1QN = e.TN1QN,
                        TN2PN = e.TN2PN,
                        TN2QN = e.TN2QN,
                        TN3PN = e.TN3PN,
                        TN3QN = e.TN3QN,
                        TN4PN = e.TN4PN,
                        TN4QN = e.TN4QN,
                        TN5PN = e.TN5PN,
                        TN5QN = e.TN5QN,
                        TLIFT = e.TLIFT,
                        THBLP = e.THBLP,
                        THBUP = e.THBUP,
                        TRAPN = e.TRAPN,
                        TRAWE = e.TRAWE,
                        TRAQN = e.TRAQN,
                        TRAHC = e.TRAHC,
                        TRAA1 = e.TRAA1,
                        TRAA2 = e.TRAA2,
                        TCUCN = e.TCUCN,
                        TGNLN = e.TGNLN,
                        TGLLN = e.TGLLN,
                        TGAZN = e.TGAZN,
                        TGALN = e.TGALN,
                        TTADN = e.TTADN,
                        TTAHN = e.TTAHN,
                        TASPN = e.TASPN,
                        TRILN = e.TRILN,
                        TADIM = e.TADIM,
                        TBDIM = e.TBDIM,
                        TCDIM = e.TCDIM,
                        TINTW = e.TINTW,
                        TTFWN = e.TTFWN,
                        TOILN = e.TOILN,
                        TTOTW = e.TTOTW,
                        TAWRN = e.TAWRN,
                        TTORN = e.TTORN,
                        TCORW = e.TCORW,
                        TFDEN = e.TFDEN,
                        TCOMA = e.TCOMA,
                        TDIMA = e.TDIMA,
                        TDIMB = e.TDIMB,
                        TDIMC = e.TDIMC,
                        TDIMD = e.TDIMD,
                        TDID1 = e.TDID1,
                        THVCM = e.THVCM,
                        TLVCM = e.TLVCM,
                        THVCW = e.THVCW,
                        TLVCW = e.TLVCW,
                        THVRE = e.THVRE,
                        TLVRE = e.TLVRE,
                        THVED = e.THVED,
                        TLVED = e.TLVED,
                        TDCRE = e.TDCRE,
                        TDEID = e.TDEID,
                        TREVN = e.TREVN,
                        TSTAT = e.TSTAT,
                        TSTDR = e.TSTDR,
                        TTATY = e.TTATY,
                        TLVBN = e.TLVBN,
                        TLVBP = e.TLVBP,
                        TBAMP = e.TBAMP,
                        TBAWE = e.TBAWE,
                        TWDTI = e.TWDTI,
                        TPRWI = e.TPRWI,
                        TANQN = e.TANQN,
                        TANPN = e.TANPN,
                        TBNPN = e.TBNPN,
                        TPHPN = e.TPHPN,
                        TBPPN = e.TBPPN,
                        TDVPN = e.TDVPN,
                        TTAPN = e.TTAPN,
                        TRAPA = e.TRAPA,
                        TRES1 = e.TRES1,
                        TRES2 = e.TRES2,
                        TRES3 = e.TRES3,
                        TRES4 = e.TRES4,
                        TRES5 = e.TRES5,
                        TRDD1 = e.TRDD1,
                        TRDD2 = e.TRDD2,
                        TLGRN = e.TLGRN,
                        TCGRN = e.TCGRN,
                        TSPO1 = e.TSPO1,
                        TSPO2 = e.TSPO2,
                        TBUST = e.TBUST,
                        TBUSQ = e.TBUSQ,
                        TCLPN = e.TCLPN,
                        TDCR2 = e.TDCR2,
                        TRES6 = e.TRES6,
                        TRES7 = e.TRES7,
                        TRES8 = e.TRES8,
                        TRES9 = e.TRES9,
                        TRE10 = e.TRE10,
                        TRE11 = e.TRE11,
                        TRE12 = e.TRE12,
                        TRE13 = e.TRE13,
                        TRE14 = e.TRE14,
                        TRE15 = e.TRE15,
                        TL127 = e.TL127,
                        TL178 = e.TL178,
                        TL254 = e.TL254,
                        TLEXT = e.TLEXT,
                        TAEXT = e.TAEXT,
                        TEEXT = e.TEEXT,
                        TLPL1 = e.TLPL1,
                        TAPL1 = e.TAPL1,
                        TCPL1 = e.TCPL1,
                        TEPL1 = e.TEPL1,
                        TLPL2 = e.TLPL2,
                        TAPL2 = e.TAPL2,
                        TCPL2 = e.TCPL2,
                        TEPL2 = e.TEPL2,
                        TLPDC = e.TLPDC,
                        TAPDC = e.TAPDC,
                        TEPDC = e.TEPDC,
                        TLCMM = e.TLCMM,
                        TLLMM = e.TLLMM,
                        TACAS = e.TACAS,
                        TECAS = e.TECAS,
                        TCCN1 = e.TCCN1,
                        TACN1 = e.TACN1,
                        TECN1 = e.TECN1,
                        TCCN2 = e.TCCN2,
                        TACN2 = e.TACN2,
                        TECN2 = e.TECN2,
                        TPCPN = e.TPCPN,
                        TPCQY = e.TPCQY,
                        TRE16 = e.TRE16,
                        TRE17 = e.TRE17,
                        TRE18 = e.TRE18,
                        TRE19 = e.TRE19,
                        TRE20 = e.TRE20,
                        TRE21 = e.TRE21,
                        TRE22 = e.TRE22,
                        TRE23 = e.TRE23,
                        TRE24 = e.TRE24,
                        TRE25 = e.TRE25,
                        TRE26 = e.TRE26,
                        TRE27 = e.TRE27,
                        TRE28 = e.TRE28,
                        TATBT = e.TATBT,
                        TQTBT = e.TQTBT,
                        TALTT = e.TALTT,
                        TABET = e.TABET,
                        TQBET = e.TQBET,
                        TAPET = e.TAPET,
                        TQPET = e.TQPET,
                        TARPB = e.TARPB,
                        TARRT = e.TARRT,
                        TARTB = e.TARTB,
                        TATRT = e.TATRT,
                        TAETT = e.TAETT,
                        TATCI = e.TATCI,
                        TATUC = e.TATUC,
                        TABCI = e.TABCI,
                        TATTT = e.TATTT,
                        TARTT = e.TARTT,
                        TARPT = e.TARPT,
                        TATCN = e.TATCN,
                        TATNB = e.TATNB,
                        TARNB = e.TARNB,
                        TAPCA = e.TAPCA,
                        TAGB1 = e.TAGB1,
                        TAGB2 = e.TAGB2,
                        TACGB = e.TACGB,
                        TABGB = e.TABGB,
                        TABAT = e.TABAT,
                        TARGB = e.TARGB,
                        TARRG = e.TARRG,
                        TATGB = e.TATGB,
                        TABUG = e.TABUG,
                        TACVD = e.TACVD,
                        TAVAM = e.TAVAM,
                        TASSC = e.TASSC,
                        TALUP = e.TALUP,
                        TALPS = e.TALPS,
                        TADES = e.TADES,
                        TARRP = e.TARRP,
                        TRE29 = e.TRE29,
                        TRE30 = e.TRE30,
                        TRE31 = e.TRE31,
                        TRE32 = e.TRE32,
                        TRE33 = e.TRE33,
                        TSKRT = e.TSKRT,
                        TFDIM = e.TFDIM,
                        TATAP = e.TATAP,
                        TRE34 = e.TRE34,
                        TRE35 = e.TRE35,
                        TREFCNTD = e.TREFCNTD,
                        TREFCNTU = e.TREFCNTU

                        #endregion
                    });

                if (designs is null)
                {
                    designs = Enumerable.Empty<ComboOrderDesignModel>();
                }

                return designs;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar los diseños de ordenes.");
                throw;
            }
        }

        #endregion
    }
}
