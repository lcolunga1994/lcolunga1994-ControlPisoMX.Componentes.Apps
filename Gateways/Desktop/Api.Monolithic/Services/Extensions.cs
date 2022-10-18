namespace Cores.Services
{
    using ERP.Entities;

    using Microsoft.EntityFrameworkCore;

    using Models;

    using System.Linq;

    internal static class Extensions
    {
        public static IQueryable<DesignModel> ToModels(this IQueryable<Ttipge025006> ttipge025006s)
        {
            return ttipge025006s
                .Select(e => new DesignModel()
                {
                    Revision = (int)e.TRevi,
                    Procedure = e.TProc != null ? e.TProc.Trim() : null,
                    Atribute1 = e.TAtr1 != null ? e.TAtr1.Trim() : null,
                    Atribute2 = e.TAtr2 != null ? e.TAtr2.Trim() : null,
                    String1 = e.TSva1 != null ? e.TSva1.Trim() : null,
                    String2 = e.TSva2 != null ? e.TSva2.Trim() : null,
                    Decimal1 = e.TNva1,
                    Decimal2 = e.TNva2,
                    Decimal3 = e.TNva3,
                });
        }

        



        #region Assembly extensions

        public static IQueryable<Ttipge025006> GetAssemblyDesign(this DbContext dbContext, string designID)
        {
            return dbContext.Set<Ttipge025006>()
                .AsNoTracking()
                .Where(e => e.TCwoc == "ENS")
                .Where(e => e.TBunu == designID);
        }

        public static IQueryable<NotaModel> GetTIP28(this DbContext dbContext)
        {
            return dbContext.Set<Ttipge028006>().AsNoTracking()
                .Where(e => e.THoja == "EN")
                .Join(dbContext.Set<Ttttxt010006>().AsNoTracking(), ik => ik.TTxta, ok => ok.TCtxt, (tip28, txt) => new Models.NotaModel()
                {
                    TItem = tip28.TItem,
                    TRevo = tip28.TRevo,
                    TTxta = txt.TText,
                    TUser = tip28.TUser,
                    TTrdt = tip28.TTrdt
                });
        }
        
        #endregion

        #region CMS extensions
        
        private static IQueryable<Ttipge025006> GetManufacturingDesigns(this DbContext dbContext, string designID)
        {
            return dbContext.Set<Ttipge025006>()
                .AsNoTracking()
                .Where(e => e.TCwoc == "CMS")
                .Where(e => e.TBunu == designID);
        }

        #endregion
    }
}