#nullable enable

namespace Cores.Services
{
    using Cores.BFF.Web;
    using Cores.Models;

    using Catalogs.Models;

    using Microsoft.EntityFrameworkCore;

    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;
    using ERP.Entities;
    using System.Linq;
    using Dapper;
    
    public class CatalogsService : BaseService
    {
        #region Constructor

        public CatalogsService(DbContext context) : base(context) { }

        #endregion

        #region Methods

        public async Task<ItemModel?> GetItemAsync(string? itemID)
        {
            if (string.IsNullOrEmpty(itemID)) return null;

            string designID = itemID;

            ItemModel? item = (await Context.Database
                .GetDbConnection()
                .QueryAsync<ItemModel>($"SELECT \"T\".\"T$CTYP\" \"CTyp\", \"T\".\"T$CITG\" \"Citg\" FROM \"BAAN4\".\"TTIITM001006\" \"T\" WHERE (\"T\".\"T$ITEM\" = '{itemID}')")
                .ConfigureAwait(false))
                .FirstOrDefault();

            if (item != null)
            {
                item.ItemID = itemID;
                item.DesignID = itemID;

                if (item.Citg?.Trim() != "1SM")
                {
                    item.DesignID = await Context.Set<Ttibom010006>().AsNoTracking()
                        .Where(e => e.TPono == 10)
                        .Where(e => e.TMitm == itemID)
                        .Select(e => e.TSitm)
                        .FirstOrDefaultAsync()
                        .ConfigureAwait(false);
                }
            }

            return item;
        }

        public async Task<string?> GetItemDesignIDAsync(string? itemID)
        {
            ItemModel? item = await GetItemAsync(itemID).ConfigureAwait(false);

            return item?.DesignID;
        }

        #endregion
    }
}

namespace Cores.Models
{
    
}