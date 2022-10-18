namespace Cores.Services
{
    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using ERP.Entities;

    public class CoresPlanningService : BaseService
    {
        #region Constructor

        public CoresPlanningService(DbContext context) : base(context) { }

        #endregion

        #region Methods

        public async Task<DateTime?> GetScheduledDateAsync(string manufacturingLineCode, int previousDays, int nextDays)
        {
            DateTime targetDate = DateTime.Today;

            DateTime startDate = targetDate.AddDays(previousDays * -1);
            DateTime endDate = targetDate.AddDays(nextDays);

            return await Context.Set<Ttipge021006>().AsNoTracking()
                .Where(e => e.TPlnc == "NU1" && e.TStat == 1)
                .Where(e => e.TComa != "AM" && e.TCmhr == 0m)
                .Where(e => e.TPrdt >= startDate && e.TPrdt <= endDate)
                .Where(e => e.TPrln == manufacturingLineCode)
                .OrderBy(e => e.TPrdt)
                .Select(e => (DateTime?)e.TPrdt)
                .DefaultIfEmpty()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<string>> GetDesignsAsync(string manufacturingLineCode, DateTime date)
        {
            var query = GetNU1Query(date)
                .Where(e => e.TPrln == manufacturingLineCode)
                .OrderBy(e => e.TPrdt)
                .Select(e => e.TItem)
                .Distinct();

            return await query.ToArrayAsync();
        }

        #endregion

        #region Functionality

        private IQueryable<Ttipge021006> GetNU1Query(DateTime date)
        {
            //Plan subordinado
            return Context.Set<Ttipge021006>().AsNoTracking()
                .Where(e => e.TPlnc == "NU1" && e.TStat == 1)
                .Where(e => e.TPrdt == date && e.TCmdt < new DateTime(1900, 01, 01));
        }

        private VoltageInfoModel GetItem(string item)
        {
            string designID = item;

            var sumergibleValue = Context.Set<Ttiitm001006>().Where(e => e.TItem == item).Select(e => e.TCitg).FirstOrDefault();

            if (sumergibleValue != "1SM")
            {
                var design = Context.Set<Ttibom010006>().AsNoTracking()
                    .Where(e => e.TPono == 10)
                    .Where(e => e.TMitm == item)
                    .Select(e => new
                    {
                        e.TSitm,
                        TExdt = (e.TExdt > new DateTime(1900, 01, 01)) ? e.TExdt : (DateTime?)null
                    })
                    .FirstOrDefault();

                if (design != null)
                {
                    return new VoltageInfoModel(design.TSitm)
                    {
                        TExdt = design.TExdt,
                    };
                }
            }

            if (!string.IsNullOrEmpty(designID))
            {
                return new VoltageInfoModel(designID);
            }
            else
            {
                return null;
            }
        }

        private bool IsAmorphous(VoltageInfoModel design)
        {
            if (design == null) return false;

            string coma = Context.Set<Ttipge030006>().AsNoTracking()
                .Where(e => e.TBunu == design.ID)
                .Select(e => e.TComa)
                .FirstOrDefault();

            return coma == "AM";
        }

        #endregion
    }
}