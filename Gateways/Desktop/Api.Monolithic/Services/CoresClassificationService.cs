#nullable enable

namespace Cores.Services
{
    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using Entities;

    public class CoresClassificationService : BaseService
    {
        #region Constructor

        public CoresClassificationService(DbContext context) : base(context) { }

        #endregion

        #region Methods

        internal async Task ClassifyItemAsync(ItemModel item)
        {
            if (!await IsItemClassifiedAsync(item.ItemID).ConfigureAwait(false))
            {
                _ = int.TryParse(item.CTyp, out int fases);
                string type = "";
                string family = "";
                string division = "";
                string market = "";

                if (item.Citg == "1PT" || item.Citg == "3PT")
                {
                    type = "POS";
                }
                else if (item.Citg == "1PM")
                {
                    type = "PED";
                }

                TblClasifica classification = new TblClasifica()
                {
                    Producto = item.ItemID,
                    Tipo = type,
                    Fases = fases,
                    Familia = family,
                    Division = division,
                    Mercado = market,
                };
            }
        }

        public async Task<bool> IsItemClassifiedAsync(string itemID)
        {
            return await Context.Set<TblClasifica>()
                .Where(e => e.Producto == itemID)
                .AnyAsync()
                .ConfigureAwait(false);
        }

        #endregion
    }
}